<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmApp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmApp))
        Me.BtnCenterControl = New System.Windows.Forms.Button()
        Me.BtnOnlineReport = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'BtnCenterControl
        '
        Me.BtnCenterControl.BackColor = System.Drawing.Color.Crimson
        Me.BtnCenterControl.Font = New System.Drawing.Font("Zar", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.BtnCenterControl.ForeColor = System.Drawing.Color.White
        Me.BtnCenterControl.Location = New System.Drawing.Point(69, 120)
        Me.BtnCenterControl.Name = "BtnCenterControl"
        Me.BtnCenterControl.Size = New System.Drawing.Size(357, 47)
        Me.BtnCenterControl.TabIndex = 1
        Me.BtnCenterControl.Text = "کنترل سيستم"
        Me.BtnCenterControl.UseVisualStyleBackColor = False
        '
        'BtnOnlineReport
        '
        Me.BtnOnlineReport.BackColor = System.Drawing.Color.DodgerBlue
        Me.BtnOnlineReport.Font = New System.Drawing.Font("Zar", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.BtnOnlineReport.ForeColor = System.Drawing.Color.White
        Me.BtnOnlineReport.Location = New System.Drawing.Point(69, 173)
        Me.BtnOnlineReport.Name = "BtnOnlineReport"
        Me.BtnOnlineReport.Size = New System.Drawing.Size(357, 47)
        Me.BtnOnlineReport.TabIndex = 2
        Me.BtnOnlineReport.Text = "گزارش آنلاين و آفلاين تراکنش هاي سيستم"
        Me.BtnOnlineReport.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Zar", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(13, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(471, 45)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "سيستم كنترل متمرکز نوبت دهي پايانه هاي استان اصفهان"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(13, 316)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(272, 22)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "TWS System Server Application"
        '
        'FrmApp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(515, 351)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnCenterControl)
        Me.Controls.Add(Me.BtnOnlineReport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmApp"
        Me.Padding = New System.Windows.Forms.Padding(10)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TWSServerApp"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnCenterControl As System.Windows.Forms.Button
    Friend WithEvents BtnOnlineReport As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label

End Class
