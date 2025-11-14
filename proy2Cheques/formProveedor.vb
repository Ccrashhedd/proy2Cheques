Imports System.Text.RegularExpressions
Imports MySqlConnector

Public Class formProveedor

    Public Event ProveedorAgregado(sender As Object, e As EventArgs)

    Dim conexion As String = "Server=localhost;Database=proycheque;Uid=root;Pwd=;"

    ' Al cargar el formulario
    Private Sub formProveedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Añadir handlers para validaciones
        AddHandler TextBox1.KeyPress, AddressOf TextBox1_KeyPress ' Código
        AddHandler TextBox2.KeyPress, AddressOf TextBox2_KeyPress ' Nombre
        AddHandler TextBox3.KeyPress, AddressOf TextBox3_KeyPress ' RUC
    End Sub

    ' Cuando se presiona el botón de AGREGAR
    Private Sub MaterialButton1_Click(sender As Object, e As EventArgs) Handles MaterialButton1.Click
        Try
            ' Leer y normalizar valores
            Dim codigoRaw = TextBox1.Text.Trim()
            Dim nombre = TextBox2.Text.Trim()
            Dim rucRaw = TextBox3.Text.Trim().ToUpper()
            Dim direccion = TextBox4.Text.Trim()

            ' ------------------ Validar CÓDIGO ------------------
            If String.IsNullOrWhiteSpace(codigoRaw) Then
                MessageBox.Show("Ingrese el código del proveedor.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextBox1.Focus()
                Return
            End If

            ' Validar que sea solo números
            If Not Regex.IsMatch(codigoRaw, "^\d+$") Then
                MessageBox.Show("El código solo debe contener dígitos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextBox1.Focus()
                Return
            End If

            ' Validar longitud (entre 1 y 6 dígitos)
            If codigoRaw.Length < 1 OrElse codigoRaw.Length > 6 Then
                MessageBox.Show("El código debe tener entre 1 y 6 dígitos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextBox1.Focus()
                Return
            End If

            ' Validar valor mayor a cero
            Dim codigoVal As Integer = 0
            If Not Integer.TryParse(codigoRaw, codigoVal) OrElse codigoVal <= 0 Then
                MessageBox.Show("El código debe ser un número entero mayor que cero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextBox1.Focus()
                Return
            End If

            ' Verificar que el código sea único
            If CodigoExisteEnBD(codigoRaw) Then
                MessageBox.Show("El código de proveedor ya está registrado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextBox1.Focus()
                Return
            End If

            ' ------------------ Validar NOMBRE ------------------
            If String.IsNullOrWhiteSpace(nombre) Then
                MessageBox.Show("Ingrese el nombre del proveedor.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextBox2.Focus()
                Return
            End If

            If nombre.Length < 3 Then
                MessageBox.Show("El nombre debe tener al menos 3 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextBox2.Focus()
                Return
            End If

            If nombre.Length > 50 Then
                MessageBox.Show("El nombre no puede superar los 50 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextBox2.Focus()
                Return
            End If

            ' Permitir solo letras, números, espacios, acentos, &, ., -, /
            If Not Regex.IsMatch(nombre, "^[A-Za-zÁÉÍÓÚÑáéíóúñ0-9&\.\-\s\/]+$") Then
                MessageBox.Show("El nombre contiene caracteres no permitidos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextBox2.Focus()
                Return
            End If

            ' Validar RUC
            If String.IsNullOrWhiteSpace(rucRaw) Then
                MessageBox.Show("Ingrese el RUC del proveedor.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextBox3.Focus()
                Return
            End If

            ' Validar que el RUC tenga el formato adecuado: cédula (8 dígitos con guion) o RUC de empresa (11 dígitos con guion)
            If Not Regex.IsMatch(rucRaw, "^\d{1}-\d{4}-\d{4}$") AndAlso Not Regex.IsMatch(rucRaw, "^\d{2}-\d{3}-\d{4}$") Then
                MessageBox.Show("El RUC debe tener el formato válido (Ej. 4-1234-5678 o 12-345-6789).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextBox3.Focus()
                Return
            End If


            ' Verificar que el RUC sea único
            If RucExisteEnBD(rucRaw) Then
                MessageBox.Show("El RUC ingresado ya está registrado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextBox3.Focus()
                Return
            End If

            ' ------------------ Validar DIRECCIÓN ------------------
            If String.IsNullOrWhiteSpace(direccion) Then
                MessageBox.Show("Ingrese la dirección del proveedor.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextBox4.Focus()
                Return
            End If

            If direccion.Length > 250 Then
                MessageBox.Show("La dirección no puede superar los 250 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextBox4.Focus()
                Return
            End If

            ' ------------------ Insertar en BD ------------------
            Dim resultado As String = moduloProveedor.agregarProveedor(codigoRaw, nombre, rucRaw, direccion)
            MessageBox.Show(resultado)

            ' Limpiar campos si la operación fue exitosa
            If resultado IsNot Nothing AndAlso resultado.ToLower().Contains("correctamente") Then
                ClearFields()
                Try
                    RaiseEvent ProveedorAgregado(Me, EventArgs.Empty)
                Catch
                End Try
            End If

        Catch ex As Exception
            MessageBox.Show("Error al intentar agregar proveedor: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Limpiar campos (útil después de agregar proveedor)
    Public Sub ClearFields()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox1.Focus()
    End Sub

    ' Validar que solo se ingresen números en el campo código
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs)
        ' Validar solo números y no permitir más caracteres después de 6
        If Char.IsControl(e.KeyChar) Then Return
        If Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
        ' Limitar la longitud a 6 caracteres
        If TextBox1.Text.Length >= 6 AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    ' Validar solo caracteres válidos en el campo nombre
    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs)
        ' Permitir solo letras, espacios, acentos y caracteres especiales
        If Char.IsControl(e.KeyChar) Then Return
        If Not Regex.IsMatch(e.KeyChar.ToString(), "[A-Za-zÁÉÍÓÚÑáéíóúñ0-9&\.\-\s\/]") Then
            e.Handled = True
        End If
        ' Limitar la longitud a 50 caracteres
        If TextBox2.Text.Length >= 50 AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    ' Validar solo números en el campo RUC
    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs)
        ' Permitir solo números y guion
        If Char.IsControl(e.KeyChar) Then Return
        If Not Regex.IsMatch(e.KeyChar.ToString(), "[\d\-]") Then
            e.Handled = True
        End If
        ' Limitar la longitud a 11 caracteres para el RUC
        If TextBox3.Text.Length >= 11 AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    ' Consultar si el código ya existe en la BD
    Private Function CodigoExisteEnBD(codigo As String) As Boolean
        Try
            Using conn As New MySqlConnection(conexion)
                conn.Open()
                Dim sql As String = "SELECT COUNT(1) FROM proveedores WHERE codigo = @codigo"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@codigo", codigo)
                    Dim count = Convert.ToInt32(cmd.ExecuteScalar())
                    Return count > 0
                End Using
            End Using
        Catch ex As Exception
            Debug.WriteLine("Error al verificar código en BD: " & ex.Message)
            Return False
        End Try
    End Function

    ' Consultar si el RUC ya existe en la BD
    Private Function RucExisteEnBD(ruc As String) As Boolean
        Try
            Using conn As New MySqlConnection(conexion)
                conn.Open()
                Dim sql As String = "SELECT COUNT(1) FROM proveedores WHERE ruc = @ruc"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@ruc", ruc)
                    Dim count = Convert.ToInt32(cmd.ExecuteScalar())
                    Return count > 0
                End Using
            End Using
        Catch ex As Exception
            Debug.WriteLine("Error al verificar RUC en BD: " & ex.Message)
            Return False
        End Try
    End Function

End Class
