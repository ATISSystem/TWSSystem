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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblTerminal = New System.Windows.Forms.Label()
        Me.LblNew = New System.Windows.Forms.Label()
        Me.LblTime = New System.Windows.Forms.Label()
        Me.LblShamsiDate = New System.Windows.Forms.Label()
        Me.LblLogNote = New System.Windows.Forms.Label()
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.PnlMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlMain
        '
        Me.PnlMain.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.PnlMain.Controls.Add(Me.LblTerminal)
        Me.PnlMain.Controls.Add(Me.Label1)
        Me.PnlMain.Controls.Add(Me.LblNew)
        Me.PnlMain.Controls.Add(Me.LblTime)
        Me.PnlMain.Controls.Add(Me.LblShamsiDate)
        Me.PnlMain.Controls.Add(Me.LblLogNote)
        Me.PnlMain.Cursor = System.Windows.Forms.Cursors.Default
        Me.PnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlMain.Location = New System.Drawing.Point(10, 10)
        Me.PnlMain.Name = "PnlMain"
        Me.PnlMain.Size = New System.Drawing.Size(692, 57)
        Me.PnlMain.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("B Homa", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(304, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label1.Size = New System.Drawing.Size(105, 25)
        Me.Label1.TabIndex = 82
        Me.Label1.Text = "زمان اتصال :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblTerminal
        '
        Me.LblTerminal.Font = New System.Drawing.Font("B Homa", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.LblTerminal.ForeColor = System.Drawing.Color.White
        Me.LblTerminal.Location = New System.Drawing.Point(460, 0)
        Me.LblTerminal.Name = "LblTerminal"
        Me.LblTerminal.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.LblTerminal.Size = New System.Drawing.Size(221, 47)
        Me.LblTerminal.TabIndex = 39
        Me.LblTerminal.Text = "امير کبير"
        Me.LblTerminal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblNew
        '
        Me.LblNew.Font = New System.Drawing.Font("B Homa", 11.25!)
        Me.LblNew.ForeColor = System.Drawing.Color.Red
        Me.LblNew.Location = New System.Drawing.Point(11, 13)
        Me.LblNew.Name = "LblNew"
        Me.LblNew.Size = New System.Drawing.Size(55, 25)
        Me.LblNew.TabIndex = 81
        Me.LblNew.Text = "New"
        Me.LblNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTime
        '
        Me.LblTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.LblTime.ForeColor = System.Drawing.Color.White
        Me.LblTime.Location = New System.Drawing.Point(138, 7)
        Me.LblTime.Name = "LblTime"
        Me.LblTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.LblTime.Size = New System.Drawing.Size(74, 23)
        Me.LblTime.TabIndex = 44
        Me.LblTime.Text = "12:12:12"
        Me.LblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblShamsiDate
        '
        Me.LblShamsiDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.LblShamsiDate.ForeColor = System.Drawing.Color.White
        Me.LblShamsiDate.Location = New System.Drawing.Point(218, 7)
        Me.LblShamsiDate.Name = "LblShamsiDate"
        Me.LblShamsiDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.LblShamsiDate.Size = New System.Drawing.Size(84, 23)
        Me.LblShamsiDate.TabIndex = 43
        Me.LblShamsiDate.Text = "1396/04/21"
        Me.LblShamsiDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblLogNote
        '
        Me.LblLogNote.ForeColor = System.Drawing.Color.White
        Me.LblLogNote.Location = New System.Drawing.Point(72, 29)
        Me.LblLogNote.Name = "LblLogNote"
        Me.LblLogNote.Size = New System.Drawing.Size(537, 18)
        Me.LblLogNote.TabIndex = 78
        Me.LblLogNote.Text = "?"
        Me.LblLogNote.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.PnlMain)
        Me.Name = "UcSingleLogHolder"
        Me.Padding = New System.Windows.Forms.Padding(10)
        Me.Size = New System.Drawing.Size(712, 77)
        Me.PnlMain.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlMain As System.Windows.Forms.Panel
    Friend WithEvents LblTerminal As System.Windows.Forms.Label
    Friend WithEvents LblTime As System.Windows.Forms.Label
    Friend WithEvents LblShamsiDate As System.Windows.Forms.Label
    Friend WithEvents LblLogNote As System.Windows.Forms.Label
    Friend WithEvents ImageList As System.Windows.Forms.ImageList
    Friend WithEvents LblNew As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
