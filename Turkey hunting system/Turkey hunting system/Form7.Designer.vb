<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form7
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Form1.ExitProgram()
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form7))
        Me.defend = New System.Windows.Forms.Button()
        Me.defendt = New System.Windows.Forms.Label()
        Me.attackt = New System.Windows.Forms.Label()
        Me.attack = New System.Windows.Forms.Button()
        Me.magict = New System.Windows.Forms.Label()
        Me.magic = New System.Windows.Forms.Button()
        Me.battler = New System.Windows.Forms.PictureBox()
        Me.life2t = New System.Windows.Forms.Label()
        Me.cd2t = New System.Windows.Forms.Label()
        Me.cd1t = New System.Windows.Forms.Label()
        Me.life1t = New System.Windows.Forms.Label()
        Me.title = New System.Windows.Forms.Label()
        Me.setlife1 = New System.Windows.Forms.Timer(Me.components)
        Me.setlife2 = New System.Windows.Forms.Timer(Me.components)
        Me.popout1 = New System.Windows.Forms.Label()
        Me.popout2 = New System.Windows.Forms.Label()
        Me.settop1 = New System.Windows.Forms.Timer(Me.components)
        Me.settop2 = New System.Windows.Forms.Timer(Me.components)
        Me.cool1 = New System.Windows.Forms.Timer(Me.components)
        Me.cool2 = New System.Windows.Forms.Timer(Me.components)
        Me.tutorial = New System.Windows.Forms.GroupBox()
        Me.skip = New System.Windows.Forms.Button()
        Me.next_ = New System.Windows.Forms.Button()
        Me.content = New System.Windows.Forms.Label()
        Me.titleshow = New System.Windows.Forms.Timer(Me.components)
        Me.EnemyAction = New System.Windows.Forms.Timer(Me.components)
        Me.hidecool1 = New System.Windows.Forms.Timer(Me.components)
        Me.hidecool2 = New System.Windows.Forms.Timer(Me.components)
        Me.shining = New System.Windows.Forms.Timer(Me.components)
        Me.defeat = New System.Windows.Forms.Timer(Me.components)
        Me.status1_6 = New System.Windows.Forms.PictureBox()
        Me.status1_5 = New System.Windows.Forms.PictureBox()
        Me.status1_3 = New System.Windows.Forms.PictureBox()
        Me.status1_4 = New System.Windows.Forms.PictureBox()
        Me.status1_1 = New System.Windows.Forms.PictureBox()
        Me.status1_2 = New System.Windows.Forms.PictureBox()
        Me.status2_1 = New System.Windows.Forms.PictureBox()
        Me.status2_2 = New System.Windows.Forms.PictureBox()
        Me.status2_3 = New System.Windows.Forms.PictureBox()
        Me.status2_4 = New System.Windows.Forms.PictureBox()
        Me.status2_5 = New System.Windows.Forms.PictureBox()
        Me.status2_6 = New System.Windows.Forms.PictureBox()
        Me.StatusImage = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.StatusMove = New System.Windows.Forms.Timer(Me.components)
        Me.StatusCheck = New System.Windows.Forms.Timer(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.spelling = New System.Windows.Forms.GroupBox()
        Me.vocabulary = New System.Windows.Forms.ListBox()
        Me.SpellBox = New System.Windows.Forms.TextBox()
        Me.example = New System.Windows.Forms.Label()
        Me.secret = New System.Windows.Forms.TextBox()
        Me.special1 = New System.Windows.Forms.GroupBox()
        Me.next1 = New System.Windows.Forms.Button()
        Me.content1 = New System.Windows.Forms.Label()
        Me.heal = New System.Windows.Forms.Button()
        Me.enemies_number = New System.Windows.Forms.GroupBox()
        Me.numberT = New System.Windows.Forms.Label()
        Me.number = New System.Windows.Forms.ProgressBar()
        Me.assist = New System.Windows.Forms.GroupBox()
        Me.assist3t = New System.Windows.Forms.Label()
        Me.assist3 = New System.Windows.Forms.Button()
        Me.assist2t = New System.Windows.Forms.Label()
        Me.assist2 = New System.Windows.Forms.Button()
        Me.assist1t = New System.Windows.Forms.Label()
        Me.assist1 = New System.Windows.Forms.Button()
        Me.pause = New System.Windows.Forms.Button()
        Me.paused = New System.Windows.Forms.Label()
        Me.mana1t = New System.Windows.Forms.Label()
        Me.mana2t = New System.Windows.Forms.Label()
        Me.Mana1restore = New System.Windows.Forms.Timer(Me.components)
        Me.Mana2restore = New System.Windows.Forms.Timer(Me.components)
        Me.setmana1 = New System.Windows.Forms.Timer(Me.components)
        Me.setmana2 = New System.Windows.Forms.Timer(Me.components)
        Me.color1 = New System.Windows.Forms.Timer(Me.components)
        Me.color2 = New System.Windows.Forms.Timer(Me.components)
        Me.cd1b = New System.Windows.Forms.Label()
        Me.cd1f = New System.Windows.Forms.Label()
        Me.cd2f = New System.Windows.Forms.Label()
        Me.cd2b = New System.Windows.Forms.Label()
        Me.life1b = New System.Windows.Forms.Label()
        Me.life1f = New System.Windows.Forms.Label()
        Me.mana1b = New System.Windows.Forms.Label()
        Me.mana1f = New System.Windows.Forms.Label()
        Me.life2b = New System.Windows.Forms.Label()
        Me.life2f = New System.Windows.Forms.Label()
        Me.mana2b = New System.Windows.Forms.Label()
        Me.mana2f = New System.Windows.Forms.Label()
        Me.debug = New System.Windows.Forms.Timer(Me.components)
        CType(Me.battler, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tutorial.SuspendLayout()
        CType(Me.status1_6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.status1_5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.status1_3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.status1_4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.status1_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.status1_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.status2_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.status2_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.status2_3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.status2_4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.status2_5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.status2_6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spelling.SuspendLayout()
        Me.special1.SuspendLayout()
        Me.enemies_number.SuspendLayout()
        Me.assist.SuspendLayout()
        Me.SuspendLayout()
        '
        'defend
        '
        Me.defend.Font = New System.Drawing.Font("幼圆", 22.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.defend.Location = New System.Drawing.Point(12, 550)
        Me.defend.Name = "defend"
        Me.defend.Size = New System.Drawing.Size(215, 50)
        Me.defend.TabIndex = 0
        Me.defend.Text = "Defend"
        Me.defend.UseVisualStyleBackColor = True
        '
        'defendt
        '
        Me.defendt.Font = New System.Drawing.Font("等线", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.defendt.Location = New System.Drawing.Point(12, 603)
        Me.defendt.Name = "defendt"
        Me.defendt.Size = New System.Drawing.Size(215, 75)
        Me.defendt.TabIndex = 1
        Me.defendt.Text = "Defend 30% damage from the enemy."
        '
        'attackt
        '
        Me.attackt.Font = New System.Drawing.Font("等线", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.attackt.Location = New System.Drawing.Point(233, 603)
        Me.attackt.Name = "attackt"
        Me.attackt.Size = New System.Drawing.Size(216, 75)
        Me.attackt.TabIndex = 3
        Me.attackt.Text = "Cause 16 damage, critical hit can stun the enemy"
        '
        'attack
        '
        Me.attack.Font = New System.Drawing.Font("幼圆", 22.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.attack.Location = New System.Drawing.Point(233, 550)
        Me.attack.Name = "attack"
        Me.attack.Size = New System.Drawing.Size(216, 50)
        Me.attack.TabIndex = 2
        Me.attack.Text = "Beat"
        Me.attack.UseVisualStyleBackColor = True
        '
        'magict
        '
        Me.magict.Font = New System.Drawing.Font("等线", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.magict.Location = New System.Drawing.Point(455, 603)
        Me.magict.Name = "magict"
        Me.magict.Size = New System.Drawing.Size(215, 75)
        Me.magict.TabIndex = 5
        Me.magict.Text = "At present, you have no magic."
        '
        'magic
        '
        Me.magic.Font = New System.Drawing.Font("幼圆", 22.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.magic.Location = New System.Drawing.Point(455, 550)
        Me.magic.Name = "magic"
        Me.magic.Size = New System.Drawing.Size(216, 50)
        Me.magic.TabIndex = 4
        Me.magic.Text = "Magic"
        Me.magic.UseVisualStyleBackColor = True
        '
        'battler
        '
        Me.battler.Image = CType(resources.GetObject("battler.Image"), System.Drawing.Image)
        Me.battler.Location = New System.Drawing.Point(12, 104)
        Me.battler.Name = "battler"
        Me.battler.Size = New System.Drawing.Size(658, 440)
        Me.battler.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.battler.TabIndex = 6
        Me.battler.TabStop = False
        '
        'life2t
        '
        Me.life2t.Font = New System.Drawing.Font("等线", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.life2t.Location = New System.Drawing.Point(-20, 681)
        Me.life2t.Name = "life2t"
        Me.life2t.Size = New System.Drawing.Size(166, 23)
        Me.life2t.TabIndex = 8
        Me.life2t.Text = "0"
        Me.life2t.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cd2t
        '
        Me.cd2t.Font = New System.Drawing.Font("等线", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.cd2t.Location = New System.Drawing.Point(302, 728)
        Me.cd2t.Name = "cd2t"
        Me.cd2t.Size = New System.Drawing.Size(116, 16)
        Me.cd2t.TabIndex = 10
        Me.cd2t.Text = "Cool down:"
        Me.cd2t.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cd2t.Visible = False
        '
        'cd1t
        '
        Me.cd1t.Font = New System.Drawing.Font("等线", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.cd1t.Location = New System.Drawing.Point(302, 12)
        Me.cd1t.Name = "cd1t"
        Me.cd1t.Size = New System.Drawing.Size(116, 16)
        Me.cd1t.TabIndex = 14
        Me.cd1t.Text = "Cool down:"
        Me.cd1t.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cd1t.Visible = False
        '
        'life1t
        '
        Me.life1t.Font = New System.Drawing.Font("等线", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.life1t.Location = New System.Drawing.Point(-20, 34)
        Me.life1t.Name = "life1t"
        Me.life1t.Size = New System.Drawing.Size(166, 23)
        Me.life1t.TabIndex = 12
        Me.life1t.Text = "0"
        Me.life1t.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'title
        '
        Me.title.Font = New System.Drawing.Font("等线", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.title.Location = New System.Drawing.Point(12, 78)
        Me.title.Name = "title"
        Me.title.Size = New System.Drawing.Size(612, 23)
        Me.title.TabIndex = 15
        Me.title.Tag = ""
        Me.title.Text = "You beat the turkey egg."
        Me.title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.title.Visible = False
        '
        'setlife1
        '
        Me.setlife1.Interval = 15
        '
        'setlife2
        '
        Me.setlife2.Interval = 15
        '
        'popout1
        '
        Me.popout1.Font = New System.Drawing.Font("Segoe UI Emoji", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.popout1.Location = New System.Drawing.Point(215, 218)
        Me.popout1.Name = "popout1"
        Me.popout1.Size = New System.Drawing.Size(200, 70)
        Me.popout1.TabIndex = 16
        Me.popout1.Text = "-16"
        Me.popout1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.popout1.Visible = False
        '
        'popout2
        '
        Me.popout2.Font = New System.Drawing.Font("Segoe UI Emoji", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.popout2.Location = New System.Drawing.Point(510, 634)
        Me.popout2.Name = "popout2"
        Me.popout2.Size = New System.Drawing.Size(200, 70)
        Me.popout2.TabIndex = 17
        Me.popout2.Text = "-16"
        Me.popout2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.popout2.Visible = False
        '
        'settop1
        '
        Me.settop1.Interval = 12
        '
        'settop2
        '
        Me.settop2.Interval = 12
        '
        'cool1
        '
        Me.cool1.Interval = 10
        '
        'cool2
        '
        Me.cool2.Interval = 10
        '
        'tutorial
        '
        Me.tutorial.Controls.Add(Me.skip)
        Me.tutorial.Controls.Add(Me.next_)
        Me.tutorial.Controls.Add(Me.content)
        Me.tutorial.Font = New System.Drawing.Font("微软雅黑", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.tutorial.Location = New System.Drawing.Point(73, 123)
        Me.tutorial.Name = "tutorial"
        Me.tutorial.Size = New System.Drawing.Size(500, 200)
        Me.tutorial.TabIndex = 18
        Me.tutorial.TabStop = False
        Me.tutorial.Text = "tutorial"
        Me.tutorial.Visible = False
        '
        'skip
        '
        Me.skip.Location = New System.Drawing.Point(288, 159)
        Me.skip.Name = "skip"
        Me.skip.Size = New System.Drawing.Size(100, 35)
        Me.skip.TabIndex = 2
        Me.skip.Text = "Skip"
        Me.skip.UseVisualStyleBackColor = True
        '
        'next_
        '
        Me.next_.Location = New System.Drawing.Point(394, 159)
        Me.next_.Name = "next_"
        Me.next_.Size = New System.Drawing.Size(100, 35)
        Me.next_.TabIndex = 1
        Me.next_.Text = "Next"
        Me.next_.UseVisualStyleBackColor = True
        '
        'content
        '
        Me.content.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.content.Location = New System.Drawing.Point(6, 34)
        Me.content.Name = "content"
        Me.content.Size = New System.Drawing.Size(488, 163)
        Me.content.TabIndex = 0
        Me.content.Text = "Welcome to the battle system, this is the first battle."
        '
        'titleshow
        '
        Me.titleshow.Interval = 10
        '
        'EnemyAction
        '
        '
        'hidecool1
        '
        Me.hidecool1.Interval = 1000
        '
        'hidecool2
        '
        Me.hidecool2.Interval = 1000
        '
        'shining
        '
        Me.shining.Interval = 400
        '
        'defeat
        '
        Me.defeat.Interval = 2000
        '
        'status1_6
        '
        Me.status1_6.Location = New System.Drawing.Point(283, 0)
        Me.status1_6.Name = "status1_6"
        Me.status1_6.Size = New System.Drawing.Size(34, 34)
        Me.status1_6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.status1_6.TabIndex = 19
        Me.status1_6.TabStop = False
        Me.status1_6.Visible = False
        '
        'status1_5
        '
        Me.status1_5.Location = New System.Drawing.Point(250, 0)
        Me.status1_5.Name = "status1_5"
        Me.status1_5.Size = New System.Drawing.Size(34, 34)
        Me.status1_5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.status1_5.TabIndex = 20
        Me.status1_5.TabStop = False
        Me.status1_5.Visible = False
        '
        'status1_3
        '
        Me.status1_3.Location = New System.Drawing.Point(184, 0)
        Me.status1_3.Name = "status1_3"
        Me.status1_3.Size = New System.Drawing.Size(34, 34)
        Me.status1_3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.status1_3.TabIndex = 22
        Me.status1_3.TabStop = False
        Me.status1_3.Visible = False
        '
        'status1_4
        '
        Me.status1_4.Location = New System.Drawing.Point(217, 0)
        Me.status1_4.Name = "status1_4"
        Me.status1_4.Size = New System.Drawing.Size(34, 34)
        Me.status1_4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.status1_4.TabIndex = 21
        Me.status1_4.TabStop = False
        Me.status1_4.Visible = False
        '
        'status1_1
        '
        Me.status1_1.Location = New System.Drawing.Point(118, 0)
        Me.status1_1.Name = "status1_1"
        Me.status1_1.Size = New System.Drawing.Size(34, 34)
        Me.status1_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.status1_1.TabIndex = 24
        Me.status1_1.TabStop = False
        Me.status1_1.Visible = False
        '
        'status1_2
        '
        Me.status1_2.Location = New System.Drawing.Point(151, 0)
        Me.status1_2.Name = "status1_2"
        Me.status1_2.Size = New System.Drawing.Size(34, 34)
        Me.status1_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.status1_2.TabIndex = 23
        Me.status1_2.TabStop = False
        Me.status1_2.Visible = False
        '
        'status2_1
        '
        Me.status2_1.Location = New System.Drawing.Point(118, 722)
        Me.status2_1.Name = "status2_1"
        Me.status2_1.Size = New System.Drawing.Size(34, 34)
        Me.status2_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.status2_1.TabIndex = 30
        Me.status2_1.TabStop = False
        Me.status2_1.Visible = False
        '
        'status2_2
        '
        Me.status2_2.Location = New System.Drawing.Point(151, 722)
        Me.status2_2.Name = "status2_2"
        Me.status2_2.Size = New System.Drawing.Size(34, 34)
        Me.status2_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.status2_2.TabIndex = 29
        Me.status2_2.TabStop = False
        Me.status2_2.Visible = False
        '
        'status2_3
        '
        Me.status2_3.Location = New System.Drawing.Point(184, 722)
        Me.status2_3.Name = "status2_3"
        Me.status2_3.Size = New System.Drawing.Size(34, 34)
        Me.status2_3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.status2_3.TabIndex = 28
        Me.status2_3.TabStop = False
        Me.status2_3.Visible = False
        '
        'status2_4
        '
        Me.status2_4.Location = New System.Drawing.Point(217, 722)
        Me.status2_4.Name = "status2_4"
        Me.status2_4.Size = New System.Drawing.Size(34, 34)
        Me.status2_4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.status2_4.TabIndex = 27
        Me.status2_4.TabStop = False
        Me.status2_4.Visible = False
        '
        'status2_5
        '
        Me.status2_5.Location = New System.Drawing.Point(250, 722)
        Me.status2_5.Name = "status2_5"
        Me.status2_5.Size = New System.Drawing.Size(34, 34)
        Me.status2_5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.status2_5.TabIndex = 26
        Me.status2_5.TabStop = False
        Me.status2_5.Visible = False
        '
        'status2_6
        '
        Me.status2_6.Location = New System.Drawing.Point(283, 722)
        Me.status2_6.Name = "status2_6"
        Me.status2_6.Size = New System.Drawing.Size(34, 34)
        Me.status2_6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.status2_6.TabIndex = 25
        Me.status2_6.TabStop = False
        Me.status2_6.Visible = False
        '
        'StatusImage
        '
        Me.StatusImage.ImageStream = CType(resources.GetObject("StatusImage.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.StatusImage.TransparentColor = System.Drawing.Color.Transparent
        Me.StatusImage.Images.SetKeyName(0, "shield0.png")
        Me.StatusImage.Images.SetKeyName(1, "fire.png")
        Me.StatusImage.Images.SetKeyName(2, "water.png")
        Me.StatusImage.Images.SetKeyName(3, "up.png")
        Me.StatusImage.Images.SetKeyName(4, "stun.png")
        Me.StatusImage.Images.SetKeyName(5, "shield1.png")
        Me.StatusImage.Images.SetKeyName(6, "shrink.png")
        Me.StatusImage.Images.SetKeyName(7, "expand.png")
        Me.StatusImage.Images.SetKeyName(8, "numb.png")
        Me.StatusImage.Images.SetKeyName(9, "slow.png")
        Me.StatusImage.Images.SetKeyName(10, "shield2.5.png")
        Me.StatusImage.Images.SetKeyName(11, "puzzle.png")
        Me.StatusImage.Images.SetKeyName(12, "poison.png")
        Me.StatusImage.Images.SetKeyName(13, "blood.png")
        Me.StatusImage.Images.SetKeyName(14, "discombobulation.png")
        Me.StatusImage.Images.SetKeyName(15, "fire.png")
        Me.StatusImage.Images.SetKeyName(16, "corrosion.png")
        Me.StatusImage.Images.SetKeyName(17, "spike.png")
        Me.StatusImage.Images.SetKeyName(18, "burrow.png")
        Me.StatusImage.Images.SetKeyName(19, "charm.png")
        Me.StatusImage.Images.SetKeyName(20, "freeze.png")
        Me.StatusImage.Images.SetKeyName(21, "spshield.png")
        Me.StatusImage.Images.SetKeyName(22, "confusion.png")
        Me.StatusImage.Images.SetKeyName(23, "solar corona fire.png")
        Me.StatusImage.Images.SetKeyName(24, "shield3.png")
        Me.StatusImage.Images.SetKeyName(25, "scare.png")
        Me.StatusImage.Images.SetKeyName(26, "ghost.png")
        Me.StatusImage.Images.SetKeyName(27, "turtle.png")
        Me.StatusImage.Images.SetKeyName(28, "turkey.png")
        Me.StatusImage.Images.SetKeyName(29, "extreme confusion.png")
        Me.StatusImage.Images.SetKeyName(30, "charm.png")
        Me.StatusImage.Images.SetKeyName(31, "hydrogen sulfide poison.png")
        Me.StatusImage.Images.SetKeyName(32, "phantom.png")
        Me.StatusImage.Images.SetKeyName(33, "positiveness.png")
        Me.StatusImage.Images.SetKeyName(34, "negativeness.png")
        Me.StatusImage.Images.SetKeyName(35, "full immunity.png")
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 15000
        Me.ToolTip1.InitialDelay = 500
        Me.ToolTip1.ReshowDelay = 100
        '
        'StatusMove
        '
        '
        'StatusCheck
        '
        Me.StatusCheck.Interval = 1000
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 10
        '
        'spelling
        '
        Me.spelling.Controls.Add(Me.vocabulary)
        Me.spelling.Controls.Add(Me.SpellBox)
        Me.spelling.Controls.Add(Me.example)
        Me.spelling.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.spelling.Location = New System.Drawing.Point(12, 550)
        Me.spelling.Name = "spelling"
        Me.spelling.Size = New System.Drawing.Size(658, 125)
        Me.spelling.TabIndex = 31
        Me.spelling.TabStop = False
        Me.spelling.Text = "Word spelling"
        Me.spelling.Visible = False
        '
        'vocabulary
        '
        Me.vocabulary.FormattingEnabled = True
        Me.vocabulary.ItemHeight = 27
        Me.vocabulary.Items.AddRange(New Object() {"apart", "absurd", "abduct", "apartment", "avoid", "abuse", "application", "attract", "attraction", "attractive", "abnormal", "and", "ant", "aim", "aimless", "afraid", "apply", "allow", "almost", "altar", "activate", "activation", "altogether", "amazement", "acidic", "acid", "abhor", "abhorrent", "abhorrence", "angel", "angle", "able", "any", "absurdity", "bomb", "bitch", "blow", "borrow", "blush", "blast", "bomber", "bus", "but", "bat", "bad", "beyond", "belong", "beat", "beast", "bank", "bar", "beauty", "beef", "beach", "beget", "bell", "bear", "bind", "birthplace", "birth", "bleed", "blood", "bottom", "bottomless", "breakdown", "breakage", "button", "biochemistry", "cause", "course", "can", "cap", "cruelty", "carry", "carelessness", "continuous", "cave", "chagrin", "challenge", "champion", "chance", "command", "condemn", "celibatarian", "compel", "compare", "charge", "catastrophe", "change", "chemistry", "class", "classic", "could", "collect", "collection", "dead", "deadly", "die", "doom", "doomsday", "destroy", "destructive", "disaster", "discourage", "damn", "disdain", "dismiss", "dismissal", "detest", "divorce", "detestation", "distort", "downfall", "demonic", "demon", "devil", "divine", "duck", "destine", "destiny", "enrage", "enable", "expert", "egg", "eager", "epic", "eagerly", "earn", "electricity", "edition", "effect", "effort", "element", "elephant", "enemy", "experience", "expansion", "engraft", "enterprise", "entire", "flunk", "flunked", "flap", "flee", "factory", "fallacy", "fault", "faultless", "felon", "foremost", "farewell", "fatal", "fight", "forget", "font", "forgive", "forsake", "foxy", "fluid", "god", "good", "goat", "ghost", "ghostly", "gossip", "goldfish", "gloom", "gloomy", "habit", "have", "hate", "hung", "heartless", "helpless", "hide", "history", "horror", "horrible", "holy", "horrid", "harm", "harmful", "hurtful", "iron", "immortal", "immortality", "impact", "infection", "injection", "insistence", "insist", "identify", "illness", "inborn", "impressable", "impress", "impossible", "impossibility", "import", "income", "incurable", "indeed", "index", "indict", "indirect", "inexpert", "inferno", "inferior", "injury", "inn", "inquire", "install", "inappreciable", "jaw", "jet", "journal", "journey", "jail", "jellyfish", "jewel", "jeweler", "joy", "join", "joyance", "justify", "justice", "know", "kid", "knight", "kidnap", "ketone", "kill", "killer", "king", "kingdom", "kingship", "kindness", "knowledge", "knowledgeable", "lethal", "lie", "lay", "lord", "lather", "later", "legend", "latter", "law", "lawbook", "lawful", "lawless", "lawyer", "leak", "leanness", "legacy", "lone", "lorn", "license", "limewater", "liveliness", "loosen", "loyal", "lowliness", "loyalty", "mortal", "mirror", "mirroring", "middle", "mystery", "madam", "mainly", "meaningless", "many", "murloc", "master", "Mars", "misery", "misfortune", "mistrust", "mislead", "maze", "minister", "misunderstand", "mourn", "none", "null", "neither", "nether", "natal", "navy", "neon", "nothingness", "nightmare", "noise", "noiseless", "nonentity", "nihility", "number", "noxious", "normal", "normalizition", "normalize", "nonchalance", "nitrogen", "oxygen", "owe", "organization", "oblivion", "occur", "occupy", "office", "opposition", "original", "owl", "outline", "outlive", "outlying", "over", "overcrowd", "overheat", "overjoy", "overpopulation", "overpower", "overshadow", "oxidize", "objective", "overestimate", "pig", "pacify", "pacifist", "panic", "panicky", "percent", "presentation", "present", "poor", "passion", "pessimistic", "path", "pay", "pear", "periodic", "phoenix", "poison", "poisonous", "pitiful", "pitiless", "pity", "pitfall", "pitch", "plague", "plain", "ploy", "private", "profuse", "pirate", "predict", "prediction", "protect", "protest", "protestion", "proceed", "progress", "program", "python", "quit", "quite", "quiet", "quartermaster", "quickness", "quixotic", "quicken", "quell", "quest", "questionaire", "quail", "quarter", "rabbit", "reduction", "reduce", "radiate", "radiation", "rampage", "rashness", "rush", "rat", "rebut", "replace", "remove", "replace", "revive", "resurrection", "resurrect", "recoll", "reconstruction", "refresh", "rise", "require", "reorder", "requite", "resist", "resistance", "restore", "richness", "rightful", "riskful", "risk", "roar", "rogue", "reflection", "reflect", "ruthless", "superb", "super", "salt", "spicy", "spice", "simple", "sample", "save", "savior", "saw", "sawyer", "sandwich", "scientific", "screw", "screen", "scary", "sit", "script", "spirit", "seek", "sank", "selfish", "surrender", "surreal", "severe", "several", "shelve", "shape", "stop", "stun", "stubborn", "shake", "shock", "shudder", "skillful", "skull", "sneak", "softball", "safe", "soldier", "spread", "spreader", "systolic", "systematically", "systematize", "torture", "terror", "terrorist", "talent", "tank", "taunt", "tenantless", "tendency", "terrifying", "term", "Thanksgiving", "turkey", "tornado", "temple", "trample", "twist", "thorn", "tremble", "topical", "toxoid", "toxic", "teleport", "teleporter", "transfer", "thump", "undead", "unemployment", "unable", "underscore", "undervalue", "underestimate", "undersirable", "undertake", "unfit", "universal", "unloose", "unpopular", "unskillful", "upgrade", "uprising", "upmost", "utility", "vicious", "virtuous", "vampire", "various", "vector", "verify", "vertiginous", "victim", "victimize", "vide", "vine", "violent", "viscid", "versus", "vital", "visual", "vitality", "vying", "wane", "wild", "warmth", "waterfall", "weightlessness", "whenever", "whale", "while", "witch", "win", "widow", "within", "without", "wood", "wrongful", "wry", "Xerox", "xylem", "xylophone", "xenophobia", "xerography", "xerophyte", "yarn", "yak", "yes", "yet", "youngling", "yearling", "yarrow", "year", "yesterday", "yellowstone", "yardstick", "zoo", "zoology", "zoological", "zone", "zoom", "zealous"})
        Me.vocabulary.Location = New System.Drawing.Point(342, 2)
        Me.vocabulary.Name = "vocabulary"
        Me.vocabulary.Size = New System.Drawing.Size(120, 85)
        Me.vocabulary.TabIndex = 3
        Me.vocabulary.Tag = "0"
        Me.vocabulary.Visible = False
        '
        'SpellBox
        '
        Me.SpellBox.Font = New System.Drawing.Font("等线", 24.0!, System.Drawing.FontStyle.Bold)
        Me.SpellBox.Location = New System.Drawing.Point(6, 70)
        Me.SpellBox.Name = "SpellBox"
        Me.SpellBox.Size = New System.Drawing.Size(646, 49)
        Me.SpellBox.TabIndex = 1
        Me.SpellBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'example
        '
        Me.example.Font = New System.Drawing.Font("等线", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.example.Location = New System.Drawing.Point(6, 30)
        Me.example.Name = "example"
        Me.example.Size = New System.Drawing.Size(646, 40)
        Me.example.TabIndex = 0
        Me.example.Tag = "0"
        Me.example.Text = "Example"
        Me.example.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'secret
        '
        Me.secret.Location = New System.Drawing.Point(201, 157)
        Me.secret.Name = "secret"
        Me.secret.Size = New System.Drawing.Size(273, 38)
        Me.secret.TabIndex = 2
        Me.secret.Tag = "0"
        Me.secret.Text = "damncurrentlovethefallaciousloveisdoomedtofallapart"
        Me.secret.Visible = False
        '
        'special1
        '
        Me.special1.Controls.Add(Me.next1)
        Me.special1.Controls.Add(Me.secret)
        Me.special1.Controls.Add(Me.content1)
        Me.special1.Font = New System.Drawing.Font("微软雅黑", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.special1.Location = New System.Drawing.Point(67, 148)
        Me.special1.Name = "special1"
        Me.special1.Size = New System.Drawing.Size(500, 200)
        Me.special1.TabIndex = 19
        Me.special1.TabStop = False
        Me.special1.Text = "special mode"
        Me.special1.Visible = False
        '
        'next1
        '
        Me.next1.Location = New System.Drawing.Point(394, 159)
        Me.next1.Name = "next1"
        Me.next1.Size = New System.Drawing.Size(100, 35)
        Me.next1.TabIndex = 1
        Me.next1.Text = "Next"
        Me.next1.UseVisualStyleBackColor = True
        '
        'content1
        '
        Me.content1.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.content1.Location = New System.Drawing.Point(6, 34)
        Me.content1.Name = "content1"
        Me.content1.Size = New System.Drawing.Size(488, 163)
        Me.content1.TabIndex = 0
        Me.content1.Tag = "0"
        Me.content1.Text = "The solar corona ball is protected by the power of RX that normal attacks cannot " &
    "hurt it, you have to use the English words to break up the corona ball."
        '
        'heal
        '
        Me.heal.Font = New System.Drawing.Font("微软雅黑", 13.8!)
        Me.heal.Location = New System.Drawing.Point(-1, 722)
        Me.heal.Name = "heal"
        Me.heal.Size = New System.Drawing.Size(115, 35)
        Me.heal.TabIndex = 2
        Me.heal.Text = "Heal(0)"
        Me.heal.UseVisualStyleBackColor = True
        '
        'enemies_number
        '
        Me.enemies_number.BackColor = System.Drawing.Color.SeaShell
        Me.enemies_number.Controls.Add(Me.numberT)
        Me.enemies_number.Controls.Add(Me.number)
        Me.enemies_number.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.enemies_number.Location = New System.Drawing.Point(424, 104)
        Me.enemies_number.Name = "enemies_number"
        Me.enemies_number.Size = New System.Drawing.Size(200, 59)
        Me.enemies_number.TabIndex = 65
        Me.enemies_number.TabStop = False
        Me.enemies_number.Text = "Enemies number"
        Me.enemies_number.Visible = False
        '
        'numberT
        '
        Me.numberT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.numberT.Location = New System.Drawing.Point(149, 30)
        Me.numberT.Name = "numberT"
        Me.numberT.Size = New System.Drawing.Size(49, 25)
        Me.numberT.TabIndex = 65
        Me.numberT.Text = "13"
        '
        'number
        '
        Me.number.Location = New System.Drawing.Point(6, 33)
        Me.number.Maximum = 13
        Me.number.Name = "number"
        Me.number.Size = New System.Drawing.Size(140, 20)
        Me.number.TabIndex = 65
        Me.number.Tag = ""
        Me.number.Value = 13
        '
        'assist
        '
        Me.assist.Controls.Add(Me.assist3t)
        Me.assist.Controls.Add(Me.assist3)
        Me.assist.Controls.Add(Me.assist2t)
        Me.assist.Controls.Add(Me.assist2)
        Me.assist.Controls.Add(Me.assist1t)
        Me.assist.Controls.Add(Me.assist1)
        Me.assist.Font = New System.Drawing.Font("微软雅黑", 12.0!)
        Me.assist.Location = New System.Drawing.Point(12, 151)
        Me.assist.Name = "assist"
        Me.assist.Size = New System.Drawing.Size(150, 253)
        Me.assist.TabIndex = 66
        Me.assist.TabStop = False
        Me.assist.Tag = "0"
        Me.assist.Text = "Mr.Duck"
        Me.assist.Visible = False
        '
        'assist3t
        '
        Me.assist3t.Font = New System.Drawing.Font("宋体", 7.5!)
        Me.assist3t.Location = New System.Drawing.Point(6, 202)
        Me.assist3t.Name = "assist3t"
        Me.assist3t.Size = New System.Drawing.Size(138, 48)
        Me.assist3t.TabIndex = 8
        Me.assist3t.Tag = "0"
        Me.assist3t.Text = "Cause 120|sin(x°)| damage. x=your enemy's health."
        '
        'assist3
        '
        Me.assist3.Font = New System.Drawing.Font("微软雅黑", 12.0!)
        Me.assist3.Location = New System.Drawing.Point(6, 169)
        Me.assist3.Name = "assist3"
        Me.assist3.Size = New System.Drawing.Size(138, 33)
        Me.assist3.TabIndex = 7
        Me.assist3.Text = "Function"
        Me.assist3.UseVisualStyleBackColor = True
        '
        'assist2t
        '
        Me.assist2t.Font = New System.Drawing.Font("宋体", 7.5!)
        Me.assist2t.Location = New System.Drawing.Point(5, 134)
        Me.assist2t.Name = "assist2t"
        Me.assist2t.Size = New System.Drawing.Size(139, 32)
        Me.assist2t.TabIndex = 4
        Me.assist2t.Tag = "0"
        Me.assist2t.Text = "Puzzle your enemy. Dispel statuses."
        '
        'assist2
        '
        Me.assist2.Font = New System.Drawing.Font("微软雅黑", 12.0!)
        Me.assist2.Location = New System.Drawing.Point(6, 101)
        Me.assist2.Name = "assist2"
        Me.assist2.Size = New System.Drawing.Size(138, 33)
        Me.assist2.TabIndex = 5
        Me.assist2.Text = "Math wave"
        Me.assist2.UseVisualStyleBackColor = True
        '
        'assist1t
        '
        Me.assist1t.Font = New System.Drawing.Font("宋体", 7.5!)
        Me.assist1t.Location = New System.Drawing.Point(6, 66)
        Me.assist1t.Name = "assist1t"
        Me.assist1t.Size = New System.Drawing.Size(138, 32)
        Me.assist1t.TabIndex = 3
        Me.assist1t.Tag = "0"
        Me.assist1t.Text = "Cause 14 damage, octuple to murloc."
        '
        'assist1
        '
        Me.assist1.Location = New System.Drawing.Point(6, 33)
        Me.assist1.Name = "assist1"
        Me.assist1.Size = New System.Drawing.Size(138, 33)
        Me.assist1.TabIndex = 3
        Me.assist1.Text = "Peck"
        Me.assist1.UseVisualStyleBackColor = True
        '
        'pause
        '
        Me.pause.Enabled = False
        Me.pause.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.pause.Location = New System.Drawing.Point(6, 101)
        Me.pause.Name = "pause"
        Me.pause.Size = New System.Drawing.Size(133, 33)
        Me.pause.TabIndex = 67
        Me.pause.Text = "Pause"
        Me.pause.UseVisualStyleBackColor = True
        '
        'paused
        '
        Me.paused.Font = New System.Drawing.Font("微软雅黑", 25.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.paused.Location = New System.Drawing.Point(-4, 0)
        Me.paused.Name = "paused"
        Me.paused.Size = New System.Drawing.Size(88, 28)
        Me.paused.TabIndex = 68
        Me.paused.Text = "Paused"
        Me.paused.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.paused.Visible = False
        '
        'mana1t
        '
        Me.mana1t.Font = New System.Drawing.Font("等线", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.mana1t.Location = New System.Drawing.Point(-20, 57)
        Me.mana1t.Name = "mana1t"
        Me.mana1t.Size = New System.Drawing.Size(166, 18)
        Me.mana1t.TabIndex = 70
        Me.mana1t.Text = "0"
        Me.mana1t.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mana2t
        '
        Me.mana2t.Font = New System.Drawing.Font("等线", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.mana2t.Location = New System.Drawing.Point(-20, 704)
        Me.mana2t.Name = "mana2t"
        Me.mana2t.Size = New System.Drawing.Size(166, 18)
        Me.mana2t.TabIndex = 72
        Me.mana2t.Text = "0"
        Me.mana2t.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Mana1restore
        '
        Me.Mana1restore.Interval = 500
        '
        'Mana2restore
        '
        Me.Mana2restore.Interval = 500
        '
        'setmana1
        '
        Me.setmana1.Interval = 15
        '
        'setmana2
        '
        Me.setmana2.Interval = 15
        '
        'color1
        '
        Me.color1.Interval = 500
        '
        'color2
        '
        Me.color2.Interval = 500
        '
        'cd1b
        '
        Me.cd1b.BackColor = System.Drawing.Color.White
        Me.cd1b.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cd1b.Location = New System.Drawing.Point(424, 12)
        Me.cd1b.Name = "cd1b"
        Me.cd1b.Size = New System.Drawing.Size(246, 16)
        Me.cd1b.TabIndex = 3
        '
        'cd1f
        '
        Me.cd1f.BackColor = System.Drawing.Color.Aqua
        Me.cd1f.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cd1f.Location = New System.Drawing.Point(424, 12)
        Me.cd1f.Name = "cd1f"
        Me.cd1f.Size = New System.Drawing.Size(246, 16)
        Me.cd1f.TabIndex = 73
        '
        'cd2f
        '
        Me.cd2f.BackColor = System.Drawing.Color.Aqua
        Me.cd2f.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cd2f.Location = New System.Drawing.Point(424, 728)
        Me.cd2f.Name = "cd2f"
        Me.cd2f.Size = New System.Drawing.Size(246, 16)
        Me.cd2f.TabIndex = 75
        '
        'cd2b
        '
        Me.cd2b.BackColor = System.Drawing.Color.White
        Me.cd2b.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cd2b.Location = New System.Drawing.Point(424, 728)
        Me.cd2b.Name = "cd2b"
        Me.cd2b.Size = New System.Drawing.Size(246, 16)
        Me.cd2b.TabIndex = 74
        '
        'life1b
        '
        Me.life1b.BackColor = System.Drawing.Color.White
        Me.life1b.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.life1b.Location = New System.Drawing.Point(139, 34)
        Me.life1b.Name = "life1b"
        Me.life1b.Size = New System.Drawing.Size(531, 23)
        Me.life1b.TabIndex = 76
        '
        'life1f
        '
        Me.life1f.BackColor = System.Drawing.Color.Lime
        Me.life1f.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.life1f.Location = New System.Drawing.Point(139, 34)
        Me.life1f.Name = "life1f"
        Me.life1f.Size = New System.Drawing.Size(531, 23)
        Me.life1f.TabIndex = 77
        '
        'mana1b
        '
        Me.mana1b.BackColor = System.Drawing.Color.White
        Me.mana1b.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mana1b.Location = New System.Drawing.Point(139, 63)
        Me.mana1b.Name = "mana1b"
        Me.mana1b.Size = New System.Drawing.Size(531, 12)
        Me.mana1b.TabIndex = 78
        '
        'mana1f
        '
        Me.mana1f.BackColor = System.Drawing.Color.Blue
        Me.mana1f.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mana1f.Location = New System.Drawing.Point(139, 63)
        Me.mana1f.Name = "mana1f"
        Me.mana1f.Size = New System.Drawing.Size(531, 12)
        Me.mana1f.TabIndex = 79
        '
        'life2b
        '
        Me.life2b.BackColor = System.Drawing.Color.White
        Me.life2b.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.life2b.Location = New System.Drawing.Point(139, 681)
        Me.life2b.Name = "life2b"
        Me.life2b.Size = New System.Drawing.Size(531, 23)
        Me.life2b.TabIndex = 80
        '
        'life2f
        '
        Me.life2f.BackColor = System.Drawing.Color.Lime
        Me.life2f.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.life2f.Location = New System.Drawing.Point(139, 681)
        Me.life2f.Name = "life2f"
        Me.life2f.Size = New System.Drawing.Size(531, 23)
        Me.life2f.TabIndex = 81
        '
        'mana2b
        '
        Me.mana2b.BackColor = System.Drawing.Color.White
        Me.mana2b.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mana2b.Location = New System.Drawing.Point(139, 710)
        Me.mana2b.Name = "mana2b"
        Me.mana2b.Size = New System.Drawing.Size(531, 12)
        Me.mana2b.TabIndex = 82
        '
        'mana2f
        '
        Me.mana2f.BackColor = System.Drawing.Color.Blue
        Me.mana2f.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mana2f.Location = New System.Drawing.Point(139, 710)
        Me.mana2f.Name = "mana2f"
        Me.mana2f.Size = New System.Drawing.Size(531, 12)
        Me.mana2f.TabIndex = 83
        '
        'debug
        '
        '
        'Form7
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SeaShell
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(682, 756)
        Me.Controls.Add(Me.popout2)
        Me.Controls.Add(Me.mana2f)
        Me.Controls.Add(Me.mana2b)
        Me.Controls.Add(Me.life2f)
        Me.Controls.Add(Me.life2b)
        Me.Controls.Add(Me.mana1f)
        Me.Controls.Add(Me.mana1b)
        Me.Controls.Add(Me.life1f)
        Me.Controls.Add(Me.life1b)
        Me.Controls.Add(Me.cd2f)
        Me.Controls.Add(Me.cd2b)
        Me.Controls.Add(Me.cd1f)
        Me.Controls.Add(Me.cd1b)
        Me.Controls.Add(Me.mana1t)
        Me.Controls.Add(Me.pause)
        Me.Controls.Add(Me.paused)
        Me.Controls.Add(Me.assist)
        Me.Controls.Add(Me.enemies_number)
        Me.Controls.Add(Me.heal)
        Me.Controls.Add(Me.special1)
        Me.Controls.Add(Me.spelling)
        Me.Controls.Add(Me.status2_1)
        Me.Controls.Add(Me.status2_2)
        Me.Controls.Add(Me.status1_1)
        Me.Controls.Add(Me.status1_2)
        Me.Controls.Add(Me.status2_3)
        Me.Controls.Add(Me.status1_3)
        Me.Controls.Add(Me.status1_4)
        Me.Controls.Add(Me.status2_4)
        Me.Controls.Add(Me.status1_5)
        Me.Controls.Add(Me.status1_6)
        Me.Controls.Add(Me.status2_5)
        Me.Controls.Add(Me.tutorial)
        Me.Controls.Add(Me.status2_6)
        Me.Controls.Add(Me.popout1)
        Me.Controls.Add(Me.title)
        Me.Controls.Add(Me.cd1t)
        Me.Controls.Add(Me.cd2t)
        Me.Controls.Add(Me.battler)
        Me.Controls.Add(Me.magict)
        Me.Controls.Add(Me.magic)
        Me.Controls.Add(Me.attackt)
        Me.Controls.Add(Me.attack)
        Me.Controls.Add(Me.defendt)
        Me.Controls.Add(Me.defend)
        Me.Controls.Add(Me.life1t)
        Me.Controls.Add(Me.life2t)
        Me.Controls.Add(Me.mana2t)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form7"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Battle!"
        CType(Me.battler, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tutorial.ResumeLayout(False)
        CType(Me.status1_6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.status1_5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.status1_3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.status1_4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.status1_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.status1_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.status2_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.status2_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.status2_3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.status2_4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.status2_5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.status2_6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spelling.ResumeLayout(False)
        Me.spelling.PerformLayout()
        Me.special1.ResumeLayout(False)
        Me.special1.PerformLayout()
        Me.enemies_number.ResumeLayout(False)
        Me.assist.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents defend As Button
    Friend WithEvents defendt As Label
    Friend WithEvents attackt As Label
    Friend WithEvents attack As Button
    Friend WithEvents magict As Label
    Friend WithEvents magic As Button
    Friend WithEvents battler As PictureBox
    Friend WithEvents life2t As Label
    Friend WithEvents cd2t As Label
    Friend WithEvents cd1t As Label
    Friend WithEvents life1t As Label
    Friend WithEvents title As Label
    Friend WithEvents setlife1 As Timer
    Friend WithEvents setlife2 As Timer
    Friend WithEvents popout1 As Label
    Friend WithEvents popout2 As Label
    Friend WithEvents settop1 As Timer
    Friend WithEvents settop2 As Timer
    Friend WithEvents cool1 As Timer
    Friend WithEvents cool2 As Timer
    Friend WithEvents tutorial As GroupBox
    Friend WithEvents content As Label
    Friend WithEvents skip As Button
    Friend WithEvents next_ As Button
    Friend WithEvents titleshow As Timer
    Friend WithEvents EnemyAction As Timer
    Friend WithEvents hidecool1 As Timer
    Friend WithEvents hidecool2 As Timer
    Friend WithEvents shining As Timer
    Friend WithEvents defeat As Timer
    Friend WithEvents status1_6 As PictureBox
    Friend WithEvents status1_5 As PictureBox
    Friend WithEvents status1_3 As PictureBox
    Friend WithEvents status1_4 As PictureBox
    Friend WithEvents status1_1 As PictureBox
    Friend WithEvents status1_2 As PictureBox
    Friend WithEvents status2_1 As PictureBox
    Friend WithEvents status2_2 As PictureBox
    Friend WithEvents status2_3 As PictureBox
    Friend WithEvents status2_4 As PictureBox
    Friend WithEvents status2_5 As PictureBox
    Friend WithEvents status2_6 As PictureBox
    Friend WithEvents StatusImage As ImageList
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents StatusMove As Timer
    Friend WithEvents StatusCheck As Timer
    Friend WithEvents Timer1 As Timer
    Friend WithEvents spelling As GroupBox
    Friend WithEvents example As Label
    Friend WithEvents SpellBox As TextBox
    Friend WithEvents special1 As GroupBox
    Friend WithEvents next1 As Button
    Friend WithEvents content1 As Label
    Friend WithEvents secret As TextBox
    Friend WithEvents vocabulary As ListBox
    Friend WithEvents heal As Button
    Friend WithEvents enemies_number As GroupBox
    Friend WithEvents numberT As Label
    Friend WithEvents number As ProgressBar
    Friend WithEvents assist As GroupBox
    Friend WithEvents assist2t As Label
    Friend WithEvents assist2 As Button
    Friend WithEvents assist1t As Label
    Friend WithEvents assist1 As Button
    Friend WithEvents assist3 As Button
    Friend WithEvents assist3t As Label
    Friend WithEvents pause As Button
    Friend WithEvents paused As Label
    Friend WithEvents mana1t As Label
    Friend WithEvents mana2t As Label
    Friend WithEvents Mana1restore As Timer
    Friend WithEvents Mana2restore As Timer
    Friend WithEvents setmana1 As Timer
    Friend WithEvents setmana2 As Timer
    Friend WithEvents color1 As Timer
    Friend WithEvents color2 As Timer
    Friend WithEvents cd1b As Label
    Friend WithEvents cd1f As Label
    Friend WithEvents cd2f As Label
    Friend WithEvents cd2b As Label
    Friend WithEvents life1b As Label
    Friend WithEvents life1f As Label
    Friend WithEvents mana1b As Label
    Friend WithEvents mana1f As Label
    Friend WithEvents life2b As Label
    Friend WithEvents life2f As Label
    Friend WithEvents mana2b As Label
    Friend WithEvents mana2f As Label
    Friend WithEvents debug As Timer
End Class
