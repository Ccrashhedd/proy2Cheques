Imports System.Data.SqlClient
Imports MySqlConnector
Imports System.Globalization
Imports System.Text.RegularExpressions

Public Class formCheque

    Public Event ChequeAgregado(sender As Object, e As EventArgs)

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

        ' Añadir validadores de entrada
        AddHandler TextBox1.KeyPress, AddressOf TextBox1_KeyPress ' número de cheque: solo dígitos
        AddHandler TextBox2.KeyPress, AddressOf TextBox2_KeyPress ' monto: permitir dígitos y un punto/coma
        ' TextBox2.TextChanged ya maneja parseo y conversión
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

    ' Permitir solo dígitos en número de cheque
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Char.IsControl(e.KeyChar) Then Return
        If Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    ' Validación de tecla para TextBox2: permitir dígitos y un solo punto (o coma)
    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Char.IsControl(e.KeyChar) Then Return

        Dim tb = DirectCast(sender, TextBox)
        Dim ch As Char = e.KeyChar

        If Char.IsDigit(ch) Then
            ' permitir dígitos siempre (TextChanged limpiará el exceso si se pega)
            Return
        End If

        If ch = "."c Or ch = ","c Then
            ' permitir un solo separador decimal
            If Not tb.Text.Contains(".") Then
                ' allow dot (we'll normalize commas later)
                Return
            ElseIf Not tb.Text.Contains(",") And Not tb.Text.Contains(".") Then
                Return
            End If
        End If

        ' Si llegó aquí, carácter no permitido
        e.Handled = True
    End Sub

    ' Actualizar el texto de "Monto en letras" cuando cambia el TextBox2
    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        Dim textoOriginal As String = TextBox2.Text
        If String.IsNullOrEmpty(textoOriginal) Then
            RichTextBox1.Text = String.Empty
            Return
        End If

        ' Normalizar: cambiar comas por punto y eliminar caracteres no numericos (excepto punto)
        Dim t As String = textoOriginal.Replace(" ", "").Replace("$", "").Replace(",", ".")

        ' Eliminar caracteres no dígitos y no punto
        Dim cleaned As String = Regex.Replace(t, "[^0-9\.]", "")

        ' Si hay más de un punto, quedarse con el primero y eliminar el resto
        Dim firstDot = cleaned.IndexOf(".")
        If firstDot >= 0 Then
            Dim before = cleaned.Substring(0, firstDot + 1)
            Dim after = cleaned.Substring(firstDot + 1)
            after = Regex.Replace(after, "\.", "") ' quitar otros puntos
            cleaned = before & after
        End If

        ' Limitar partes: enteros max 7, decimales max 2
        Dim parts = cleaned.Split("."c)
        Dim intPart As String = parts(0)
        If intPart.Length > 7 Then intPart = intPart.Substring(0, 7)
        Dim decPart As String = String.Empty
        If parts.Length > 1 Then
            decPart = parts(1)
            If decPart.Length > 2 Then decPart = decPart.Substring(0, 2)
        End If

        ' Preserve trailing dot if user typed it (allow entering decimals after reaching 7 digits)
        Dim finalText As String
        If parts.Length > 1 Then
            ' user has typed a separator; keep it even if decimals empty
            finalText = intPart & "." & decPart
        Else
            finalText = intPart
        End If

        ' Si el texto fue modificado por limpieza, actualizar textbox conservando caret
        If Not finalText.Equals(textoOriginal) Then
            Dim sel = TextBox2.SelectionStart
            TextBox2.Text = finalText
            TextBox2.SelectionStart = Math.Min(finalText.Length, sel)
        End If

        ' Ahora intentar parsear con invariant culture (punto) o culture actual
        Dim monto As Decimal = 0D
        Dim success As Boolean = Decimal.TryParse(finalText.TrimEnd("."c), NumberStyles.Number Or NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, monto)
        If Not success Then
            ' también intentar con la cultura actual
            success = Decimal.TryParse(finalText.TrimEnd("."c), NumberStyles.Number Or NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture, monto)
        End If

        If success Then
            Try
                RichTextBox1.Text = Traduccion.ConvertirAMontoEnPalabras(monto)
            Catch ex As Exception
                RichTextBox1.Text = String.Empty
                Debug.WriteLine("Error al convertir monto a palabras: " & ex.Message)
            End Try
        Else
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

            ' Validar que el número de cheque sea entero
            Dim numChequeInt As Long = 0
            If Not Long.TryParse(numCheque, numChequeInt) Then
                MessageBox.Show("El número de cheque debe contener solo dígitos enteros.")
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

            ' Validar monto con patrón: hasta 7 enteros, opcional . y hasta 2 decimales
            Dim montoText As String = TextBox2.Text.Trim()
            Dim montoPattern As String = "^\d{1,7}(?:\.\d{1,2})?$"
            If Not Regex.IsMatch(montoText.TrimEnd("."c), montoPattern) Then
                MessageBox.Show("Ingrese un monto válido: hasta 7 dígitos enteros, opcional '.' y hasta 2 decimales (ej. 1234567.89).")
                Return
            End If

            Dim montoVal As Double = 0
            If Not Double.TryParse(montoText, NumberStyles.Number, CultureInfo.InvariantCulture, montoVal) Then
                ' intentar con cultura actual
                If Not Double.TryParse(montoText, NumberStyles.Number, CultureInfo.CurrentCulture, montoVal) Then
                    MessageBox.Show("El monto ingresado no es un número válido.")
                    Return
                End If
            End If

            Dim montoEnLetras As String = RichTextBox1.Text.Trim()
            Dim detalle As String = RichTextBox2.Text.Trim()

            ' Llamar al modulo para agregar el cheque
            Dim resultado As String = moduloCheque.agregarCheque(numChequeInt.ToString(), fecha, idProv, montoVal, montoEnLetras, detalle, idObj)
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
                ' Raise event so parent can refresh
                Try
                    RaiseEvent ChequeAgregado(Me, EventArgs.Empty)
                Catch
                End Try
            End If

        Catch ex As Exception
            MessageBox.Show("Error al intentar agregar el cheque: " & ex.Message)
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class
