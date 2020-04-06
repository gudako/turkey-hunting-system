<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form19
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form19))
        Me.Atropos = New System.Windows.Forms.PictureBox()
        Me.backbar2 = New System.Windows.Forms.Label()
        Me.card0 = New System.Windows.Forms.PictureBox()
        Me.card1 = New System.Windows.Forms.PictureBox()
        Me.card2 = New System.Windows.Forms.PictureBox()
        Me.card3 = New System.Windows.Forms.PictureBox()
        Me.card4 = New System.Windows.Forms.PictureBox()
        Me.frontbar2 = New System.Windows.Forms.Label()
        Me.frontbar1 = New System.Windows.Forms.Label()
        Me.backbar1 = New System.Windows.Forms.Label()
        Me.draw_pile = New System.Windows.Forms.PictureBox()
        Me.discard_pile = New System.Windows.Forms.PictureBox()
        Me.discard_text = New System.Windows.Forms.Label()
        Me.draw_text = New System.Windows.Forms.Label()
        Me.board1 = New System.Windows.Forms.PictureBox()
        Me.board2 = New System.Windows.Forms.PictureBox()
        Me.damage_image = New System.Windows.Forms.ImageList(Me.components)
        Me.damage1 = New System.Windows.Forms.PictureBox()
        Me.damage2 = New System.Windows.Forms.PictureBox()
        Me.tiptext = New System.Windows.Forms.Label()
        Me.tutorial_box = New System.Windows.Forms.GroupBox()
        Me.tutorial_image6 = New System.Windows.Forms.PictureBox()
        Me.tutorial_image5 = New System.Windows.Forms.PictureBox()
        Me.tutorial_image4 = New System.Windows.Forms.PictureBox()
        Me.tutorial_image3 = New System.Windows.Forms.PictureBox()
        Me.tutorial_image2 = New System.Windows.Forms.PictureBox()
        Me.tutorial_image1 = New System.Windows.Forms.PictureBox()
        Me.tutorial_next = New System.Windows.Forms.Button()
        Me.tutorial = New System.Windows.Forms.Label()
        Me.card_list = New System.Windows.Forms.ImageList(Me.components)
        Me.status1_1 = New System.Windows.Forms.PictureBox()
        Me.status1_2 = New System.Windows.Forms.PictureBox()
        Me.status2_2 = New System.Windows.Forms.PictureBox()
        Me.status2_1 = New System.Windows.Forms.PictureBox()
        Me.status_list = New System.Windows.Forms.ImageList(Me.components)
        Me.spcard_list = New System.Windows.Forms.ImageList(Me.components)
        Me.MoveAtropos = New System.Windows.Forms.Timer(Me.components)
        Me.MoveCard = New System.Windows.Forms.Timer(Me.components)
        Me.status1_3 = New System.Windows.Forms.PictureBox()
        Me.status2_3 = New System.Windows.Forms.PictureBox()
        Me.TimeCost = New System.Windows.Forms.Timer(Me.components)
        Me.MoveCardEx = New System.Windows.Forms.Timer(Me.components)
        Me.healbutton = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.setlife1 = New System.Windows.Forms.Timer(Me.components)
        Me.setlife2 = New System.Windows.Forms.Timer(Me.components)
        Me.setdamage1 = New System.Windows.Forms.Timer(Me.components)
        Me.setdamage2 = New System.Windows.Forms.Timer(Me.components)
        Me.TurnWeaver = New System.Windows.Forms.Timer(Me.components)
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        CType(Me.Atropos,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.card0,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.card1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.card2,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.card3,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.card4,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.draw_pile,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.discard_pile,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.board1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.board2,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.damage1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.damage2,System.ComponentModel.ISupportInitialize).BeginInit
        Me.tutorial_box.SuspendLayout
        CType(Me.tutorial_image6,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tutorial_image5,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tutorial_image4,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tutorial_image3,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tutorial_image2,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tutorial_image1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.status1_1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.status1_2,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.status2_2,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.status2_1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.status1_3,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.status2_3,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'Atropos
        '
        Me.Atropos.BackColor = System.Drawing.Color.Transparent
        Me.Atropos.Image = CType(resources.GetObject("Atropos.Image"),System.Drawing.Image)
        Me.Atropos.Location = New System.Drawing.Point(26, 124)
        Me.Atropos.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Atropos.Name = "Atropos"
        Me.Atropos.Size = New System.Drawing.Size(660, 572)
        Me.Atropos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Atropos.TabIndex = 0
        Me.Atropos.TabStop = false
        '
        'backbar2
        '
        Me.backbar2.BackColor = System.Drawing.Color.White
        Me.backbar2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.backbar2.Location = New System.Drawing.Point(9, 488)
        Me.backbar2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.backbar2.Name = "backbar2"
        Me.backbar2.Size = New System.Drawing.Size(694, 26)
        Me.backbar2.TabIndex = 1
        '
        'card0
        '
        Me.card0.Image = CType(resources.GetObject("card0.Image"),System.Drawing.Image)
        Me.card0.Location = New System.Drawing.Point(9, 517)
        Me.card0.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.card0.Name = "card0"
        Me.card0.Size = New System.Drawing.Size(135, 169)
        Me.card0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.card0.TabIndex = 2
        Me.card0.TabStop = false
        Me.card0.Visible = false
        '
        'card1
        '
        Me.card1.Image = CType(resources.GetObject("card1.Image"),System.Drawing.Image)
        Me.card1.Location = New System.Drawing.Point(148, 517)
        Me.card1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.card1.Name = "card1"
        Me.card1.Size = New System.Drawing.Size(135, 169)
        Me.card1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.card1.TabIndex = 3
        Me.card1.TabStop = false
        Me.card1.Visible = false
        '
        'card2
        '
        Me.card2.Image = CType(resources.GetObject("card2.Image"),System.Drawing.Image)
        Me.card2.Location = New System.Drawing.Point(288, 517)
        Me.card2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.card2.Name = "card2"
        Me.card2.Size = New System.Drawing.Size(135, 169)
        Me.card2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.card2.TabIndex = 4
        Me.card2.TabStop = false
        Me.card2.Visible = false
        '
        'card3
        '
        Me.card3.Image = CType(resources.GetObject("card3.Image"),System.Drawing.Image)
        Me.card3.Location = New System.Drawing.Point(428, 517)
        Me.card3.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.card3.Name = "card3"
        Me.card3.Size = New System.Drawing.Size(135, 169)
        Me.card3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.card3.TabIndex = 5
        Me.card3.TabStop = false
        Me.card3.Visible = false
        '
        'card4
        '
        Me.card4.Image = CType(resources.GetObject("card4.Image"),System.Drawing.Image)
        Me.card4.Location = New System.Drawing.Point(567, 517)
        Me.card4.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.card4.Name = "card4"
        Me.card4.Size = New System.Drawing.Size(135, 169)
        Me.card4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.card4.TabIndex = 6
        Me.card4.TabStop = false
        Me.card4.Visible = false
        '
        'frontbar2
        '
        Me.frontbar2.BackColor = System.Drawing.Color.Lime
        Me.frontbar2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.frontbar2.Font = New System.Drawing.Font("SimHei", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134,Byte))
        Me.frontbar2.Location = New System.Drawing.Point(9, 488)
        Me.frontbar2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.frontbar2.Name = "frontbar2"
        Me.frontbar2.Size = New System.Drawing.Size(694, 26)
        Me.frontbar2.TabIndex = 7
        Me.frontbar2.Text = "100.0"
        Me.frontbar2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frontbar1
        '
        Me.frontbar1.BackColor = System.Drawing.Color.Lime
        Me.frontbar1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.frontbar1.Font = New System.Drawing.Font("SimHei", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134,Byte))
        Me.frontbar1.Location = New System.Drawing.Point(9, 8)
        Me.frontbar1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.frontbar1.Name = "frontbar1"
        Me.frontbar1.Size = New System.Drawing.Size(694, 26)
        Me.frontbar1.TabIndex = 9
        Me.frontbar1.Text = "100.0"
        Me.frontbar1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'backbar1
        '
        Me.backbar1.BackColor = System.Drawing.Color.White
        Me.backbar1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.backbar1.Location = New System.Drawing.Point(9, 8)
        Me.backbar1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.backbar1.Name = "backbar1"
        Me.backbar1.Size = New System.Drawing.Size(694, 26)
        Me.backbar1.TabIndex = 8
        '
        'draw_pile
        '
        Me.draw_pile.Image = CType(resources.GetObject("draw_pile.Image"),System.Drawing.Image)
        Me.draw_pile.Location = New System.Drawing.Point(9, 36)
        Me.draw_pile.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.draw_pile.Name = "draw_pile"
        Me.draw_pile.Size = New System.Drawing.Size(135, 169)
        Me.draw_pile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.draw_pile.TabIndex = 10
        Me.draw_pile.TabStop = false
        '
        'discard_pile
        '
        Me.discard_pile.Image = CType(resources.GetObject("discard_pile.Image"),System.Drawing.Image)
        Me.discard_pile.Location = New System.Drawing.Point(567, 36)
        Me.discard_pile.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.discard_pile.Name = "discard_pile"
        Me.discard_pile.Size = New System.Drawing.Size(135, 169)
        Me.discard_pile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.discard_pile.TabIndex = 11
        Me.discard_pile.TabStop = false
        Me.discard_pile.Visible = false
        '
        'discard_text
        '
        Me.discard_text.AutoSize = true
        Me.discard_text.BackColor = System.Drawing.Color.Transparent
        Me.discard_text.Font = New System.Drawing.Font("DengXian", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134,Byte))
        Me.discard_text.Location = New System.Drawing.Point(591, 180)
        Me.discard_text.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.discard_text.Name = "discard_text"
        Me.discard_text.Size = New System.Drawing.Size(118, 23)
        Me.discard_text.TabIndex = 12
        Me.discard_text.Text = "discard pile"
        '
        'draw_text
        '
        Me.draw_text.AutoSize = true
        Me.draw_text.BackColor = System.Drawing.Color.Transparent
        Me.draw_text.Font = New System.Drawing.Font("DengXian", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134,Byte))
        Me.draw_text.Location = New System.Drawing.Point(9, 180)
        Me.draw_text.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.draw_text.Name = "draw_text"
        Me.draw_text.Size = New System.Drawing.Size(96, 23)
        Me.draw_text.TabIndex = 13
        Me.draw_text.Text = "draw pile"
        '
        'board1
        '
        Me.board1.Image = CType(resources.GetObject("board1.Image"),System.Drawing.Image)
        Me.board1.Location = New System.Drawing.Point(9, 225)
        Me.board1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.board1.Name = "board1"
        Me.board1.Size = New System.Drawing.Size(210, 260)
        Me.board1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.board1.TabIndex = 14
        Me.board1.TabStop = false
        Me.board1.Visible = false
        '
        'board2
        '
        Me.board2.Image = CType(resources.GetObject("board2.Image"),System.Drawing.Image)
        Me.board2.Location = New System.Drawing.Point(492, 225)
        Me.board2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.board2.Name = "board2"
        Me.board2.Size = New System.Drawing.Size(210, 260)
        Me.board2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.board2.TabIndex = 15
        Me.board2.TabStop = false
        Me.board2.Visible = false
        '
        'damage_image
        '
        Me.damage_image.ImageStream = CType(resources.GetObject("damage_image.ImageStream"),System.Windows.Forms.ImageListStreamer)
        Me.damage_image.TransparentColor = System.Drawing.Color.Transparent
        Me.damage_image.Images.SetKeyName(0, "0.5.png")
        Me.damage_image.Images.SetKeyName(1, "1.png")
        Me.damage_image.Images.SetKeyName(2, "2.png")
        Me.damage_image.Images.SetKeyName(3, "3.png")
        Me.damage_image.Images.SetKeyName(4, "4.png")
        Me.damage_image.Images.SetKeyName(5, "5.png")
        Me.damage_image.Images.SetKeyName(6, "6.png")
        Me.damage_image.Images.SetKeyName(7, "8.png")
        Me.damage_image.Images.SetKeyName(8, "10.png")
        Me.damage_image.Images.SetKeyName(9, "+4.png")
        Me.damage_image.Images.SetKeyName(10, "+8.png")
        Me.damage_image.Images.SetKeyName(11, "timed.png")
        Me.damage_image.Images.SetKeyName(12, "stunned.png")
        Me.damage_image.Images.SetKeyName(13, "confused.png")
        Me.damage_image.Images.SetKeyName(14, "power-up.png")
        Me.damage_image.Images.SetKeyName(15, "1.5.png")
        '
        'damage1
        '
        Me.damage1.BackColor = System.Drawing.Color.Transparent
        Me.damage1.Image = CType(resources.GetObject("damage1.Image"),System.Drawing.Image)
        Me.damage1.Location = New System.Drawing.Point(35, 277)
        Me.damage1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.damage1.Name = "damage1"
        Me.damage1.Size = New System.Drawing.Size(158, 157)
        Me.damage1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.damage1.TabIndex = 16
        Me.damage1.TabStop = false
        Me.damage1.Visible = false
        '
        'damage2
        '
        Me.damage2.BackColor = System.Drawing.Color.Transparent
        Me.damage2.Image = CType(resources.GetObject("damage2.Image"),System.Drawing.Image)
        Me.damage2.Location = New System.Drawing.Point(518, 277)
        Me.damage2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.damage2.Name = "damage2"
        Me.damage2.Size = New System.Drawing.Size(158, 157)
        Me.damage2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.damage2.TabIndex = 17
        Me.damage2.TabStop = false
        Me.damage2.Visible = false
        '
        'tiptext
        '
        Me.tiptext.BackColor = System.Drawing.Color.Transparent
        Me.tiptext.Font = New System.Drawing.Font("DengXian", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134,Byte))
        Me.tiptext.ForeColor = System.Drawing.Color.White
        Me.tiptext.Location = New System.Drawing.Point(148, 36)
        Me.tiptext.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.tiptext.Name = "tiptext"
        Me.tiptext.Size = New System.Drawing.Size(414, 85)
        Me.tiptext.TabIndex = 18
        '
        'tutorial_box
        '
        Me.tutorial_box.BackColor = System.Drawing.Color.Transparent
        Me.tutorial_box.Controls.Add(Me.tutorial_image6)
        Me.tutorial_box.Controls.Add(Me.tutorial_image5)
        Me.tutorial_box.Controls.Add(Me.tutorial_image4)
        Me.tutorial_box.Controls.Add(Me.tutorial_image3)
        Me.tutorial_box.Controls.Add(Me.tutorial_image2)
        Me.tutorial_box.Controls.Add(Me.tutorial_image1)
        Me.tutorial_box.Controls.Add(Me.tutorial_next)
        Me.tutorial_box.Controls.Add(Me.tutorial)
        Me.tutorial_box.Font = New System.Drawing.Font("Microsoft YaHei", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134,Byte))
        Me.tutorial_box.ForeColor = System.Drawing.Color.White
        Me.tutorial_box.Location = New System.Drawing.Point(148, 124)
        Me.tutorial_box.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.tutorial_box.Name = "tutorial_box"
        Me.tutorial_box.Padding = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.tutorial_box.Size = New System.Drawing.Size(414, 361)
        Me.tutorial_box.TabIndex = 19
        Me.tutorial_box.TabStop = false
        Me.tutorial_box.Text = "Tutorial"
        '
        'tutorial_image6
        '
        Me.tutorial_image6.BackColor = System.Drawing.Color.Transparent
        Me.tutorial_image6.Image = CType(resources.GetObject("tutorial_image6.Image"),System.Drawing.Image)
        Me.tutorial_image6.Location = New System.Drawing.Point(276, 165)
        Me.tutorial_image6.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.tutorial_image6.Name = "tutorial_image6"
        Me.tutorial_image6.Size = New System.Drawing.Size(131, 152)
        Me.tutorial_image6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.tutorial_image6.TabIndex = 7
        Me.tutorial_image6.TabStop = false
        Me.tutorial_image6.Visible = false
        '
        'tutorial_image5
        '
        Me.tutorial_image5.BackColor = System.Drawing.Color.Transparent
        Me.tutorial_image5.Image = CType(resources.GetObject("tutorial_image5.Image"),System.Drawing.Image)
        Me.tutorial_image5.Location = New System.Drawing.Point(140, 165)
        Me.tutorial_image5.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.tutorial_image5.Name = "tutorial_image5"
        Me.tutorial_image5.Size = New System.Drawing.Size(131, 152)
        Me.tutorial_image5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.tutorial_image5.TabIndex = 6
        Me.tutorial_image5.TabStop = false
        Me.tutorial_image5.Visible = false
        '
        'tutorial_image4
        '
        Me.tutorial_image4.BackColor = System.Drawing.Color.Transparent
        Me.tutorial_image4.Image = CType(resources.GetObject("tutorial_image4.Image"),System.Drawing.Image)
        Me.tutorial_image4.Location = New System.Drawing.Point(4, 165)
        Me.tutorial_image4.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.tutorial_image4.Name = "tutorial_image4"
        Me.tutorial_image4.Size = New System.Drawing.Size(131, 152)
        Me.tutorial_image4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.tutorial_image4.TabIndex = 5
        Me.tutorial_image4.TabStop = false
        Me.tutorial_image4.Visible = false
        '
        'tutorial_image3
        '
        Me.tutorial_image3.BackColor = System.Drawing.Color.White
        Me.tutorial_image3.Image = CType(resources.GetObject("tutorial_image3.Image"),System.Drawing.Image)
        Me.tutorial_image3.Location = New System.Drawing.Point(4, 56)
        Me.tutorial_image3.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.tutorial_image3.Name = "tutorial_image3"
        Me.tutorial_image3.Size = New System.Drawing.Size(405, 260)
        Me.tutorial_image3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.tutorial_image3.TabIndex = 4
        Me.tutorial_image3.TabStop = false
        Me.tutorial_image3.Visible = false
        '
        'tutorial_image2
        '
        Me.tutorial_image2.BackColor = System.Drawing.Color.White
        Me.tutorial_image2.Image = CType(resources.GetObject("tutorial_image2.Image"),System.Drawing.Image)
        Me.tutorial_image2.Location = New System.Drawing.Point(4, 56)
        Me.tutorial_image2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.tutorial_image2.Name = "tutorial_image2"
        Me.tutorial_image2.Size = New System.Drawing.Size(405, 260)
        Me.tutorial_image2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.tutorial_image2.TabIndex = 3
        Me.tutorial_image2.TabStop = false
        Me.tutorial_image2.Visible = false
        '
        'tutorial_image1
        '
        Me.tutorial_image1.BackColor = System.Drawing.Color.White
        Me.tutorial_image1.Image = CType(resources.GetObject("tutorial_image1.Image"),System.Drawing.Image)
        Me.tutorial_image1.Location = New System.Drawing.Point(140, 56)
        Me.tutorial_image1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.tutorial_image1.Name = "tutorial_image1"
        Me.tutorial_image1.Size = New System.Drawing.Size(270, 260)
        Me.tutorial_image1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.tutorial_image1.TabIndex = 2
        Me.tutorial_image1.TabStop = false
        Me.tutorial_image1.Visible = false
        '
        'tutorial_next
        '
        Me.tutorial_next.BackColor = System.Drawing.Color.Black
        Me.tutorial_next.Location = New System.Drawing.Point(320, 322)
        Me.tutorial_next.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.tutorial_next.Name = "tutorial_next"
        Me.tutorial_next.Size = New System.Drawing.Size(90, 35)
        Me.tutorial_next.TabIndex = 1
        Me.tutorial_next.Text = "Next"
        Me.tutorial_next.UseVisualStyleBackColor = false
        '
        'tutorial
        '
        Me.tutorial.Location = New System.Drawing.Point(4, 29)
        Me.tutorial.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.tutorial.Name = "tutorial"
        Me.tutorial.Size = New System.Drawing.Size(405, 289)
        Me.tutorial.TabIndex = 0
        Me.tutorial.Text = "Here is the detail of the restraint relationship."&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"""half"" means"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"0.5 damage."&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"O"& _ 
    "nce finished,"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"the loser of the"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"combat will"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"corresponding-"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"ly get the"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"damage"& _ 
    "."
        '
        'card_list
        '
        Me.card_list.ImageStream = CType(resources.GetObject("card_list.ImageStream"),System.Windows.Forms.ImageListStreamer)
        Me.card_list.TransparentColor = System.Drawing.Color.Transparent
        Me.card_list.Images.SetKeyName(0, "card back.png")
        Me.card_list.Images.SetKeyName(1, "rooster.png")
        Me.card_list.Images.SetKeyName(2, "big white hen.png")
        Me.card_list.Images.SetKeyName(3, "turkey.png")
        Me.card_list.Images.SetKeyName(4, "witch.png")
        Me.card_list.Images.SetKeyName(5, "Mr.Duck.png")
        Me.card_list.Images.SetKeyName(6, "generate.png")
        Me.card_list.Images.SetKeyName(7, "vanish.png")
        Me.card_list.Images.SetKeyName(8, "release.png")
        Me.card_list.Images.SetKeyName(9, "shine.png")
        Me.card_list.Images.SetKeyName(10, "reflect.png")
        Me.card_list.Images.SetKeyName(11, "static.png")
        Me.card_list.Images.SetKeyName(12, "contort time.png")
        Me.card_list.Images.SetKeyName(13, "explode.png")
        Me.card_list.Images.SetKeyName(14, "flunk.png")
        Me.card_list.Images.SetKeyName(15, "useless card.png")
        Me.card_list.Images.SetKeyName(16, "null.png")
        '
        'status1_1
        '
        Me.status1_1.Image = CType(resources.GetObject("status1_1.Image"),System.Drawing.Image)
        Me.status1_1.Location = New System.Drawing.Point(628, 10)
        Me.status1_1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.status1_1.Name = "status1_1"
        Me.status1_1.Size = New System.Drawing.Size(72, 21)
        Me.status1_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.status1_1.TabIndex = 20
        Me.status1_1.TabStop = false
        Me.status1_1.Visible = false
        '
        'status1_2
        '
        Me.status1_2.Image = CType(resources.GetObject("status1_2.Image"),System.Drawing.Image)
        Me.status1_2.Location = New System.Drawing.Point(552, 10)
        Me.status1_2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.status1_2.Name = "status1_2"
        Me.status1_2.Size = New System.Drawing.Size(72, 21)
        Me.status1_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.status1_2.TabIndex = 21
        Me.status1_2.TabStop = false
        Me.status1_2.Visible = false
        '
        'status2_2
        '
        Me.status2_2.Image = CType(resources.GetObject("status2_2.Image"),System.Drawing.Image)
        Me.status2_2.Location = New System.Drawing.Point(552, 491)
        Me.status2_2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.status2_2.Name = "status2_2"
        Me.status2_2.Size = New System.Drawing.Size(72, 21)
        Me.status2_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.status2_2.TabIndex = 23
        Me.status2_2.TabStop = false
        Me.status2_2.Visible = false
        '
        'status2_1
        '
        Me.status2_1.Image = CType(resources.GetObject("status2_1.Image"),System.Drawing.Image)
        Me.status2_1.Location = New System.Drawing.Point(628, 491)
        Me.status2_1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.status2_1.Name = "status2_1"
        Me.status2_1.Size = New System.Drawing.Size(72, 21)
        Me.status2_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.status2_1.TabIndex = 22
        Me.status2_1.TabStop = false
        Me.status2_1.Visible = false
        '
        'status_list
        '
        Me.status_list.ImageStream = CType(resources.GetObject("status_list.ImageStream"),System.Windows.Forms.ImageListStreamer)
        Me.status_list.TransparentColor = System.Drawing.Color.Transparent
        Me.status_list.Images.SetKeyName(0, "timed.png")
        Me.status_list.Images.SetKeyName(1, "stunned.png")
        Me.status_list.Images.SetKeyName(2, "confused.png")
        Me.status_list.Images.SetKeyName(3, "power-up.png")
        '
        'spcard_list
        '
        Me.spcard_list.ImageStream = CType(resources.GetObject("spcard_list.ImageStream"),System.Windows.Forms.ImageListStreamer)
        Me.spcard_list.TransparentColor = System.Drawing.Color.Transparent
        Me.spcard_list.Images.SetKeyName(0, "card_game_icon_128px_538639_easyicon.netf.png")
        Me.spcard_list.Images.SetKeyName(1, "鸭哥.png")
        Me.spcard_list.Images.SetKeyName(2, "static.png")
        '
        'MoveAtropos
        '
        Me.MoveAtropos.Interval = 25
        '
        'MoveCard
        '
        Me.MoveCard.Interval = 10
        '
        'status1_3
        '
        Me.status1_3.Image = CType(resources.GetObject("status1_3.Image"),System.Drawing.Image)
        Me.status1_3.Location = New System.Drawing.Point(476, 10)
        Me.status1_3.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.status1_3.Name = "status1_3"
        Me.status1_3.Size = New System.Drawing.Size(72, 21)
        Me.status1_3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.status1_3.TabIndex = 24
        Me.status1_3.TabStop = false
        Me.status1_3.Visible = false
        '
        'status2_3
        '
        Me.status2_3.Image = CType(resources.GetObject("status2_3.Image"),System.Drawing.Image)
        Me.status2_3.Location = New System.Drawing.Point(476, 491)
        Me.status2_3.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.status2_3.Name = "status2_3"
        Me.status2_3.Size = New System.Drawing.Size(72, 21)
        Me.status2_3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.status2_3.TabIndex = 25
        Me.status2_3.TabStop = false
        Me.status2_3.Visible = false
        '
        'TimeCost
        '
        Me.TimeCost.Interval = 1000
        '
        'MoveCardEx
        '
        Me.MoveCardEx.Interval = 10
        '
        'healbutton
        '
        Me.healbutton.Enabled = false
        Me.healbutton.Location = New System.Drawing.Point(655, 676)
        Me.healbutton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.healbutton.Name = "healbutton"
        Me.healbutton.Size = New System.Drawing.Size(56, 20)
        Me.healbutton.TabIndex = 26
        Me.healbutton.Text = "Heal(0)"
        Me.healbutton.UseVisualStyleBackColor = true
        Me.healbutton.Visible = false
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 15000
        Me.ToolTip1.InitialDelay = 500
        Me.ToolTip1.ReshowDelay = 100
        '
        'setlife1
        '
        Me.setlife1.Interval = 50
        '
        'setlife2
        '
        Me.setlife2.Interval = 50
        '
        'setdamage1
        '
        Me.setdamage1.Interval = 25
        '
        'setdamage2
        '
        Me.setdamage2.Interval = 25
        '
        'TurnWeaver
        '
        Me.TurnWeaver.Interval = 50
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = true
        Me.LinkLabel1.Location = New System.Drawing.Point(146, 34)
        Me.LinkLabel1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(314, 13)
        Me.LinkLabel1.TabIndex = 27
        Me.LinkLabel1.TabStop = true
        Me.LinkLabel1.Text = "THIS BACKGROUND IS REMOVED DUE TO DEBUG REASON"
        '
        'Form19
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"),System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(711, 696)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.status2_3)
        Me.Controls.Add(Me.status1_3)
        Me.Controls.Add(Me.status2_2)
        Me.Controls.Add(Me.status2_1)
        Me.Controls.Add(Me.status1_2)
        Me.Controls.Add(Me.status1_1)
        Me.Controls.Add(Me.tutorial_box)
        Me.Controls.Add(Me.tiptext)
        Me.Controls.Add(Me.damage2)
        Me.Controls.Add(Me.damage1)
        Me.Controls.Add(Me.board2)
        Me.Controls.Add(Me.board1)
        Me.Controls.Add(Me.draw_text)
        Me.Controls.Add(Me.discard_text)
        Me.Controls.Add(Me.discard_pile)
        Me.Controls.Add(Me.draw_pile)
        Me.Controls.Add(Me.frontbar1)
        Me.Controls.Add(Me.backbar1)
        Me.Controls.Add(Me.frontbar2)
        Me.Controls.Add(Me.card4)
        Me.Controls.Add(Me.card3)
        Me.Controls.Add(Me.card2)
        Me.Controls.Add(Me.card1)
        Me.Controls.Add(Me.card0)
        Me.Controls.Add(Me.backbar2)
        Me.Controls.Add(Me.healbutton)
        Me.Controls.Add(Me.Atropos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.MaximizeBox = false
        Me.Name = "Form19"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Battle of destiny"
        CType(Me.Atropos,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.card0,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.card1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.card2,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.card3,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.card4,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.draw_pile,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.discard_pile,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.board1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.board2,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.damage1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.damage2,System.ComponentModel.ISupportInitialize).EndInit
        Me.tutorial_box.ResumeLayout(false)
        CType(Me.tutorial_image6,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tutorial_image5,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tutorial_image4,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tutorial_image3,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tutorial_image2,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tutorial_image1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.status1_1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.status1_2,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.status2_2,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.status2_1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.status1_3,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.status2_3,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents Atropos As PictureBox
    Friend WithEvents backbar2 As Label
    Friend WithEvents card0 As PictureBox
    Friend WithEvents card1 As PictureBox
    Friend WithEvents card2 As PictureBox
    Friend WithEvents card3 As PictureBox
    Friend WithEvents card4 As PictureBox
    Friend WithEvents frontbar2 As Label
    Friend WithEvents frontbar1 As Label
    Friend WithEvents backbar1 As Label
    Friend WithEvents draw_pile As PictureBox
    Friend WithEvents discard_pile As PictureBox
    Friend WithEvents discard_text As Label
    Friend WithEvents draw_text As Label
    Friend WithEvents board1 As PictureBox
    Friend WithEvents board2 As PictureBox
    Friend WithEvents damage_image As ImageList
    Friend WithEvents damage1 As PictureBox
    Friend WithEvents damage2 As PictureBox
    Friend WithEvents tiptext As Label
    Friend WithEvents tutorial_box As GroupBox
    Friend WithEvents tutorial_next As Button
    Friend WithEvents tutorial As Label
    Friend WithEvents card_list As ImageList
    Friend WithEvents tutorial_image1 As PictureBox
    Friend WithEvents tutorial_image2 As PictureBox
    Friend WithEvents status1_1 As PictureBox
    Friend WithEvents status1_2 As PictureBox
    Friend WithEvents status2_2 As PictureBox
    Friend WithEvents status2_1 As PictureBox
    Friend WithEvents status_list As ImageList
    Friend WithEvents tutorial_image3 As PictureBox
    Friend WithEvents tutorial_image6 As PictureBox
    Friend WithEvents tutorial_image5 As PictureBox
    Friend WithEvents tutorial_image4 As PictureBox
    Friend WithEvents spcard_list As ImageList
    Friend WithEvents MoveAtropos As Timer
    Friend WithEvents MoveCard As Timer
    Friend WithEvents status1_3 As PictureBox
    Friend WithEvents status2_3 As PictureBox
    Friend WithEvents TimeCost As Timer
    Friend WithEvents MoveCardEx As Timer
    Friend WithEvents healbutton As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents setlife1 As Timer
    Friend WithEvents setlife2 As Timer
    Friend WithEvents setdamage1 As Timer
    Friend WithEvents setdamage2 As Timer
    Friend WithEvents TurnWeaver As Timer
    Friend WithEvents LinkLabel1 As LinkLabel
End Class
