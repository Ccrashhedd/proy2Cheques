Public Class Form1

    Private sesionControl As controlSesionUser

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Agregar el userControl que es la parte de iniciar sesion
        sesionControl = New controlSesionUser()
        sesionControl.Dock = DockStyle.Fill

        ' Implementarlo al panel1 del splitcointainer (se añade una vez y se muestra/oculta)
        SplitContainer1.Panel1.Controls.Clear()
        SplitContainer1.Panel1.Controls.Add(sesionControl)
        sesionControl.BringToFront()

        ' Suscribirse al evento de sesión para actualizar la UI cuando cambie
        AddHandler moduloSesion.sesionChanged, AddressOf OnSesionChanged

        ' Estado inicial según el moduloSesion
        If moduloSesion.sesionIniciada Then
            Me.Show()
            EnableTabs(True)
        Else
            EnableTabs(False)
        End If
    End Sub

    Private Sub OnSesionChanged()
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf OnSesionChanged))
            Return
        End If

        If moduloSesion.sesionIniciada Then
            ' Usuario inició sesión: mostrar este formulario y habilitar tabs
            If Not Me.Visible Then Me.Show()
            EnableTabs(True)

            ' Si hay un formulario de login abierto, esconderlo
            Dim loginForm = FindLoginFormInstance()
            If loginForm IsNot Nothing Then
                loginForm.Hide()
            End If
        Else
            ' Usuario cerró sesión: deshabilitar tabs y mostrar formulario de login
            EnableTabs(False)
            Dim loginForm = FindLoginFormInstance()
            If loginForm Is Nothing Then
                Dim f As New formInicioSesion()
                f.Show()
            Else
                loginForm.Show()
                loginForm.BringToFront()
            End If
            ' Ocultar el formulario principal
            Me.Hide()
        End If
    End Sub

    Private Sub EnableTabs(enable As Boolean)
        If MaterialTabControl1 Is Nothing Then Return
        For Each tab As TabPage In MaterialTabControl1.TabPages
            tab.Enabled = enable
        Next
        If Not enable Then
            MaterialTabControl1.SelectedIndex = 0
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

    Private Sub TabPage1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TabPage1_Layout(sender As Object, e As LayoutEventArgs)

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub
End Class
