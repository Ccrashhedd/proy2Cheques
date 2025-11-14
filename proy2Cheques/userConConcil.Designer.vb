<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class userConConcil
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        txtSaldoSegunLibros = New TextBox()
        txtDepositosTransito = New TextBox()
        txtChequesPendientes = New TextBox()
        txtSaldoBanco = New TextBox()
        txtSaldoConciliado = New TextBox()
        btnGuardar = New Button()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        Label7 = New Label()
        Label8 = New Label()
        Label9 = New Label()
        Label10 = New Label()
        MonthComboBox = New ComboBox()
        YearComboBox = New ComboBox()
        SuspendLayout()
        ' 
        ' txtSaldoSegunLibros
        ' 
        txtSaldoSegunLibros.Location = New Point(219, 117)
        txtSaldoSegunLibros.Margin = New Padding(3, 2, 3, 2)
        txtSaldoSegunLibros.Name = "txtSaldoSegunLibros"
        txtSaldoSegunLibros.Size = New Size(219, 23)
        txtSaldoSegunLibros.TabIndex = 0
        ' 
        ' txtDepositosTransito
        ' 
        txtDepositosTransito.Location = New Point(219, 154)
        txtDepositosTransito.Margin = New Padding(3, 2, 3, 2)
        txtDepositosTransito.Name = "txtDepositosTransito"
        txtDepositosTransito.Size = New Size(219, 23)
        txtDepositosTransito.TabIndex = 1
        ' 
        ' txtChequesPendientes
        ' 
        txtChequesPendientes.Location = New Point(219, 192)
        txtChequesPendientes.Margin = New Padding(3, 2, 3, 2)
        txtChequesPendientes.Name = "txtChequesPendientes"
        txtChequesPendientes.Size = New Size(219, 23)
        txtChequesPendientes.TabIndex = 2
        ' 
        ' txtSaldoBanco
        ' 
        txtSaldoBanco.Location = New Point(219, 230)
        txtSaldoBanco.Margin = New Padding(3, 2, 3, 2)
        txtSaldoBanco.Name = "txtSaldoBanco"
        txtSaldoBanco.Size = New Size(219, 23)
        txtSaldoBanco.TabIndex = 3
        ' 
        ' txtSaldoConciliado
        ' 
        txtSaldoConciliado.Enabled = False
        txtSaldoConciliado.Location = New Point(219, 267)
        txtSaldoConciliado.Margin = New Padding(3, 2, 3, 2)
        txtSaldoConciliado.Name = "txtSaldoConciliado"
        txtSaldoConciliado.Size = New Size(219, 23)
        txtSaldoConciliado.TabIndex = 4
        ' 
        ' btnGuardar
        ' 
        btnGuardar.Location = New Point(219, 304)
        btnGuardar.Margin = New Padding(3, 2, 3, 2)
        btnGuardar.Name = "btnGuardar"
        btnGuardar.Size = New Size(219, 22)
        btnGuardar.TabIndex = 5
        btnGuardar.Text = "Guardar Conciliación"
        btnGuardar.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(44, 117)
        Label1.Name = "Label1"
        Label1.Size = New Size(106, 15)
        Label1.TabIndex = 6
        Label1.Text = "Saldo según libros:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(44, 154)
        Label2.Name = "Label2"
        Label2.Size = New Size(121, 15)
        Label2.TabIndex = 7
        Label2.Text = "Depósitos en tránsito:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(44, 192)
        Label3.Name = "Label3"
        Label3.Size = New Size(117, 15)
        Label3.TabIndex = 8
        Label3.Text = "Cheques pendientes:"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(44, 230)
        Label4.Name = "Label4"
        Label4.Size = New Size(88, 15)
        Label4.TabIndex = 9
        Label4.Text = "Saldo bancario:"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(44, 267)
        Label5.Name = "Label5"
        Label5.Size = New Size(124, 15)
        Label5.TabIndex = 10
        Label5.Text = "Saldo conciliado total:"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.ForeColor = Color.Red
        Label6.Location = New Point(44, 304)
        Label6.Name = "Label6"
        Label6.Size = New Size(138, 15)
        Label6.TabIndex = 11
        Label6.Text = "Valores deben ser iguales"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(481, 305)
        Label7.Name = "Label7"
        Label7.Size = New Size(153, 15)
        Label7.TabIndex = 12
        Label7.Text = "Firma: ______________________"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Arial", 14F, FontStyle.Bold)
        Label8.Location = New Point(207, 9)
        Label8.Name = "Label8"
        Label8.Size = New Size(255, 22)
        Label8.TabIndex = 13
        Label8.Text = "CONCILIACIÓN BANCARIA "
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label9.Location = New Point(232, 31)
        Label9.Name = "Label9"
        Label9.Size = New Size(206, 21)
        Label9.TabIndex = 14
        Label9.Text = "Empresa XYZ - Estado actual"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Location = New Point(55, 68)
        Label10.Name = "Label10"
        Label10.Size = New Size(127, 15)
        Label10.TabIndex = 15
        Label10.Text = "Seleccionar mes y año:"
        ' 
        ' MonthComboBox
        ' 
        MonthComboBox.DropDownStyle = ComboBoxStyle.DropDownList
        MonthComboBox.FormattingEnabled = True
        MonthComboBox.Items.AddRange(New Object() {"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"})
        MonthComboBox.Location = New Point(332, 65)
        MonthComboBox.Margin = New Padding(3, 2, 3, 2)
        MonthComboBox.Name = "MonthComboBox"
        MonthComboBox.Size = New Size(106, 23)
        MonthComboBox.TabIndex = 16
        ' 
        ' YearComboBox
        ' 
        YearComboBox.DropDownStyle = ComboBoxStyle.DropDownList
        YearComboBox.FormattingEnabled = True
        YearComboBox.Items.AddRange(New Object() {"2025", "2024", "2023", "2022"})
        YearComboBox.Location = New Point(219, 65)
        YearComboBox.Margin = New Padding(3, 2, 3, 2)
        YearComboBox.Name = "YearComboBox"
        YearComboBox.Size = New Size(106, 23)
        YearComboBox.TabIndex = 17
        ' 
        ' userConConcil
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(YearComboBox)
        Controls.Add(MonthComboBox)
        Controls.Add(Label10)
        Controls.Add(Label9)
        Controls.Add(Label8)
        Controls.Add(Label7)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(btnGuardar)
        Controls.Add(txtSaldoConciliado)
        Controls.Add(txtSaldoBanco)
        Controls.Add(txtChequesPendientes)
        Controls.Add(txtDepositosTransito)
        Controls.Add(txtSaldoSegunLibros)
        Margin = New Padding(3, 2, 3, 2)
        Name = "userConConcil"
        Size = New Size(702, 375)
        ResumeLayout(False)
        PerformLayout()

    End Sub

    ' Declaración de controles
    Private WithEvents txtSaldoSegunLibros As TextBox
    Private WithEvents txtDepositosTransito As TextBox
    Private WithEvents txtChequesPendientes As TextBox
    Private WithEvents txtSaldoBanco As TextBox
    Private WithEvents txtSaldoConciliado As TextBox
    Private WithEvents btnGuardar As Button
    Private WithEvents Label1 As Label
    Private WithEvents Label2 As Label
    Private WithEvents Label3 As Label
    Private WithEvents Label4 As Label
    Private WithEvents Label5 As Label
    Private WithEvents Label6 As Label
    Private WithEvents Label7 As Label
    Private WithEvents Label8 As Label
    Private WithEvents Label9 As Label
    Private WithEvents Label10 As Label
    Private WithEvents MonthComboBox As ComboBox
    Private WithEvents YearComboBox As ComboBox

End Class
