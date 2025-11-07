<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formInicioSesion
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
        MaterialLabel2 = New MaterialSkin.Controls.MaterialLabel()
        MaterialButton1 = New MaterialSkin.Controls.MaterialButton()
        MaterialTextBox1 = New MaterialSkin.Controls.MaterialTextBox()
        MaterialTextBox2 = New MaterialSkin.Controls.MaterialTextBox()
        SuspendLayout()
        ' 
        ' MaterialLabel1
        ' 
        MaterialLabel1.AutoSize = True
        MaterialLabel1.Depth = 0
        MaterialLabel1.Font = New Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel)
        MaterialLabel1.Location = New Point(71, 110)
        MaterialLabel1.MouseState = MaterialSkin.MouseState.HOVER
        MaterialLabel1.Name = "MaterialLabel1"
        MaterialLabel1.Size = New Size(55, 19)
        MaterialLabel1.TabIndex = 0
        MaterialLabel1.Text = "Usuario"
        ' 
        ' MaterialLabel2
        ' 
        MaterialLabel2.AutoSize = True
        MaterialLabel2.Depth = 0
        MaterialLabel2.Font = New Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel)
        MaterialLabel2.Location = New Point(44, 209)
        MaterialLabel2.MouseState = MaterialSkin.MouseState.HOVER
        MaterialLabel2.Name = "MaterialLabel2"
        MaterialLabel2.Size = New Size(82, 19)
        MaterialLabel2.TabIndex = 2
        MaterialLabel2.Text = "Contraseña"
        ' 
        ' MaterialButton1
        ' 
        MaterialButton1.AutoSizeMode = AutoSizeMode.GrowAndShrink
        MaterialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default
        MaterialButton1.Depth = 0
        MaterialButton1.HighEmphasis = True
        MaterialButton1.Icon = Nothing
        MaterialButton1.Location = New Point(146, 271)
        MaterialButton1.Margin = New Padding(4, 6, 4, 6)
        MaterialButton1.MouseState = MaterialSkin.MouseState.HOVER
        MaterialButton1.Name = "MaterialButton1"
        MaterialButton1.NoAccentTextColor = Color.Empty
        MaterialButton1.Size = New Size(91, 36)
        MaterialButton1.TabIndex = 4
        MaterialButton1.Text = "Ingresar"
        MaterialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
        MaterialButton1.UseAccentColor = False
        MaterialButton1.UseVisualStyleBackColor = True
        ' 
        ' MaterialTextBox1
        ' 
        MaterialTextBox1.AnimateReadOnly = False
        MaterialTextBox1.BorderStyle = BorderStyle.None
        MaterialTextBox1.Depth = 0
        MaterialTextBox1.Font = New Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel)
        MaterialTextBox1.LeadingIcon = Nothing
        MaterialTextBox1.Location = New Point(146, 94)
        MaterialTextBox1.MaxLength = 50
        MaterialTextBox1.MouseState = MaterialSkin.MouseState.OUT
        MaterialTextBox1.Multiline = False
        MaterialTextBox1.Name = "MaterialTextBox1"
        MaterialTextBox1.Size = New Size(210, 50)
        MaterialTextBox1.TabIndex = 5
        MaterialTextBox1.Text = ""
        MaterialTextBox1.TrailingIcon = Nothing
        ' 
        ' MaterialTextBox2
        ' 
        MaterialTextBox2.AnimateReadOnly = False
        MaterialTextBox2.BorderStyle = BorderStyle.None
        MaterialTextBox2.Depth = 0
        MaterialTextBox2.Font = New Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel)
        MaterialTextBox2.LeadingIcon = Nothing
        MaterialTextBox2.Location = New Point(146, 197)
        MaterialTextBox2.MaxLength = 50
        MaterialTextBox2.MouseState = MaterialSkin.MouseState.OUT
        MaterialTextBox2.Multiline = False
        MaterialTextBox2.Name = "MaterialTextBox2"
        MaterialTextBox2.Size = New Size(210, 50)
        MaterialTextBox2.TabIndex = 6
        MaterialTextBox2.Text = ""
        MaterialTextBox2.TrailingIcon = Nothing
        ' 
        ' formInicioSesion
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(394, 331)
        Controls.Add(MaterialTextBox2)
        Controls.Add(MaterialTextBox1)
        Controls.Add(MaterialButton1)
        Controls.Add(MaterialLabel2)
        Controls.Add(MaterialLabel1)
        Name = "formInicioSesion"
        Text = "Iniciar Sesion"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents MaterialLabel1 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents MaterialLabel2 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents MaterialButton1 As MaterialSkin.Controls.MaterialButton
    Friend WithEvents MaterialTextBox1 As MaterialSkin.Controls.MaterialTextBox
    Friend WithEvents MaterialTextBox2 As MaterialSkin.Controls.MaterialTextBox
End Class
