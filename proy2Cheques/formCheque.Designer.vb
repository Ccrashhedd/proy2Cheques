<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formCheque
    Inherits MaterialSkin.Controls.MaterialForm

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Label1 = New Label()
        comboBoxProveedor = New ComboBox()
        comboBoxObjGas = New ComboBox()
        TextBox1 = New TextBox()
        RichTextBox1 = New RichTextBox()
        TextBox2 = New TextBox()
        DateTimePicker1 = New DateTimePicker()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        Label7 = New Label()
        RichTextBox2 = New RichTextBox()
        MaterialButton1 = New MaterialSkin.Controls.MaterialButton()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(22, 124)
        Label1.Name = "Label1"
        Label1.Size = New Size(86, 20)
        Label1.TabIndex = 0
        Label1.Text = "No. Cheque"
        ' 
        ' comboBoxProveedor
        ' 
        comboBoxProveedor.FormattingEnabled = True
        comboBoxProveedor.Location = New Point(104, 272)
        comboBoxProveedor.Margin = New Padding(3, 4, 3, 4)
        comboBoxProveedor.Name = "comboBoxProveedor"
        comboBoxProveedor.Size = New Size(236, 28)
        comboBoxProveedor.TabIndex = 1
        ' 
        ' comboBoxObjGas
        ' 
        comboBoxObjGas.FormattingEnabled = True
        comboBoxObjGas.Location = New Point(460, 272)
        comboBoxObjGas.Margin = New Padding(3, 4, 3, 4)
        comboBoxObjGas.Name = "comboBoxObjGas"
        comboBoxObjGas.Size = New Size(280, 28)
        comboBoxObjGas.TabIndex = 2
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(126, 116)
        TextBox1.Margin = New Padding(3, 4, 3, 4)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(114, 27)
        TextBox1.TabIndex = 3
        ' 
        ' RichTextBox1
        ' 
        RichTextBox1.Enabled = False
        RichTextBox1.Location = New Point(346, 189)
        RichTextBox1.Margin = New Padding(3, 4, 3, 4)
        RichTextBox1.Name = "RichTextBox1"
        RichTextBox1.Size = New Size(326, 51)
        RichTextBox1.TabIndex = 4
        RichTextBox1.Text = ""
        ' 
        ' TextBox2
        ' 
        TextBox2.Location = New Point(126, 202)
        TextBox2.Margin = New Padding(3, 4, 3, 4)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(114, 27)
        TextBox2.TabIndex = 5
        ' 
        ' DateTimePicker1
        ' 
        DateTimePicker1.Checked = False
        DateTimePicker1.Location = New Point(398, 117)
        DateTimePicker1.Margin = New Padding(3, 4, 3, 4)
        DateTimePicker1.Name = "DateTimePicker1"
        DateTimePicker1.Size = New Size(274, 27)
        DateTimePicker1.TabIndex = 6
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(345, 119)
        Label2.Name = "Label2"
        Label2.Size = New Size(47, 20)
        Label2.TabIndex = 7
        Label2.Text = "Fecha"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(55, 205)
        Label3.Name = "Label3"
        Label3.Size = New Size(53, 20)
        Label3.TabIndex = 8
        Label3.Text = "Monto"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(346, 165)
        Label4.Name = "Label4"
        Label4.Size = New Size(113, 20)
        Label4.TabIndex = 9
        Label4.Text = "Monto en letras"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(21, 275)
        Label5.Name = "Label5"
        Label5.Size = New Size(77, 20)
        Label5.TabIndex = 10
        Label5.Text = "Proveedor"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(341, 275)
        Label6.Name = "Label6"
        Label6.Size = New Size(118, 20)
        Label6.TabIndex = 11
        Label6.Text = "Objeto de Gasto"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(70, 349)
        Label7.Name = "Label7"
        Label7.Size = New Size(57, 20)
        Label7.TabIndex = 12
        Label7.Text = "Detalle"
        ' 
        ' RichTextBox2
        ' 
        RichTextBox2.Location = New Point(126, 349)
        RichTextBox2.Margin = New Padding(3, 4, 3, 4)
        RichTextBox2.Name = "RichTextBox2"
        RichTextBox2.Size = New Size(405, 88)
        RichTextBox2.TabIndex = 13
        RichTextBox2.Text = ""
        ' 
        ' MaterialButton1
        ' 
        MaterialButton1.AutoSizeMode = AutoSizeMode.GrowAndShrink
        MaterialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default
        MaterialButton1.Depth = 0
        MaterialButton1.HighEmphasis = True
        MaterialButton1.Icon = Nothing
        MaterialButton1.Location = New Point(304, 462)
        MaterialButton1.Margin = New Padding(5, 8, 5, 8)
        MaterialButton1.MouseState = MaterialSkin.MouseState.HOVER
        MaterialButton1.Name = "MaterialButton1"
        MaterialButton1.NoAccentTextColor = Color.Empty
        MaterialButton1.Size = New Size(88, 36)
        MaterialButton1.TabIndex = 15
        MaterialButton1.Text = "Agregar"
        MaterialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
        MaterialButton1.UseAccentColor = False
        MaterialButton1.UseVisualStyleBackColor = True
        ' 
        ' formCheque
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(768, 545)
        Controls.Add(MaterialButton1)
        Controls.Add(RichTextBox2)
        Controls.Add(Label7)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(DateTimePicker1)
        Controls.Add(TextBox2)
        Controls.Add(RichTextBox1)
        Controls.Add(TextBox1)
        Controls.Add(comboBoxObjGas)
        Controls.Add(comboBoxProveedor)
        Controls.Add(Label1)
        Margin = New Padding(3, 4, 3, 4)
        Name = "formCheque"
        Padding = New Padding(3, 85, 3, 4)
        Text = "Agregar Cheque"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents comboBoxProveedor As ComboBox
    Friend WithEvents comboBoxObjGas As ComboBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents RichTextBox2 As RichTextBox
    Friend WithEvents MaterialButton1 As MaterialSkin.Controls.MaterialButton
End Class
