Public Class formControlProv
    Private formProv As formProveedor

    Private Sub formControlProv_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            CargarProveedores()
        Catch ex As Exception
            Debug.WriteLine("Error al cargar proveedores en Load: " & ex.Message)
        End Try
    End Sub

    Private Sub MaterialButton1_Click(sender As Object, e As EventArgs) Handles MaterialButton1.Click
        Try
            If formProv Is Nothing OrElse formProv.IsDisposed Then
                formProv = New formProveedor()
                AddHandler formProv.FormClosed, Sub(s, args)
                                                    formProv = Nothing
                                                    CargarProveedores()
                                                End Sub
                ' Actualizar grid inmediatamente cuando se agregue un proveedor desde el formulario
                AddHandler formProv.ProveedorAgregado, Sub(s, args)
                                                           CargarProveedores()
                                                       End Sub
            End If
            formProv.Show()
            formProv.BringToFront()
            formProv.Focus()
        Catch ex As Exception
            Debug.WriteLine("Error al abrir formProveedor: " & ex.Message)
        End Try
    End Sub

    Public Sub CargarProveedores()
        Try
            Dim dt As DataTable = moduloProveedor.ObtenerProveedores()
            If dt Is Nothing Then Return

            DataGridView1.Rows.Clear()
            For Each r As DataRow In dt.Rows
                Dim codigo = If(IsDBNull(r("codigo")), "", r("codigo").ToString())
                Dim nombre = If(IsDBNull(r("nombre")), "", r("nombre").ToString())
                Dim ruc = If(IsDBNull(r("ruc")), "", r("ruc").ToString())
                Dim direccion = If(IsDBNull(r("direccion")), "", r("direccion").ToString())

                DataGridView1.Rows.Add(codigo, nombre, ruc, direccion, "Editar", "Eliminar")
            Next
        Catch ex As Exception
            Debug.WriteLine("Error al cargar proveedores: " & ex.Message)
        End Try
    End Sub

    ' Manejar clicks en el grid (editar/eliminar)
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Try
            If e.RowIndex < 0 Then Return
            Dim colName = DataGridView1.Columns(e.ColumnIndex).Name
            Dim codigo = DataGridView1.Rows(e.RowIndex).Cells("columnIdProveedor").Value?.ToString()
            If String.IsNullOrEmpty(codigo) Then Return

            If colName = "columnEditar" Then
                ' Abrir formProveedor y llenar campos para editar (implementar si se desea)
                Dim fp As New formProveedor()
                ' Se podría exponer un método en formProveedor para cargar datos y editar
                fp.Show()
            ElseIf colName = "columnEliminar" Then
                Dim resp = MessageBox.Show($"¿Eliminar proveedor {codigo}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If resp = DialogResult.Yes Then
                    ' Implementar eliminación en moduloProveedor si se desea
                    MessageBox.Show("Función de eliminar no implementada aún.")
                End If
            End If
        Catch ex As Exception
            Debug.WriteLine("Error en DataGridView1_CellContentClick: " & ex.Message)
        End Try
    End Sub
End Class