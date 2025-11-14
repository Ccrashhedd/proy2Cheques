Imports System.Data.SqlClient
Imports MySqlConnector
Imports System.Globalization

Public Class formCheque

    Dim cm As MySqlCommand
    Dim pr As MySqlDataAdapter
    Dim dsl As DataSet
    Dim conexion As String =
        "Server=localhost;Database=proycheque;Uid=root;Pwd=;"
    Dim miconexion As New MySqlConnection(conexion)

    Dim proveedores As String
    Dim objGasto As String

    Private Sub formCheque_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Inicializar DateTimePicker vacío (sin fecha visible)
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = " "
        ' Asegura que el control no muestre tiempo; usaremos .Value.Date al leer

        ' Asegurar que los combobox no permitan escritura manual
        Try
            comboBoxProveedor.DropDownStyle = ComboBoxStyle.DropDownList
        Catch ex As Exception
            Debug.WriteLine("No se pudo establecer DropDownStyle en comboBoxProveedor: " & ex.Message)
        End Try
        Try
            comboBoxObjGas.DropDownStyle = ComboBoxStyle.DropDownList
        Catch ex As Exception
            Debug.WriteLine("No se pudo establecer DropDownStyle en comboBoxObjGas: " & ex.Message)
        End Try

        ' Cargar los proveedores en el ComboBox (codigo, nombre) y ordenar alfabéticamente
        Try
            Dim sqlProv As String = "SELECT codigo, nombre FROM proveedores"
            Using da As New MySqlDataAdapter(sqlProv, miconexion)
                Dim dtProv As New DataTable()
                da.Fill(dtProv)
                If comboBoxProveedor IsNot Nothing Then
                    If dtProv.Rows.Count > 0 Then
                        ' Ordenar por nombre ascendente antes de asignar
                        Dim dvProv As DataView = dtProv.DefaultView
                        dvProv.Sort = "nombre ASC"
                        comboBoxProveedor.DataSource = dvProv
                        comboBoxProveedor.DisplayMember = "nombre"
                        comboBoxProveedor.ValueMember = "codigo"
                        comboBoxProveedor.SelectedIndex = -1 ' sin selección por defecto
                    Else
                        comboBoxProveedor.DataSource = Nothing
                        comboBoxProveedor.Items.Clear()
                    End If
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al cargar proveedores: " & ex.Message)
        End Try

        ' Cargar los objetos de gasto en el ComboBox (codigo, detalle) y ordenar alfabéticamente
        Try
            Dim sqlObj As String = "SELECT codigo, detalle FROM objeto_gasto"
            Using da As New MySqlDataAdapter(sqlObj, miconexion)
                Dim dtObj As New DataTable()
                da.Fill(dtObj)
                If comboBoxObjGas IsNot Nothing Then
                    If dtObj.Rows.Count > 0 Then
                        Dim dvObj As DataView = dtObj.DefaultView
                        dvObj.Sort = "detalle ASC"
                        comboBoxObjGas.DataSource = dvObj
                        comboBoxObjGas.DisplayMember = "detalle"
                        comboBoxObjGas.ValueMember = "codigo"
                        comboBoxObjGas.SelectedIndex = -1
                    Else
                        comboBoxObjGas.DataSource = Nothing
                        comboBoxObjGas.Items.Clear()
                    End If
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al cargar objetos de gasto: " & ex.Message)
        End Try

        ' Inicializar monto en letras vacío
        RichTextBox1.Text = String.Empty
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        ' Cuando el usuario selecciona una fecha, aplicar formato de solo fecha
        DateTimePicker1.CustomFormat = "yyyy-MM-dd" ' o "dd/MM/yyyy" según preferencia
    End Sub

    Private Sub DateTimePicker1_KeyDown(sender As Object, e As KeyEventArgs) Handles DateTimePicker1.KeyDown
        ' Permitir al usuario borrar la fecha con Supr o Backspace: volvemos a formato vacío
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            DateTimePicker1.CustomFormat = " "
        End If
    End Sub

    ' Devuelve Date.MinValue cuando no hay fecha seleccionada
    Public Function ObtenerFechaCreacion() As Date
        If DateTimePicker1.CustomFormat = " " Then
            Return Date.MinValue
        End If
        Return DateTimePicker1.Value.Date
    End Function

    ' Actualizar el texto de "Monto en letras" cuando cambia el TextBox2
    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        Dim texto As String = TextBox2.Text.Trim()
        If String.IsNullOrEmpty(texto) Then
            RichTextBox1.Text = String.Empty
            Return
        End If

        ' Intentar parsear con la cultura actual
        Dim monto As Decimal = 0D
        Dim success As Boolean = Decimal.TryParse(texto, NumberStyles.Number Or NumberStyles.AllowCurrencySymbol, CultureInfo.CurrentCulture, monto)

        ' Si falla, intentar con invariant (aceptar punto como separador) después de limpiar espacios y símbolos
        If Not success Then
            Dim cleaned = texto.Replace(" ", "").Replace("$", "")
            ' permitir tanto coma como punto: normalizar a punto para invariant
            cleaned = cleaned.Replace(",", ".")
            success = Decimal.TryParse(cleaned, NumberStyles.Number, CultureInfo.InvariantCulture, monto)
        End If

        If success Then
            Try
                RichTextBox1.Text = Traduccion.ConvertirAMontoEnPalabras(monto)
            Catch ex As Exception
                RichTextBox1.Text = String.Empty
                Debug.WriteLine("Error al convertir monto a palabras: " & ex.Message)
            End Try
        Else
            ' No mostrar error intrusivo; solo limpiar
            RichTextBox1.Text = String.Empty
        End If
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub MaterialButton1_Click(sender As Object, e As EventArgs) Handles MaterialButton1.Click
        Try
            ' Obtener y validar campos
            Dim numCheque As String = TextBox1.Text.Trim()
            If String.IsNullOrEmpty(numCheque) Then
                MessageBox.Show("Ingrese el número de cheque.")
                Return
            End If

            Dim fecha As Date = ObtenerFechaCreacion()
            If fecha = Date.MinValue Then
                MessageBox.Show("Seleccione la fecha del cheque.")
                Return
            End If

            Dim idProv As String = String.Empty
            If comboBoxProveedor IsNot Nothing AndAlso comboBoxProveedor.SelectedValue IsNot Nothing Then
                idProv = comboBoxProveedor.SelectedValue.ToString()
            End If
            If String.IsNullOrEmpty(idProv) Then
                MessageBox.Show("Seleccione un proveedor.")
                Return
            End If

            Dim idObj As String = String.Empty
            If comboBoxObjGas IsNot Nothing AndAlso comboBoxObjGas.SelectedValue IsNot Nothing Then
                idObj = comboBoxObjGas.SelectedValue.ToString()
            End If
            If String.IsNullOrEmpty(idObj) Then
                MessageBox.Show("Seleccione un objeto de gasto.")
                Return
            End If

            Dim monto As Double = 0
            If Not Double.TryParse(TextBox2.Text.Trim(), monto) Then
                MessageBox.Show("Ingrese un monto válido.")
                Return
            End If

            Dim montoText As String = RichTextBox1.Text.Trim()
            Dim detalle As String = RichTextBox2.Text.Trim()

            ' Llamar al modulo para agregar el cheque
            Dim resultado As String = moduloCheque.agregarCheque(numCheque, fecha, idProv, monto, montoText, detalle, idObj)
            MessageBox.Show(resultado)

            ' Si fue exitoso, limpiar campos
            If resultado IsNot Nothing AndAlso resultado.ToLower().Contains("exitos") Then
                TextBox1.Clear()
                TextBox2.Clear()
                RichTextBox1.Clear()
                RichTextBox2.Clear()
                If comboBoxProveedor IsNot Nothing Then comboBoxProveedor.SelectedIndex = -1
                If comboBoxObjGas IsNot Nothing Then comboBoxObjGas.SelectedIndex = -1
                DateTimePicker1.CustomFormat = " "
            End If

        Catch ex As Exception
            MessageBox.Show("Error al intentar agregar el cheque: " & ex.Message)
        End Try
    End Sub

End Class
