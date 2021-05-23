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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReport))
        Me.OpbOnline = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.OpbOffLine = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.BtnStart = New System.Windows.Forms.Button()
        Me.BtnStop = New System.Windows.Forms.Button()
        Me.Timer = New System.Windows.Forms.Timer(Me.components)
        Me.BtnRefresh = New System.Windows.Forms.Button()
        Me.PnlUcLogHolder = New System.Windows.Forms.Panel()
        Me.PicEnd = New System.Windows.Forms.PictureBox()
        Me.PnlTop = New System.Windows.Forms.Panel()
        Me.PicMin = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SqlConnection1 = New System.Data.SqlClient.SqlConnection()
        Me.PnlSetting = New System.Windows.Forms.Panel()
        Me.ChkWarning = New System.Windows.Forms.CheckBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.BtnDontLogDisplay = New System.Windows.Forms.Button()
        Me.ChkServerWinServiceStart = New System.Windows.Forms.CheckBox()
        Me.ChkServerWinServiceStop = New System.Windows.Forms.CheckBox()
        Me.ChkServerWinServiceGarbageTimerElapsed = New System.Windows.Forms.CheckBox()
        Me.ChkServerWinAppCreateTerminal = New System.Windows.Forms.CheckBox()
        Me.ChkClientWinReportAppPassOk = New System.Windows.Forms.CheckBox()
        Me.ChkCenterControlChangeSystemStatus = New System.Windows.Forms.CheckBox()
        Me.ChkWebMethodSetNewSystemStatus = New System.Windows.Forms.CheckBox()
        Me.ChkWebMethodGetNewSystemStatus = New System.Windows.Forms.CheckBox()
        Me.ChkClientWinReportAppTimerStart = New System.Windows.Forms.CheckBox()
        Me.ChkGetExistNobatsInOtherData = New System.Windows.Forms.CheckBox()
        Me.ChkGetSTPsTblConfigurationData = New System.Windows.Forms.CheckBox()
        Me.ChkIdentifyTerminal = New System.Windows.Forms.CheckBox()
        Me.ChkClientWinAppSettingSqlServerAdmin = New System.Windows.Forms.CheckBox()
        Me.ChkClientWinAppServiceStart = New System.Windows.Forms.CheckBox()
        Me.ChkSystemStatusChangedToExecuteNonOutputSqlCommand = New System.Windows.Forms.CheckBox()
        Me.ChkSystemStatusChangedToExecuteWithOutputSqlCommand = New System.Windows.Forms.CheckBox()
        Me.ChkWinServiceStart = New System.Windows.Forms.CheckBox()
        Me.ChkWinServiceStop = New System.Windows.Forms.CheckBox()
        Me.ChkSendCurrentStatus = New System.Windows.Forms.CheckBox()
        Me.ChkSetWinServiceSyncCounting = New System.Windows.Forms.CheckBox()
        Me.ChkSetWinServiceTimerInterval = New System.Windows.Forms.CheckBox()
        Me.ChkGetWinServiceConnectionString = New System.Windows.Forms.CheckBox()
        Me.ChkGetWinServiceTerminalId = New System.Windows.Forms.CheckBox()
        Me.ChkGetWinServiceDateTime = New System.Windows.Forms.CheckBox()
        Me.ChkGetWinServiceComputerInfo = New System.Windows.Forms.CheckBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.ChkSyncAll = New System.Windows.Forms.CheckBox()
        Me.ChkAuthentication = New System.Windows.Forms.CheckBox()
        Me.ChkSystemStatusChangedToSystemClearNobatsTrucksBufferAndSilent = New System.Windows.Forms.CheckBox()
        Me.ChkSystemStatusChangedToSystemGeneral = New System.Windows.Forms.CheckBox()
        Me.ChkSystemStatusChangedToSystemFullSilent = New System.Windows.Forms.CheckBox()
        Me.ChkSystemStatusChangedToStpExistNobatSilent = New System.Windows.Forms.CheckBox()
        Me.ChkSystemStatusChangedToWinServiceSilent = New System.Windows.Forms.CheckBox()
        Me.ChkSyncTrucks = New System.Windows.Forms.CheckBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ChkErrorLog = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PicExitPnlSetting = New System.Windows.Forms.PictureBox()
        Me.PnlMain = New System.Windows.Forms.Panel()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.BtnSetting = New System.Windows.Forms.Button()
        Me.LblLogTotal = New System.Windows.Forms.Label()
        CType(Me.PicEnd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlTop.SuspendLayout()
        CType(Me.PicMin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlSetting.SuspendLayout()
        CType(Me.PicExitPnlSetting, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'OpbOnline
        '
        Me.OpbOnline.Checked = True
        Me.OpbOnline.Location = New System.Drawing.Point(8, 40)
        Me.OpbOnline.Name = "OpbOnline"
        Me.OpbOnline.Size = New System.Drawing.Size(20, 24)
        Me.OpbOnline.TabIndex = 0
        Me.OpbOnline.TabStop = True
        Me.OpbOnline.Text = " "
        Me.OpbOnline.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(26, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 18)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "OnLine Report"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(26, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 18)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "OffLine Report"
        '
        'OpbOffLine
        '
        Me.OpbOffLine.Location = New System.Drawing.Point(8, 68)
        Me.OpbOffLine.Name = "OpbOffLine"
        Me.OpbOffLine.Size = New System.Drawing.Size(20, 24)
        Me.OpbOffLine.TabIndex = 2
        Me.OpbOffLine.Text = " "
        Me.OpbOffLine.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(139, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label3.Size = New System.Drawing.Size(68, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "From Date"
        '
        'DateTimePicker
        '
        Me.DateTimePicker.Font = New System.Drawing.Font("Times New Roman", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker.Location = New System.Drawing.Point(213, 71)
        Me.DateTimePicker.Name = "DateTimePicker"
        Me.DateTimePicker.RightToLeftLayout = True
        Me.DateTimePicker.Size = New System.Drawing.Size(228, 25)
        Me.DateTimePicker.TabIndex = 5
        '
        'BtnStart
        '
        Me.BtnStart.Font = New System.Drawing.Font("Times New Roman", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnStart.Location = New System.Drawing.Point(140, 40)
        Me.BtnStart.Name = "BtnStart"
        Me.BtnStart.Size = New System.Drawing.Size(111, 25)
        Me.BtnStart.TabIndex = 6
        Me.BtnStart.Text = "Start"
        Me.BtnStart.UseVisualStyleBackColor = True
        '
        'BtnStop
        '
        Me.BtnStop.Font = New System.Drawing.Font("Times New Roman", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnStop.Location = New System.Drawing.Point(257, 40)
        Me.BtnStop.Name = "BtnStop"
        Me.BtnStop.Size = New System.Drawing.Size(111, 25)
        Me.BtnStop.TabIndex = 7
        Me.BtnStop.Text = "Stop"
        Me.BtnStop.UseVisualStyleBackColor = True
        '
        'Timer
        '
        Me.Timer.Interval = 5000
        '
        'BtnRefresh
        '
        Me.BtnRefresh.Enabled = False
        Me.BtnRefresh.Font = New System.Drawing.Font("Times New Roman", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRefresh.ForeColor = System.Drawing.Color.Red
        Me.BtnRefresh.Location = New System.Drawing.Point(447, 68)
        Me.BtnRefresh.Name = "BtnRefresh"
        Me.BtnRefresh.Size = New System.Drawing.Size(111, 23)
        Me.BtnRefresh.TabIndex = 10
        Me.BtnRefresh.Text = "Refresh"
        Me.BtnRefresh.UseVisualStyleBackColor = True
        '
        'PnlUcLogHolder
        '
        Me.PnlUcLogHolder.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PnlUcLogHolder.AutoScroll = True
        Me.PnlUcLogHolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlUcLogHolder.Location = New System.Drawing.Point(11, 111)
        Me.PnlUcLogHolder.Name = "PnlUcLogHolder"
        Me.PnlUcLogHolder.Size = New System.Drawing.Size(973, 475)
        Me.PnlUcLogHolder.TabIndex = 1
        '
        'PicEnd
        '
        Me.PicEnd.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.PicEnd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PicEnd.Image = CType(resources.GetObject("PicEnd.Image"), System.Drawing.Image)
        Me.PicEnd.Location = New System.Drawing.Point(962, 3)
        Me.PicEnd.Name = "PicEnd"
        Me.PicEnd.Size = New System.Drawing.Size(22, 24)
        Me.PicEnd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicEnd.TabIndex = 12
        Me.PicEnd.TabStop = False
        '
        'PnlTop
        '
        Me.PnlTop.BackColor = System.Drawing.Color.Firebrick
        Me.PnlTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlTop.Controls.Add(Me.PicMin)
        Me.PnlTop.Controls.Add(Me.Label4)
        Me.PnlTop.Controls.Add(Me.PicEnd)
        Me.PnlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlTop.Location = New System.Drawing.Point(0, 0)
        Me.PnlTop.Name = "PnlTop"
        Me.PnlTop.Size = New System.Drawing.Size(997, 35)
        Me.PnlTop.TabIndex = 13
        '
        'PicMin
        '
        Me.PicMin.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.PicMin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PicMin.Image = CType(resources.GetObject("PicMin.Image"), System.Drawing.Image)
        Me.PicMin.Location = New System.Drawing.Point(931, 3)
        Me.PicMin.Name = "PicMin"
        Me.PicMin.Size = New System.Drawing.Size(21, 24)
        Me.PicMin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicMin.TabIndex = 15
        Me.PicMin.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(308, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(337, 22)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "TWS Online Offline Transactions Report"
        '
        'SqlConnection1
        '
        Me.SqlConnection1.ConnectionString = "Data Source=192.168.11.67;Initial Catalog=TDBServer;Persist Security Info=True;Us" & _
            "er ID=sa;Password=Biinfo878"
        Me.SqlConnection1.FireInfoMessageEventOnUserErrors = False
        '
        'PnlSetting
        '
        Me.PnlSetting.BackColor = System.Drawing.Color.White
        Me.PnlSetting.Controls.Add(Me.ChkWarning)
        Me.PnlSetting.Controls.Add(Me.Label40)
        Me.PnlSetting.Controls.Add(Me.BtnDontLogDisplay)
        Me.PnlSetting.Controls.Add(Me.ChkServerWinServiceStart)
        Me.PnlSetting.Controls.Add(Me.ChkServerWinServiceStop)
        Me.PnlSetting.Controls.Add(Me.ChkServerWinServiceGarbageTimerElapsed)
        Me.PnlSetting.Controls.Add(Me.ChkServerWinAppCreateTerminal)
        Me.PnlSetting.Controls.Add(Me.ChkClientWinReportAppPassOk)
        Me.PnlSetting.Controls.Add(Me.ChkCenterControlChangeSystemStatus)
        Me.PnlSetting.Controls.Add(Me.ChkWebMethodSetNewSystemStatus)
        Me.PnlSetting.Controls.Add(Me.ChkWebMethodGetNewSystemStatus)
        Me.PnlSetting.Controls.Add(Me.ChkClientWinReportAppTimerStart)
        Me.PnlSetting.Controls.Add(Me.ChkGetExistNobatsInOtherData)
        Me.PnlSetting.Controls.Add(Me.ChkGetSTPsTblConfigurationData)
        Me.PnlSetting.Controls.Add(Me.ChkIdentifyTerminal)
        Me.PnlSetting.Controls.Add(Me.ChkClientWinAppSettingSqlServerAdmin)
        Me.PnlSetting.Controls.Add(Me.ChkClientWinAppServiceStart)
        Me.PnlSetting.Controls.Add(Me.ChkSystemStatusChangedToExecuteNonOutputSqlCommand)
        Me.PnlSetting.Controls.Add(Me.ChkSystemStatusChangedToExecuteWithOutputSqlCommand)
        Me.PnlSetting.Controls.Add(Me.ChkWinServiceStart)
        Me.PnlSetting.Controls.Add(Me.ChkWinServiceStop)
        Me.PnlSetting.Controls.Add(Me.ChkSendCurrentStatus)
        Me.PnlSetting.Controls.Add(Me.ChkSetWinServiceSyncCounting)
        Me.PnlSetting.Controls.Add(Me.ChkSetWinServiceTimerInterval)
        Me.PnlSetting.Controls.Add(Me.ChkGetWinServiceConnectionString)
        Me.PnlSetting.Controls.Add(Me.ChkGetWinServiceTerminalId)
        Me.PnlSetting.Controls.Add(Me.ChkGetWinServiceDateTime)
        Me.PnlSetting.Controls.Add(Me.ChkGetWinServiceComputerInfo)
        Me.PnlSetting.Controls.Add(Me.Label39)
        Me.PnlSetting.Controls.Add(Me.Label38)
        Me.PnlSetting.Controls.Add(Me.Label37)
        Me.PnlSetting.Controls.Add(Me.Label36)
        Me.PnlSetting.Controls.Add(Me.Label35)
        Me.PnlSetting.Controls.Add(Me.Label34)
        Me.PnlSetting.Controls.Add(Me.Label33)
        Me.PnlSetting.Controls.Add(Me.Label32)
        Me.PnlSetting.Controls.Add(Me.Label31)
        Me.PnlSetting.Controls.Add(Me.Label30)
        Me.PnlSetting.Controls.Add(Me.Label29)
        Me.PnlSetting.Controls.Add(Me.Label28)
        Me.PnlSetting.Controls.Add(Me.Label27)
        Me.PnlSetting.Controls.Add(Me.Label26)
        Me.PnlSetting.Controls.Add(Me.Label25)
        Me.PnlSetting.Controls.Add(Me.Label24)
        Me.PnlSetting.Controls.Add(Me.Label23)
        Me.PnlSetting.Controls.Add(Me.Label22)
        Me.PnlSetting.Controls.Add(Me.Label21)
        Me.PnlSetting.Controls.Add(Me.Label20)
        Me.PnlSetting.Controls.Add(Me.Label19)
        Me.PnlSetting.Controls.Add(Me.ChkSyncAll)
        Me.PnlSetting.Controls.Add(Me.ChkAuthentication)
        Me.PnlSetting.Controls.Add(Me.ChkSystemStatusChangedToSystemClearNobatsTrucksBufferAndSilent)
        Me.PnlSetting.Controls.Add(Me.ChkSystemStatusChangedToSystemGeneral)
        Me.PnlSetting.Controls.Add(Me.ChkSystemStatusChangedToSystemFullSilent)
        Me.PnlSetting.Controls.Add(Me.ChkSystemStatusChangedToStpExistNobatSilent)
        Me.PnlSetting.Controls.Add(Me.ChkSystemStatusChangedToWinServiceSilent)
        Me.PnlSetting.Controls.Add(Me.ChkSyncTrucks)
        Me.PnlSetting.Controls.Add(Me.Label18)
        Me.PnlSetting.Controls.Add(Me.Label17)
        Me.PnlSetting.Controls.Add(Me.Label16)
        Me.PnlSetting.Controls.Add(Me.Label15)
        Me.PnlSetting.Controls.Add(Me.Label14)
        Me.PnlSetting.Controls.Add(Me.Label13)
        Me.PnlSetting.Controls.Add(Me.Label12)
        Me.PnlSetting.Controls.Add(Me.Label11)
        Me.PnlSetting.Controls.Add(Me.Label10)
        Me.PnlSetting.Controls.Add(Me.Label9)
        Me.PnlSetting.Controls.Add(Me.Label8)
        Me.PnlSetting.Controls.Add(Me.ChkErrorLog)
        Me.PnlSetting.Controls.Add(Me.Label7)
        Me.PnlSetting.Controls.Add(Me.Label6)
        Me.PnlSetting.Controls.Add(Me.Panel1)
        Me.PnlSetting.Controls.Add(Me.Label5)
        Me.PnlSetting.Controls.Add(Me.PicExitPnlSetting)
        Me.PnlSetting.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlSetting.Location = New System.Drawing.Point(0, 0)
        Me.PnlSetting.Name = "PnlSetting"
        Me.PnlSetting.Size = New System.Drawing.Size(997, 599)
        Me.PnlSetting.TabIndex = 14
        '
        'ChkWarning
        '
        Me.ChkWarning.Location = New System.Drawing.Point(524, 360)
        Me.ChkWarning.Name = "ChkWarning"
        Me.ChkWarning.Size = New System.Drawing.Size(15, 17)
        Me.ChkWarning.TabIndex = 73
        Me.ChkWarning.Text = " "
        Me.ChkWarning.UseVisualStyleBackColor = True
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(545, 361)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(47, 13)
        Me.Label40.TabIndex = 72
        Me.Label40.Text = "Warning"
        '
        'BtnDontLogDisplay
        '
        Me.BtnDontLogDisplay.Location = New System.Drawing.Point(152, 369)
        Me.BtnDontLogDisplay.Name = "BtnDontLogDisplay"
        Me.BtnDontLogDisplay.Size = New System.Drawing.Size(160, 23)
        Me.BtnDontLogDisplay.TabIndex = 71
        Me.BtnDontLogDisplay.Text = "Dont'LogDisplay"
        Me.BtnDontLogDisplay.UseVisualStyleBackColor = True
        '
        'ChkServerWinServiceStart
        '
        Me.ChkServerWinServiceStart.Location = New System.Drawing.Point(524, 297)
        Me.ChkServerWinServiceStart.Name = "ChkServerWinServiceStart"
        Me.ChkServerWinServiceStart.Size = New System.Drawing.Size(15, 17)
        Me.ChkServerWinServiceStart.TabIndex = 70
        Me.ChkServerWinServiceStart.Text = " "
        Me.ChkServerWinServiceStart.UseVisualStyleBackColor = True
        '
        'ChkServerWinServiceStop
        '
        Me.ChkServerWinServiceStop.Location = New System.Drawing.Point(524, 313)
        Me.ChkServerWinServiceStop.Name = "ChkServerWinServiceStop"
        Me.ChkServerWinServiceStop.Size = New System.Drawing.Size(15, 17)
        Me.ChkServerWinServiceStop.TabIndex = 69
        Me.ChkServerWinServiceStop.Text = " "
        Me.ChkServerWinServiceStop.UseVisualStyleBackColor = True
        '
        'ChkServerWinServiceGarbageTimerElapsed
        '
        Me.ChkServerWinServiceGarbageTimerElapsed.Location = New System.Drawing.Point(524, 329)
        Me.ChkServerWinServiceGarbageTimerElapsed.Name = "ChkServerWinServiceGarbageTimerElapsed"
        Me.ChkServerWinServiceGarbageTimerElapsed.Size = New System.Drawing.Size(15, 17)
        Me.ChkServerWinServiceGarbageTimerElapsed.TabIndex = 68
        Me.ChkServerWinServiceGarbageTimerElapsed.Text = " "
        Me.ChkServerWinServiceGarbageTimerElapsed.UseVisualStyleBackColor = True
        '
        'ChkServerWinAppCreateTerminal
        '
        Me.ChkServerWinAppCreateTerminal.Location = New System.Drawing.Point(524, 345)
        Me.ChkServerWinAppCreateTerminal.Name = "ChkServerWinAppCreateTerminal"
        Me.ChkServerWinAppCreateTerminal.Size = New System.Drawing.Size(15, 17)
        Me.ChkServerWinAppCreateTerminal.TabIndex = 67
        Me.ChkServerWinAppCreateTerminal.Text = " "
        Me.ChkServerWinAppCreateTerminal.UseVisualStyleBackColor = True
        '
        'ChkClientWinReportAppPassOk
        '
        Me.ChkClientWinReportAppPassOk.Location = New System.Drawing.Point(524, 107)
        Me.ChkClientWinReportAppPassOk.Name = "ChkClientWinReportAppPassOk"
        Me.ChkClientWinReportAppPassOk.Size = New System.Drawing.Size(15, 17)
        Me.ChkClientWinReportAppPassOk.TabIndex = 66
        Me.ChkClientWinReportAppPassOk.Text = " "
        Me.ChkClientWinReportAppPassOk.UseVisualStyleBackColor = True
        '
        'ChkCenterControlChangeSystemStatus
        '
        Me.ChkCenterControlChangeSystemStatus.Location = New System.Drawing.Point(524, 123)
        Me.ChkCenterControlChangeSystemStatus.Name = "ChkCenterControlChangeSystemStatus"
        Me.ChkCenterControlChangeSystemStatus.Size = New System.Drawing.Size(15, 17)
        Me.ChkCenterControlChangeSystemStatus.TabIndex = 65
        Me.ChkCenterControlChangeSystemStatus.Text = " "
        Me.ChkCenterControlChangeSystemStatus.UseVisualStyleBackColor = True
        '
        'ChkWebMethodSetNewSystemStatus
        '
        Me.ChkWebMethodSetNewSystemStatus.Location = New System.Drawing.Point(524, 139)
        Me.ChkWebMethodSetNewSystemStatus.Name = "ChkWebMethodSetNewSystemStatus"
        Me.ChkWebMethodSetNewSystemStatus.Size = New System.Drawing.Size(15, 17)
        Me.ChkWebMethodSetNewSystemStatus.TabIndex = 64
        Me.ChkWebMethodSetNewSystemStatus.Text = " "
        Me.ChkWebMethodSetNewSystemStatus.UseVisualStyleBackColor = True
        '
        'ChkWebMethodGetNewSystemStatus
        '
        Me.ChkWebMethodGetNewSystemStatus.Location = New System.Drawing.Point(524, 155)
        Me.ChkWebMethodGetNewSystemStatus.Name = "ChkWebMethodGetNewSystemStatus"
        Me.ChkWebMethodGetNewSystemStatus.Size = New System.Drawing.Size(15, 17)
        Me.ChkWebMethodGetNewSystemStatus.TabIndex = 63
        Me.ChkWebMethodGetNewSystemStatus.Text = " "
        Me.ChkWebMethodGetNewSystemStatus.UseVisualStyleBackColor = True
        '
        'ChkClientWinReportAppTimerStart
        '
        Me.ChkClientWinReportAppTimerStart.Location = New System.Drawing.Point(524, 92)
        Me.ChkClientWinReportAppTimerStart.Name = "ChkClientWinReportAppTimerStart"
        Me.ChkClientWinReportAppTimerStart.Size = New System.Drawing.Size(15, 17)
        Me.ChkClientWinReportAppTimerStart.TabIndex = 62
        Me.ChkClientWinReportAppTimerStart.Text = " "
        Me.ChkClientWinReportAppTimerStart.UseVisualStyleBackColor = True
        '
        'ChkGetExistNobatsInOtherData
        '
        Me.ChkGetExistNobatsInOtherData.Location = New System.Drawing.Point(524, 218)
        Me.ChkGetExistNobatsInOtherData.Name = "ChkGetExistNobatsInOtherData"
        Me.ChkGetExistNobatsInOtherData.Size = New System.Drawing.Size(15, 17)
        Me.ChkGetExistNobatsInOtherData.TabIndex = 61
        Me.ChkGetExistNobatsInOtherData.Text = " "
        Me.ChkGetExistNobatsInOtherData.UseVisualStyleBackColor = True
        '
        'ChkGetSTPsTblConfigurationData
        '
        Me.ChkGetSTPsTblConfigurationData.Location = New System.Drawing.Point(524, 234)
        Me.ChkGetSTPsTblConfigurationData.Name = "ChkGetSTPsTblConfigurationData"
        Me.ChkGetSTPsTblConfigurationData.Size = New System.Drawing.Size(15, 17)
        Me.ChkGetSTPsTblConfigurationData.TabIndex = 60
        Me.ChkGetSTPsTblConfigurationData.Text = " "
        Me.ChkGetSTPsTblConfigurationData.UseVisualStyleBackColor = True
        '
        'ChkIdentifyTerminal
        '
        Me.ChkIdentifyTerminal.Location = New System.Drawing.Point(524, 250)
        Me.ChkIdentifyTerminal.Name = "ChkIdentifyTerminal"
        Me.ChkIdentifyTerminal.Size = New System.Drawing.Size(15, 17)
        Me.ChkIdentifyTerminal.TabIndex = 59
        Me.ChkIdentifyTerminal.Text = " "
        Me.ChkIdentifyTerminal.UseVisualStyleBackColor = True
        '
        'ChkClientWinAppSettingSqlServerAdmin
        '
        Me.ChkClientWinAppSettingSqlServerAdmin.Location = New System.Drawing.Point(524, 266)
        Me.ChkClientWinAppSettingSqlServerAdmin.Name = "ChkClientWinAppSettingSqlServerAdmin"
        Me.ChkClientWinAppSettingSqlServerAdmin.Size = New System.Drawing.Size(15, 17)
        Me.ChkClientWinAppSettingSqlServerAdmin.TabIndex = 58
        Me.ChkClientWinAppSettingSqlServerAdmin.Text = " "
        Me.ChkClientWinAppSettingSqlServerAdmin.UseVisualStyleBackColor = True
        '
        'ChkClientWinAppServiceStart
        '
        Me.ChkClientWinAppServiceStart.Location = New System.Drawing.Point(524, 282)
        Me.ChkClientWinAppServiceStart.Name = "ChkClientWinAppServiceStart"
        Me.ChkClientWinAppServiceStart.Size = New System.Drawing.Size(15, 17)
        Me.ChkClientWinAppServiceStart.TabIndex = 57
        Me.ChkClientWinAppServiceStart.Text = " "
        Me.ChkClientWinAppServiceStart.UseVisualStyleBackColor = True
        '
        'ChkSystemStatusChangedToExecuteNonOutputSqlCommand
        '
        Me.ChkSystemStatusChangedToExecuteNonOutputSqlCommand.Location = New System.Drawing.Point(152, 234)
        Me.ChkSystemStatusChangedToExecuteNonOutputSqlCommand.Name = "ChkSystemStatusChangedToExecuteNonOutputSqlCommand"
        Me.ChkSystemStatusChangedToExecuteNonOutputSqlCommand.Size = New System.Drawing.Size(15, 17)
        Me.ChkSystemStatusChangedToExecuteNonOutputSqlCommand.TabIndex = 56
        Me.ChkSystemStatusChangedToExecuteNonOutputSqlCommand.Text = " "
        Me.ChkSystemStatusChangedToExecuteNonOutputSqlCommand.UseVisualStyleBackColor = True
        '
        'ChkSystemStatusChangedToExecuteWithOutputSqlCommand
        '
        Me.ChkSystemStatusChangedToExecuteWithOutputSqlCommand.Location = New System.Drawing.Point(152, 250)
        Me.ChkSystemStatusChangedToExecuteWithOutputSqlCommand.Name = "ChkSystemStatusChangedToExecuteWithOutputSqlCommand"
        Me.ChkSystemStatusChangedToExecuteWithOutputSqlCommand.Size = New System.Drawing.Size(15, 17)
        Me.ChkSystemStatusChangedToExecuteWithOutputSqlCommand.TabIndex = 55
        Me.ChkSystemStatusChangedToExecuteWithOutputSqlCommand.Text = " "
        Me.ChkSystemStatusChangedToExecuteWithOutputSqlCommand.UseVisualStyleBackColor = True
        '
        'ChkWinServiceStart
        '
        Me.ChkWinServiceStart.Location = New System.Drawing.Point(152, 266)
        Me.ChkWinServiceStart.Name = "ChkWinServiceStart"
        Me.ChkWinServiceStart.Size = New System.Drawing.Size(15, 17)
        Me.ChkWinServiceStart.TabIndex = 54
        Me.ChkWinServiceStart.Text = " "
        Me.ChkWinServiceStart.UseVisualStyleBackColor = True
        '
        'ChkWinServiceStop
        '
        Me.ChkWinServiceStop.Location = New System.Drawing.Point(152, 282)
        Me.ChkWinServiceStop.Name = "ChkWinServiceStop"
        Me.ChkWinServiceStop.Size = New System.Drawing.Size(15, 17)
        Me.ChkWinServiceStop.TabIndex = 53
        Me.ChkWinServiceStop.Text = " "
        Me.ChkWinServiceStop.UseVisualStyleBackColor = True
        '
        'ChkSendCurrentStatus
        '
        Me.ChkSendCurrentStatus.Location = New System.Drawing.Point(152, 298)
        Me.ChkSendCurrentStatus.Name = "ChkSendCurrentStatus"
        Me.ChkSendCurrentStatus.Size = New System.Drawing.Size(15, 17)
        Me.ChkSendCurrentStatus.TabIndex = 52
        Me.ChkSendCurrentStatus.Text = " "
        Me.ChkSendCurrentStatus.UseVisualStyleBackColor = True
        '
        'ChkSetWinServiceSyncCounting
        '
        Me.ChkSetWinServiceSyncCounting.Location = New System.Drawing.Point(152, 314)
        Me.ChkSetWinServiceSyncCounting.Name = "ChkSetWinServiceSyncCounting"
        Me.ChkSetWinServiceSyncCounting.Size = New System.Drawing.Size(15, 17)
        Me.ChkSetWinServiceSyncCounting.TabIndex = 51
        Me.ChkSetWinServiceSyncCounting.Text = " "
        Me.ChkSetWinServiceSyncCounting.UseVisualStyleBackColor = True
        '
        'ChkSetWinServiceTimerInterval
        '
        Me.ChkSetWinServiceTimerInterval.Location = New System.Drawing.Point(152, 330)
        Me.ChkSetWinServiceTimerInterval.Name = "ChkSetWinServiceTimerInterval"
        Me.ChkSetWinServiceTimerInterval.Size = New System.Drawing.Size(15, 17)
        Me.ChkSetWinServiceTimerInterval.TabIndex = 50
        Me.ChkSetWinServiceTimerInterval.Text = " "
        Me.ChkSetWinServiceTimerInterval.UseVisualStyleBackColor = True
        '
        'ChkGetWinServiceConnectionString
        '
        Me.ChkGetWinServiceConnectionString.Location = New System.Drawing.Point(152, 346)
        Me.ChkGetWinServiceConnectionString.Name = "ChkGetWinServiceConnectionString"
        Me.ChkGetWinServiceConnectionString.Size = New System.Drawing.Size(15, 17)
        Me.ChkGetWinServiceConnectionString.TabIndex = 49
        Me.ChkGetWinServiceConnectionString.Text = " "
        Me.ChkGetWinServiceConnectionString.UseVisualStyleBackColor = True
        '
        'ChkGetWinServiceTerminalId
        '
        Me.ChkGetWinServiceTerminalId.Location = New System.Drawing.Point(524, 171)
        Me.ChkGetWinServiceTerminalId.Name = "ChkGetWinServiceTerminalId"
        Me.ChkGetWinServiceTerminalId.Size = New System.Drawing.Size(15, 17)
        Me.ChkGetWinServiceTerminalId.TabIndex = 48
        Me.ChkGetWinServiceTerminalId.Text = " "
        Me.ChkGetWinServiceTerminalId.UseVisualStyleBackColor = True
        '
        'ChkGetWinServiceDateTime
        '
        Me.ChkGetWinServiceDateTime.Location = New System.Drawing.Point(524, 187)
        Me.ChkGetWinServiceDateTime.Name = "ChkGetWinServiceDateTime"
        Me.ChkGetWinServiceDateTime.Size = New System.Drawing.Size(15, 17)
        Me.ChkGetWinServiceDateTime.TabIndex = 47
        Me.ChkGetWinServiceDateTime.Text = " "
        Me.ChkGetWinServiceDateTime.UseVisualStyleBackColor = True
        '
        'ChkGetWinServiceComputerInfo
        '
        Me.ChkGetWinServiceComputerInfo.Location = New System.Drawing.Point(524, 203)
        Me.ChkGetWinServiceComputerInfo.Name = "ChkGetWinServiceComputerInfo"
        Me.ChkGetWinServiceComputerInfo.Size = New System.Drawing.Size(15, 17)
        Me.ChkGetWinServiceComputerInfo.TabIndex = 46
        Me.ChkGetWinServiceComputerInfo.Text = " "
        Me.ChkGetWinServiceComputerInfo.UseVisualStyleBackColor = True
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(545, 108)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(140, 13)
        Me.Label39.TabIndex = 45
        Me.Label39.Text = "ClientWinReportAppPassOk"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(545, 124)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(172, 13)
        Me.Label38.TabIndex = 44
        Me.Label38.Text = "CenterControlChangeSystemStatus"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(545, 140)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(168, 13)
        Me.Label37.TabIndex = 43
        Me.Label37.Text = "WebMethodSetNewSystemStatus"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(544, 155)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(169, 13)
        Me.Label36.TabIndex = 42
        Me.Label36.Text = "WebMethodGetNewSystemStatus"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(545, 314)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(115, 13)
        Me.Label35.TabIndex = 41
        Me.Label35.Text = "ServerWinServiceStop"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(545, 346)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(147, 13)
        Me.Label34.TabIndex = 40
        Me.Label34.Text = "ServerWinAppCreateTerminal"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(545, 330)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(198, 13)
        Me.Label33.TabIndex = 39
        Me.Label33.Text = "ServerWinServiceGarbageTimerElapsed"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(545, 92)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(151, 13)
        Me.Label32.TabIndex = 38
        Me.Label32.Text = "ClientWinReportAppTimerStart"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(545, 251)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(81, 13)
        Me.Label31.TabIndex = 37
        Me.Label31.Text = "IdentifyTerminal"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(545, 298)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(115, 13)
        Me.Label30.TabIndex = 36
        Me.Label30.Text = "ServerWinServiceStart"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(545, 283)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(129, 13)
        Me.Label29.TabIndex = 35
        Me.Label29.Text = "ClientWinAppServiceStart"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(545, 266)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(179, 13)
        Me.Label28.TabIndex = 34
        Me.Label28.Text = "ClientWinAppSettingSqlServerAdmin"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(545, 204)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(142, 13)
        Me.Label27.TabIndex = 33
        Me.Label27.Text = "GetWinServiceComputerInfo"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(545, 219)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(138, 13)
        Me.Label26.TabIndex = 32
        Me.Label26.Text = "GetExistNobatsInOtherData"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(545, 235)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(150, 13)
        Me.Label25.TabIndex = 31
        Me.Label25.Text = "GetSTPsTblConfigurationData"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(173, 298)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(96, 13)
        Me.Label24.TabIndex = 30
        Me.Label24.Text = "SendCurrentStatus"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(173, 315)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(144, 13)
        Me.Label23.TabIndex = 29
        Me.Label23.Text = "SetWinServiceSyncCounting"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(173, 331)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(139, 13)
        Me.Label22.TabIndex = 28
        Me.Label22.Text = "SetWinServiceTimerInterval"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(173, 347)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(160, 13)
        Me.Label21.TabIndex = 27
        Me.Label21.Text = "GetWinServiceConnectionString"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(545, 172)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(128, 13)
        Me.Label20.TabIndex = 26
        Me.Label20.Text = "GetWinServiceTerminalId"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(545, 188)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(125, 13)
        Me.Label19.TabIndex = 25
        Me.Label19.Text = "GetWinServiceDateTime"
        '
        'ChkSyncAll
        '
        Me.ChkSyncAll.Location = New System.Drawing.Point(152, 123)
        Me.ChkSyncAll.Name = "ChkSyncAll"
        Me.ChkSyncAll.Size = New System.Drawing.Size(15, 17)
        Me.ChkSyncAll.TabIndex = 24
        Me.ChkSyncAll.Text = " "
        Me.ChkSyncAll.UseVisualStyleBackColor = True
        '
        'ChkAuthentication
        '
        Me.ChkAuthentication.Location = New System.Drawing.Point(152, 139)
        Me.ChkAuthentication.Name = "ChkAuthentication"
        Me.ChkAuthentication.Size = New System.Drawing.Size(15, 17)
        Me.ChkAuthentication.TabIndex = 23
        Me.ChkAuthentication.Text = " "
        Me.ChkAuthentication.UseVisualStyleBackColor = True
        '
        'ChkSystemStatusChangedToSystemClearNobatsTrucksBufferAndSilent
        '
        Me.ChkSystemStatusChangedToSystemClearNobatsTrucksBufferAndSilent.Location = New System.Drawing.Point(152, 155)
        Me.ChkSystemStatusChangedToSystemClearNobatsTrucksBufferAndSilent.Name = "ChkSystemStatusChangedToSystemClearNobatsTrucksBufferAndSilent"
        Me.ChkSystemStatusChangedToSystemClearNobatsTrucksBufferAndSilent.Size = New System.Drawing.Size(15, 17)
        Me.ChkSystemStatusChangedToSystemClearNobatsTrucksBufferAndSilent.TabIndex = 22
        Me.ChkSystemStatusChangedToSystemClearNobatsTrucksBufferAndSilent.Text = " "
        Me.ChkSystemStatusChangedToSystemClearNobatsTrucksBufferAndSilent.UseVisualStyleBackColor = True
        '
        'ChkSystemStatusChangedToSystemGeneral
        '
        Me.ChkSystemStatusChangedToSystemGeneral.Location = New System.Drawing.Point(152, 171)
        Me.ChkSystemStatusChangedToSystemGeneral.Name = "ChkSystemStatusChangedToSystemGeneral"
        Me.ChkSystemStatusChangedToSystemGeneral.Size = New System.Drawing.Size(15, 17)
        Me.ChkSystemStatusChangedToSystemGeneral.TabIndex = 21
        Me.ChkSystemStatusChangedToSystemGeneral.Text = " "
        Me.ChkSystemStatusChangedToSystemGeneral.UseVisualStyleBackColor = True
        '
        'ChkSystemStatusChangedToSystemFullSilent
        '
        Me.ChkSystemStatusChangedToSystemFullSilent.Location = New System.Drawing.Point(152, 187)
        Me.ChkSystemStatusChangedToSystemFullSilent.Name = "ChkSystemStatusChangedToSystemFullSilent"
        Me.ChkSystemStatusChangedToSystemFullSilent.Size = New System.Drawing.Size(15, 17)
        Me.ChkSystemStatusChangedToSystemFullSilent.TabIndex = 20
        Me.ChkSystemStatusChangedToSystemFullSilent.Text = " "
        Me.ChkSystemStatusChangedToSystemFullSilent.UseVisualStyleBackColor = True
        '
        'ChkSystemStatusChangedToStpExistNobatSilent
        '
        Me.ChkSystemStatusChangedToStpExistNobatSilent.Location = New System.Drawing.Point(152, 203)
        Me.ChkSystemStatusChangedToStpExistNobatSilent.Name = "ChkSystemStatusChangedToStpExistNobatSilent"
        Me.ChkSystemStatusChangedToStpExistNobatSilent.Size = New System.Drawing.Size(15, 17)
        Me.ChkSystemStatusChangedToStpExistNobatSilent.TabIndex = 19
        Me.ChkSystemStatusChangedToStpExistNobatSilent.Text = " "
        Me.ChkSystemStatusChangedToStpExistNobatSilent.UseVisualStyleBackColor = True
        '
        'ChkSystemStatusChangedToWinServiceSilent
        '
        Me.ChkSystemStatusChangedToWinServiceSilent.Location = New System.Drawing.Point(152, 219)
        Me.ChkSystemStatusChangedToWinServiceSilent.Name = "ChkSystemStatusChangedToWinServiceSilent"
        Me.ChkSystemStatusChangedToWinServiceSilent.Size = New System.Drawing.Size(15, 17)
        Me.ChkSystemStatusChangedToWinServiceSilent.TabIndex = 18
        Me.ChkSystemStatusChangedToWinServiceSilent.Text = " "
        Me.ChkSystemStatusChangedToWinServiceSilent.UseVisualStyleBackColor = True
        '
        'ChkSyncTrucks
        '
        Me.ChkSyncTrucks.Location = New System.Drawing.Point(152, 107)
        Me.ChkSyncTrucks.Name = "ChkSyncTrucks"
        Me.ChkSyncTrucks.Size = New System.Drawing.Size(15, 17)
        Me.ChkSyncTrucks.TabIndex = 17
        Me.ChkSyncTrucks.Text = " "
        Me.ChkSyncTrucks.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(173, 124)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(42, 13)
        Me.Label18.TabIndex = 16
        Me.Label18.Text = "SyncAll"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(173, 139)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(75, 13)
        Me.Label17.TabIndex = 15
        Me.Label17.Text = "Authentication"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(173, 156)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(325, 13)
        Me.Label16.TabIndex = 14
        Me.Label16.Text = "SystemStatusChangedToSystemClearNobatsTrucksBufferAndSilent"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(173, 172)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(198, 13)
        Me.Label15.TabIndex = 13
        Me.Label15.Text = "SystemStatusChangedToSystemGeneral"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(173, 188)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(203, 13)
        Me.Label14.TabIndex = 12
        Me.Label14.Text = "SystemStatusChangedToSystemFullSilent"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(173, 204)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(220, 13)
        Me.Label13.TabIndex = 11
        Me.Label13.Text = "SystemStatusChangedToStpExistNobatSilent"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(173, 220)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(208, 13)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "SystemStatusChangedToWinServiceSilent"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(173, 236)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(280, 13)
        Me.Label11.TabIndex = 9
        Me.Label11.Text = "SystemStatusChangedToExecuteNonOutputSqlCommand"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(173, 252)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(282, 13)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "SystemStatusChangedToExecuteWithOutputSqlCommand"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(173, 268)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(84, 13)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "WinServiceStart"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(173, 283)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(84, 13)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "WinServiceStop"
        '
        'ChkErrorLog
        '
        Me.ChkErrorLog.Location = New System.Drawing.Point(152, 91)
        Me.ChkErrorLog.Name = "ChkErrorLog"
        Me.ChkErrorLog.Size = New System.Drawing.Size(15, 17)
        Me.ChkErrorLog.TabIndex = 5
        Me.ChkErrorLog.Text = " "
        Me.ChkErrorLog.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(173, 109)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 13)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "SyncTrucks"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(173, 92)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "ErrorLog"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.Firebrick
        Me.Panel1.Location = New System.Drawing.Point(-10, 49)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1007, 36)
        Me.Panel1.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 92)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "LogID To Dont'Display :"
        '
        'PicExitPnlSetting
        '
        Me.PicExitPnlSetting.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PicExitPnlSetting.Image = CType(resources.GetObject("PicExitPnlSetting.Image"), System.Drawing.Image)
        Me.PicExitPnlSetting.Location = New System.Drawing.Point(12, 16)
        Me.PicExitPnlSetting.Name = "PicExitPnlSetting"
        Me.PicExitPnlSetting.Size = New System.Drawing.Size(56, 18)
        Me.PicExitPnlSetting.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicExitPnlSetting.TabIndex = 0
        Me.PicExitPnlSetting.TabStop = False
        '
        'PnlMain
        '
        Me.PnlMain.BackColor = System.Drawing.Color.White
        Me.PnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlMain.Controls.Add(Me.Label41)
        Me.PnlMain.Controls.Add(Me.BtnSetting)
        Me.PnlMain.Controls.Add(Me.BtnStart)
        Me.PnlMain.Controls.Add(Me.Label1)
        Me.PnlMain.Controls.Add(Me.Label2)
        Me.PnlMain.Controls.Add(Me.BtnRefresh)
        Me.PnlMain.Controls.Add(Me.BtnStop)
        Me.PnlMain.Controls.Add(Me.OpbOnline)
        Me.PnlMain.Controls.Add(Me.OpbOffLine)
        Me.PnlMain.Controls.Add(Me.DateTimePicker)
        Me.PnlMain.Controls.Add(Me.Label3)
        Me.PnlMain.Controls.Add(Me.LblLogTotal)
        Me.PnlMain.Controls.Add(Me.PnlUcLogHolder)
        Me.PnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlMain.Location = New System.Drawing.Point(0, 0)
        Me.PnlMain.Name = "PnlMain"
        Me.PnlMain.Padding = New System.Windows.Forms.Padding(5)
        Me.PnlMain.Size = New System.Drawing.Size(997, 599)
        Me.PnlMain.TabIndex = 16
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Times New Roman", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(571, 68)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(149, 22)
        Me.Label41.TabIndex = 12
        Me.Label41.Text = "Number of Logs :"
        '
        'BtnSetting
        '
        Me.BtnSetting.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSetting.ForeColor = System.Drawing.Color.Black
        Me.BtnSetting.Location = New System.Drawing.Point(873, 66)
        Me.BtnSetting.Name = "BtnSetting"
        Me.BtnSetting.Size = New System.Drawing.Size(111, 23)
        Me.BtnSetting.TabIndex = 11
        Me.BtnSetting.Text = "Setting"
        Me.BtnSetting.UseVisualStyleBackColor = True
        '
        'LblLogTotal
        '
        Me.LblLogTotal.AutoSize = True
        Me.LblLogTotal.Font = New System.Drawing.Font("Times New Roman", 20.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLogTotal.Location = New System.Drawing.Point(729, 64)
        Me.LblLogTotal.Name = "LblLogTotal"
        Me.LblLogTotal.Size = New System.Drawing.Size(30, 31)
        Me.LblLogTotal.TabIndex = 13
        Me.LblLogTotal.Text = "0"
        '
        'FrmReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LavenderBlush
        Me.ClientSize = New System.Drawing.Size(997, 599)
        Me.ControlBox = False
        Me.Controls.Add(Me.PnlTop)
        Me.Controls.Add(Me.PnlMain)
        Me.Controls.Add(Me.PnlSetting)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmReport"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TWSReport"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PicEnd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlTop.ResumeLayout(False)
        Me.PnlTop.PerformLayout()
        CType(Me.PicMin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlSetting.ResumeLayout(False)
        Me.PnlSetting.PerformLayout()
        CType(Me.PicExitPnlSetting, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlMain.ResumeLayout(False)
        Me.PnlMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OpbOnline As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents OpbOffLine As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnStart As System.Windows.Forms.Button
    Friend WithEvents BtnStop As System.Windows.Forms.Button
    Friend WithEvents Timer As System.Windows.Forms.Timer
    Friend WithEvents BtnRefresh As System.Windows.Forms.Button
    Friend WithEvents PnlUcLogHolder As System.Windows.Forms.Panel
    Friend WithEvents PicEnd As System.Windows.Forms.PictureBox
    Friend WithEvents PnlTop As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PicMin As System.Windows.Forms.PictureBox
    Friend WithEvents SqlConnection1 As System.Data.SqlClient.SqlConnection
    Friend WithEvents PnlSetting As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PicExitPnlSetting As System.Windows.Forms.PictureBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents PnlMain As System.Windows.Forms.Panel
    Friend WithEvents ChkErrorLog As System.Windows.Forms.CheckBox
    Friend WithEvents ChkSyncAll As System.Windows.Forms.CheckBox
    Friend WithEvents ChkAuthentication As System.Windows.Forms.CheckBox
    Friend WithEvents ChkSystemStatusChangedToSystemClearNobatsTrucksBufferAndSilent As System.Windows.Forms.CheckBox
    Friend WithEvents ChkSystemStatusChangedToSystemGeneral As System.Windows.Forms.CheckBox
    Friend WithEvents ChkSystemStatusChangedToSystemFullSilent As System.Windows.Forms.CheckBox
    Friend WithEvents ChkSystemStatusChangedToStpExistNobatSilent As System.Windows.Forms.CheckBox
    Friend WithEvents ChkSystemStatusChangedToWinServiceSilent As System.Windows.Forms.CheckBox
    Friend WithEvents ChkSyncTrucks As System.Windows.Forms.CheckBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents ChkServerWinServiceStart As System.Windows.Forms.CheckBox
    Friend WithEvents ChkServerWinServiceStop As System.Windows.Forms.CheckBox
    Friend WithEvents ChkServerWinServiceGarbageTimerElapsed As System.Windows.Forms.CheckBox
    Friend WithEvents ChkServerWinAppCreateTerminal As System.Windows.Forms.CheckBox
    Friend WithEvents ChkClientWinReportAppPassOk As System.Windows.Forms.CheckBox
    Friend WithEvents ChkCenterControlChangeSystemStatus As System.Windows.Forms.CheckBox
    Friend WithEvents ChkWebMethodSetNewSystemStatus As System.Windows.Forms.CheckBox
    Friend WithEvents ChkWebMethodGetNewSystemStatus As System.Windows.Forms.CheckBox
    Friend WithEvents ChkClientWinReportAppTimerStart As System.Windows.Forms.CheckBox
    Friend WithEvents ChkGetExistNobatsInOtherData As System.Windows.Forms.CheckBox
    Friend WithEvents ChkGetSTPsTblConfigurationData As System.Windows.Forms.CheckBox
    Friend WithEvents ChkIdentifyTerminal As System.Windows.Forms.CheckBox
    Friend WithEvents ChkClientWinAppSettingSqlServerAdmin As System.Windows.Forms.CheckBox
    Friend WithEvents ChkClientWinAppServiceStart As System.Windows.Forms.CheckBox
    Friend WithEvents ChkSystemStatusChangedToExecuteNonOutputSqlCommand As System.Windows.Forms.CheckBox
    Friend WithEvents ChkSystemStatusChangedToExecuteWithOutputSqlCommand As System.Windows.Forms.CheckBox
    Friend WithEvents ChkWinServiceStart As System.Windows.Forms.CheckBox
    Friend WithEvents ChkWinServiceStop As System.Windows.Forms.CheckBox
    Friend WithEvents ChkSendCurrentStatus As System.Windows.Forms.CheckBox
    Friend WithEvents ChkSetWinServiceSyncCounting As System.Windows.Forms.CheckBox
    Friend WithEvents ChkSetWinServiceTimerInterval As System.Windows.Forms.CheckBox
    Friend WithEvents ChkGetWinServiceConnectionString As System.Windows.Forms.CheckBox
    Friend WithEvents ChkGetWinServiceTerminalId As System.Windows.Forms.CheckBox
    Friend WithEvents ChkGetWinServiceDateTime As System.Windows.Forms.CheckBox
    Friend WithEvents ChkGetWinServiceComputerInfo As System.Windows.Forms.CheckBox
    Friend WithEvents BtnDontLogDisplay As System.Windows.Forms.Button
    Friend WithEvents BtnSetting As System.Windows.Forms.Button
    Friend WithEvents ChkWarning As System.Windows.Forms.CheckBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents LblLogTotal As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
End Class
