<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCenterControl
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboTerminals = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtCommandAndValue = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.OpbSystemGeneral = New System.Windows.Forms.RadioButton()
        Me.BtnSubmit = New System.Windows.Forms.Button()
        Me.OpbSystemClearNobatsTrucksBufferAndSilent = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.OpbSystemFullSilent = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.OpbWinServiceSilent = New System.Windows.Forms.RadioButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.OpbStpExistNobatSilent = New System.Windows.Forms.RadioButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.OpbExecuteNonOutputSqlCommand = New System.Windows.Forms.RadioButton()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.OpbExecuteWithOutputSqlCommand = New System.Windows.Forms.RadioButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.OpbSendCurrentStatus = New System.Windows.Forms.RadioButton()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.OpbSetWinServiceTimerInterval = New System.Windows.Forms.RadioButton()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.OpbSetWinServiceSyncCounting = New System.Windows.Forms.RadioButton()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.OpbGetWinServiceConnectionString = New System.Windows.Forms.RadioButton()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.OpbGetWinServiceTerminalId = New System.Windows.Forms.RadioButton()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.OpbGetWinServiceDateTime = New System.Windows.Forms.RadioButton()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.OpbGetWinServiceComputerInfo = New System.Windows.Forms.RadioButton()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.OpbGetExistNobatsInOtherData = New System.Windows.Forms.RadioButton()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.OpbGetSTPsTblConfigurationData = New System.Windows.Forms.RadioButton()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.BtnGetCurrentSystemStatus = New System.Windows.Forms.Button()
        Me.ChkAllTerminals = New System.Windows.Forms.CheckBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.BtnSetSyncChangedTrucks = New System.Windows.Forms.Button()
        Me.SqlConnection1 = New System.Data.SqlClient.SqlConnection()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(53, 165)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "SystemGeneral "
        '
        'ComboTerminals
        '
        Me.ComboTerminals.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.ComboTerminals.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ComboTerminals.FormattingEnabled = True
        Me.ComboTerminals.Location = New System.Drawing.Point(377, 58)
        Me.ComboTerminals.Name = "ComboTerminals"
        Me.ComboTerminals.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ComboTerminals.Size = New System.Drawing.Size(269, 24)
        Me.ComboTerminals.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Zar", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(652, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label2.Size = New System.Drawing.Size(71, 30)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "ترمينال :"
        '
        'TxtCommandAndValue
        '
        Me.TxtCommandAndValue.Location = New System.Drawing.Point(33, 90)
        Me.TxtCommandAndValue.Multiline = True
        Me.TxtCommandAndValue.Name = "TxtCommandAndValue"
        Me.TxtCommandAndValue.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtCommandAndValue.Size = New System.Drawing.Size(613, 50)
        Me.TxtCommandAndValue.TabIndex = 3
        Me.TxtCommandAndValue.Text = "Select * from tbltrucks"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Zar", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(652, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label3.Size = New System.Drawing.Size(90, 26)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "داده ارسالي :"
        '
        'OpbSystemGeneral
        '
        Me.OpbSystemGeneral.Checked = True
        Me.OpbSystemGeneral.Location = New System.Drawing.Point(33, 160)
        Me.OpbSystemGeneral.Name = "OpbSystemGeneral"
        Me.OpbSystemGeneral.Size = New System.Drawing.Size(18, 26)
        Me.OpbSystemGeneral.TabIndex = 5
        Me.OpbSystemGeneral.TabStop = True
        Me.OpbSystemGeneral.Text = " "
        Me.OpbSystemGeneral.UseVisualStyleBackColor = True
        '
        'BtnSubmit
        '
        Me.BtnSubmit.Font = New System.Drawing.Font("Times New Roman", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSubmit.Location = New System.Drawing.Point(30, 560)
        Me.BtnSubmit.Name = "BtnSubmit"
        Me.BtnSubmit.Size = New System.Drawing.Size(159, 29)
        Me.BtnSubmit.TabIndex = 6
        Me.BtnSubmit.Text = "SubMit"
        Me.BtnSubmit.UseVisualStyleBackColor = True
        '
        'OpbSystemClearNobatsTrucksBufferAndSilent
        '
        Me.OpbSystemClearNobatsTrucksBufferAndSilent.Location = New System.Drawing.Point(33, 186)
        Me.OpbSystemClearNobatsTrucksBufferAndSilent.Name = "OpbSystemClearNobatsTrucksBufferAndSilent"
        Me.OpbSystemClearNobatsTrucksBufferAndSilent.Size = New System.Drawing.Size(18, 26)
        Me.OpbSystemClearNobatsTrucksBufferAndSilent.TabIndex = 8
        Me.OpbSystemClearNobatsTrucksBufferAndSilent.Text = " "
        Me.OpbSystemClearNobatsTrucksBufferAndSilent.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(53, 191)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(244, 16)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "SystemClearNobatsTrucksBufferAndSilent"
        '
        'OpbSystemFullSilent
        '
        Me.OpbSystemFullSilent.Location = New System.Drawing.Point(33, 212)
        Me.OpbSystemFullSilent.Name = "OpbSystemFullSilent"
        Me.OpbSystemFullSilent.Size = New System.Drawing.Size(18, 26)
        Me.OpbSystemFullSilent.TabIndex = 10
        Me.OpbSystemFullSilent.Text = " "
        Me.OpbSystemFullSilent.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(53, 216)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 16)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "SystemFullSilent"
        '
        'OpbWinServiceSilent
        '
        Me.OpbWinServiceSilent.Location = New System.Drawing.Point(33, 238)
        Me.OpbWinServiceSilent.Name = "OpbWinServiceSilent"
        Me.OpbWinServiceSilent.Size = New System.Drawing.Size(18, 26)
        Me.OpbWinServiceSilent.TabIndex = 12
        Me.OpbWinServiceSilent.Text = " "
        Me.OpbWinServiceSilent.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(53, 242)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(103, 16)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "WinServiceSilent"
        '
        'OpbStpExistNobatSilent
        '
        Me.OpbStpExistNobatSilent.Location = New System.Drawing.Point(33, 264)
        Me.OpbStpExistNobatSilent.Name = "OpbStpExistNobatSilent"
        Me.OpbStpExistNobatSilent.Size = New System.Drawing.Size(18, 26)
        Me.OpbStpExistNobatSilent.TabIndex = 14
        Me.OpbStpExistNobatSilent.Text = " "
        Me.OpbStpExistNobatSilent.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(53, 268)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(121, 16)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "StpExistNobatSilent"
        '
        'OpbExecuteNonOutputSqlCommand
        '
        Me.OpbExecuteNonOutputSqlCommand.Location = New System.Drawing.Point(33, 290)
        Me.OpbExecuteNonOutputSqlCommand.Name = "OpbExecuteNonOutputSqlCommand"
        Me.OpbExecuteNonOutputSqlCommand.Size = New System.Drawing.Size(18, 26)
        Me.OpbExecuteNonOutputSqlCommand.TabIndex = 16
        Me.OpbExecuteNonOutputSqlCommand.Text = " "
        Me.OpbExecuteNonOutputSqlCommand.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(53, 294)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(189, 16)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "ExecuteNonOutputSqlCommand"
        '
        'OpbExecuteWithOutputSqlCommand
        '
        Me.OpbExecuteWithOutputSqlCommand.Location = New System.Drawing.Point(33, 316)
        Me.OpbExecuteWithOutputSqlCommand.Name = "OpbExecuteWithOutputSqlCommand"
        Me.OpbExecuteWithOutputSqlCommand.Size = New System.Drawing.Size(18, 26)
        Me.OpbExecuteWithOutputSqlCommand.TabIndex = 18
        Me.OpbExecuteWithOutputSqlCommand.Text = " "
        Me.OpbExecuteWithOutputSqlCommand.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(53, 320)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(193, 16)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "ExecuteWithOutputSqlCommand"
        '
        'OpbSendCurrentStatus
        '
        Me.OpbSendCurrentStatus.Location = New System.Drawing.Point(33, 341)
        Me.OpbSendCurrentStatus.Name = "OpbSendCurrentStatus"
        Me.OpbSendCurrentStatus.Size = New System.Drawing.Size(18, 26)
        Me.OpbSendCurrentStatus.TabIndex = 20
        Me.OpbSendCurrentStatus.Text = " "
        Me.OpbSendCurrentStatus.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(53, 346)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(112, 16)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "SendCurrentStatus"
        '
        'OpbSetWinServiceTimerInterval
        '
        Me.OpbSetWinServiceTimerInterval.Location = New System.Drawing.Point(33, 367)
        Me.OpbSetWinServiceTimerInterval.Name = "OpbSetWinServiceTimerInterval"
        Me.OpbSetWinServiceTimerInterval.Size = New System.Drawing.Size(18, 26)
        Me.OpbSetWinServiceTimerInterval.TabIndex = 22
        Me.OpbSetWinServiceTimerInterval.Text = " "
        Me.OpbSetWinServiceTimerInterval.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Times New Roman", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(53, 372)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(165, 16)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "SetWinServiceTimerInterval"
        '
        'OpbSetWinServiceSyncCounting
        '
        Me.OpbSetWinServiceSyncCounting.Location = New System.Drawing.Point(33, 393)
        Me.OpbSetWinServiceSyncCounting.Name = "OpbSetWinServiceSyncCounting"
        Me.OpbSetWinServiceSyncCounting.Size = New System.Drawing.Size(18, 26)
        Me.OpbSetWinServiceSyncCounting.TabIndex = 24
        Me.OpbSetWinServiceSyncCounting.Text = " "
        Me.OpbSetWinServiceSyncCounting.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Times New Roman", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(53, 397)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(166, 16)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "SetWinServiceSyncCounting"
        '
        'OpbGetWinServiceConnectionString
        '
        Me.OpbGetWinServiceConnectionString.Location = New System.Drawing.Point(33, 419)
        Me.OpbGetWinServiceConnectionString.Name = "OpbGetWinServiceConnectionString"
        Me.OpbGetWinServiceConnectionString.Size = New System.Drawing.Size(18, 26)
        Me.OpbGetWinServiceConnectionString.TabIndex = 26
        Me.OpbGetWinServiceConnectionString.Text = " "
        Me.OpbGetWinServiceConnectionString.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Times New Roman", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(53, 423)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(188, 16)
        Me.Label13.TabIndex = 25
        Me.Label13.Text = "GetWinServiceConnectionString"
        '
        'OpbGetWinServiceTerminalId
        '
        Me.OpbGetWinServiceTerminalId.Location = New System.Drawing.Point(33, 445)
        Me.OpbGetWinServiceTerminalId.Name = "OpbGetWinServiceTerminalId"
        Me.OpbGetWinServiceTerminalId.Size = New System.Drawing.Size(18, 26)
        Me.OpbGetWinServiceTerminalId.TabIndex = 28
        Me.OpbGetWinServiceTerminalId.Text = " "
        Me.OpbGetWinServiceTerminalId.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Times New Roman", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(53, 449)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(152, 16)
        Me.Label14.TabIndex = 27
        Me.Label14.Text = "GetWinServiceTerminalId"
        '
        'OpbGetWinServiceDateTime
        '
        Me.OpbGetWinServiceDateTime.Location = New System.Drawing.Point(33, 471)
        Me.OpbGetWinServiceDateTime.Name = "OpbGetWinServiceDateTime"
        Me.OpbGetWinServiceDateTime.Size = New System.Drawing.Size(18, 26)
        Me.OpbGetWinServiceDateTime.TabIndex = 30
        Me.OpbGetWinServiceDateTime.Text = " "
        Me.OpbGetWinServiceDateTime.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Times New Roman", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(53, 475)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(144, 16)
        Me.Label15.TabIndex = 29
        Me.Label15.Text = "GetWinServiceDateTime"
        '
        'OpbGetWinServiceComputerInfo
        '
        Me.OpbGetWinServiceComputerInfo.Location = New System.Drawing.Point(33, 496)
        Me.OpbGetWinServiceComputerInfo.Name = "OpbGetWinServiceComputerInfo"
        Me.OpbGetWinServiceComputerInfo.Size = New System.Drawing.Size(18, 26)
        Me.OpbGetWinServiceComputerInfo.TabIndex = 32
        Me.OpbGetWinServiceComputerInfo.Text = " "
        Me.OpbGetWinServiceComputerInfo.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Times New Roman", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(53, 501)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(168, 16)
        Me.Label16.TabIndex = 31
        Me.Label16.Text = "GetWinServiceComputerInfo"
        '
        'OpbGetExistNobatsInOtherData
        '
        Me.OpbGetExistNobatsInOtherData.Location = New System.Drawing.Point(399, 160)
        Me.OpbGetExistNobatsInOtherData.Name = "OpbGetExistNobatsInOtherData"
        Me.OpbGetExistNobatsInOtherData.Size = New System.Drawing.Size(18, 26)
        Me.OpbGetExistNobatsInOtherData.TabIndex = 34
        Me.OpbGetExistNobatsInOtherData.Text = " "
        Me.OpbGetExistNobatsInOtherData.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Times New Roman", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(419, 165)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(261, 16)
        Me.Label17.TabIndex = 33
        Me.Label17.Text = "GetExistNobatsInOtherData(Need Command)"
        '
        'OpbGetSTPsTblConfigurationData
        '
        Me.OpbGetSTPsTblConfigurationData.Location = New System.Drawing.Point(399, 186)
        Me.OpbGetSTPsTblConfigurationData.Name = "OpbGetSTPsTblConfigurationData"
        Me.OpbGetSTPsTblConfigurationData.Size = New System.Drawing.Size(18, 26)
        Me.OpbGetSTPsTblConfigurationData.TabIndex = 36
        Me.OpbGetSTPsTblConfigurationData.Text = " "
        Me.OpbGetSTPsTblConfigurationData.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Times New Roman", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(419, 190)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(276, 16)
        Me.Label18.TabIndex = 35
        Me.Label18.Text = "GetSTPsTblConfigurationData(Need Command)"
        '
        'BtnGetCurrentSystemStatus
        '
        Me.BtnGetCurrentSystemStatus.Font = New System.Drawing.Font("Times New Roman", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGetCurrentSystemStatus.Location = New System.Drawing.Point(436, 560)
        Me.BtnGetCurrentSystemStatus.Name = "BtnGetCurrentSystemStatus"
        Me.BtnGetCurrentSystemStatus.Size = New System.Drawing.Size(244, 29)
        Me.BtnGetCurrentSystemStatus.TabIndex = 37
        Me.BtnGetCurrentSystemStatus.Text = "ViewCurrentSystemStatus"
        Me.BtnGetCurrentSystemStatus.UseVisualStyleBackColor = True
        '
        'ChkAllTerminals
        '
        Me.ChkAllTerminals.Checked = True
        Me.ChkAllTerminals.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkAllTerminals.Location = New System.Drawing.Point(629, 26)
        Me.ChkAllTerminals.Name = "ChkAllTerminals"
        Me.ChkAllTerminals.Size = New System.Drawing.Size(17, 26)
        Me.ChkAllTerminals.TabIndex = 38
        Me.ChkAllTerminals.Text = " "
        Me.ChkAllTerminals.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Zar", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Red
        Me.Label19.Location = New System.Drawing.Point(463, 22)
        Me.Label19.Name = "Label19"
        Me.Label19.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label19.Size = New System.Drawing.Size(160, 30)
        Me.Label19.TabIndex = 39
        Me.Label19.Text = "فرمان فراگير يا پخشي"
        '
        'BtnSetSyncChangedTrucks
        '
        Me.BtnSetSyncChangedTrucks.Font = New System.Drawing.Font("Times New Roman", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSetSyncChangedTrucks.ForeColor = System.Drawing.Color.Red
        Me.BtnSetSyncChangedTrucks.Location = New System.Drawing.Point(436, 524)
        Me.BtnSetSyncChangedTrucks.Name = "BtnSetSyncChangedTrucks"
        Me.BtnSetSyncChangedTrucks.Size = New System.Drawing.Size(244, 29)
        Me.BtnSetSyncChangedTrucks.TabIndex = 40
        Me.BtnSetSyncChangedTrucks.Text = "SetSyncChangedTrucks"
        Me.BtnSetSyncChangedTrucks.UseVisualStyleBackColor = True
        '
        'SqlConnection1
        '
        Me.SqlConnection1.ConnectionString = "Data Source=192.168.11.64\sql2008r2;Initial Catalog=TDBServer;Persist Security In" & _
            "fo=True;User ID=sa;Password=Biinfo878"
        Me.SqlConnection1.FireInfoMessageEventOnUserErrors = False
        '
        'FrmCenterControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(765, 631)
        Me.Controls.Add(Me.BtnSetSyncChangedTrucks)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.ChkAllTerminals)
        Me.Controls.Add(Me.BtnGetCurrentSystemStatus)
        Me.Controls.Add(Me.OpbGetSTPsTblConfigurationData)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.OpbGetExistNobatsInOtherData)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.OpbGetWinServiceComputerInfo)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.OpbGetWinServiceDateTime)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.OpbGetWinServiceTerminalId)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.OpbGetWinServiceConnectionString)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.OpbSetWinServiceSyncCounting)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.OpbSetWinServiceTimerInterval)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.OpbSendCurrentStatus)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.OpbExecuteWithOutputSqlCommand)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.OpbExecuteNonOutputSqlCommand)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.OpbStpExistNobatSilent)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.OpbWinServiceSilent)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.OpbSystemFullSilent)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.OpbSystemClearNobatsTrucksBufferAndSilent)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.BtnSubmit)
        Me.Controls.Add(Me.OpbSystemGeneral)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtCommandAndValue)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ComboTerminals)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Times New Roman", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FrmCenterControl"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmCenterControl"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboTerminals As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtCommandAndValue As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents OpbSystemGeneral As System.Windows.Forms.RadioButton
    Friend WithEvents BtnSubmit As System.Windows.Forms.Button
    Friend WithEvents OpbSystemClearNobatsTrucksBufferAndSilent As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents OpbSystemFullSilent As System.Windows.Forms.RadioButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents OpbWinServiceSilent As System.Windows.Forms.RadioButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents OpbStpExistNobatSilent As System.Windows.Forms.RadioButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents OpbExecuteNonOutputSqlCommand As System.Windows.Forms.RadioButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents OpbExecuteWithOutputSqlCommand As System.Windows.Forms.RadioButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents OpbSendCurrentStatus As System.Windows.Forms.RadioButton
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents OpbSetWinServiceTimerInterval As System.Windows.Forms.RadioButton
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents OpbSetWinServiceSyncCounting As System.Windows.Forms.RadioButton
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents OpbGetWinServiceConnectionString As System.Windows.Forms.RadioButton
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents OpbGetWinServiceTerminalId As System.Windows.Forms.RadioButton
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents OpbGetWinServiceDateTime As System.Windows.Forms.RadioButton
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents OpbGetWinServiceComputerInfo As System.Windows.Forms.RadioButton
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents OpbGetExistNobatsInOtherData As System.Windows.Forms.RadioButton
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents OpbGetSTPsTblConfigurationData As System.Windows.Forms.RadioButton
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents BtnGetCurrentSystemStatus As System.Windows.Forms.Button
    Friend WithEvents ChkAllTerminals As System.Windows.Forms.CheckBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents BtnSetSyncChangedTrucks As System.Windows.Forms.Button
    Friend WithEvents SqlConnection1 As System.Data.SqlClient.SqlConnection
End Class
