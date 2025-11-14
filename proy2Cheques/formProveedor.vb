Public Class formProveedor

    Public Event ProveedorAgregado(sender As Object, e As EventArgs)

    Private Sub MaterialButton1_Click(sender As Object, e As EventArgs) Handles MaterialButton1.Click
        Try
            ' Leer valores
            Dim codigo = TextBox1.Text.Trim()
            Dim nombre = TextBox2.Text.Trim()
            Dim ruc = TextBox3.Text.Trim()
            Dim direccion = TextBox4.Text.Trim()

            ' Validaciones
            If String.IsNullOrEmpty(codigo) Then
                MessageBox.Show("Ingrese el código del proveedor.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextBox1.Focus()
                Return
            End If

            If codigo.Length > 5 Then
                MessageBox.Show("El código no puede tener más de 5 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextBox1.Focus()
                Return
            End If

            If String.IsNullOrEmpty(nombre) Then
                MessageBox.Show("Ingrese el nombre del proveedor.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextBox2.Focus()
                Return
            End If

            ' Si se ingresó RUC, validar que solo tenga dígitos
            If Not String.IsNullOrEmpty(ruc) Then
                If Not System.Text.RegularExpressions.Regex.IsMatch(ruc, "^\d+$") Then
                    MessageBox.Show("El RUC debe contener solo dígitos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    TextBox3.Focus()
                    Return
                End If
            End If

            ' Llamar al módulo para agregar proveedor
            Dim resultado As String = moduloProveedor.agregarProveedor(codigo, nombre, ruc, direccion)
            MessageBox.Show(resultado)

            ' Si fue exitoso, limpiar campos y notificar
            If resultado IsNot Nothing AndAlso resultado.ToLower().Contains("correctamente") Then
                ClearFields()
                Try
                    RaiseEvent ProveedorAgregado(Me, EventArgs.Empty)
                Catch
                    ' Ignorar si no hay listeners
                End Try
            End If

        Catch ex As Exception
            MessageBox.Show("Error al intentar agregar proveedor: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Método público para limpiar campos (útil desde otros formularios)
    Public Sub ClearFields()
        Try
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox1.Focus()
        Catch
            ' Ignorar errores de limpieza
        End Try
    End Sub
End Class