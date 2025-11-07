Imports System.Data.SqlClient
Imports MySqlConnector

Public Class formInicioSesion

    Dim cm As MySqlCommand
    Dim pr As MySqlDataAdapter
    Dim dsl As DataSet
    Dim conexion As String =
        "Server=localhost;Database=proycheque;Uid=root;Pwd=;"
    Dim miconexion As New MySqlConnection(conexion)

    Private Function verificarCredenciales(usuario As String, contrasena As String) As Boolean
        Try
            ' Asegúrate de que el nombre de columna es el correcto en tu BD: "contrasena" o "contrasen"
            Dim consulta As String = "SELECT COUNT(*) FROM usuario WHERE idUsuario = @usuario AND contrasen = @contrasena"
            Using cmd As New MySqlCommand(consulta, miconexion)
                cmd.Parameters.AddWithValue("@usuario", usuario)
                cmd.Parameters.AddWithValue("@contrasena", contrasena)
                miconexion.Open()
                Dim resultado As Object = cmd.ExecuteScalar()
                Dim count As Integer = 0
                If resultado IsNot Nothing AndAlso Integer.TryParse(resultado.ToString(), count) Then
                    Return count > 0
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al verificar las credenciales: " & ex.Message)
            Return False
        Finally
            If miconexion.State <> ConnectionState.Closed Then
                miconexion.Close()
            End If
        End Try
    End Function

    Private Sub formInicioSesion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub MaterialButton1_Click(sender As Object, e As EventArgs) Handles MaterialButton1.Click
        Dim usuario As String = MaterialTextBox1.Text
        Dim contrasena As String = MaterialTextBox2.Text

        If verificarCredenciales(usuario, contrasena) = True Then
            ' Atención: loged espera (username, userid) en tu módulo de sesión.
            ' Aquí solo tenemos el nombre; si necesitas el id real, cambia verificarCredenciales
            ' para devolver el id o recuperar el registro completo.
            loged(usuario, usuario) ' temporal: pasar usuario como id hasta obtener el id real
            MessageBox.Show("Inicio de sesión exitoso.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Hide()
        Else
            MessageBox.Show("Credenciales inválidas. Intente de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class