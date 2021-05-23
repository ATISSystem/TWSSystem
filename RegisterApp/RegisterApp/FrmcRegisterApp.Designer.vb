<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RegisterApp
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RegisterApp))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnCreateRegistery = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtCNN = New System.Windows.Forms.TextBox()
        Me.BtnSubMit = New System.Windows.Forms.Button()
        Me.SqlConnection1 = New System.Data.SqlClient.SqlConnection()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.Location = New System.Drawing.Point(32, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Registery  :"
        '
        'BtnCreateRegistery
        '
        Me.BtnCreateRegistery.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.BtnCreateRegistery.Location = New System.Drawing.Point(146, 24)
        Me.BtnCreateRegistery.Name = "BtnCreateRegistery"
        Me.BtnCreateRegistery.Size = New System.Drawing.Size(184, 23)
        Me.BtnCreateRegistery.TabIndex = 1
        Me.BtnCreateRegistery.Text = "Create Registery"
        Me.BtnCreateRegistery.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label4.Location = New System.Drawing.Point(32, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(190, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Default Connection String :"
        '
        'TxtCNN
        '
        Me.TxtCNN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtCNN.Location = New System.Drawing.Point(71, 82)
        Me.TxtCNN.Name = "TxtCNN"
        Me.TxtCNN.Size = New System.Drawing.Size(482, 20)
        Me.TxtCNN.TabIndex = 5
        Me.TxtCNN.Text = "Data Source=RD\SQL2008R2;Initial Catalog=@;Integrated Security=True"
        '
        'BtnSubMit
        '
        Me.BtnSubMit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.BtnSubMit.Location = New System.Drawing.Point(202, 239)
        Me.BtnSubMit.Name = "BtnSubMit"
        Me.BtnSubMit.Size = New System.Drawing.Size(184, 23)
        Me.BtnSubMit.TabIndex = 6
        Me.BtnSubMit.Text = "SubMit"
        Me.BtnSubMit.UseVisualStyleBackColor = True
        '
        'SqlConnection1
        '
        Me.SqlConnection1.ConnectionString = "Data Source=RD\SQL2008R2;Initial Catalog=Bm2p92;Integrated Security=True"
        Me.SqlConnection1.FireInfoMessageEventOnUserErrors = False
        '
        'RegisterApp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 349)
        Me.Controls.Add(Me.BtnSubMit)
        Me.Controls.Add(Me.TxtCNN)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.BtnCreateRegistery)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "RegisterApp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RegisterApp"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnCreateRegistery As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtCNN As System.Windows.Forms.TextBox
    Friend WithEvents BtnSubMit As System.Windows.Forms.Button
    Friend WithEvents SqlConnection1 As System.Data.SqlClient.SqlConnection

End Class
