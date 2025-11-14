Public Class formObjGas

    Public Event ObjGastoAgregado(sender As Object, e As EventArgs)

    Private Sub MaterialButton1_Click(sender As Object, e As EventArgs) Handles MaterialButton1.Click
        Try
            Dim codigo = TextBox2.Text.Trim()
            Dim detalle = TextBox3.Text.Trim()
            Dim objeto = TextBox1.Text.Trim()

            ' Validaciones
            If String.IsNullOrEmpty(codigo) Then
                MessageBox.Show("Ingrese el código.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextBox2.Focus()
                Return
            End If

            ' codigo debe ser solo números
            If Not System.Text.RegularExpressions.Regex.IsMatch(codigo, "^\d+$") Then
                MessageBox.Show("El código debe contener solo dígitos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextBox2.Focus()
                Return
            End If

            If String.IsNullOrEmpty(detalle) Then
                MessageBox.Show("Ingrese el detalle.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextBox3.Focus()
                Return
            End If

            ' detalle solo letras y espacios
            If Not System.Text.RegularExpressions.Regex.IsMatch(detalle, "^[\p{L} ]+$") Then
                MessageBox.Show("El detalle solo puede contener letras y espacios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextBox3.Focus()
                Return
            End If

            If String.IsNullOrEmpty(objeto) Then
                MessageBox.Show("Ingrese el objeto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextBox1.Focus()
                Return
            End If

            ' objeto debe ser solo números
            If Not System.Text.RegularExpressions.Regex.IsMatch(objeto, "^\d+$") Then
                MessageBox.Show("El campo 'Objeto' debe contener solo dígitos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextBox1.Focus()
                Return
            End If

            ' Llamar al módulo para agregar
            Dim resultado As String = moduloObjGasto.agregarObjGas(codigo, detalle, objeto)
            MessageBox.Show(resultado)

            If resultado IsNot Nothing AndAlso resultado.ToLower().Contains("correctamente") Then
                ClearFields()
                Try
                    RaiseEvent ObjGastoAgregado(Me, EventArgs.Empty)
                Catch
                End Try
            End If

        Catch ex As Exception
            MessageBox.Show("Error al intentar agregar objeto de gasto: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Restringir la entrada en tiempo real: solo letras y espacios
    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        Try
            Dim ch As Char = e.KeyChar
            If Char.IsControl(ch) Then
                Return
            End If
            If Char.IsLetter(ch) OrElse Char.IsWhiteSpace(ch) Then
                Return
            End If
            ' Bloquear cualquier otro caracter
            e.Handled = True
        Catch
            ' Ignorar errores
        End Try
    End Sub

    Public Sub ClearFields()
        Try
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox2.Focus()
        Catch
        End Try
    End Sub
End Class
''''''''