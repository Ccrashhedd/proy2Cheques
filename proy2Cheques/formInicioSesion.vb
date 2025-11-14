Imports MySqlConnector

Public Class formInicioSesion

    Private mostrarPass As Boolean = False

    Private Sub formInicioSesion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Ocultar por defecto
        MaterialTextBox2.Password = True

        ' Asignar TrailingIcon con Unicode (ojo)
        MaterialTextBox2.TrailingIcon = TextToImage("👁")
    End Sub


    ' Función para convertir un carácter Unicode en una imagen
    Private Function TextToImage(text As String) As Image
        Dim bmp As New Bitmap(32, 32)
        Using g = Graphics.FromImage(bmp)
            g.Clear(Color.Transparent)
            g.DrawString(text, New Font("Segoe UI Emoji", 18), Brushes.Black, -4, -4)
        End Using
        Return bmp
    End Function


    Private Sub MaterialTextBox2_TrailingIconClick(sender As Object, e As EventArgs) _
        Handles MaterialTextBox2.TrailingIconClick

        mostrarPass = Not mostrarPass

        If mostrarPass Then
            MaterialTextBox2.Password = False
            MaterialTextBox2.TrailingIcon = TextToImage("🙈")  ' Ojo tapado
        Else
            MaterialTextBox2.Password = True
            MaterialTextBox2.TrailingIcon = TextToImage("👁")   ' Ojo normal
        End If

    End Sub


    ' ============================
    '  Resto de tu código
    ' ============================

    Private Function verificarCredenciales(idUsuario As String, contrasena As String) As String
        Dim cadena As String = "Server=localhost;Database=proycheque;Uid=root;Pwd=;"

        Try
            Using conn As New MySqlConnection(cadena)
                conn.Open()

                Dim sql As String =
                    "SELECT nombre 
                     FROM usuario 
                     WHERE idUsuario = @id AND contrasen = @pass
                     LIMIT 1"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@id", idUsuario)
                    cmd.Parameters.AddWithValue("@pass", contrasena)

                    Dim resultado = cmd.ExecuteScalar()

                    If resultado IsNot Nothing Then
                        Return resultado.ToString()
                    Else
                        Return ""
                    End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error al verificar las credenciales: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return ""
        End Try
    End Function


    Private Sub MaterialButton1_Click(sender As Object, e As EventArgs) Handles MaterialButton1.Click
        Dim usuario As String = MaterialTextBox1.Text.Trim()
        Dim contrasena As String = MaterialTextBox2.Text.Trim()

        If usuario = "" Or contrasena = "" Then
            MessageBox.Show("Por favor complete todos los campos.",
                            "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim nombreUsuario As String = verificarCredenciales(usuario, contrasena)

        If nombreUsuario <> "" Then

            moduloSesion.loged(nombreUsuario, usuario)

            MessageBox.Show("Inicio de sesión exitoso.",
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim main As New Form1
            main.Show()

            Me.Hide()

        Else
            MessageBox.Show("Credenciales inválidas. Intente de nuevo.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

End Class
