Imports System.Data.SqlClient
Imports MySqlConnector

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

        ' Cargar los proveedores en el ComboBox1 (codigo, nombre)
        Try
            Dim sqlProv As String = "SELECT codigo, nombre FROM proveedores"
            Using da As New MySqlDataAdapter(sqlProv, miconexion)
                Dim dtProv As New DataTable()
                da.Fill(dtProv)
                Dim cbProv As ComboBox = Nothing
                Dim foundProv() As Control = Me.Controls.Find("comboBoxProveedores", True)
                If foundProv.Length > 0 Then cbProv = TryCast(foundProv(0), ComboBox)
                If cbProv IsNot Nothing Then
                    If dtProv.Rows.Count > 0 Then
                        cbProv.DataSource = dtProv
                        cbProv.DisplayMember = "nombre"
                        cbProv.ValueMember = "codigo"
                        cbProv.SelectedIndex = -1 ' sin selección por defecto
                        cbProv.DropDownStyle = ComboBoxStyle.DropDownList
                    Else
                        cbProv.DataSource = Nothing
                    End If
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al cargar proveedores: " & ex.Message)
        End Try

        ' Cargar los objetos de gasto en el ComboBox2 (codigo, detalle)
        Try
            Dim sqlObj As String = "SELECT codigo, detalle FROM objeto_gasto"
            Using da As New MySqlDataAdapter(sqlObj, miconexion)
                Dim dtObj As New DataTable()
                da.Fill(dtObj)
                Dim cbObj As ComboBox = Nothing
                Dim foundObj() As Control = Me.Controls.Find("comboBoxObjGas", True)
                If foundObj.Length > 0 Then cbObj = TryCast(foundObj(0), ComboBox)
                If cbObj IsNot Nothing Then
                    If dtObj.Rows.Count > 0 Then
                        cbObj.DataSource = dtObj
                        cbObj.DisplayMember = "detalle"
                        cbObj.ValueMember = "codigo"
                        cbObj.SelectedIndex = -1
                        cbObj.DropDownStyle = ComboBoxStyle.DropDownList
                    Else
                        cbObj.DataSource = Nothing
                    End If
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al cargar objetos de gasto: " & ex.Message)
        End Try
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

End Class