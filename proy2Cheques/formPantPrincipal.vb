Public Class Form1

    Private sesionControl As controlSesionUser
    Private formChq As formCheque

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

        ' Cargar cheques inicialmente
        Try
            CargarChequesEnGrid()
        Catch ex As Exception
            Debug.WriteLine("Error al cargar cheques iniciales: " & ex.Message)
        End Try
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

    ' Handler when the cheque form loses focus (user clicked outside)
    Private Async Sub OnFormChqDeactivated(sender As Object, e As EventArgs)
        Try
            Dim f As formCheque = TryCast(sender, formCheque)
            If f IsNot Nothing Then
                ' Llamar la atencion: briefly make form topmost and beep
                Dim prevTopMost = f.TopMost
                f.TopMost = True
                System.Media.SystemSounds.Beep.Play()
                Await Task.Delay(300)
                If Not f.IsDisposed Then
                    f.TopMost = prevTopMost
                End If
            End If
        Catch ex As Exception
            Debug.WriteLine("Error en OnFormChqDeactivated: " & ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Evitar NullReferenceException: crear instancia si es Nothing o estuvo cerrada
        Try
            If formChq Is Nothing OrElse formChq.IsDisposed Then
                formChq = New formCheque()
                ' limpiar referencia cuando se cierre
                AddHandler formChq.FormClosed, Sub(s, args) formChq = Nothing
                ' detectar cuando pierde foco para llamar la atencion
                AddHandler formChq.Deactivate, AddressOf OnFormChqDeactivated
                ' Cuando se cierre el formulario de cheque, refrescar grid
                AddHandler formChq.FormClosed, Sub(s, args) CargarChequesEnGrid()
            End If

            ' Mostrar formulario (modeless) y llevar al frente
            formChq.Show()
            formChq.BringToFront()
            formChq.Focus()
        Catch ex As Exception
            Debug.WriteLine("Error al mostrar formCheque: " & ex.Message)
        End Try
    End Sub

    ' Carga los cheques desde la base de datos y los muestra en DataGridView1
    Public Sub CargarChequesEnGrid()
        Try
            Dim dt As DataTable = moduloCheque.ObtenerCheques()
            If dt Is Nothing Then Return

            DataGridView1.Rows.Clear()

            For Each r As DataRow In dt.Rows
                Dim idCheque = If(IsDBNull(r("idCheque")), "", r("idCheque").ToString())
                Dim fecha = If(IsDBNull(r("fechaCheque")), "", Convert.ToDateTime(r("fechaCheque")).ToString("yyyy-MM-dd"))
                Dim monto = If(IsDBNull(r("monto")), 0D, Convert.ToDecimal(r("monto")))
                Dim proveedor = If(IsDBNull(r("proveedor")), "", r("proveedor").ToString())
                Dim objeto = If(IsDBNull(r("objeto")), "", r("objeto").ToString())

                ' Estado viene como entero en la BD
                Dim estadoVal As Integer = 1
                If Not IsDBNull(r("estado")) Then
                    Integer.TryParse(r("estado").ToString(), estadoVal)
                End If
                Dim estadoTexto As String = ""
                If moduloCheque.estadoCheque.ContainsKey(estadoVal) Then
                    estadoTexto = moduloCheque.estadoCheque(estadoVal)
                Else
                    estadoTexto = "Desconocido"
                End If

                ' Fecha de anulacion: solo mostrar si estado es Anulado (0)
                Dim fechaAnulacion As String = "---"
                If Not IsDBNull(r("fechaAnulacion")) Then
                    Dim fa = r("fechaAnulacion")
                    If Not String.IsNullOrEmpty(fa.ToString()) Then
                        fechaAnulacion = Convert.ToDateTime(fa).ToString("yyyy-MM-dd")
                    End If
                End If

                ' Si el estado no es anulado, forzar '---'
                If estadoVal <> 0 Then
                    fechaAnulacion = "---"
                Else
                    ' si es anulado pero la fecha es DBNull o vacía, mantener 'Sin fecha' para claridad
                    If fechaAnulacion = "---" Then
                        fechaAnulacion = "Sin fecha"
                    End If
                End If

                DataGridView1.Rows.Add(idCheque, fecha, monto.ToString("N2"), proveedor, objeto, fechaAnulacion, estadoTexto, "Anular")

                ' Ajustes visuales del botón según estado (no ejecutar lógica aquí)
                Dim colIndex = DataGridView1.Columns("columnAnular").Index
                Dim lastRow = DataGridView1.Rows(DataGridView1.Rows.Count - 1)
                Dim btnCell = TryCast(lastRow.Cells(colIndex), DataGridViewButtonCell)
                If btnCell IsNot Nothing Then
                    If estadoTexto = "Circulante" Then
                        btnCell.Style.ForeColor = Color.Red
                        btnCell.FlatStyle = FlatStyle.Standard
                    Else
                        btnCell.Style.ForeColor = Color.Gray
                        btnCell.FlatStyle = FlatStyle.Flat
                    End If
                End If
            Next

        Catch ex As Exception
            Debug.WriteLine("Error al cargar cheques en grid: " & ex.Message)
        End Try
    End Sub

    ' Manejar clicks en el grid (anular cheque)
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Try
            If e.RowIndex < 0 Then Return
            If e.ColumnIndex < 0 Then Return

            Dim colName = DataGridView1.Columns(e.ColumnIndex).Name
            If colName = "columnAnular" Then
                ' Obtener id del cheque en la fila
                Dim idCheque = DataGridView1.Rows(e.RowIndex).Cells("columnIDCheque").Value?.ToString()
                If String.IsNullOrEmpty(idCheque) Then Return

                ' Verificar estado actual; solo permitir anular si está circulante
                Dim estado = DataGridView1.Rows(e.RowIndex).Cells("columnEstado").Value?.ToString()
                If estado IsNot Nothing AndAlso estado <> "Circulante" Then
                    MessageBox.Show("Solo se pueden anular cheques en estado 'Circulante'.")
                    Return
                End If

                Dim resp = MessageBox.Show($"¿Anular el cheque {idCheque}?", "Confirmar anulación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If resp = DialogResult.Yes Then
                    Dim resultado = moduloCheque.anularCheque(idCheque)
                    MessageBox.Show(resultado)
                    ' Refrescar grid
                    CargarChequesEnGrid()
                End If
            End If
        Catch ex As Exception
            Debug.WriteLine("Error en DataGridView1_CellContentClick: " & ex.Message)
        End Try
    End Sub
End Class
