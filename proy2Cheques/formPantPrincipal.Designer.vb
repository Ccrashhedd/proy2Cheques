<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits MaterialSkin.Controls.MaterialForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        SplitContainer1 = New SplitContainer()
        MaterialTabControl1 = New MaterialSkin.Controls.MaterialTabControl()
        tabPageInicio = New TabPage()
        Label2 = New Label()
        Label1 = New Label()
        TabPage2 = New TabPage()
        Button3 = New Button()
        TextBox1 = New TextBox()
        Button2 = New Button()
        Button1 = New Button()
        Label3 = New Label()
        DataGridView1 = New DataGridView()
        columnIDCheque = New DataGridViewTextBoxColumn()
        columnFecha = New DataGridViewTextBoxColumn()
        columnMonto = New DataGridViewTextBoxColumn()
        columnProveedor = New DataGridViewTextBoxColumn()
        columnObjGasto = New DataGridViewTextBoxColumn()
        columnFechaAnulacion = New DataGridViewTextBoxColumn()
        columnEstado = New DataGridViewTextBoxColumn()
        columnAnular = New DataGridViewButtonColumn()
        TabPage1 = New TabPage()
        MaterialCard1 = New MaterialSkin.Controls.MaterialCard()
        Label10 = New Label()
        Label9 = New Label()
        Label8 = New Label()
        MaterialButton1 = New MaterialSkin.Controls.MaterialButton()
        DateTimePicker1 = New DateTimePicker()
        RichTextBox1 = New RichTextBox()
        TextBox2 = New TextBox()
        ComboBox1 = New ComboBox()
        Label7 = New Label()
        Label6 = New Label()
        Label5 = New Label()
        Label4 = New Label()
        DataGridView2 = New DataGridView()
        columnIdDeposito = New DataGridViewTextBoxColumn()
        columnTipoDeposito = New DataGridViewTextBoxColumn()
        columnMontoDeposito = New DataGridViewTextBoxColumn()
        columnFechaDeposito = New DataGridViewTextBoxColumn()
        TabPage3 = New TabPage()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer1.Panel2.SuspendLayout()
        SplitContainer1.SuspendLayout()
        MaterialTabControl1.SuspendLayout()
        tabPageInicio.SuspendLayout()
        TabPage2.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        TabPage1.SuspendLayout()
        MaterialCard1.SuspendLayout()
        CType(DataGridView2, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' SplitContainer1
        ' 
        SplitContainer1.Dock = DockStyle.Fill
        SplitContainer1.IsSplitterFixed = True
        SplitContainer1.Location = New Point(3, 64)
        SplitContainer1.Name = "SplitContainer1"
        SplitContainer1.Orientation = Orientation.Horizontal
        ' 
        ' SplitContainer1.Panel2
        ' 
        SplitContainer1.Panel2.Controls.Add(MaterialTabControl1)
        SplitContainer1.Size = New Size(981, 601)
        SplitContainer1.SplitterDistance = 138
        SplitContainer1.TabIndex = 0
        ' 
        ' MaterialTabControl1
        ' 
        MaterialTabControl1.Controls.Add(tabPageInicio)
        MaterialTabControl1.Controls.Add(TabPage2)
        MaterialTabControl1.Controls.Add(TabPage1)
        MaterialTabControl1.Controls.Add(TabPage3)
        MaterialTabControl1.Depth = 0
        MaterialTabControl1.Dock = DockStyle.Fill
        MaterialTabControl1.Location = New Point(0, 0)
        MaterialTabControl1.MouseState = MaterialSkin.MouseState.HOVER
        MaterialTabControl1.Multiline = True
        MaterialTabControl1.Name = "MaterialTabControl1"
        MaterialTabControl1.SelectedIndex = 0
        MaterialTabControl1.Size = New Size(981, 459)
        MaterialTabControl1.TabIndex = 0
        ' 
        ' tabPageInicio
        ' 
        tabPageInicio.Controls.Add(Label2)
        tabPageInicio.Controls.Add(Label1)
        tabPageInicio.Location = New Point(4, 24)
        tabPageInicio.Name = "tabPageInicio"
        tabPageInicio.Padding = New Padding(3)
        tabPageInicio.Size = New Size(973, 431)
        tabPageInicio.TabIndex = 0
        tabPageInicio.Text = "Inicio"
        tabPageInicio.UseVisualStyleBackColor = True
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(369, 166)
        Label2.Name = "Label2"
        Label2.Size = New Size(41, 15)
        Label2.TabIndex = 1
        Label2.Text = "Label2"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(359, 74)
        Label1.Name = "Label1"
        Label1.Size = New Size(41, 15)
        Label1.TabIndex = 0
        Label1.Text = "Label1"
        ' 
        ' TabPage2
        ' 
        TabPage2.Controls.Add(Button3)
        TabPage2.Controls.Add(TextBox1)
        TabPage2.Controls.Add(Button2)
        TabPage2.Controls.Add(Button1)
        TabPage2.Controls.Add(Label3)
        TabPage2.Controls.Add(DataGridView1)
        TabPage2.Location = New Point(4, 24)
        TabPage2.Name = "TabPage2"
        TabPage2.Padding = New Padding(3)
        TabPage2.Size = New Size(973, 431)
        TabPage2.TabIndex = 1
        TabPage2.Text = "Cheques"
        TabPage2.UseVisualStyleBackColor = True
        ' 
        ' Button3
        ' 
        Button3.Location = New Point(556, 8)
        Button3.Name = "Button3"
        Button3.Size = New Size(95, 28)
        Button3.TabIndex = 6
        Button3.Text = "Objeto Gasto"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(123, 17)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(175, 23)
        TextBox1.TabIndex = 5
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(666, 8)
        Button2.Name = "Button2"
        Button2.Size = New Size(102, 31)
        Button2.TabIndex = 4
        Button2.Text = "Proveedores"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(795, 6)
        Button1.Name = "Button1"
        Button1.Size = New Size(110, 33)
        Button1.TabIndex = 3
        Button1.Text = "Nuevo Cheque"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(55, 16)
        Label3.Name = "Label3"
        Label3.Size = New Size(62, 20)
        Label3.TabIndex = 1
        Label3.Text = "Cheque:"
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Columns.AddRange(New DataGridViewColumn() {columnIDCheque, columnFecha, columnMonto, columnProveedor, columnObjGasto, columnFechaAnulacion, columnEstado, columnAnular})
        DataGridView1.Location = New Point(55, 45)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.ReadOnly = True
        DataGridView1.Size = New Size(850, 361)
        DataGridView1.TabIndex = 0
        ' 
        ' columnIDCheque
        ' 
        columnIDCheque.Frozen = True
        columnIDCheque.HeaderText = "Numero de cheque"
        columnIDCheque.Name = "columnIDCheque"
        columnIDCheque.ReadOnly = True
        ' 
        ' columnFecha
        ' 
        columnFecha.Frozen = True
        columnFecha.HeaderText = "Fecha"
        columnFecha.Name = "columnFecha"
        columnFecha.ReadOnly = True
        ' 
        ' columnMonto
        ' 
        columnMonto.Frozen = True
        columnMonto.HeaderText = "Monto"
        columnMonto.Name = "columnMonto"
        columnMonto.ReadOnly = True
        ' 
        ' columnProveedor
        ' 
        columnProveedor.Frozen = True
        columnProveedor.HeaderText = "Proveedor"
        columnProveedor.Name = "columnProveedor"
        columnProveedor.ReadOnly = True
        ' 
        ' columnObjGasto
        ' 
        columnObjGasto.Frozen = True
        columnObjGasto.HeaderText = "ObjetoGasto"
        columnObjGasto.Name = "columnObjGasto"
        columnObjGasto.ReadOnly = True
        ' 
        ' columnFechaAnulacion
        ' 
        columnFechaAnulacion.Frozen = True
        columnFechaAnulacion.HeaderText = "Fecha de anulacion"
        columnFechaAnulacion.Name = "columnFechaAnulacion"
        columnFechaAnulacion.ReadOnly = True
        ' 
        ' columnEstado
        ' 
        columnEstado.Frozen = True
        columnEstado.HeaderText = "Estado"
        columnEstado.Name = "columnEstado"
        columnEstado.ReadOnly = True
        ' 
        ' columnAnular
        ' 
        columnAnular.HeaderText = "Accion:"
        columnAnular.Name = "columnAnular"
        columnAnular.ReadOnly = True
        ' 
        ' TabPage1
        ' 
        TabPage1.Controls.Add(MaterialCard1)
        TabPage1.Controls.Add(Label5)
        TabPage1.Controls.Add(Label4)
        TabPage1.Controls.Add(DataGridView2)
        TabPage1.Location = New Point(4, 24)
        TabPage1.Name = "TabPage1"
        TabPage1.Padding = New Padding(3)
        TabPage1.Size = New Size(973, 431)
        TabPage1.TabIndex = 2
        TabPage1.Text = "Depósitos"
        TabPage1.UseVisualStyleBackColor = True
        ' 
        ' MaterialCard1
        ' 
        MaterialCard1.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        MaterialCard1.Controls.Add(Label10)
        MaterialCard1.Controls.Add(Label9)
        MaterialCard1.Controls.Add(Label8)
        MaterialCard1.Controls.Add(MaterialButton1)
        MaterialCard1.Controls.Add(DateTimePicker1)
        MaterialCard1.Controls.Add(RichTextBox1)
        MaterialCard1.Controls.Add(TextBox2)
        MaterialCard1.Controls.Add(ComboBox1)
        MaterialCard1.Controls.Add(Label7)
        MaterialCard1.Controls.Add(Label6)
        MaterialCard1.Depth = 0
        MaterialCard1.ForeColor = Color.FromArgb(CByte(222), CByte(0), CByte(0), CByte(0))
        MaterialCard1.Location = New Point(540, 10)
        MaterialCard1.Margin = New Padding(14)
        MaterialCard1.MouseState = MaterialSkin.MouseState.HOVER
        MaterialCard1.Name = "MaterialCard1"
        MaterialCard1.Padding = New Padding(14)
        MaterialCard1.Size = New Size(416, 335)
        MaterialCard1.TabIndex = 3
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Location = New Point(98, 243)
        Label10.Name = "Label10"
        Label10.Size = New Size(41, 15)
        Label10.TabIndex = 9
        Label10.Text = "Fecha:"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(47, 149)
        Label9.Name = "Label9"
        Label9.Size = New Size(93, 15)
        Label9.TabIndex = 8
        Label9.Text = "Monto en letras:"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(93, 101)
        Label8.Name = "Label8"
        Label8.Size = New Size(46, 15)
        Label8.TabIndex = 7
        Label8.Text = "Monto:"
        ' 
        ' MaterialButton1
        ' 
        MaterialButton1.AutoSizeMode = AutoSizeMode.GrowAndShrink
        MaterialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default
        MaterialButton1.Depth = 0
        MaterialButton1.HighEmphasis = True
        MaterialButton1.Icon = Nothing
        MaterialButton1.Location = New Point(143, 278)
        MaterialButton1.Margin = New Padding(4, 6, 4, 6)
        MaterialButton1.MouseState = MaterialSkin.MouseState.HOVER
        MaterialButton1.Name = "MaterialButton1"
        MaterialButton1.NoAccentTextColor = Color.Empty
        MaterialButton1.Size = New Size(161, 36)
        MaterialButton1.TabIndex = 6
        MaterialButton1.Text = "Agregar Depósito"
        MaterialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
        MaterialButton1.UseAccentColor = False
        MaterialButton1.UseVisualStyleBackColor = True
        ' 
        ' DateTimePicker1
        ' 
        DateTimePicker1.Location = New Point(171, 237)
        DateTimePicker1.Name = "DateTimePicker1"
        DateTimePicker1.Size = New Size(228, 23)
        DateTimePicker1.TabIndex = 5
        ' 
        ' RichTextBox1
        ' 
        RichTextBox1.Location = New Point(68, 167)
        RichTextBox1.Name = "RichTextBox1"
        RichTextBox1.Size = New Size(298, 45)
        RichTextBox1.TabIndex = 4
        RichTextBox1.Text = ""
        ' 
        ' TextBox2
        ' 
        TextBox2.Location = New Point(171, 98)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(100, 23)
        TextBox2.TabIndex = 3
        ' 
        ' ComboBox1
        ' 
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(171, 46)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(121, 23)
        ComboBox1.TabIndex = 2
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(39, 49)
        Label7.Name = "Label7"
        Label7.Size = New Size(100, 15)
        Label7.TabIndex = 1
        Label7.Text = "Tipo de Depósito:"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold Or FontStyle.Underline, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(16, 14)
        Label6.Name = "Label6"
        Label6.Size = New Size(156, 25)
        Label6.TabIndex = 0
        Label6.Text = "Nuevo Depósito"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(550, 25)
        Label5.Name = "Label5"
        Label5.Size = New Size(0, 15)
        Label5.TabIndex = 2
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(550, 10)
        Label4.Name = "Label4"
        Label4.Size = New Size(0, 15)
        Label4.TabIndex = 1
        ' 
        ' DataGridView2
        ' 
        DataGridView2.AllowUserToAddRows = False
        DataGridView2.AllowUserToDeleteRows = False
        DataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView2.Columns.AddRange(New DataGridViewColumn() {columnIdDeposito, columnTipoDeposito, columnMontoDeposito, columnFechaDeposito})
        DataGridView2.Location = New Point(15, 32)
        DataGridView2.Name = "DataGridView2"
        DataGridView2.ReadOnly = True
        DataGridView2.Size = New Size(465, 384)
        DataGridView2.TabIndex = 0
        ' 
        ' columnIdDeposito
        ' 
        columnIdDeposito.Frozen = True
        columnIdDeposito.HeaderText = "ID Depósito"
        columnIdDeposito.Name = "columnIdDeposito"
        columnIdDeposito.ReadOnly = True
        ' 
        ' columnTipoDeposito
        ' 
        columnTipoDeposito.Frozen = True
        columnTipoDeposito.HeaderText = "Tipo de Depósito"
        columnTipoDeposito.Name = "columnTipoDeposito"
        columnTipoDeposito.ReadOnly = True
        ' 
        ' columnMontoDeposito
        ' 
        columnMontoDeposito.Frozen = True
        columnMontoDeposito.HeaderText = "Monto"
        columnMontoDeposito.Name = "columnMontoDeposito"
        columnMontoDeposito.ReadOnly = True
        ' 
        ' columnFechaDeposito
        ' 
        columnFechaDeposito.Frozen = True
        columnFechaDeposito.HeaderText = "Fecha de Depósito"
        columnFechaDeposito.Name = "columnFechaDeposito"
        columnFechaDeposito.ReadOnly = True
        ' 
        ' TabPage3
        ' 
        TabPage3.Location = New Point(4, 24)
        TabPage3.Name = "TabPage3"
        TabPage3.Padding = New Padding(3)
        TabPage3.Size = New Size(973, 431)
        TabPage3.TabIndex = 3
        TabPage3.Text = "Conciliación"
        TabPage3.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(987, 668)
        Controls.Add(SplitContainer1)
        DrawerTabControl = MaterialTabControl1
        Name = "Form1"
        Text = "Form1"
        SplitContainer1.Panel2.ResumeLayout(False)
        CType(SplitContainer1, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer1.ResumeLayout(False)
        MaterialTabControl1.ResumeLayout(False)
        tabPageInicio.ResumeLayout(False)
        tabPageInicio.PerformLayout()
        TabPage2.ResumeLayout(False)
        TabPage2.PerformLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        TabPage1.ResumeLayout(False)
        TabPage1.PerformLayout()
        MaterialCard1.ResumeLayout(False)
        MaterialCard1.PerformLayout()
        CType(DataGridView2, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents MaterialTabControl1 As MaterialSkin.Controls.MaterialTabControl
    Friend WithEvents tabPageInicio As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents columnIDCheque As DataGridViewTextBoxColumn
    Friend WithEvents columnFecha As DataGridViewTextBoxColumn
    Friend WithEvents columnMonto As DataGridViewTextBoxColumn
    Friend WithEvents columnProveedor As DataGridViewTextBoxColumn
    Friend WithEvents columnObjGasto As DataGridViewTextBoxColumn
    Friend WithEvents columnFechaAnulacion As DataGridViewTextBoxColumn
    Friend WithEvents columnEstado As DataGridViewTextBoxColumn
    Friend WithEvents columnAnular As DataGridViewButtonColumn
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents MaterialCard1 As MaterialSkin.Controls.MaterialCard
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents columnIdDeposito As DataGridViewTextBoxColumn
    Friend WithEvents columnTipoDeposito As DataGridViewTextBoxColumn
    Friend WithEvents columnMontoDeposito As DataGridViewTextBoxColumn
    Friend WithEvents columnFechaDeposito As DataGridViewTextBoxColumn
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents MaterialButton1 As MaterialSkin.Controls.MaterialButton
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Button3 As Button

End Class
