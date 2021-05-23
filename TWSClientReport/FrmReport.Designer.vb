<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReport))
        Me.BtnView = New System.Windows.Forms.Button()
        Me.SqlConnection1 = New System.Data.SqlClient.SqlConnection()
        Me.PnlSetting = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtTotalRec = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PicExitPnlSetting = New System.Windows.Forms.PictureBox()
        Me.PnlMain = New System.Windows.Forms.Panel()
        Me.LblMin = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.LblSelectedTerminal = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.BtnOnLineEbtal = New System.Windows.Forms.Button()
        Me.LblTruckId = New System.Windows.Forms.Label()
        Me.BtnSetting = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.TxtSerial = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtPelak = New System.Windows.Forms.TextBox()
        Me.PicEnd = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PnlUcLogHolder = New System.Windows.Forms.Panel()
        Me.PnlSetting.SuspendLayout()
        CType(Me.PicExitPnlSetting, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlMain.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicEnd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnView
        '
        Me.BtnView.BackColor = System.Drawing.Color.FloralWhite
        Me.BtnView.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnView.Font = New System.Drawing.Font("Zar", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.BtnView.Location = New System.Drawing.Point(21, 154)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(98, 34)
        Me.BtnView.TabIndex = 6
        Me.BtnView.Text = "نمايش"
        Me.BtnView.UseVisualStyleBackColor = False
        '
        'SqlConnection1
        '
        Me.SqlConnection1.ConnectionString = "Data Source=172.20.30.18;Initial Catalog=TDBServer;Persist Security Info=True;Use" & _
            "r ID=sa;Password=Biinfo878"
        Me.SqlConnection1.FireInfoMessageEventOnUserErrors = False
        '
        'PnlSetting
        '
        Me.PnlSetting.BackColor = System.Drawing.Color.White
        Me.PnlSetting.Controls.Add(Me.Label5)
        Me.PnlSetting.Controls.Add(Me.Label3)
        Me.PnlSetting.Controls.Add(Me.TxtTotalRec)
        Me.PnlSetting.Controls.Add(Me.Panel1)
        Me.PnlSetting.Controls.Add(Me.PicExitPnlSetting)
        Me.PnlSetting.Location = New System.Drawing.Point(11, 116)
        Me.PnlSetting.Name = "PnlSetting"
        Me.PnlSetting.Padding = New System.Windows.Forms.Padding(10)
        Me.PnlSetting.Size = New System.Drawing.Size(621, 385)
        Me.PnlSetting.TabIndex = 14
        Me.PnlSetting.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Zar", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label5.Location = New System.Drawing.Point(297, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label5.Size = New System.Drawing.Size(59, 26)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "تنظيمات"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Zar", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label3.Location = New System.Drawing.Point(463, 131)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label3.Size = New System.Drawing.Size(114, 21)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "تعداد رکورد دريافتي :"
        '
        'TxtTotalRec
        '
        Me.TxtTotalRec.Font = New System.Drawing.Font("Alborz Titr", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.TxtTotalRec.Location = New System.Drawing.Point(357, 131)
        Me.TxtTotalRec.Name = "TxtTotalRec"
        Me.TxtTotalRec.Size = New System.Drawing.Size(100, 23)
        Me.TxtTotalRec.TabIndex = 3
        Me.TxtTotalRec.Text = "10"
        Me.TxtTotalRec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.Location = New System.Drawing.Point(0, 59)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(622, 36)
        Me.Panel1.TabIndex = 2
        '
        'PicExitPnlSetting
        '
        Me.PicExitPnlSetting.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PicExitPnlSetting.Image = CType(resources.GetObject("PicExitPnlSetting.Image"), System.Drawing.Image)
        Me.PicExitPnlSetting.Location = New System.Drawing.Point(13, 24)
        Me.PicExitPnlSetting.Name = "PicExitPnlSetting"
        Me.PicExitPnlSetting.Size = New System.Drawing.Size(66, 13)
        Me.PicExitPnlSetting.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicExitPnlSetting.TabIndex = 0
        Me.PicExitPnlSetting.TabStop = False
        '
        'PnlMain
        '
        Me.PnlMain.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.PnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlMain.Controls.Add(Me.LblMin)
        Me.PnlMain.Controls.Add(Me.Label4)
        Me.PnlMain.Controls.Add(Me.Panel2)
        Me.PnlMain.Controls.Add(Me.PicEnd)
        Me.PnlMain.Controls.Add(Me.Label1)
        Me.PnlMain.Controls.Add(Me.PnlUcLogHolder)
        Me.PnlMain.Controls.Add(Me.PnlSetting)
        Me.PnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlMain.Location = New System.Drawing.Point(2, 2)
        Me.PnlMain.Name = "PnlMain"
        Me.PnlMain.Padding = New System.Windows.Forms.Padding(5)
        Me.PnlMain.Size = New System.Drawing.Size(797, 552)
        Me.PnlMain.TabIndex = 16
        '
        'LblMin
        '
        Me.LblMin.BackColor = System.Drawing.Color.Transparent
        Me.LblMin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LblMin.Font = New System.Drawing.Font("Alborz Titr", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblMin.ForeColor = System.Drawing.Color.Red
        Me.LblMin.Location = New System.Drawing.Point(731, -5)
        Me.LblMin.Name = "LblMin"
        Me.LblMin.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.LblMin.Size = New System.Drawing.Size(29, 29)
        Me.LblMin.TabIndex = 26
        Me.LblMin.Text = "-"
        Me.LblMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Zar", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(308, 70)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label4.Size = New System.Drawing.Size(181, 33)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "گزارش رديابي ناوگان"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.LblSelectedTerminal)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.BtnOnLineEbtal)
        Me.Panel2.Controls.Add(Me.LblTruckId)
        Me.Panel2.Controls.Add(Me.BtnSetting)
        Me.Panel2.Controls.Add(Me.PictureBox2)
        Me.Panel2.Controls.Add(Me.BtnView)
        Me.Panel2.Controls.Add(Me.TxtSerial)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.TxtPelak)
        Me.Panel2.Location = New System.Drawing.Point(640, 116)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(143, 385)
        Me.Panel2.TabIndex = 22
        '
        'LblSelectedTerminal
        '
        Me.LblSelectedTerminal.BackColor = System.Drawing.Color.Transparent
        Me.LblSelectedTerminal.Font = New System.Drawing.Font("Zar", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.LblSelectedTerminal.ForeColor = System.Drawing.Color.Red
        Me.LblSelectedTerminal.Location = New System.Drawing.Point(12, 350)
        Me.LblSelectedTerminal.Name = "LblSelectedTerminal"
        Me.LblSelectedTerminal.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.LblSelectedTerminal.Size = New System.Drawing.Size(116, 22)
        Me.LblSelectedTerminal.TabIndex = 24
        Me.LblSelectedTerminal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Zar", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(13, 261)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label6.Size = New System.Drawing.Size(116, 49)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "درخواست ابطال نوبت در سيستم آنلاين"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnOnLineEbtal
        '
        Me.BtnOnLineEbtal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnOnLineEbtal.BackColor = System.Drawing.Color.GhostWhite
        Me.BtnOnLineEbtal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnOnLineEbtal.Font = New System.Drawing.Font("Zar", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.BtnOnLineEbtal.ForeColor = System.Drawing.Color.Black
        Me.BtnOnLineEbtal.Location = New System.Drawing.Point(21, 310)
        Me.BtnOnLineEbtal.Name = "BtnOnLineEbtal"
        Me.BtnOnLineEbtal.Size = New System.Drawing.Size(98, 34)
        Me.BtnOnLineEbtal.TabIndex = 22
        Me.BtnOnLineEbtal.Text = "ابطال نوبت"
        Me.BtnOnLineEbtal.UseVisualStyleBackColor = False
        '
        'LblTruckId
        '
        Me.LblTruckId.AutoSize = True
        Me.LblTruckId.Font = New System.Drawing.Font("Alborz Titr", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblTruckId.ForeColor = System.Drawing.Color.Silver
        Me.LblTruckId.Location = New System.Drawing.Point(56, 136)
        Me.LblTruckId.Name = "LblTruckId"
        Me.LblTruckId.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.LblTruckId.Size = New System.Drawing.Size(11, 15)
        Me.LblTruckId.TabIndex = 19
        Me.LblTruckId.Text = " "
        Me.LblTruckId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnSetting
        '
        Me.BtnSetting.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSetting.BackColor = System.Drawing.Color.GhostWhite
        Me.BtnSetting.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSetting.Font = New System.Drawing.Font("Zar", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.BtnSetting.ForeColor = System.Drawing.Color.Black
        Me.BtnSetting.Location = New System.Drawing.Point(21, 194)
        Me.BtnSetting.Name = "BtnSetting"
        Me.BtnSetting.Size = New System.Drawing.Size(98, 33)
        Me.BtnSetting.TabIndex = 11
        Me.BtnSetting.Text = "تنظيمات"
        Me.BtnSetting.UseVisualStyleBackColor = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.TWSClientReport.My.Resources.Resources.Truck_icon
        Me.PictureBox2.Location = New System.Drawing.Point(56, 99)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(32, 30)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 21
        Me.PictureBox2.TabStop = False
        '
        'TxtSerial
        '
        Me.TxtSerial.BackColor = System.Drawing.Color.White
        Me.TxtSerial.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSerial.Font = New System.Drawing.Font("Zar", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtSerial.ForeColor = System.Drawing.Color.Silver
        Me.TxtSerial.Location = New System.Drawing.Point(3, 72)
        Me.TxtSerial.Name = "TxtSerial"
        Me.TxtSerial.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtSerial.Size = New System.Drawing.Size(134, 21)
        Me.TxtSerial.TabIndex = 18
        Me.TxtSerial.Text = "سري پلاک را وارد نماييد"
        Me.TxtSerial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Zar", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(15, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label2.Size = New System.Drawing.Size(105, 26)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "مشخصات ناوگان"
        '
        'TxtPelak
        '
        Me.TxtPelak.BackColor = System.Drawing.Color.White
        Me.TxtPelak.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPelak.Font = New System.Drawing.Font("Zar", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtPelak.ForeColor = System.Drawing.Color.Silver
        Me.TxtPelak.Location = New System.Drawing.Point(5, 45)
        Me.TxtPelak.Name = "TxtPelak"
        Me.TxtPelak.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtPelak.Size = New System.Drawing.Size(129, 21)
        Me.TxtPelak.TabIndex = 17
        Me.TxtPelak.Text = "پلاک ناوگان را وارد نماييد"
        Me.TxtPelak.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PicEnd
        '
        Me.PicEnd.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.PicEnd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PicEnd.Image = CType(resources.GetObject("PicEnd.Image"), System.Drawing.Image)
        Me.PicEnd.Location = New System.Drawing.Point(762, 4)
        Me.PicEnd.Name = "PicEnd"
        Me.PicEnd.Size = New System.Drawing.Size(22, 24)
        Me.PicEnd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicEnd.TabIndex = 12
        Me.PicEnd.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Zar", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(52, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label1.Size = New System.Drawing.Size(662, 50)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "سيستم کنترل متمرکز نوبت دهي پايانه هاي استان اصفهان"
        '
        'PnlUcLogHolder
        '
        Me.PnlUcLogHolder.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PnlUcLogHolder.AutoScroll = True
        Me.PnlUcLogHolder.BackColor = System.Drawing.Color.White
        Me.PnlUcLogHolder.BackgroundImage = Global.TWSClientReport.My.Resources.Resources._2
        Me.PnlUcLogHolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PnlUcLogHolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlUcLogHolder.Location = New System.Drawing.Point(11, 116)
        Me.PnlUcLogHolder.Name = "PnlUcLogHolder"
        Me.PnlUcLogHolder.Size = New System.Drawing.Size(621, 385)
        Me.PnlUcLogHolder.TabIndex = 1
        '
        'FrmReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Crimson
        Me.ClientSize = New System.Drawing.Size(801, 556)
        Me.ControlBox = False
        Me.Controls.Add(Me.PnlMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmReport"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TWSClientOfflineReport"
        Me.PnlSetting.ResumeLayout(False)
        Me.PnlSetting.PerformLayout()
        CType(Me.PicExitPnlSetting, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlMain.ResumeLayout(False)
        Me.PnlMain.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicEnd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnView As System.Windows.Forms.Button
    Friend WithEvents PnlUcLogHolder As System.Windows.Forms.Panel
    Friend WithEvents PicEnd As System.Windows.Forms.PictureBox
    Friend WithEvents SqlConnection1 As System.Data.SqlClient.SqlConnection
    Friend WithEvents PnlSetting As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PicExitPnlSetting As System.Windows.Forms.PictureBox
    Friend WithEvents PnlMain As System.Windows.Forms.Panel
    Friend WithEvents BtnSetting As System.Windows.Forms.Button
    Friend WithEvents TxtSerial As System.Windows.Forms.TextBox
    Friend WithEvents TxtPelak As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtTotalRec As System.Windows.Forms.TextBox
    Friend WithEvents LblTruckId As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents LblMin As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents BtnOnLineEbtal As System.Windows.Forms.Button
    Friend WithEvents LblSelectedTerminal As System.Windows.Forms.Label
End Class
