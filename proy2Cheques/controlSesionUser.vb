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

    ' Actualiza la UI según el estado de sesión
    Public Sub UpdateUI()
        If moduloSesion.sesionIniciada Then
            MaterialLabel1.Text = moduloSesion.idUsuario
            MaterialLabel2.Text = If(String.IsNullOrWhiteSpace(moduloSesion.nombreUsuario),
                                     "Usuario",
                                     moduloSesion.nombreUsuario)
            MaterialButton1.Text = "Cerrar sesión"
        Else
            MaterialLabel1.Text = "--"
            MaterialLabel2.Text = "--"
            MaterialButton1.Text = "Iniciar sesión"
        End If
    End Sub

    ' Buscar si ya hay un formulario de login abierto
    Private Function FindLoginFormInstance() As formInicioSesion
        For Each f As Form In Application.OpenForms
            If TypeOf f Is formInicioSesion Then
                Return DirectCast(f, formInicioSesion)
            End If
        Next
        Return Nothing
    End Function

    ' Botón de iniciar / cerrar sesión
    Private Sub MaterialButton1_Click(sender As Object, e As EventArgs) Handles MaterialButton1.Click

        If moduloSesion.sesionIniciada Then
            ' ============ CERRAR SESIÓN ============

            ' Solo cerrar sesión en el módulo; Form1 recibirá el evento y limpiará/ocultará UI
            moduloSesion.logout()

            ' UpdateUI se hará automáticamente por el evento, pero llamamos para respuesta inmediata
            UpdateUI()

        Else
            ' ============ INICIAR SESIÓN ============

            ' Si ya existe un login abierto, lo traemos al frente
            Dim login = FindLoginFormInstance()
            If login Is Nothing Then
                login = New formInicioSesion()
            End If
            login.Show()
            login.BringToFront()

        End If

    End Sub

    ' Botón "Cerrar" (sale de la aplicación completa)
    Private Sub MaterialButton2_Click(sender As Object, e As EventArgs) Handles MaterialButton2.Click
        If MessageBox.Show("¿Desea cerrar la aplicación?",
                           "Confirmar cierre",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question) = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

End Class
