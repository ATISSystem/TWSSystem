<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TWSApp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TWSApp))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnIdentify = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtServerName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtAdminName = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtAdminPass = New System.Windows.Forms.TextBox()
        Me.BtnSetD = New System.Windows.Forms.Button()
        Me.SqlConnection = New System.Data.SqlClient.SqlConnection()
        Me.LblError = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.BtnStartService = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtTimerInterval = New System.Windows.Forms.TextBox()
        Me.BtnSetTimerInterval = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtSyncCounting = New System.Windows.Forms.TextBox()
        Me.BtnSetSyncCounting = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(35, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Indentify Service :"
        '
        'BtnIdentify
        '
        Me.BtnIdentify.Location = New System.Drawing.Point(147, 16)
        Me.BtnIdentify.Name = "BtnIdentify"
        Me.BtnIdentify.Size = New System.Drawing.Size(138, 23)
        Me.BtnIdentify.TabIndex = 1
        Me.BtnIdentify.Text = "Identify"
        Me.BtnIdentify.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(35, 127)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Set Database :"
        '
        'TxtServerName
        '
        Me.TxtServerName.Location = New System.Drawing.Point(147, 143)
        Me.TxtServerName.Name = "TxtServerName"
        Me.TxtServerName.Size = New System.Drawing.Size(138, 20)
        Me.TxtServerName.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(144, 127)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Server"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(144, 166)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "AdminUserName"
        '
        'TxtAdminName
        '
        Me.TxtAdminName.Location = New System.Drawing.Point(147, 182)
        Me.TxtAdminName.Name = "TxtAdminName"
        Me.TxtAdminName.Size = New System.Drawing.Size(138, 20)
        Me.TxtAdminName.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(144, 204)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "AdminUserPass"
        '
        'TxtAdminPass
        '
        Me.TxtAdminPass.Location = New System.Drawing.Point(147, 220)
        Me.TxtAdminPass.Name = "TxtAdminPass"
        Me.TxtAdminPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtAdminPass.Size = New System.Drawing.Size(138, 20)
        Me.TxtAdminPass.TabIndex = 9
        '
        'BtnSetD
        '
        Me.BtnSetD.Location = New System.Drawing.Point(291, 218)
        Me.BtnSetD.Name = "BtnSetD"
        Me.BtnSetD.Size = New System.Drawing.Size(83, 23)
        Me.BtnSetD.TabIndex = 12
        Me.BtnSetD.Text = "Set"
        Me.BtnSetD.UseVisualStyleBackColor = True
        '
        'SqlConnection
        '
        Me.SqlConnection.ConnectionString = "Data Source=46.143.202.19\sql2008r2;Initial Catalog=TDBClient;Persist Security In" & _
            "fo=True;User ID=sa;Password=Biinfo878"
        Me.SqlConnection.FireInfoMessageEventOnUserErrors = False
        '
        'LblError
        '
        Me.LblError.ForeColor = System.Drawing.Color.Red
        Me.LblError.Location = New System.Drawing.Point(35, 290)
        Me.LblError.Name = "LblError"
        Me.LblError.Size = New System.Drawing.Size(339, 84)
        Me.LblError.TabIndex = 13
        Me.LblError.Text = " "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(35, 266)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Start Service"
        '
        'BtnStartService
        '
        Me.BtnStartService.ForeColor = System.Drawing.Color.Red
        Me.BtnStartService.Location = New System.Drawing.Point(147, 261)
        Me.BtnStartService.Name = "BtnStartService"
        Me.BtnStartService.Size = New System.Drawing.Size(83, 23)
        Me.BtnStartService.TabIndex = 15
        Me.BtnStartService.Text = "Start"
        Me.BtnStartService.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(35, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "TimerInterval :"
        '
        'TxtTimerInterval
        '
        Me.TxtTimerInterval.Location = New System.Drawing.Point(147, 68)
        Me.TxtTimerInterval.Name = "TxtTimerInterval"
        Me.TxtTimerInterval.Size = New System.Drawing.Size(138, 20)
        Me.TxtTimerInterval.TabIndex = 17
        Me.TxtTimerInterval.Text = "60000"
        Me.TxtTimerInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BtnSetTimerInterval
        '
        Me.BtnSetTimerInterval.Location = New System.Drawing.Point(291, 66)
        Me.BtnSetTimerInterval.Name = "BtnSetTimerInterval"
        Me.BtnSetTimerInterval.Size = New System.Drawing.Size(83, 23)
        Me.BtnSetTimerInterval.TabIndex = 18
        Me.BtnSetTimerInterval.Text = "Set"
        Me.BtnSetTimerInterval.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(35, 97)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(79, 13)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "SyncCounting :"
        '
        'TxtSyncCounting
        '
        Me.TxtSyncCounting.Location = New System.Drawing.Point(147, 94)
        Me.TxtSyncCounting.Name = "TxtSyncCounting"
        Me.TxtSyncCounting.Size = New System.Drawing.Size(138, 20)
        Me.TxtSyncCounting.TabIndex = 20
        Me.TxtSyncCounting.Text = "5"
        Me.TxtSyncCounting.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BtnSetSyncCounting
        '
        Me.BtnSetSyncCounting.Location = New System.Drawing.Point(291, 92)
        Me.BtnSetSyncCounting.Name = "BtnSetSyncCounting"
        Me.BtnSetSyncCounting.Size = New System.Drawing.Size(83, 23)
        Me.BtnSetSyncCounting.TabIndex = 21
        Me.BtnSetSyncCounting.Text = "Set"
        Me.BtnSetSyncCounting.UseVisualStyleBackColor = True
        '
        'TWSApp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(406, 408)
        Me.Controls.Add(Me.BtnSetSyncCounting)
        Me.Controls.Add(Me.TxtSyncCounting)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.BtnSetTimerInterval)
        Me.Controls.Add(Me.TxtTimerInterval)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BtnStartService)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.LblError)
        Me.Controls.Add(Me.BtnSetD)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtAdminPass)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtAdminName)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtServerName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BtnIdentify)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "TWSApp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TWSApp-Admin Setting"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnIdentify As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtServerName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtAdminName As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtAdminPass As System.Windows.Forms.TextBox
    Friend WithEvents BtnSetD As System.Windows.Forms.Button
    Friend WithEvents SqlConnection As System.Data.SqlClient.SqlConnection
    Friend WithEvents LblError As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents BtnStartService As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtTimerInterval As System.Windows.Forms.TextBox
    Friend WithEvents BtnSetTimerInterval As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtSyncCounting As System.Windows.Forms.TextBox
    Friend WithEvents BtnSetSyncCounting As System.Windows.Forms.Button

End Class
