Public Class controlSesionUser

    Private Sub controlSesionUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Suscribirse al evento de sesión y configurar estado inicial
        AddHandler moduloSesion.sesionChanged, AddressOf OnSessionChanged
        AddHandler Me.Disposed, AddressOf OnDisposed
        UpdateUI()
    End Sub

    Private Sub OnDisposed(sender As Object, e As EventArgs)
        ' Quitar handler al destruir el control para evitar fugas
        RemoveHandler moduloSesion.sesionChanged, AddressOf OnSessionChanged
    End Sub

    Private Sub OnSessionChanged()
        ' Asegurar ejecución en el hilo de la UI
        If Me.InvokeRequired Then
            Me.Invoke(Sub() UpdateUI())
        Else
            UpdateUI()
        End If
    End Sub

    ' Método público para actualizar la UI del control según el estado de sesión
    Public Sub UpdateUI()
        If moduloSesion.sesionIniciada Then
            MaterialLabel1.Text = moduloSesion.idUsuario
            MaterialLabel2.Text = If(String.IsNullOrWhiteSpace(moduloSesion.nombreUsuario), "Usuario", moduloSesion.nombreUsuario)
            MaterialButton1.Text = "Cerrar sesión"

        Else
            MaterialLabel1.Text = "--"
            MaterialLabel2.Text = "--"
            MaterialButton1.Text = "Iniciar Sesion"
        End If
    End Sub

    Private Function FindLoginFormInstance() As formInicioSesion
        For Each f As Form In Application.OpenForms
            If TypeOf f Is formInicioSesion Then
                Return DirectCast(f, formInicioSesion)
            End If
        Next
        Return Nothing
    End Function

    Private Sub MaterialButton1_Click(sender As Object, e As EventArgs) Handles MaterialButton1.Click
        If moduloSesion.sesionIniciada Then
            ' Cerrar sesión: usar el método centralizado
            moduloSesion.logout()
            ' Cuando se cierra la sesión, el Form principal (que contiene este control)
            ' debe cerrarse o esconderse. El formulario principal manejará mostrar el login.
        Else
            ' Abrir formulario de inicio de sesión (intenta reutilizar instancia si existe)
            Dim loginForm = FindLoginFormInstance()
            If loginForm IsNot Nothing Then
                loginForm.Show()
                loginForm.BringToFront()
            Else
                Dim f As New formInicioSesion()
                f.Show()
            End If
        End If


    End Sub


    Private Sub MaterialButton2_Click(sender As Object, e As EventArgs) Handles MaterialButton2.Click
        ' Cerrar la aplicación si no hay sesión (confirmar)
        If MessageBox.Show("¿Desea cerrar la aplicación?", "Confirmar cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Application.Exit()
        End If

    End Sub
End Class
