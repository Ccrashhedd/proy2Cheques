<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class formControlProv
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
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        DataGridView1 = New DataGridView()
        MaterialButton1 = New MaterialSkin.Controls.MaterialButton()
        MaterialLabel1 = New MaterialSkin.Controls.MaterialLabel()
        columnIdProveedor = New DataGridViewTextBoxColumn()
        columnNombre = New DataGridViewTextBoxColumn()
        columnRUC = New DataGridViewTextBoxColumn()
        columnUbicacion = New DataGridViewTextBoxColumn()
        columnEliminar = New DataGridViewButtonColumn()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.TopLeft
        DataGridViewCellStyle1.BackColor = SystemColors.Control
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle1.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Columns.AddRange(New DataGridViewColumn() {columnIdProveedor, columnNombre, columnRUC, columnUbicacion, columnEliminar})
        DataGridView1.Location = New Point(81, 125)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.ReadOnly = True
        DataGridView1.Size = New Size(649, 392)
        DataGridView1.TabIndex = 3
        ' 
        ' MaterialButton1
        ' 
        MaterialButton1.AutoSizeMode = AutoSizeMode.GrowAndShrink
        MaterialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default
        MaterialButton1.Depth = 0
        MaterialButton1.HighEmphasis = True
        MaterialButton1.Icon = Nothing
        MaterialButton1.Location = New Point(631, 80)
        MaterialButton1.Margin = New Padding(4, 6, 4, 6)
        MaterialButton1.MouseState = MaterialSkin.MouseState.HOVER
        MaterialButton1.Name = "MaterialButton1"
        MaterialButton1.NoAccentTextColor = Color.Empty
        MaterialButton1.Size = New Size(157, 36)
        MaterialButton1.TabIndex = 4
        MaterialButton1.Text = "Nuevo Proveedor"
        MaterialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained
        MaterialButton1.UseAccentColor = False
        MaterialButton1.UseVisualStyleBackColor = True
        ' 
        ' MaterialLabel1
        ' 
        MaterialLabel1.AutoSize = True
        MaterialLabel1.Depth = 0
        MaterialLabel1.Font = New Font("Roboto", 24F, FontStyle.Bold, GraphicsUnit.Pixel)
        MaterialLabel1.FontType = MaterialSkin.MaterialSkinManager.fontType.H5
        MaterialLabel1.Location = New Point(23, 80)
        MaterialLabel1.MouseState = MaterialSkin.MouseState.HOVER
        MaterialLabel1.Name = "MaterialLabel1"
        MaterialLabel1.Size = New Size(137, 29)
        MaterialLabel1.TabIndex = 5
        MaterialLabel1.Text = "Proveedores"
        ' 
        ' columnIdProveedor
        ' 
        columnIdProveedor.Frozen = True
        columnIdProveedor.HeaderText = "ID Proveedor"
        columnIdProveedor.Name = "columnIdProveedor"
        columnIdProveedor.ReadOnly = True
        ' 
        ' columnNombre
        ' 
        columnNombre.Frozen = True
        columnNombre.HeaderText = "Nombre Proveedor"
        columnNombre.Name = "columnNombre"
        columnNombre.ReadOnly = True
        ' 
        ' columnRUC
        ' 
        columnRUC.Frozen = True
        columnRUC.HeaderText = "RUC"
        columnRUC.Name = "columnRUC"
        columnRUC.ReadOnly = True
        ' 
        ' columnUbicacion
        ' 
        columnUbicacion.Frozen = True
        columnUbicacion.HeaderText = "Ubicacion"
        columnUbicacion.Name = "columnUbicacion"
        columnUbicacion.ReadOnly = True
        ' 
        ' columnEliminar
        ' 
        columnEliminar.Frozen = True
        columnEliminar.HeaderText = "Eliminar"
        columnEliminar.Name = "columnEliminar"
        columnEliminar.ReadOnly = True
        ' 
        ' formControlProv
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        ClientSize = New Size(801, 528)
        Controls.Add(MaterialLabel1)
        Controls.Add(MaterialButton1)
        Controls.Add(DataGridView1)
        Name = "formControlProv"
        Text = "Configuracion de Proveedores"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents MaterialButton1 As MaterialSkin.Controls.MaterialButton
    Friend WithEvents MaterialLabel1 As MaterialSkin.Controls.MaterialLabel
    Friend WithEvents columnIdProveedor As DataGridViewTextBoxColumn
    Friend WithEvents columnNombre As DataGridViewTextBoxColumn
    Friend WithEvents columnRUC As DataGridViewTextBoxColumn
    Friend WithEvents columnUbicacion As DataGridViewTextBoxColumn
    Friend WithEvents columnEliminar As DataGridViewButtonColumn
End Class
