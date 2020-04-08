Imports System.Drawing.Imaging

Public Class Form20
    ''' <summary>
    '''     当你使用实际数字为坐标(Size/Location)赋值时，应该乘以相应的缩放值，因为屏幕将会给出一定比例的缩放。
    ''' </summary>
    Private ReadOnly ZoomX As Single = 0.75

    ''' <summary>
    '''     当你使用实际数字为坐标(Size/Location)赋值时，应该乘以相应的缩放值，因为屏幕将会给出一定比例的缩放。
    ''' </summary>
    Private ReadOnly ZoomY As Single = 0.8

    ''' <summary>
    '''     控件可以强制设置Unable值来组织阻止操作，Unable为True时，用户不能进行操作。
    ''' </summary>
    Private Unable As Boolean = False

    ''' <summary>
    '''     这些参数都用于移动物品(得到或失去物品)。
    ''' </summary>
    Private ReadOnly MovingItem As New PictureBox

    ''' <summary>
    '''     这些参数都用于移动物品(得到或失去物品)。
    ''' </summary>
    Private MoveSource As Control,
            MoveTarget As Control,
            MoveItemTab As Integer = 0,
            ItemMoveMode As MoveMode,
            AffectCode_ As Integer

    ''' <summary>
    '''     玩家所持物品。
    ''' </summary>
    Public Items As New ListBox

    ''' <summary>
    '''     物品栏中的格子。
    ''' </summary>
    Private ReadOnly ItemBricks(5) As PictureBox

    ''' <summary>
    '''     物品栏中的格子。
    ''' </summary>
    Private ItemTab As Integer = 0

    Dim ReadOnly MissionSummoner As New Button With {.Text = "←"}
    Dim ReadOnly SceneBrick As New PictureBox With {.SizeMode = PictureBoxSizeMode.StretchImage}
    Dim SceneChangeMode As SwitchMode, ClimbSpeed_ As Single
    Dim ReadOnly Actor As New PictureBox With {.BackColor = Color.Transparent, .SizeMode = PictureBoxSizeMode.Zoom}

    Dim ReadOnly _
        dialogue As _
            New Label _
        With {.Font = New Font("微软雅黑", 16.2!, FontStyle.Regular, GraphicsUnit.Point, 134), .AutoSize = False,
        .BackColor = Color.Transparent, .Visible = False}

    ''' <summary>
    '''     决定修改PictureBox的方式。
    ''' </summary>
    Enum MoveMode
        ''' <summary>
        '''     移动。在这种情况下，MoveSource成为其初始点，一直移动到MoveTarget所在点。
        ''' </summary>
        Move
        ''' <summary>
        '''     PictureBox将一直缩放到0，然后计时器停止。其中心一直围绕MoveSource。
        ''' </summary>
        Narrow
        ''' <summary>
        '''     PictureBox围绕MoveSource，一直扩大到MoveSource的大小。其中心一直围绕MoveSource。其原始大小应该小于MoveSource。
        ''' </summary>
        Enlarge
    End Enum

    Private Sub Form20_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '控件的位置调整。
        mission.Items.Clear()
        mission_box.Size = New Size(300*ZoomX, 400*ZoomY)
        mission_report.Size = New Size(300*ZoomX, 300*ZoomY)
        mission_box.Location = New Point(scene.Width, (scene.Height - mission_box.Height)/2)
        mission_report.Location = New Point(- mission_report.Width, (scene.Height - mission_report.Height)/2)
        Actor.Size = scene.Size
        Actor.Location = New Point(0, scene.Height)
        dialogue.Size = New Size(scene.Width, 70)
        dialogue.Location = New Point(0, 0)
        Actor.BringToFront()
        itemlist.BringToFront()
        Controls.Add(Actor)
        Controls.Add(dialogue)
        Actor.Parent = scene
        dialogue.Parent = Actor
        Actor.BackColor = Color.Transparent
        dialogue.BackColor = Color.Transparent
        AddHandler Actor.Click, AddressOf Actor_Click
        '数组设定。
        ItemBricks(0) = item0
        ItemBricks(1) = item1
        ItemBricks(2) = item2
        ItemBricks(3) = item3
        ItemBricks(4) = item4
        ItemBricks(5) = item5
        '任务控件
        MissionSummoner.Location = New Point(scene.Width - mission_back.Width, mission_box.Top + mission_back.Top)
        MissionSummoner.Size = mission_back.Size
        Controls.Add(MissionSummoner)
        MissionSummoner.BringToFront()
        AddHandler MissionSummoner.Click, AddressOf MissionSummoner_Click
        SceneInitialize()
        Form1.NoMoreForm1 = True
        subActor.Visible = False
        Actor.Visible = False
    End Sub

    Private Sub Actor_Click()
        deselect()
    End Sub

    Private Sub MissionSummoner_Click()
        If Enable() = False Or Actor.Visible Then Exit Sub
        MissionSummoner.Visible = False
        Move_missions.Enabled = True
        mission_box.Visible = True
        If mission.Items.Count < 5 Then mission.TileSize = New Size(194, 48) Else mission.TileSize = New Size(177, 48)
    End Sub

    Private Sub MoveItem_Tick(sender As Object, e As EventArgs) Handles MoveItem.Tick
        If scene.Location <> New Point(0, 0) Then Exit Sub
        If MoveItemTab = - 1 Then
            PuzzlingMover.Visible = True
            PuzzlingMover.BringToFront()
            PuzzlingMover.BackColor = Color.Transparent
            PuzzlingMover.Parent = scene
            Dim ToLeft As Integer = ZoomTarget.Left
            Dim ToTop As Integer = ZoomTarget.Top
            Dim MoveLeft As Integer = ToLeft - PuzzlingMover.Left
            Dim MoveTop As Integer = ToTop - PuzzlingMover.Top
            Dim hypotenuse As Integer = Math.Pow(Math.Pow(MoveLeft, 2) + Math.Pow(MoveTop, 2), 0.5)
            Dim average As Integer = MoveSpeedPuzzling/(1 + Math.Abs(MoveTop)/Math.Abs(MoveLeft))
            Dim PerLeft As Integer = 1*average
            Dim PerTop As Integer = MoveSpeedPuzzling - PerLeft
            PuzzlingMover.Size =
                New Size((1 - hypotenuse/TotalLong)*(ZoomTarget.Width - ZoomSource.Width) + ZoomSource.Width,
                         (1 - hypotenuse/TotalLong)*(ZoomTarget.Height - ZoomSource.Height) + ZoomSource.Height)
            If MoveTop >= MoveSpeedPuzzling Then
                PuzzlingMover.Top += PerTop
            ElseIf MoveTop <= - MoveSpeedPuzzling Then
                PuzzlingMover.Top -= PerTop
            End If
            If MoveLeft >= MoveSpeedPuzzling Then
                PuzzlingMover.Left += PerLeft
            ElseIf MoveLeft <= - MoveSpeedPuzzling Then
                PuzzlingMover.Left -= PerLeft
            End If
            If _
                (MoveTop > - MoveSpeedPuzzling And MoveTop < MoveSpeedPuzzling) And
                (MoveLeft > - MoveSpeedPuzzling And MoveLeft < MoveSpeedPuzzling) Then
                MoveItem.Enabled = False
                Controls.Remove(PuzzlingMover)
                PuzzlingMover.Visible = False
                Affect(AffectCode_)
            End If
        ElseIf ItemMoveMode = MoveMode.Move Then
            Dim ToLeft As Integer
            Dim ToTop As Integer
            If MoveItemTab = 0 Then
                ToLeft = itemlist.Left + MoveTarget.Left + MoveTarget.Width/2 - MovingItem.Width/2
                ToTop = itemlist.Top + MoveTarget.Top + MoveTarget.Height/2 - MovingItem.Height/2
            Else
                ToLeft = MoveTarget.Left + MoveTarget.Width/2 - MovingItem.Width/2
                ToTop = MoveTarget.Top + MoveTarget.Height/2 - MovingItem.Height/2
            End If
            Dim MoveLeft As Integer = ToLeft - MovingItem.Left
            Dim MoveTop As Integer = ToTop - MovingItem.Top
            Dim average As Integer = 10/(1 + Math.Abs(MoveTop)/Math.Abs(MoveLeft))
            Dim PerLeft As Integer = 1*average
            Dim PerTop As Integer = 10 - PerLeft
            If MoveTop >= 10 Then
                MovingItem.Top += PerTop
            ElseIf MoveTop <= - 10 Then
                MovingItem.Top -= PerTop
            End If
            If MoveLeft >= 10 Then
                MovingItem.Left += PerLeft
            ElseIf MoveLeft <= - 10 Then
                MovingItem.Left -= PerLeft
            End If
            If MovingItem.Bottom <= scene.Bottom Then
                MovingItem.Parent = scene
                MovingItem.BorderStyle = BorderStyle.None
                MovingItem.BackColor = Color.Transparent
            ElseIf MoveItemTab = 0 Then
                MovingItem.Parent = Me
                MovingItem.BorderStyle = BorderStyle.FixedSingle
                MovingItem.BackColor = Color.White
            End If
            MovingItem.BringToFront()
            If (MoveTop > - 10 And MoveTop < 10) And (MoveLeft > - 10 And MoveLeft < 10) Then
                If MoveItemTab = 0 Then
                    refresh_item()
                    MoveItem.Enabled = False
                    Controls.Remove(MovingItem)
                ElseIf MoveItemTab = 1 Then
                    ItemMoveMode = MoveMode.Narrow
                End If
            End If
        ElseIf ItemMoveMode = MoveMode.Narrow Then
            MovingItem.Width -= 2
            MovingItem.Height -= 2
            MovingItem.Left = MoveTarget.Left + MoveTarget.Width/2 - MovingItem.Width/2
            MovingItem.Top = MoveTarget.Top + MoveTarget.Height/2 - MovingItem.Height/2
            If MovingItem.Width < 2 Or MovingItem.Height < 2 Then
                MoveItem.Enabled = False
                Controls.Remove(MovingItem)
                Affect(AffectCode_)
            End If
            MovingItem.BringToFront()
        ElseIf ItemMoveMode = MoveMode.Enlarge Then
            MovingItem.Width += 2
            MovingItem.Height += 2
            MovingItem.Left = MoveSource.Left + MoveSource.Width/2 - MovingItem.Width/2
            MovingItem.Top = MoveSource.Top + MoveSource.Height/2 - MovingItem.Height/2
            If MovingItem.Width > item1.Width - 2 Or MovingItem.Height > item1.Height - 2 Then
                ItemMoveMode = MoveMode.Move
            End If
            MovingItem.BringToFront()
        End If
    End Sub

    ''' <summary>
    '''     若你从存档跳转到这里，应该经过这些代码进行初始化。
    ''' </summary>
    Public Sub ImportFromRecord()
        For x = 0 To My.Settings.missions.Split("/").Count - 1
            Dim NewMission As String = My.Settings.missions.Split("/")(x)
            If NewMission.Split(";").Count <= 1 Then Continue For
            Dim NewListViewItem As New ListViewItem
            With NewListViewItem
                .Text = NewMission.Split(";")(0)
                .ToolTipText = NewMission.Split(";")(1)
                .ImageIndex = NewMission.Split(";")(2)
                .Tag = NewMission.Split(";")(3)
                Dim YouTurtle As Integer = NewMission.Split(";")(3)
                .Group = mission.Groups(YouTurtle)
            End With
            mission.Items.Add(NewListViewItem)
        Next
        Items.Items.Clear()
        For x = 0 To My.Settings.items.Split("/").Count - 1
            If My.Settings.items.Split("/")(x) <> "" Then Items.Items.Add(My.Settings.items.Split("/")(x))
        Next
        refresh_item()
    End Sub

    Private Sub item0_Click(sender As Object, e As EventArgs) Handles item0.Click
        SelectThe(item0)
    End Sub

    ''' <summary>
    '''     所以，你选择你选择你你你你选择
    ''' </summary>
    ''' <param name="target">必须是物品PictureBox。</param>
    Private Sub SelectThe(target As Control)
        If Enable(False) = False Then Exit Sub
        deselect()
        If target.Tag <> "Null" Then
            target.BackColor = Color.Yellow
            leftmove.Visible = True
            rightmove.Visible = True
        End If
    End Sub

    ''' <summary>
    '''     解除所有选择。
    ''' </summary>
    Private Sub deselect()
        For x = 0 To 5
            ItemBricks(x).BackColor = Color.White
        Next
        leftmove.Visible = False
        rightmove.Visible = False
    End Sub

    Private Sub item1_Click(sender As Object, e As EventArgs) Handles item1.Click
        SelectThe(item1)
    End Sub

    Private Sub item2_Click(sender As Object, e As EventArgs) Handles item2.Click
        SelectThe(item2)
    End Sub

    Private Sub item3_Click(sender As Object, e As EventArgs) Handles item3.Click
        SelectThe(item3)
    End Sub

    Private Sub item4_Click(sender As Object, e As EventArgs) Handles item4.Click
        SelectThe(item4)
    End Sub

    Private Sub item5_Click(sender As Object, e As EventArgs) Handles item5.Click
        SelectThe(item5)
    End Sub

    Private Sub left__Click(sender As Object, e As EventArgs) Handles left_.Click
        If Enable() = False Then Exit Sub
        ItemTab = ItemTab - 1
        refresh_item()
    End Sub

    Private Sub right__Click(sender As Object, e As EventArgs) Handles right_.Click
        If Enable() = False Then Exit Sub
        ItemTab = ItemTab + 1
        refresh_item()
    End Sub

    Private Sub leftmove_Click(sender As Object, e As EventArgs) Handles leftmove.Click
        If Enable() = False Then Exit Sub
        Dim usable = False
        For x = 0 To Items.Items.Count - 1
            If SelectedItem().Tag.ToString = Items.Items(x) Then
                usable = True
                Items.SelectedItem = Items.Items(x)
            End If
        Next
        If usable Then
            Dim i As Integer = Items.SelectedIndex
            If i > 0 Then
                Dim obj As Object
                obj = Items.SelectedItem
                Items.Items.RemoveAt(i)
                Items.Items.Insert(i, Items.Items.Item(i - 1))
                Items.Items.RemoveAt(i - 1)
                Items.Items.Insert(i - 1, obj)
            End If
            refresh_item()
        End If
    End Sub

    Private Sub rightmove_Click(sender As Object, e As EventArgs) Handles rightmove.Click
        If Enable() = False Then Exit Sub
        Dim usable = False
        For x = 0 To Items.Items.Count - 1
            If SelectedItem().Tag.ToString = Items.Items(x) Then
                usable = True
                Items.SelectedItem = Items.Items(x)
            End If
        Next
        If usable Then
            Dim i As Integer = Items.SelectedIndex
            If i < Items.Items.Count - 1 Then
                Dim obj As Object
                obj = Items.SelectedItem
                Items.Items.RemoveAt(i)
                Items.Items.Insert(i + 1, obj)
            End If
            refresh_item()
        End If
    End Sub

    Private Sub Move_mission_report_Tick(sender As Object, e As EventArgs) Handles Move_mission_report.Tick
        If Move_mission_report.Tag = 0 Then
            mission_report.Left += 10
            If mission_report.Left >= 0 Then
                mission_report.Left = 0
                Move_mission_report.Tag = 1
            End If
        ElseIf Move_mission_report.Tag = - 1 Then
            mission_report.Left -= 10
            If mission_report.Left <= - mission_report.Width Then
                mission_report.Left = - mission_report.Width
                Move_mission_report.Tag = 0
                Move_mission_report.Enabled = False
            End If
        Else
            Move_mission_report.Tag += 1
            If Move_mission_report.Tag = 200 Then
                Move_mission_report.Tag = - 1
            End If
        End If
    End Sub

    ''' <summary>
    '''     从场景中移出所有部件（保留背景），在切换场景或场景对话时使用。
    ''' </summary>
    Private Sub mission_report_next_Click(sender As Object, e As EventArgs) Handles mission_report_next.Click
        If Move_mission_report.Enabled Then Move_mission_report.Tag = - 1
    End Sub

    Private Sub Move_missions_Tick(sender As Object, e As EventArgs) Handles Move_missions.Tick
        If Move_missions.Tag = 0 Then
            mission_box.Left -= 10
            If mission_box.Left <= scene.Width - mission_box.Width Then
                mission_box.Left = scene.Width - mission_box.Width
                Move_missions.Tag = 1
                Move_missions.Enabled = False
            End If
        Else
            mission_box.Left += 10
            If mission_box.Left >= MissionSummoner.Left Then
                mission_box.Left = MissionSummoner.Left
                Move_missions.Tag = 0
                Move_missions.Enabled = False
                MissionSummoner.Visible = True
                mission_box.Visible = False
            End If
        End If
    End Sub

    Private Sub mission_back_Click(sender As Object, e As EventArgs) Handles mission_back.Click
        Move_missions.Tag = 1
        Move_missions.Enabled = True
    End Sub

    ''' <summary>
    '''     对一个目标使用物品，并触发相应的事件。
    ''' </summary>
    ''' <param name="target">要使用到的目标控件。</param>
    ''' <param name="AffectCode">触发事件的序列号。</param>
    Private Sub UseItem(target As Control, AffectCode As Integer)
        With MovingItem
            .Image = SelectedItem.Image
            .BackColor = Color.Yellow
            .Location = New Point(SelectedItem.Left + itemlist.Left, SelectedItem.Top + itemlist.Top)
            .Size = SelectedItem.Size
            .BorderStyle = BorderStyle.FixedSingle
            .SizeMode = PictureBoxSizeMode.StretchImage
            .Parent = Me
            .BringToFront()
        End With
        Controls.Add(MovingItem)
        MoveSource = SelectedItem()
        MoveTarget = target
        AffectCode_ = AffectCode
        ItemMoveMode = MoveMode.Move
        MoveItem.Enabled = True
        Items.Items.Remove(SelectedItem.Tag)
        MoveItemTab = 1
        refresh_item()
        SelectedItem.BackColor = Color.White
    End Sub

    ''' <summary>
    '''     从一个指定目标处得到物品。
    ''' </summary>
    ''' <param name="source">得到物品的来源。</param>
    ''' <param name="ItemName">物品名称。</param>
    Private Sub GetItem(source As Control, ItemName As String)
        With MovingItem
            .Image = GetItemImage(ItemName)
            .BackColor = Color.Transparent
            .Location = source.Location
            .Size = New Size(0, 0)
            .BorderStyle = BorderStyle.None
            .SizeMode = PictureBoxSizeMode.StretchImage
            .Parent = scene
            .BringToFront()
        End With
        Controls.Add(MovingItem)
        MoveSource = source
        MoveTarget = ItemBricks(5)
        For x = 0 To 5
            If ItemBricks(x).Tag = "Null" Then
                MoveTarget = ItemBricks(x)
                Exit For
            End If
        Next
        ItemMoveMode = MoveMode.Enlarge
        MoveItem.Enabled = True
        Items.Items.Add(ItemName)
        MoveItemTab = 0
    End Sub

    ''' <summary>
    '''     确定用户是否可用操作。无论使用何种操作，都应先通过该检验。
    ''' </summary>
    ''' <returns>若检验失败，则操作直接被取消。</returns>
    Private Function Enable(Optional ByVal TurningOut As Boolean = True) As Boolean
        If Unable Then Return False
        If Controls.Contains(MovingItem) Then Return False
        If PuzzlingMover.Visible And Controls.Contains(PuzzlingMover) Then Return False
        If Move_missions.Enabled Or Move_mission_report.Enabled Then Return False
        If mission_report.Left = 0 Or mission_box.Left = scene.Width - mission_box.Width Then Return False
        If SceneWeaver.Enabled Then Return False
        If TurningOut And Actor.Visible Then Return False
        If message_box.Visible Then Return False
        Return True
    End Function

    Private AlphaForSW As Single, ImageForSW As Image

    Private Sub SceneWeaver_Tick(sender As Object, e As EventArgs) Handles SceneWeaver.Tick
        If SceneChangeMode = SwitchMode.drag_up Then
            scene.Top += 20
            SceneBrick.Top += 20
            If SceneBrick.Top >= 0 Then GoTo complete
        ElseIf SceneChangeMode = SwitchMode.drag_down Then
            scene.Top -= 20
            SceneBrick.Top -= 20
            If SceneBrick.Top <= 0 Then GoTo complete
        ElseIf SceneChangeMode = SwitchMode.drag_left Then
            scene.Left += 20
            SceneBrick.Left += 20
            If SceneBrick.Left >= 0 Then GoTo complete
        ElseIf SceneChangeMode = SwitchMode.drag_right Then
            scene.Left -= 20
            SceneBrick.Left -= 20
            If SceneBrick.Left <= 0 Then GoTo complete
        ElseIf SceneChangeMode = SwitchMode.gradual_change Then
            AlphaForSW += 0.1
            SceneBrick.Image = ChangeAlpha(ImageForSW, AlphaForSW)
            If AlphaForSW >= 1 Then GoTo complete
        End If
        Exit Sub
        complete:
        SceneWeaver.Enabled = False
        If AlphaForSW >= 1 Then SceneBrick.Visible = False
        scene.Image = Image.FromFile(GetFile("NewScene" & SceneWeaver.Tag))
        scene.Location = New Point(0, 0)
        Controls.Remove(SceneBrick)
        SceneAppears(SceneWeaver.Tag)
    End Sub

    Private ImportantTip As Boolean
    Private ReadOnly subActor As New PictureBox With {.BackColor = Color.Transparent, .Parent = Actor}

    Private ReadOnly _
        TipBox As Label = New Label _
        With {.Location = New Point(0, 0), .Font = New Font("微软雅黑", 16.2!, FontStyle.Regular, GraphicsUnit.Point, 134),
        .BackColor = Color.Black, .ForeColor = Color.White}

    Private Sub deletetip_Tick(sender As Object, e As EventArgs) Handles deletetip.Tick
        deletetip.Tag += 1
        Dim MaxInt = 120
        If ImportantTip Then MaxInt = 470
        If deletetip.Tag > MaxInt Then
            If (deletetip.Tag - MaxInt)*10 > 255 Then
                If ImportantTip Then TipBox.BackColor = Color.Black
                If ImportantTip = False Then TipBox.BackColor = Color.White
            Else
                If ImportantTip Then _
                    TipBox.BackColor = Color.FromArgb(255 - (deletetip.Tag - MaxInt)*10,
                                                      255 - (deletetip.Tag - MaxInt)*10,
                                                      255 - (deletetip.Tag - MaxInt)*10)
                If ImportantTip = False Then _
                    TipBox.BackColor = Color.FromArgb((deletetip.Tag - MaxInt)*10, (deletetip.Tag - MaxInt)*10,
                                                      (deletetip.Tag - MaxInt)*10)
            End If
        Else
            If deletetip.Tag*10 > 255 Then
                If ImportantTip Then TipBox.BackColor = Color.Red
                If ImportantTip = False Then TipBox.BackColor = Color.Black
            Else
                If ImportantTip Then TipBox.BackColor = Color.FromArgb(deletetip.Tag*10, 0, 0)
                If ImportantTip = False Then _
                    TipBox.BackColor = Color.FromArgb(255 - deletetip.Tag*10, 255 - deletetip.Tag*10,
                                                      255 - deletetip.Tag*10)
            End If
        End If
        If deletetip.Tag >= MaxInt + 30 Then
            deletetip.Enabled = False
            deletetip.Tag = 0
            Controls.Remove(TipBox)
        End If
    End Sub

    ''' <summary>
    '''     弹出提示框。
    ''' </summary>
    ''' <param name="content">提示框的内容。</param>
    ''' <param name="important">是否重要(用红色表示，停留时间长)。</param>
    Private Sub Tip(content As String, Optional important As Boolean = False)
        TipBox.Text = content
        TipBox.Size = New Size(scene.Width, 70)
        TipBox.BorderStyle = BorderStyle.FixedSingle
        If important Then
            TipBox.ForeColor = Color.Black
            TipBox.BackColor = Color.Red
        Else
            TipBox.ForeColor = Color.White
            TipBox.BackColor = Color.Black
        End If
        ImportantTip = important
        Controls.Add(TipBox)
        TipBox.BringToFront()
        deletetip.Tag = 0
        deletetip.Enabled = True
    End Sub

    ''' <summary>
    '''     通过物品名称返回物品图片。
    ''' </summary>
    ''' <param name="ItemName">物品名称。</param>
    ''' <returns></returns>
    Private Function GetItemImage(ItemName As String) As Image
        If ItemName = "witch's book" Then Return item_image.Images(0)
        If ItemName = "duck tape" Then Return item_image.Images(1)
        Throw New Exception("""" & ItemName & """ isn't exist in the list.")
    End Function

    Private Sub scene_Click(sender As Object, e As EventArgs) Handles scene.Click
        deselect()
    End Sub

    Enum Appearance
        Appear
        ClimbUp
        GradualChange
    End Enum

    Private FullImage As Bitmap, CurrentOpacity As Single

    ''' <summary>
    '''     显示过场动画，其中包含角色对话。
    ''' </summary>
    ''' <param name="ControlTag">控件的Tag值。</param>
    ''' <param name="AppearMode">是否爬上来。如果不，则直接出现图片，且图片为Nothing。</param>
    ''' <param name="ClimbSpeed">上爬速度。</param>
    Public Sub ShowCutscene(ControlTag As Integer, AppearMode As Appearance, Optional ClimbSpeed As Single = 1)
        Actor.Visible = True
        dialogue.Visible = False
        dialogue.ForeColor = Color.Black
        dialogue.BackColor = Color.Transparent
        cutscenes.Tag = ControlTag
        If AppearMode = Appearance.ClimbUp Then
            Actor.Tag = 0
            ClimbSpeed_ = ClimbSpeed
            Actor.Top = Height
        ElseIf AppearMode = Appearance.GradualChange Then
            Actor.Tag = 2
            Actor.Top = 0
            FullImage = Actor.Image
            CurrentOpacity = 0
            Actor.Image = ChangeAlpha(Actor.Image, 0)
        Else
            Actor.Tag = 0
            Actor.Top = 0
            Actor.Image = Nothing
        End If
        Actor.BringToFront()
        itemlist.BringToFront()
        cutscenes.Enabled = True
    End Sub

    ''' <summary>
    '''     Affect.
    ''' </summary>
    ''' <param name="code">The affect code.</param>
    Private Sub Affect(code As Integer)
        If code = 0 Then
            Form1.music.URL = GetFile("music17")
            scene.Tag = 3
            Tip("Your music is restored.")
            RemoveOut(disallow2_2)
        ElseIf code = 1 Then
            Tip("He has run away! Catch up!")
        ElseIf code = 2 Then
            PuzzlingMove(scene, backward, "image54", 10, 3)
        ElseIf code = 3 Then
            Tip("Who is that guy? Is it our drillmaster? We should go into that room to have a search.", True)
        End If
    End Sub

    Private Sub cutscenes_Tick(sender As Object, e As EventArgs) Handles cutscenes.Tick
        If Actor.Top = 0 And Actor.Tag < 2 Then
            cutscenes.Tag += 1
            If cutscenes.Tag = 10 Then
                dialogue.Visible = True
                My.Computer.Audio.Play(GetFile("newvoice1"))
                dialogue.Text =
                    "In order to catch the turkey, we searched in the school, but we didn't find the turkey at all."
            ElseIf cutscenes.Tag = 200 Then
                dialogue.Visible = False
                SceneAppears(- 2, SwitchMode.drag_right)
            ElseIf cutscenes.Tag = 210 Then
                dialogue.Visible = True
                My.Computer.Audio.Play(GetFile("newvoice2"))
                dialogue.Text = "Meanwhile, we found some strange books showing the rooster's tragedy."
            ElseIf cutscenes.Tag = 360 Then
                dialogue.Text = "The rooster was once spellbound by a witch, then the witch killed him."
            ElseIf cutscenes.Tag = 520 Then
                dialogue.Visible = False
                If Form1.Unlocked.Items.Contains("without fire") Then SceneAppears(- 4, SwitchMode.drag_right) Else _
                    SceneAppears(- 3, SwitchMode.drag_right)
            ElseIf Form1.Unlocked.Items.Contains("without fire") = False And cutscenes.Tag = 530 Then
                dialogue.Visible = True
                My.Computer.Audio.Play(GetFile("newvoice3"))
                dialogue.Text = "The witch then burned the school. We escaped from the school to a time machine."
            ElseIf Form1.Unlocked.Items.Contains("without fire") = False And cutscenes.Tag = 690 Then
                dialogue.Visible = False
                SceneAppears(- 5, SwitchMode.drag_right)
            ElseIf Form1.Unlocked.Items.Contains("without fire") And cutscenes.Tag = 530 Then
                dialogue.Visible = True
                My.Computer.Audio.Play(GetFile("newvoice4"))
                dialogue.Text = "We went to time machine to go back the past and save the rooster."
            ElseIf Form1.Unlocked.Items.Contains("without fire") And cutscenes.Tag = 670 Then
                dialogue.Visible = False
                SceneAppears(- 5, SwitchMode.drag_right)
                cutscenes.Tag = 690
            ElseIf cutscenes.Tag = 700 Then
                dialogue.Visible = True
                My.Computer.Audio.Play(GetFile("newvoice5"))
                dialogue.Text = "In the past, we destroyed the witch and defeated Atropos by using the artifact."
            ElseIf cutscenes.Tag = 890 Then
                SceneAppears(- 6, SwitchMode.drag_right)
                dialogue.Text = "But we don't know if the rooster is still alive now."
            ElseIf cutscenes.Tag = 970 Then
                dialogue.Visible = False
            ElseIf cutscenes.Tag = 1000 Then
                SceneAppears(- 7, SwitchMode.drag_up)
            ElseIf cutscenes.Tag = 1020 Then
                NewMission("Catch the turkey.", "Our main mission is to catch the turkey. Of course.", 0)
            ElseIf cutscenes.Tag = 1060 Then
                NewMission("Search for the rooster.", "Find the truth of the rooster, whether he is alive or not.", 1)
            ElseIf cutscenes.Tag = 1100 Then
                Actor.Visible = False
                SceneAppears(1, SwitchMode.drag_down)
                Tip("Here is the time tunnel. From here we can go back to the real world.", True)
                Form1.music.settings.volume = Form1.BackgroundVolume
                Form1.music.URL = GetFile("music17")
                Form1.music.Ctlcontrols.play()
                cutscenes.Enabled = False
            ElseIf cutscenes.Tag = 1101 Then
                dialogue.Visible = True
                dialogue.ForeColor = Color.Red
                dialogue.Text = "(Don't blame on the clownish sound, please.)"
            ElseIf cutscenes.Tag = 1110 Then
                dialogue.ForeColor = Color.Yellow
                My.Computer.Audio.Play(GetFile("newvoice6"))
                dialogue.Text = "You're in the time tunnel, so you're also going to catch the turkey?"
            ElseIf cutscenes.Tag = 1205 Then
                My.Computer.Audio.Play(GetFile("newvoice7"))
                dialogue.Text = "But the turkey is mine. No one can bear it away."
            ElseIf cutscenes.Tag = 1280 Then
                My.Computer.Audio.Play(GetFile("newvoice8"))
                dialogue.Text =
                    "You're also strong, because you also defeated Atropos that guy. So I want to have a battle with you."
            ElseIf cutscenes.Tag = 1430 Then
                Hide()
                Form7.Show()
                Form7.initialization(Form1.shield_level, Form1.weapon_level, 0, 350 + Form1.shield_level*150, 4000, 23,
                                     400, 110, 300, 950)
                Form1.music.settings.setMode("loop", True)
                Form1.music.settings.volume = 100
                Form1.music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music8.wm"
                cutscenes.Enabled = False
                dialogue.Visible = False
            ElseIf cutscenes.Tag = 1450 Then
                dialogue.Visible = True
                My.Computer.Audio.Play(GetFile("newvoice9"))
                dialogue.Text = "Your magic is too weak. You needn't it. I will take your magics."
            ElseIf cutscenes.Tag = 1570 Then
                dialogue.Visible = False
                subActor.Size = New Size(Actor.Width, Actor.Height - dialogue.Height)
                subActor.Location = New Point(0, dialogue.Bottom)
                subActor.SizeMode = PictureBoxSizeMode.CenterImage
                subActor.Image = Image.FromFile(GetFile("image47"))
                subActor.Visible = True
                My.Computer.Audio.Play(GetFile("sound67"))
            ElseIf cutscenes.Tag = 1590 Then
                Tip("You lose some of your magics.")
            ElseIf cutscenes.Tag = 1610 Then
                subActor.Visible = False
            ElseIf cutscenes.Tag = 1620 Then
                dialogue.Visible = True
                My.Computer.Audio.Play(GetFile("newvoice10"))
                dialogue.Text = "Don't ever contend with me for the turkey. The turkey must be eaten by me."
            ElseIf cutscenes.Tag = 1710 Then
                My.Computer.Audio.Play(GetFile("newvoice11"))
                dialogue.Text = "I once defeated Atropos without any artifact, but she revived again and again."
            ElseIf cutscenes.Tag = 1815 Then
                dialogue.Text = "She was always blocking me from catching the turkey,"
            ElseIf cutscenes.Tag = 1860 Then
                dialogue.Text = "but I know that the turkey is currently in 411 dormitory of military training base."
            ElseIf cutscenes.Tag = 2015 Then
                My.Computer.Audio.Play(GetFile("newvoice12"))
                dialogue.Text = "I will change your background music, soon you will know the effect."
            ElseIf cutscenes.Tag = 2105 Then
                dialogue.Visible = False
                ClimbSpeed_ = 0.05
                Actor.Tag = 3
                Form1.music.URL = GetFile("music19")
            ElseIf cutscenes.Tag = 2106 Then
                dialogue.Visible = True
                dialogue.ForeColor = Color.Black
                My.Computer.Audio.Play(GetFile("newvoice13"))
                dialogue.Text =
                    "I tell you the fact whoever you are. The military training base is in a state of emergency."
            ElseIf cutscenes.Tag = 2230 Then
                My.Computer.Audio.Play(GetFile("newvoice14"))
                dialogue.Text = "Just now, a strange masked character rushed into the base, then ran out."
            ElseIf cutscenes.Tag = 2340 Then
                dialogue.Text = "Just after few minutes, a signal of Ms.Li ice is detected."
            ElseIf cutscenes.Tag = 2430 Then
                My.Computer.Audio.Play(GetFile("newvoice15"))
                dialogue.Text = "It is horrible, because it shows if the ice entirely melts,"
            ElseIf cutscenes.Tag = 2515 Then
                dialogue.Text = "Ms.Li will drop down from the sky and sit down all these buildings."
            ElseIf cutscenes.Tag = 2615 Then
                My.Computer.Audio.Play(GetFile("newvoice16"))
                dialogue.Text =
                    "Report me if you find the ice outside. We do not allow you to enter, because your background music is too odd."
            ElseIf cutscenes.Tag = 2765 Then
                dialogue.Visible = False
                Actor.Tag = 1
                Actor.Top += 1
                NewMission("Find the Ms.Li ice.",
                           "It will be a great horror if Ms.Li drops down from the sky! Hard to imagine!", 2)
            ElseIf cutscenes.Tag = 2766 Then
                dialogue.Visible = True
                dialogue.ForeColor = Color.White
                My.Computer.Audio.Play(GetFile("sound28"))
                dialogue.Text = "That time I was swimming in the pool, suddenly a duck hunter caught me,"
            ElseIf cutscenes.Tag = 2875 Then
                My.Computer.Audio.Play(GetFile("sound28"))
                dialogue.Text = "then I was dizzily teleported to here."
            ElseIf cutscenes.Tag = 2925 Then
                My.Computer.Audio.Play(GetFile("sound28"))
                dialogue.Text = "Oh your background music is too bad!"
            ElseIf cutscenes.Tag = 2975 Then
                My.Computer.Audio.Play(GetFile("sound28"))
                dialogue.Text = "I give you a good tape, you can use it to change the music."
            ElseIf cutscenes.Tag = 3025 Then
                GetItem(Actor, "duck tape")
            ElseIf cutscenes.Tag = 3075 Then
                My.Computer.Audio.Play(GetFile("sound28"))
                dialogue.Text = "Now I should go. Excuse me."
            ElseIf cutscenes.Tag = 3125 Then
                dialogue.Visible = False
                Actor.Tag = 1
                Actor.Top += 1
            ElseIf cutscenes.Tag = 3126 Then
                Unable = True
                Actor.Visible = False
            ElseIf cutscenes.Tag = 3140 Then
                Unable = False
                Actor.Visible = True
                Actor.Image = Image.FromFile(GetFile("image49"))
            ElseIf cutscenes.Tag = 3180 Then
                Actor.Visible = False
                RemoveOut(ice12_1)
            ElseIf cutscenes.Tag = 3200 Then
                Tip("He picked the Ms.Li ice and ran out! CATCH UP!!", True)
                cutscenes.Enabled = False
            ElseIf cutscenes.Tag = 3210 Then
                ActorLeft.Visible = True
                ActorRight.Visible = True
                ActorLeft.BringToFront()
                ActorRight.BringToFront()
                ActorLeft.Image = Image.FromFile(GetFile("image49"))
                ActorRight.Image = Image.FromFile(GetFile("image51"))
                dialogue.Visible = True
                dialogue.ForeColor = Color.Yellow
                My.Computer.Audio.Play(GetFile("newvoice17"))
                dialogue.Text = "Oh my great turkey god! I summon you with the holy artifact, the Ms.Li ice!"
            ElseIf cutscenes.Tag = 3385 Then
                dialogue.Text = "Come to this world, my turkey god!"
            ElseIf cutscenes.Tag = 3450 Then
                My.Computer.Audio.Play(GetFile("newvoice18"))
                dialogue.Text = "Now, it's the time for us"
                ActorRight.Image = Image.FromFile(GetFile("image52"))
            ElseIf cutscenes.Tag = 3505 Then
                dialogue.Text = "Who?!"
                Actor.Image = ActorLeft.Image
                ActorLeft.Visible = False
                ActorRight.Visible = False
            ElseIf cutscenes.Tag = 3540 Then
                Actor.Visible = False
                Disappear()
                scene.Image = Image.FromFile(GetFile("image28"))
                Form1.music.Ctlcontrols.pause()
                Tip("You are stunned.")
                My.Computer.Audio.Play(GetFile("sound3"))
            ElseIf cutscenes.Tag = 3590 Then
                Form1.music.Ctlcontrols.play()
                SceneAppears(12, SwitchMode.drag_up)
                Tip("The 411 dormitory! What happened outside?")
                cutscenes.Enabled = False
                NewMission("Expose the secret of turkey cult.",
                           "Turkey cult- A strange organization formed in the dormitories.", 2)
            ElseIf cutscenes.Tag = 3600 Then
                Actor.Image = Image.FromFile(GetFile("image48"))
            ElseIf cutscenes.Tag = 3625 Then
                cutscenes.Enabled = False
                ShowMessage(0,
                            "Drillmaster:" & vbCrLf &
                            "Hello, stranger. I was stunned by a turkey cult embracer just now.", "What is turkey cult?",
                            True)
            ElseIf cutscenes.Tag = 3635 Then
                Actor.Image = Image.FromFile(GetFile("image54"))
                My.Computer.Audio.Play(GetFile("sound5"))
            ElseIf cutscenes.Tag = 3650 Then
                Hide()
                Form7.Show()
                Form7.initialization(Nothing, Nothing, Nothing, 350 + Form1.shield_level*150, 19, 24, 0, 110, 0, 950)
                Form1.music.settings.setMode("loop", True)
                Form1.music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music8.wm"
                cutscenes.Enabled = False
            ElseIf cutscenes.Tag = 3651 Then
                ShowMessage(4,
                            "Turkey rider(turkey believer):" & vbCrLf &
                            "*ge ge ge ge ge ge ge gegegegege gegege gegegegeggegege*", "Oops!", True)
                cutscenes.Enabled = False
            ElseIf cutscenes.Tag = 3660 Then
                Actor.Image = Image.FromFile(GetFile("image49"))
                My.Computer.Audio.Play(GetFile("sound68"))
            ElseIf cutscenes.Tag = 3680 Then
                Actor.Visible = False
                cutscenes.Enabled = False
                Tip("The pontiff! Report it to the drillmaster!", True)
            ElseIf cutscenes.Tag = 3681 Then
                Actor.Image = Image.FromFile(GetFile("image48"))
            ElseIf cutscenes.Tag = 3700 Then
                dialogue.Visible = True
                dialogue.ForeColor = Color.Black
                My.Computer.Audio.Play(GetFile("newvoice19"))
                dialogue.Text = "What? You say that pontiff of turkey cult appeared in the dormitory?"
            ElseIf cutscenes.Tag = 3790 Then
                My.Computer.Audio.Play(GetFile("newvoice20"))
                dialogue.Text =
                    "I will go out and ring the alarm, to convene them to catch the pontiff! Of course, thank you."
            ElseIf cutscenes.Tag = 3925 Then
                Actor.Image = Nothing
                dialogue.Visible = False
            ElseIf cutscenes.Tag = 3950 Then
                dialogue.Visible = True
                My.Computer.Audio.Play(GetFile("newvoice21"))
                dialogue.Text =
                    "Warning! Warning! A large heresy, the turkey cult's pontiff is now in dormitory building."
                Actor.Image = Image.FromFile(GetFile("image56"))
                Actor.SizeMode = PictureBoxSizeMode.StretchImage
            ElseIf cutscenes.Tag = 4070 Then
                dialogue.Text = "We convene all the soldiers and drillmasters to catch him."
            ElseIf cutscenes.Tag = 4190 Then
                Actor.Visible = False
                cutscenes.Enabled = False
                SaveGame("Chapter5", "Drillmaster office", 12)
            ElseIf cutscenes.Tag = 4200 Then
                dialogue.Visible = True
                dialogue.ForeColor = Color.Red
                CompleteMission("Search for the rooster.")
                dialogue.Text = "Oh my god! The rooster is still dead!"
                rooster16_1.BringToFront()
            ElseIf cutscenes.Tag = 4250 Then
                dialogue.Visible = False
                Actor.BringToFront()
                Actor.Image = Scathach
                FullImage = Actor.Image
                Actor.Image = Nothing
                ClimbSpeed_ = 0.05
                Actor.Tag = 2
            ElseIf cutscenes.Tag = 4255 Then
                dialogue.Visible = True
                dialogue.ForeColor = Color.Black
                My.Computer.Audio.Play(GetFile("newvoice22"))
                dialogue.Text = "The rooster once married with a witch, he is already cursed, he surely will die."
            ElseIf cutscenes.Tag = 4360 Then
                My.Computer.Audio.Play(GetFile("newvoice23"))
                dialogue.Text = "But anyhow, I will never die. Neither beautiful death nor ugly death."
            ElseIf cutscenes.Tag = 4455 Then
                dialogue.ForeColor = Color.Red
                My.Computer.Audio.Play(GetFile("newvoice24"))
                dialogue.Text = "No. Besides Ms.Li, there is still one who can kill you. It's inside the canteen."
            ElseIf cutscenes.Tag = 4650 Then
                dialogue.Visible = False
            ElseIf cutscenes.Tag = 4665 Then
                dialogue.Visible = True
                dialogue.ForeColor = Color.Black
                My.Computer.Audio.Play(GetFile("newvoice25"))
                dialogue.Text = "I'll go to the canteen. Excuse me."
            ElseIf cutscenes.Tag = 4715 Then
                dialogue.Visible = False
                ClimbSpeed_ = 0.05
                Actor.Tag = 3
            ElseIf cutscenes.Tag = 4810 Then
                cutscenes.Enabled = False
                Actor.Visible = False
            ElseIf cutscenes.Tag = 4820 Then
                Controls.Add(ActorLeft)
                Controls.Add(ActorRight)
                ActorLeft.Visible = True
                ActorRight.Visible = True
                ActorLeft.BringToFront()
                ActorRight.BringToFront()
                ActorLeft.Parent = Actor
                ActorRight.Parent = Actor
                ActorLeft.BackColor = Color.Transparent
                ActorRight.BackColor = Color.Transparent
                ActorRight.Image = Image.FromFile(GetFile("image50"))
                ActorLeft.Image = Scathach
            ElseIf cutscenes.Tag = 4830 Then
                dialogue.Visible = True
                dialogue.Text = "***Mucus sound***"
                My.Computer.Audio.Play(GetFile("newvoice27"))
            ElseIf cutscenes.Tag = 4900 Then
                dialogue.Visible = False
                BattlelandInitialize(4000, 400)
                battler1.Image = Scathach
                battler2.Image = Image.FromFile(GetFile("image50"))
            ElseIf cutscenes.Tag = 4921 Then
                laser.Visible = True
                effect2.Image = scene_icon.Images(10)
                My.Computer.Audio.Play(GetFile("sound66"))
                If CanChange_BothChange(False, frontbar2.Tag - 100) = False Then cutscenes.Tag = 4920
            ElseIf cutscenes.Tag = 4930 Then
                effect2.Image = scene_icon.Images(10)
                My.Computer.Audio.Play(GetFile("sound66"))
                If CanChange_BothChange(False, frontbar2.Tag - 100) = False Then cutscenes.Tag = 4929
            ElseIf cutscenes.Tag = 4940 Then
                effect2.Image = scene_icon.Images(10)
                My.Computer.Audio.Play(GetFile("sound66"))
                If CanChange_BothChange(False, frontbar2.Tag - 100) = False Then cutscenes.Tag = 4939
            ElseIf cutscenes.Tag = 4941 Then
                If LifeWeaver.Enabled Then
                    cutscenes.Tag = 4940
                Else
                    laser.Visible = False
                    effect2.Visible = False
                End If
            ElseIf cutscenes.Tag = 4950 Then
                battler2.Left -= 1
                If battler2.Left <= battler1.Right Then battler2.Left = battler1.Right Else cutscenes.Tag = 4949
            ElseIf cutscenes.Tag = 4970 Then
                My.Computer.Audio.Play(GetFile("newvoice27"))
                battler2.Parent = battler1
                battler2.Location = New Point(0, 0)
                battler2.BringToFront()
                If CanChange_BothChange(True, 0) = False Then cutscenes.Tag = 4969
                life2.Visible = False
            ElseIf cutscenes.Tag = 4999 Then
                battler2.Parent = battle_land
                battler2.Location = New Point(battler1.Left + battler1.Width, battler1.Top)
                life2.Visible = True
            ElseIf cutscenes.Tag = 5009 Then
                battler2.Left += 1
                If battler2.Left >= 474*ZoomX Then battler2.Left = 474*ZoomX Else cutscenes.Tag = 5008
            ElseIf cutscenes.Tag = 5010 Then
                battle_land.Visible = False
                Controls.Add(SubActorLeft)
                SubActorLeft.Visible = True
                SubActorLeft.Size = ActorLeft.Size
                SubActorLeft.Location = New Point(0, 0)
                SubActorLeft.Parent = ActorLeft
                SubActorLeft.Image = Image.FromFile(GetFile("image57"))
                My.Computer.Audio.Play(GetFile("sound55"))
            ElseIf cutscenes.Tag = 5040 Then
                dialogue.Visible = True
                dialogue.ForeColor = Color.Red
                ActorRight.Image = Image.FromFile(GetFile("image49"))
                My.Computer.Audio.Play(GetFile("newvoice28"))
                dialogue.Text = "Become my scarifice for our turkey god, arrogant mortal."
            ElseIf cutscenes.Tag = 5180 Then
                dialogue.Visible = False
            ElseIf cutscenes.Tag = 5185 Then
                SubActorLeft.Image = Image.FromFile(GetFile("image47"))
                My.Computer.Audio.Play(GetFile("sound67"))
            ElseIf cutscenes.Tag = 5200 Then
                ActorLeft.Visible = False
                ActorRight.Visible = False
                SubActorLeft.Visible = False
                Controls.Remove(ActorLeft)
                Controls.Remove(ActorRight)
                Controls.Remove(SubActorLeft)
                My.Computer.Audio.Play(GetFile("sound51"))
                scene.Image = Image.FromFile(GetFile("image8"))
            ElseIf cutscenes.Tag > 5200 And cutscenes.Tag < 5260 Then
                If cutscenes.Tag Mod 10 < 5 Then scene.Image = Image.FromFile(GetFile("image8")) Else _
                    scene.Image = Image.FromFile(GetFile("image9"))
            ElseIf cutscenes.Tag = 5260 Then

            End If
        ElseIf Actor.Tag = 1 Then
            Actor.Top += ClimbSpeed_
            If Actor.Top >= Height Then
                Actor.Visible = False
                cutscenes.Enabled = False
                If cutscenes.Tag = 2105 Then
                    Tip("Who is her?? She is so powerful!!")
                    NewMission("Find the identity of ???.",
                               "A mysterious guest came and robbed all the magics, wanted to catch the turkey?", 2)
                End If
            End If
        ElseIf Actor.Tag = 2 Then
            CurrentOpacity += ClimbSpeed_
            Actor.Image = ChangeAlpha(FullImage, CurrentOpacity)
            If CurrentOpacity >= 1 Then
                Actor.Tag = 0
            End If
        ElseIf Actor.Tag = 3 Then
            CurrentOpacity -= ClimbSpeed_
            Actor.Image = ChangeAlpha(FullImage, CurrentOpacity)
            If CurrentOpacity <= 0 Then
                Actor.Visible = False
                cutscenes.Enabled = False
                If cutscenes.Tag = 4715 Then
                    dialogue.Visible = True
                    dialogue.ForeColor = Color.Red
                    My.Computer.Audio.Play(GetFile("newvoice26"))
                    dialogue.Text = "Thank you, but you will be regret."
                    Actor.Image = Nothing
                    Actor.Top = 0
                    Actor.Tag = 0
                    Actor.Visible = True
                    rooster16_1.BringToFront()
                    cutscenes.Enabled = True
                End If
            End If
        Else
            Actor.Top -= ClimbSpeed_
            If Actor.Top < 0 Then Actor.Top = 0
        End If
    End Sub

    ''' <summary>
    '''     获取一个控件，显示被选中的PictureBox。未选中则返回False。
    ''' </summary>
    ''' <returns>选中的PictureBox。</returns>
    Private Function SelectedItem() As PictureBox
        For x = 0 To 5
            If ItemBricks(x).BackColor = Color.Yellow Then Return ItemBricks(x)
        Next
        Return backward
    End Function

    ''' <summary>
    '''     刷新物品栏。
    ''' </summary>
    Friend Sub refresh_item()
        deselect()
        For x = 0 To 5
            If ItemTab + x <= Items.Items.Count - 1 Then
                ItemBricks(x).Image = GetItemImage(Items.Items(ItemTab + x))
                ItemBricks(x).Tag = Items.Items(ItemTab + x)
                ToolTip1.SetToolTip(ItemBricks(x), ItemBricks(x).Tag)
            Else
                ItemBricks(x).Image = Nothing
                ItemBricks(x).Tag = "Null"
                ToolTip1.SetToolTip(ItemBricks(x), "")
            End If
        Next
        If ItemTab > 0 Then left_.Enabled = True Else left_.Enabled = False
        If ItemTab + 6 <= Items.Items.Count Then right_.Enabled = True Else right_.Enabled = False
    End Sub

    ''' <summary>
    '''     创建新的任务。
    ''' </summary>
    ''' <param name="Name_">任务名称。</param>
    ''' <param name="content">任务简单概述。</param>
    ''' <param name="level">任务重要程度，从0~2逐渐下降。</param>
    Private Sub NewMission(Name_ As String, content As String, level As Integer)
        For x = 0 To mission.Items.Count - 1
            If mission.Items(x).Text = Name_ Then Exit Sub
        Next
        mission_top.Text = "New mission"
        mission_name.Text = Name_
        mission_text.Text = content
        mission_top.ForeColor = Color.Blue
        Dim NewMissionItem As New ListViewItem
        With NewMissionItem
            .Text = Name_
            .ToolTipText = content
            .Group = mission.Groups(level)
            .ImageIndex = 0
            .Tag = level
        End With
        mission.Items.Add(NewMissionItem)
        Move_mission_report.Enabled = True
        My.Computer.Audio.Play(GetFile("sound69"))
    End Sub

    ''' <summary>
    '''     完成一个任务。
    ''' </summary>
    ''' <param name="Name_">任务名称。</param>
    Private Sub CompleteMission(Name_ As String)
        Dim Usable = False
        Dim ChangingItem As ListViewItem
        For x = 0 To mission.Items.Count - 1
            If mission.Items(x).Text = Name_ Then
                Usable = True
                ChangingItem = mission.Items(x)
            End If
        Next
        If Usable = False Then Throw New Exception("Unable to find the mission """ & Name_ & """.")
        mission_top.Text = "Completed"
        mission_name.Text = Name_
        mission_text.Text = ChangingItem.ToolTipText
        mission_top.ForeColor = Color.Green
        ChangingItem.ImageIndex = 1
        Move_mission_report.Enabled = True
        My.Computer.Audio.Play(GetFile("sound70"))
    End Sub

    ''' <summary>
    '''     对游戏进行存档。为了保证游戏平衡，每隔一段时间就必须进行强制的存档。
    ''' </summary>
    ''' <param name="chapter">目前的游戏章节。</param>
    ''' <param name="place">目前玩家所在位置。</param>
    ''' <param name="appendix">附加值，在Form16中为附加值进行详细设置。</param>
    Public Sub SaveGame(chapter As String, place As String, appendix As Integer)
        My.Settings.savetime = Now
        My.Settings.chapter = chapter
        My.Settings.place = place
        My.Settings.weapon = Form1.weapon_level
        My.Settings.shield = Form1.shield_level
        My.Settings.revival = Form1.revive
        My.Settings.curative = Form1.heal
        My.Settings.appendix = appendix
        My.Settings.magics = ""
        For x = 0 To Form1.magics.Items.Count - 1
            My.Settings.magics = My.Settings.magics & Form1.magics.Items(x) & "/"
        Next
        My.Settings.items = ""
        For x = 0 To Items.Items.Count - 1
            My.Settings.items = My.Settings.items & Items.Items(x) & "/"
        Next
        My.Settings.unlocked = ""
        For x = 0 To Form1.Unlocked.Items.Count - 1
            My.Settings.unlocked = My.Settings.unlocked & Form1.Unlocked.Items(x) & "/"
        Next
        My.Settings.missions = ""
        For x = 0 To mission.Items.Count - 1
            My.Settings.missions = My.Settings.missions & mission.Items(x).Text & ";" & mission.Items(x).ToolTipText &
                                   ";" & mission.Items(x).ImageIndex & ";" & mission.Items(x).Tag & "/"
        Next
        My.Settings.Save()
        MsgBox("Your game is saved.", 0, "Save game")
    End Sub

    Enum SwitchMode
        direct
        drag_up
        drag_down
        drag_left
        drag_right
        gradual_change
    End Enum

    ''' <summary>
    '''     通过文件的名称直接引用文件。
    ''' </summary>
    ''' <param name="Name_">文件名称。</param>
    ''' <returns>返回的文件。</returns>
    Private Function GetFile(Name_ As String) As String
        Return My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\" & Name_ & ".wm"
    End Function
    '切换场景的区域，场景必须经由统一的Sub进行切换。
    ''' <summary>
    '''     场景的切换。场景可以以移动方式切换，但这需要花费一些时间。
    ''' </summary>
    ''' <param name="target">目标场景的代号。</param>
    ''' <param name="ChangeMode">移动方式。SwitchMode.direct(默认)表示直接切换。</param>
    Public Sub SceneAppears(target As Integer, Optional ChangeMode As SwitchMode = SwitchMode.direct)
        deselect()
        Disappear()
        Dim TargetImage As Image = Image.FromFile(GetFile("NewScene" & target))
        If ChangeMode = SwitchMode.direct Then
            scene.Image = TargetImage
            LoadTiles(target)
            backward.Tag = target
        Else
            AlphaForSW = 0
            Controls.Add(SceneBrick)
            SceneBrick.Visible = True
            SceneChangeMode = ChangeMode
            SceneBrick.Size = scene.Size
            SceneBrick.Location = scene.Location
            SceneBrick.BackColor = Color.Transparent
            MissionSummoner.BringToFront()
            SceneBrick.Parent = Me
            If ChangeMode = SwitchMode.drag_up Then
                SceneBrick.Top = - SceneBrick.Height
            ElseIf ChangeMode = SwitchMode.drag_down Then
                SceneBrick.Top = scene.Height
            ElseIf ChangeMode = SwitchMode.drag_left Then
                SceneBrick.Left = - SceneBrick.Width
            ElseIf ChangeMode = SwitchMode.drag_right Then
                SceneBrick.Left = scene.Width
            ElseIf ChangeMode = SwitchMode.gradual_change Then
                SceneBrick.Parent = scene
                SceneBrick.Visible = True
                SceneBrick.Location = New Point(0, 0)
                ImageForSW = TargetImage
            End If
            If Not ChangeMode = SwitchMode.gradual_change Then SceneBrick.Image = TargetImage
            SceneWeaver.Tag = target
            SceneWeaver.Enabled = True
        End If
    End Sub

    ''' <summary>
    '''     一个非常长的Sub。是的，越来越长，直到占满屏幕。
    ''' </summary>
    ''' <param name="scene_code">场景的代码。</param>
    Private Sub LoadTiles(scene_code As Integer)
        If scene_code = 1 Then
            AddTile(place1_1, 0)
        ElseIf scene_code = 2 Then
            AddTile(place2_1, 0)
            AddTile(disallow2_2, 4)
            AddTile(place2_3, 3)
            AddTile(lock2_4, 5)
            AddTile(place2_5, 3)
        ElseIf scene_code = 3 Then
            AddTile(backward, 1)
            AddTile(radio3_2, 6)
            AddTile(place3_1, 0)
        ElseIf scene_code = 4 Then
            AddTile(place4_1, 0)
            AddTile(backward, 1)
        ElseIf scene_code = 5 Then
            AddTile(backward, 1)
        ElseIf scene_code = 6 Then
            AddTile(backward, 1)
            AddTile(place6_1, 3)
            AddTile(place6_2, 2)
        ElseIf scene_code = 7 Then
            AddTile(place7_1, 2)
            AddTile(place7_2, 0)
        ElseIf scene_code = 8 Then
            AddTile(place8_1, 0)
            AddTile(place8_2, 3)
            AddTile(lock8_3, 5)
            AddTile(backward, 1)
        ElseIf scene_code = 9 Then
            AddTile(place9_1, 0)
            AddTile(backward, 1)
        ElseIf scene_code = 10 Then
            AddTile(place10_1, 0)
            AddTile(place10_2, 3)
            AddTile(lock10_3, 5)
            AddTile(place10_4, 2)
            AddTile(lock10_5, 5)
            AddTile(backward, 1)
        ElseIf scene_code = 11 Then
            AddTile(place11_1, 3)
            AddTile(place11_2, 3)
            AddTile(backward, 1)
        ElseIf scene_code = 12 Then
            AddTile(backward, 1)
            AddTile(ice12_1, 7)
        ElseIf scene_code = 13 Then
            AddTile(place13_1, 2)
            AddTile(lock13_2, 5)
        ElseIf scene_code = 14 Then
            AddTile(backward, 1)
        ElseIf scene_code = 15 Then
            AddTile(place15_1, 0)
        ElseIf scene_code = 16 Then
            AddTile(place16_2, 0)
            AddTile(rooster16_1, 8)
            AddTile(place16_3, 3)
        ElseIf scene_code = 17 Then
            AddTile(backward, 1)
        ElseIf scene_code = 18 Then
            AddTile(place18_1, 0)
            AddTile(lock18_2, 5)
            AddTile(place18_3, 3)
        ElseIf scene_code = 19 Then
            AddTile(place19_1, 2)
            AddTile(place19_2, 0)
            AddTile(backward, 1)
        ElseIf scene_code = 20 Then
            AddTile(backward, 1)
        ElseIf scene_code = 21 Then
            AddTile(place21_1, 3)
            AddTile(place21_2, 3)
            AddTile(lock21_3, 5)
            AddTile(place21_4, 3)
            AddTile(lock21_5, 5)
            AddTile(backward, 1)
        ElseIf scene_code = 22 Then
            AddTile(backward, 1)
        ElseIf scene_code = 23 Then
            AddTile(place23_1, 2)
            AddTile(backward, 1)
        ElseIf scene_code = 24 Then
            AddTile(backward, 1)
        ElseIf scene_code = 25 Then
            AddTile(place25_1, 2)
            AddTile(place25_2, 3)
        ElseIf scene_code = 26 Then
            AddTile(place26_1, 0)
            AddTile(backward, 1)
        ElseIf scene_code = 27 Then
            AddTile(place27_1, 0)
            AddTile(backward, 1)
        ElseIf scene_code = 28 Then
            AddTile(place28_1, 0)
            AddTile(backward, 1)
        End If
    End Sub
    '我们在此定义一切存在于各个场景的组件。文件名以NewScene开头，必须保证组件前缀，场景切换索引和文件名的数字完全一致。在窗体上严禁直接添加组件，否则将导致严重卡顿。
    Private ReadOnly _
        place1_1 As _
            New PictureBox _
        With {.Name = "place1_1", .Size = New Size(36, 36), .Location = New Point(380*ZoomX, 320*ZoomY)}

    Public Scathach As Bitmap
    Private ReadOnly backward As New PictureBox With {.Name = "backward", .Size = New Size(36, 36)}

    Private ReadOnly _
        place2_1 As _
            New PictureBox _
        With {.Name = "place2_1", .Size = New Size(36, 36), .Location = New Point(530*ZoomX, 440*ZoomY)}

    Private ReadOnly _
        disallow2_2 As _
            New PictureBox _
        With {.Name = "disallow2_2", .Size = New Size(24, 24), .Location = New Point(540*ZoomX, 400*ZoomY)}

    Private ReadOnly _
        place2_3 As _
            New PictureBox _
        With {.Name = "place2_3", .Size = New Size(24, 24), .Location = New Point(650*ZoomX, 390*ZoomY)}

    Private ReadOnly _
        lock2_4 As _
            New PictureBox _
        With {.Name = "lock2_4", .Size = New Size(24, 24), .Location = New Point(680*ZoomX, 380*ZoomY)}

    Private ReadOnly place2_5 As New PictureBox With {.Name = "place2_5", .Size = New Size(36, 36)}

    Private ReadOnly _
        place3_1 As _
            New PictureBox _
        With {.Name = "place3_1", .Size = New Size(36, 36), .Location = New Point(660*ZoomX, 290*ZoomY)}

    Private ReadOnly _
        radio3_2 As _
            New PictureBox _
        With {.Name = "radio3_2", .Size = New Size(128, 128), .Location = New Point(120*ZoomX, 320*ZoomY)}

    Private ReadOnly _
        place4_1 As _
            New PictureBox _
        With {.Name = "place4_1", .Size = New Size(48, 48), .Location = New Point(440*ZoomX, 380*ZoomY)}

    Private ReadOnly place6_1 As New PictureBox With {.Name = "place6_1", .Size = New Size(36, 36)}

    Private ReadOnly _
        place6_2 As _
            New PictureBox With {.Name = "place6_2", .Size = New Size(36, 36), .Location = New Point(0, 420*ZoomY)}

    Private ReadOnly _
        place7_1 As _
            New PictureBox With {.Name = "place7_1", .Size = New Size(36, 36), .Location = New Point(0, 300*ZoomY)}

    Private ReadOnly _
        place7_2 As _
            New PictureBox _
        With {.Name = "place7_2", .Size = New Size(36, 36), .Location = New Point(350*ZoomX, 250*ZoomY)}

    Private ReadOnly _
        place8_1 As _
            New PictureBox _
        With {.Name = "place8_1", .Size = New Size(36, 36), .Location = New Point(390*ZoomX, 350*ZoomY)}

    Private ReadOnly _
        place8_2 As _
            New PictureBox _
        With {.Name = "place8_2", .Size = New Size(36, 36), .Location = New Point(720*ZoomX, 320*ZoomY)}

    Private ReadOnly _
        lock8_3 As _
            New PictureBox _
        With {.Name = "lock8_3", .Size = New Size(36, 36), .Location = New Point(770*ZoomX, 320*ZoomY)}

    Private ReadOnly _
        place9_1 As _
            New PictureBox _
        With {.Name = "place9_1", .Size = New Size(48, 48), .Location = New Point(400*ZoomX, 250*ZoomY)}

    Private ReadOnly _
        place10_1 As _
            New PictureBox _
        With {.Name = "place10_1", .Size = New Size(36, 36), .Location = New Point(410*ZoomX, 210*ZoomY)}

    Private ReadOnly _
        place10_2 As _
            New PictureBox _
        With {.Name = "place10_2", .Size = New Size(36, 36), .Location = New Point(640*ZoomX, 270*ZoomY)}

    Private ReadOnly _
        lock10_3 As _
            New PictureBox _
        With {.Name = "lock10_3", .Size = New Size(36, 36), .Location = New Point(680*ZoomX, 270*ZoomY)}

    Private ReadOnly _
        place10_4 As _
            New PictureBox _
        With {.Name = "place10_4", .Size = New Size(36, 36), .Location = New Point(240*ZoomX, 270*ZoomY)}

    Private ReadOnly _
        lock10_5 As _
            New PictureBox _
        With {.Name = "lock10_5", .Size = New Size(36, 36), .Location = New Point(200*ZoomX, 270*ZoomY)}

    Private ReadOnly _
        place11_1 As _
            New PictureBox _
        With {.Name = "place11_1", .Size = New Size(36, 36), .Location = New Point(130*ZoomX, 260*ZoomY)}

    Private ReadOnly _
        place11_2 As _
            New PictureBox _
        With {.Name = "place11_2", .Size = New Size(36, 36), .Location = New Point(390*ZoomX, 300*ZoomY)}

    Private ReadOnly _
        ice12_1 As _
            New PictureBox _
        With {.Name = "ice12_1", .Size = New Size(128, 128), .Location = New Point(200*ZoomX, 280*ZoomY)}

    Private ReadOnly _
        place13_1 As _
            New PictureBox _
        With {.Name = "place13_1", .Size = New Size(36, 36), .Location = New Point(150*ZoomX, 380*ZoomY)}

    Private ReadOnly _
        lock13_2 As _
            New PictureBox _
        With {.Name = "lock13_2", .Size = New Size(36, 36), .Location = New Point(110*ZoomX, 380*ZoomY)}

    Private ReadOnly _
        place15_1 As _
            New PictureBox _
        With {.Name = "place15_1", .Size = New Size(36, 36), .Location = New Point(630*ZoomX, 200*ZoomY)}

    Private ReadOnly _
        rooster16_1 As _
            New PictureBox _
        With {.Name = "rooster16_1", .Size = New Size(256, 128), .Location = New Point(300*ZoomX, 330*ZoomY)}

    Private ReadOnly _
        place16_2 As _
            New PictureBox _
        With {.Name = "place16_2", .Size = New Size(36, 36), .Location = New Point(660*ZoomX, 340*ZoomY)}

    Private ReadOnly place16_3 As New PictureBox With {.Name = "place16_3", .Size = New Size(36, 36)}

    Private ReadOnly _
        place18_1 As _
            New PictureBox _
        With {.Name = "place18_1", .Size = New Size(36, 36), .Location = New Point(500*ZoomX, 250*ZoomY)}

    Private ReadOnly _
        lock18_2 As _
            New PictureBox _
        With {.Name = "lock18_2", .Size = New Size(36, 36), .Location = New Point(490*ZoomX, 200*ZoomY)}

    Private ReadOnly _
        place18_3 As _
            New PictureBox _
        With {.Name = "place18_3", .Size = New Size(36, 36), .Location = New Point(650*ZoomX, 200*ZoomY)}

    Private ReadOnly _
        place19_1 As _
            New PictureBox With {.Name = "place19_1", .Size = New Size(48, 48), .Location = New Point(0, 460*ZoomY)} _
    'left
    Private ReadOnly _
        place19_2 As _
            New PictureBox _
        With {.Name = "place19_2", .Size = New Size(36, 36), .Location = New Point(480*ZoomX, 240*ZoomY)} 'up
    Private ReadOnly _
        place21_1 As _
            New PictureBox _
        With {.Name = "place21_1", .Size = New Size(36, 36), .Location = New Point(520*ZoomX, 300*ZoomY)} 'right1
    Private ReadOnly _
        place21_2 As _
            New PictureBox _
        With {.Name = "place21_2", .Size = New Size(36, 36), .Location = New Point(600*ZoomX, 350*ZoomY)} 'right1
    Private ReadOnly _
        lock21_3 As _
            New PictureBox _
        With {.Name = "lock21_3", .Size = New Size(36, 36), .Location = New Point(620*ZoomX, 350*ZoomY)} 'right2
    Private ReadOnly _
        place21_4 As _
            New PictureBox _
        With {.Name = "place21_4", .Size = New Size(48, 48), .Location = New Point(720*ZoomX, 370*ZoomY)} 'right3
    Private ReadOnly _
        lock21_5 As _
            New PictureBox _
        With {.Name = "lock21_5", .Size = New Size(36, 36), .Location = New Point(770*ZoomX, 380*ZoomY)} 'right3
    Private ReadOnly _
        place23_1 As _
            New PictureBox _
        With {.Name = "place23_1", .Size = New Size(36, 36), .Location = New Point(230*ZoomX, 300*ZoomY)}

    Private ReadOnly _
        place25_1 As _
            New PictureBox _
        With {.Name = "place25_1", .Size = New Size(36, 36), .Location = New Point(190*ZoomX, 320*ZoomY)}

    Private ReadOnly _
        place25_2 As _
            New PictureBox _
        With {.Name = "place25_2", .Size = New Size(36, 36), .Location = New Point(680*ZoomX, 380*ZoomY)}

    Private ReadOnly place26_1 As New PictureBox With {.Name = "place26_1", .Size = New Size(36, 36)}

    Private ReadOnly _
        place27_1 As _
            New PictureBox _
        With {.Name = "place27_1", .Size = New Size(36, 36), .Location = New Point(640*ZoomX, 280*ZoomY)}

    Private ReadOnly _
        place28_1 As _
            New PictureBox _
        With {.Name = "place28_1", .Size = New Size(36, 36), .Location = New Point(410*ZoomX, 330*ZoomY)}

    Private Sub SceneInitialize()
        AddHandler place1_1.Click, AddressOf place1_1_click
        AddHandler backward.Click, AddressOf backward_click
        AddHandler place2_1.Click, AddressOf place2_1_click
        AddHandler place2_3.Click, AddressOf place2_3_click
        AddHandler place2_5.Click, AddressOf place2_5_click
        AddHandler place3_1.Click, AddressOf place3_1_click
        AddHandler radio3_2.Click, AddressOf radio3_2_click
        AddHandler place4_1.Click, AddressOf place4_1_click
        AddHandler place6_1.Click, AddressOf place6_1_click
        AddHandler place6_2.Click, AddressOf place6_2_click
        AddHandler place7_1.Click, AddressOf place7_1_click
        AddHandler place7_2.Click, AddressOf place7_2_click
        AddHandler place8_1.Click, AddressOf place8_1_click
        AddHandler place8_2.Click, AddressOf place8_2_click
        AddHandler place9_1.Click, AddressOf place9_1_click
        AddHandler place10_1.Click, AddressOf place10_1_click
        AddHandler place10_2.Click, AddressOf place10_2_click
        AddHandler place10_4.Click, AddressOf place10_4_click
        AddHandler place11_1.Click, AddressOf place11_1_click
        AddHandler place11_2.Click, AddressOf place11_2_click
        AddHandler place13_1.Click, AddressOf place13_1_click
        AddHandler place15_1.Click, AddressOf place15_1_click
        AddHandler rooster16_1.Click, AddressOf rooster16_1_click
        AddHandler place16_2.Click, AddressOf place16_2_click
        AddHandler place16_3.Click, AddressOf place16_3_click
        AddHandler place18_1.Click, AddressOf place18_1_click
        AddHandler place18_3.Click, AddressOf place18_3_click
        AddHandler place19_1.Click, AddressOf place19_1_click
        AddHandler place19_2.Click, AddressOf place19_2_click
        AddHandler place21_1.Click, AddressOf place21_1_click
        AddHandler place21_2.Click, AddressOf place21_2_click
        AddHandler place21_4.Click, AddressOf place21_4_click
        AddHandler place23_1.Click, AddressOf place23_1_click
        AddHandler place25_1.Click, AddressOf place25_1_click
        AddHandler place25_2.Click, AddressOf place25_2_click
        AddHandler place26_1.Click, AddressOf place26_1_click
        AddHandler place27_1.Click, AddressOf place27_1_click
        AddHandler place28_1.Click, AddressOf place28_1_click
        backward.Location = New Point((scene.Width - backward.Width)/2, scene.Height - backward.Height)
        place2_5.Location = New Point(scene.Width - place2_5.Width, 500*ZoomY)
        place6_1.Location = New Point(scene.Width - place6_1.Width, 450*ZoomY)
        ActorLeft.Parent = Actor
        ActorLeft.Location = New Point(0, dialogue.Height)
        ActorLeft.Size = New Size(scene.Width/2, scene.Height - dialogue.Height)
        ActorLeft.BackColor = Color.Transparent
        ActorRight.Parent = Actor
        ActorRight.Location = New Point(scene.Width/2, dialogue.Height)
        ActorRight.Size = New Size(scene.Width/2, scene.Height - dialogue.Height)
        ActorRight.BackColor = Color.Transparent
        place16_3.Location = New Point(scene.Width - place6_1.Width, 440*ZoomY)
        Scathach = ChopImage(Image.FromFile(GetFile("image46")), New Size(334, 501))
        place26_1.Location = New Point(scene.Width - place26_1.Width, 170*ZoomY)
    End Sub

    Private Function ChopImage(MainImage As Image, SizeRemained As Size) As Bitmap
        Dim img As New Bitmap(MainImage)
        Dim rc = New Rectangle(0, 0, SizeRemained.Width, SizeRemained.Height)
        Dim newImg As Bitmap = img.Clone(rc, PixelFormat.Format32bppArgb)
        Return newImg
    End Function

    Private Sub place1_1_click() '从时间隧道向前
        If Enable() = False Then Exit Sub
        If scene.Tag = 0 Then
            scene.Tag = 1
            Actor.Image = Scathach
            ShowCutscene(1100, Appearance.GradualChange, 0.05)
        Else
            SceneAppears(2, SwitchMode.gradual_change)
            If scene.Tag = 1 Then
                scene.Tag = 2
                ShowCutscene(2105, Appearance.ClimbUp, 10)
                Actor.Image = Image.FromFile(GetFile("image48"))
            End If
        End If
    End Sub

    Private Sub backward_click() '后退
        If Enable() = False Then Exit Sub
        If backward.Tag = 2 Then
            SceneAppears(1, SwitchMode.drag_down)
        ElseIf backward.Tag = 3 Then
            SceneAppears(2, SwitchMode.drag_left)
        ElseIf backward.Tag = 4 Then
            SceneAppears(3, SwitchMode.gradual_change)
        ElseIf backward.Tag = 5 Then
            SceneAppears(4, SwitchMode.gradual_change)
        ElseIf backward.Tag = 6 Then
            SceneAppears(2, SwitchMode.gradual_change)
        ElseIf backward.Tag = 8 Then
            SceneAppears(9, SwitchMode.gradual_change)
        ElseIf backward.Tag = 9 Then
            SceneAppears(8, SwitchMode.gradual_change)
            If scene.Tag = 6 Then
                scene.Tag = 7
                RemoveOut(lock8_3)
                PuzzlingMove(scene, place8_2, "image49", 20, 1)
            End If
        ElseIf backward.Tag = 10 Then
            SceneAppears(9, SwitchMode.drag_down)
        ElseIf backward.Tag = 11 Then
            If scene.Tag = 9 Then
                Tip("That may be our drillmaster> It's dangerous to go down now.")
                Exit Sub
            End If
            SceneAppears(10, SwitchMode.drag_down)
            If scene.Tag = 5 Then
                scene.Tag = 6
                PuzzlingMove(scene, backward, "image49", 20, 1)
            ElseIf scene.Tag = 10 Then
                scene.Tag = 11
                RemoveOut(lock10_5)
                PuzzlingMove(scene, place10_4, "image54")
            End If
        ElseIf backward.Tag = 12 Then
            SceneAppears(11, SwitchMode.gradual_change)
            If scene.Tag = 4 Then
                scene.Tag = 5
                PuzzlingMove(scene, backward, "image49", 20, 1)
            ElseIf scene.Tag = 8 Then
                scene.Tag = 9
                PuzzlingMove(place11_1, scene, "image54", 5, 2)
            End If
        ElseIf backward.Tag = 13 Then
            SceneAppears(8, SwitchMode.gradual_change)
        ElseIf backward.Tag = 14 Then
            Actor.Visible = False
            SceneAppears(11, SwitchMode.gradual_change)
            backward.Left = (scene.Width - backward.Width)/2
        ElseIf backward.Tag = 16 Then
            SceneAppears(6, SwitchMode.drag_right)
        ElseIf backward.Tag = 17 Then
            SceneAppears(16, SwitchMode.gradual_change)
        ElseIf backward.Tag = 19 Then
            SceneAppears(18, SwitchMode.gradual_change)
        ElseIf backward.Tag = 20 Then
            SceneAppears(19, SwitchMode.gradual_change)
        ElseIf backward.Tag = 21 Then
            SceneAppears(19, SwitchMode.drag_right)
        ElseIf backward.Tag = 22 Then
            SceneAppears(21, SwitchMode.gradual_change)
        ElseIf backward.Tag = 23 Then
            SceneAppears(22, SwitchMode.gradual_change)
        ElseIf backward.Tag = 24 Then
            SceneAppears(23, SwitchMode.gradual_change)
        ElseIf backward.Tag = 26 Then
            SceneAppears(18, SwitchMode.gradual_change)
        ElseIf backward.Tag = 27 Then
            SceneAppears(26, SwitchMode.gradual_change)
        ElseIf backward.Tag = 28 Then
            SceneAppears(27, SwitchMode.gradual_change)
        End If
    End Sub

    Private Sub place2_1_click() '进入军营内部
        If Enable() = False Then Exit Sub
        If disallow2_2.Visible Then
            deselect()
            Tip("The drillmaster disallows you. You may should find a way to change the music.")
        Else
            SceneAppears(6, SwitchMode.gradual_change)
        End If
    End Sub

    Private Sub place2_3_click() '军营外侧锁的门
        If Enable() = False Then Exit Sub
        If lock2_4.Visible Then
            If SelectedItem().Tag.ToString = "" Then

            Else
                deselect()
                Tip("A locked small door.")
            End If
        Else

        End If
    End Sub

    Private Sub place2_5_click() '右侧丛林
        If Enable() = False Then Exit Sub
        SceneAppears(3, SwitchMode.drag_right)
    End Sub

    Private Sub place3_1_click()
        If Enable() = False Then Exit Sub
        SceneAppears(4, SwitchMode.gradual_change)
    End Sub

    Private Sub radio3_2_click()
        If Enable() = False Then Exit Sub
        If SelectedItem.Tag.ToString = "duck tape" Then
            UseItem(radio3_2, 0)
        Else
            Tip("Radio.")
        End If
    End Sub

    Private Sub place4_1_click() '进入鸭哥小屋
        If Enable() = False Then Exit Sub
        SceneAppears(5, SwitchMode.gradual_change)
        If scene.Tag = 2 Then
            scene.Tag = 3
            ShowCutscene(2765, Appearance.ClimbUp, 7.5)
            Actor.Image = Image.FromFile(GetFile("image43"))
        End If
    End Sub

    Private Sub place6_1_click()
        If Enable() = False Then Exit Sub
        SceneAppears(7, SwitchMode.drag_right)
    End Sub

    Private Sub place6_2_click()
        If Enable() = False Then Exit Sub
        If scene.Tag >= 13 Then
            SceneAppears(16, SwitchMode.drag_left)
            If scene.Tag = 13 Then
                scene.Tag = 14
                ShowCutscene(4190, Appearance.Appear)
            End If
        Else
            Tip("The drillmasters are going on patrol there.")
        End If
    End Sub

    Private Sub place7_1_click()
        If Enable() = False Then Exit Sub
        SceneAppears(6, SwitchMode.drag_left)
    End Sub

    Private Sub place7_2_click() '进入军训宿舍楼
        If Enable() = False Then Exit Sub
        SceneAppears(8, SwitchMode.gradual_change)
    End Sub

    Private Sub place8_1_click() '离开军训宿舍楼
        If Enable() = False Then Exit Sub
        SceneAppears(7, SwitchMode.gradual_change)
    End Sub

    Private Sub place8_2_click()
        If Enable() = False Then Exit Sub
        If lock8_3.Visible Then
            deselect()
            Tip("A locked small door.")
        Else
            SceneAppears(13, SwitchMode.drag_right)
            If scene.Tag = 7 Then
                scene.Tag = 8
                ShowCutscene(3200, Appearance.Appear)
            End If
        End If
    End Sub

    Private Sub place9_1_click()
        If Enable() = False Then Exit Sub
        SceneAppears(10, SwitchMode.drag_up)
    End Sub

    Private Sub place10_1_click()
        If Enable() = False Then Exit Sub
        SceneAppears(11, SwitchMode.drag_up)
    End Sub

    Private ChangingMessage As String,
            ChangingMessageClicker As String,
            CurrentChar As Integer,
            CurrentReceiveChar As Integer

    Private Sub MessageWeaver_Tick(sender As Object, e As EventArgs) Handles MessageWeaver.Tick
        MessageWeaver.Tag += 5
        If MessageWeaver.Tag > 255 Then MessageWeaver.Tag = 255
        If MessageWeaver.Tag < 0 Then
            message_clicker.ForeColor = Color.FromArgb(0, 0, - MessageWeaver.Tag)
            message_box.BackColor = Color.FromArgb(- MessageWeaver.Tag, - MessageWeaver.Tag, - MessageWeaver.Tag)
        ElseIf MessageWeaver.Tag = 0 Then
            message.Text = ""
            message_clicker.Text = ""
            If ChangingMessage = "" Then
                MessageWeaver.Enabled = False
                message_box.Visible = False
            End If
        Else
            message_clicker.ForeColor = Color.FromArgb(0, 0, MessageWeaver.Tag)
            message_box.BackColor = Color.FromArgb(MessageWeaver.Tag, MessageWeaver.Tag, MessageWeaver.Tag)
            If CurrentChar < ChangingMessage.Length Then
                message.Text = message.Text & ChangingMessage.Substring(CurrentChar, 1)
                CurrentChar += 1
            Else
                If CurrentReceiveChar < ChangingMessageClicker.Length Then
                    message_clicker.Text = message_clicker.Text & ChangingMessageClicker.Substring(CurrentChar, 1)
                    CurrentReceiveChar += 1
                End If
            End If
            If MessageWeaver.Tag = 255 And CurrentReceiveChar = ChangingMessageClicker.Length Then
                MessageWeaver.Enabled = False
                message_clicker.Enabled = True
            End If
        End If
    End Sub

    ''' <summary>
    '''     在信息提示栏目中显示信息。
    ''' </summary>
    ''' <param name="content">信息的内容。</param>
    ''' <param name="link_content">可供用户点击的信息内容。</param>
    ''' <param name="FirstShow">第一次展示时，需要设置Visible值，并使用不同效果登场。</param>
    Private Sub ShowMessage(code As Integer, content As String, Optional link_content As String = "Next.",
                            Optional FirstShow As Boolean = False)
        If FirstShow Then
            message_box.BackColor = Color.Black
            message_clicker.ForeColor = Color.Black
            message_clicker.Enabled = False
            message_box.Visible = True
        End If
        CurrentChar = 0
        CurrentReceiveChar = 0
        message_box.BringToFront()
        If FirstShow Then MessageWeaver.Tag = - 5 Else MessageWeaver.Tag = - 255
        ChangingMessage = content
        ChangingMessageClicker = link_content
        MessageWeaver.Enabled = True
        message_clicker.Tag = code
        message_clicker.Enabled = False
    End Sub

    Private Sub message_clicker_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) _
        Handles message_clicker.LinkClicked
        If MessageWeaver.Enabled Then Exit Sub
        If message_clicker.Tag = 0 Then
            ShowMessage(1,
                        "Drillmaster:" & vbCrLf &
                        "It's a strange cult organized in the dormitory. No more speaking, fast go down, catch that guy, then report me!",
                        "Yes.")
        ElseIf message_clicker.Tag = 1 Then
            subActor.Visible = True
            subActor.Image = Image.FromFile(GetFile("image55"))
            subActor.Parent = Actor
            subActor.BringToFront()
            subActor.Size = New Size(Actor.Width, Actor.Height - dialogue.Height)
            subActor.Location = New Point(0, dialogue.Bottom)
            subActor.SizeMode = PictureBoxSizeMode.Zoom
            ShowMessage(2, "Drillmaster:" & vbCrLf & "I give you my sword, rush down!", "Yes!")
        ElseIf message_clicker.Tag = 2 Then
            subActor.Visible = False
            Form1.weapon_level = 4
            ShowMessage(3, " ", "Back.")
            NewMission("Defeat the turkey cult adorer.",
                       "We can hardly imagine how surreal it is, but things always go strangely.", 2)
        ElseIf message_clicker.Tag = 3 Then
            Actor.Visible = False
            SceneAppears(11, SwitchMode.drag_left)
            ShowMessage(0, "")
        ElseIf message_clicker.Tag = 4 Then
            ShowMessage(0, "")
            cutscenes.Enabled = True
        End If
    End Sub

    Private Sub place10_2_click() '写有411抓鸡总部的门
        If Enable() = False Then Exit Sub
        If lock10_3.Visible Then
            If SelectedItem().Tag.ToString = "" Then

            Else
                deselect()
                Tip("A locked door.")
            End If
        Else

        End If
    End Sub

    Private Sub place10_4_click() '进入左边的DistortedSoldier门
        If Enable() = False Then Exit Sub
        If lock10_5.Visible Then
            deselect()
            Tip("A locked door.")
        Else
            SceneAppears(15, SwitchMode.gradual_change)
            If scene.Tag = 11 Then
                scene.Tag = 12
                ShowCutscene(3625, Appearance.Appear)
            End If
        End If
    End Sub

    Private Sub deadrooster_off_Click(sender As Object, e As EventArgs) Handles deadrooster_off.Click
        Unable = False
        deadrooster.Visible = False
    End Sub

    Private Sub place11_1_click() '进入教官室
        If Enable() = False Then Exit Sub
        If scene.Tag >= 9 Then
            SceneAppears(14, SwitchMode.gradual_change)
            If scene.Tag = 9 Then
                scene.Tag = 10
                ShowCutscene(3590, Appearance.Appear)
            ElseIf scene.Tag = 10 Or scene.Tag = 11 Then
                Actor.Visible = True
                Actor.Top = 0
                Actor.Image = Image.FromFile(GetFile("image48"))
                Tip("You should go down and catch that guy.")
                ShowMessage(3, " ", "Back.", True)
            ElseIf scene.Tag = 12 Then
                scene.Tag = 13
                ShowCutscene(3680, Appearance.Appear)
            End If
        Else
            Tip("The drillmaster is inside.")
        End If
    End Sub

    Private Sub place11_2_click() '进入411
        If Enable() = False Then Exit Sub
        SceneAppears(12, SwitchMode.gradual_change)
        If scene.Tag = 3 Then
            scene.Tag = 4
            ShowCutscene(3125, Appearance.Appear)
        End If
    End Sub

    Private Sub place13_1_click() '隔间教堂向前
        If Enable() = False Then Exit Sub
        If lock13_2.Visible Then
            If SelectedItem().Tag.ToString = "" Then

            Else
                deselect()
                Tip("A locked door.")
            End If
        Else

        End If
    End Sub

    Private Function CanChange_BothChange(player1 As Boolean, value As Integer)
        If LifeWeaver.Enabled Then
            Return False
        Else
            If player1 Then LifeWeaver.Tag = "1:" & value Else LifeWeaver.Tag = "2:" & value
            LifeWeaver.Enabled = True
            Return True
        End If
    End Function

    Private Sub LifeWeaver_Tick(sender As Object, e As EventArgs) Handles LifeWeaver.Tick
        Dim targetplayer As Integer = LifeWeaver.Tag.ToString.Split(":")(0)
        Dim targetlife As Integer = LifeWeaver.Tag.ToString.Split(":")(1)
        If targetplayer = 1 Then
            If targetlife > backbar1.Tag Then
                targetlife = backbar1.Tag
                LifeWeaver.Tag = "1:" & targetlife
            End If
            If frontbar1.Tag < targetlife Then frontbar1.Tag += 10
            If frontbar1.Tag > targetlife Then
                If backbar1.Tag = 4000 Then frontbar1.Tag -= 25 Else frontbar1.Tag -= 10
            End If
            If frontbar1.Tag > targetlife - 10 And frontbar1.Tag < targetlife + 10 Then
                frontbar1.Tag = targetlife
                LifeWeaver.Enabled = False
                effect1.Image = Nothing
            End If
        Else
            If targetlife > backbar2.Tag Then
                targetlife = backbar2.Tag
                LifeWeaver.Tag = "2:" & targetlife
            End If
            If frontbar2.Tag < targetlife Then frontbar2.Tag += 10
            If frontbar2.Tag > targetlife Then frontbar2.Tag -= 10
            If frontbar2.Tag > targetlife - 10 And frontbar2.Tag < targetlife + 10 Then
                frontbar2.Tag = targetlife
                LifeWeaver.Enabled = False
                effect2.Image = Nothing
            End If
        End If
        refresh_battleland()
    End Sub

    Private Sub refresh_battleland()
        If frontbar1.Tag < 0 Then frontbar1.Tag = 0
        If frontbar2.Tag < 0 Then frontbar2.Tag = 0
        life1.Text = Form7.AddDot(frontbar1.Tag)
        life2.Text = Form7.AddDot(frontbar2.Tag)
        frontbar1.Width = frontbar1.Tag/backbar1.Tag*backbar1.Width
        frontbar2.Width = frontbar2.Tag/backbar2.Tag*backbar2.Width
        frontbar1.BackColor = Color.FromArgb(255*(1 - frontbar1.Tag/backbar1.Tag), 255*frontbar1.Tag/backbar1.Tag, 0)
        frontbar2.BackColor = Color.FromArgb(255*(1 - frontbar2.Tag/backbar2.Tag), 255*frontbar2.Tag/backbar2.Tag, 0)
    End Sub

    Private Sub place15_1_click() '从小宿舍返回
        If Enable() = False Then Exit Sub
        SceneAppears(10, SwitchMode.gradual_change)
    End Sub

    Private Sub rooster16_1_click()
        If Enable() = False Then Exit Sub
        Unable = True
        deadrooster.Visible = True
        deadrooster.Size = New Size(700*ZoomX, 480*ZoomY)
        deadrooster.Location = New Point(90*ZoomX, 50*ZoomY)
        deadrooster.BackgroundImageLayout = ImageLayout.Stretch
        Tip("The rooster is dead! What means ""Illusive Lust""??")
    End Sub

    Private Sub place16_2_click() '进入食堂
        If Enable() = False Then Exit Sub
        SceneAppears(17, SwitchMode.gradual_change)
        If scene.Tag = 14 Then
            scene.Tag = 15
            ShowCutscene(4810, Appearance.Appear)
        End If
    End Sub

    Private Sub place16_3_click() '从食堂外侧回到广场
        If Enable() = False Then Exit Sub
        SceneAppears(6, SwitchMode.drag_right)
    End Sub

    Private Sub place18_1_click() '到前门圣地
        If Enable() = False Then Exit Sub
        If lock18_2.Visible Then

        Else
            SceneAppears(26, SwitchMode.gradual_change)
        End If
    End Sub

    Private Sub place18_3_click() '侧门的通道
        If Enable() = False Then Exit Sub
        SceneAppears(19, SwitchMode.gradual_change)
    End Sub

    Private Sub place19_1_click() '往左边走
        If Enable() = False Then Exit Sub
        SceneAppears(21, SwitchMode.drag_left)
    End Sub

    Private Sub place19_2_click() '向前走
        If Enable() = False Then Exit Sub
        SceneAppears(20, SwitchMode.gradual_change)
    End Sub

    Private Sub place21_1_click() '走廊第一间
        If Enable() = False Then Exit Sub
        SceneAppears(23, SwitchMode.gradual_change)
    End Sub

    Private Sub place21_2_click() '走廊第二间
        If Enable() = False Then Exit Sub
        If lock21_3.Visible Then

        Else
            SceneAppears(22, SwitchMode.gradual_change)
        End If
    End Sub

    Private Sub place21_4_click() '走廊第三间
        If Enable() = False Then Exit Sub
        If lock21_5.Visible Then

        Else
            SceneAppears(25, SwitchMode.gradual_change)
        End If
    End Sub

    Private Sub place23_1_click() '小隔间向前
        If Enable() = False Then Exit Sub
        SceneAppears(24, SwitchMode.gradual_change)
    End Sub

    Private Sub place25_1_click() '外侧返回
        If Enable() = False Then Exit Sub
        SceneAppears(21, SwitchMode.gradual_change)
    End Sub

    Private Sub place25_2_click() '外侧向右
        If Enable() = False Then Exit Sub
        SceneAppears(7, SwitchMode.gradual_change)
    End Sub

    Private Sub place26_1_click() '内侧向上
        If Enable() = False Then Exit Sub
        SceneAppears(27, SwitchMode.gradual_change)
    End Sub

    Private Sub place27_1_click()
        If Enable() = False Then Exit Sub
        SceneAppears(28, SwitchMode.gradual_change)
    End Sub

    Private Sub place28_1_click() '圣坛
        If Enable() = False Then Exit Sub
    End Sub

    ''' <summary>
    '''     如果存在，则显示一个物品在屏幕上。
    ''' </summary>
    ''' <param name="tile">物品。</param>
    ''' <param name="ImageCode">图片编码。</param>
    ''' <param name="opposite">相反的判定。</param>
    Private Sub AddTile(tile As PictureBox, ImageCode As Integer, Optional opposite As Boolean = False)
        Controls.Add(tile)
        tile.Parent = scene
        tile.BackColor = Color.Transparent
        tile.SizeMode = PictureBoxSizeMode.StretchImage
        tile.Image = scene_icon.Images(ImageCode)
        If Form1.Unlocked.Items.Contains(tile.Name & "*") Then
            tile.Visible = opposite
        Else
            If opposite Then tile.Visible = False Else tile.Visible = True
        End If
    End Sub

    ''' <summary>
    '''     将物品从屏幕上移出。
    ''' </summary>
    ''' <param name="tile">物品。</param>
    Private Sub RemoveOut(tile As Control)
        tile.Visible = False
        Form1.Unlocked.Items.Add(tile.Name & "*")
    End Sub

    Public Sub AfterBattle(code As Integer)
        Form1.music.settings.volume = Form1.BackgroundVolume
        If code = 1 Then
            cutscenes.Tag = 1619
            cutscenes.Enabled = True
            Form1.music.settings.volume = Form1.BackgroundVolume
            Form1.music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music17.wm"
        ElseIf code = 2 Then
            Form1.magics.Items.Remove("Water egg")
            Form1.magics.Items.Remove("Cockscomb gun")
            Form1.magics.Items.Remove("Solar light")
            Form1.magics.Items.Remove("Fireball")
            Form1.magics.Items.Remove("Snowflake")
            cutscenes.Enabled = True
            Form1.music.settings.volume = Form1.BackgroundVolume
            Form1.music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music17.wm"
        ElseIf code = 3 Then
            cutscenes.Enabled = True
            Form1.music.settings.volume = Form1.BackgroundVolume
            Form1.music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music17.wm"
            CompleteMission("Defeat the turkey cult adorer.")
        ElseIf code = 4 Then
            MsgBox("Your patience is admirable, so you have got a chance to battle again.", 0,
                   "We admire your patience.")
            Hide()
            Form7.Show()
            Form7.initialization(Nothing, Nothing, Nothing, 350 + Form1.shield_level*150, 20, 24, 0, 110, 0, 950)
            Form1.music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music8.wm"
        End If
    End Sub

    Private Sub Disappear()
        place1_1.Visible = False
        backward.Visible = False
        place2_1.Visible = False
        disallow2_2.Visible = False
        place2_3.Visible = False
        lock2_4.Visible = False
        place2_5.Visible = False
        place3_1.Visible = False
        radio3_2.Visible = False
        place4_1.Visible = False
        place6_1.Visible = False
        place6_2.Visible = False
        place7_1.Visible = False
        place7_2.Visible = False
        place8_1.Visible = False
        place8_2.Visible = False
        lock8_3.Visible = False
        place9_1.Visible = False
        place10_1.Visible = False
        place10_2.Visible = False
        lock10_3.Visible = False
        place10_4.Visible = False
        lock10_5.Visible = False
        place11_1.Visible = False
        place11_2.Visible = False
        ice12_1.Visible = False
        place13_1.Visible = False
        lock13_2.Visible = False
        place15_1.Visible = False
        place16_2.Visible = False
        rooster16_1.Visible = False
        place16_3.Visible = False
    End Sub

    Private ReadOnly _
        PuzzlingMover As New PictureBox With {.BackColor = Color.Transparent, .SizeMode = PictureBoxSizeMode.Zoom}

    Private ZoomTarget As Control, ZoomSource As Control, TotalLong As Integer, MoveSpeedPuzzling As Integer

    Private ReadOnly _
        ActorLeft As _
            New PictureBox With {.BackColor = Color.Transparent, .SizeMode = PictureBoxSizeMode.Zoom, .Visible = False}

    Private ReadOnly _
        ActorRight As _
            New PictureBox With {.BackColor = Color.Transparent, .SizeMode = PictureBoxSizeMode.Zoom, .Visible = False}

    Private ReadOnly _
        SubActorLeft As _
            New PictureBox With {.BackColor = Color.Transparent, .SizeMode = PictureBoxSizeMode.Zoom, .Visible = False}

    ''' <summary>
    '''     使一个控件(新建的控件)从一个地点缩放并转移到另外一个地点。
    ''' </summary>
    ''' <param name="source">来源。</param>
    ''' <param name="target">移动目标。</param>
    Private Sub PuzzlingMove(source As Control, target As Control, image_ As String, Optional speed As Integer = 10,
                             Optional AffectCode As Integer = - 1)
        With PuzzlingMover
            .Parent = scene
            .Size = source.Size
            .Location = source.Location
            .Image = Image.FromFile(GetFile(image_))
            .BackColor = Color.Transparent
        End With
        Controls.Add(PuzzlingMover)
        ZoomTarget = target
        ZoomSource = source
        TotalLong = Math.Pow(Math.Pow(target.Left - source.Left, 2) + Math.Pow(target.Top - source.Top, 2), 0.5)
        MoveSpeedPuzzling = speed
        AffectCode_ = AffectCode
        MoveItemTab = - 1
        MoveItem.Enabled = True
    End Sub

    Private Sub BattlelandInitialize(life1_ As Integer, life2_ As Integer)
        battle_land.BackColor = Color.Transparent
        battle_land.Parent = scene
        effect1.BackColor = Color.Transparent
        effect2.BackColor = Color.Transparent
        effect1.Parent = battler1
        effect2.Parent = battler2
        effect1.Location = New Point(0, 0)
        effect2.Location = New Point(0, 0)
        life1.BackColor = Color.Transparent
        life1.Parent = battler1
        life2.BackColor = Color.Transparent
        life2.Parent = battler2
        life1.Location = New Point(life1.Left - battler1.Left, life1.Top - battler1.Top)
        life2.Location = New Point(life2.Left - battler2.Left, life2.Top - battler2.Top)
        battle_land.Visible = True
        frontbar1.Tag = life1_
        backbar1.Tag = life1_
        frontbar2.Tag = life2_
        backbar2.Tag = life2_
        refresh_battleland()
        battle_land.Size = New Size(800*ZoomX, 500*ZoomY)
        battle_land.Location = New Point(40*ZoomX, 40*ZoomY)
        battler1.Location = New Point(6*ZoomX, 33*ZoomY)
        battler2.Location = New Point(474*ZoomX, 33*ZoomY)
        battle_land.BringToFront()
    End Sub

    ''' <summary>
    '''     修改图片透明度。
    ''' </summary>
    ''' <param name="Bitmaps">要修改的图片</param>
    ''' <param name="OPacitys">透明度(0~1)。</param>
    ''' <returns></returns>
    Private Function ChangeAlpha(Bitmaps As Bitmap, OPacitys As Single) As Bitmap
        Dim CColorMatrix()() As Single = {New Single() {1, 0, 0, 0, 0}, New Single() {0, 1, 0, 0, 0},
                                          New Single() {0, 0, 1, 0, 0}, New Single() {0, 0, 0, OPacitys, 0},
                                          New Single() {0, 0, 0, 0, 0}}    '初始化颜色比例参数,用OPacitys属性来代替透明度,最大为1,最小为0  
        Dim CM = New ColorMatrix(CColorMatrix)   '用颜色比例参数去实例化颜色矩阵  
        If Bitmaps Is Nothing Then Return Nothing   '如果没有图片资源，则退出过程  
        Dim BBitmap As Bitmap = Bitmaps.Clone   '制作一个当前图像的浅表副本  
        Dim IA As New ImageAttributes       '实例化一个图像辅助类(包含了图像属性)  
        IA.SetColorMatrix(CM, ColorMatrixFlag.Default, ColorAdjustType.Bitmap)  '定义图像属性  
        Dim NewImage = New Bitmap(Bitmaps.Width, Bitmaps.Height)
        Dim a As Graphics = Graphics.FromImage(NewImage)
        a.DrawImage(BBitmap, New Rectangle(0, 0, BBitmap.Width, BBitmap.Height), 0, 0, BBitmap.Width, BBitmap.Height,
                    GraphicsUnit.Pixel, IA)  '利用设定好的图像属性去画出源图像
        Return NewImage
    End Function
End Class