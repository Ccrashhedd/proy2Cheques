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

            ' Limpiar datos sensibles antes de ocultar el formulario
            ClearSensitiveData()

            Dim loginForm = FindLoginFormInstance()
            If loginForm Is Nothing Then
                Dim f As New formInicioSesion()
                ' asegurar campos limpios en nueva instancia (opcional)
                f.ClearFields()
                f.Show()
            Else
                ' limpiar campos de la instancia reutilizada
                Try
                    loginForm.ClearFields()
                Catch ex As Exception
                    Debug.WriteLine("No se pudo limpiar campos del login: " & ex.Message)
                End Try
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

    ' Limpia grids y controles de entrada para evitar mostrar datos previos
    Private Sub ClearSensitiveData()
        Try
            ' Limpiar DataGridView si existen
            If Me.Controls.ContainsKey("DataGridView1") Then
                Dim dgv1 = TryCast(Me.Controls("DataGridView1"), DataGridView)
                If dgv1 IsNot Nothing Then
                    dgv1.DataSource = Nothing
                    dgv1.Rows.Clear()
                End If
            End If

            If Me.Controls.ContainsKey("DataGridView2") Then
                Dim dgv2 = TryCast(Me.Controls("DataGridView2"), DataGridView)
                If dgv2 IsNot Nothing Then
                    dgv2.DataSource = Nothing
                    dgv2.Rows.Clear()
                End If
            End If

            ' Limpiar controles dentro de las pestañas
            If MaterialTabControl1 IsNot Nothing Then
                For Each tab As TabPage In MaterialTabControl1.TabPages
                    For Each ctrl As Control In tab.Controls
                        ClearControlRecursive(ctrl)
                    Next
                Next
            End If

            ' Limpiar controles en Panel2 del SplitContainer (u otros contenedores)
            If SplitContainer1 IsNot Nothing Then
                For Each ctrl As Control In SplitContainer1.Panel2.Controls
                    ClearControlRecursive(ctrl)
                    ' Intentar invocar ClearData si el control lo implementa
                    Dim mi = ctrl.GetType().GetMethod("ClearData")
                    If mi IsNot Nothing Then
                        mi.Invoke(ctrl, Nothing)
                    End If
                Next
            End If
        Catch ex As Exception
            ' No bloquear el flujo por errores de limpieza
            Debug.WriteLine("Error al limpiar datos: " & ex.Message)
        End Try
    End Sub

    Private Sub ClearControlRecursive(ctrl As Control)
        If ctrl Is Nothing Then Return

        ' Limpiar según tipo
        If TypeOf ctrl Is TextBox Then
            DirectCast(ctrl, TextBox).Text = String.Empty
        ElseIf TypeOf ctrl Is ComboBox Then
            DirectCast(ctrl, ComboBox).SelectedIndex = -1
        ElseIf TypeOf ctrl Is ListBox Then
            DirectCast(ctrl, ListBox).Items.Clear()
        ElseIf TypeOf ctrl Is DataGridView Then
            Dim dgv = DirectCast(ctrl, DataGridView)
            dgv.DataSource = Nothing
            dgv.Rows.Clear()
        End If

        ' Recursividad para contenedores
        For Each child As Control In ctrl.Controls
            ClearControlRecursive(child)
        Next
    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TabPage1_Layout(sender As Object, e As LayoutEventArgs)

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub


End Class
