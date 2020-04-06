<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form17
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Hide()
        Form1.Show()
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form17))
        Dim ListViewGroup1 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Internet", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup2 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Fixed disk", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup3 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Removable disk", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Local disk (C:)", 0)
        Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Local disk (D:)", 1)
        Dim ListViewItem3 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Local disk (E:)", 1)
        Dim ListViewItem4 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Removable disk (F:)", 2)
        Dim ListViewItem5 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Unable", 3)
        Me.RefreshButton = New System.Windows.Forms.Button()
        Me.Unconnected = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MainIcon = New System.Windows.Forms.PictureBox()
        Me.Icon1 = New System.Windows.Forms.PictureBox()
        Me.Icon2 = New System.Windows.Forms.PictureBox()
        Me.Icon3 = New System.Windows.Forms.PictureBox()
        Me.Programs = New System.Windows.Forms.ImageList(Me.components)
        Me.FileListView = New System.Windows.Forms.ListView()
        Me.ProgramIcons = New System.Windows.Forms.ImageList(Me.components)
        Me.icon4 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.unlock_ = New System.Windows.Forms.Button()
        Me.exit_ = New System.Windows.Forms.Button()
        Me.password_circle = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.exit2 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.realpath = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.examtip = New System.Windows.Forms.Label()
        Me.examback = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.exambutton1 = New System.Windows.Forms.Button()
        Me.exambutton2 = New System.Windows.Forms.Button()
        Me.examtext2 = New System.Windows.Forms.TextBox()
        Me.examtext1 = New System.Windows.Forms.TextBox()
        Me.exam2 = New System.Windows.Forms.Label()
        Me.exam1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        CType(Me.Unconnected, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MainIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Icon1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Icon2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Icon3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.icon4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RefreshButton
        '
        Me.RefreshButton.Font = New System.Drawing.Font("微软雅黑", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.RefreshButton.Location = New System.Drawing.Point(237, 406)
        Me.RefreshButton.Name = "RefreshButton"
        Me.RefreshButton.Size = New System.Drawing.Size(200, 50)
        Me.RefreshButton.TabIndex = 0
        Me.RefreshButton.Text = "Refresh"
        Me.RefreshButton.UseVisualStyleBackColor = True
        Me.RefreshButton.Visible = False
        '
        'Unconnected
        '
        Me.Unconnected.Image = CType(resources.GetObject("Unconnected.Image"), System.Drawing.Image)
        Me.Unconnected.Location = New System.Drawing.Point(12, 12)
        Me.Unconnected.Name = "Unconnected"
        Me.Unconnected.Size = New System.Drawing.Size(658, 388)
        Me.Unconnected.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Unconnected.TabIndex = 2
        Me.Unconnected.TabStop = False
        Me.Unconnected.Visible = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("宋体", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 512)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(682, 41)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Date: 411/01/01"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'MainIcon
        '
        Me.MainIcon.Image = CType(resources.GetObject("MainIcon.Image"), System.Drawing.Image)
        Me.MainIcon.Location = New System.Drawing.Point(0, 0)
        Me.MainIcon.Name = "MainIcon"
        Me.MainIcon.Size = New System.Drawing.Size(258, 53)
        Me.MainIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.MainIcon.TabIndex = 4
        Me.MainIcon.TabStop = False
        '
        'Icon1
        '
        Me.Icon1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Icon1.Image = CType(resources.GetObject("Icon1.Image"), System.Drawing.Image)
        Me.Icon1.Location = New System.Drawing.Point(0, 512)
        Me.Icon1.Name = "Icon1"
        Me.Icon1.Size = New System.Drawing.Size(41, 41)
        Me.Icon1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Icon1.TabIndex = 5
        Me.Icon1.TabStop = False
        '
        'Icon2
        '
        Me.Icon2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Icon2.Image = CType(resources.GetObject("Icon2.Image"), System.Drawing.Image)
        Me.Icon2.Location = New System.Drawing.Point(47, 512)
        Me.Icon2.Name = "Icon2"
        Me.Icon2.Size = New System.Drawing.Size(41, 41)
        Me.Icon2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Icon2.TabIndex = 6
        Me.Icon2.TabStop = False
        '
        'Icon3
        '
        Me.Icon3.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Icon3.Image = CType(resources.GetObject("Icon3.Image"), System.Drawing.Image)
        Me.Icon3.Location = New System.Drawing.Point(94, 512)
        Me.Icon3.Name = "Icon3"
        Me.Icon3.Size = New System.Drawing.Size(41, 41)
        Me.Icon3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Icon3.TabIndex = 7
        Me.Icon3.TabStop = False
        '
        'Programs
        '
        Me.Programs.ImageStream = CType(resources.GetObject("Programs.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Programs.TransparentColor = System.Drawing.Color.Transparent
        Me.Programs.Images.SetKeyName(0, "Internet explorer.jpg")
        Me.Programs.Images.SetKeyName(1, "Windows explorer.jpg")
        '
        'FileListView
        '
        Me.FileListView.Font = New System.Drawing.Font("微软雅黑", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        ListViewGroup1.Header = "Internet"
        ListViewGroup1.Name = "Group1"
        ListViewGroup2.Header = "Fixed disk"
        ListViewGroup2.Name = "Group2"
        ListViewGroup3.Header = "Removable disk"
        ListViewGroup3.Name = "Group3"
        Me.FileListView.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup1, ListViewGroup2, ListViewGroup3})
        ListViewItem1.Group = ListViewGroup2
        ListViewItem2.Group = ListViewGroup2
        ListViewItem3.Group = ListViewGroup2
        ListViewItem4.Group = ListViewGroup3
        ListViewItem5.Group = ListViewGroup1
        Me.FileListView.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1, ListViewItem2, ListViewItem3, ListViewItem4, ListViewItem5})
        Me.FileListView.Location = New System.Drawing.Point(12, 59)
        Me.FileListView.MultiSelect = False
        Me.FileListView.Name = "FileListView"
        Me.FileListView.Size = New System.Drawing.Size(658, 447)
        Me.FileListView.SmallImageList = Me.ProgramIcons
        Me.FileListView.TabIndex = 10
        Me.FileListView.UseCompatibleStateImageBehavior = False
        Me.FileListView.View = System.Windows.Forms.View.SmallIcon
        Me.FileListView.Visible = False
        '
        'ProgramIcons
        '
        Me.ProgramIcons.ImageStream = CType(resources.GetObject("ProgramIcons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ProgramIcons.TransparentColor = System.Drawing.Color.Transparent
        Me.ProgramIcons.Images.SetKeyName(0, "Hard_disk_gold_xp_128px_511356_easyicon.net.png")
        Me.ProgramIcons.Images.SetKeyName(1, "Hard_disk_gold_128px_511355_easyicon.net.png")
        Me.ProgramIcons.Images.SetKeyName(2, "Sandisk_Cruzer_Micro_Black_Alt_USB_512px_1121998_easyicon.net.png")
        Me.ProgramIcons.Images.SetKeyName(3, "stock_disconnect_128px_1078469_easyicon.net.png")
        Me.ProgramIcons.Images.SetKeyName(4, "connect_creating_128px_33305_easyicon.net.png")
        Me.ProgramIcons.Images.SetKeyName(5, "Go_back_512px_1186174_easyicon.net.png")
        Me.ProgramIcons.Images.SetKeyName(6, "folder_process_128px_535738_easyicon.net.png")
        Me.ProgramIcons.Images.SetKeyName(7, "folder_128px_535739_easyicon.net.png")
        Me.ProgramIcons.Images.SetKeyName(8, "Picture_128px_543891_easyicon.net.png")
        Me.ProgramIcons.Images.SetKeyName(9, "page_128px_535768_easyicon.net.png")
        Me.ProgramIcons.Images.SetKeyName(10, "word_128px_523083_easyicon.net.png")
        '
        'icon4
        '
        Me.icon4.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.icon4.Image = CType(resources.GetObject("icon4.Image"), System.Drawing.Image)
        Me.icon4.Location = New System.Drawing.Point(141, 512)
        Me.icon4.Name = "icon4"
        Me.icon4.Size = New System.Drawing.Size(41, 41)
        Me.icon4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.icon4.TabIndex = 11
        Me.icon4.TabStop = False
        Me.icon4.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.unlock_)
        Me.GroupBox1.Controls.Add(Me.exit_)
        Me.GroupBox1.Controls.Add(Me.password_circle)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("微软雅黑", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(135, 33)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Locked"
        Me.GroupBox1.Visible = False
        '
        'unlock_
        '
        Me.unlock_.Location = New System.Drawing.Point(148, 154)
        Me.unlock_.Name = "unlock_"
        Me.unlock_.Size = New System.Drawing.Size(170, 40)
        Me.unlock_.TabIndex = 3
        Me.unlock_.Text = "Unlock"
        Me.unlock_.UseVisualStyleBackColor = True
        '
        'exit_
        '
        Me.exit_.Location = New System.Drawing.Point(324, 154)
        Me.exit_.Name = "exit_"
        Me.exit_.Size = New System.Drawing.Size(170, 40)
        Me.exit_.TabIndex = 2
        Me.exit_.Text = "Exit"
        Me.exit_.UseVisualStyleBackColor = True
        '
        'password_circle
        '
        Me.password_circle.Location = New System.Drawing.Point(83, 71)
        Me.password_circle.MaxLength = 10
        Me.password_circle.Name = "password_circle"
        Me.password_circle.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.password_circle.Size = New System.Drawing.Size(411, 40)
        Me.password_circle.TabIndex = 1
        Me.password_circle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(289, 32)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Please enter password:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.PictureBox1)
        Me.GroupBox2.Controls.Add(Me.exit2)
        Me.GroupBox2.Controls.Add(Me.TextBox1)
        Me.GroupBox2.Font = New System.Drawing.Font("微软雅黑", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(141, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(154, 36)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "E:\truth in my thought.txt"
        Me.GroupBox2.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(7, 56)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(645, 339)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'exit2
        '
        Me.exit2.Location = New System.Drawing.Point(482, 401)
        Me.exit2.Name = "exit2"
        Me.exit2.Size = New System.Drawing.Size(170, 40)
        Me.exit2.TabIndex = 3
        Me.exit2.Text = "Exit"
        Me.exit2.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.White
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Location = New System.Drawing.Point(6, 39)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox1.Size = New System.Drawing.Size(646, 356)
        Me.TextBox1.TabIndex = 0
        '
        'realpath
        '
        Me.realpath.Font = New System.Drawing.Font("微软雅黑", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.realpath.Location = New System.Drawing.Point(301, 12)
        Me.realpath.Name = "realpath"
        Me.realpath.Size = New System.Drawing.Size(369, 27)
        Me.realpath.TabIndex = 14
        Me.realpath.Text = "C:\Windows"
        Me.realpath.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.examtip)
        Me.GroupBox3.Controls.Add(Me.examback)
        Me.GroupBox3.Controls.Add(Me.PictureBox2)
        Me.GroupBox3.Controls.Add(Me.exambutton1)
        Me.GroupBox3.Controls.Add(Me.exambutton2)
        Me.GroupBox3.Controls.Add(Me.examtext2)
        Me.GroupBox3.Controls.Add(Me.examtext1)
        Me.GroupBox3.Controls.Add(Me.exam2)
        Me.GroupBox3.Controls.Add(Me.exam1)
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.TextBox2)
        Me.GroupBox3.Font = New System.Drawing.Font("微软雅黑", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(12, 59)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(658, 447)
        Me.GroupBox3.TabIndex = 13
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Internet connected"
        Me.GroupBox3.Visible = False
        '
        'examtip
        '
        Me.examtip.BackColor = System.Drawing.Color.Yellow
        Me.examtip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.examtip.Location = New System.Drawing.Point(6, 82)
        Me.examtip.Name = "examtip"
        Me.examtip.Size = New System.Drawing.Size(646, 40)
        Me.examtip.TabIndex = 11
        Me.examtip.Text = "The password is incorrect. You have 5 turns left."
        Me.examtip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.examtip.Visible = False
        '
        'examback
        '
        Me.examback.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.examback.Location = New System.Drawing.Point(508, 415)
        Me.examback.Name = "examback"
        Me.examback.Size = New System.Drawing.Size(150, 35)
        Me.examback.TabIndex = 10
        Me.examback.Text = "返回(back)"
        Me.examback.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(0, 85)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(658, 362)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 9
        Me.PictureBox2.TabStop = False
        '
        'exambutton1
        '
        Me.exambutton1.Location = New System.Drawing.Point(156, 333)
        Me.exambutton1.Name = "exambutton1"
        Me.exambutton1.Size = New System.Drawing.Size(150, 72)
        Me.exambutton1.TabIndex = 8
        Me.exambutton1.Text = "注册" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(register)"
        Me.exambutton1.UseVisualStyleBackColor = True
        '
        'exambutton2
        '
        Me.exambutton2.Location = New System.Drawing.Point(330, 333)
        Me.exambutton2.Name = "exambutton2"
        Me.exambutton2.Size = New System.Drawing.Size(150, 72)
        Me.exambutton2.TabIndex = 7
        Me.exambutton2.Text = "登录" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(login)"
        Me.exambutton2.UseVisualStyleBackColor = True
        '
        'examtext2
        '
        Me.examtext2.Location = New System.Drawing.Point(277, 251)
        Me.examtext2.MaxLength = 13
        Me.examtext2.Name = "examtext2"
        Me.examtext2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.examtext2.Size = New System.Drawing.Size(219, 40)
        Me.examtext2.TabIndex = 6
        '
        'examtext1
        '
        Me.examtext1.Location = New System.Drawing.Point(277, 188)
        Me.examtext1.MaxLength = 7
        Me.examtext1.Name = "examtext1"
        Me.examtext1.Size = New System.Drawing.Size(219, 40)
        Me.examtext1.TabIndex = 5
        '
        'exam2
        '
        Me.exam2.AutoSize = True
        Me.exam2.Location = New System.Drawing.Point(123, 175)
        Me.exam2.Name = "exam2"
        Me.exam2.Size = New System.Drawing.Size(148, 128)
        Me.exam2.TabIndex = 4
        Me.exam2.Text = "用户名：" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(username)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "密码：" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(password)"
        '
        'exam1
        '
        Me.exam1.AutoSize = True
        Me.exam1.Location = New System.Drawing.Point(210, 122)
        Me.exam1.Name = "exam1"
        Me.exam1.Size = New System.Drawing.Size(215, 32)
        Me.exam1.TabIndex = 3
        Me.exam1.Text = "考试数据分析系统"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(502, 39)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(150, 40)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Go!"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 32)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "URL:"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(81, 39)
        Me.TextBox2.MaxLength = 40
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(415, 40)
        Me.TextBox2.TabIndex = 0
        Me.TextBox2.Text = "103.2.135.464:8080"
        '
        'Form17
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(682, 553)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.realpath)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.icon4)
        Me.Controls.Add(Me.FileListView)
        Me.Controls.Add(Me.Icon3)
        Me.Controls.Add(Me.Icon2)
        Me.Controls.Add(Me.Icon1)
        Me.Controls.Add(Me.MainIcon)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Unconnected)
        Me.Controls.Add(Me.RefreshButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form17"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Screen display"
        CType(Me.Unconnected, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MainIcon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Icon1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Icon2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Icon3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.icon4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents RefreshButton As Button
    Friend WithEvents Unconnected As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents MainIcon As PictureBox
    Friend WithEvents Icon1 As PictureBox
    Friend WithEvents Icon2 As PictureBox
    Friend WithEvents Icon3 As PictureBox
    Friend WithEvents Programs As ImageList
    Friend WithEvents FileListView As ListView
    Friend WithEvents ProgramIcons As ImageList
    Friend WithEvents icon4 As PictureBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents unlock_ As Button
    Friend WithEvents exit_ As Button
    Friend WithEvents password_circle As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents exit2 As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents realpath As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents exam2 As Label
    Friend WithEvents exam1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents exambutton2 As Button
    Friend WithEvents examtext2 As TextBox
    Friend WithEvents examtext1 As TextBox
    Friend WithEvents exambutton1 As Button
    Friend WithEvents examback As Button
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents examtip As Label
End Class
