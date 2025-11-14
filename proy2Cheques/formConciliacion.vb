Public Class formConciliacion
    Inherits UserControl

    ' Controles para la conciliación
    Private txtSaldoLibros As TextBox
    Private txtSaldoBanco As TextBox
    Private dgvConciliacion As DataGridView
    Private btnRegistrar As Button
    Private lblSaldoLibros As Label
    Private lblSaldoBanco As Label

    Public Sub New()
        Me.Dock = DockStyle.Fill
        InitializeControls()
        CargarConciliaciones()
    End Sub

    Private Sub InitializeControls()
        ' Crear Label y TextBox para el saldo según libros
        lblSaldoLibros = New Label() With {
            .Location = New Point(20, 20),
            .AutoSize = True,
            .Text = "Saldo según libros:"
        }
        txtSaldoLibros = New TextBox() With {
            .Location = New Point(20, 40),
            .Width = 150
        }

        ' Crear Label y TextBox para el saldo bancario
        lblSaldoBanco = New Label() With {
            .Location = New Point(200, 20),
            .AutoSize = True,
            .Text = "Saldo bancario:"
        }
        txtSaldoBanco = New TextBox() With {
            .Location = New Point(200, 40),
            .Width = 150
        }

        ' Crear DataGridView para mostrar las conciliaciones registradas
        dgvConciliacion = New DataGridView() With {
            .Location = New Point(20, 80),
            .Width = 600,
            .Height = 250,
            .ReadOnly = True,
            .AllowUserToAddRows = False,
            .AllowUserToDeleteRows = False,
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        }

        ' Crear botón para registrar la conciliación
        btnRegistrar = New Button() With {
            .Location = New Point(20, 350),
            .Text = "Registrar Conciliación",
            .Width = 180
        }
        AddHandler btnRegistrar.Click, AddressOf btnRegistrar_Click

        ' Agregar controles al UserControl
        Controls.Add(lblSaldoLibros)
        Controls.Add(txtSaldoLibros)
        Controls.Add(lblSaldoBanco)
        Controls.Add(txtSaldoBanco)
        Controls.Add(dgvConciliacion)
        Controls.Add(btnRegistrar)
    End Sub

    ' Cargar conciliaciones desde la base de datos al DataGridView
    Private Sub CargarConciliaciones()
        Try
            Dim dt As DataTable = ModuloConciliacion.ObtenerConciliaciones()
            dgvConciliacion.DataSource = dt
        Catch ex As Exception
            MessageBox.Show("Error al cargar conciliaciones: " & ex.Message)
        End Try
    End Sub

    ' Lógica para registrar la conciliación
    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs)
        Dim saldoLibros As Decimal
        Dim saldoBanco As Decimal

        ' Validar saldo según libros
        If Not Decimal.TryParse(txtSaldoLibros.Text, saldoLibros) Then
            MessageBox.Show("Ingrese un saldo válido según libros.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtSaldoLibros.Focus()
            Return
        End If

        ' Validar saldo bancario
        If Not Decimal.TryParse(txtSaldoBanco.Text, saldoBanco) Then
            MessageBox.Show("Ingrese un saldo bancario válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtSaldoBanco.Focus()
            Return
        End If

        ' Obtener los cheques y depósitos del mes actual
        Dim cheques As Decimal = ModuloConciliacion.ObtenerCheques()
        Dim depositos As Decimal = ModuloConciliacion.ObtenerDepositos()

        ' Calcular el saldo de libros ajustado
        Dim saldoAjustado As Decimal = saldoLibros - cheques + depositos

        ' Verificar si el saldo ajustado coincide con el saldo bancario
        If saldoAjustado <> saldoBanco Then
            MessageBox.Show("El saldo ajustado no coincide con el saldo bancario. Verifique los cheques y depósitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Registrar la conciliación
        Dim resultado As String = ModuloConciliacion.RegistrarConciliacion(saldoLibros, saldoBanco)

        ' Mostrar el resultado
        MessageBox.Show(resultado, "Conciliación", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ' Si se registró correctamente, limpiar y recargar los datos
        If resultado.ToLower().Contains("registrada") OrElse resultado.ToLower().Contains("exitosamente") Then
            txtSaldoLibros.Clear()
            txtSaldoBanco.Clear()
            CargarConciliaciones()
        End If
    End Sub
End Class
