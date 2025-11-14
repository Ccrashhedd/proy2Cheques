<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formProveedor
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
        MaterialLabel1 = New MaterialSkin.Controls.MaterialLabel()
        Label1 = New Label()
        TextBox1 = New TextBox()
        TextBox2 = New TextBox()
        TextBox3 = New TextBox()
        TextBox4 = New TextBox()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        MaterialButton1 = New MaterialSkin.Controls.MaterialButton()
        SuspendLayout()
        ' 
        ' MaterialLabel1
        ' 
        MaterialLabel1.AutoSize = True
        MaterialLabel1.Depth = 0
        MaterialLabel1.Font = New Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel)
        MaterialLabel1.Location = New Point(23, 108)
        MaterialLabel1.MouseState = MaterialSkin.MouseState.HOVER
        MaterialLabel1.Name = "MaterialLabel1"
        MaterialLabel1.Size = New Size(197, 19)
        MaterialLabel1.TabIndex = 0
        MaterialLabel1.Text = "Configuracion de Proveedor"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(46, 169)
        Label1.Name = "Label1"
        Label1.Size = New Size(58, 20)
        Label1.TabIndex = 1
        Label1.Text = "Codigo"
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(105, 165)
        TextBox1.Margin = New Padding(3, 4, 3, 4)
        TextBox1.MaxLength = 5
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(114, 27)
        TextBox1.TabIndex = 2
        ' 
        ' TextBox2
        ' 
        TextBox2.Location = New Point(330, 165)
        TextBox2.Margin = New Padding(3, 4, 3, 4)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(114, 27)
        TextBox2.TabIndex = 3
        ' 
        ' TextBox3
        ' 
        TextBox3.Location = New Point(105, 256)
        TextBox3.Margin = New Padding(3, 4, 3, 4)
        TextBox3.Name = "TextBox3"
        TextBox3.Size = New Size(114, 27)
        TextBox3.TabIndex = 4
        ' 
        ' TextBox4
        ' 
        TextBox4.Location = New Point(330, 263)
        TextBox4.Margin = New Padding(3, 4, 3, 4)
        TextBox4.Name = "TextBox4"
        TextBox4.Size = New Size(114, 27)
        TextBox4.TabIndex = 5
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(265, 169)
        Label2.Name = "Label2"
        Label2.Size = New Size(64, 20)
        Label2.TabIndex = 6
        Label2.Text = "Nombre"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(64, 260)
        Label3.Name = "Label3"
        Label3.Size = New Size(37, 20)
        Label3.TabIndex = 7
        Label3.Text = "RUC"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(258, 267)
        Label4.Name = "Label4"
        Label4.Size = New Size(72, 20)
        Label4.TabIndex = 8
        Label4.Text = "Direccion"
        ' 
        ' MaterialButton1
        ' 
        MaterialButton1.AutoSizeMode = AutoSizeMode.GrowAndShrink
        MaterialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default
        MaterialButton1.Depth = 0
        MaterialButton1.HighEmphasis = True
        MaterialButton1.Icon = Nothing
        MaterialButton1.Location = New Point(190, 333)
        MaterialButton1.Margin = New Padding(5, 8, 5, 8)
        MaterialButton1.MouseState = MaterialSkin.MouseState.HOVER
        MaterialButton1.Name = "MaterialButton1"
        MaterialButton1.NoAccentTextColor = Color.Empty
        MaterialButton1.Size = New Size(88, 36)
        MaterialButton1.TabIndex = 9
        MaterialButton1.Text = "Agregar"
        MaterialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
        MaterialButton1.UseAccentColor = False
        MaterialButton1.UseVisualStyleBackColor = True
        ' 
        ' formProveedor
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(509, 412)
        Controls.Add(MaterialButton1)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(TextBox4)
        Controls.Add(TextBox3)
        Controls.Add(TextBox2)
        Controls.Add(TextBox1)
        Controls.Add(Label1)
        Controls.Add(MaterialLabel1)
        Margin = New Padding(3, 4, 3, 4)
        Name = "formProveedor"
        Padding = New Padding(3, 85, 3, 4)
        Text = "Proveedor"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents MaterialLabel1 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents MaterialButton1 As MaterialSkin.Controls.MaterialButton
End Class
