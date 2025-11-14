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

        ' Cargar los proveedores en el ComboBox (codigo, nombre)
        Try
            Dim sqlProv As String = "SELECT codigo, nombre FROM proveedores"
            Using da As New MySqlDataAdapter(sqlProv, miconexion)
                Dim dtProv As New DataTable()
                da.Fill(dtProv)
                If comboBoxProveedor IsNot Nothing Then
                    If dtProv.Rows.Count > 0 Then
                        comboBoxProveedor.DataSource = dtProv
                        comboBoxProveedor.DisplayMember = "nombre"
                        comboBoxProveedor.ValueMember = "codigo"
                        comboBoxProveedor.SelectedIndex = -1 ' sin selección por defecto
                    Else
                        comboBoxProveedor.DataSource = Nothing
                    End If
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al cargar proveedores: " & ex.Message)
        End Try

        ' Cargar los objetos de gasto en el ComboBox (codigo, detalle)
        Try
            Dim sqlObj As String = "SELECT codigo, detalle FROM objeto_gasto"
            Using da As New MySqlDataAdapter(sqlObj, miconexion)
                Dim dtObj As New DataTable()
                da.Fill(dtObj)
                If comboBoxObjGas IsNot Nothing Then
                    If dtObj.Rows.Count > 0 Then
                        comboBoxObjGas.DataSource = dtObj
                        comboBoxObjGas.DisplayMember = "detalle"
                        comboBoxObjGas.ValueMember = "codigo"
                        comboBoxObjGas.SelectedIndex = -1
                    Else
                        comboBoxObjGas.DataSource = Nothing
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