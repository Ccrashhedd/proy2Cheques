Imports System.Text.RegularExpressions
Imports MySqlConnector

Public Class formInicioSesion

    Private mostrarPass As Boolean = False

    Private Sub formInicioSesion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Ocultar por defecto
        MaterialTextBox2.Password = True
        ' Asignar TrailingIcon con Unicode (ojo)
        MaterialTextBox2.TrailingIcon = TextToImage("👁")

        ' Asegurar validación en tiempo real para el campo usuario
        AddHandler MaterialTextBox1.KeyPress, AddressOf MaterialTextBox1_KeyPress
        AddHandler MaterialTextBox1.TextChanged, AddressOf MaterialTextBox1_TextChanged
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

    ' Validación de usuario (solo letras, números, y guión bajo)
    Private Function ValidarUsuario(usuario As String) As Boolean
        Dim regex As New Regex("^[a-zA-Z0-9_]+$")
        Return regex.IsMatch(usuario)
    End Function

    ' Maneja tecla pulsada en el campo usuario: permite solo letras, dígitos, guión bajo y teclas de control
    Private Sub MaterialTextBox1_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Char.IsControl(e.KeyChar) Then
            Return
        End If

        Dim allowed As New Regex("^[a-zA-Z0-9_]$")
        If Not allowed.IsMatch(e.KeyChar.ToString()) Then
            e.Handled = True
        End If
    End Sub

    ' Maneja texto cambiado (por ejemplo pegado) y elimina caracteres no permitidos
    Private Sub MaterialTextBox1_TextChanged(sender As Object, e As EventArgs)
        Try
            Dim tb = DirectCast(sender, Control)
            Dim textProp = tb.GetType().GetProperty("Text")
            If textProp Is Nothing Then Return

            Dim current As String = CStr(textProp.GetValue(tb))
            Dim cleaned As String = Regex.Replace(current, "[^a-zA-Z0-9_]", "")
            If Not current.Equals(cleaned) Then
                Dim selStartProp = tb.GetType().GetProperty("SelectionStart")
                Dim selStart As Integer = If(selStartProp IsNot Nothing, CInt(selStartProp.GetValue(tb)), cleaned.Length)

                textProp.SetValue(tb, cleaned)

                If selStartProp IsNot Nothing Then
                    Dim newSel = Math.Min(cleaned.Length, Math.Max(0, selStart - (current.Length - cleaned.Length)))
                    selStartProp.SetValue(tb, newSel)
                End If
            End If
        Catch ex As Exception
            Debug.WriteLine("Error al limpiar texto usuario: " & ex.Message)
        End Try
    End Sub

    ' Verificar credenciales de usuario
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

        ' Validar que los campos no estén vacíos
        If usuario = "" Or contrasena = "" Then
            MessageBox.Show("Por favor complete todos los campos.",
                            "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Validar que el usuario no tenga caracteres especiales
        If Not ValidarUsuario(usuario) Then
            MessageBox.Show("El nombre de usuario solo puede contener letras, números y guión bajo.",
                            "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim nombreUsuario As String = verificarCredenciales(usuario, contrasena)

        If nombreUsuario <> "" Then

            ' Iniciar sesión
            moduloSesion.loged(nombreUsuario, usuario)

            MessageBox.Show("Inicio de sesión exitoso.",
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Mostrar el formulario principal existente si hay uno, sino crear uno nuevo
            Dim mainForm As Form = Nothing
            For Each f As Form In Application.OpenForms
                If TypeOf f Is Form1 Then
                    mainForm = f
                    Exit For
                End If
            Next

            If mainForm Is Nothing Then
                mainForm = New Form1()
                mainForm.Show()
            Else
                mainForm.Show()
                mainForm.BringToFront()
            End If

            ' Ocultar el login
            Me.Hide()

        Else
            MessageBox.Show("Credenciales inválidas. Intente de nuevo.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ' Limpiar los campos cada vez que se muestre el formulario de inicio de sesión
    Protected Overrides Sub OnShown(e As EventArgs)
        MyBase.OnShown(e)

        ' Limpiar campos del login cada vez que se muestra
        MaterialTextBox1.Text = ""
        MaterialTextBox2.Text = ""
        MaterialTextBox2.Password = True
    End Sub

    ' Método público para limpiar campos cuando se reutiliza la misma instancia
    Public Sub ClearFields()
        Try
            mostrarPass = False
            If MaterialTextBox1 IsNot Nothing Then MaterialTextBox1.Text = String.Empty
            If MaterialTextBox2 IsNot Nothing Then
                MaterialTextBox2.Text = String.Empty
                MaterialTextBox2.Password = True
                MaterialTextBox2.TrailingIcon = TextToImage("👁")
            End If
        Catch ex As Exception
            Debug.WriteLine("ClearFields error: " & ex.Message)
        End Try
    End Sub

End Class
