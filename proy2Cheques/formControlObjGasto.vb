Public Class formControlObjGasto
    Private formObj As formObjGas

    Private Sub formControlObjGasto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            CargarObjetos()
        Catch ex As Exception
            Debug.WriteLine("Error al cargar objetos en Load: " & ex.Message)
        End Try
    End Sub

    Private Sub MaterialButton1_Click(sender As Object, e As EventArgs) Handles MaterialButton1.Click
        Try
            If formObj Is Nothing OrElse formObj.IsDisposed Then
                formObj = New formObjGas()
                AddHandler formObj.FormClosed, Sub(s, args)
                                                   formObj = Nothing
                                                   CargarObjetos()
                                               End Sub
                AddHandler formObj.ObjGastoAgregado, Sub(s, args)
                                                         CargarObjetos()
                                                     End Sub
            End If
            formObj.Show()
            formObj.BringToFront()
            formObj.Focus()
        Catch ex As Exception
            Debug.WriteLine("Error al abrir formObjGas: " & ex.Message)
        End Try
    End Sub

    Public Sub CargarObjetos()
        Try
            Dim dt As DataTable = moduloObjGasto.ObtenerObjGastos()
            If dt Is Nothing Then Return

            DataGridView1.Rows.Clear()
            For Each r As DataRow In dt.Rows
                Dim codigo = If(IsDBNull(r("codigo")), "", r("codigo").ToString())
                Dim detalle = If(IsDBNull(r("detalle")), "", r("detalle").ToString())
                Dim objeto = If(IsDBNull(r("objeto")), "", r("objeto").ToString())
                DataGridView1.Rows.Add(codigo, detalle, objeto, "Eliminar")
            Next
        Catch ex As Exception
            Debug.WriteLine("Error al cargar objetos: " & ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Try
            If e.RowIndex < 0 Then Return
            Dim colName = DataGridView1.Columns(e.ColumnIndex).Name
            Dim codigo = DataGridView1.Rows(e.RowIndex).Cells("columnCodigo").Value?.ToString()
            If String.IsNullOrEmpty(codigo) Then Return

            If colName = "columnEliminar" Then
                Dim resp = MessageBox.Show($"¿Eliminar objeto {codigo}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If resp = DialogResult.Yes Then
                    Dim resultado = moduloObjGasto.eliminarObjGas(codigo)
                    MessageBox.Show(resultado)
                    CargarObjetos()
                End If
            End If
        Catch ex As Exception
            Debug.WriteLine("Error en DataGridView1_CellContentClick: " & ex.Message)
        End Try
    End Sub
End Class