<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form20
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If MsgBox("Exit the program?", vbYesNo, "Exit") = vbYesNo Then
            End
        End If
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form20))
        Dim ListViewGroup1 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Foremost mission", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup2 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Important mission", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup3 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Normal mission", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Find the identity of Scathach.", 1)
        Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Catch the turkey", 0)
        Me.scene = New System.Windows.Forms.PictureBox()
        Me.itemlist = New System.Windows.Forms.GroupBox()
        Me.item5 = New System.Windows.Forms.PictureBox()
        Me.leftmove = New System.Windows.Forms.Button()
        Me.rightmove = New System.Windows.Forms.Button()
        Me.right_ = New System.Windows.Forms.Button()
        Me.item4 = New System.Windows.Forms.PictureBox()
        Me.item3 = New System.Windows.Forms.PictureBox()
        Me.item2 = New System.Windows.Forms.PictureBox()
        Me.item1 = New System.Windows.Forms.PictureBox()
        Me.left_ = New System.Windows.Forms.Button()
        Me.item0 = New System.Windows.Forms.PictureBox()
        Me.mission_report = New System.Windows.Forms.GroupBox()
        Me.mission_report_next = New System.Windows.Forms.Button()
        Me.mission_text = New System.Windows.Forms.Label()
        Me.blackbar1 = New System.Windows.Forms.Label()
        Me.mission_name = New System.Windows.Forms.Label()
        Me.mission_top = New System.Windows.Forms.Label()
        Me.blackbar0 = New System.Windows.Forms.Label()
        Me.mission_box = New System.Windows.Forms.GroupBox()
        Me.mission_back = New System.Windows.Forms.Button()
        Me.mission = New System.Windows.Forms.ListView()
        Me.mission_icon = New System.Windows.Forms.ImageList(Me.components)
        Me.item_image = New System.Windows.Forms.ImageList(Me.components)
        Me.MoveItem = New System.Windows.Forms.Timer(Me.components)
        Me.Move_mission_report = New System.Windows.Forms.Timer(Me.components)
        Me.Move_missions = New System.Windows.Forms.Timer(Me.components)
        Me.SceneWeaver = New System.Windows.Forms.Timer(Me.components)
        Me.deletetip = New System.Windows.Forms.Timer(Me.components)
        Me.cutscenes = New System.Windows.Forms.Timer(Me.components)
        Me.scene_icon = New System.Windows.Forms.ImageList(Me.components)
        Me.scanner = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.message_box = New System.Windows.Forms.GroupBox()
        Me.message_clicker = New System.Windows.Forms.LinkLabel()
        Me.message = New System.Windows.Forms.Label()
        Me.MessageWeaver = New System.Windows.Forms.Timer(Me.components)
        Me.deadrooster = New System.Windows.Forms.GroupBox()
        Me.deadrooster_off = New System.Windows.Forms.Button()
        Me.battle_land = New System.Windows.Forms.GroupBox()
        Me.laser = New System.Windows.Forms.Label()
        Me.frontbar2 = New System.Windows.Forms.Label()
        Me.backbar2 = New System.Windows.Forms.Label()
        Me.life2 = New System.Windows.Forms.Label()
        Me.effect2 = New System.Windows.Forms.PictureBox()
        Me.frontbar1 = New System.Windows.Forms.Label()
        Me.backbar1 = New System.Windows.Forms.Label()
        Me.life1 = New System.Windows.Forms.Label()
        Me.effect1 = New System.Windows.Forms.PictureBox()
        Me.battler2 = New System.Windows.Forms.PictureBox()
        Me.battler1 = New System.Windows.Forms.PictureBox()
        Me.LifeWeaver = New System.Windows.Forms.Timer(Me.components)
        CType(Me.scene, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.itemlist.SuspendLayout()
        CType(Me.item5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.item4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.item3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.item2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.item1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.item0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mission_report.SuspendLayout()
        Me.mission_box.SuspendLayout()
        Me.message_box.SuspendLayout()
        Me.deadrooster.SuspendLayout()
        Me.battle_land.SuspendLayout()
        CType(Me.effect2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.effect1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.battler2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.battler1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'scene
        '
        Me.scene.Image = CType(resources.GetObject("scene.Image"), System.Drawing.Image)
        Me.scene.Location = New System.Drawing.Point(0, 0)
        Me.scene.Name = "scene"
        Me.scene.Size = New System.Drawing.Size(900, 600)
        Me.scene.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.scene.TabIndex = 0
        Me.scene.TabStop = False
        Me.scene.Tag = "0"
        '
        'itemlist
        '
        Me.itemlist.Controls.Add(Me.item5)
        Me.itemlist.Controls.Add(Me.leftmove)
        Me.itemlist.Controls.Add(Me.rightmove)
        Me.itemlist.Controls.Add(Me.right_)
        Me.itemlist.Controls.Add(Me.item4)
        Me.itemlist.Controls.Add(Me.item3)
        Me.itemlist.Controls.Add(Me.item2)
        Me.itemlist.Controls.Add(Me.item1)
        Me.itemlist.Controls.Add(Me.left_)
        Me.itemlist.Controls.Add(Me.item0)
        Me.itemlist.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.itemlist.Location = New System.Drawing.Point(0, 600)
        Me.itemlist.Name = "itemlist"
        Me.itemlist.Size = New System.Drawing.Size(900, 167)
        Me.itemlist.TabIndex = 167
        Me.itemlist.TabStop = False
        Me.itemlist.Text = "Item List"
        '
        'item5
        '
        Me.item5.BackColor = System.Drawing.Color.White
        Me.item5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.item5.Location = New System.Drawing.Point(721, 33)
        Me.item5.Name = "item5"
        Me.item5.Size = New System.Drawing.Size(128, 128)
        Me.item5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.item5.TabIndex = 9
        Me.item5.TabStop = False
        Me.item5.Tag = "Null"
        '
        'leftmove
        '
        Me.leftmove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.leftmove.Location = New System.Drawing.Point(685, 0)
        Me.leftmove.Name = "leftmove"
        Me.leftmove.Size = New System.Drawing.Size(33, 33)
        Me.leftmove.TabIndex = 8
        Me.leftmove.Text = "←"
        Me.leftmove.UseVisualStyleBackColor = True
        Me.leftmove.Visible = False
        '
        'rightmove
        '
        Me.rightmove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rightmove.Location = New System.Drawing.Point(717, 0)
        Me.rightmove.Name = "rightmove"
        Me.rightmove.Size = New System.Drawing.Size(33, 33)
        Me.rightmove.TabIndex = 7
        Me.rightmove.Text = "→"
        Me.rightmove.UseVisualStyleBackColor = True
        Me.rightmove.Visible = False
        '
        'right_
        '
        Me.right_.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.right_.Location = New System.Drawing.Point(855, 33)
        Me.right_.Name = "right_"
        Me.right_.Size = New System.Drawing.Size(33, 128)
        Me.right_.TabIndex = 6
        Me.right_.Text = "→"
        Me.right_.UseVisualStyleBackColor = True
        '
        'item4
        '
        Me.item4.BackColor = System.Drawing.Color.White
        Me.item4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.item4.Location = New System.Drawing.Point(587, 33)
        Me.item4.Name = "item4"
        Me.item4.Size = New System.Drawing.Size(128, 128)
        Me.item4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.item4.TabIndex = 5
        Me.item4.TabStop = False
        Me.item4.Tag = "Null"
        '
        'item3
        '
        Me.item3.BackColor = System.Drawing.Color.White
        Me.item3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.item3.Location = New System.Drawing.Point(453, 33)
        Me.item3.Name = "item3"
        Me.item3.Size = New System.Drawing.Size(128, 128)
        Me.item3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.item3.TabIndex = 4
        Me.item3.TabStop = False
        Me.item3.Tag = "Null"
        '
        'item2
        '
        Me.item2.BackColor = System.Drawing.Color.White
        Me.item2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.item2.Location = New System.Drawing.Point(319, 33)
        Me.item2.Name = "item2"
        Me.item2.Size = New System.Drawing.Size(128, 128)
        Me.item2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.item2.TabIndex = 3
        Me.item2.TabStop = False
        Me.item2.Tag = "Null"
        '
        'item1
        '
        Me.item1.BackColor = System.Drawing.Color.White
        Me.item1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.item1.Location = New System.Drawing.Point(185, 33)
        Me.item1.Name = "item1"
        Me.item1.Size = New System.Drawing.Size(128, 128)
        Me.item1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.item1.TabIndex = 2
        Me.item1.TabStop = False
        Me.item1.Tag = "Null"
        '
        'left_
        '
        Me.left_.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.left_.Location = New System.Drawing.Point(12, 33)
        Me.left_.Name = "left_"
        Me.left_.Size = New System.Drawing.Size(33, 128)
        Me.left_.TabIndex = 1
        Me.left_.Text = "←"
        Me.left_.UseVisualStyleBackColor = True
        '
        'item0
        '
        Me.item0.BackColor = System.Drawing.Color.White
        Me.item0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.item0.Location = New System.Drawing.Point(51, 33)
        Me.item0.Name = "item0"
        Me.item0.Size = New System.Drawing.Size(128, 128)
        Me.item0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.item0.TabIndex = 0
        Me.item0.TabStop = False
        Me.item0.Tag = "Null"
        '
        'mission_report
        '
        Me.mission_report.Controls.Add(Me.mission_report_next)
        Me.mission_report.Controls.Add(Me.mission_text)
        Me.mission_report.Controls.Add(Me.blackbar1)
        Me.mission_report.Controls.Add(Me.mission_name)
        Me.mission_report.Controls.Add(Me.mission_top)
        Me.mission_report.Controls.Add(Me.blackbar0)
        Me.mission_report.Font = New System.Drawing.Font("宋体", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.mission_report.Location = New System.Drawing.Point(0, 0)
        Me.mission_report.Name = "mission_report"
        Me.mission_report.Size = New System.Drawing.Size(20, 20)
        Me.mission_report.TabIndex = 168
        Me.mission_report.TabStop = False
        Me.mission_report.Text = "Mission report"
        '
        'mission_report_next
        '
        Me.mission_report_next.Location = New System.Drawing.Point(194, 264)
        Me.mission_report_next.Name = "mission_report_next"
        Me.mission_report_next.Size = New System.Drawing.Size(100, 30)
        Me.mission_report_next.TabIndex = 174
        Me.mission_report_next.Text = "Next"
        Me.mission_report_next.UseVisualStyleBackColor = True
        '
        'mission_text
        '
        Me.mission_text.Font = New System.Drawing.Font("宋体", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.mission_text.Location = New System.Drawing.Point(12, 124)
        Me.mission_text.Name = "mission_text"
        Me.mission_text.Size = New System.Drawing.Size(282, 137)
        Me.mission_text.TabIndex = 172
        Me.mission_text.Text = "Catch the turkey and put the turkey into the nest."
        '
        'blackbar1
        '
        Me.blackbar1.BackColor = System.Drawing.Color.Black
        Me.blackbar1.Location = New System.Drawing.Point(6, 114)
        Me.blackbar1.Name = "blackbar1"
        Me.blackbar1.Size = New System.Drawing.Size(288, 10)
        Me.blackbar1.TabIndex = 171
        '
        'mission_name
        '
        Me.mission_name.Font = New System.Drawing.Font("宋体", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.mission_name.Location = New System.Drawing.Point(12, 64)
        Me.mission_name.Name = "mission_name"
        Me.mission_name.Size = New System.Drawing.Size(282, 50)
        Me.mission_name.TabIndex = 170
        Me.mission_name.Text = "Catch the turkey"
        '
        'mission_top
        '
        Me.mission_top.Font = New System.Drawing.Font("宋体", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.mission_top.Location = New System.Drawing.Point(12, 24)
        Me.mission_top.Name = "mission_top"
        Me.mission_top.Size = New System.Drawing.Size(282, 30)
        Me.mission_top.TabIndex = 169
        Me.mission_top.Text = "New mission"
        '
        'blackbar0
        '
        Me.blackbar0.BackColor = System.Drawing.Color.Black
        Me.blackbar0.Location = New System.Drawing.Point(6, 54)
        Me.blackbar0.Name = "blackbar0"
        Me.blackbar0.Size = New System.Drawing.Size(288, 10)
        Me.blackbar0.TabIndex = 169
        '
        'mission_box
        '
        Me.mission_box.Controls.Add(Me.mission_back)
        Me.mission_box.Controls.Add(Me.mission)
        Me.mission_box.Font = New System.Drawing.Font("宋体", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.mission_box.Location = New System.Drawing.Point(20, 0)
        Me.mission_box.Name = "mission_box"
        Me.mission_box.Size = New System.Drawing.Size(25, 20)
        Me.mission_box.TabIndex = 173
        Me.mission_box.TabStop = False
        Me.mission_box.Text = "Missions"
        Me.mission_box.Visible = False
        '
        'mission_back
        '
        Me.mission_back.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.mission_back.Location = New System.Drawing.Point(6, 27)
        Me.mission_back.Name = "mission_back"
        Me.mission_back.Size = New System.Drawing.Size(20, 367)
        Me.mission_back.TabIndex = 1
        Me.mission_back.Text = "→"
        Me.mission_back.UseVisualStyleBackColor = True
        '
        'mission
        '
        ListViewGroup1.Header = "Foremost mission"
        ListViewGroup1.Name = "ListViewGroup1"
        ListViewGroup2.Header = "Important mission"
        ListViewGroup2.Name = "ListViewGroup2"
        ListViewGroup3.Header = "Normal mission"
        ListViewGroup3.Name = "ListViewGroup3"
        Me.mission.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup1, ListViewGroup2, ListViewGroup3})
        ListViewItem1.Group = ListViewGroup3
        ListViewItem2.Group = ListViewGroup1
        Me.mission.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1, ListViewItem2})
        Me.mission.LargeImageList = Me.mission_icon
        Me.mission.Location = New System.Drawing.Point(32, 27)
        Me.mission.Name = "mission"
        Me.mission.Size = New System.Drawing.Size(262, 367)
        Me.mission.TabIndex = 0
        Me.mission.TileSize = New System.Drawing.Size(194, 48)
        Me.mission.UseCompatibleStateImageBehavior = False
        Me.mission.View = System.Windows.Forms.View.Tile
        '
        'mission_icon
        '
        Me.mission_icon.ImageStream = CType(resources.GetObject("mission_icon.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.mission_icon.TransparentColor = System.Drawing.Color.Transparent
        Me.mission_icon.Images.SetKeyName(0, "Checkbox_Empty_32px_1097531_easyicon.net.png")
        Me.mission_icon.Images.SetKeyName(1, "Checkbox_Full_32px_1097532_easyicon.net.png")
        '
        'item_image
        '
        Me.item_image.ImageStream = CType(resources.GetObject("item_image.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.item_image.TransparentColor = System.Drawing.Color.Transparent
        Me.item_image.Images.SetKeyName(0, "secret_book_128px_522288_easyicon.net.png")
        Me.item_image.Images.SetKeyName(1, "media_tape_256px_541496_easyicon.net.png")
        Me.item_image.Images.SetKeyName(2, "Cheese_256px_1064521_easyicon.net.png")
        '
        'MoveItem
        '
        Me.MoveItem.Interval = 15
        '
        'Move_mission_report
        '
        Me.Move_mission_report.Interval = 25
        Me.Move_mission_report.Tag = "0"
        '
        'Move_missions
        '
        Me.Move_missions.Interval = 25
        Me.Move_missions.Tag = "0"
        '
        'SceneWeaver
        '
        Me.SceneWeaver.Interval = 10
        '
        'deletetip
        '
        Me.deletetip.Interval = 10
        '
        'cutscenes
        '
        Me.cutscenes.Interval = 50
        '
        'scene_icon
        '
        Me.scene_icon.ImageStream = CType(resources.GetObject("scene_icon.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.scene_icon.TransparentColor = System.Drawing.Color.Transparent
        Me.scene_icon.Images.SetKeyName(0, "Right_Green_arrow_256px_580030_easyicon.net.png")
        Me.scene_icon.Images.SetKeyName(1, "Right_Green_arrow_256px_580030_easyicon.net - 副本.png")
        Me.scene_icon.Images.SetKeyName(2, "Right_Green_arrow_256px_580030_easyicon.net - 副本 (2).png")
        Me.scene_icon.Images.SetKeyName(3, "Right_Green_arrow_256px_580030_easyicon.net - 副本 (3).png")
        Me.scene_icon.Images.SetKeyName(4, "Error_32px_1134460_easyicon.net.png")
        Me.scene_icon.Images.SetKeyName(5, "Lock_32px_1134504_easyicon.net.png")
        Me.scene_icon.Images.SetKeyName(6, "radio_128px_1135127_easyicon.net.png")
        Me.scene_icon.Images.SetKeyName(7, "timg.png")
        Me.scene_icon.Images.SetKeyName(8, "285_162673_a78ecdbe8a88742.png")
        Me.scene_icon.Images.SetKeyName(9, "smoke_explosion_512px_1102038_easyicon.net.png")
        Me.scene_icon.Images.SetKeyName(10, "explosion_512px_1101500_easyicon.net.png")
        '
        'scanner
        '
        Me.scanner.Location = New System.Drawing.Point(679, 380)
        Me.scanner.Name = "scanner"
        Me.scanner.Size = New System.Drawing.Size(36, 36)
        Me.scanner.TabIndex = 174
        Me.scanner.Visible = False
        '
        'message_box
        '
        Me.message_box.BackColor = System.Drawing.Color.White
        Me.message_box.Controls.Add(Me.message_clicker)
        Me.message_box.Controls.Add(Me.message)
        Me.message_box.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.message_box.Location = New System.Drawing.Point(0, 600)
        Me.message_box.Name = "message_box"
        Me.message_box.Size = New System.Drawing.Size(900, 167)
        Me.message_box.TabIndex = 168
        Me.message_box.TabStop = False
        Me.message_box.Text = "Message"
        Me.message_box.Visible = False
        '
        'message_clicker
        '
        Me.message_clicker.Location = New System.Drawing.Point(6, 139)
        Me.message_clicker.Name = "message_clicker"
        Me.message_clicker.Size = New System.Drawing.Size(888, 25)
        Me.message_clicker.TabIndex = 1
        Me.message_clicker.TabStop = True
        Me.message_clicker.Text = "教官好！"
        Me.message_clicker.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'message
        '
        Me.message.Font = New System.Drawing.Font("等线", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.message.Location = New System.Drawing.Point(6, 30)
        Me.message.Name = "message"
        Me.message.Size = New System.Drawing.Size(888, 109)
        Me.message.TabIndex = 0
        Me.message.Text = "The monster:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "I am a turkey. Not monster."
        '
        'MessageWeaver
        '
        Me.MessageWeaver.Interval = 25
        '
        'deadrooster
        '
        Me.deadrooster.BackColor = System.Drawing.Color.Black
        Me.deadrooster.BackgroundImage = CType(resources.GetObject("deadrooster.BackgroundImage"), System.Drawing.Image)
        Me.deadrooster.Controls.Add(Me.deadrooster_off)
        Me.deadrooster.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.deadrooster.ForeColor = System.Drawing.Color.White
        Me.deadrooster.Location = New System.Drawing.Point(39, -1)
        Me.deadrooster.Name = "deadrooster"
        Me.deadrooster.Size = New System.Drawing.Size(30, 20)
        Me.deadrooster.TabIndex = 175
        Me.deadrooster.TabStop = False
        Me.deadrooster.Text = "Dead rooster"
        Me.deadrooster.Visible = False
        '
        'deadrooster_off
        '
        Me.deadrooster_off.BackColor = System.Drawing.Color.White
        Me.deadrooster_off.ForeColor = System.Drawing.Color.Black
        Me.deadrooster_off.Location = New System.Drawing.Point(594, 441)
        Me.deadrooster_off.Name = "deadrooster_off"
        Me.deadrooster_off.Size = New System.Drawing.Size(100, 33)
        Me.deadrooster_off.TabIndex = 0
        Me.deadrooster_off.Text = "Next"
        Me.deadrooster_off.UseVisualStyleBackColor = False
        '
        'battle_land
        '
        Me.battle_land.Controls.Add(Me.laser)
        Me.battle_land.Controls.Add(Me.frontbar2)
        Me.battle_land.Controls.Add(Me.backbar2)
        Me.battle_land.Controls.Add(Me.life2)
        Me.battle_land.Controls.Add(Me.effect2)
        Me.battle_land.Controls.Add(Me.frontbar1)
        Me.battle_land.Controls.Add(Me.backbar1)
        Me.battle_land.Controls.Add(Me.life1)
        Me.battle_land.Controls.Add(Me.effect1)
        Me.battle_land.Controls.Add(Me.battler2)
        Me.battle_land.Controls.Add(Me.battler1)
        Me.battle_land.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.battle_land.Location = New System.Drawing.Point(60, -4)
        Me.battle_land.Name = "battle_land"
        Me.battle_land.Size = New System.Drawing.Size(39, 23)
        Me.battle_land.TabIndex = 176
        Me.battle_land.TabStop = False
        Me.battle_land.Text = "battle"
        Me.battle_land.Visible = False
        '
        'laser
        '
        Me.laser.BackColor = System.Drawing.Color.Red
        Me.laser.ForeColor = System.Drawing.Color.Red
        Me.laser.Location = New System.Drawing.Point(170, 200)
        Me.laser.Name = "laser"
        Me.laser.Size = New System.Drawing.Size(460, 15)
        Me.laser.TabIndex = 10
        Me.laser.Visible = False
        '
        'frontbar2
        '
        Me.frontbar2.BackColor = System.Drawing.Color.Lime
        Me.frontbar2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.frontbar2.Font = New System.Drawing.Font("微软雅黑", 22.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.frontbar2.Location = New System.Drawing.Point(474, 474)
        Me.frontbar2.Name = "frontbar2"
        Me.frontbar2.Size = New System.Drawing.Size(320, 20)
        Me.frontbar2.TabIndex = 8
        Me.frontbar2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'backbar2
        '
        Me.backbar2.BackColor = System.Drawing.Color.White
        Me.backbar2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.backbar2.Font = New System.Drawing.Font("微软雅黑", 22.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.backbar2.Location = New System.Drawing.Point(474, 474)
        Me.backbar2.Name = "backbar2"
        Me.backbar2.Size = New System.Drawing.Size(320, 20)
        Me.backbar2.TabIndex = 9
        Me.backbar2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'life2
        '
        Me.life2.Font = New System.Drawing.Font("微软雅黑", 22.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.life2.Location = New System.Drawing.Point(474, 397)
        Me.life2.Name = "life2"
        Me.life2.Size = New System.Drawing.Size(320, 77)
        Me.life2.TabIndex = 7
        Me.life2.Text = "1,000"
        Me.life2.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'effect2
        '
        Me.effect2.Location = New System.Drawing.Point(474, 33)
        Me.effect2.Name = "effect2"
        Me.effect2.Size = New System.Drawing.Size(320, 320)
        Me.effect2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.effect2.TabIndex = 6
        Me.effect2.TabStop = False
        '
        'frontbar1
        '
        Me.frontbar1.BackColor = System.Drawing.Color.Lime
        Me.frontbar1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.frontbar1.Font = New System.Drawing.Font("微软雅黑", 22.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.frontbar1.Location = New System.Drawing.Point(6, 474)
        Me.frontbar1.Name = "frontbar1"
        Me.frontbar1.Size = New System.Drawing.Size(320, 20)
        Me.frontbar1.TabIndex = 5
        Me.frontbar1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'backbar1
        '
        Me.backbar1.BackColor = System.Drawing.Color.White
        Me.backbar1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.backbar1.Font = New System.Drawing.Font("微软雅黑", 22.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.backbar1.Location = New System.Drawing.Point(6, 474)
        Me.backbar1.Name = "backbar1"
        Me.backbar1.Size = New System.Drawing.Size(320, 20)
        Me.backbar1.TabIndex = 4
        Me.backbar1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'life1
        '
        Me.life1.Font = New System.Drawing.Font("微软雅黑", 22.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.life1.Location = New System.Drawing.Point(6, 397)
        Me.life1.Name = "life1"
        Me.life1.Size = New System.Drawing.Size(320, 77)
        Me.life1.TabIndex = 3
        Me.life1.Text = "1,000"
        Me.life1.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'effect1
        '
        Me.effect1.Location = New System.Drawing.Point(6, 33)
        Me.effect1.Name = "effect1"
        Me.effect1.Size = New System.Drawing.Size(320, 320)
        Me.effect1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.effect1.TabIndex = 2
        Me.effect1.TabStop = False
        '
        'battler2
        '
        Me.battler2.Location = New System.Drawing.Point(474, 33)
        Me.battler2.Name = "battler2"
        Me.battler2.Size = New System.Drawing.Size(320, 461)
        Me.battler2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.battler2.TabIndex = 1
        Me.battler2.TabStop = False
        '
        'battler1
        '
        Me.battler1.Location = New System.Drawing.Point(6, 33)
        Me.battler1.Name = "battler1"
        Me.battler1.Size = New System.Drawing.Size(320, 461)
        Me.battler1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.battler1.TabIndex = 0
        Me.battler1.TabStop = False
        '
        'LifeWeaver
        '
        Me.LifeWeaver.Interval = 20
        '
        'Form20
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(900, 766)
        Me.Controls.Add(Me.battle_land)
        Me.Controls.Add(Me.deadrooster)
        Me.Controls.Add(Me.message_box)
        Me.Controls.Add(Me.scanner)
        Me.Controls.Add(Me.mission_box)
        Me.Controls.Add(Me.mission_report)
        Me.Controls.Add(Me.itemlist)
        Me.Controls.Add(Me.scene)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form20"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Turkey hunting system"
        CType(Me.scene, System.ComponentModel.ISupportInitialize).EndInit()
        Me.itemlist.ResumeLayout(False)
        CType(Me.item5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.item4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.item3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.item2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.item1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.item0, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mission_report.ResumeLayout(False)
        Me.mission_box.ResumeLayout(False)
        Me.message_box.ResumeLayout(False)
        Me.deadrooster.ResumeLayout(False)
        Me.battle_land.ResumeLayout(False)
        CType(Me.effect2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.effect1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.battler2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.battler1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents scene As PictureBox
    Friend WithEvents itemlist As GroupBox
    Friend WithEvents item5 As PictureBox
    Friend WithEvents leftmove As Button
    Friend WithEvents rightmove As Button
    Friend WithEvents right_ As Button
    Friend WithEvents item4 As PictureBox
    Friend WithEvents item3 As PictureBox
    Friend WithEvents item2 As PictureBox
    Friend WithEvents item1 As PictureBox
    Friend WithEvents left_ As Button
    Friend WithEvents item0 As PictureBox
    Friend WithEvents mission_report As GroupBox
    Friend WithEvents mission_text As Label
    Friend WithEvents blackbar1 As Label
    Friend WithEvents mission_name As Label
    Friend WithEvents mission_top As Label
    Friend WithEvents blackbar0 As Label
    Friend WithEvents mission_box As GroupBox
    Friend WithEvents mission_back As Button
    Friend WithEvents mission As ListView
    Friend WithEvents mission_icon As ImageList
    Friend WithEvents item_image As ImageList
    Friend WithEvents MoveItem As Timer
    Friend WithEvents Move_mission_report As Timer
    Friend WithEvents Move_missions As Timer
    Friend WithEvents mission_report_next As Button
    Friend WithEvents SceneWeaver As Timer
    Friend WithEvents deletetip As Timer
    Friend WithEvents cutscenes As Timer
    Friend WithEvents scene_icon As ImageList
    Friend WithEvents scanner As Label
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents message_box As GroupBox
    Friend WithEvents message_clicker As LinkLabel
    Friend WithEvents message As Label
    Friend WithEvents MessageWeaver As Timer
    Friend WithEvents deadrooster As GroupBox
    Friend WithEvents deadrooster_off As Button
    Friend WithEvents battle_land As GroupBox
    Friend WithEvents frontbar2 As Label
    Friend WithEvents backbar2 As Label
    Friend WithEvents life2 As Label
    Friend WithEvents effect2 As PictureBox
    Friend WithEvents frontbar1 As Label
    Friend WithEvents backbar1 As Label
    Friend WithEvents life1 As Label
    Friend WithEvents effect1 As PictureBox
    Friend WithEvents battler2 As PictureBox
    Friend WithEvents battler1 As PictureBox
    Friend WithEvents LifeWeaver As Timer
    Friend WithEvents laser As Label
End Class
