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
    End Sub

    Private Sub OnSesionChanged()
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf OnSesionChanged))
            Return
        End If

        ' En caso de iniciar sesion, mostrar tabs
        If moduloSesion.sesionIniciada = True Then
            ' Mostrar pestañas
            For Each tab As TabPage In MaterialTabControl1.TabPages
                tab.Enabled = True
            Next
        Else
            ' Ocultar pestañas
            For Each tab As TabPage In MaterialTabControl1.TabPages
                tab.Enabled = False
            Next
            MaterialTabControl1.SelectedIndex = 0
        End If
    End Sub


    Private Sub TabPage1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TabPage1_Layout(sender As Object, e As LayoutEventArgs)

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub
End Class
