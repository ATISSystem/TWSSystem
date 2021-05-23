<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UcSingleLogHolder
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UcSingleLogHolder))
        Me.PnlMain = New System.Windows.Forms.Panel()
        Me.LblTravelTime = New System.Windows.Forms.Label()
        Me.LblTime = New System.Windows.Forms.Label()
        Me.LblShamsiDate = New System.Windows.Forms.Label()
        Me.LblTerminal = New System.Windows.Forms.Label()
        Me.LblTraceWriter = New System.Windows.Forms.Label()
        Me.LblStatus = New System.Windows.Forms.Label()
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.PnlMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlMain
        '
        Me.PnlMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PnlMain.Controls.Add(Me.LblTravelTime)
        Me.PnlMain.Controls.Add(Me.LblTime)
        Me.PnlMain.Controls.Add(Me.LblShamsiDate)
        Me.PnlMain.Controls.Add(Me.LblTerminal)
        Me.PnlMain.Controls.Add(Me.LblTraceWriter)
        Me.PnlMain.Controls.Add(Me.LblStatus)
        Me.PnlMain.Cursor = System.Windows.Forms.Cursors.Default
        Me.PnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlMain.Location = New System.Drawing.Point(5, 5)
        Me.PnlMain.Name = "PnlMain"
        Me.PnlMain.Size = New System.Drawing.Size(603, 29)
        Me.PnlMain.TabIndex = 0
        '
        'LblTravelTime
        '
        Me.LblTravelTime.Font = New System.Drawing.Font("Alborz Titr", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblTravelTime.ForeColor = System.Drawing.Color.White
        Me.LblTravelTime.Location = New System.Drawing.Point(91, 7)
        Me.LblTravelTime.Name = "LblTravelTime"
        Me.LblTravelTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.LblTravelTime.Size = New System.Drawing.Size(32, 20)
        Me.LblTravelTime.TabIndex = 56
        Me.LblTravelTime.Text = "54"
        Me.LblTravelTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LblTravelTime.UseCompatibleTextRendering = True
        '
        'LblTime
        '
        Me.LblTime.Font = New System.Drawing.Font("Alborz Titr", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblTime.ForeColor = System.Drawing.Color.White
        Me.LblTime.Location = New System.Drawing.Point(525, 3)
        Me.LblTime.Name = "LblTime"
        Me.LblTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.LblTime.Size = New System.Drawing.Size(67, 23)
        Me.LblTime.TabIndex = 44
        Me.LblTime.Text = "12:12:12"
        Me.LblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblShamsiDate
        '
        Me.LblShamsiDate.Font = New System.Drawing.Font("Alborz Titr", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblShamsiDate.ForeColor = System.Drawing.Color.White
        Me.LblShamsiDate.Location = New System.Drawing.Point(453, 3)
        Me.LblShamsiDate.Name = "LblShamsiDate"
        Me.LblShamsiDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.LblShamsiDate.Size = New System.Drawing.Size(74, 23)
        Me.LblShamsiDate.TabIndex = 43
        Me.LblShamsiDate.Text = "91/10/10"
        Me.LblShamsiDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTerminal
        '
        Me.LblTerminal.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTerminal.ForeColor = System.Drawing.Color.White
        Me.LblTerminal.Location = New System.Drawing.Point(321, 1)
        Me.LblTerminal.Name = "LblTerminal"
        Me.LblTerminal.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.LblTerminal.Size = New System.Drawing.Size(128, 26)
        Me.LblTerminal.TabIndex = 39
        Me.LblTerminal.Text = "امير کبير"
        Me.LblTerminal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTraceWriter
        '
        Me.LblTraceWriter.AutoSize = True
        Me.LblTraceWriter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.LblTraceWriter.ForeColor = System.Drawing.Color.White
        Me.LblTraceWriter.Location = New System.Drawing.Point(3, 8)
        Me.LblTraceWriter.Name = "LblTraceWriter"
        Me.LblTraceWriter.Size = New System.Drawing.Size(76, 13)
        Me.LblTraceWriter.TabIndex = 10
        Me.LblTraceWriter.Text = "WebService"
        Me.LblTraceWriter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblStatus
        '
        Me.LblStatus.Font = New System.Drawing.Font("Zar", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.LblStatus.ForeColor = System.Drawing.Color.White
        Me.LblStatus.Location = New System.Drawing.Point(134, 2)
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.LblStatus.Size = New System.Drawing.Size(181, 23)
        Me.LblStatus.TabIndex = 78
        Me.LblStatus.Text = "صدور مجوز"
        Me.LblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ImageList
        '
        Me.ImageList.ImageStream = CType(resources.GetObject("ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList.Images.SetKeyName(0, "Down.jpg")
        Me.ImageList.Images.SetKeyName(1, "Up.jpg")
        '
        'UcSingleLogHolder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.PnlMain)
        Me.Name = "UcSingleLogHolder"
        Me.Padding = New System.Windows.Forms.Padding(5)
        Me.Size = New System.Drawing.Size(613, 39)
        Me.PnlMain.ResumeLayout(False)
        Me.PnlMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlMain As System.Windows.Forms.Panel
    Friend WithEvents LblTraceWriter As System.Windows.Forms.Label
    Friend WithEvents LblTerminal As System.Windows.Forms.Label
    Friend WithEvents LblTime As System.Windows.Forms.Label
    Friend WithEvents LblShamsiDate As System.Windows.Forms.Label
    Friend WithEvents LblStatus As System.Windows.Forms.Label
    Friend WithEvents LblTravelTime As System.Windows.Forms.Label
    Friend WithEvents ImageList As System.Windows.Forms.ImageList

End Class
