<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formControlObjGasto
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
        DataGridView1 = New DataGridView()
        MaterialButton1 = New MaterialSkin.Controls.MaterialButton()
        MaterialLabel1 = New MaterialSkin.Controls.MaterialLabel()
        columnCodigo = New DataGridViewTextBoxColumn()
        columnDetalle = New DataGridViewTextBoxColumn()
        columnObjeto = New DataGridViewTextBoxColumn()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Columns.AddRange(New DataGridViewColumn() {columnCodigo, columnDetalle, columnObjeto})
        DataGridView1.Location = New Point(30, 126)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.ReadOnly = True
        DataGridView1.Size = New Size(737, 299)
        DataGridView1.TabIndex = 0
        ' 
        ' MaterialButton1
        ' 
        MaterialButton1.AutoSizeMode = AutoSizeMode.GrowAndShrink
        MaterialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default
        MaterialButton1.Depth = 0
        MaterialButton1.HighEmphasis = True
        MaterialButton1.Icon = Nothing
        MaterialButton1.Location = New Point(609, 81)
        MaterialButton1.Margin = New Padding(4, 6, 4, 6)
        MaterialButton1.MouseState = MaterialSkin.MouseState.HOVER
        MaterialButton1.Name = "MaterialButton1"
        MaterialButton1.NoAccentTextColor = Color.Empty
        MaterialButton1.Size = New Size(155, 36)
        MaterialButton1.TabIndex = 1
        MaterialButton1.Text = "Agregar Objetos"
        MaterialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
        MaterialButton1.UseAccentColor = False
        MaterialButton1.UseVisualStyleBackColor = True
        ' 
        ' MaterialLabel1
        ' 
        MaterialLabel1.AutoSize = True
        MaterialLabel1.Depth = 0
        MaterialLabel1.Font = New Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel)
        MaterialLabel1.Location = New Point(30, 91)
        MaterialLabel1.MouseState = MaterialSkin.MouseState.HOVER
        MaterialLabel1.Name = "MaterialLabel1"
        MaterialLabel1.Size = New Size(115, 19)
        MaterialLabel1.TabIndex = 2
        MaterialLabel1.Text = "Lista de Objetos"
        ' 
        ' columnCodigo
        ' 
        columnCodigo.Frozen = True
        columnCodigo.HeaderText = "ID Objeto Gasto"
        columnCodigo.Name = "columnCodigo"
        columnCodigo.ReadOnly = True
        ' 
        ' columnDetalle
        ' 
        columnDetalle.Frozen = True
        columnDetalle.HeaderText = "Detalle"
        columnDetalle.Name = "columnDetalle"
        columnDetalle.ReadOnly = True
        ' 
        ' columnObjeto
        ' 
        columnObjeto.Frozen = True
        columnObjeto.HeaderText = "Objeto/Cantidad"
        columnObjeto.Name = "columnObjeto"
        columnObjeto.ReadOnly = True
        ' 
        ' formControlObjGasto
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(MaterialLabel1)
        Controls.Add(MaterialButton1)
        Controls.Add(DataGridView1)
        Name = "formControlObjGasto"
        Text = "Configuracion Objeto Gasto"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents MaterialButton1 As MaterialSkin.Controls.MaterialButton
    Friend WithEvents MaterialLabel1 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents columnCodigo As DataGridViewTextBoxColumn
    Friend WithEvents columnDetalle As DataGridViewTextBoxColumn
    Friend WithEvents columnObjeto As DataGridViewTextBoxColumn
End Class
