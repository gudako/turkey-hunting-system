Imports System.Text

Public Class Form1
    'MODERN
    Public Const height_append As Integer = 70
    Public Const width_append As Integer = 5

    'ANCIENT
    Public step_ As Integer = 0
    Public epilogue As Boolean = False
    Public destroy_nest As Boolean = False
    Public required_labkey As Boolean = False
    Public labkey As Boolean = False
    Private TargetHeight As Integer
    Private AfterSettingHeight_code As Integer
    Public duck_office As Boolean = False
    Public six_god As Boolean = False
    Public revive As Integer = 0
    Public hen_egg As Boolean = False
    Public shield_level As Integer = 0
    Public weapon_level As Integer = 0
    Public witch_book As Boolean = False
    Public magics As ListBox = New ListBox
    Public defeat_hen As Boolean = False
    Public heal As Integer = 0
    Public TargetWidth As Integer
    Private AfterSettingWidth_code As Integer
    Public potion_existed As Boolean = True
    Public items As ListBox = New ListBox
    Public OnFire As Boolean = False
    Private CurrentPlace As Label = p1
    Public Unlocked As ListBox = New ListBox
    Public ItemBox As PictureBox() = {Nothing, Nothing, Nothing, Nothing, Nothing}
    Private ReadOnly MovingItem As PictureBox = New PictureBox With {.Visible = False}
    Private MoveTarget As Control
    Private MoveSource As Control
    Private AddItemName As String
    Private UseItemCode As Integer, DrawerAffectTarget As PictureBox

    Private ReadOnly _
        TipBox As Label = New Label _
        With {.Location = New Point(0, 0), .Font = New Font("微软雅黑", 16.2!, FontStyle.Regular, GraphicsUnit.Point, 134),
        .BackColor = Color.Black, .ForeColor = Color.White, .Visible = True}

    Private ImportantTip As Boolean = False,
            ResponseCode As Integer = 0,
            DeathFlag As Boolean = False,
            Temp1 As Boolean = True,
            MoveSpeed As Integer = 1,
            MoveHydrogenPeroxide As Boolean = False,
            MP3mixture As Boolean = False

    Friend DeathFlagNum As Integer = 0,
           BackgroundVolume As Integer = 67,
           Drawer As PictureBox() = {drawer1, drawer2, drawer3, drawer4},
           Unable As Boolean = False

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If step_ = 0 Then
            If _
                MsgBox("You can exit, but it require a hunted turkey, do you have it?", vbYesNo + vbExclamation,
                       "Exit the system") = vbYes Then
                MsgBox("You have no turkey, you can't exit.")
            End If
        ElseIf step_ = 1 Then
            If number.Value = 6 Then
                step_ = 2
                MsgBox("Good! It truly is in class 6, now let us go to the class and hunt him.", 64, "Level Complete!")
                number.Enabled = False
                Button2.Text = "Run!"
                content.Text = "Now we should run to class 6 to hunt him!"
                bar.Visible = True
            Else
                If number.Value = 1 Then
                    MsgBox("No, he isn't in experimental class. Choose another one.", 48, "Wrong")
                ElseIf number.Value = 0 Then
                    MsgBox("There's probably no class 0.", 48, "Wrong")
                ElseIf number.Value = - 1 Then
                    GameOver("You dive into underground and run out of the Earth.")
                Else
                    MsgBox("No, he isn't in class " & number.Value & ". Choose another one.", 48, "Wrong")
                End If
            End If
        ElseIf step_ = 2 Then
            content.Text = "Please wait while we are running to the class."
            Timer1.Enabled = True
            Button2.Enabled = False
        ElseIf step_ = 5 Then
            step_ = 6
            Button2.Text = "Fight!"
            content.Text = "The egg started bumping you, you must defeat the egg and pick it up!"
        ElseIf step_ = 6 Then
            Hide()
            Form7.Show()
            Form7.initialization(0, 0, 0, 300, 60, 0)
            music.settings.volume = 100
            music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music7.wm"
            Form7.StartTutorial()
        ElseIf step_ = 7 Then
            step_ = 8
            If Not mute.Checked Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound5.wm")
            content.Text = "A big turkey voice spreads out from the teaching building!"
            Button2.Text = "Next."
        ElseIf step_ = 8 Then
            step_ = 9
            bar.Visible = True
            bar.Value = bar.Minimum
            bar.Maximum = 360
            Timer1.Enabled = True
            Button2.Enabled = False
            content.Text = "Running to the teaching building..."
        ElseIf step_ = 9 Then
            Button2.Visible = False
            bar.Visible = False
            SetHeight(427, 0)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If step_ = 0 Then
            If MsgBox("Are you ready for hunting the turkey?", vbQuestion + vbYesNo, "Get ready!") = vbYes Then
                step_ = 1
                MsgBox("Ok, let's go on.", 64, "Start!")
                Button1.Visible = False
                Button2.Text = "Yes."
                number.Visible = True
                music.settings.setMode("loop", True)
                music.settings.volume = BackgroundVolume
                music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music1.wm"
                content.Text =
                    "To hunt the turkey, we surely should know his location, probably he is in class now. Enter which class contains the turkey."
                topic.Text = "Intro"
                topic.Visible = True
                DifTip.Visible = True
                RemoveTitle.Enabled = True
                number.Minimum = - 1
                number.Value = 0
            End If
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If step_ = 2 Then
            bar.Value += 1
            If bar.Value = bar.Maximum Then
                Timer1.Enabled = False
                MsgBox("The turkey isn't in class, we must search another place.", 64, "Not in class.")
                step_ = 3
                bar.Visible = False
                number.Visible = False
                Button2.Visible = False
                Button3.Visible = True
                Button4.Visible = True
                Button5.Visible = True
                content.Text = "Please choose a place Where the turkey is in."
            End If
        ElseIf step_ = 9 Then
            bar.Value += 1
            If bar.Value = bar.Maximum Then
                Timer1.Enabled = False
                Button2.Enabled = True
                content.Text = "We'll find where the turkey is."
                Button2.Text = "Yes."
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If step_ = 3 Then
            MsgBox("Let's us go to the teacher office.", 64, "Go to office.")
            Form4.Show()
            Form4.start("There're teachers in the office, probably turkey is in it. Shall we rush into it?", "Rush it!",
                        0, "Go out quietly.", 1)
        ElseIf step_ = 4 Then
            MsgBox("Yes, maybe it's sitting on the stair: turkey likes sitting there, let's go.")
            Form5.start(3, "Target: Stairs.", 4.7)
        End If
    End Sub

    Public Sub Choosing(code As Integer)
        If code = 0 Then
            Form5.Show()
            Form5.start(0, "Rushing into the office!", 7)
        ElseIf code = 1 Then
            MsgBox("You went back, let's choose another place.")
        ElseIf code = 2 Then
            Form5.Show()
            Form5.start(2, "Please wait while we're destroying the turkey nest...", 9)
        ElseIf code = 3 Then
            MsgBox(
                "Then we should resume searching the turkey, there's other three places, maybe the turkey is in them. It's nest in toilet, it means the turkey is near.",
                64, "Resume")
            content.Text = "Maybe the turkey is in these places, choose one."
            Button3.Text = "The stairs"
            Button4.Text = "Playground"
            Button3.Width = 250
            step_ = 4
        ElseIf code = 4 Then
            labkey = True
            Form6.start("You pick up the key." & vbCrLf & "You get a new item: the lab key.", - 1)
        ElseIf code = 5 Then
            MsgBox("You went back. Choose another place.")
        ElseIf code = 6 Then
            MsgBox("You get a hen egg.", 64, "New item")
            hen_egg = True
            place3_4.Tag = 2
        ElseIf code = 7 Then
            place1_1.Tag = 1
            Form6.start("The door is opened.", 4)
        ElseIf code = 8 Then
            Hide()
            Form7.Show()
            Form7.initialization(0, 0, 0, 300, 140, 1)
            music.settings.volume = 100
            music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music7.wm"
            music.settings.setMode("loop", True)
        ElseIf code = 9 Then
            place2_2.Tag = 1
            MsgBox("There's no one inside.", 0, "Good.")
            Form5.start(10, "Searching in the forbidden area...", 7)
        ElseIf code = 10 Then
            Form6.start("There's no response. He seems as if has been petrified.", 27)
        ElseIf code = 11 Then
            MsgBox("Ok. Let's go out and resume searching for solar coins.")
        ElseIf code = 12 Then
            items.Items.Remove("Caesium")
            picturebox2.Tag = 37
            My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound32.wm")
            MsgBox("The stones're exploded!", 0, "Explode")
        End If
    End Sub

    Public Sub TimeDone(code As Integer)
        If code = 0 Then
            MsgBox("You've been caught by the teacher!!", 16, "Damn it!")
            GameOver("You're caught by the teacher. Now you have to to write self-criticism.")
        ElseIf code = 1 Then
            MsgBox("Oh, a big turkey nest!", 64, "Turkey nest is detected!")
            Form6.Show()
            Form6.start("The turkey isn't in it, but there's turkey nest inside the toilet, however there's no egg.", 0)
        ElseIf code = 2 Then
            destroy_nest = True
            Form6.Show()
            Form6.start("The nest is destroyed.", 1)
        ElseIf code = 3 Then
            Form6.start("Incorrect. The turkey isn't sitting there.", - 1)
        ElseIf code = 4 Then
            If labkey Then
                Form6.start("This time we cannot find anything.", - 1)
            Else
                If required_labkey Then
                    Form4.start(
                        "No turkey. However, on the playground, that's the lab key what we required! Shall we pick it?",
                        "Pick it.", 4, "Keep it on ground.", 5)
                Else
                    Form6.start("There's a key on ground with nothing else. We can't see the turkey. Go back.", - 1)
                End If
            End If
        ElseIf code = 5 Then
            If picturebox1.Tag = 12 Then
                picturebox1.Tag = 13
                disappear()
                picturebox1.Image =
                    Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene9.wm")
                place9_1.Visible = True
                MsgBox("The sound came from the building just now, rush it!", 48, "End of Chapter1")
            Else
                disappear()
                picturebox1.Image =
                    Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene2.wm")
                place1_1.Visible = True
                place1_2.Visible = True
                If Not six_god Then place1_3.Visible = True
                If place1_4.Tag = 1 Then place1_4.Visible = True
            End If
        ElseIf code = 6 Then
            disappear()
            picturebox1.Image =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene1.wm")
            place3_1.Visible = True
            place3_2.Visible = True
            place3_3.Visible = True
            place3_4.Visible = True
            place3_5.Visible = True
        ElseIf code = 7 Then
            Form11.Show()
            Form11.start(1, "New item!", "You find a bottle of six god on the construction plant!", "Pick it up.")
        ElseIf code = 8 Then
            MsgBox("Successfully dispelled the smell in toilet by using Six God.", 64, "Dispel")
            place3_4.Tag = 1
            MsgBox("Now you can go into the toilet and watch what happened.")
        ElseIf code = 9 Then
            disappear()
            picturebox1.Image =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene3.wm")
            place2_1.Visible = True
            If Not place2_3.Tag = 1 Then place2_2.Visible = True
            If Not place2_3.Tag = 1 Then place2_3.Visible = True
            If Not place2_4.Tag = 1 Then place2_4.Visible = True
            If picturebox1.Tag = 12 Then
                MsgBox("the current test is successful")
                End
            End If
        ElseIf code = 10 Then
            place2_3.Tag = 1
            If shield_level > 1 Then
                MsgBox("There's shield inside which is worse than yours.")
            Else
                shield_level = 1
                Form11.start(5, "New shield!",
                             "You find a light aluminic shield inside the area! Your defence'll be powered up.", "Done.")
            End If
        ElseIf code = 11 Then
            place1_4.Tag = 1
            MsgBox("!!", 48, "!!")
            place1_4.Tag = 1
            Form6.start("You find a syllabus. It shows the turkey is having PE class in basketball hall!", 5)
        ElseIf code = 12 Then
            disappear()
            picturebox1.Image =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene6.wm")
            place6_1.Visible = True
            If picturebox1.Tag = 2 Then
                picturebox1.Tag = 3
                MsgBox("There's no turkey!", 48, "Unluckily")
                Form6.start("The turkey ran down from another exit! rush down and catch it!", - 1)
            End If
        ElseIf code = 13 Then
            disappear()
            picturebox1.Image =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene5.wm")
            place5_1.Visible = True
            place5_2.Visible = True
        ElseIf code = 14 Then
            place8_4.Tag = 1
            place8_4.Visible = False
            MsgBox("There is nothing.", 64, "Nothing useful.")
        ElseIf code = 15 Then
            place9_1.Visible = False
            picturebox1.Visible = False
            picturebox2.Visible = True
            TargetWidth = 578
            TargetHeight = 479
            Timer2.Enabled = True
            Timer3.Enabled = True
            AfterSettingHeight_code = - 1
            AfterSettingWidth_code = - 1
            topic.Text = "Chapter2"
            topic.Visible = True
            topic.Width = picturebox2.Width
            DifTip.Visible = True
            RemoveTitle.Enabled = True
            picturebox2.Tag = 0
            Scene1Appears()
            SaveGame("Chapter2", "Comprehensive building", 1, False)
            savetip.Visible = True
            RemoveSaveTip.Enabled = True
        ElseIf code = 16 Then
            MsgBox("The turkey isn't on it. It's being prepared for the Turkey Hunting Quiz.", 48, "Information")
            MsgBox("We should run out, because the turkey probably has gone outside.", 0, "Tip")
        ElseIf code = 17 Then
            GainItem(printer107_2, "duck function")
        End If
    End Sub

    Public Sub GameOver(cause As String)
        mute.Enabled = False
        Hide()
        Form4.Hide()
        Form5.Hide()
        Form6.Hide()
        Form7.Hide()
        Form8.Hide()
        Form9.Hide()
        Form10.Hide()
        Form11.Hide()
        Form12.Hide()
        Form13.Hide()
        Form14.Hide()
        Form15.Hide()
        Form16.Hide()
        Form3.Show()
        music.Dispose()
        Form3.cause.Text = cause
        Form3.Timer1.Enabled = True
        If mute.Checked = False Then _
            My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound7.wm")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If step_ = 3 Then
            If _
                MsgBox("Maybe he is in toilet, we can rush into it!", MsgBoxStyle.Question + vbYesNo, "The toilet") =
                vbYes Then
                Form5.Show()
                Form5.start(1, "Rushing into the toilet.", 10)
            End If
        ElseIf step_ = 4 Then
            If _
                MsgBox("The playground may be a bit far, do you still want to go?", MsgBoxStyle.Question + vbYesNo,
                       "The playground") = vbYes Then
                Form5.start(4, "Target: Playground.", 13)
            End If
        End If
    End Sub

    Private Sub mute_CheckedChanged(sender As Object, e As EventArgs) Handles mute.CheckedChanged
        If mute.Checked Then
            music.Ctlcontrols.pause()
            music.settings.volume = 0
        Else
            music.Ctlcontrols.play()
            music.settings.volume = 100
        End If
    End Sub

    Public Sub Information(code As Integer)
        If code = 0 Then
            Form4.Show()
            Form4.start("Do you want to destroy the nest?", "Destroy it!", 2, "No, go out.", 3)
        ElseIf code = 1 Then
            Choosing(3)
        ElseIf code = 2 Then
            step_ = 5
            MsgBox("You opened the door and went inside. But there's something unusual......", 48, "Oops!")
            Button3.Visible = False
            Button4.Visible = False
            Button5.Visible = False
            Button2.Visible = True
            Button2.Text = "Next"
            Button2.Enabled = True
            content.Text = "The turkey egg becomes mad and jumped up and down! It started to attack!!"
        ElseIf code = 3 Then
            If hen_egg Then
                Form4.start("You have both two eggs, do you want to put them into the door and open it now?", "Open.", 7,
                            "Do not open.", - 1)
            Else
                Form6.start("You just have the turkey egg but the another one, so you can't open it.", - 1)
            End If
        ElseIf code = 4 Then
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound9.wm")
            Form4.start("Suddenly, a rabbit rushes out with something, do you want to snatch the thing?", "Snatch it!",
                        8, "Get away.", - 1)
        ElseIf code = 5 Then
            Form6.start("We must go to the basketball hall and catch the turkey fast!", - 1)
        ElseIf code = 6 Then
            Form6.start("The small black hen is being angry for her lost egg, she started attacking.", 7)
        ElseIf code = 7 Then
            If defeat_hen = False Then
                Hide()
                Form7.Show()
                defeat_hen = True
                Form7.initialization(weapon_level, shield_level, 0, 300 + shield_level*150, 500, 2)
                music.settings.setMode("loop", True)
                music.settings.volume = 100
                music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music7.wm"
            End If
        ElseIf code = 8 Then
            GameOver("This time you are quite doomed.")
        ElseIf code = 9 Then
            Form6.start("However, there is something strange. No. Absolutely abnormal.", 10)
        ElseIf code = 10 Then
            Form11.start(10, "Corona ball!",
                         "Oh my god! The English teacher has set corona ball near the door, it starts to attack! You must defeat it or it won't stop.",
                         "Fight!")
        ElseIf code = 11 Then
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound5.wm")
            Form6.start("The turkey's sound comes out from outside! He is fleeing away!", 12)
        ElseIf code = 12 Then
            picturebox1.Tag = 11
            Form6.start("Rush out the door! Fast it!", - 1)
        ElseIf code = 13 Then
            Form6.start("small black hen:" & vbCrLf & "You've stolen my egg! I'll push you down!", 7)
        ElseIf code = 14 Then
            Scene5Appears()
            Form11.start(15, "Mad murlocs", "They dragged you into the biology lab, it's full of smelly gas.", "Next→")
        ElseIf code = 15 Then
            Form11.start(16, "Assist!",
                         "Mr.Duck is going to support you, he can eat murlocs fast. You'd battle together!",
                         "To battle!")
        ElseIf code = 16 Then
            Form6.start("Chairman:" & vbCrLf & "Welcome, participant! Now let the match begin!", 17)
        ElseIf code = 17 Then
            Form6.start("Chairman:" & vbCrLf & "All participants, go up the rostrum! I'll explain the rules.", 18)
        ElseIf code = 18 Then
            MsgBox("You must go up the rostrum and join the quiz, or the chairman won't let go of you.")
        ElseIf code = 19 Then
            Form11.start(21, "Turkey Quiz", "Welcome to turkey hunting quiz! Are you ready?", "No.", "Yes.")
        ElseIf code = 20 Then
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound35.wm")
            MsgBox("What's the sound?", 0, "Oh!")
            MsgBox("It's our big smelly milk cow! He's in the biology lab!", 0, "Big milk cow")
            MsgBox("We must save him! Go up to the lab!", 0, "Big milk cow")
        ElseIf code = 21 Then
            Form6.start("I don't know what animal bit me because of my carefulness on giving milk.", 22)
        ElseIf code = 22 Then
            Form6.start("We should have a look on the microscope on platform, there's strange sounds coming out.", 23)
        ElseIf code = 23 Then
            MsgBox("Let's have a look on the telescope on platform.")
        ElseIf code = 24 Then
            Form6.start("I don't know what she is, and the reason why she did assault me, but it's true.", 25)
        ElseIf code = 25 Then
            Form6.start(
                "May you'd go up second floor on right side, just now I heard witch's laughter and turkey voice.", 26)
        ElseIf code = 26 Then
            MsgBox("You got the key.")
        ElseIf code = 27 Then
            MsgBox("You can only go out and search for another way to get the solar coin.")
        ElseIf code = 28 Then
            MsgBox("The big milk cow called you, he found something in biology lab.", 0, "Biology lab")
            place05_4.Tag = 1
        ElseIf code = 29 Then
            Form6.start("That turkey rushed into biology lab, I caught up, but I see nothing in the lab.", 30)
        ElseIf code = 30 Then
            Form6.start("The window is closed, there's no sign of the turkey at all. But I saw it exactly.", 31)
        ElseIf code = 31 Then
            Form6.start("Look, there is a book on ground!", 32)
        ElseIf code = 32 Then
            MsgBox("The X is the book.", 0, "Tip")
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If step_ = 3 Then
            Form6.Show()
            required_labkey = True
            Form6.start("The chemistry lab is locked, there's a turkey egg in it, but you cannot get it.", - 1)
        ElseIf step_ = 4 Then
            If labkey Then
                Form6.start("The door is able to be opened, let's open it and pick the egg in the lab.", 2)
            Else
                required_labkey = True
                Form6.start(
                    "There's a big turkey egg in the lab, but there's also a big lock on the door which blocked us from going inside.",
                    - 1)
            End If
        End If
    End Sub

    Public Sub AfterBattle(code As Integer)
        If code = 0 Then
            step_ = 7
            Button2.Text = "Go on."
            content.Text = "The egg stopped being mad." & vbCrLf & "You get a new item: the turkey egg."
            music.settings.volume = BackgroundVolume
            music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music1.wm"
        ElseIf code = 1 Then
            MsgBox("The turkey egg rolled out and reported the situation to the office.", 16, "Damn it!")
            GameOver("You've been caught by the teachers.")
        ElseIf code = 2 Then
            revive += 1
            Form11.start(2, "New item!",
                         "You get a Six God revival potion from the rabbit. You can use it when you get defeated in battle.",
                         "Yes.")
            music.settings.volume = BackgroundVolume
            music.settings.volume = BackgroundVolume
            music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music1.wm"
        ElseIf code = 3 Then
            music.settings.volume = BackgroundVolume
            music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music1.wm"
            MsgBox("The rabbit runs far away.", 48, "Defeat!")
        ElseIf code = 4 Then
            music.settings.volume = BackgroundVolume
            music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music1.wm"
            magics.Items.Add("Cockscomb gun")
            Form11.start(8, "New magic!", "You get a cockscomb gun from the hen!", "Yes.")
        ElseIf code = 5 Then
            Dim random_ = New Random(Date.Now.Millisecond)
            If random_.Next(1, 5) = 1 Then
                music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music1.wm"
                Form6.start("The hen has run away.", - 1)
            Else
                Form6.start("The hen went to find the grade leader.", 8)
            End If
        ElseIf code = 6 Then
            magics.Items.Add("Solar light")
            music.settings.volume = BackgroundVolume
            music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music1.wm"
            MsgBox(
                "The solar corona ball with R.X. power is broken up, you get a power of solar light. Now you can go to the class now.")
        ElseIf code = 7 Then
            GameOver("You can hardly escape out from class, surely the teacher'll catch you.")
        ElseIf code = 8 Then
            music.settings.volume = BackgroundVolume
            music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music1.wm"
            shield_level = 2
            MsgBox("You get the fish scale shield.", 64, "New shield!")
            Form6.start("What the hell happened in biology lab! We quite should have a look.", - 1)
        ElseIf code = 9 Then
            GameOver("Your meats are being eaten.")
        ElseIf code = 10 Then
            music.settings.volume = BackgroundVolume
            music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music1.wm"
            MsgBox("Mr.Duck comes inside. He will help you.")
            AfterBattle(12)
        ElseIf code = 11 Then
            Form6.start("Massive murlocs rush out from biology lab and surround you.", 14)
            music.settings.volume = BackgroundVolume
            music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music1.wm"
        ElseIf code = 12 Then
            music.settings.volume = BackgroundVolume
            music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music1.wm"
            MsgBox("All the murlocs are defeated, it is silent inside.")
            MsgBox("After lg3² seconds...")
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound27.wm")
            Form11.start(17, "Mixture creation!",
                         "Hahahahahaha!! Ao(ge)ao(ge)ao(ge)ao(ge)ao(ge)ao(ge)ao(ge)aoaoao(gegege)!!!", "Next→")
        ElseIf code = 13 Then
            GameOver("This time you have no way to escape.")
        ElseIf code = 14 Then
            music.settings.volume = BackgroundVolume
            music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music1.wm"
            MsgBox("You get a revival potion from the turk&fish.", 64, "Revival Potion")
            MsgBox("Well done! Let's go out from the terrifying biology lab. The turkey is still near.", 64,
                   "Well Done!")
        ElseIf code = 15 Then
            GameOver("The mixed monster turk&fish killed you and ate your skull.")
        ElseIf code = 16 Then
            heal += 1
            weapon_level = 2
            SaveGame("Chapter2", "Biology laboratory", 2, False)
            savetip.Visible = True
            RemoveSaveTip.Enabled = True
            music.settings.volume = BackgroundVolume
            music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music1.wm"
            MsgBox("You've got 2 things:" & vbCrLf & "Murloc sword," & vbCrLf & "1x SixGod Curative potion.", 64,
                   "After battle")
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound5.wm")
            Form11.start(19, "Turkey voice!", "The turkey cried again and rushed down from stairs! Catch up!", "Yes!")
        ElseIf code = 17 Then
            GameOver("You've been caught by the flying turk&fish lord.")
        ElseIf code = 18 Then
            music.settings.volume = BackgroundVolume
            music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music1.wm"
            MsgBox("The quiz is aborted.", 0, "Abortion!")
            Form6.start("Now the door is opened, we can go outside and resume hunting the turkey.", 20)
        ElseIf code = 19 Then
            music.settings.volume = BackgroundVolume
            music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music1.wm"
            MsgBox("Finally the cow calms down.", 0, "Big milk cow")
            Form6.start("Big milk cow:" & vbCrLf & "Just now the witch cast a spell on me which made me insane.", 24)
        ElseIf code = 20 Then
            GameOver("You've been destroyed.")
        ElseIf code = 21 Then
            music.settings.volume = BackgroundVolume
            music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music12.wm"
            MsgBox("Now let's open the book.")
        ElseIf code = 22 Then
            GameOver("-You become the witch's puppet..-")
        ElseIf code = 23 Then
            music.settings.volume = BackgroundVolume
            music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music12.wm"
            MsgBox("Now you should go to the Turkey catch association.", 0, "Next")
        ElseIf code = 24 Then
            GameOver("You've been eaten as the meal.")
        ElseIf code = 25 Then
            RemoveOut(lock27_2)
            AddTip("The guard is defeated.")
            music.settings.volume = BackgroundVolume
            music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music14.wm"
        ElseIf code = 26 Then
            GameOver("The king kills you.")
        ElseIf code = 27 Then
            lock26_1.Tag = 2
            Unlocked.Items.Remove("lock26_1")
            lock26_1.Image = ImageList1.Images(4)
            Unlocked.Items.Add("coin26_2")
            Scene001appears()
            AddTip("What happened? Where is Atropos?", True)
            music.settings.volume = BackgroundVolume
            music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music14.wm"
        ElseIf code = 28 Then
            PictureBox3.Tag = 6
            music.settings.volume = BackgroundVolume
            music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music14.wm"
            shield_level = 3
            weapon_level = 3
            magics.Items.Add("Homework generator")
            SaveGame("Chapter 3", "Aurora's palace", 5, False)
            MsgBox(
                "You get three things:" & vbCrLf & "Dragon paw" & vbCrLf & "Dragon armor shield" & vbCrLf &
                "Magic: Homework generator", 0, "Weapon&shield")
            actor.Image =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image6.wm")
            SendMessage("Tarecgosa:" & vbCrLf & "The fire... is too strong!!", 7)
            shining.Enabled = True
        ElseIf code = 29 Then
            GameOver("You are torn into piece.")
        ElseIf code = 30 Then
            music.settings.volume = BackgroundVolume
            music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music16.wm"
            actor.Image =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image2.wm")
            MoveAtropos.Tag = 2700
            MoveAtropos.Enabled = True
        ElseIf code = 31 Then
            GameOver("You have been possessed by the ghost and become slave.")
        ElseIf code = 32 Then
            MsgBox("Max Life + 50" & vbCrLf & "Max Mana + 10" & vbCrLf & "Restore speed + 0.05", 0, "Level up!")
            MoveAtropos.Enabled = True
            music.settings.volume = BackgroundVolume
            music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music16.wm"
        ElseIf code = 33 Then
            GameOver("You belong to the witch.")
        ElseIf code = 34 Then
            MoveAtropos.Enabled = True
            music.settings.volume = BackgroundVolume
            music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music14.wm"
        ElseIf code = 35 Then
            GameOver("The duck pool god eats you.")
        ElseIf code = 36 Then
            If DeathFlagNum = 2 Then
                magics.Items.Add("H2S ejector")
                MsgBox("You get the H2S ejector.", 0, "New magic")
                MoveAtropos.Enabled = True
                music.settings.volume = BackgroundVolume
                music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music14.wm"
            Else
                MoveAtropos.Enabled = True
                music.settings.volume = BackgroundVolume
                music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music14.wm"
            End If
        ElseIf code = 37 Then
            GameOver("You belong to the witch.")
        ElseIf code = 38 Then
            RemoveOut(chicken72_2)
            GainItem(chicken72_2, "chicken")
            music.settings.volume = BackgroundVolume
            music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music14.wm"
        ElseIf code = 39 Then
            AddTip("You failed to catch the chicken.")
            music.settings.volume = BackgroundVolume
            music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music14.wm"
        ElseIf code = 40 Then
            actor.Image = Nothing
            actor.Visible = False
            Scene059appears()
            music.settings.volume = BackgroundVolume
            music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music14.wm"
            If Form7.ChangeCow > - 1 Then
                AddTip("Fantastic!!")
            End If
        ElseIf code = 41 Then
            GameOver("You become a negative positive phantom as well.")
        ElseIf code = 42 Then
            music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music18.wm"
            MoveAtropos.Enabled = True
        ElseIf code = 43 Then
            MoveAtropos.Tag = 13634
            MoveAtropos.Enabled = True
        ElseIf code = 44 Then
            GameOver("Yes. You failed.")
        End If
    End Sub

    Friend Sub SetHeight(height As Integer, code As Integer)
        TargetHeight = height + height_append
        Timer2.Enabled = True
        AfterSettingHeight_code = code
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If Height < TargetHeight Then
            Height += 1
        ElseIf Height > TargetHeight Then
            Height -= 1
        Else
            Timer2.Enabled = False
            AfterSetting(AfterSettingHeight_code)
        End If
        Left = (Screen.PrimaryScreen.Bounds.Width - Width)/2
        Top = (Screen.PrimaryScreen.Bounds.Height - Height)/2
    End Sub

    Private Sub AfterSetting(code As Integer)
        If code = 0 Then
            step_ = 10
            picturebox1.Visible = True
            place3_1.Visible = True
            place3_2.Visible = True
            place3_3.Visible = True
            place3_4.Visible = True
            place3_5.Visible = True
            BackColor = Color.White
            picturebox1.Image =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene1.wm")
            content.Text = "Please select a place to search the turkey." & vbCrLf & vbCrLf &
                           "The sound ensures the turkey is in the school."
            topic.Text = "Chapter1"
            topic.Visible = True
            DifTip.Visible = True
            RemoveTitle.Enabled = True
            SaveGame("Chapter1", "Floor3, Main building", 0, False)
            savetip.Visible = True
            RemoveSaveTip.Enabled = True
        End If
    End Sub

    Private Sub place3_5_Click(sender As Object, e As EventArgs) Handles place3_5.Click
        If step_ = 10 Then
            If (picturebox1.Tag = 8 Or picturebox1.Tag = 9) And place3_5.Tag = 0 Then
                place3_5.Tag = 1
                heal += 2
                Form11.start(11, "Curative potion", "You find two bottles of curative potion near Mr.Duck's seat.",
                             "Next")
            ElseIf (picturebox1.Tag = 8 Or picturebox1.Tag = 9) And place3_5.Tag = 1 Then
                MsgBox("There is nothing anymore.", 0, "Nothing.")
            Else
                Form6.start("The door of office is closed and locked.", - 1)
            End If
        End If
    End Sub

    Private Sub place3_4_Click(sender As Object, e As EventArgs) Handles place3_4.Click
        If step_ = 10 Then
            If place3_4.Tag = 1 Then
                If destroy_nest Then
                    Form4.start("There's a hen egg on the ground! What did it happen? Shall we pick it?", "Pick it.", 6,
                                "Ignore.", - 1)
                Else
                    Form4.start("There's a hen egg in the turkey nest! What did it happen? Shall we pick it?",
                                "Pick it.", 6, "Ignore.", - 1)
                End If
            ElseIf place3_4.Tag = 0 Then
                If six_god Then
                    Form11.Show()
                    Form11.start(0, "Unable to enter.", "The toilet becomes too smelly! Mortals cannot bear it.",
                                 "Go out.", "Use Six God to dispel.")
                Else
                    Form11.Show()
                    Form11.start(0, "Unable to enter.", "The toilet becomes too smelly! Mortals cannot bear it.",
                                 "Go out.")
                End If
            ElseIf place3_4.Tag = 2 Then
                Form6.start("There's nothing inside.", - 1)
            End If
        End If
    End Sub

    Private Sub place3_3_Click(sender As Object, e As EventArgs) Handles place3_3.Click
        If step_ = 10 Then
            If picturebox1.Tag = 12 Then
                MsgBox("It's unimportant to search here, go to the playground from another series of stairs.", 0,
                       "Useless.")
            Else
                MsgBox("The turkey isn't sitting there.", 0, "Useless.")
            End If
        End If
    End Sub

    Private Sub disappear()
        place3_1.Visible = False
        place3_2.Visible = False
        place3_3.Visible = False
        place3_4.Visible = False
        place3_5.Visible = False
        place1_1.Visible = False
        place1_2.Visible = False
        place1_3.Visible = False
        place1_4.Visible = False
        place2_1.Visible = False
        place2_2.Visible = False
        place2_3.Visible = False
        place2_4.Visible = False
        place4_1.Visible = False
        place4_2.Visible = False
        place4_3.Visible = False
        place5_1.Visible = False
        place5_2.Visible = False
        place6_1.Visible = False
        place7_1.Visible = False
        place7_2.Visible = False
        place8_1.Visible = False
        place8_2.Visible = False
        place8_3.Visible = False
        place8_4.Visible = False
        place8_5.Visible = False
    End Sub

    Private Sub place1_1_Click(sender As Object, e As EventArgs) Handles place1_1.Click
        If place1_1.Tag = 0 Then
            Form6.start("The door of library is closed, there're two holes on it, the holes are shaped like eggs.", 3)
        ElseIf place1_1.Tag = 1 Then
            If _
                MsgBox("The stairs'll lead you to the underground library.", vbOKCancel + vbQuestion, "Down to library") =
                vbOKCancel Then
                Form5.start(9, "Target: Library.", 5)
            End If
        End If
    End Sub

    Private Sub place1_2_Click(sender As Object, e As EventArgs) Handles place1_2.Click
        If step_ = 10 Then
            If MsgBox("You'll go up from here to teaching building.", vbOKCancel + vbQuestion, "Change scene") = vbOK _
                Then
                Form5.start(6, "Going up to the teaching building, floor 3...", 12)
            End If
        End If
    End Sub

    Private Sub place3_1_Click(sender As Object, e As EventArgs) Handles place3_1.Click
        If step_ = 10 Then
            If picturebox1.Tag = 12 Then
                If Not defeat_hen Then
                    Form6.start("Suddenly, an angry hen appeared!", 13)
                    Exit Sub
                End If
                MsgBox("Rush down!")
            End If
            If MsgBox("You'll go down from here to playground.", vbOKCancel + vbQuestion, "Change scene") = vbOK Then
                Form5.start(5, "Going down to the playground...", 8)
            End If
        End If
    End Sub

    Private Sub place1_3_Click(sender As Object, e As EventArgs) Handles place1_3.Click
        If step_ = 10 Then
            If six_god Then
                MsgBox("There's nothing.", 0, "Nothing")
            Else
                Form5.start(7, "Searching the construction plant...", 7)
            End If
        End If
    End Sub

    Private Sub place2_1_Click(sender As Object, e As EventArgs) Handles place2_1.Click
        If step_ = 10 Then
            If MsgBox("You'll go up the ground from library.", vbOKCancel + vbQuestion, "Up to ground") = vbOKCancel _
                Then
                Form5.start(5, "Target: Playground.", 7)
            End If
        End If
    End Sub

    Private Sub place2_3_Click(sender As Object, e As EventArgs) Handles place2_3.Click
        If step_ = 10 Then
            If witch_book Then
                MsgBox("There's nothing useful.")
            Else
                Form11.start(4, "Witch's book!",
                             "There's a witch's book on the counter! It looks strange! Do you want to take it?", "No.",
                             "Yes.")
            End If
        End If
    End Sub

    Private Sub place2_2_Click(sender As Object, e As EventArgs) Handles place2_2.Click
        If step_ = 10 Then
            If place2_2.Tag = 1 Then
                MsgBox("Nothing useful.")
            Else
                Form4.start("You may get detected if someone finds you. Do you still want to get inside?", "Risk it!", 9,
                            "Avoid.", - 1)
            End If
        End If
    End Sub

    Private Sub place2_4_Click(sender As Object, e As EventArgs) Handles place2_4.Click
        If step_ = 10 Then
            If place2_4.Tag = 0 Then
                place2_4.Tag = 1
                Form5.start(11, "Searching carefully in the library......", 11)
            Else
                Form6.start("There's nothing else. You should go to basketball hall and find the turkey now.", - 1)
            End If
        End If
    End Sub

    Private Sub place1_4_Click(sender As Object, e As EventArgs) Handles place1_4.Click
        If step_ = 10 Then
            disappear()
            picturebox1.Image =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene4.wm")
            place4_1.Visible = True
            place4_2.Visible = True
            If place4_3.Tag = 1 Then place4_3.Visible = True
        End If
    End Sub

    Private Sub place4_1_Click(sender As Object, e As EventArgs) Handles place4_1.Click
        If step_ = 10 Then
            If picturebox1.Tag = 6 Or picturebox1.Tag = 7 Then
                MsgBox("You've chosen that you wanted to run to GYM, so you cannot go this way.")
            Else
                If picturebox1.Tag = 9 And defeat_hen = False Then _
                    MsgBox("We'll catch up with the shadow.", 64, "Speed up!")
                disappear()
                picturebox1.Image =
                    Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene2.wm")
                place1_1.Visible = True
                place1_2.Visible = True
                If Not six_god Then place1_3.Visible = True
                If place1_4.Tag = 1 Then place1_4.Visible = True
                If picturebox1.Tag = 9 Then
                    If defeat_hen = False Then
                        MsgBox("Oh a small black hen!", 48, "A small black hen")
                        Form6.start(
                            "The hen is roaring to you! She wants to fight and report your matters to the teacher.", 6)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub place4_2_Click(sender As Object, e As EventArgs) Handles place4_2.Click
        If step_ = 10 Then
            disappear()
            picturebox1.Image =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene5.wm")
            place5_1.Visible = True
            place5_2.Visible = True
            If picturebox1.Tag = 0 Then
                picturebox1.Tag = 1
                MsgBox("The turkey isn't here, surely he is on floor three, go upstairs and catch it!", 48,
                       "Turkey is out there somewhere..")
            End If
        End If
    End Sub

    Private Sub place3_2_Click(sender As Object, e As EventArgs) Handles place3_2.Click
        If step_ = 10 Then
            If picturebox1.Tag = 8 Or picturebox1.Tag = 9 Then
                picturebox1.Tag = 10
                Form6.start("The teacher isn't in class.", 9)
            ElseIf picturebox1.Tag >= 10 Then
                disappear()
                If place8_1.Tag = 0 Then place8_1.Visible = True
                If place8_2.Tag = 0 Then place8_2.Visible = True
                If place8_3.Tag = 0 Then place8_3.Visible = True
                If place8_4.Tag = 0 Then place8_4.Visible = True
                If place8_5.Tag = 0 Then place8_5.Visible = True
                picturebox1.Image =
                    Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene8.wm")
            Else
                Form6.start("The teacher is in class, you'd better not to risk it.", - 1)
            End If
        End If
    End Sub

    Private Sub place5_2_Click(sender As Object, e As EventArgs) Handles place5_2.Click
        If step_ = 10 Then
            disappear()
            picturebox1.Image =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene4.wm")
            place4_1.Visible = True
            place4_2.Visible = True
            If place4_3.Tag = 1 Then place4_3.Visible = True
            If picturebox1.Tag = 4 Then
                picturebox1.Tag = 5
                MsgBox(
                    "Suddenly, a big shadow flapped and rushed near you, we don't know what's that thing, but it's very probable it's the turkey.")
                Form11.start(6, "Black shadow!", "It has run to teaching building! Do you want to catch up with it?",
                             "Still go to another exit.", "Of course: catch up!")
            End If
        End If
    End Sub

    Private Sub place5_1_Click(sender As Object, e As EventArgs) Handles place5_1.Click
        If step_ = 10 Then
            If picturebox1.Tag = 1 Then
                picturebox1.Tag = 2
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound11.wm")
                MsgBox("The class has ended!", 48, "Warning")
                MsgBox("So we'd rush up faster.", 0, "Speed warning")
            End If
            Form5.start(12, "(GYM) floor1→floor3", 7)
        End If
    End Sub

    Private Sub place6_1_Click(sender As Object, e As EventArgs) Handles place6_1.Click
        If step_ = 10 Then
            Form5.start(13, "(GYM) floor1←floor3", 5)
            If picturebox1.Tag = 3 Then
                picturebox1.Tag = 4
                MsgBox("We'll catch the turkey in another exit of the GYM.")
            End If
        End If
    End Sub

    Private Sub place4_3_Click(sender As Object, e As EventArgs) Handles place4_3.Click
        If step_ = 10 Then
            If picturebox1.Tag = 6 Then
                MsgBox("Rush!!")
            End If
            disappear()
            picturebox1.Image =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene7.wm")
            place7_1.Visible = True
            place7_2.Visible = True
            If picturebox1.Tag = 6 Then
                picturebox1.Tag = 7
                MsgBox("There's something on the ground.")
                magics.Items.Add("Water egg")
                Form11.start(7, "New magic!",
                             "You get a water egg which can water, it seems is which the small black hen lost on ground.",
                             "Get it!")
            End If
        End If
    End Sub

    Private Sub place7_2_Click(sender As Object, e As EventArgs) Handles place7_2.Click
        If step_ = 10 Then
            If picturebox1.Tag = 7 Then
                MsgBox("It's not the time for us to go back, we'd enter the GYM and find turkey first.")
                Exit Sub
            End If
            disappear()
            picturebox1.Image =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene4.wm")
            place4_1.Visible = True
            place4_2.Visible = True
            If place4_3.Tag = 1 Then place4_3.Visible = True
        End If
    End Sub

    Private Sub place7_1_Click(sender As Object, e As EventArgs) Handles place7_1.Click
        If step_ = 10 Then
            MsgBox("The door is locked.", 48, "Locked")
            If picturebox1.Tag = 7 Then
                picturebox1.Tag = 8
                Form6.start(
                    "There's no turkey, the shadow maybe is the turkey. Maybe he is in class now, go back the class.",
                    - 1)
            End If
        End If
    End Sub

    Private Sub topic_Click(sender As Object, e As EventArgs) Handles topic.Click
        DifTip.Visible = False
        topic.Visible = False
        RemoveTitle.Enabled = False
    End Sub

    Private Sub DifTip_Click(sender As Object, e As EventArgs) Handles DifTip.Click
        DifTip.Visible = False
        topic.Visible = False
        RemoveTitle.Enabled = False
    End Sub

    Private Sub place8_3_Click(sender As Object, e As EventArgs) Handles place8_3.Click
        If step_ = 10 Then
            MsgBox("There is nothing but nihility.", 16, "Nihility!!")
        End If
    End Sub

    Private Sub place8_4_Click(sender As Object, e As EventArgs) Handles place8_4.Click
        If step_ = 10 Then
            If _
                MsgBox("There're many things inside the desk, do you want to search things in it?", 32 + vbYesNo,
                       "Massive things") = vbYes Then
                Form5.start(14, "Searching things in it...", 8)
            End If
        End If
    End Sub

    Private Sub place8_1_Click(sender As Object, e As EventArgs) Handles place8_1.Click
        If step_ = 10 Then
            Form6.start("The turkey isn't on seat. Actually he'll not go back, he is escaping out.", - 1)
        End If
    End Sub

    Private Sub place8_5_Click(sender As Object, e As EventArgs) Handles place8_5.Click
        If step_ = 10 Then
            If picturebox1.Tag = 10 Or picturebox1.Tag = 11 Then
                MsgBox("There's a classtable on the platform.")
                If picturebox1.Tag = 10 Then
                    Form6.start("The next class is Mr.Duck's class!", 11)
                Else
                    Form6.start(
                        "The next class is Mr.Duck's class. Now the turkey is outside, rush out the door and catch it fast.",
                        - 1)
                End If
            Else
                MsgBox("You've already visited it.")
            End If
        End If
    End Sub

    Private Sub place8_2_Click(sender As Object, e As EventArgs) Handles place8_2.Click
        If picturebox1.Tag < 11 Then
            MsgBox("Have a search first.")
            Exit Sub
        End If
        If picturebox1.Tag = 11 Then
            MsgBox("The turkey is running outside, we must catch it at once. Get ready!", 0, "Rush!")
        End If
        disappear()
        picturebox1.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene1.wm")
        place3_1.Visible = True
        place3_2.Visible = True
        place3_3.Visible = True
        place3_4.Visible = True
        place3_5.Visible = True
        If picturebox1.Tag = 11 Then
            picturebox1.Tag = 12
            MsgBox("The turkey has run to playground, rush down the stairs and catch it!", 0, "On playground!")
        End If
    End Sub

    Private Sub place9_1_Click(sender As Object, e As EventArgs) Handles place9_1.Click
        Form5.start(15, "Chapter 2", 10)
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        If Width < TargetWidth Then
            Width += 1
        ElseIf Width > TargetWidth Then
            Width -= 1
        Else
            Timer3.Enabled = False
            AfterSetting(AfterSettingWidth_code)
        End If
        Left = (Screen.PrimaryScreen.Bounds.Width - Width)/2
        Top = (Screen.PrimaryScreen.Bounds.Height - Height)/2
    End Sub

    Private Sub Disappear1()
        place01_1.Visible = False
        place01_2.Visible = False
        place01_3.Visible = False
        place02_1.Visible = False
        place02_2.Visible = False
        place02_3.Visible = False
        place03_1.Visible = False
        place03_2.Visible = False
        place03_3.Visible = False
        place03_4.Visible = False
        place03_5.Visible = False
        place04_1.Visible = False
        place04_2.Visible = False
        place04_3.Visible = False
        place05_1.Visible = False
        place05_2.Visible = False
        place05_3.Visible = False
        place05_4.Visible = False
        place06_1.Visible = False
        place06_2.Visible = False
        place06_3.Visible = False
        place07_1.Visible = False
        place07_2.Visible = False
        place07_3.Visible = False
        place07_4.Visible = False
        place08_1.Visible = False
        place08_2.Visible = False
        place08_3.Visible = False
        place08_4.Visible = False
        place09_1.Visible = False
        place09_2.Visible = False
        place09_3.Visible = False
        place09_4.Visible = False
        place10_1.Visible = False
        place10_2.Visible = False
        place10_3.Visible = False
        place10_4.Visible = False
        place10_5.Visible = False
        place10_6.Visible = False
        place10_7.Visible = False
        lock10_1.Visible = False
        lock10_2.Visible = False
        lock10_3.Visible = False
        place11_1.Visible = False
        place12_1.Visible = False
        place12_2.Visible = False
        place12_3.Visible = False
        place12_4.Visible = False
        place12_5.Visible = False
        place12_6.Visible = False
        place12_7.Visible = False
        lock12_1.Visible = False
        lock12_2.Visible = False
        place13_1.Visible = False
        place13_2.Visible = False
        place13_3.Visible = False
        lock13_1.Visible = False
        place14_1.Visible = False
        place14_2.Visible = False
        place14_3.Visible = False
        place15_1.Visible = False
        place15_2.Visible = False
        place15_3.Visible = False
        place15_4.Visible = False
        lock15_1.Visible = False
        place16_1.Visible = False
        place16_2.Visible = False
        place16_3.Visible = False
        place17_1.Visible = False
        place17_2.Visible = False
        place17_3.Visible = False
        place18_1.Visible = False
        place18_2.Visible = False
        place19_1.Visible = False
        place19_2.Visible = False
        place19_3.Visible = False
        place20_1.Visible = False
        place24_1.Visible = False
        place24_2.Visible = False
        place24_3.Visible = False
        place21_1.Visible = False
        place21_2.Visible = False
        place21_3.Visible = False
        place21_4.Visible = False
        place22_1.Visible = False
        place22_2.Visible = False
        place22_3.Visible = False
        place22_4.Visible = False
        place23_1.Visible = False
        place23_2.Visible = False
        place23_3.Visible = False
        place23_4.Visible = False
        place24_1.Visible = False
        place24_2.Visible = False
        place24_3.Visible = False
        place25_1.Visible = False
    End Sub

    Friend Sub Scene1Appears()
        If OnFire And p16.BackColor = Color.FromArgb(0, 0, 0) Then
            MsgBox("This place has been destroyed.", 0, "Destroyed")
            Exit Sub
        End If
        Disappear1()
        picturebox2.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene10.wm")
        If place01_1.Tag > 0 Then place01_1.Visible = True
        If place01_2.Tag > 0 Then place01_2.Visible = True
        If place01_3.Tag > 0 Then place01_3.Visible = True
        If OnFire Then CurrentPlace = p16
    End Sub

    Private Sub Scene2Appears()
        If OnFire And p15.BackColor = Color.FromArgb(0, 0, 0) Then
            MsgBox("This place has been destroyed.", 0, "Destroyed")
            Exit Sub
        End If
        Disappear1()
        picturebox2.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene11.wm")
        If place02_1.Tag > 0 Then place02_1.Visible = True
        If place02_2.Tag > 0 Then place02_2.Visible = True
        If place02_3.Tag > 0 Then place02_3.Visible = True
        If OnFire Then CurrentPlace = p15
    End Sub

    Private Sub Scene3Appears()
        If OnFire And p12.BackColor = Color.FromArgb(0, 0, 0) Then
            MsgBox("This place has been destroyed.", 0, "Destroyed")
            Exit Sub
        End If
        Disappear1()
        picturebox2.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene12.wm")
        If place03_1.Tag > 0 Then place03_1.Visible = True
        If place03_2.Tag > 0 Then place03_2.Visible = True
        If place03_3.Tag > 0 Then place03_3.Visible = True
        If place03_4.Tag > 0 Then place03_4.Visible = True
        If place03_5.Tag > 0 Then place03_5.Visible = True
        If OnFire Then CurrentPlace = p12
    End Sub

    Private Sub Scene4Appears()
        If OnFire And p10.BackColor = Color.FromArgb(0, 0, 0) Then
            MsgBox("This place has been destroyed.", 0, "Destroyed")
            Exit Sub
        End If
        Disappear1()
        picturebox2.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene13.wm")
        If place04_1.Tag > 0 Then place04_1.Visible = True
        If place04_2.Tag > 0 Then place04_2.Visible = True
        If place04_3.Tag > 0 Then place04_3.Visible = True
        If OnFire Then CurrentPlace = p10
    End Sub

    Friend Sub Scene5Appears()
        If OnFire And p11.BackColor = Color.FromArgb(0, 0, 0) Then
            MsgBox("This place has been destroyed.", 0, "Destroyed")
            Exit Sub
        End If
        Disappear1()
        picturebox2.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene14.wm")
        If place05_1.Tag > 0 Then place05_1.Visible = True
        If place05_2.Tag > 0 Then place05_2.Visible = True
        If place05_3.Tag > 0 Then place05_3.Visible = True
        If place05_4.Tag > 0 Then place05_4.Visible = True
        If OnFire Then CurrentPlace = p11
    End Sub

    Private Sub Scene6Appears()
        If OnFire And p13.BackColor = Color.FromArgb(0, 0, 0) Then
            MsgBox("This place has been destroyed.", 0, "Destroyed")
            Exit Sub
        End If
        Disappear1()
        picturebox2.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene15.wm")
        If place06_1.Tag > 0 Then place06_1.Visible = True
        If place06_2.Tag > 0 Then place06_2.Visible = True
        If place06_3.Tag > 0 Then place06_3.Visible = True
        If OnFire Then CurrentPlace = p13
    End Sub

    Private Sub Scene7Appears()
        If OnFire And p19.BackColor = Color.FromArgb(0, 0, 0) Then
            MsgBox("This place has been destroyed.", 0, "Destroyed")
            Exit Sub
        End If
        Disappear1()
        picturebox2.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene16.wm")
        If place07_1.Tag > 0 Then place07_1.Visible = True
        If place07_2.Tag > 0 Then place07_2.Visible = True
        If place07_3.Tag > 0 Then place07_3.Visible = True
        If place07_4.Tag > 0 Then place07_4.Visible = True
        If OnFire Then CurrentPlace = p19
    End Sub

    Private Sub Scene8Appears()
        If OnFire And p18.BackColor = Color.FromArgb(0, 0, 0) Then
            MsgBox("This place has been destroyed.", 0, "Destroyed")
            Exit Sub
        End If
        Disappear1()
        picturebox2.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene17.wm")
        If place08_1.Tag > 0 Then place08_1.Visible = True
        If place08_2.Tag > 0 Then place08_2.Visible = True
        If place08_3.Tag > 0 Then place08_3.Visible = True
        If place08_4.Tag > 0 Then place08_4.Visible = True
        If OnFire Then CurrentPlace = p18
    End Sub

    Private Sub Scene9Appears()
        If OnFire And p17.BackColor = Color.FromArgb(0, 0, 0) Then
            MsgBox("This place has been destroyed.", 0, "Destroyed")
            Exit Sub
        End If
        Disappear1()
        picturebox2.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene18.wm")
        If place09_1.Tag > 0 Then place09_1.Visible = True
        If place09_2.Tag > 0 Then place09_2.Visible = True
        If place09_3.Tag > 0 Then place09_3.Visible = True
        If place09_4.Tag > 0 Then place09_4.Visible = True
        If OnFire Then CurrentPlace = p17
    End Sub

    Private Sub Scene10Appears()
        If OnFire And p20.BackColor = Color.FromArgb(0, 0, 0) Then
            MsgBox("This place has been destroyed.", 0, "Destroyed")
            Exit Sub
        End If
        Disappear1()
        picturebox2.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene19.wm")
        If place10_1.Tag > 0 Then place10_1.Visible = True
        If place10_2.Tag > 0 Then place10_2.Visible = True
        If place10_3.Tag > 0 Then place10_3.Visible = True
        If place10_4.Tag > 0 Then place10_4.Visible = True
        If place10_5.Tag > 0 Then place10_5.Visible = True
        If place10_6.Tag > 0 Then place10_6.Visible = True
        If place10_7.Tag > 0 Then place10_7.Visible = True
        If lock10_1.Tag > 0 Then lock10_1.Visible = True
        If lock10_2.Tag > 0 Then lock10_2.Visible = True
        If lock10_3.Tag > 0 Then lock10_3.Visible = True
        If OnFire Then CurrentPlace = p20
    End Sub

    Private Sub Scene11Appears()
        If OnFire And p21.BackColor = Color.FromArgb(0, 0, 0) Then
            MsgBox("This place has been destroyed.", 0, "Destroyed")
            Exit Sub
        End If
        Disappear1()
        picturebox2.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene20.wm")
        If place11_1.Tag > 0 Then place11_1.Visible = True
        If OnFire Then CurrentPlace = p21
    End Sub

    Private Sub Scene12Appears()
        If OnFire And p4.BackColor = Color.FromArgb(0, 0, 0) Then
            MsgBox("This place has been destroyed.", 0, "Destroyed")
            Exit Sub
        End If
        Disappear1()
        picturebox2.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene21.wm")
        If place12_1.Tag > 0 Then place12_1.Visible = True
        If place12_2.Tag > 0 Then place12_2.Visible = True
        If place12_3.Tag > 0 Then place12_3.Visible = True
        If place12_4.Tag > 0 Then place12_4.Visible = True
        If place12_5.Tag > 0 Then place12_5.Visible = True
        If place12_6.Tag > 0 Then place12_6.Visible = True
        If place12_7.Tag > 0 Then place12_7.Visible = True
        If lock12_1.Tag > 0 Then lock12_1.Visible = True
        If lock12_2.Tag > 0 Then lock12_2.Visible = True
        If OnFire Then CurrentPlace = p4
    End Sub

    Private Sub Scene13Appears()
        If OnFire And p5.BackColor = Color.FromArgb(0, 0, 0) Then
            MsgBox("This place has been destroyed.", 0, "Destroyed")
            Exit Sub
        End If
        Disappear1()
        picturebox2.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene22.wm")
        If place13_1.Tag > 0 Then place13_1.Visible = True
        If place13_2.Tag > 0 Then place13_2.Visible = True
        If place13_3.Tag > 0 Then place13_3.Visible = True
        If lock13_1.Tag > 0 Then lock13_1.Visible = True
        If OnFire Then CurrentPlace = p5
    End Sub

    Friend Sub Scene14Appears()
        If OnFire And p6.BackColor = Color.FromArgb(0, 0, 0) Then
            MsgBox("This place has been destroyed.", 0, "Destroyed")
            Exit Sub
        End If
        Disappear1()
        picturebox2.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene23.wm")
        If place14_1.Tag > 0 Then place14_1.Visible = True
        If place14_2.Tag > 0 Then place14_2.Visible = True
        If place14_3.Tag > 0 Then place14_3.Visible = True
        If OnFire Then CurrentPlace = p6
    End Sub

    Private Sub Scene15Appears()
        If OnFire And p8.BackColor = Color.FromArgb(0, 0, 0) Then
            MsgBox("This place has been destroyed.", 0, "Destroyed")
            Exit Sub
        End If
        Disappear1()
        picturebox2.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene24.wm")
        If place15_1.Tag > 0 Then place15_1.Visible = True
        If place15_2.Tag > 0 Then place15_2.Visible = True
        If place15_3.Tag > 0 Then place15_3.Visible = True
        If place15_4.Tag > 0 Then place15_4.Visible = True
        If lock15_1.Tag > 0 Then lock15_1.Visible = True
        If OnFire Then CurrentPlace = p8
    End Sub

    Private Sub Scene16Appears()
        If OnFire And p14.BackColor = Color.FromArgb(0, 0, 0) Then
            MsgBox("This place has been destroyed.", 0, "Destroyed")
            Exit Sub
        End If
        Disappear1()
        picturebox2.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene25.wm")
        If place16_1.Tag > 0 Then place16_1.Visible = True
        If place16_2.Tag > 0 Then place16_2.Visible = True
        If place16_3.Tag > 0 Then place16_3.Visible = True
        If OnFire Then CurrentPlace = p14
    End Sub

    Friend Sub Scene17Appears()
        If OnFire And p7.BackColor = Color.FromArgb(0, 0, 0) Then
            MsgBox("This place has been destroyed.", 0, "Destroyed")
            Exit Sub
        End If
        Disappear1()
        picturebox2.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene26.wm")
        If place17_1.Tag > 0 Then place17_1.Visible = True
        If place17_2.Tag > 0 Then place17_2.Visible = True
        If place17_3.Tag > 0 Then place17_3.Visible = True
        If OnFire Then CurrentPlace = p7
    End Sub

    Private Sub Scene18Appears()
        If OnFire And p9.BackColor = Color.FromArgb(0, 0, 0) Then
            MsgBox("This place has been destroyed.", 0, "Destroyed")
            Exit Sub
        End If
        Disappear1()
        picturebox2.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene27.wm")
        If place18_1.Tag > 0 Then place18_1.Visible = True
        If place18_2.Tag > 0 Then place18_2.Visible = True
        If OnFire Then CurrentPlace = p9
    End Sub

    Private Sub Scene19Appears()
        If OnFire And p22.BackColor = Color.FromArgb(0, 0, 0) Then
            MsgBox("This place has been destroyed.", 0, "Destroyed")
            Exit Sub
        End If
        Disappear1()
        picturebox2.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene28.wm")
        If place19_1.Tag > 0 Then place19_1.Visible = True
        If place19_2.Tag > 0 Then place19_2.Visible = True
        If place19_3.Tag > 0 Then place19_3.Visible = True
        If OnFire Then CurrentPlace = p22
    End Sub

    Private Sub Scene20Appears()
        If OnFire And p4.BackColor = Color.FromArgb(0, 0, 0) Then
            MsgBox("This place has been destroyed.", 0, "Destroyed")
            Exit Sub
        End If
        Disappear1()
        picturebox2.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene29.wm")
        If place12_1.Tag > 0 Then place12_1.Visible = True
        If place12_2.Tag > 0 Then place12_2.Visible = True
        If place12_3.Tag > 0 Then place12_3.Visible = True
        If place12_4.Tag > 0 Then place12_4.Visible = True
        If place12_5.Tag > 0 Then place12_5.Visible = True
        If place20_1.Tag > 0 Then place20_1.Visible = True
        If OnFire Then CurrentPlace = p4
    End Sub

    Private Sub Scene21Appears()
        If OnFire And p3.BackColor = Color.FromArgb(0, 0, 0) Then
            MsgBox("This place has been destroyed.", 0, "Destroyed")
            Exit Sub
        End If
        Disappear1()
        picturebox2.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene30.wm")
        If place21_1.Tag > 0 Then place21_1.Visible = True
        If place21_2.Tag > 0 Then place21_2.Visible = True
        If place21_3.Tag > 0 Then place21_3.Visible = True
        If place21_4.Tag > 0 Then place21_4.Visible = True
        If OnFire Then CurrentPlace = p3
    End Sub

    Private Sub Scene22Appears()
        If OnFire And p2.BackColor = Color.FromArgb(0, 0, 0) Then
            MsgBox("This place has been destroyed.", 0, "Destroyed")
            Exit Sub
        End If
        Disappear1()
        picturebox2.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene31.wm")
        If place22_1.Tag > 0 Then place22_1.Visible = True
        If place22_2.Tag > 0 Then place22_2.Visible = True
        If place22_3.Tag > 0 Then place22_3.Visible = True
        If place22_4.Tag > 0 Then place22_4.Visible = True
        If OnFire Then CurrentPlace = p2
    End Sub

    Private Sub Scene23Appears()
        If OnFire And p23.BackColor = Color.FromArgb(0, 0, 0) Then
            MsgBox("This place has been destroyed.", 0, "Destroyed")
            Exit Sub
        End If
        Disappear1()
        picturebox2.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene32.wm")
        If place23_1.Tag > 0 Then place23_1.Visible = True
        If place23_2.Tag > 0 Then place23_2.Visible = True
        If place23_3.Tag > 0 Then place23_3.Visible = True
        If place23_4.Tag > 0 Then place23_4.Visible = True
        If OnFire Then CurrentPlace = p23
    End Sub

    Private Sub Scene24Appears()
        If OnFire And p1.BackColor = Color.FromArgb(0, 0, 0) Then
            MsgBox("This place has been destroyed.", 0, "Destroyed")
            Exit Sub
        End If
        Disappear1()
        picturebox2.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene33.wm")
        If place24_1.Tag > 0 Then place24_1.Visible = True
        If place24_2.Tag > 0 Then place24_2.Visible = True
        If place24_3.Tag > 0 Then place24_3.Visible = True
        If OnFire Then CurrentPlace = p1
    End Sub

    Private Sub Scene25Appears()
        If OnFire And p21.BackColor = Color.FromArgb(0, 0, 0) Then
            MsgBox("This place has been destroyed.", 0, "Destroyed")
            Exit Sub
        End If
        Disappear1()
        picturebox2.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene34.wm")
        If place25_1.Tag > 0 Then place25_1.Visible = True
    End Sub

    Private Sub place01_2_Click(sender As Object, e As EventArgs) Handles place01_2.Click
        If picturebox2.Tag <= 1 Then
            MsgBox("It's unimportant to enter this lab, because the turkey isn't inside.")
        Else
            Scene8Appears()
        End If
    End Sub

    Private Sub place01_3_Click(sender As Object, e As EventArgs) Handles place01_3.Click
        If items.Items.Contains("Physics lab key") Then
            If CostPower(5) Then
                If picturebox2.Tag = 23 Then MsgBox("You opened the door.", 0, "Open the door")
                Scene9Appears()
                If picturebox2.Tag = 23 Then
                    picturebox2.Tag = 24
                    If mute.Checked = False Then _
                        My.Computer.Audio.Play(
                            My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound39.wm")
                    MsgBox("Suddenly, you saw the rooster speedly rushed over you! And jumped out the window.", 0,
                           "Oh my god.")
                    MsgBox(
                        "When he was jumping out, he was carrying a big plastic bag with full of worms and worm liquid..",
                        0, "Then")
                End If
            End If
        Else
            Form6.start("The door is locked.", - 1)
        End If
    End Sub

    Private Sub place01_1_Click(sender As Object, e As EventArgs) Handles place01_1.Click
        If CostPower(25) Then
            If picturebox2.Tag = 0 Then
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound5.wm")
                MsgBox("The turkey's sound comes out once again! It's spreading above! Rush up!")
            End If
            Scene2Appears()
            If picturebox2.Tag = 0 Then
                picturebox2.Tag = 1
                MsgBox("Not here. It's from the left side.", 64, "Left Side")
                MsgBox("Probably we should go left.")
                Form11.start(12, "Beware!",
                             "There'll be your physical power, every action costs power to do. The power'll be restored while time is passing.",
                             "I know.")
            End If
        End If
    End Sub

    Private Sub place02_1_Click(sender As Object, e As EventArgs) Handles place02_1.Click
        If CostPower(12) Then
            Scene1Appears()
        End If
    End Sub

    Private Sub place02_2_Click(sender As Object, e As EventArgs) Handles place02_2.Click
        If CostPower(6) Then
            If picturebox2.Tag = 1 Then
                heal += 1
                MsgBox("You find a curative potion on ground")
                MsgBox("Rush up! Turkey is near!")
            End If
            Scene3Appears()
            If picturebox2.Tag = 1 Then
                picturebox2.Tag = 2
                MsgBox("No, not here, it's out there somewhere.")
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound5.wm")
                MsgBox("It's on the upper floor! Speed up!", 48, "Caution!")
            End If
        End If
    End Sub

    Private Sub place03_1_Click(sender As Object, e As EventArgs) Handles place03_1.Click
        If CostPower(6) Then
            Scene2Appears()
        End If
    End Sub

    Private Sub place03_3_Click(sender As Object, e As EventArgs) Handles place03_3.Click
        If OnFire And place03_3.Tag = 1 Then
            If items.Items.Contains("cleaner") Then
                Form11.start(34, "Sodium cyanide",
                             "Large bottles of NaCN on the path. There is no doubt that the bottles were then put on a train for 411.",
                             "Keep away.", "Pick up and eat.", "Use cleaner to clear.")
            Else
                Form11.start(34, "Sodium cyanide",
                             "Large bottles of NaCN on the path. There is no doubt that the bottles were then put on a train for 411.",
                             "Keep away.", "Pick up and eat.")
            End If
        Else
            If picturebox2.Tag >= 37 Then
                If CostPower(12) Then
                    Scene16Appears()
                End If
            Else
                If CostPower(3) Then
                    If items.Items.Contains("Caesium") Then
                        Form4.start("The door of the building is blocked by huge stones.", "Throw Caesium.", 12,
                                    "Go back.", - 1)
                    Else
                        Form6.start("The door of the building is blocked by huge stones that you have no way to go out.",
                                    - 1)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub place03_2_Click(sender As Object, e As EventArgs) Handles place03_2.Click
        If OnFire Then
            MsgBox("The lecture hall is locked by a big iron worm.", 0, "Worm lock!")
            Exit Sub
        End If
        If CostPower(7) Then
            If picturebox2.Tag < 6 Then
                If potion_existed Then
                    potion_existed = False
                    heal += 1
                    Form11.start(11, "Curative potion", "You find a bottle of curative potion on the door.", "Next")
                    Exit Sub
                End If
                MsgBox("The sound comes from floor three, we have no time to explore here.")
            Else
                If picturebox2.Tag = 6 Then
                    MsgBox(
                        "Yes, it's here! This time the turkey cannot run anymore, because the back door is closed and locked.",
                        64, "Good Job.")
                End If
                Scene6Appears()
                If picturebox2.Tag = 6 Then
                    picturebox2.Tag = 7
                    MsgBox("It's so far that we can hardly see the rostrum, but the turkey might be on it.")
                End If
            End If
        End If
    End Sub

    Private Sub place03_5_Click(sender As Object, e As EventArgs) Handles place03_5.Click
        If CostPower(30) Then
            If picturebox2.Tag = 2 Then MsgBox("Rush up!!")
            Scene4Appears()
            If picturebox2.Tag = 2 Then
                picturebox2.Tag = 3
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound5.wm")
                MsgBox("The turkey sound seems came from biology lab!", 0, "Coincidence!")
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound26.wm")
                MsgBox("No... It's not the turkey's sound... It is murloc!", 0, "Coincidence!")
                Form11.start(13, "All of a sudden",
                             "Suddenly a murloc cried ""mlgr~mlgr~~mlgr~"" and rushes out from the biology lab! It seems very, very insane.",
                             "Fight!", "Avoid away.")
            End If
        End If
    End Sub

    Private Sub place04_3_Click(sender As Object, e As EventArgs) Handles place04_3.Click
        If OnFire And place04_3.Tag = 1 Then
            MsgBox("The path is blocked by a magic shield.", 0, "block")
            If items.Items.Contains("Magic dispeller") Then
                If MsgBox("You can use magic dispeller to dispel the magic shield", vbYesNo, "Magic dispeller") = vbYes _
                    Then
                    MsgBox("The magic shield is destroyed.", 0, "Magic shield")
                    place04_3.Tag = 2
                End If
            End If
            Exit Sub
        End If
        If CostPower(15) Then
            If picturebox2.Tag = 5 Then
                If Not mute.Checked Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound31.wm")
                MsgBox("The class starts, Mr.Duck goes back.", 64, "Class starts")
                magics.Items.Add("Duck function")
                MsgBox("You get Mr.Duck's function.", 0, "New magic")
                MsgBox("Yes it's here, rush down stairs!")
            End If
            Scene3Appears()
            If picturebox2.Tag = 5 Then
                picturebox2.Tag = 6
                MsgBox("He runs into the lecture hall! Follow him!")
            End If
        End If
    End Sub

    Private Sub place02_3_Click(sender As Object, e As EventArgs) Handles place02_3.Click
        If picturebox2.Tag >= 14 Then
            If CostPower(20) Then
                If picturebox2.Tag = 14 Then
                    MsgBox(
                        "Yes, it's here! The big smelly milk cow has given us the key so that we can unlock the door.",
                        0, "Unlock Door")
                End If
                Scene7Appears()
                If picturebox2.Tag = 14 Then
                    picturebox2.Tag = 15
                    MsgBox("It's too smelly inside. What a smelly milk giving place.", 0, "Smelly place")
                    MsgBox(
                        "The cow said there was witch and turkey's sound coming out. Let's go to floor 3 and find the fact.",
                        0, "Discover the Fact")
                End If
            End If
        Else
            Form6.start("This path is blocked by a locked door.", - 1)
        End If
    End Sub

    Private Function CostPower(cost As Integer)
        If physical_power.Visible Then
            If power.Tag >= cost Then
                power.Tag = power.Value - cost
                CostPowerTimer.Enabled = True
                Return True
            Else
                MsgBox("You do not have enough physical power (" & cost & ") to do the action.", 0, "Insufficient Power")
                Return False
            End If
        Else
            Return True
        End If
    End Function

    Private Sub CostPowerTimer_Tick(sender As Object, e As EventArgs) Handles CostPowerTimer.Tick
        If power.Value < power.Tag Then
            power.Value += 1
            refreshPowerText()
        ElseIf power.Value > power.Tag Then
            power.Value -= 1
            refreshPowerText()
        Else
            CostPowerTimer.Enabled = False
        End If
    End Sub

    Public Sub refreshPowerText()
        powerT.Text = power.Value
        If power.Value = 100 Then
            powerT.ForeColor = Color.DarkGreen
        ElseIf power.Value <= 10 Then
            powerT.ForeColor = Color.Blue
        Else
            powerT.ForeColor = Color.Black
        End If
    End Sub

    Private Sub Restore_Tick(sender As Object, e As EventArgs) Handles Restore.Tick
        Restore.Interval = 100
        If power.Value < 100 Then
            power.Value += 1
            power.Tag += 1
            refreshPowerText()
        End If
    End Sub

    Private Sub place04_1_Click(sender As Object, e As EventArgs) Handles place04_1.Click
        If picturebox2.Tag = 3 Then
            picturebox2.Tag = 4
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound26.wm")
            Form11.start(14, "Murlocs rush!",
                         "Massive mad murlocs rush out from inside and started attacking! What the hell of it!",
                         "Oh my god!")
        Else
            If CostPower(4) Then
                If picturebox2.Tag = 11 Then
                    MsgBox("Let's go inside and find the cow.", 0, "Big milk cow")
                End If
                Scene5Appears()
                If picturebox2.Tag = 11 Then
                    picturebox2.Tag = 12
                    MsgBox("We find the cow! He is sitting on ground!", 0, "Big milk cow")
                    Form11.start(22, "Big milk cow",
                                 "Our big milk cow is sitting on ground with few holes on its body! What happened?",
                                 "Next")
                ElseIf picturebox2.Tag = 19 Then
                    picturebox2.Tag = 20
                    MsgBox("There is no cow, you saw the rooster standing numbly with silence.")
                    Form4.start("What shall you do?", "Ask him.", 10, "Do nothing.", 11)
                ElseIf picturebox2.Tag = 28 Then
                    picturebox2.Tag = 29
                    MsgBox("The cow is inside.", 0, "Cow")
                    Form6.start("Big milk cow:" & vbCrLf & "I saw Avogadro turkey jumping down from floor4.", 29)
                End If
            End If
        End If
    End Sub

    Private Sub place05_1_Click(sender As Object, e As EventArgs) Handles place05_1.Click
        If picturebox2.Tag = 4 Then
            picturebox2.Tag = 5
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound27.wm")
            MsgBox("What the....", 0, "Strange sound")
            MsgBox("There's still turk&fish, but we cannot see anyone!", 0, "Strange sound")
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound25.wm")
            Form11.start(18, "Boss!!", "It's the lord of turkfish!!", "!!!")
        ElseIf picturebox2.Tag = 13 Then
            If MsgBox("Go out?", vbQuestion + vbYesNo, "Request") = vbYes Then
                picturebox2.Tag = 14
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound37.wm")
                MsgBox("The witch's sound! It's so terrifying!", 0, "The witch")
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound35.wm")
                MsgBox("Suddenly, our big smelly milk cow becomes mad and rushes over you!", 0, "Big smelly milk cow")
                MsgBox(
                    "What happened to our cow! It's the witch making ghost! But she just laughed and disappeared, we don't know what the magic she did cast on our cow.",
                    0, "Big smelly milk cow")
                MsgBox(
                    "Whatever the fact is... You must defeat the cow and calm it down. Or you'll be flattened by the cow.")
                Hide()
                Form7.Show()
                Form7.initialization(shield_level, weapon_level, 0, 300 + shield_level*150, 800, 10)
                music.settings.setMode("loop", True)
                music.settings.volume = 100
                music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music7.wm"
            End If
        Else
            If picturebox2.Tag = 20 Then
                MsgBox("Let's go out and search for the solar coin.")
            End If
            If CostPower(5) Then Scene4Appears()
            If picturebox2.Tag = 20 Then
                picturebox2.Tag = 21
                MsgBox("The coin may be in Chemistry lab. Go inside and have a search.")
            End If
        End If
    End Sub

    Private Sub place05_2_Click(sender As Object, e As EventArgs) Handles place05_2.Click
        If OnFire Then
            If place05_2.Tag = 1 Then
                MsgBox("There's a book on platform showing how to cook the rabbit.")
                MsgBox("There're tweezers on the book.")
                MsgBox("You get the tweezers on the book.")
                place05_2.Tag = 2
                items.Items.Add("tweezers")
            Else
                MsgBox("There's a book on platform showing how to cook the rabbit.")
            End If
        Else
            If picturebox2.Tag = 12 Then
                Form11.start(23, "Microscope", "Let's look the microscope.", "Avoid.", "Look.")
            Else
                Form6.start("There's a book on platform showing how to cook the rabbit.", - 1)
            End If
        End If
    End Sub

    Private Sub place05_3_Click(sender As Object, e As EventArgs) Handles place05_3.Click
        If place05_3.Tag = 1 Then
            If OnFire Then
                MsgBox("Many smelly medicines inside. The cabinet needs key to open.", 0, "Cabinet")
                If items.Items.Contains("cabinet key") Then
                    MsgBox("It has been unlocked by the cabinet key.", 0, "unlock")
                    place05_3.Tag = 2
                End If
            Else
                Form6.start("Many smelly medicines.", - 1)
            End If
        ElseIf place05_3.Tag = 2 Then
            place05_3.Tag = 3
            MsgBox("You get a bottle of magic dispeller from the cabinet.", 0, "Magic dispeller")
            items.Items.Add("Magic dispeller")
        Else
            MsgBox("Many smelly medicines.", 0, "Smelly")
        End If
    End Sub

    Private Sub place04_2_Click(sender As Object, e As EventArgs) Handles place04_2.Click
        If picturebox2.Tag < 31 Then
            MsgBox("It was dark over all that we can hardly go up.", 0, "Problem of Light")
        Else
            If CostPower(36) Then
                If Not OnFire Then Scene12Appears()
                If OnFire Then Scene20Appears()
                If picturebox2.Tag = 31 Then
                    picturebox2.Tag = 32
                    MsgBox("Yes, it is here. The teacher really has turned on the light.", 0, "Yes")
                End If
            End If
        End If
    End Sub

    Private Sub place06_1_Click(sender As Object, e As EventArgs) Handles place06_1.Click
        If picturebox2.Tag = 7 Then
            picturebox2.Tag = 8
            Form5.start(16, "Going to the rostrum...", 3.1)
        ElseIf picturebox2.Tag = 9 Then
            picturebox2.Tag = 10
            Form6.start("Chairman:" & vbCrLf & "Welcome you! Let's start!", 19)
        Else
            MsgBox("There is nothing to do.")
        End If
    End Sub

    Private Sub place06_3_Click(sender As Object, e As EventArgs) Handles place06_3.Click
        If picturebox2.Tag = 8 Then
            picturebox2.Tag = 9
            Form6.start("Because the quiz has begun, the door is locked.", 16)
        ElseIf picturebox2.Tag = 9 Then
            MsgBox("The door is locked.")
        Else
            If CostPower(6) Then
                If picturebox2.Tag = 10 Then
                    picturebox2.Tag = 11
                    MsgBox("Yes, we'll go to find the cow.", 0, "Yes!")
                End If
                Scene3Appears()
            End If
        End If
    End Sub

    Private Sub place06_2_Click(sender As Object, e As EventArgs) Handles place06_2.Click
        Form11.start(20, "Big Bomb!", "There's a big bomb on the seat!", "Keep away.", "Kick it.", "Hit it.")
    End Sub

    Private Sub place07_1_Click(sender As Object, e As EventArgs) Handles place07_1.Click
        If CostPower(13) Then
            Scene2Appears()
        End If
    End Sub

    Private Sub place07_2_Click(sender As Object, e As EventArgs) Handles place07_2.Click
        MsgBox("What a smelly place.", 0, "Smelly")
        If items.Items.Contains("Chemistry cabinet key") = False Then
            items.Items.Add("Chemistry cabinet key")
            Form6.start("You find a strange key on ground! It seems is the key to lab's cabinet.", - 1)
        End If
    End Sub

    Private Sub place07_3_Click(sender As Object, e As EventArgs) Handles place07_3.Click
        If picturebox2.Tag >= 24 Then
            MsgBox("There is nothing.", 0, "Nothing")
        ElseIf place07_3.Tag = 2 Then
            Form11.start(28, "Worm Water", "You cannot pass through the worm water..", "Oh yes..")
        ElseIf items.Items.Contains("Nitric acid") Then
            Form11.start(26, "Worms", "There're massive worms inside, we can hardly pass through.", "Oh yes.",
                         "Splash Nitric acid.")
        Else
            Form11.start(26, "Worms", "There're massive worms inside, we can hardly pass through.", "Oh yes.")
        End If
    End Sub

    Private Sub place07_4_Click(sender As Object, e As EventArgs) Handles place07_4.Click
        If picturebox2.Tag >= 24 Then
            If picturebox2.Tag = 24 Then
                MsgBox(
                    "Strangely, the worm water disappeared at all. Is it the rooster carried away the liquid? That's so strange!",
                    0, "Strange situation")
            End If
            If CostPower(17) Then
                Scene10Appears()
                If picturebox2.Tag = 24 Then
                    picturebox2.Tag = 25
                    MsgBox("This floor is a bit strange.", 0, "Floor3")
                End If
            End If
        ElseIf place07_3.Tag = 2 Then
            MsgBox("The worm liquid in worm egg production room won't allow you going up.", 0, "Worms")
        Else
            MsgBox("The worms in worm egg production room won't allow you going up.", 0, "Worms")
        End If
    End Sub

    Private Sub place08_2_Click(sender As Object, e As EventArgs) Handles place08_2.Click
        If picturebox2.Tag = 21 Then
            picturebox2.Tag = 22
            Form13.SetCoins(Form13.coins.Tag + 1)
            MsgBox("You get a big solar coin inside the trush bin soaking by NaCl, I, CCl4 solution.", 48, "New item")
            Form13.AddThing("Copper powder", 4, 1001)
            Form13.AddThing("Caesium", 5, 1000000)
            Form13.AddThing("Sodium", 6, 2333)
        Else
            Form11.start(27, "Waste liquid cylinder",
                         "There's NaCl, I, CCl4 solution in it, looked colorful, but we cannot drink it.", "Yes.")
        End If
    End Sub

    Private Sub place08_3_Click(sender As Object, e As EventArgs) Handles place08_3.Click
        Form6.start("The paper on platform shows who'd stand at the door while others're doing experiment.", - 1)
    End Sub

    Private Sub place08_4_Click(sender As Object, e As EventArgs) Handles place08_4.Click
        If CostPower(6) Then
            If items.Items.Contains("Chemistry cabinet key") Then
                If picturebox2.Tag = 15 Then
                    MsgBox("Now we can unlock it by the key.")
                    If mute.Checked = False Then _
                        My.Computer.Audio.Play(
                            My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound48.wm")
                    MsgBox("It's an automatic vendor! You can buy things by using solar corona coins.")
                    Form13.Show()
                    Form13.AddThing("Sulphuric acid (0%)", 3, 0)
                    Form13.AddThing("Nitric acid", 2, 1000)
                End If
                Hide()
                Form13.Show()
                Form13.RefreshAll()
                If picturebox2.Tag = 15 Then
                    picturebox2.Tag = 16
                    MsgBox(
                        "Let's buy something inside... Though we have no money, but it seems something's price is zero.")
                End If
            Else
                MsgBox("It has been locked by an iron lock.")
            End If
        End If
    End Sub

    Private Sub place08_1_Click(sender As Object, e As EventArgs) Handles place08_1.Click
        If CostPower(5) Then
            Scene1Appears()
        End If
    End Sub

    Private Sub place03_4_Click(sender As Object, e As EventArgs) Handles place03_4.Click
        If picturebox2.Tag < 18 Then
            MsgBox("There's nothing useful.")
        ElseIf picturebox2.Tag = 18 Then
            MsgBox("There is no corona coin near the safe, but it may be many coins inside.")
            If MsgBox("Do you want to open the safe?", vbYesNo + vbQuestion, "Open the Safe") = vbYes Then
                Hide()
                Form14.Show()
            End If
        Else
            MsgBox("There's nothing but smelly gas.")
        End If
    End Sub

    Private Sub place09_4_Click(sender As Object, e As EventArgs) Handles place09_4.Click
        If CostPower(4) Then
            Scene1Appears()
        End If
    End Sub

    Private Sub place09_1_Click(sender As Object, e As EventArgs) Handles place09_1.Click
        MsgBox("The platform is empty.")
    End Sub

    Private Sub place09_2_Click(sender As Object, e As EventArgs) Handles place09_2.Click
        If items.Items.Contains("trush key") Then
            items.Items.Remove("trush key")
            MsgBox("You opened the box and get a hammer", 0, "New item")
            items.Items.Add("hammer")
            place09_2.Tag = 2
        ElseIf place09_2.Tag = 2 Then
            MsgBox("There is nothing")
        Else
            MsgBox("There is a wooden box in the trush bin, but it requires key to open.")
        End If
    End Sub

    Private Sub place09_3_Click(sender As Object, e As EventArgs) Handles place09_3.Click
        MsgBox("The medical cabinet is empty.")
    End Sub

    Private Sub place10_5_Click(sender As Object, e As EventArgs) Handles place10_5.Click
        If OnFire And place25_1.Tag = 2 Then
            Scene25Appears()
            Exit Sub
        End If
        If lock10_2.Tag = 1 Then
            MsgBox("This path is locked.", 0, "Lock")
        Else
            If OnFire Then place25_1.Tag += 1
            If CostPower(2) Then
                Scene11Appears()
                If picturebox2.Tag = 26 Then
                    picturebox2.Tag = 27
                    MsgBox("Empty Room!", 0, "-")
                    MsgBox("We should go back.", 0, "--")
                End If
            End If
        End If
    End Sub

    Private Sub place10_4_Click(sender As Object, e As EventArgs) Handles place10_4.Click
        If lock10_3.Tag = 1 Then
            MsgBox("The Amber hole is locked.", 0, "Amber hole")
        Else

        End If
    End Sub

    Private Sub place10_6_Click(sender As Object, e As EventArgs) Handles place10_6.Click
        If OnFire Then
            MsgBox(
                "The ground shows that you should go to the top floor with a plastic hammer, then go out, then go inside again, then go out again. After doing all of these, enter ""I want a hard hammer"".")
        Else
            If lock10_1.Tag = 1 Then
                MsgBox("The door of the Amber nest is locked.", 0, "Lock")
            Else
                MsgBox("You cannot find anything in the nest.", 0, "Nothing")
            End If
            If items.Items.Contains("Amber key") Then
                If MsgBox("Do you want to open the door of Amber Nest by using the key?", vbYesNo, "Amber Nest") = vbYes _
                    Then
                    items.Items.Remove("Amber key")
                    If mute.Checked = False Then _
                        My.Computer.Audio.Play(
                            My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound48.wm")
                    MsgBox("You opened the door.")
                    lock10_1.Visible = False
                    lock10_1.Tag = 0
                    Form6.start("Mission 1 completed:" & vbCrLf & "The door of Amber Nest is opened.", - 1)
                End If
            End If
        End If
    End Sub

    Private Sub place10_7_Click(sender As Object, e As EventArgs) Handles place10_7.Click
        If OnFire Then
            If place10_7.Tag = 3 Then
                Scene19Appears()
                Exit Sub
            End If
            MsgBox("There is a big huge monster statue blocked the way. It's the witch, once again. Of course.", 0,
                   "Trick!")
            If place10_7.Tag = 1 Then
                place10_7.Tag = 2
                MsgBox("You get a key to a wooden box.", 0, "Box key")
                items.Items.Add("trush key")
            End If
            If items.Items.Contains("hammer") Then
                If MsgBox("You can use hammer to break the statue.", vbYesNo, "Break") = vbYes Then
                    If mute.Checked = False Then _
                        My.Computer.Audio.Play(
                            My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound12.wm")
                    MsgBox(
                        "The hammer is too small, the statue is too big. The hammer is too small, the statue is too big." &
                        vbCrLf & "So that" & vbCrLf & "It's improbable to break.", 0, "No use")
                End If
            ElseIf items.Items.Contains("hard hammer") Then
                If MsgBox("You can use hard hammer to break the statue.", vbYesNo, "Break") = vbYes Then
                    If mute.Checked = False Then _
                        My.Computer.Audio.Play(
                            My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound12.wm")
                    MsgBox("The statue is broken", 0, "Break")
                    place10_7.Tag = 3
                End If
            End If
            Exit Sub
        End If
        If lock10_1.Tag = 1 Then
            MsgBox("The door of the Amber nest is locked.", 0, "Lock")
        Else
            If CostPower(2) Then
                Scene19Appears()
            End If
        End If
    End Sub

    Private Sub place10_1_Click(sender As Object, e As EventArgs) Handles place10_1.Click
        If CostPower(9) Then
            Scene7Appears()
        End If
        If OnFire Then place25_1.Tag = 1
    End Sub

    Private Sub place10_2_Click(sender As Object, e As EventArgs) Handles place10_2.Click
        If OnFire And place10_2.Tag = 1 Then
            MsgBox("A loose stone box.", 0, "Wooden box")
            If items.Items.Contains("hammer") Then
                If MsgBox("Probably you can use hammer to break.", vbYesNo, "Break") = vbYes Then
                    If mute.Checked = False Then _
                        My.Computer.Audio.Play(
                            My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound12.wm")
                    MsgBox("There is no use." & vbCrLf & "Because your hammer is plastic.", 0, "No use")
                    If MsgBox("It's better to use hand to break.", vbYesNo, "Break") = vbYes Then
                        If mute.Checked = False Then _
                            My.Computer.Audio.Play(
                                My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound3.wm")
                        MsgBox("There is no use." & vbCrLf & "Because your hand isn't iron.", 0, "No use")
                    End If
                End If
            ElseIf items.Items.Contains("hard hammer") Then
                If MsgBox("Probably you can use hard hammer to break.", vbYesNo, "Break") = vbYes Then
                    If mute.Checked = False Then _
                        My.Computer.Audio.Play(
                            My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound12.wm")
                    place10_2.Tag = 2
                    MsgBox("You break the box, but the box is empty.", 0, "Empty")
                End If
            End If
        ElseIf OnFire And place10_2.Tag = 2 Then
            MsgBox("there is nothing")
        Else
            MsgBox("Some profound books and a loose stone box", 0, "Book")
        End If
    End Sub

    Private Sub place10_3_Click(sender As Object, e As EventArgs) Handles place10_3.Click
        If picturebox2.Tag = 25 Then
            MsgBox("A book about the rooster.", 0, "Book")
            music.Ctlcontrols.stop()
        End If
        Hide()
        Form15.Show()
        Form15.ChangeImage(1)
    End Sub

    Private Sub ChangeMusic_Tick(sender As Object, e As EventArgs) Handles ChangeMusic.Tick
        ChangeMusic.Enabled = False
        music.settings.volume = BackgroundVolume
        music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music12.wm"
    End Sub

    Private Sub place11_1_Click(sender As Object, e As EventArgs) Handles place11_1.Click
        If CostPower(1) Then
            If picturebox2.Tag = 27 Then
                heal += 1
                MsgBox("You get 1 curative potion.", 0, "Curative potion")
            End If
            Scene10Appears()
            If picturebox2.Tag = 27 Then
                picturebox2.Tag = 28
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound5.wm")
                MsgBox("The turkey's sound comes from Amber Nest. But we cannot entry: It is locked.", 0, "Lock")
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound36.wm")
                MsgBox("Suddenly, the witch's sound spreads out from Amber Nest!", 0, "Witch!")
                MsgBox(
                    "The turkey has run away from that room to the right side. We must open that door and find the fact.",
                    0, "Mystery")
                Form6.start("Mission 1:" & vbCrLf & "Open the door of Amber Nest.", 28)
            End If
        End If
    End Sub

    Private Sub place05_4_Click(sender As Object, e As EventArgs) Handles place05_4.Click
        If picturebox2.Tag = 29 Then
            picturebox2.Tag = 30
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound41.wm")
            MsgBox("Suddenly, the Avogadro turkey rushed out from the book!")
            Hide()
            Form7.Show()
            ChangeMusic.Enabled = False
            Form7.initialization(weapon_level, shield_level, 0, 300 + shield_level*150, 666, 11)
            music.settings.setMode("loop", True)
            music.settings.volume = 100
            music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music7.wm"
        Else
            If picturebox2.Tag = 30 Then
                MsgBox("The book shows the history of the witch.", 0, "Book")
                music.Ctlcontrols.stop()
            End If
            Hide()
            Form15.Show()
            Form15.ChangeImage(6)
        End If
    End Sub

    Private Sub place12_4_Click(sender As Object, e As EventArgs) Handles place12_4.Click
        If CostPower(4) Then
            Scene13Appears()
        End If
    End Sub

    Private Sub place13_1_Click(sender As Object, e As EventArgs) Handles place13_1.Click
        If CostPower(3) Then
            If Not OnFire Then Scene12Appears()
            If OnFire Then Scene20Appears()
        End If
    End Sub

    Private Sub place12_1_Click(sender As Object, e As EventArgs) Handles place12_1.Click
        If OnFire And place12_1.Tag = 1 Then
            MsgBox("Massive rocks blocked the path. Surely it is the witch made the ghost!", 0, "Block")
            If items.Items.Contains("corona rock") Then
                MsgBox("The corona rock removed these rocks.", 0, "Corona rock")
                place12_1.Tag = 2
            End If
        Else
            If CostPower(17) Then
                Scene4Appears()
            End If
        End If
    End Sub

    Public Sub ExitProgram()
        If MsgBox("Do you want to exit the program?", vbYesNo, "Exit program") = vbYes Then End
    End Sub

    Private Sub RemoveTitle_Tick(sender As Object, e As EventArgs) Handles RemoveTitle.Tick
        RemoveTitle.Enabled = False
        topic.Visible = False
        DifTip.Visible = False
    End Sub

    Private Sub RemoveSaveTip_Tick(sender As Object, e As EventArgs) Handles RemoveSaveTip.Tick
        RemoveSaveTip.Enabled = False
        savetip.Visible = False
    End Sub

    Private Sub savetip_Click(sender As Object, e As EventArgs) Handles savetip.Click
        savetip.Visible = False
        RemoveSaveTip.Enabled = False
    End Sub

    Private Sub place12_6_Click(sender As Object, e As EventArgs) Handles place12_6.Click
        MsgBox("Oh my god! This path is blocked by a huge homework mountain! Horrible!", 0, "Massive Homeworks!")
    End Sub

    Private Sub place12_7_Click(sender As Object, e As EventArgs) Handles place12_7.Click
        MsgBox("The left side is too dark that we'll be disabled to see anything there.", 0, "Darkness")
    End Sub

    Private Sub place12_5_Click(sender As Object, e As EventArgs) Handles place12_5.Click
        If picturebox2.Tag = 38 Then
            picturebox2.Tag = 39
            lock12_1.Visible = False
            lock12_1.Tag = 0
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound48.wm")
            MsgBox("The door is unlocked.", 0, "Unlock")
            Exit Sub
        End If
        If lock12_1.Visible Then
            MsgBox("The psychology classroom door is locked.", 0, "Lock")
        Else
            If CostPower(1) Then
                Scene17Appears()
            End If
        End If
    End Sub

    Private Sub place12_3_Click(sender As Object, e As EventArgs) Handles place12_3.Click
        If lock12_2.Visible Then
            MsgBox("There's big lock on the door with a hole. It requires a key to be unlocked.", 0, "Lock")
            If items.Items.Contains("Turkey key") Then
                lock12_2.Visible = False
                lock12_2.Tag = 0
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound48.wm")
                MsgBox("The door is unlocked.", 0, "Unlock")
            End If
        Else
            If picturebox2.Tag = 35 Then
                picturebox2.Tag = 36
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound45.wm")
                MsgBox("A small sound comes out, it is like a big machine.", 0, "Sound")
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound45.wm")
                MsgBox("But what is it?", 0, "Sound")
                Form11.start(31, "Robot!", "The lunch contending robot in madness! It's the time for lunch!", "Next")
            Else
                If CostPower(3) Then
                    Scene15Appears()
                End If
            End If
        End If
    End Sub

    Public Sub SaveGame(chapter As String, place As String, appendix As Integer, potionshop As Boolean)
        My.Settings.savetime = Now
        My.Settings.chapter = chapter
        My.Settings.place = place
        My.Settings.weapon = weapon_level
        My.Settings.shield = shield_level
        My.Settings.magics = ""
        For i = 0 To magics.Items.Count - 1
            My.Settings.magics = My.Settings.magics & magics.Items(i) & "/"
        Next
        My.Settings.revival = revive
        My.Settings.curative = heal
        My.Settings.appendix = appendix
        My.Settings.potionshop = ""
        If potionshop Then
            For i = 0 To Form13.ItemsList.Items.Count - 1
                My.Settings.potionshop = My.Settings.potionshop & Form13.ItemsList.Items(i).SubItems(0).Text & "/"
                My.Settings.potionshop = My.Settings.potionshop & Form13.ItemsList.Items(i).SubItems(1).Text & "/"
                My.Settings.potionshop = My.Settings.potionshop & Form13.ItemsList.Items(i).SubItems(2).Text & "/"
            Next
        End If
        My.Settings.items = ""
        For i = 0 To items.Items.Count - 1
            My.Settings.items = My.Settings.items & items.Items(i) & "/"
        Next
        My.Settings.nest_destroyed = destroy_nest
        My.Settings.witch_book = witch_book
        My.Settings.unlocked = ""
        For i = 0 To Unlocked.Items.Count - 1
            My.Settings.unlocked = My.Settings.unlocked & Unlocked.Items(i) & "/"
        Next
        My.Settings.Save()
        MsgBox("Your game is saved.", 0, "Save game")
    End Sub

    Private Sub savetip_VisibleChanged(sender As Object, e As EventArgs) Handles savetip.VisibleChanged
        savetip.Left = Width - savetip.Width
        savetip.Top = Height - savetip.Height
    End Sub

    Private Sub place13_2_Click(sender As Object, e As EventArgs) Handles place13_2.Click
        MsgBox("The door is locked by a big worm lock.", 0, "Lock")
    End Sub

    Private Sub place13_3_Click(sender As Object, e As EventArgs) Handles place13_3.Click
        If OnFire Then
            If place13_3.Tag = 1 Then
                MsgBox(
                    "There is a key to biology lab cabinet inside the machine, but it is stucked in a crack, the crack is too small that you cannot take it out.",
                    0, "Key")
                If items.Items.Contains("tweezers") Then
                    If MsgBox("You can take it out with the tweezers.", vbYesNo) = vbYes Then
                        MsgBox("You get the biology lab cabinet key.", 0, "key")
                        items.Items.Add("cabinet key")
                        place13_3.Tag = 2
                    End If
                End If
            Else
                Form11.start(32, "Function upgrader",
                             "You can still upgrade the Duck function. But under the fire, you need not at present.",
                             "Back and escape.")
            End If
        Else
            If magics.Items.Contains("Duck function+") Then
                Form11.start(32, "Function upgrader", "You can still upgrade the Duck function! By using this machine.",
                             "Back.", "Full Upgrade")
            Else
                Form11.start(29, "Function upgrader",
                             "There is a function upgrader machine in toilet, you can put duck function inside and upgrade it.",
                             "Back.", "Upgrade")
            End If
        End If
    End Sub

    Private Sub place14_2_Click(sender As Object, e As EventArgs) Handles place14_2.Click
        If CostPower(2) Then
            If Not OnFire Then Scene12Appears()
            If OnFire Then Scene20Appears()
        End If
    End Sub

    Private Sub place12_2_Click(sender As Object, e As EventArgs) Handles place12_2.Click
        If CostPower(3) Then
            Scene14Appears()
            If picturebox2.Tag = 32 Then
                picturebox2.Tag = 33
                SaveGame("Chapter2", "General tech room", 3, True)
                savetip.Visible = True
                RemoveSaveTip.Enabled = True
            End If
        End If
    End Sub

    Private Sub place14_3_Click(sender As Object, e As EventArgs) Handles place14_3.Click
        If picturebox2.Tag = 33 Then
            picturebox2.Tag = 34
            MsgBox(
                "It is a questioning machine! You must correctly answer a easy question then you can get things inside.",
                0, "Questioning machine.")
            Hide()
            Form14.Show()
            Form14.ClearAll()
            Form14.GroupBox1.Visible = True
        ElseIf picturebox2.Tag = 34 Then
            Hide()
            Form14.Show()
            Form14.ClearAll()
        Else
            MsgBox("The machine is empty. There is nothing.", 0, "Nothing")
        End If
    End Sub

    Private Sub place14_1_Click(sender As Object, e As EventArgs) Handles place14_1.Click
        MsgBox("Some disordered turkey-shaped cardboards.", 0, "Cardboard")
    End Sub

    Private Sub place15_1_Click(sender As Object, e As EventArgs) Handles place15_1.Click
        If CostPower(2) Then
            If Not OnFire Then Scene12Appears()
            If OnFire Then Scene20Appears()
        End If
    End Sub

    Private Sub place15_2_Click(sender As Object, e As EventArgs) Handles place15_2.Click
        MsgBox("There is nothing.", 0, "Nothing")
    End Sub

    Private Sub place15_3_Click(sender As Object, e As EventArgs) Handles place15_3.Click
        place15_3.Tag = 0
        Form13.SetCoins(Form13.coins.Tag + 2000)
        MsgBox("You get 2,000 solar coins from one of the computers.", 64, "Solar coin")
        place15_3.Visible = False
    End Sub

    Private Sub place16_1_Click(sender As Object, e As EventArgs) Handles place16_1.Click
        If CostPower(24) Then
            Scene3Appears()
        End If
    End Sub

    Private Sub place16_2_Click(sender As Object, e As EventArgs) Handles place16_2.Click
        Hide()
        Form14.Show()
        Form14.GroupBox1.Visible = False
        Form14.GroupBox2.Visible = True
        If items.Items.Contains("Time machine key") Then Form14.TextBox2.ForeColor = Color.Green
        If items.Items.Contains("Sodium") Then Form14.TextBox3.ForeColor = Color.Green
        If items.Items.Contains("Witch clothes") Then Form14.TextBox4.ForeColor = Color.Green
        If _
            Form14.TextBox2.ForeColor = Color.Green And Form14.TextBox3.ForeColor = Color.Green And
            Form14.TextBox4.ForeColor = Color.Green Then
            Form14.Button5.Text = "Rush!"
            Form14.Label10.Text = "The time travel is being prepared."
        End If
    End Sub

    Private Sub place16_3_Click(sender As Object, e As EventArgs) Handles place16_3.Click
        If picturebox2.Tag = 37 Then
            MsgBox("The book shows their destinies.", 0, "Book")
            music.Ctlcontrols.stop()
        End If
        Hide()
        Form15.Show()
        Form15.ChangeImage(13)
    End Sub

    Private Sub place17_1_Click(sender As Object, e As EventArgs) Handles place17_1.Click
        If picturebox2.Tag = 40 Then
            MsgBox("The door is locked, the lock is new. Of course it is the witch burned the room and locked the door.",
                   0, "Lock")
        ElseIf picturebox2.Tag = 41 Then
            picturebox2.Tag = 42
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound48.wm")
            MsgBox("The door is unlocked.", 0, "Unlock")
        Else
            If CostPower(5) Then
                If Not OnFire Then Scene12Appears()
                If OnFire Then Scene20Appears()
            End If
        End If
    End Sub

    Private Sub place17_3_Click(sender As Object, e As EventArgs) Handles place17_3.Click
        If picturebox2.Tag = 40 Then
            If MsgBox("Do you think there is anything useful?", vbYesNo, "Question") = vbYes Then
                picturebox2.Tag = 41
                MsgBox("You find the new key to psychology lab!", 0, "Key")
            Else
                MsgBox("Nothing useful.", 0, "Answer")
            End If
        Else
            MsgBox("Do you think there is anything useful?", vbYesNo, "Question")
            MsgBox("Nothing useful.", 0, "Answer")
        End If
    End Sub

    Private Sub place17_2_Click(sender As Object, e As EventArgs) Handles place17_2.Click
        If OnFire Then
            MsgBox("There is nothing")
            Exit Sub
        End If
        If items.Items.Contains("Mr.Duck's plank") Then
            place17_2.Tag += 1
            If place17_2.Tag = 3 Then
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound17.wm")
                MsgBox("Suddenly, a small key dropped out from the desk.", 0, "Small key")
                items.Items.Add("Small side key")
                MsgBox("You get the unknown key.", 0, "Unknown key")
            Else
                MsgBox("This time you cannot find other thing.", 0, "No other thing")
            End If
        Else
            items.Items.Add("Mr.Duck's plank")
            MsgBox("You get Mr.Duck's plank.", 0, "New item")
        End If
    End Sub

    Private Sub lock15_1_Click(sender As Object, e As EventArgs) Handles lock15_1.Click
        If OnFire Then Exit Sub
        If items.Items.Contains("Small side key") Then
            lock15_1.Visible = False
            lock15_1.Tag = 0
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound48.wm")
            MsgBox("The lock is removed by the mysterious unknown key.", 0, "Unlock")
            place15_4.Visible = True
            place15_4.Tag = 1
        End If
    End Sub

    Private Sub place18_1_Click(sender As Object, e As EventArgs) Handles place18_1.Click
        If CostPower(1) Then
            Scene15Appears()
        End If
    End Sub

    Private Sub place15_4_Click(sender As Object, e As EventArgs) Handles place15_4.Click
        If lock15_1.Tag = 1 Then
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound48.wm")
            MsgBox("The door is unlocked.", 0, "Unlock")
            lock15_1.Tag = 0
            lock15_1.Visible = False
            Exit Sub
        End If
        If CostPower(2) Then
            Scene18Appears()
        End If
    End Sub

    Private Sub place18_2_Click(sender As Object, e As EventArgs) Handles place18_2.Click
        If items.Items.Contains("Witch clothes") Then
            MsgBox("There is nothing", 0, "Nothing")
        Else
            If MsgBox("Oh there is full of witch's clothes, do you want to get one?", vbYesNo, "Witch clothes") = vbYes _
                Then
                items.Items.Add("Witch clothes")
                MsgBox("You get the witch's clothes.", 0, "New item")
            End If
        End If
    End Sub

    Private Sub place19_2_Click(sender As Object, e As EventArgs) Handles place19_2.Click
        If CostPower(1) Then
            Scene10Appears()
        End If
    End Sub

    Private Sub place19_1_Click(sender As Object, e As EventArgs) Handles place19_1.Click
        If place19_1.Tag = 1 Then
            place19_1.Tag = 2
            Form13.SetCoins(Form13.coins.Tag + 3000)
            MsgBox("You get 3,000 solar coins in the corner!", 0, "Solar coin")
        Else
            MsgBox("There is nothing.", 0, "Nothing")
        End If
    End Sub

    Private Sub place19_3_Click(sender As Object, e As EventArgs) Handles place19_3.Click
        If picturebox2.Tag = 39 Then
            picturebox2.Tag = 40
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound34.wm")
            Hide()
            music.Ctlcontrols.stop()
            ChangeMusic.Enabled = False
            MsgBox("!!!!!!!!!!!!!!!", 0, "!!")
            Form11.start(33, "Stunned!", "Suddenly, you don't know the source.. but you.. have been stunned!",
                         "Wake up!")
        Else
            If CostPower(4) Then
                Scene23Appears()
            End If
        End If
    End Sub

    Private Sub fire_Tick(sender As Object, e As EventArgs) Handles fire.Tick
        fire.Tag = 0
        SpreadFire(p1, {p1, p2, p3, p4})
        SpreadFire(p2, {p2, p1})
        SpreadFire(p3, {p3, p1})
        SpreadFire(p4, {p4, p1, p5, p6, p7, p8, p10})
        SpreadFire(p5, {p5, p4})
        SpreadFire(p6, {p6, p4, p9})
        SpreadFire(p7, {p7, p4})
        SpreadFire(p8, {p8, p4})
        SpreadFire(p9, {p9, p6})
        SpreadFire(p10, {p10, p4, p11})
        SpreadFire(p11, {p11, p10})
        SpreadFire(p12, {p12, p10, p13, p14})
        SpreadFire(p13, {p13, p12})
        SpreadFire(p14, {p14, p12})
        SpreadFire(p15, {p15, p12, p16, p19})
        SpreadFire(p16, {p16, p17, p18})
        SpreadFire(p17, {p17, p16})
        SpreadFire(p18, {p18, p16})
        SpreadFire(p19, {p19, p15, p20})
        SpreadFire(p20, {p20, p19, p21, p22})
        SpreadFire(p21, {p21, p20})
        SpreadFire(p22, {p22, p20, p23})
        SpreadFire(p23, {p23, p22})
        If p1.BackColor = Color.FromArgb(0, 0, 0) And (place22_2.Tag < 3 Or place21_2.Tag = 1) Then _
            GameOver("One of the rooms has gotten collapsed and blocked your way.")
        If p2.BackColor = Color.FromArgb(0, 0, 0) And place22_2.Tag < 3 Then _
            GameOver("One of the rooms has gotten collapsed and blocked your way.")
        If p3.BackColor = Color.FromArgb(0, 0, 0) And place21_2.Tag = 1 Then _
            GameOver("One of the rooms has gotten collapsed and blocked your way.")
        If _
            (p8.BackColor = Color.FromArgb(0, 0, 0) Or p9.BackColor = Color.FromArgb(0, 0, 0)) And
            items.Items.Contains("Witch clothes") = False Then _
            GameOver("One of the rooms has gotten collapsed and blocked your way.")
        If CurrentPlace.Text = "mysterious" And p8.BackColor = Color.FromArgb(0, 0, 0) Then _
            GameOver("One of the rooms has gotten collapsed and blocked your way.")
        If p5.BackColor = Color.FromArgb(0, 0, 0) And place13_3.Tag < 2 Then _
            GameOver("One of the rooms has gotten collapsed and blocked your way.")
        If _
            p4.BackColor = Color.FromArgb(0, 0, 0) And
            (CurrentPlace.Text = "mysterious" Or items.Items.Contains("Witch clothes") = False Or place13_3.Tag < 2) _
            Then GameOver("One of the rooms has gotten collapsed and blocked your way.")
        If p12.BackColor = Color.FromArgb(0, 0, 0) And Not CurrentPlace.Text = "odd playground" Then _
            GameOver("One of the rooms has gotten collapsed and blocked your way.")
        If p17.BackColor = Color.FromArgb(0, 0, 0) And place09_2.Tag < 2 Then _
            GameOver("One of the rooms has gotten collapsed and blocked your way.")
        If p18.BackColor = Color.FromArgb(0, 0, 0) And items.Items.Contains("Sodium") = False Then _
            GameOver("One of the rooms has gotten collapsed and blocked your way.")
    End Sub

    Private Sub SpreadFire(target As Label, spreaders As Label())
        If target.BackColor = Color.FromArgb(0, 0, 0) Then Exit Sub
        Dim random_ = New Random(Now.Date.Millisecond)
        Dim AddFire As Double = 0
        For Each spreader In spreaders
            If spreader.Tag.ToString.Split("/").Count = 1 Then Continue For
            If spreader.BackColor = Color.FromArgb(0, 0, 0) Or spreader.BackColor = Color.FromArgb(255, 255, 255) Then _
                Continue For
            If target.Tag.ToString.Split("/").Count = 2 Then _
                AddFire +=
                    Math.Max(0,
                             Math.Min(CDbl(spreader.Tag.ToString.Split("/")(0)),
                                      CDbl(spreader.Tag.ToString.Split("/")(1))))/20
        Next
        For Each spreader In spreaders
            If spreader.Tag.ToString.Split("/").Count = 1 Then Continue For
            If spreader.BackColor = Color.FromArgb(0, 0, 0) Or spreader.BackColor = Color.FromArgb(255, 255, 255) Then _
                Continue For
            If target.Tag.ToString.Split("/").Count = 1 Then
                If _
                    Math.Log(
                        Math.Min(CDbl(spreader.Tag.ToString.Split("/")(0)), CDbl(spreader.Tag.ToString.Split("/")(1)))/
                        spreader.Tag.ToString.Split("/")(1) + 1, 10) > Rnd() Then
                    target.Tag = "0/" & target.Tag
                    If mute.Checked = False Then _
                        My.Computer.Audio.Play(
                            My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound10.wm")
                    target.BackColor = Color.FromArgb(255,
                                                      Math.Min(255,
                                                               Math.Max(0,
                                                                        255*
                                                                        (1 -
                                                                         target.Tag.ToString.Split("/")(0)/
                                                                         target.Tag.ToString.Split("/")(1)))),
                                                      Math.Min(255,
                                                               Math.Max(0,
                                                                        255*
                                                                        (1 -
                                                                         target.Tag.ToString.Split("/")(0)/
                                                                         target.Tag.ToString.Split("/")(1)))))
                End If
            End If
        Next
        If AddFire > 0 Then
            AddFire *= random_.Next(5, 16)/10
            AddFire = Math.Log(AddFire)
            target.Tag = target.Tag.ToString.Split("/")(0) + AddFire & "/" & target.Tag.ToString.Split("/")(1)
            target.BackColor = Color.FromArgb(255,
                                              Math.Min(255,
                                                       Math.Max(0,
                                                                255*
                                                                (1 -
                                                                 target.Tag.ToString.Split("/")(0)/
                                                                 target.Tag.ToString.Split("/")(1)))),
                                              Math.Min(255,
                                                       Math.Max(0,
                                                                255*
                                                                (1 -
                                                                 target.Tag.ToString.Split("/")(0)/
                                                                 target.Tag.ToString.Split("/")(1)))))
            If Math.Log(target.Tag.ToString.Split("/")(0)/target.Tag.ToString.Split("/")(1) - 1, 10) > Rnd() Then
                target.BackColor = Color.FromArgb(0, 0, 0)
                target.ForeColor = Color.FromArgb(255, 255, 255)
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound32.wm")
                If target.Text = CurrentPlace.Text Then
                    fire.Enabled = False
                    firecost.Enabled = False
                    GameOver("The place where you're staying has collapsed.")
                End If
            End If
        End If
    End Sub

    Private Sub place24_1_Click(sender As Object, e As EventArgs) Handles place23_1.Click
        If CostPower(6) Then
            Scene19Appears()
        End If
    End Sub

    Private Sub place20_1_Click(sender As Object, e As EventArgs) Handles place20_1.Click
        If CostPower(3) Then
            Scene24Appears()
        End If
    End Sub

    Private Sub place21_1_Click(sender As Object, e As EventArgs) Handles place24_1.Click
        If CostPower(3) Then
            Scene20Appears()
        End If
    End Sub

    Private Sub place21_2_Click(sender As Object, e As EventArgs) Handles place24_2.Click
        If CostPower(3) Then
            Scene21Appears()
        End If
    End Sub

    Private Sub place21_3_Click(sender As Object, e As EventArgs) Handles place24_3.Click
        If CostPower(3) Then
            Scene22Appears()
        End If
    End Sub

    Private Sub place22_1_Click(sender As Object, e As EventArgs) Handles place21_1.Click
        If CostPower(3) Then
            Scene24Appears()
        End If
    End Sub

    Private Sub place23_1_Click(sender As Object, e As EventArgs) Handles place22_1.Click
        If CostPower(3) Then
            Scene24Appears()
        End If
    End Sub

    Private Sub firecost_Tick(sender As Object, e As EventArgs) Handles firecost.Tick
        firecost.Tag += 10
        If _
            CurrentPlace.Tag.ToString.Split("/").Count > 1 AndAlso
            firecost.Tag >=
            Math.Pow(
                40*
                (1.25 -
                 Math.Min(CDbl(CurrentPlace.Tag.ToString.Split("/")(0)), CDbl(CurrentPlace.Tag.ToString.Split("/")(1)))/
                 CurrentPlace.Tag.ToString.Split("/")(1)), 1.5) Then
            firecost.Tag = 0
            life.Value -= 1
            lifetext.Text = life.Value & "/" & life.Maximum
            If life.Value = 0 Then
                fire.Enabled = False
                firecost.Enabled = False
                GameOver("You died.")
            End If
        End If
        p1.ForeColor = Color.Black
        p2.ForeColor = Color.Black
        p3.ForeColor = Color.Black
        p4.ForeColor = Color.Black
        p5.ForeColor = Color.Black
        p6.ForeColor = Color.Black
        p7.ForeColor = Color.Black
        p8.ForeColor = Color.Black
        p9.ForeColor = Color.Black
        p10.ForeColor = Color.Black
        p11.ForeColor = Color.Black
        p12.ForeColor = Color.Black
        p13.ForeColor = Color.Black
        p14.ForeColor = Color.Black
        p15.ForeColor = Color.Black
        p16.ForeColor = Color.Black
        p17.ForeColor = Color.Black
        p18.ForeColor = Color.Black
        p19.ForeColor = Color.Black
        p20.ForeColor = Color.Black
        p21.ForeColor = Color.Black
        p22.ForeColor = Color.Black
        p23.ForeColor = Color.Black
        CurrentPlace.ForeColor = Color.Blue
    End Sub

    Private Sub place21_3_Click_1(sender As Object, e As EventArgs) Handles place21_3.Click
        MsgBox("A music paper of SixGod.", 0, "Paper")
    End Sub

    Private Sub place21_4_Click(sender As Object, e As EventArgs) Handles place21_4.Click
        If MsgBox("Do you want to play the piano?", vbYesNo, "Confirm") = vbYes Then
            MsgBox("If you correctly enter these letters, it will be completed.", 0, "Piano")
            If Not InputBox("Please enter: hello", "Enter") = "hello" Then GoTo wrong
            If Not InputBox("Please enter: ,", "Enter") = "," Then GoTo wrong
            If Not InputBox("Please enter: i", "Enter") = "i" Then GoTo wrong
            If Not InputBox("Please enter: like", "Enter") = "like" Then GoTo wrong
            If Not InputBox("Please enter: eating", "Enter") = "eating" Then GoTo wrong
            If Not InputBox("Please enter: worms", "Enter") = "worms" Then GoTo wrong
            MsgBox("Oh my god, you like eating worms!", 0, "!!")
            Disappear1()
            picturebox2.Image =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image1.wm")
            ClearWorm.Enabled = True
            Exit Sub
        Else
            Exit Sub
        End If
        wrong:
        MsgBox("Wrong!", 0, "Wrong")
    End Sub

    Private Sub ClearWorm_Tick(sender As Object, e As EventArgs) Handles ClearWorm.Tick
        ClearWorm.Enabled = False
        Scene21Appears()
    End Sub

    Private Sub place21_2_Click_1(sender As Object, e As EventArgs) Handles place21_2.Click
        If place21_2.Tag = 1 Then
            place21_2.Tag = 2
            items.Items.Add("piano key")
            MsgBox("You get a key on a musical instrument(钢琴琴键).", 0, "Piano key")
        Else
            MsgBox("Some large Musical instruments", 0, "Music")
        End If
    End Sub

    Private Sub place22_4_Click(sender As Object, e As EventArgs) Handles place22_4.Click
        MsgBox("There is a big pen with ""SixGod"" on it.", 0, "Art")
    End Sub

    Private Sub place22_3_Click(sender As Object, e As EventArgs) Handles place22_3.Click
        MsgBox("A seating chart of students. It seems the turkey's seat is far away from the platform.", 0, "Art")
    End Sub

    Private Sub place22_2_Click(sender As Object, e As EventArgs) Handles place22_2.Click
        If place22_2.Tag = 1 Then
            MsgBox("The locked art equipment cabinet requires a square-shaped thing to open.", 0, "Lock")
            If items.Items.Contains("piano key") Then
                If MsgBox("You can use the piano key to open.", vbYesNo, "open") = vbYes Then
                    place22_2.Tag = 2
                    MsgBox("The cabinet is unlocked.", 0, "unlock")
                End If
            End If
        ElseIf place22_2.Tag = 2 Then
            place22_2.Tag = 3
            If items.Items.Contains("Small side key") = False Then
                items.Items.Add("Small side key")
                MsgBox("You get the key to catching machine in turkey catching association.", 0, "New item")
                place15_4.Tag = 1
            End If
            items.Items.Add("corona rock")
            MsgBox("You get a corona rock, it can help you to remove other rocks.", 0, "Corona rock")
        Else
            MsgBox("Some beautiful artworks.", 0, "Art")
        End If
    End Sub

    Public Sub FireInit()
        GroupBox1.Visible = True
        life.Visible = True
        lifetext.Visible = True
        Button6.Visible = True
        Button7.Visible = True
        Button8.Visible = True
        If magics.Items.Contains("Water egg") Then
            Button8.Enabled = True
            Button8.Text = "Water egg(1)"
        Else
            Button8.Enabled = False
            Button8.Text = "Water egg(0)"
        End If
        Button6.Text = "Heal(" & heal & ")+30%"
        If heal = 0 Then
            Button6.Enabled = False
        Else
            Button6.Enabled = True
        End If
        Button7.Text = "Revive(" & heal & ")+100%"
        If revive = 0 Then
            Button7.Enabled = False
        Else
            Button7.Enabled = True
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Button8.Enabled = False
        Button8.Text = "Water egg(0)"
        magics.Items.Remove("Water egg")
        If mute.Checked = False Then _
            My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound13.wm")
        If p1.Tag.ToString.Split("/").Count = 2 Then _
            p1.Tag = Math.Min(CDbl(p1.Tag.ToString.Split("/")(0)), CDbl(p1.Tag.ToString.Split("/")(1)))/2 & "/" &
                     p1.Tag.ToString.Split("/")(1)
        If p2.Tag.ToString.Split("/").Count = 2 Then _
            p2.Tag = Math.Min(CDbl(p2.Tag.ToString.Split("/")(0)), CDbl(p2.Tag.ToString.Split("/")(1)))/2 & "/" &
                     p2.Tag.ToString.Split("/")(1)
        If p3.Tag.ToString.Split("/").Count = 2 Then _
            p3.Tag = Math.Min(CDbl(p3.Tag.ToString.Split("/")(0)), CDbl(p3.Tag.ToString.Split("/")(1)))/2 & "/" &
                     p3.Tag.ToString.Split("/")(1)
        If p4.Tag.ToString.Split("/").Count = 2 Then _
            p4.Tag = Math.Min(CDbl(p4.Tag.ToString.Split("/")(0)), CDbl(p4.Tag.ToString.Split("/")(1)))/2 & "/" &
                     p4.Tag.ToString.Split("/")(1)
        If p5.Tag.ToString.Split("/").Count = 2 Then _
            p5.Tag = Math.Min(CDbl(p5.Tag.ToString.Split("/")(0)), CDbl(p5.Tag.ToString.Split("/")(1)))/2 & "/" &
                     p5.Tag.ToString.Split("/")(1)
        If p6.Tag.ToString.Split("/").Count = 2 Then _
            p6.Tag = Math.Min(CDbl(p6.Tag.ToString.Split("/")(0)), CDbl(p6.Tag.ToString.Split("/")(1)))/2 & "/" &
                     p6.Tag.ToString.Split("/")(1)
        If p7.Tag.ToString.Split("/").Count = 2 Then _
            p7.Tag =
                Math.Max(25, Math.Min(CDbl(p7.Tag.ToString.Split("/")(0)), CDbl(p7.Tag.ToString.Split("/")(1)))/2) & "/" &
                p7.Tag.ToString.Split("/")(1)
        If p8.Tag.ToString.Split("/").Count = 2 Then _
            p8.Tag = Math.Min(CDbl(p8.Tag.ToString.Split("/")(0)), CDbl(p8.Tag.ToString.Split("/")(1)))/2 & "/" &
                     p8.Tag.ToString.Split("/")(1)
        If p9.Tag.ToString.Split("/").Count = 2 Then _
            p9.Tag = Math.Min(CDbl(p9.Tag.ToString.Split("/")(0)), CDbl(p9.Tag.ToString.Split("/")(1)))/2 & "/" &
                     p9.Tag.ToString.Split("/")(1)
        If p10.Tag.ToString.Split("/").Count = 2 Then _
            p10.Tag = Math.Min(CDbl(p10.Tag.ToString.Split("/")(0)), CDbl(p10.Tag.ToString.Split("/")(1)))/2 & "/" &
                      p10.Tag.ToString.Split("/")(1)
        If p11.Tag.ToString.Split("/").Count = 2 Then _
            p11.Tag = Math.Min(CDbl(p11.Tag.ToString.Split("/")(0)), CDbl(p11.Tag.ToString.Split("/")(1)))/2 & "/" &
                      p11.Tag.ToString.Split("/")(1)
        If p12.Tag.ToString.Split("/").Count = 2 Then _
            p12.Tag = Math.Min(CDbl(p12.Tag.ToString.Split("/")(0)), CDbl(p12.Tag.ToString.Split("/")(1)))/2 & "/" &
                      p12.Tag.ToString.Split("/")(1)
        If p13.Tag.ToString.Split("/").Count = 2 Then _
            p13.Tag = Math.Min(CDbl(p13.Tag.ToString.Split("/")(0)), CDbl(p13.Tag.ToString.Split("/")(1)))/2 & "/" &
                      p13.Tag.ToString.Split("/")(1)
        If p14.Tag.ToString.Split("/").Count = 2 Then _
            p14.Tag = Math.Min(CDbl(p14.Tag.ToString.Split("/")(0)), CDbl(p14.Tag.ToString.Split("/")(1)))/2 & "/" &
                      p14.Tag.ToString.Split("/")(1)
        If p15.Tag.ToString.Split("/").Count = 2 Then _
            p15.Tag = Math.Min(CDbl(p15.Tag.ToString.Split("/")(0)), CDbl(p15.Tag.ToString.Split("/")(1)))/2 & "/" &
                      p15.Tag.ToString.Split("/")(1)
        If p16.Tag.ToString.Split("/").Count = 2 Then _
            p16.Tag = Math.Min(CDbl(p16.Tag.ToString.Split("/")(0)), CDbl(p16.Tag.ToString.Split("/")(1)))/2 & "/" &
                      p16.Tag.ToString.Split("/")(1)
        If p17.Tag.ToString.Split("/").Count = 2 Then _
            p17.Tag = Math.Min(CDbl(p17.Tag.ToString.Split("/")(0)), CDbl(p17.Tag.ToString.Split("/")(1)))/2 & "/" &
                      p17.Tag.ToString.Split("/")(1)
        If p18.Tag.ToString.Split("/").Count = 2 Then _
            p18.Tag = Math.Min(CDbl(p18.Tag.ToString.Split("/")(0)), CDbl(p18.Tag.ToString.Split("/")(1)))/2 & "/" &
                      p18.Tag.ToString.Split("/")(1)
        If p19.Tag.ToString.Split("/").Count = 2 Then _
            p19.Tag = Math.Min(CDbl(p19.Tag.ToString.Split("/")(0)), CDbl(p19.Tag.ToString.Split("/")(1)))/2 & "/" &
                      p19.Tag.ToString.Split("/")(1)
        If p20.Tag.ToString.Split("/").Count = 2 Then _
            p20.Tag = Math.Min(CDbl(p20.Tag.ToString.Split("/")(0)), CDbl(p20.Tag.ToString.Split("/")(1)))/2 & "/" &
                      p20.Tag.ToString.Split("/")(1)
        If p21.Tag.ToString.Split("/").Count = 2 Then _
            p21.Tag = Math.Min(CDbl(p21.Tag.ToString.Split("/")(0)), CDbl(p21.Tag.ToString.Split("/")(1)))/2 & "/" &
                      p21.Tag.ToString.Split("/")(1)
        If p22.Tag.ToString.Split("/").Count = 2 Then _
            p22.Tag = Math.Min(CDbl(p22.Tag.ToString.Split("/")(0)), CDbl(p22.Tag.ToString.Split("/")(1)))/2 & "/" &
                      p22.Tag.ToString.Split("/")(1)
        If p23.Tag.ToString.Split("/").Count = 2 Then _
            p23.Tag = Math.Min(CDbl(p23.Tag.ToString.Split("/")(0)), CDbl(p23.Tag.ToString.Split("/")(1)))/2 & "/" &
                      p23.Tag.ToString.Split("/")(1)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        heal -= 1
        Button6.Text = "Heal(" & heal & ")+30%"
        If mute.Checked = False Then _
            My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound15.wm")
        If heal = 0 Then
            Button6.Enabled = False
        Else
            Button6.Enabled = True
        End If
        If life.Value + life.Maximum*0.3 > life.Maximum Then
            life.Value = life.Maximum
            lifetext.Text = life.Value & "/" & life.Maximum
        Else
            life.Value += life.Maximum*0.3
            lifetext.Text = life.Value & "/" & life.Maximum
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        revive -= 1
        Button7.Text = "Revive(" & heal & ")+100%"
        If mute.Checked = False Then _
            My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound19.wm")
        If heal = 0 Then
            Button7.Enabled = False
        Else
            Button7.Enabled = True
        End If
        life.Value = life.Maximum
        lifetext.Text = life.Value & "/" & life.Maximum
    End Sub

    Private Sub place25_1_Click(sender As Object, e As EventArgs) Handles place25_1.Click
        place25_1.Tag += 1
        Scene10Appears()
        If MsgBox("Do you want a hard hammer?", vbYesNo, "Key") = vbYes Then
            If items.Items.Contains("hammer") Then
                items.Items.Remove("hammer")
                items.Items.Add("hard hammer")
                MsgBox("You get the plastic hammer changed to hard hammer")
            Else
                place25_1.Tag = 1
                MsgBox("You have no plastic hammer so that you cannot change it to hard hammer.", 0, "No")
            End If
        Else
            place25_1.Tag = 1
        End If
    End Sub

    Private Sub place23_2_Click(sender As Object, e As EventArgs) Handles place23_2.Click
        MsgBox("The hand basins are all extremely dirty: filled with worms, dirts, and something like shits.", 0,
               "Dirty")
    End Sub

    Private Sub place23_4_Click(sender As Object, e As EventArgs) Handles place23_4.Click
        MsgBox("The urinals are all extremely smelly: filled with green smelly waters, and something like worms.", 0,
               "Smelly")
    End Sub

    Private Sub place23_3_Click(sender As Object, e As EventArgs) Handles place23_3.Click
        MsgBox(
            "The doors of stool pools are all broken and can only be opened a little, except worms, human cannot be so thin like that.",
            0, "Shrunk")
        If place23_3.Tag = 1 Then
            place23_3.Tag = 2
            MsgBox("You get a cleaner near one of the broken doors.", 0, "New item")
            items.Items.Add("cleaner")
        End If
    End Sub

    Public Sub SetParent1()
        lock26_1.Parent = PictureBox3
        lock27_1.Parent = PictureBox3
        lock27_2.Parent = PictureBox3
        actor.Top = 0
        actor.Left = 0
        actor.Width = PictureBox3.Width
        actor.Height = PictureBox3.Width
        actor.Parent = PictureBox3
        dialogue.Top = 0
        dialogue.Left = 0
        dialogue.Parent = actor
        actor.BringToFront()
        dialogue.BringToFront()
        dialogue.Text = ""
        ItemBox(0) = item1
        ItemBox(1) = item2
        ItemBox(2) = item3
        ItemBox(3) = item4
        ItemBox(4) = item5
    End Sub

    Public Sub Disappear2()
        deselect()
        card107_x.Visible = False
        place26_4.Visible = False
        lock26_1.Visible = False
        place27_2.Visible = False
        lock27_1.Visible = False
        lock27_2.Visible = False
        place28_2.Visible = False
        place28_3.Visible = False
        box28_1.Visible = False
        lock29_1.Visible = False
        place30_2.Visible = False
        warning30_1.Visible = False
        fire30_2.Visible = False
        key31_1.Visible = False
        lock31_2.Visible = False
        potion31_3.Visible = False
        backward.Visible = False
        arrow32_2.Visible = False
        coin26_2.Visible = False
        arrow33_1.Visible = False
        arrow33_3.Visible = False
        paper33_4.Visible = False
        lock33_4.Visible = False
        arrow34_2.Visible = False
        arrow34_3.Visible = False
        water35_2.Visible = False
        battery35_3.Visible = False
        scissors35_4.Visible = False
        arrow37_2.Visible = False
        warning37_3.Visible = False
        worm37_4.Visible = False
        dive38_1.Visible = False
        arrow40_1.Visible = False
        lock40_2.Visible = False
        arrow41_1.Visible = False
        lock41_2.Visible = False
        arrow41_3.Visible = False
        paper39_1.Visible = False
        place42_1.Visible = False
        place43_1.Visible = False
        stick43_2.Visible = False
        place44_2.Visible = False
        place44_1.Visible = False
        paper44_3.Visible = False
        lock44_4.Visible = False
        arrow45_1.Visible = False
        blood45_2.Visible = False
        magic45_3.Visible = False
        arrow46_1.Visible = False
        lock46_2.Visible = False
        magic46_3.Visible = False
        paper46_4.Visible = False
        ball46_5.Visible = False
        potion47_1.Visible = False
        potion47_2.Visible = False
        arrow50_1.Visible = False
        lock51_Mistake.Visible = False
        skull51_3.Visible = False
        lock50_Mistake.Visible = False
        arrow55_1.Visible = False
        arrow57_1.Visible = False
        lock57_2.Visible = False
        arrow57_3.Visible = False
        lock57_4.Visible = False
        potion57_5.Visible = False
        arrow54_1.Visible = False
        warning54_2.Visible = False
        bottle58_1.Visible = False
        arrow62_1.Visible = False
        arrow63_1.Visible = False
        laptop63_2.Visible = False
        machine63_3.Visible = False
        lock63_4.Visible = False
        mp67_1.Visible = False
        arrow68_1.Visible = False
        lock68_2.Visible = False
        blocker68_3.Visible = False
        lock62_2.Visible = False
        blocker68_3.Visible = False
        dive64_1.Visible = False
        key66_3.Visible = False
        lock66_2.Visible = False
        arrow66_1.Visible = False
        paper46_5.Visible = False
        arrow69_1.Visible = False
        lock69_2.Visible = False
        arrow70_1.Visible = False
        lock70_2.Visible = False
        leg70_3.Visible = False
        bottle65_1.Visible = False
        apple71_2.Visible = False
        key71_1.Visible = False
        lock72_1.Visible = False
        chicken72_2.Visible = False
        key72_3.Visible = False
        answer73_3.Visible = False
        chest74_1.Visible = False
        arrow73_1.Visible = False
        arrow79_1.Visible = False
        downward81_1.Visible = False
        lock81_2.Visible = False
        arrow81_3.Visible = False
        arrow82_1.Visible = False
        letter82_2.Visible = False
        arrow92_1.Visible = False
        bow92_2.Visible = False
        arrow92_3.Visible = False
        card81_3.Visible = False
        box85_1.Visible = False
        colloid84_1.Visible = False
        ghostbox86_1.Visible = False
        gas87_1.Visible = False
        paper87_2.Visible = False
        ghostbox86_1.Visible = False
        paper87_3.Visible = False
        arrow92_1.Visible = False
        arrow92_3.Visible = False
        lock91_1.Visible = False
        gas93_1.Visible = False
        arrow99_1.Visible = False
        card96_1.Visible = False
        arrow101_2.Visible = False
        arrow103_1.Visible = False
        vortex106_1.Visible = False
        teleporter95_1.Visible = False
        gem101_1.Visible = False
        box98_1.Visible = False
        box100_1.Visible = False
        paper98_2.Visible = False
        machine102_1.Visible = False
        printer107_2.Visible = False
        eraser107_3.Visible = False
        password98_3.Visible = False
        arrow98_4.Visible = False
        chest82_3.Visible = False
        potion94_2.Visible = False
        safe67_3.Visible = False
        statue_fault.Visible = False
        arrow105_1.Visible = False
        computer107_1.Visible = False
        ladder106_fault.Visible = False
        trailer92_1.Visible = False
    End Sub

    Private Sub PutThing(thing As Control)
        thing.Parent = PictureBox3
        If Not Unlocked.Items.Contains(thing.Name) Then thing.Visible = True
    End Sub

    Friend Sub Scene001appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene35.wm")
        PutThing(lock26_1)
        PutThing(backward)
        PutThing(arrow34_2)
        PutThing(place26_4)
        backward.Tag = 26
        coin26_2.Parent = PictureBox3
        If Unlocked.Items.Contains(coin26_2.Name) Then coin26_2.Visible = True
    End Sub

    Friend Sub Scene002appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene36.wm")
        PutThing(lock27_1)
        PutThing(lock27_2)
        PutThing(place26_4)
        PutThing(arrow32_2)
        PutThing(place27_2)
        PutThing(backward)
        backward.Tag = 27
    End Sub

    Friend Sub Scene003appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene37.wm")
        PutThing(place28_2)
        PutThing(place28_3)
        PutThing(box28_1)
        PutThing(backward)
        backward.Tag = 28
    End Sub

    Friend Sub Scene004appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene38.wm")
        PutThing(place26_4)
        PutThing(arrow32_2)
        PutThing(lock29_1)
        PutThing(backward)
        backward.Tag = 29
    End Sub

    Friend Sub Scene005appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene39.wm")
        PutThing(place30_2)
        PutThing(warning30_1)
        PutThing(fire30_2)
        PutThing(backward)
        backward.Tag = 30
    End Sub

    Friend Sub Scene006appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene40.wm")
        PutThing(key31_1)
        PutThing(lock31_2)
        PutThing(potion31_3)
        PutThing(arrow32_2)
        PutThing(backward)
        backward.Tag = 31
    End Sub

    Friend Sub Scene007appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene41.wm")
        backward.Tag = 32
        PutThing(backward)
        PutThing(arrow32_2)
    End Sub

    Friend Sub Scene008appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene42.wm")
        backward.Tag = 33
        PutThing(arrow33_1)
        PutThing(backward)
        PutThing(arrow33_3)
        PutThing(paper33_4)
        PutThing(lock33_4)
    End Sub

    Friend Sub Scene009appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene43.wm")
        backward.Tag = 34
        PutThing(backward)
        PutThing(arrow34_2)
        PutThing(arrow34_3)
    End Sub

    Friend Sub Scene010appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene44.wm")
        backward.Tag = 35
        PutThing(backward)
        PutThing(water35_2)
        PutThing(battery35_3)
        PutThing(scissors35_4)
    End Sub

    Friend Sub Scene011appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene45.wm")
        PutThing(arrow32_2)
    End Sub

    Friend Sub Scene012appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene46.wm")
        backward.Tag = 37
        PutThing(backward)
        PutThing(arrow37_2)
        PutThing(warning37_3)
        PutThing(worm37_4)
    End Sub

    Friend Sub Scene013appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene47.wm")
        backward.Tag = 38
        PutThing(backward)
        PutThing(dive38_1)
        PutThing(arrow34_3)
    End Sub

    Friend Sub Scene014appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene48.wm")
        backward.Tag = 39
        PutThing(backward)
        PutThing(arrow32_2)
        PutThing(paper39_1)
    End Sub

    Friend Sub Scene015appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene49.wm")
        backward.Tag = 40
        PutThing(backward)
        PutThing(arrow40_1)
        PutThing(lock40_2)
    End Sub

    Friend Sub Scene016appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene50.wm")
        backward.Tag = 41
        PutThing(backward)
        PutThing(arrow41_1)
        PutThing(lock41_2)
        PutThing(arrow41_3)
    End Sub

    Friend Sub Scene017appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene51.wm")
        backward.Tag = 42
        PutThing(backward)
        PutThing(arrow41_1)
        PutThing(place42_1)
    End Sub

    Friend Sub Scene018appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene52.wm")
        backward.Tag = 43
        PutThing(backward)
        PutThing(place43_1)
        PutThing(arrow34_2)
        PutThing(stick43_2)
    End Sub

    Friend Sub Scene019appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene53.wm")
        backward.Tag = 44
        PutThing(place44_1)
        PutThing(place44_2)
        PutThing(paper44_3)
        PutThing(lock44_4)
    End Sub

    Friend Sub Scene020appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene54.wm")
        backward.Tag = 45
        PutThing(backward)
        PutThing(arrow45_1)
        PutThing(blood45_2)
        PutThing(magic45_3)
    End Sub

    Friend Sub Scene021appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene55.wm")
        backward.Tag = 46
        PutThing(backward)
        PutThing(arrow46_1)
        PutThing(lock46_2)
        PutThing(magic46_3)
        PutThing(arrow33_3)
        PutThing(paper46_4)
        PutThing(ball46_5)
        PutThing(paper46_5)
    End Sub

    Friend Sub Scene022appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene56.wm")
        backward.Tag = 47
        PutThing(backward)
        PutThing(potion47_1)
        PutThing(potion47_2)
    End Sub

    Friend Sub Scene023appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene57.wm")
        backward.Tag = 48
        PutThing(backward)
        PictureBox3.SizeMode = PictureBoxSizeMode.Zoom
    End Sub

    Friend Sub Scene024appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene58.wm")
        backward.Tag = 49
        PutThing(arrow32_2)
    End Sub

    Friend Sub Scene025appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene59.wm")
        backward.Tag = 50
        PutThing(backward)
        PutThing(arrow50_1)
        PutThing(lock50_Mistake)
        PutThing(place26_4)
    End Sub

    Friend Sub Scene026appears()
        Disappear2()
        If PictureBox3.Tag < 11 Then
            PictureBox3.Image =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene60.wm")
        Else
            PictureBox3.Image =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene60_2.wm")
        End If
        backward.Tag = 51
        PutThing(backward)
        PutThing(arrow50_1)
        lock51_Mistake.Parent = PictureBox3
        skull51_3.Parent = PictureBox3
        If Unlocked.Items.Contains(lock51_Mistake.Name) Then lock51_Mistake.Visible = True
        If Unlocked.Items.Contains(skull51_3.Name) Then skull51_3.Visible = True
    End Sub

    Friend Sub Scene027appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene61.wm")
        backward.Tag = 52
        PutThing(backward)
        PutThing(arrow50_1)
    End Sub

    Friend Sub Scene028appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene62.wm")
        backward.Tag = 53
        PutThing(backward)
        PutThing(arrow41_3)
    End Sub

    Friend Sub Scene029appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene63.wm")
        backward.Tag = 54
        PutThing(backward)
        PutThing(place30_2)
        PutThing(arrow54_1)
        PutThing(warning54_2)
    End Sub

    Friend Sub Scene030appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene64.wm")
        backward.Tag = 55
        PutThing(backward)
        PutThing(arrow55_1)
    End Sub

    Friend Sub Scene031appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene65.wm")
        backward.Tag = 56
        PutThing(backward)
        PutThing(arrow33_3)
    End Sub

    Friend Sub Scene032appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene66.wm")
        backward.Tag = 57
        PutThing(backward)
        PutThing(arrow57_1)
        PutThing(lock57_2)
        PutThing(arrow57_3)
        PutThing(lock57_4)
        PutThing(potion57_5)
    End Sub

    Friend Sub Scene033appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene67.wm")
        backward.Tag = 58
        PutThing(backward)
        PutThing(arrow50_1)
        PutThing(bottle58_1)
    End Sub

    Friend Sub Scene034appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene68.wm")
        backward.Tag = 59
        PutThing(backward)
        PutThing(water35_2)
    End Sub

    Friend Sub Scene035appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene69.wm")
        backward.Tag = 60
        PutThing(backward)
        PutThing(arrow32_2)
    End Sub

    Friend Sub Scene036appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene70.wm")
        backward.Tag = 61
        PutThing(backward)
        PutThing(arrow32_2)
    End Sub

    Friend Sub Scene037appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene71.wm")
        backward.Tag = 62
        PutThing(backward)
        PutThing(place30_2)
        PutThing(arrow62_1)
        PutThing(lock62_2)
    End Sub

    Friend Sub Scene038appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene72.wm")
        backward.Tag = 63
        PutThing(backward)
        PutThing(arrow63_1)
        PutThing(laptop63_2)
        PutThing(machine63_3)
        PutThing(lock63_4)
    End Sub

    Friend Sub Scene039appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene73.wm")
        backward.Tag = 64
        PutThing(backward)
        PutThing(dive64_1)
    End Sub

    Friend Sub Scene040appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene74.wm")
        backward.Tag = 65
        PutThing(backward)
        PutThing(arrow50_1)
        If PictureBox3.Tag >= 27 Then PutThing(bottle65_1)
    End Sub

    Friend Sub Scene041appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene75.wm")
        backward.Tag = 66
        PutThing(backward)
        PutThing(arrow66_1)
        PutThing(lock66_2)
        PutThing(key66_3)
        PutThing(arrow46_1)
    End Sub

    Friend Sub Scene042appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene76.wm")
        backward.Tag = 67
        PutThing(backward)
        PutThing(paper46_4)
        PutThing(mp67_1)
        PutThing(safe67_3)
        safe67_3.Size = New Size(128, 128)
        If Unlocked.Items.Contains("open safe") Then safe67_3.Image = ImageList1.Images(71)
    End Sub

    Friend Sub Scene043appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene77.wm")
        backward.Tag = 68
        PutThing(backward)
        PutThing(arrow68_1)
        PutThing(lock68_2)
        blocker68_3.Parent = PictureBox3
        If Unlocked.Items.Contains(blocker68_3.Name) And Not Unlocked.Items.Contains("IrremovableBottle") Then
            blocker68_3.Visible = True
        Else
            PutThing(arrow34_2)
        End If
    End Sub

    Friend Sub Scene044appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene78.wm")
        backward.Tag = 69
        PutThing(backward)
        PutThing(arrow69_1)
        PutThing(lock69_2)
    End Sub

    Friend Sub Scene045appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene79.wm")
        backward.Tag = 70
        PutThing(backward)
        PutThing(arrow70_1)
        PutThing(lock70_2)
        PutThing(leg70_3)
    End Sub

    Friend Sub Scene046appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene80.wm")
        backward.Tag = 71
        PutThing(backward)
        If Not Unlocked.Items.Contains("defeat witch") Then PutThing(key71_1)
        PutThing(apple71_2)
    End Sub

    Friend Sub Scene047appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene81.wm")
        backward.Tag = 72
        PutThing(backward)
        PutThing(arrow50_1)
        PutThing(lock72_1)
        PutThing(chicken72_2)
        If Unlocked.Items.Contains("defeat witch") Then PutThing(key72_3)
    End Sub

    Friend Sub Scene048appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene82.wm")
        backward.Tag = 73
        PutThing(backward)
        PutThing(answer73_3)
        PutThing(arrow73_1)
    End Sub

    Friend Sub Scene049appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene83.wm")
        backward.Tag = 74
        PutThing(backward)
        PutThing(arrow50_1)
        PutThing(chest74_1)
    End Sub

    Friend Sub Scene050appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene84.wm")
        backward.Tag = 75
        PutThing(arrow33_1)
        PutThing(place26_4)
    End Sub

    Friend Sub Scene051appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene85.wm")
        backward.Tag = 76
        PutThing(backward)
        PutThing(arrow41_3)
    End Sub

    Friend Sub Scene052appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene86.wm")
        backward.Tag = 77
        PutThing(backward)
        PutThing(arrow32_2)
    End Sub

    Friend Sub Scene053appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene87.wm")
        backward.Tag = 78
        PutThing(backward)
        PutThing(arrow32_2)
    End Sub

    Friend Sub Scene054appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene88.wm")
        backward.Tag = 79
        PutThing(backward)
        PutThing(arrow79_1)
    End Sub

    Friend Sub Scene055appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene89.wm")
        backward.Tag = 80
        PutThing(backward)
        PutThing(arrow55_1)
    End Sub

    Friend Sub Scene056appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene90.wm")
        backward.Tag = 81
        PutThing(downward81_1)
        PutThing(lock81_2)
        PutThing(arrow81_3)
        PutThing(arrow79_1)
        PutThing(card81_3)
    End Sub

    Friend Sub Scene057appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene91.wm")
        backward.Tag = 82
        PutThing(arrow82_1)
        PutThing(letter82_2)
        PutThing(chest82_3)
    End Sub

    Friend Sub Scene058appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene92.wm")
        backward.Tag = 83
        PutThing(arrow92_1)
        PutThing(bow92_2)
        PutThing(arrow92_3)
    End Sub

    Friend Sub Scene059appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene93.wm")
        backward.Tag = 84
        PutThing(backward)
        PutThing(colloid84_1)
    End Sub

    Friend Sub Scene060appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene94.wm")
        backward.Tag = 85
        PutThing(backward)
        PutThing(box85_1)
    End Sub

    Friend Sub Scene061appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene95.wm")
        backward.Tag = 86
        PutThing(backward)
        If Not Unlocked.Items.Contains("machine used") Then PutThing(dive64_1)
        PutThing(ghostbox86_1)
    End Sub

    Friend Sub Scene062appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene96.wm")
        backward.Tag = 87
        PutThing(backward)
        PutThing(gas87_1)
        PutThing(paper87_2)
        PutThing(paper87_3)
    End Sub

    Friend Sub Scene063appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene97.wm")
        backward.Tag = 88
        PutThing(arrow41_3)
        PutThing(backward)
    End Sub

    Friend Sub Scene064appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene98.wm")
        backward.Tag = 89
        PutThing(backward)
        PutThing(arrow32_2)
    End Sub

    Friend Sub Scene065appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene99.wm")
        backward.Tag = 90
        PutThing(backward)
        PutThing(arrow46_1)
        PutThing(place30_2)
    End Sub

    Friend Sub Scene066appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene100.wm")
        backward.Tag = 91
        PutThing(backward)
        PutThing(arrow32_2)
        PutThing(lock91_1)
    End Sub

    Friend Sub Scene067appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene101.wm")
        backward.Tag = 92
        PutThing(backward)
        PutThing(arrow70_1)
        PutThing(trailer92_1)
        trailer92_1.Size = New Size(128, 128)
    End Sub

    Friend Sub Scene068appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene102.wm")
        backward.Tag = 93
        PutThing(backward)
        PutThing(arrow50_1)
        PutThing(gas93_1)
    End Sub

    Friend Sub Scene069appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene103.wm")
        backward.Tag = 94
        PutThing(backward)
        PutThing(arrow62_1)
        PutThing(potion94_2)
    End Sub

    Friend Sub Scene070appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene104.wm")
        backward.Tag = 95
        PutThing(backward)
        PutThing(teleporter95_1)
        teleporter95_1.Size = New Size(192, 192)
        If Unlocked.Items.Contains("mirror1deflect") Then teleporter95_1.Image = ImageList1.Images(73) Else _
            teleporter95_1.Image = ImageList1.Images(74)
    End Sub

    Friend Sub Scene071appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene105.wm")
        backward.Tag = 96
        PutThing(backward)
        PutThing(arrow69_1)
        PutThing(card96_1)
    End Sub

    Friend Sub Scene072appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene106.wm")
        backward.Tag = 97
        PutThing(backward)
        PutThing(arrow41_3)
        PutThing(arrow81_3)
        PutThing(teleporter95_1)
        teleporter95_1.Size = New Size(192, 192)
        If Unlocked.Items.Contains("mirror2deflect") Then teleporter95_1.Image = ImageList1.Images(73) Else _
            teleporter95_1.Image = ImageList1.Images(74)
    End Sub

    Friend Sub Scene073appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene107.wm")
        backward.Tag = 98
        PutThing(box98_1)
        PutThing(paper98_2)
        PutThing(password98_3)
        PutThing(arrow98_4)
        box98_1.Size = New Size(96, 96)
        If Unlocked.Items.Contains("open HF box") Then box98_1.Image = ImageList1.Images(61)
    End Sub

    Friend Sub Scene074appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene108.wm")
        backward.Tag = 99
        PutThing(backward)
        PutThing(arrow99_1)
        PutThing(arrow57_1)
    End Sub

    Friend Sub Scene075appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene109.wm")
        backward.Tag = 100
        PutThing(backward)
        PutThing(box100_1)
        box100_1.Size = New Size(96, 96)
    End Sub

    Friend Sub Scene076appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene110.wm")
        backward.Tag = 101
        PutThing(backward)
        PutThing(gem101_1)
        PutThing(arrow101_2)
        gem101_1.Size = New Size(128, 192)
        If Unlocked.Items.Contains("break gem") Then gem101_1.Image = ImageList1.Images(58)
    End Sub

    Friend Sub Scene077appears()
        Disappear2()
        If Unlocked.Items.Contains("build stairs") Then _
            PictureBox3.Image =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene111_1.wm") _
            Else _
            PictureBox3.Image =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene111.wm")
        backward.Tag = 102
        PutThing(backward)
        PutThing(arrow50_1)
        PutThing(machine102_1)
    End Sub

    Friend Sub Scene078appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene112.wm")
        backward.Tag = 103
        PutThing(backward)
        PutThing(arrow103_1)
    End Sub

    Friend Sub Scene079appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene113.wm")
        backward.Tag = 104
        PutThing(backward)
        PutThing(arrow33_3)
    End Sub

    Friend Sub Scene080appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene114.wm")
        backward.Tag = 105
        PutThing(backward)
        PutThing(arrow105_1)
        PutThing(statue_fault)
        statue_fault.Size = New Size(100, 200)
    End Sub

    Friend Sub Scene081appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene115.wm")
        backward.Tag = 106
        PutThing(backward)
        PutThing(vortex106_1)
        vortex106_1.Size = New Size(96, 96)
        PutThing(ladder106_fault)
        ladder106_fault.Size = New Size(40, 150)
    End Sub

    Friend Sub Scene082appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene116.wm")
        backward.Tag = 107
        PutThing(backward)
        PutThing(computer107_1)
        PutThing(printer107_2)
        PutThing(eraser107_3)
        PutThing(card107_x)
    End Sub

    Friend Sub Scene083appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene117.wm")
        backward.Tag = 108
        PutThing(backward)
        PutThing(arrow33_1)
    End Sub

    Friend Sub Scene084appears()
        Disappear2()
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene118.wm")
        backward.Tag = 109
    End Sub

    Private Sub MoveAtropos_Tick(sender As Object, e As EventArgs) Handles MoveAtropos.Tick
        If MoveHydrogenPeroxide Then
            blocker68_3.Top += 6
            If blocker68_3.Top < - 33 + 6 And blocker68_3.Top > - 33 - 6 Then
                MoveHydrogenPeroxide = False
                Unlocked.Items.Add(blocker68_3.Name)
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound55.wm")
                MoveAtropos.Enabled = False
                AddTip("Atropos set a big bottle of hydrogen peroxide here! She is quite mad.", True)
                Scene043appears()
            End If
            Exit Sub
        End If
        If actor.Top = 0 Then
            If PictureBox3.Tag = 5 Then
                MoveAtropos.Enabled = False
                SendMessage("Prince frog:" & vbCrLf & "Hello, I'm prince frog, you can straight call me Mr.Frog.", 0,
                            "What's up?")
                Exit Sub
            ElseIf PictureBox3.Tag = 27 Then
                dialogue.Visible = False
                MoveAtropos.Enabled = False
                SendMessage("Prince frog:" & vbCrLf & "See you again.", 9, "Hello, Mr.Frog.")
                Exit Sub
            ElseIf DeathFlagNum = 5 Then
                MoveAtropos.Enabled = False
                Exit Sub
            ElseIf PictureBox3.Tag = 33 And Not Unlocked.Items.Contains("DamnYou Frog") Then
                MoveAtropos.Enabled = False
                SendMessage("Prince frog:" & vbCrLf & "I have found a great thing!", 14, "What thing?")
                Exit Sub
            End If
            MoveAtropos.Tag += 1
            If MoveAtropos.Tag = 20 Then
                dialogue.ForeColor = Color.Black
                dialogue.Text = "Welcome, mortal. I know your purpose, but the" & vbCrLf & "rooster cannot be saved."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue1.wm")
            ElseIf MoveAtropos.Tag = 190 Then
                dialogue.ForeColor = Color.Black
                dialogue.Text = "This is his destiny, no one can change it." & vbCrLf &
                                "He sacrificed himself to the witch, so he must die."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue2.wm")
            ElseIf MoveAtropos.Tag = 440 Then
                dialogue.Text = "You have no right to pass through the time" & vbCrLf & "and change the past."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue3.wm")
            ElseIf MoveAtropos.Tag = 570 Then
                dialogue.Text = "You soon will find your efforts useless," & vbCrLf &
                                "and things you did are a great failure."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue4.wm")
            ElseIf MoveAtropos.Tag = 800 Then
                dialogue.Text = "I'll not let you succeed. Of course."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue5.wm")
            ElseIf MoveAtropos.Tag = 880 Then
                dialogue.Visible = False
                actor.Tag = 1
                actor.Top -= 1
            ElseIf MoveAtropos.Tag = 901 Then
                dialogue.Visible = True
                dialogue.ForeColor = Color.Black
                dialogue.Text = "I'm Atropos, the cutter of life line, the protector of" & vbCrLf & "destiny."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue6.wm")
            ElseIf MoveAtropos.Tag = 1050 Then
                dialogue.Text = "As for these mortals, at beginning, their surfaces make" & vbCrLf &
                                "illusions to others and themselves."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue7.wm")
            ElseIf MoveAtropos.Tag = 1225 Then
                dialogue.Text = "Then they start to abandon each other." & vbCrLf &
                                "But they'll never know what'll happen after their abandon."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue8.wm")
            ElseIf MoveAtropos.Tag = 1370 Then
                dialogue.Text = "And after all of these, they cycle again and again."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue9.wm")
            ElseIf MoveAtropos.Tag = 1475 Then
                dialogue.Text = "They made fallacies one by one, formed their own" & vbCrLf & "invisible catastrophe."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue10.wm")
            ElseIf MoveAtropos.Tag = 1635 Then
                dialogue.Text = "Their destiny will punish them, and save them from" & vbCrLf & "their catastrophe."
            ElseIf MoveAtropos.Tag = 1780 Then
                Hide()
                Form7.Show()
                Form7.initialization(shield_level, weapon_level, 0, 300 + shield_level*150, 2000, 14, 400, 100, 500,
                                     1000)
                music.settings.setMode("loop", True)
                music.settings.volume = 100
                music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music8.wm"
                actor.Visible = False
                dialogue.Visible = False
                MoveAtropos.Enabled = False
                actor.Top = Height
            ElseIf MoveAtropos.Tag = 1800 Then
                dialogue.Visible = True
                dialogue.ForeColor = Color.Red
                dialogue.Text = "Your soul soon will be mine."
                backward.Left = (PictureBox3.Width - backward.Width)/2
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\voice18.wm")
            ElseIf MoveAtropos.Tag = 1900 Then
                Scene016appears()
                actor.Visible = False
                dialogue.Visible = False
                MoveAtropos.Enabled = False
                AddTip("What is that? Shell we resume going forward the palace?")
            ElseIf MoveAtropos.Tag = 1901 Then
                dialogue.Visible = True
                dialogue.ForeColor = Color.Red
                dialogue.Text = "Stay alone forever."
                backward.Left = (PictureBox3.Width - backward.Width)/2
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\voice19.wm")
            ElseIf MoveAtropos.Tag = 2000 Then
                Scene025appears()
                actor.Visible = False
                dialogue.Visible = False
                MoveAtropos.Enabled = False
                AddTip("This may be Atropos's world! She can control it, and release her anger.")
            ElseIf MoveAtropos.Tag = 2001 Then
                dialogue.Visible = True
                dialogue.ForeColor = Color.Red
                dialogue.Text = "Now they must have known."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\voice20.wm")
            ElseIf MoveAtropos.Tag = 2100 Then
                Scene026appears()
                actor.Visible = False
                dialogue.Visible = False
                MoveAtropos.Enabled = False
            ElseIf MoveAtropos.Tag = 2101 Then
                dialogue.Visible = True
                dialogue.ForeColor = Color.Red
                dialogue.Text = "All of these are fallacies."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\voice21.wm")
            ElseIf MoveAtropos.Tag = 2200 Then
                Scene027appears()
                actor.Visible = False
                dialogue.Visible = False
                MoveAtropos.Enabled = False
                AddTip("It is not so simple.")
            ElseIf MoveAtropos.Tag = 2201 Then
                dialogue.Visible = True
                dialogue.ForeColor = Color.Red
                dialogue.Text = "Fall apart."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\voice22.wm")
            ElseIf MoveAtropos.Tag = 2275 Then
                Scene025appears()
                actor.Visible = False
                dialogue.Visible = False
                MoveAtropos.Enabled = False
            ElseIf MoveAtropos.Tag = 2301 Then
                dialogue.Visible = True
                dialogue.ForeColor = Color.White
                dialogue.Text = "I must admire your bravery, but the following quest" & vbCrLf & "will be very hard."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue11.wm")
            ElseIf MoveAtropos.Tag = 2455 Then
                dialogue.Text = "The next station is the hell. Come on, my ghost."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue12.wm")
            ElseIf MoveAtropos.Tag = 2575 Then
                dialogue.Text = "*ghost*"
                actor.Image =
                    Image.FromFile(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\battler15.wm")
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue13.wm")
            ElseIf MoveAtropos.Tag = 2666 Then
                MoveAtropos.Enabled = False
                Hide()
                Form7.Show()
                Form7.initialization(shield_level, weapon_level, 0, 300 + shield_level*150, 400, 16, 50, 100, 250, 1000)
                music.settings.setMode("loop", True)
                music.settings.volume = 100
                music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music8.wm"
            ElseIf MoveAtropos.Tag = 2750 Then
                dialogue.Text = "It is not so simple."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue14.wm")
            ElseIf MoveAtropos.Tag = 2800 Then
                actor.Image = Nothing
                dialogue.Text = "You will dive into the hell and find the source of" & vbCrLf & "their tragedies."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue15.wm")
            ElseIf MoveAtropos.Tag = 2925 Then
                dialogue.Text = "It's the time for you to feel their miseries." & vbCrLf & "Good luck, mortal."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue16.wm")
            ElseIf MoveAtropos.Tag = 3050 Then
                MoveAtropos.Enabled = False
                actor.Visible = False
                actor.Top = Height
                Scene028appears()
                AddTip("What means their tragedies and their miseries?")
            ElseIf MoveAtropos.Tag = 3051 Then
                dialogue.ForeColor = Color.White
                dialogue.Text = "They will be regret."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue17.wm")
            ElseIf MoveAtropos.Tag = 3125 Then
                MoveAtropos.Enabled = False
                actor.Visible = False
                Scene029appears()
            ElseIf MoveAtropos.Tag = 3126 Then
                dialogue.Text = "They are all absurd disguise."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue18.wm")
            ElseIf MoveAtropos.Tag = 3200 Then
                MoveAtropos.Enabled = False
                actor.Visible = False
                Scene030appears()
            ElseIf MoveAtropos.Tag = 3201 Then
                dialogue.Text = "Things are complex."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue19.wm")
            ElseIf MoveAtropos.Tag = 3275 Then
                MoveAtropos.Enabled = False
                actor.Visible = False
                Scene031appears()
            ElseIf MoveAtropos.Tag = 3276 Then
                dialogue.Text = "They had slain themselves."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue20.wm")
            ElseIf MoveAtropos.Tag = 3350 Then
                MoveAtropos.Enabled = False
                actor.Visible = False
                Scene032appears()
            ElseIf MoveAtropos.Tag = 3351 Then
                dialogue.Text = "Go downhill."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue21.wm")
            ElseIf MoveAtropos.Tag = 3400 Then
                MoveAtropos.Enabled = False
                actor.Visible = False
                Scene031appears()
            ElseIf MoveAtropos.Tag = 3410 Then
                dialogue.ForeColor = Color.Red
                dialogue.Text = "Their doomsday will come. And as you see, this is" & vbCrLf & "their legacy."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue22.wm")
            ElseIf MoveAtropos.Tag = 3550 Then
                dialogue.Text = "If they awaken now, the doom will not happen."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue23.wm")
            ElseIf MoveAtropos.Tag = 3640 Then
                dialogue.Text = "But it's impossible."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue24.wm")
            ElseIf MoveAtropos.Tag = 3710 Then
                actor.Visible = False
                MoveAtropos.Enabled = False
                Scene033appears()
            ElseIf MoveAtropos.Tag = 3711 Then
                dialogue.ForeColor = Color.White
                dialogue.Text = "You reached this stage!"
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue25.wm")
            ElseIf MoveAtropos.Tag = 3800 Then
                dialogue.Text = "*scream*"
                actor.Image =
                    Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image11.wm")
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue26.wm")
            ElseIf MoveAtropos.Tag = 3825 Then
                dialogue.Text = "I will defeat you, you vicious witch!"
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue27.wm")
            ElseIf MoveAtropos.Tag = 3875 Then
                dialogue.Text = "Atropos! Give me power!!"
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue28.wm")
            ElseIf MoveAtropos.Tag = 3950 Then
                dialogue.ForeColor = Color.Red
                dialogue.Text = "Yes. Destroy the stupid guy, she had broken my" & vbCrLf & "control."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue29.wm")
            ElseIf MoveAtropos.Tag = 4100 Then
                dialogue.Text = "Here is your power."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue30.wm")
            ElseIf MoveAtropos.Tag = 4150 Then
                dialogue.Text = ""
                actor.Image =
                    Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image12.wm")
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound10.wm")
            ElseIf MoveAtropos.Tag = 4175 Then
                dialogue.ForeColor = Color.White
                dialogue.Text = "Oh no! I hit the fire!!"
                actor.Image =
                    Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image13.wm")
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue31.wm")
            ElseIf MoveAtropos.Tag = 4225 Then
                dialogue.ForeColor = Color.Red
                dialogue.Text = "Tarecgosa, you abused the mortals' lust, and became their" & vbCrLf &
                                "goddess by this way. Now you'll get your DOOM!!"
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue32.wm")
            ElseIf MoveAtropos.Tag = 4475 Then
                dialogue.Text = "Annihilate!!"
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue33.wm")
            ElseIf MoveAtropos.Tag = 4550 Then
                dialogue.Text = ""
                actor.Image =
                    Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image14.wm")
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound32.wm")
            ElseIf MoveAtropos.Tag = 4600 Then
                dialogue.ForeColor = Color.White
                actor.Image =
                    Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image15.wm")
                dialogue.Text = "Mortal, though that guy hurt me, but I can still defeat you." & vbCrLf &
                                "Let's battle, and you will belong to me."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue34.wm")
            ElseIf MoveAtropos.Tag = 4900 Then
                dialogue.ForeColor = Color.White
                dialogue.Text = "Let's play a game named the turtle and the turkey."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue35.wm")
            ElseIf MoveAtropos.Tag = 5075 Then
                MoveAtropos.Enabled = False
                Hide()
                Form7.Show()
                Form7.initialization(shield_level, weapon_level, 0, 300 + shield_level*150, 741, 17, 66, 100, 666, 1000)
                music.settings.setMode("loop", True)
                music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music8.wm"
            ElseIf MoveAtropos.Tag = 5076 Then
                shining.Interval = 500
                shining.Enabled = True
                dialogue.ForeColor = Color.White
                dialogue.Text = "You defeated my mirroring, but this is not serious."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue36.wm")
            ElseIf MoveAtropos.Tag = 5250 Then
                shining.Enabled = False
                actor.Image = Nothing
                dialogue.ForeColor = Color.Red
                dialogue.Text = "I don't think you can get out of the hell. But if you" & vbCrLf &
                                "completed, we still have a way to defeat you."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue37.wm")
            ElseIf MoveAtropos.Tag = 5425 Then
                dialogue.Text = "And soon you will know the real source of their" & vbCrLf &
                                "tragedies. The same to the rooster."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue38.wm")
            ElseIf MoveAtropos.Tag = 5565 Then
                dialogue.Text = "And then it's the time for you understanding by" & vbCrLf & "yourself."
            ElseIf MoveAtropos.Tag = 5665 Then
                Disappear2()
                PictureBox3.Tag = 19
                actor.Visible = False
                shining.Tag = 0
                shining.Enabled = True
                shining.Interval = 200
                MoveAtropos.Enabled = False
                PictureBox3.Image =
                    Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image8.wm")
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound51.wm")
            ElseIf MoveAtropos.Tag = 5666 Then
                dialogue.Text = "They tragedies come from their pursuit of illusive" & vbCrLf & "happiness."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue39.wm")
            ElseIf MoveAtropos.Tag = 5800 Then
                MoveAtropos.Enabled = False
                actor.Visible = False
                Scene028appears()
            ElseIf MoveAtropos.Tag = 5801 Then
                dialogue.Text = "Their greed is always increasing rapidly."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue40.wm")
            ElseIf MoveAtropos.Tag = 5900 Then
                MoveAtropos.Enabled = False
                actor.Visible = False
                Scene029appears()
            ElseIf MoveAtropos.Tag = 5901 Then
                dialogue.Text = "Their viciousness break out with no remain."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue41.wm")
            ElseIf MoveAtropos.Tag = 5975 Then
                MoveAtropos.Enabled = False
                actor.Visible = False
                Scene033appears()
            ElseIf MoveAtropos.Tag = 5976 Then
                dialogue.Text = "What a great fallacy."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue42.wm")
            ElseIf MoveAtropos.Tag = 6025 Then
                MoveAtropos.Enabled = False
                actor.Visible = False
                Scene034appears()
            ElseIf MoveAtropos.Tag = 6026 Then
                dialogue.Text = "Now let's add some difficulties to your solution."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue43.wm")
            ElseIf MoveAtropos.Tag = 6125 Then
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound54.wm")
                blocker68_3.Visible = True
                blocker68_3.Size = New Point(130, 414)
                blocker68_3.Location = New Point(127, - 414)
                MoveHydrogenPeroxide = True
                actor.Visible = False
                Unlocked.Items.Remove("DamnYou Frog")
            ElseIf MoveAtropos.Tag = 6126 Then
                dialogue.Text = "Hello, I'm the god of Mr.Duck's pool, I know you are" & vbCrLf &
                                "going to get some water from the pool."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue44.wm")
            ElseIf MoveAtropos.Tag = 6290 Then
                dialogue.Text = "But you should activate it first, or the water will be" & vbCrLf & "useless."
            ElseIf MoveAtropos.Tag = 6390 Then
                dialogue.Text = "There is the dilute sulphuric acid, you must topple all" & vbCrLf &
                                "of them to the pool, then you can get it activated."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue45.wm")
            ElseIf MoveAtropos.Tag = 6420 Then
                GainItem(actor, "dilute sulfuric acid")
            ElseIf MoveAtropos.Tag = 6550 Then
                PictureBox3.Tag = 30
                dialogue.Text = "I have something else to do, so I must leave at once." & vbCrLf & "Excuse me."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue46.wm")
            ElseIf MoveAtropos.Tag = 6650 Then
                dialogue.Visible = False
                actor.Top -= 1
                actor.Tag = 1
            ElseIf MoveAtropos.Tag = 6651 Then
                dialogue.Text = "You dare to disobey my command, I will bear down" & vbCrLf & "you."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue47.wm")
            ElseIf MoveAtropos.Tag = 6775 Then
                MoveAtropos.Enabled = False
                Hide()
                Form7.Show()
                Form7.initialization(shield_level, weapon_level, 0, 350 + shield_level*150, 888, 18, 0, 110, 0, 950)
                music.settings.setMode("loop", True)
                music.settings.volume = 100
                music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music8.wm"
            ElseIf MoveAtropos.Tag = 6776 Then
                dialogue.Text = "Not so easy."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue48.wm")
            ElseIf MoveAtropos.Tag = 6850 Then
                MoveAtropos.Enabled = False
                actor.Visible = False
                MsgBox("A key dropped down.")
                GainItem(actor, "witch house key")
                Scene009appears()
            ElseIf MoveAtropos.Tag = 6851 Then
                dialogue.Visible = False
                actor.Image =
                    Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image25.wm")
            ElseIf MoveAtropos.Tag = 6875 Then
                dialogue.Visible = True
                dialogue.ForeColor = Color.Yellow
                dialogue.Text = "Let me have a look."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue49.wm")
            ElseIf MoveAtropos.Tag = 6975 Then
                dialogue.Text = "Oh my god! What the hell of it!"
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue50.wm")
            ElseIf MoveAtropos.Tag = 7100 Then
                dialogue.Text = "It's hellish difficult!!"
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue51.wm")
            ElseIf MoveAtropos.Tag = 7175 Then
                MoveAtropos.Enabled = False
                MsgBox(
                    "Originally that so-called ""pool god"" is the witch! However, now is a good chance to attack the witch.",
                    0, "Attack!")
                Hide()
                Form7.Show()
                DeathFlagNum = 2
                Form7.initialization(shield_level, weapon_level, 0, 350 + shield_level*150, 1400, 19, 100, 110, 1000,
                                     900)
                music.settings.setMode("loop", True)
                music.settings.volume = 100
                music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music10.wm"
                actor.Image =
                    Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image10.wm")
            ElseIf MoveAtropos.Tag = 7176 Then
                DeathFlagNum = 3
                shining.Enabled = True
            ElseIf MoveAtropos.Tag = 7225 Then
                dialogue.ForeColor = Color.Red
                dialogue.Text = "She is just my minimum creation, and she is not" & vbCrLf &
                                "good at math. So you needn't be too happy."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue52.wm")
            ElseIf MoveAtropos.Tag = 7400 Then
                dialogue.Text = "Soon you'll know that the situation of the rooster" & vbCrLf & "will never change."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue53.wm")
            ElseIf MoveAtropos.Tag = 7525 Then
                Unlocked.Items.Add("defeat witch")
                MoveAtropos.Enabled = False
                actor.Visible = False
                Scene009appears()
            ElseIf MoveAtropos.Tag = 7535 Then
                actor.Visible = False
                MoveAtropos.Enabled = False
                Scene054appears()
                AddTip("Disappeared! What's that gem on her?")
            ElseIf MoveAtropos.Tag = 7551 Then
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound39.wm")
                SendMessage("Rooster:" & vbCrLf & "Hello, adventurer. I'm exploring the palace.", 17,
                            "I have something important to tell you.")
                MoveAtropos.Enabled = False
            ElseIf MoveAtropos.Tag = 7552 Then
                dialogue.Visible = True
                dialogue.ForeColor = Color.Red
                dialogue.Text = "He is doomed to death. You cannot change his" & vbCrLf & "destiny."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue54.wm")
            ElseIf MoveAtropos.Tag = 7650 Then
                MoveAtropos.Enabled = False
                actor.Visible = False
                Scene055appears()
            ElseIf MoveAtropos.Tag = 7651 Then
                dialogue.Visible = True
                dialogue.ForeColor = Color.Yellow
                dialogue.Text = "This time you won't be so lucky."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue55.wm")
            ElseIf MoveAtropos.Tag = 7725 Then
                actor.Visible = False
                Scene025appears()
            ElseIf MoveAtropos.Tag = 7775 Then
                music.Ctlcontrols.pause()
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound3.wm")
                Disappear2()
                PictureBox3.Image =
                    Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image28.wm")
                AddTip("You are stunned.")
            ElseIf MoveAtropos.Tag = 7825 Then
                MoveAtropos.Enabled = False
                items.Items.Remove("saw")
                items.Items.Remove("dilute sulfuric acid")
                RefreshItems()
                music.Ctlcontrols.play()
                Scene057appears()
                AddTip("What happened")
            ElseIf MoveAtropos.Tag = 7826 Then
                dialogue.Visible = True
                dialogue.ForeColor = Color.Red
                dialogue.Text = "*scream*"
                actor.Image = Nothing
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue56.wm")
            ElseIf MoveAtropos.Tag = 7875 Then
                MoveAtropos.Enabled = False
                dialogue.Visible = False
                SendMessage("*scream* (seems to come from the palace)", 22,
                            "Probably is Atropos! Rush to Aurora's palace at once!")
            ElseIf MoveAtropos.Tag = 7900 Then
                dialogue.Visible = True
                dialogue.ForeColor = Color.Red
                dialogue.Text = "Look at my new creation. The positive negative cow!"
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue57.wm")
            ElseIf MoveAtropos.Tag = 8025 Then
                dialogue.Text = "Come up, my cow!"
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue58.wm")
            ElseIf MoveAtropos.Tag = 8075 Then
                MoveAtropos.Enabled = False
                dialogue.ForeColor = Color.Yellow
                dialogue.Text = "Click the cow to start battle." & vbCrLf &
                                "(You can use item to suck up negative gas of cow)"
                actor.Image =
                    Image.FromFile(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\battler18.wm")
                If Not mute.Checked Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound35.wm")
                DeathFlagNum = 7
            ElseIf MoveAtropos.Tag = 8076 Then
                dialogue.Visible = True
                dialogue.Text = "I'm Aurora's ghost, I was once thrown to Mr.Duck" & vbCrLf &
                                "function soup by Atropos."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue59.wm")
            ElseIf MoveAtropos.Tag = 8215 Then
                dialogue.Text = "And I cannot solve the function, so I became ghost."
            ElseIf MoveAtropos.Tag = 8315 Then
                dialogue.Text = "I know that Atropos is always hiding behind the" & vbCrLf & "underwater magical door."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue60.wm")
            ElseIf MoveAtropos.Tag = 8440 Then
                dialogue.Text = "The only thing I can give you is the turtle. I hope it" & vbCrLf &
                                "can help you a lot."
            ElseIf MoveAtropos.Tag = 8475 Then
                GainItem(actor, "turtle")
            ElseIf MoveAtropos.Tag = 8530 Then
                dialogue.Text = "If you find the math paper of the final exam," & vbCrLf & "please tell me."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue61.wm")
            ElseIf MoveAtropos.Tag = 8650 Then
                dialogue.Text = "Because I need it to revive."
            ElseIf MoveAtropos.Tag = 8700 Then
                actor.Tag = 1
                actor.Top += 1
                dialogue.Visible = False
            ElseIf MoveAtropos.Tag = 8701 Then
                dialogue.Visible = True
                dialogue.ForeColor = Color.White
                dialogue.Text = "I have been in this waiting for a long time,"
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue62.wm")
            ElseIf MoveAtropos.Tag = 8825 Then
                dialogue.Text = "now it's the time for you to die."
            ElseIf MoveAtropos.Tag = 8950 Then
                Unlocked.Items.Contains("straight defeat witch")
                Hide()
                Form7.Show()
                DeathFlagNum = 0
                Form7.initialization(shield_level, weapon_level, 0, 350 + shield_level*150, 1400, 19, 100, 110, 1000,
                                     900)
                music.settings.setMode("loop", True)
                music.settings.volume = 100
                music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music10.wm"
                actor.Image =
                    Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image10.wm")
            ElseIf MoveAtropos.Tag = 8951 Then
                DeathFlagNum = 3
                shining.Enabled = True
                SaveGame("Chapter4", "underwater magic cave", 8, False)
            ElseIf MoveAtropos.Tag = 8975 Then
                dialogue.ForeColor = Color.Red
                dialogue.Text = "She is just my minimum creation. No matter what" & vbCrLf &
                                "happens, the reality can never be changed."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue63.wm")
            ElseIf MoveAtropos.Tag = 9150 Then
                MoveAtropos.Enabled = False
                actor.Visible = False
                Scene047appears()
            ElseIf MoveAtropos.Tag = 9151 Then
                dialogue.Visible = True
                dialogue.ForeColor = Color.Red
                dialogue.Text = "Welcome to the magical world, and I have something" & vbCrLf & "to tell you."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue64.wm")
            ElseIf MoveAtropos.Tag = 9250 Then
                dialogue.Text = "Look at these stupid mortals. They're always" & vbCrLf &
                                "torturing, slaying each other."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue65.wm")
            ElseIf MoveAtropos.Tag = 9375 Then
                dialogue.Text = "Humans are developing rapidly. But under the" & vbCrLf & "control of their lust,"
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue66.wm")
            ElseIf MoveAtropos.Tag = 9475 Then
                dialogue.Text = "they just get their doom nearer and nearer."
            ElseIf MoveAtropos.Tag = 9550 Then
                dialogue.Text = "Until one day, they will bring destruction on" & vbCrLf & "themselves!"
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue67.wm")
            ElseIf MoveAtropos.Tag = 9675 Then
                dialogue.Text = "I show them the consequence, to prohibit them from" & vbCrLf &
                                "making their stupid destruction."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue68.wm")
            ElseIf MoveAtropos.Tag = 9800 Then
                dialogue.Text = "then they can avoid their annihilation."
            ElseIf MoveAtropos.Tag = 9875 Then
                dialogue.Text = "All these things I did are for human's future." & vbCrLf & "They do not understand."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue69.wm")
            ElseIf MoveAtropos.Tag = 10000 Then
                dialogue.Text = "But after I eat the turkey, it'll be all completed."
            ElseIf MoveAtropos.Tag = 10100 Then
                dialogue.Visible = False
                actor.Image =
                    Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image26.wm")
            ElseIf MoveAtropos.Tag = 10110 Then
                actor.Visible = False
                MoveAtropos.Enabled = False
                Scene063appears()
                AddTip("That gem appeared again!")
            ElseIf MoveAtropos.Tag = 10120 Then
                PictureBox3.Image =
                    Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image33.wm")
            ElseIf MoveAtropos.Tag = 10130 Then
                actor.Top = 0
                actor.Visible = True
                actor.Image =
                    Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image26.wm")
            ElseIf MoveAtropos.Tag = 10140 Then
                actor.Visible = False
            ElseIf MoveAtropos.Tag = 10150 Then
                SetHeight(479, - 1)
                music.Ctlcontrols.stop()
                PictureBox3.Image =
                    Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image34.wm")
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound32.wm")
            ElseIf MoveAtropos.Tag = 10200 Then
                MoveAtropos.Enabled = False
                GameOver("Atropos blew up the whole castle includes you.")
            ElseIf MoveAtropos.Tag = 10201 Then
                dialogue.Visible = True
                dialogue.ForeColor = Color.Red
                dialogue.BackColor = Color.Yellow
                dialogue.Text = "In reality, do not imitate."
            ElseIf MoveAtropos.Tag = 10250 Then
                actor.Visible = False
                dialogue.BackColor = Color.Transparent
                MoveAtropos.Enabled = False
            ElseIf MoveAtropos.Tag = 10251 Then
                dialogue.Visible = True
                dialogue.ForeColor = Color.Black
                dialogue.Text = "Thank you. Now I can remove the functions from my" & vbCrLf & "body."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue70.wm")
            ElseIf MoveAtropos.Tag = 10350 Then
                dialogue.Text = ""
                actor.Image =
                    Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image35.wm")
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound19.wm")
            ElseIf MoveAtropos.Tag = 10375 Then
                dialogue.Text = "Because of Atropos's power, I can not revive."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue71.wm")
            ElseIf MoveAtropos.Tag = 10450 Then
                dialogue.Text = "In return, I can only give you the ink cartridge."
            ElseIf MoveAtropos.Tag = 10500 Then
                GainItem(actor, "ink cartridge")
            ElseIf MoveAtropos.Tag = 10525 Then
                dialogue.Text = "Thank you for your help. I hope there will be the day" & vbCrLf &
                                "when we destroy Atropos."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue72.wm")
            ElseIf MoveAtropos.Tag = 10625 Then
                actor.Tag = 1
                actor.Top += 1
                dialogue.Visible = False
            ElseIf MoveAtropos.Tag = 10626 Then
                dialogue.Visible = True
                dialogue.ForeColor = Color.Black
                dialogue.Text = "Why do you come to my temple..."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue74.wm")
            ElseIf MoveAtropos.Tag = 10710 Then
                dialogue.Text = "I will change you to a big rock."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue75.wm")
            ElseIf MoveAtropos.Tag = 10800 Then
                dialogue.Text = "Look at my eyes."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue76.wm")
            ElseIf MoveAtropos.Tag = 10875 Then
                DeathFlagNum = 12
                dialogue.Text = ""
                actor.Image =
                    Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image37.wm")
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound25.wm")
            ElseIf MoveAtropos.Tag = 10975 Then
                SetHeight(479, - 1)
                music.Ctlcontrols.stop()
                actor.Image = Nothing
                DeathFlagNum = 0
                PictureBox3.Image =
                    Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image28.wm")
            ElseIf MoveAtropos.Tag = 11000 Then
                dialogue.ForeColor = Color.White
                dialogue.Text = "That is so great."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue78.wm")
            ElseIf MoveAtropos.Tag = 11050 Then
                MoveAtropos.Enabled = False
                GameOver("You are petrified.")
            ElseIf MoveAtropos.Tag = 11075 Then
                dialogue.Text = "Oh, no! *gegegegegege*"
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue77.wm")
            ElseIf MoveAtropos.Tag = 11150 Then
                dialogue.Visible = False
                actor.Image =
                    Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image38.wm")
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound34.wm")
            ElseIf MoveAtropos.Tag = 11175 Then
                actor.Tag = 1
                actor.Top += 1
            ElseIf MoveAtropos.Tag = 11176 Then
                dialogue.Visible = True
                dialogue.ForeColor = Color.Red
                music.settings.volume = 50
                dialogue.Text = "Finally, you reached here. Now let's start our final" & vbCrLf & "battle."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue79.wm")
            ElseIf MoveAtropos.Tag = 11310 Then '√
                dialogue.Text = "These mortals're making fallacies one by one." & vbCrLf &
                                "Their insistences are completely wrong."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue80.wm")
            ElseIf MoveAtropos.Tag = 11485 Then '√
                dialogue.Text = "And the effect will be the opposite."
            ElseIf MoveAtropos.Tag = 11550 Then '√
                dialogue.Text = "Their lust drives them to seek for their happiness." & vbCrLf &
                                "But what means their happiness?"
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue81.wm")
            ElseIf MoveAtropos.Tag = 11705 Then '√
                dialogue.Text = "At last what did they get?? You know them all."
            ElseIf MoveAtropos.Tag = 11800 Then '√
                dialogue.Text = "They'll never get their happiness until they clear up" & vbCrLf & "their lust."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue82.wm")
            ElseIf MoveAtropos.Tag = 11915 Then '√
                dialogue.Text = "Their persuit of happiness are all illusive. Their" & vbCrLf &
                                "opinions are distorted."
            ElseIf MoveAtropos.Tag = 12050 Then '√
                dialogue.Text = "These mortals're really mournful. Because their" & vbCrLf &
                                "absurd persuit of happiness will only bring sadness..."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue83.wm")
            ElseIf MoveAtropos.Tag = 12270 Then '√
                dialogue.Text = "You know all these facts, because you're also one" & vbCrLf & "of these mortals."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue84.wm")
            ElseIf MoveAtropos.Tag = 12395 Then '√
                dialogue.Text = "And their tragedies are always happening around" & vbCrLf & "you."
            ElseIf MoveAtropos.Tag = 12480 Then '√
                dialogue.Text = "But you don't think them stupid. Because you're" & vbCrLf &
                                "cheated. Now you're stupid too."
            ElseIf MoveAtropos.Tag = 12630 Then '√
                dialogue.Text = "You now intruded into my Destiny Temple. So I" & vbCrLf & "must destroy you."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue85.wm")
            ElseIf MoveAtropos.Tag = 12790 Then '√
                timebar.Value = 0
                timebar.Maximum = 150
                timebar.Visible = True
                dialogue.Visible = False
                actor.Image =
                    Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image39.wm")
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound34.wm")
            ElseIf MoveAtropos.Tag > 12790 And MoveAtropos.Tag < 12940 Then '√
                timebar.Value += 1
            ElseIf MoveAtropos.Tag = 12940 Then '√
                SetHeight(479, - 1)
                music.Ctlcontrols.stop()
                timebar.Visible = False
                actor.Visible = False
                PictureBox3.Image =
                    Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image28.wm")
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound55.wm")
            ElseIf MoveAtropos.Tag = 12990 Then '√
                MoveAtropos.Enabled = False
                GameOver("You're destroyed by Atropos.")
            ElseIf MoveAtropos.Tag = 12991 Then '√
                actor.Image =
                    Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image2.wm")
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound62.wm")
            ElseIf MoveAtropos.Tag = 13000 Then '√
                dialogue.Visible = True
                dialogue.ForeColor = Color.Red
                music.settings.volume = 50
                timebar.Visible = False
                dialogue.Visible = True
                dialogue.Text = "What! You find the artifact!" & vbCrLf &
                                "But I don't believe that you can get a good result-"
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue86.wm")
            ElseIf MoveAtropos.Tag = 13145 Then '√
                dialogue.Text = "like two papers used to activate the artifact."
            ElseIf MoveAtropos.Tag = 13245 Then '√
                dialogue.Text = "I'll check your result on the Internet, then you have" & vbCrLf &
                                "no way to cheat me anymore."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue87.wm")
            ElseIf MoveAtropos.Tag = 13380 Then '√
                dialogue.Visible = False
                timebar.Value = 0
                timebar.Maximum = 100
                timebar.Visible = True
                actor.Image =
                    Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image40.wm")
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound57.wm")
            ElseIf MoveAtropos.Tag > 13380 And MoveAtropos.Tag < 13480 Then '√
                timebar.Value += 1
            ElseIf MoveAtropos.Tag = 13480 Then '√
                timebar.Visible = False
                dialogue.Visible = True
                actor.Image =
                    Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image2.wm")
                If Unlocked.Items.Contains("freeze score") Then
                    dialogue.Text = "Oh no, your account is frozen! But it doesn't" & vbCrLf & "matter."
                    If mute.Checked = False Then _
                        My.Computer.Audio.Play(
                            My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue90.wm")
                Else
                    dialogue.Text = "Your result is false! You originally had gotten" & vbCrLf &
                                    "flunked. The artifact is useless now."
                    If mute.Checked = False Then _
                        My.Computer.Audio.Play(
                            My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue88.wm")
                End If
            ElseIf MoveAtropos.Tag = 13635 And Unlocked.Items.Contains("freeze score") = False Then '√
                dialogue.Visible = False
                actor.Image =
                    Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image41.wm")
            ElseIf MoveAtropos.Tag = 13660 And Unlocked.Items.Contains("freeze score") = False Then '√
                actor.Image =
                    Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image42.wm")
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound62.wm")
            ElseIf MoveAtropos.Tag = 13705 And Unlocked.Items.Contains("freeze score") = False Then '√
                actor.Image =
                    Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image2.wm")
            ElseIf MoveAtropos.Tag = 13710 And Unlocked.Items.Contains("freeze score") = False Then '√
                MoveAtropos.Tag = 12789
            ElseIf MoveAtropos.Tag = 13600 And Unlocked.Items.Contains("freeze score") Then '√
                dialogue.Text = "I'll give you a sum to let you solve, of course you" & vbCrLf & "can not do it."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue91.wm")
            ElseIf MoveAtropos.Tag = 13710 And Unlocked.Items.Contains("freeze score") Then '√
                dialogue.Text = "Then your stupid artifact will become useless."
            ElseIf MoveAtropos.Tag = 13790 Then '√
                dialogue.Visible = True
                dialogue.ForeColor = Color.Red
                dialogue.Text = "Here is it. Solve it in one minute! it's the duck" & vbCrLf &
                                "function. How can you solve it?"
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue92.wm")
            ElseIf MoveAtropos.Tag = 13960 Then '√
                dialogue.Text = "Your failure is doomed."
            ElseIf MoveAtropos.Tag = 14010 Then
                dialogue.Visible = False
                GroupBox4.Size = New Size(488, 370)
                GroupBox4.Location = New Point((PictureBox3.Left + PictureBox3.Width - GroupBox4.Width)/2,
                                               (PictureBox3.Top + PictureBox3.Height - GroupBox4.Height)/2)
                answertext.Text = "01:00"
                answertext.Visible = True
                answerbox.Visible = True
                answerworm.Visible = False
                answerbutton.Enabled = False
                answerbox.Clear()
                GroupBox4.Visible = True
                answertime.Value = 0
                answertime.Maximum = 1200
            ElseIf MoveAtropos.Tag > 14010 And MoveAtropos.Tag < 15210 Then '√
                answertime.Value += 1
                Dim temp As Integer = 60 - answertime.Value*0.05
                answertext.Text = ChangeToTime(temp)
            ElseIf MoveAtropos.Tag = 15210 Then '√
                GroupBox4.Visible = False
                dialogue.Visible = True
                dialogue.Text = "You can't solve it! So your exam paper is false." & vbCrLf &
                                "Your artifact loses its effect!"
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue93.wm")
            ElseIf MoveAtropos.Tag = 15400 Then ' resume
                Unlocked.Items.Remove("freeze score")
                MoveAtropos.Tag = 13634
            ElseIf MoveAtropos.Tag = 15401 Then
                dialogue.Visible = True
                dialogue.Text = "Not so easy, let's resume. Solve this physics problem." & vbCrLf &
                                "These problems are all on your exam paper,"
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue100.wm")
            ElseIf MoveAtropos.Tag = 15625 Then
                dialogue.Text = "as long as you can not solve one of them, your" & vbCrLf &
                                "artifact will lose its effect."
            ElseIf MoveAtropos.Tag = 15775 Then
                dialogue.Visible = False
                Physics.Size = New Size(488, 400)
                Physics.Location = New Point(38, 22)
                Physics.Visible = True
                Physicsanswertext.Visible = True
                Physicsanswertime.Maximum = 2400
                PhysicsGround.Top = 383
                OneMeterPx = (PhysicsGround.Bottom - PhysicsUpperground.Top)/78.4
            ElseIf MoveAtropos.Tag > 15775 And MoveAtropos.Tag < 18175 Then '√
                Physicsanswertime.Value += 1
                Dim temp As Integer = 120 - Physicsanswertime.Value*0.05
                Physicsanswertext.Text = ChangeToTime(temp)
            ElseIf MoveAtropos.Tag = 18175 Then '√
                Physics.Visible = False
                MoveAtropos.Tag = 15209
            ElseIf MoveAtropos.Tag = 18200 Then '√
                dialogue.Visible = True
                dialogue.Text = "It seems your preparation is enough. But the next" & vbCrLf &
                                "problem surely will defeat you,"
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue101.wm")
            ElseIf MoveAtropos.Tag = 18350 Then '√
                dialogue.Text = "and turn your stupid artifact to sheet iron."
            ElseIf MoveAtropos.Tag = 18475 Then '√
                dialogue.Visible = False
                physics2.Size = New Size(488, 440)
                physics2.Location = New Point(38, 0)
                physics2.Visible = True
                Physics2answertext.Visible = True
                Physics2answertime.Maximum = 6000
                OneMeterPx = (Physics2Ground.Bottom - PhysicsTemp1.Top)/66.67
            ElseIf MoveAtropos.Tag > 18475 And MoveAtropos.Tag < 24475 Then '√
                Physics2answertime.Value += 1
                Dim temp As Integer = 300 - Physics2answertime.Value*0.05
                Physics2answertext.Text = ChangeToTime(temp)
            ElseIf MoveAtropos.Tag = 24475 Then '√
                physics2.Visible = False
                MoveAtropos.Tag = 15209
            ElseIf MoveAtropos.Tag = 24476 Then '√
                dialogue.Visible = True
                dialogue.Text = "You can solve it, but I don't matter! Because I have" & vbCrLf & "Mr.Duck!"
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue94.wm")
            ElseIf MoveAtropos.Tag = 24600 Then '√
                dialogue.Text = "Come out, my creation. Mr.Duck phantom!"
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue95.wm")
            ElseIf MoveAtropos.Tag = 24725 Then
                dialogue.Visible = False
                actor.Image =
                    Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image44.wm")
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound28.wm")
            ElseIf MoveAtropos.Tag = 24775 Then '√
                dialogue.Visible = False
                MoveAtropos.Enabled = False
                If items.Items.Contains("duck vector launcher") Then
                    items.Items.Remove("duck vector launcher")
                    RefreshItems()
                    If mute.Checked = False Then _
                        My.Computer.Audio.Play(
                            My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound60.wm")
                    actor.Image =
                        Image.FromFile(
                            My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image45.wm")
                    AddTip("Suddenly, the duck vector arrow shoots out and hit the phantom.", True)
                    DeathFlagNum = 14
                    shining.Enabled = True
                    MoveAtropos.Tag = 24915
                    MoveAtropos.Enabled = False
                    GainItem(actor, "Mr.Duck card")
                Else
                    Hide()
                    Form7.Show()
                    Form7.initialization(shield_level, weapon_level, 0, 350 + shield_level*150, 775, 22, 150, 110, 1000,
                                         950)
                    music.settings.setMode("loop", True)
                    music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music8.wm"
                End If
            ElseIf MoveAtropos.Tag = 24776 Then '√
                DeathFlagNum = 13
                shining.Enabled = True
                MoveAtropos.Enabled = False
            ElseIf MoveAtropos.Tag = 24777 Then '√
                actor.Image =
                    Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image2.wm")
                dialogue.Visible = True
                dialogue.Text = "You defeated my phantom, so you think it's great?" & vbCrLf & "Not at all!"
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue97.wm")
            ElseIf MoveAtropos.Tag = 24915 Then '√
                MoveAtropos.Tag = 25034
            ElseIf MoveAtropos.Tag = 24916 Then '√
                actor.Image =
                    Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image2.wm")
                dialogue.Visible = True
                dialogue.Text = "Oops!! *gegegegeggee* There is no matter."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue96.wm")
            ElseIf MoveAtropos.Tag = 25035 Then '√
                dialogue.Text = "Now it's the time for us to start our final battle."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue98.wm")
            ElseIf MoveAtropos.Tag = 25185 Then '√
                MoveAtropos.Enabled = False
                Form19.Show()
                Hide()
            ElseIf MoveAtropos.Tag = 25186 Then '√
                dialogue.Visible = True
                dialogue.ForeColor = Color.Red
                dialogue.Text = "I must admit my defeat, but you also lost."
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue99.wm")
            ElseIf MoveAtropos.Tag = 25325 Then '√
                MoveAtropos.Enabled = False
                Hide()
                Form20.Show()
                Form20.SceneAppears(- 1)
                Form20.ShowCutscene(0, False)
                If items.Items.Contains("witch's book") Then Form20.Items.Items.add("witch's book")
                Form20.refresh_item()
            End If
        ElseIf actor.Tag = 1 Then
            actor.Top += 5*MoveSpeed
            If actor.Top >= Height Then
                actor.Tag = 0
                actor.Visible = False
                MoveAtropos.Enabled = False
                MoveSpeed = 1
                If MoveAtropos.Tag = 880 Then
                    Scene002appears()
                    AddTip("Who Is her? Why did she know all Of these??", True)
                ElseIf MoveAtropos.Tag = 7551 Then
                    MoveAtropos.Enabled = True
                ElseIf ResponseCode = 4 Then
                    Scene009appears()
                    AddTip("The palace Is In danger! Find the solar fire first, Then Get inside.", True)
                ElseIf MoveAtropos.Tag = 6650 Then
                    Scene010appears()
                ElseIf MoveAtropos.Tag = 8700 Then
                    MoveAtropos.Enabled = False
                    Scene061appears()
                ElseIf DeathFlagNum = 6 Then
                    DeathFlagNum = 0
                    MoveAtropos.Enabled = False
                    Exit Sub
                ElseIf PictureBox3.Tag = 28 Then
                    Scene041appears()
                ElseIf PictureBox3.Tag = 33 Then
                    Scene008appears()
                ElseIf PictureBox3.Tag = 35 Then
                    actor.Visible = True
                    actor.Image = Nothing
                    actor.Top = 0
                    dialogue.Visible = False
                ElseIf MoveAtropos.Tag = 10625 Then
                    actor.Tag = 1
                    actor.Image = Nothing
                    actor.Top = 1
                    actor.Visible = True
                    dialogue.Visible = True
                    MoveAtropos.Tag += 1
                    dialogue.ForeColor = Color.Red
                    dialogue.Text = "No that day."
                    If mute.Checked = False Then _
                        My.Computer.Audio.Play(
                            My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue73.wm")
                    MoveAtropos.Enabled = True
                ElseIf MoveAtropos.Tag = 11175 Then
                    actor.Visible = False
                    MoveAtropos.Enabled = False
                    Scene080appears()
                End If
            ElseIf MoveAtropos.Tag > 10625 And MoveAtropos.Tag < 10675 Then
                actor.Tag = 1
                actor.Top = 1
                MoveAtropos.Tag += 1
            ElseIf MoveAtropos.Tag = 10675 Then
                actor.Visible = False
                Scene061appears()
                MoveAtropos.Enabled = False
            End If
        Else
            actor.Top -= 5*MoveSpeed
            If actor.Top > 0 And actor.Top < 5*MoveSpeed Then actor.Top = 0
        End If
    End Sub

    Public Function ChangeToTime(number As Integer)
        Dim minute As Integer = Int(number/60)
        Dim second As Integer = number Mod 60
        Return minute.ToString.PadLeft(2, "0") & ":" & second.ToString.PadLeft(2, "0")
    End Function

    Public Sub RefreshItems()
        deselect()
        right_.Enabled = True
        If item1.Tag.ToString.Split("/")(0) = 0 Then
            left_.Enabled = False
        Else
            left_.Enabled = True
        End If

        For x = 0 To 4
            ItemBox(x).BackColor = Color.White
            Dim step__ As Integer = - 1
            For x2 As Integer = item1.Tag.ToString.Split("/")(0) To item1.Tag.ToString.Split("/")(0) + 4
                step__ += 1
                If step__ = x Then
                    If items.Items.Count - 1 < x2 Then
                        ItemBox(x).Image = Nothing
                        ToolTip1.SetToolTip(ItemBox(x), Nothing)
                        right_.Enabled = False
                        ItemBox(x).Tag = ItemBox(x).Tag.ToString.Split("/")(0) & "/" & "Null"
                    Else
                        ItemBox(x).Image = ImageList1.Images(GetPictureCode(items.Items(x2)))
                        ToolTip1.SetToolTip(ItemBox(x), items.Items(x2))
                        ItemBox(x).Tag = ItemBox(x).Tag.ToString.Split("/")(0) & "/" & items.Items(x2)
                    End If
                End If
            Next
        Next
    End Sub

    Private Function GetPictureCode(Name_ As String)
        If Name_ = "witch's book" Then
            Return 0
        ElseIf Name_ = "torch without fire" Then
            Return 1
        ElseIf Name_ = "torch" Then
            Return 2
        ElseIf Name_ = "Medusa temple's key" Then
            Return 3
        ElseIf Name_ = "turkey coin" Then
            Return 5
        ElseIf Name_ = "Mr.Duck ticket" Then
            Return 6
        ElseIf Name_ = "chemistry test paper" Then
            Return 7
        ElseIf Name_ = "battery" Then
            Return 8
        ElseIf Name_ = "palace key" Then
            Return 9
        ElseIf Name_ = "scissors" Then
            Return 10
        ElseIf Name_ = "laughing worm" Then
            Return 11
        ElseIf Name_ = "physics test paper" Then
            Return 12
        ElseIf Name_ = "carbolic stick" Then
            Return 13
        ElseIf Name_ = "chicken blood" Then
            Return 14
        ElseIf Name_ = "red stick" Then
            Return 15
        ElseIf Name_ = "physics test paper (passed)" Then
            Return 16
        ElseIf Name_ = "chemistry test paper (passed)" Then
            Return 17
        ElseIf Name_ = "solar shell" Then
            Return 18
        ElseIf Name_ = "hydrochloric acid" Then
            Return 19
        ElseIf Name_ = "manganese dioxide" Then
            Return 20
        ElseIf Name_ = "liquefied chlorine" Then
            Return 21
        ElseIf Name_ = "solar ball" Then
            Return 22
        ElseIf Name_ = "orange key" Then
            Return 23
        ElseIf Name_ = "chlorine" Then
            Return 24
        ElseIf Name_ = "skull" Then
            Return 25
        ElseIf Name_ = "magic dispeller" Then
            Return 26
        ElseIf Name_ = "bottle" Then
            Return 27
        ElseIf Name_ = "aqua regia" Then
            Return 28
        ElseIf Name_ = "portable submarine" Then
            Return 29
        ElseIf Name_ = "Aurora music room key" Then
            Return 30
        ElseIf Name_ = "mathematics workbook" Then
            Return 31
        ElseIf Name_ = "MP3 player" Then
            Return 32
        ElseIf Name_ = "duck pool water" Then
            Return 33
        ElseIf Name_ = "dilute sulfuric acid" Then
            Return 34
        ElseIf Name_ = "saw" Then
            Return 35
        ElseIf Name_ = "underwater cave key" Then
            Return 36
        ElseIf Name_ = "golden apple" Then
            Return 37
        ElseIf Name_ = "chicken" Then
            Return 38
        ElseIf Name_ = "witch house key" Then
            Return 39
        ElseIf Name_ = "shrinking potion" Then
            Return 40
        ElseIf Name_ = "Mr.Duck standard answer" Then
            Return 41
        ElseIf Name_ = "SixGod SD card" Then
            Return 42
        ElseIf Name_ = "MP3 player with SixGod" Then
            Return 43
        ElseIf Name_ = "constant a" Then
            If Unlocked.Items.Contains("a=-2") Then Return 44
            If Unlocked.Items.Contains("a=-1") Then Return 45
            If Unlocked.Items.Contains("a=0") Then Return 46
            If Unlocked.Items.Contains("a=1") Then Return 47
        ElseIf Name_ = "bow" Then
            Return 48
        ElseIf Name_ = "Mr.Duck vector" Then
            Return 49
        ElseIf Name_ = "duck vector launcher" Then
            Return 50
        ElseIf Name_ = "access card of Aurora's room" Then
            Return 51
        ElseIf Name_ = "paper box" Then
            Return 52
        ElseIf Name_ = "sodium hydroxide" Then
            Return 53
        ElseIf Name_ = "magical colloid" Then
            Return 54
        ElseIf Name_ = "turtle" Then
            Return 55
        ElseIf Name_ = "liquid nitrogen" Then
            Return 56
        ElseIf Name_ = "underwater magical key" Then
            Return 57
        ElseIf Name_ = "static card" Then
            Return 59
        ElseIf Name_ = "screwdriver" Then
            Return 60
        ElseIf Name_ = "hydrofluoric acid" Then
            Return 61
        ElseIf Name_ = "paper" Then
            Return 62
        ElseIf Name_ = "final examination paper" Then
            Return 63
        ElseIf Name_ = "eraser" Then
            Return 64
        ElseIf Name_ = "palette" Then
            Return 65
        ElseIf Name_ = "painting tool" Then
            Return 66
        ElseIf Name_ = "duck function" Then
            Return 67
        ElseIf Name_ = "Aurora's password" Then
            Return 68
        ElseIf Name_ = "ink cartridge" Then
            Return 69
        ElseIf Name_ = "package" Then
            Return 70
        ElseIf Name_ = "USB" Then
            Return 72
        ElseIf Name_ = "mirror" Then
            Return 74
        ElseIf Name_ = "portable trailer" Then
            Return 75
        ElseIf Name_ = "trailer with mirror" Then
            Return 76
        ElseIf Name_ = "ladder" Then
            Return 77
        ElseIf Name_ = "XuTianhao artifact -2" Then
            Return 78
        ElseIf Name_ = "XuTianhao artifact -1" Then
            Return 79
        ElseIf Name_ = "XuTianhao artifact" Then
            Return 80
        ElseIf Name_ = "Mr.Duck card" Then
            Return 81
        ElseIf Name_ = "mirror card" Then
            Return 82
        Else
            Return Nothing
        End If
    End Function

    Private Sub left__Click(sender As Object, e As EventArgs) Handles left_.Click
        If Not Enable() Then Exit Sub
        item1.Tag = item1.Tag.ToString.Split("/")(0) - 1 & "/" & item1.Tag.ToString.Split("/")(1)
        RefreshItems()
    End Sub

    Private Sub item1_Click(sender As Object, e As EventArgs) Handles item1.Click
        If Enable() = False Then Exit Sub
        If MixThings(item1) Then Exit Sub
        deselect()
        If Not item1.Tag.ToString.Split("/")(1) = "Null" Then
            item1.BackColor = Color.Yellow
            leftmove.Visible = True
            rightmove.Visible = True
        End If
    End Sub

    Private Sub item2_Click(sender As Object, e As EventArgs) Handles item2.Click
        If Enable() = False Then Exit Sub
        If MixThings(item2) Then Exit Sub
        deselect()
        If Not item2.Tag.ToString.Split("/")(1) = "Null" Then
            item2.BackColor = Color.Yellow
            leftmove.Visible = True
            rightmove.Visible = True
        End If
    End Sub

    Private Sub item3_Click(sender As Object, e As EventArgs) Handles item3.Click
        If Enable() = False Then Exit Sub
        If MixThings(item3) Then Exit Sub
        deselect()
        If Not item3.Tag.ToString.Split("/")(1) = "Null" Then
            item3.BackColor = Color.Yellow
            leftmove.Visible = True
            rightmove.Visible = True
        End If
    End Sub

    Private Sub deselect()
        For i = 0 To 4
            ItemBox(i).BackColor = Color.White
        Next
        leftmove.Visible = False
        rightmove.Visible = False
    End Sub

    Private Sub item4_Click(sender As Object, e As EventArgs) Handles item4.Click
        If Enable() = False Then Exit Sub
        If MixThings(item4) Then Exit Sub
        deselect()
        If Not item4.Tag.ToString.Split("/")(1) = "Null" Then
            item4.BackColor = Color.Yellow
            leftmove.Visible = True
            rightmove.Visible = True
        End If
    End Sub

    Private Sub item5_Click(sender As Object, e As EventArgs) Handles item5.Click
        If Enable() = False Then Exit Sub
        If MixThings(item5) Then Exit Sub
        deselect()
        If Not item5.Tag.ToString.Split("/")(1) = "Null" Then
            item5.BackColor = Color.Yellow
            leftmove.Visible = True
            rightmove.Visible = True
        End If
    End Sub

    Private Sub right__Click(sender As Object, e As EventArgs) Handles right_.Click
        If Not Enable() Then Exit Sub
        item1.Tag = item1.Tag.ToString.Split("/")(0) + 1 & "/" & item1.Tag.ToString.Split("/")(1)
        RefreshItems()
    End Sub

    Private Sub place28_2_Click(sender As Object, e As EventArgs) Handles place28_2.Click
        If Not Enable() Then Exit Sub
        Scene004appears()
    End Sub

    Private Sub place28_3_Click(sender As Object, e As EventArgs) Handles place28_3.Click
        If Not Enable() Then Exit Sub
        Scene005appears()
    End Sub

    Private Sub place30_2_Click(sender As Object, e As EventArgs) Handles place30_2.Click
        If Not Enable() Then Exit Sub
        If backward.Tag = 54 And backward.Visible Then
            If warning54_2.Visible = False Then
                Scene033appears()
                If PictureBox3.Tag = 16 Then
                    PictureBox3.Tag = 17
                    Disappear2()
                    actor.Visible = True
                    dialogue.Visible = True
                    MoveAtropos.Enabled = True
                ElseIf PictureBox3.Tag = 22 Then
                    PictureBox3.Tag = 23
                    actor.Visible = True
                    actor.Top = 0
                    actor.Image = Nothing
                    dialogue.Visible = True
                    dialogue.Text = ""
                    dialogue.ForeColor = Color.Red
                    Disappear2()
                    MoveAtropos.Enabled = True
                End If
            Else
                If SelectedItemIs("magic dispeller") Then
                    UseItem(warning54_2, 15)
                ElseIf SelectedItemIs() Then
                    deselect()
                    AddTip("Not this.")
                Else
                    AddTip("There is too foggy.")
                End If
            End If
        ElseIf backward.Visible And backward.Tag = 62 Then
            If lock62_2.Visible Then
                If SelectedItemIs("access card of Aurora's room") Then
                    UseItem(lock62_2, 36)
                Else
                    AddTip("An electric force resists you from getting inside.")
                End If
            Else
                Scene060appears()
            End If
        ElseIf backward.Visible And backward.Tag = 90 Then
            Scene066appears()
        Else
            If Unlocked.Items.Contains("warning30_1") Then
                Scene012appears()
            Else
                If SelectedItemIs("scissors") Then
                    UseItem(warning30_1, 5)
                ElseIf SelectedItemIs("torch") Then
                    deselect()
                    AddTip("We cannot burn it, we cannot predict the consequence.")
                ElseIf SelectedItemIs() Then
                    deselect()
                    AddTip("This cannot cut the thorns.")
                Else
                    AddTip("You cannot straight pass through these spiky thorns.")
                End If
            End If
        End If
    End Sub

    Private Sub box28_1_Click(sender As Object, e As EventArgs) Handles box28_1.Click
        If Not Enable() Then Exit Sub
        If MsgBox("Do you want to open the box?", vbYesNo, "Component") = vbYes Then
            AddTip("You opened the box and get a torch without fire.")
            GainItem(box28_1, "torch without fire")
            Unlocked.Items.Add("box28_1")
            box28_1.Visible = False
            RefreshItems()
        End If
    End Sub

    Friend Sub RemoveOut(thing As Control)
        thing.Visible = False
        Unlocked.Items.Add(thing.Name)
    End Sub

    Private Function SelectedItemIs(Optional ByVal itemname As String = "Default")
        Dim Selected = False
        Dim SelectedItem_ As PictureBox
        For i = 0 To 4
            If ItemBox(i).BackColor = Color.Yellow Then
                Selected = True
                SelectedItem_ = ItemBox(i)
            End If
        Next
        If Selected = False Then
            Return False
        Else
            If itemname = "Default" Then Return True
            If SelectedItem_.Tag.ToString.Split("/")(1) = itemname Then
                Return True
            Else
                Return False
            End If
        End If
    End Function

    Private Sub UseItem(target As Control, code As Integer)
        Dim Selected = False
        Dim SelectedItem_ As PictureBox
        For i = 0 To 4
            If ItemBox(i).BackColor = Color.Yellow Then
                Selected = True
                SelectedItem_ = ItemBox(i)
            End If
        Next
        If Selected Then
            MoveTarget = target
            MovingItem.SizeMode = PictureBoxSizeMode.Zoom
            MovingItem.Size = New Size(item1.Width, item1.Height)
            MovingItem.Location = New Point(SelectedItem_.Left + itemlist.Left, SelectedItem_.Top + itemlist.Top)
            MovingItem.BorderStyle = BorderStyle.FixedSingle
            MovingItem.BackColor = Color.Yellow
            MovingItem.Image = SelectedItem_.Image
            items.Items.Remove(SelectedItem_.Tag.ToString.Split("/")(1))
            RefreshItems()
            MovingItem.Visible = True
            MovingItem.Tag = "Use"
            Controls.Add(MovingItem)
            MovingItem.BringToFront()
            MoveItem.Enabled = True
            MoveItem.Tag = 0
            UseItemCode = code
        End If
    End Sub

    Private Sub MoveItem_Tick(sender As Object, e As EventArgs) Handles MoveItem.Tick
        If MoveItem.Tag = 0 Then
            Dim ToLeft As Integer = MoveTarget.Left + MoveTarget.Width/2 - MovingItem.Width/2
            Dim ToTop As Integer = MoveTarget.Top + MoveTarget.Height/2 - MovingItem.Height/2
            If Not MovingItem.Tag = "Use" Then
                ToLeft = MoveTarget.Left + itemlist.Left + MoveTarget.Width/2 - MovingItem.Width/2
                ToTop = MoveTarget.Top + itemlist.Top + MoveTarget.Height/2 - MovingItem.Height/2
            End If
            Dim MoveLeft As Integer = ToLeft - MovingItem.Left
            Dim MoveTop As Integer = ToTop - MovingItem.Top
            Dim hypotenuse As Integer = Math.Pow(Math.Pow(MoveLeft, 2) + Math.Pow(MoveTop, 2), 0.5)
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
            If (MoveTop > - 10 And MoveTop < 10) And (MoveLeft > - 10 And MoveLeft < 10) Then
                MoveItem.Tag = 1
                If MovingItem.Tag = "Gain" Then
                    MoveItem.Enabled = False
                    MovingItem.Visible = False
                    Controls.Remove(MovingItem)
                    items.Items.Add(AddItemName)
                    RefreshItems()
                ElseIf Not MovingItem.Tag = "Use" Then
                    MoveItem.Enabled = False
                    MovingItem.Visible = False
                    Controls.Remove(MovingItem)
                    items.Items.Add(MovingItem.Tag)
                    RefreshItems()
                    If MP3mixture Then
                        MP3mixture = False
                        Unable = False
                        dialogue.ForeColor = Color.Blue
                        actor.Top = Height
                        MoveSpeed = 3
                        dialogue.Text = "Use the MP3 SixGod player on the mermaid."
                        actor.Image =
                            Image.FromFile(
                                My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image22.wm")
                        DeathFlagNum = 5
                        actor.Visible = True
                        dialogue.Visible = True
                        actor.Tag = 0
                        MoveAtropos.Enabled = True
                    End If
                End If
            End If
        ElseIf MoveItem.Tag = 1 Then
            MovingItem.Width -= 2
            MovingItem.Height -= 2
            MovingItem.Left = MoveTarget.Left + MoveTarget.Width/2 - MovingItem.Width/2
            MovingItem.Top = MoveTarget.Top + MoveTarget.Height/2 - MovingItem.Height/2
            If MovingItem.Width < 2 Or MovingItem.Height < 2 Then
                MoveItem.Enabled = False
                MovingItem.Visible = False
                Controls.Remove(MovingItem)
                Affect(UseItemCode)
            End If
        Else
            MovingItem.Width += 2
            MovingItem.Height += 2
            MovingItem.Left = MoveSource.Left + MoveSource.Width/2 - MovingItem.Width/2
            MovingItem.Top = MoveSource.Top + MoveSource.Height/2 - MovingItem.Height/2
            If MovingItem.Width > item1.Width - 2 Or MovingItem.Height > item1.Height - 2 Then MoveItem.Tag = 0
        End If
    End Sub

    Private Function Enable()
        Dim enable_ = True
        If MovingItem.Visible = True Then enable_ = False
        If shining.Enabled = True Then enable_ = False
        If Unable Then enable_ = False
        Return enable_
    End Function

    Friend Sub GainItem(source As Control, itemname As String)
        MoveSource = source
        MovingItem.SizeMode = PictureBoxSizeMode.Zoom
        MovingItem.Size = New Size(0, 0)
        MovingItem.Location = New Point(source.Left + MovingItem.Width, source.Top + MovingItem.Height)
        MovingItem.BorderStyle = BorderStyle.FixedSingle
        MovingItem.BackColor = Color.White
        MovingItem.Image = ImageList1.Images(GetPictureCode(itemname))
        MovingItem.Visible = True
        MovingItem.Tag = "Gain"
        Controls.Add(MovingItem)
        MovingItem.BringToFront()
        For x = 4 To 0 Step - 1
            If x = 4 Or ItemBox(x).Tag.ToString.Split("/")(1) = "Null" Then MoveTarget = ItemBox(x)
        Next
        MoveItem.Tag = 2
        MoveItem.Enabled = True
        AddItemName = itemname
    End Sub

    Private Sub Affect(code As Integer)
        If code = 0 Then
            GainItem(fire30_2, "torch")
            AddTip("You burned the torch.")
            If Not mute.Checked Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound10.wm")
        ElseIf code = 1 Then
            RemoveOut(lock27_1)
            RemoveOut(place27_2)
            AddTip("The rocket is launched out and it destroyed the gate of Aurora palace.", True)
            If Not mute.Checked Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound32.wm")
        ElseIf code = 2 Then
            RemoveOut(lock26_1)
            AddTip("The door of Medusa temple is unlocked.")
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound48.wm")
        ElseIf code = 3 Then
            GainItem(arrow32_2, "Mr.Duck ticket")
            AddTip("You get the Mr.Duck ticket, now you can enter the theme park.")
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound42.wm")
        ElseIf code = 4 Then
            RemoveOut(lock29_1)
            AddTip("You now are allowed to enter.")
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound48.wm")
        ElseIf code = 5 Then
            RemoveOut(warning30_1)
            AddTip("The thorns are cut.")
            GainItem(warning30_1, "scissors")
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound14.wm")
        ElseIf code = 6 Then
            DeathFlag = True
            Scene011appears()
            music.settings.volume = BackgroundVolume
            music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music1.wm"
            AddTip("You are teleported near the house, you may should get inside.", True)
        ElseIf code = 7 Then
            RemoveOut(lock31_2)
            AddTip("The palace door is unlocked.")
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound48.wm")
        ElseIf code = 8 Then
            RemoveOut(lock33_4)
            AddTip("The worm door is unlocked, the worm ran away.")
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound48.wm")
        ElseIf code = 9 Then
            GainItem(lock40_2, "physics test paper")
            RemoveOut(lock40_2)
            AddTip("The door is unlocked by the paper.")
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound48.wm")
        ElseIf code = 10 Then
            ball46_5.Tag += 1
            If ball46_5.Tag = 3 Then
                Scene021appears()
                GainItem(arrow33_3, "chlorine")
                AddTip("You get a bottle of chloride gas.")
                PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage
            End If
        ElseIf code = 11 Then
            GainItem(arrow34_2, "liquefied chlorine")
            AddTip("You get the chlorine liquefied.")
        ElseIf code = 12 Then
            backward.Visible = False
            If Not mute.Checked Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound10.wm")
            actor.Image =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image7.wm")
            SendMessage("Tarecgosa:" & vbCrLf & "Stupid mortal! You dare to violate your goddess!", 5,
                        "I will defeat you!")
        ElseIf code = 13 Then
            RemoveOut(lock44_4)
            AddTip("The door is opened.")
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound48.wm")
        ElseIf code = 14 Then
            RemoveOut(lock50_Mistake)
            AddTip("The door is unlocked.")
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound48.wm")
        ElseIf code = 15 Then
            RemoveOut(warning54_2)
            AddTip("Good job, the magic fog is dispelled.")
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound49.wm")
        ElseIf code = 16 Then
            GainItem(water35_2, "aqua regia")
            AddTip("You get the aqua regia.")
        ElseIf code = 17 Then
            RemoveOut(lock57_2)
            AddTip("The door is corroded.")
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound48.wm")
        ElseIf code = 18 Then
            Scene040appears()
            If PictureBox3.Tag = 25 Then
                PictureBox3.Tag = 26
                AddTip("Underwater.", False)
            End If
            GainItem(dive64_1, "portable submarine")
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound54.wm")
        ElseIf code = 19 Then
            RemoveOut(lock63_4)
            AddTip("The door is unlocked.")
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound48.wm")
        ElseIf code = 20 Then
            If PictureBox3.Tag = 28 Then
                Disappear2()
                actor.Top = Height
                MoveSpeed = 2
                actor.Image =
                    Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image23.wm")
                actor.Visible = True
                dialogue.Visible = True
                dialogue.Text = ""
                dialogue.ForeColor = Color.Yellow
                GainItem(water35_2, "bottle")
                MoveAtropos.Tag = 6125
                MoveAtropos.Enabled = True
            ElseIf PictureBox3.Tag = 31 Then
                GainItem(water35_2, "duck pool water")
            End If
        ElseIf code = 21 Then
            Disappear2()
            AddTip("Some extremely smelly gas escaped...")
            PictureBox3.Image =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image24.wm")
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound56.wm")
            DeathTime.Tag = 0
            DeathTime.Enabled = True
        ElseIf code = 22 Then
            MoveAtropos.Tag = 6850
            actor.Visible = True
            MoveAtropos.Enabled = True
        ElseIf code = 23 Then
            RemoveOut(warning37_3)
            GainItem(warning37_3, "saw")
            AddTip("These thorns are cut.")
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound59.wm")
        ElseIf code = 24 Then
            RemoveOut(lock69_2)
            GainItem(lock69_2, "saw")
            AddTip("Of course.")
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound59.wm")
        ElseIf code = 25 Then
            RemoveOut(lock69_2)
            GainItem(lock69_2, "witch house key")
            AddTip("unlocked")
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound48.wm")
        ElseIf code = 26 Then
            RemoveOut(lock70_2)
            AddTip("unlocked")
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound48.wm")
        ElseIf code = 27 Then
            RemoveOut(lock68_2)
            GainItem(lock68_2, "saw")
            AddTip("The door is sawed off.")
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound59.wm")
        ElseIf code = 28 Then
            RemoveOut(lock68_2)
            AddTip("The door is unlocked.")
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound48.wm")
        ElseIf code = 29 Then
            Unlocked.Items.Remove(blocker68_3.Name)
            Unlocked.Items.Add("IrremovableBottle")
            Scene043appears()
            AddTip("The big bottle of hydrogen peroxide disappeared at once.")
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound13.wm")
        ElseIf code = 30 Then
            RemoveOut(answer73_3)
            items.Items.Add("carbolic stick")
            GainItem(answer73_3, "Mr.Duck standard answer")
            AddTip("You get Mr.Duck standard answer.")
        ElseIf code = 31 Then
            RemoveOut(answer73_3)
            items.Items.Add("red stick")
            GainItem(answer73_3, "Mr.Duck standard answer")
            AddTip("You get Mr.Duck standard answer.")
        ElseIf code = 32 Then
            RemoveOut(chest74_1)
            GainItem(chest74_1, "SixGod SD card")
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound48.wm")
        ElseIf code = 33 Then
            dialogue.Visible = False
            Dim a As Integer = New Random(Now.Date.Millisecond).Next(- 2, 2)
            If a = - 2 Then Unlocked.Items.Add("a=-2")
            If a = - 1 Then Unlocked.Items.Add("a=-1")
            If a = 0 Then Unlocked.Items.Add("a=0")
            If a = 1 Then Unlocked.Items.Add("a=1")
            GainItem(actor, "constant a")
            actor.Tag = 1
            actor.Top += 1
            DeathFlagNum = 6
            MoveAtropos.Enabled = True
            AddTip("You get the constant [a] from the mermaid!")
        ElseIf code = 34 Then
            RemoveOut(warning37_3)
            GainItem(warning37_3, "witch house key")
            AddTip("The thorns are unlocked.")
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound48.wm")
        ElseIf code = 35 Then
            RemoveOut(lock57_2)
            GainItem(lock57_2, "duck vector launcher")
            AddTip("unlocked")
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound60.wm")
        ElseIf code = 36 Then
            RemoveOut(lock62_2)
            AddTip("unlocked")
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound48.wm")
        ElseIf code = 37 Then
            DeathFlagNum = 8
            dialogue.Text = "Click the cow to start battle."
            actor.Image =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\battler20.wm")
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound49.wm")
            AddTip("Sodium hydroxide has entirely sucked up the negative gas of the cow.")
        ElseIf code = 38 Then
            RemoveOut(lock81_2)
            GainItem(lock81_2, "scissors")
            AddTip("The paper tape is cut down.")
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound29.wm")
        ElseIf code = 39 Then
            PictureBox3.Tag = 41
            PictureBox3.Image =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image30.wm")
            AddTip("You put the magical colloid into the mould.")
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound13.wm")
        ElseIf code = 40 Then
            PictureBox3.Tag = 42
            PictureBox3.Image =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image31.wm")
            AddTip("You used the liquid nitrogen to freeze the colloid.")
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound56.wm")
        ElseIf code = 41 Then
            RemoveOut(lock46_2)
            GainItem(lock46_2, "turtle")
            AddTip("The door opened naturally.")
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound48.wm")
        ElseIf code = 42 Then
            RemoveOut(lock72_1)
            AddTip("The magic door is unlocked.")
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound48.wm")
            If Unlocked.Items.Contains("defeat witch") = False Then
                Disappear2()
                MoveSpeed = 2
                dialogue.Visible = False
                actor.Top = Height
                actor.Image =
                    Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image10.wm")
                actor.Visible = True
                MoveAtropos.Tag = 8700
                MoveAtropos.Enabled = True
            End If
        ElseIf code = 43 Then
            RemoveOut(gas93_1)
            AddTip("The hydrogen sulfide has been entirely sucked up.")
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound34.wm")
        ElseIf code = 44 Then
            RemoveOut(lock91_1)
            AddTip("It is unlocked.")
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound48.wm")
        ElseIf code = 45 Then
            Unlocked.Items.Add("build stairs")
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound55.wm")
            Scene077appears()
        ElseIf code = 46 Then
            Unlocked.Items.Add("open HF box")
            Scene073appears()
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound48.wm")
        ElseIf code = 47 Then
            RemoveOut(box100_1)
            GainItem(box100_1, "screwdriver")
            AddTip("You get the screwdriver from the box.")
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound48.wm")
        ElseIf code = 48 Then
            AddTip("Electrified.")
            Unlocked.Items.Add("electricity of gambling machine")
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound20.wm")
        ElseIf code = 49 Then
            DrawerAffectTarget.Image = Nothing
            DrawerAffectTarget.Tag = - 1
            GainItem(DrawerAffectTarget, "eraser")
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound50.wm")
        ElseIf code = 50 Then
            DrawerAffectTarget.Image = ImageList2.Images(5)
            DrawerAffectTarget.Tag = 5
            GainItem(DrawerAffectTarget, "painting tool")
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound50.wm")
            If ChosenDrawer.tag = 5 And drawit.Enabled = False Then
                gobackdraw.Enabled = False
                Button9.Enabled = True
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound28.wm")
                AddTip("You get the duck!!")
                headdraw.Text = "You get the duck! Click ""Get the bouns"" to get the duck function!"
            End If
        ElseIf code = 51 Then
            Unable = True
            Dim tempbox As String = InputBox("Please enter Aurora's password:", "Enter password")
            Unable = False
            If tempbox = "" Then
                AddTip("You didn't enter the password.")
                GainItem(chest82_3, "Aurora's password")
            ElseIf tempbox = "turtle" Then
                RemoveOut(chest82_3)
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound48.wm")
                items.Items.Add("Aurora's password")
                GainItem(chest82_3, "palette")
                AddTip("You get the palette from the chest.")
            Else
                AddTip("Incorrect.")
                GainItem(chest82_3, "Aurora's password")
            End If
        ElseIf code = 52 Then
            RemoveOut(ghostbox86_1)
            Disappear2()
            actor.Top = Height
            actor.Image =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image32.wm")
            dialogue.Visible = False
            actor.Visible = True
            MoveSpeed = 2
            MoveAtropos.Tag = 10250
            MoveAtropos.Enabled = True
        ElseIf code = 53 Then
            RemoveOut(lock26_1)
            AddTip("Atropos's magic is dispelled.")
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound34.wm")
        ElseIf code = 54 Then
            Unlocked.Items.Add("ink")
            AddTip("You put the ink cartridge into the printer.")
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound20.wm")
        ElseIf code = 55 Then
            Unlocked.Items.Add("paper inserted")
            AddTip("You put the paper into the printer.")
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound20.wm")
        ElseIf code = 56 Then
            Unlocked.Items.Add("break gem")
            Scene076appears()
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound62.wm")
            SaveGame("Chapter4", "Atropos altar", 10, False)
        ElseIf code = 57 Then
            Unable = True
            Dim tempbox As String = InputBox("Please enter Aurora's password:", "Enter password")
            Unable = False
            If tempbox = "" Then
                AddTip("You didn't enter the password.")
                GainItem(safe67_3, "Aurora's password")
            ElseIf tempbox = "turtle" Then
                Unlocked.Items.Add("open safe")
                Scene042appears()
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound48.wm")
                items.Items.Add("Aurora's password")
                GainItem(safe67_3, "USB")
                AddTip("You get the USB from the safe.")
            Else
                AddTip("Incorrect.")
                GainItem(safe67_3, "Aurora's password")
            End If
        ElseIf code = 58 Then
            Unlocked.Items.Add("DiskF")
            AddTip("New device is found.")
            Form17.username = GenerateRandom(7, "0,1,2,3,4,5,6,7,8,9,X")
            Form17.password = "111111"
            Dim selectable As String = GenerateRandom(10, "0,1,2,3,4,5,6,7,8,9,X")
            Form17.scoreurl = selectable.Substring(0, 3) & "." & selectable.Substring(3, 1) & "." &
                              selectable.Substring(4, 3) & "." & selectable.Substring(7, 3) & ":8080"
        ElseIf code = 59 Then
            Unlocked.Items.Remove("mirror1deflect")
            GainItem(teleporter95_1, "portable trailer")
            Scene070appears()
        ElseIf code = 60 Then
            Unlocked.Items.Remove("mirror1deflect")
            Scene070appears()
        ElseIf code = 61 Then
            Unlocked.Items.Add("mirror1deflect")
            GainItem(teleporter95_1, "trailer with mirror")
            Scene070appears()
        ElseIf code = 62 Then
            Unlocked.Items.Remove("mirror2deflect")
            GainItem(teleporter95_1, "portable trailer")
            Scene072appears()
        ElseIf code = 63 Then
            Unlocked.Items.Remove("mirror2deflect")
            Scene072appears()
        ElseIf code = 64 Then
            Unlocked.Items.Add("mirror2deflect")
            GainItem(teleporter95_1, "trailer with mirror")
            Scene072appears()
        ElseIf code = 65 Then
            DeathFlagNum = 0
            MoveAtropos.Tag = 11050
            MoveAtropos.Enabled = True
            GainItem(actor, "mirror")
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound57.wm")
        ElseIf code = 66 Then
            Hide()
            Form7.Show()
            DeathFlagNum = 0
            Form7.initialization(shield_level, weapon_level, 0, 350 + shield_level*150, 1400, 19, 100, 110, 1000, 900)
            music.settings.setMode("loop", True)
            music.settings.volume = 100
            music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music10.wm"
            actor.Image =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image10.wm")
        ElseIf code = 67 Then
            MoveAtropos.Tag = 12990
            MoveAtropos.Enabled = True
        ElseIf code = 68 Then
            answerbox.Visible = False
            answerworm.Visible = True
            AddTip("The standard answer tells you that the real answer is a big worm.")
            GroupBox5.Enabled = False
            answerclear.Enabled = True
            answerbutton.Enabled = True
        ElseIf code = 69 Then
            Physics_μ.Text = "μ=0.9"
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound50.wm")
        End If
    End Sub

    Friend Sub AddTip(content As String, Optional important As Boolean = False)
        TipBox.Text = content
        TipBox.Size = New Size(PictureBox3.Width, 70)
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
        DeleteTip.Tag = 0
        DeleteTip.Enabled = True
    End Sub

    Private Sub DeleteTip_Tick(sender As Object, e As EventArgs) Handles DeleteTip.Tick
        DeleteTip.Tag += 1
        Dim MaxInt = 120
        If ImportantTip Then MaxInt = 470
        If DeleteTip.Tag > MaxInt Then
            If (DeleteTip.Tag - MaxInt)*10 > 255 Then
                If ImportantTip Then TipBox.BackColor = Color.Black
                If ImportantTip = False Then TipBox.BackColor = Color.White
            Else
                If ImportantTip Then _
                    TipBox.BackColor = Color.FromArgb(255 - (DeleteTip.Tag - MaxInt)*10,
                                                      255 - (DeleteTip.Tag - MaxInt)*10,
                                                      255 - (DeleteTip.Tag - MaxInt)*10)
                If ImportantTip = False Then _
                    TipBox.BackColor = Color.FromArgb((DeleteTip.Tag - MaxInt)*10, (DeleteTip.Tag - MaxInt)*10,
                                                      (DeleteTip.Tag - MaxInt)*10)
            End If
        Else
            If DeleteTip.Tag*10 > 255 Then
                If ImportantTip Then TipBox.BackColor = Color.Red
                If ImportantTip = False Then TipBox.BackColor = Color.Black
            Else
                If ImportantTip Then TipBox.BackColor = Color.FromArgb(DeleteTip.Tag*10, 0, 0)
                If ImportantTip = False Then _
                    TipBox.BackColor = Color.FromArgb(255 - DeleteTip.Tag*10, 255 - DeleteTip.Tag*10,
                                                      255 - DeleteTip.Tag*10)
            End If
        End If
        If DeleteTip.Tag >= MaxInt + 30 Then
            DeleteTip.Enabled = False
            DeleteTip.Tag = 0
            Controls.Remove(TipBox)
        End If
    End Sub

    Private Sub itemlist_click(sender As Object, e As EventArgs) Handles itemlist.Click
        deselect()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        items.Items.Remove("MP3 player with SixGod")
        If backward.Tag = 48 And backward.Visible Then
            If SelectedItemIs("manganese dioxide") Then
                UseItem(PictureBox3, 10)
            ElseIf SelectedItemIs("hydrochloric acid") Then
                UseItem(PictureBox3, 10)
            End If
        ElseIf backward.Tag = - 1 And PictureBox3.Tag <= 40 Then
            If SelectedItemIs("magical colloid") Then
                UseItem(PictureBox3, 39)
            Else
                AddTip("Step1: Put the colloid into it.")
            End If
        ElseIf backward.Tag = - 1 And PictureBox3.Tag = 41 Then
            If SelectedItemIs("liquid nitrogen") Then
                UseItem(PictureBox3, 40)
            Else
                AddTip("Step2: Splash sryogen onto it to cool it down.")
            End If
        ElseIf backward.Tag = - 1 And PictureBox3.Tag = 42 Then
            PictureBox3.Tag = 43
            Unlocked.Items.Add("machine used")
            AddTip("Step3: Get it!")
            GainItem(PictureBox3, "underwater magical key")
            Scene061appears()
        Else
            deselect()
        End If
    End Sub

    Private Sub place27_2_Click(sender As Object, e As EventArgs) Handles place27_2.Click
        If Not Enable() Then Exit Sub
        If SelectedItemIs("torch without fire") Then
            deselect()
            AddTip("The torch has no fire.")
        ElseIf SelectedItemIs("torch") Then
            UseItem(place27_2, 1)
        ElseIf SelectedItemIs() Then
            deselect()
            AddTip("This thing cannot set the fire.")
        Else
            AddTip("This rocket needs fire to launch.")
        End If
    End Sub

    Private Sub fire30_2_Click(sender As Object, e As EventArgs) Handles fire30_2.Click
        If Not Enable() Then Exit Sub
        If SelectedItemIs("torch without fire") Then
            UseItem(fire30_2, 0)
        ElseIf SelectedItemIs() Then
            deselect()
            AddTip("We cannot burn this.")
        Else
            AddTip("A bonfire is prepared to be used for burning something.")
        End If
    End Sub

    Private Sub key31_1_Click(sender As Object, e As EventArgs) Handles key31_1.Click
        If Enable() = False Then Exit Sub
        GainItem(key31_1, "Medusa temple's key")
        RemoveOut(key31_1)
        AddTip("You get the key to Medusa temple.")
    End Sub

    Private Sub potion31_3_Click(sender As Object, e As EventArgs) Handles potion31_3.Click
        If Enable() = False Then Exit Sub
        RemoveOut(potion31_3)
        heal += 1
        AddTip("You get 1 curative potion.")
    End Sub

    Private Sub coin26_2_Click(sender As Object, e As EventArgs) Handles coin26_2.Click
        If Enable() = False Then Exit Sub
        coin26_2.Visible = False
        Unlocked.Items.Remove("coin26_2")
        GainItem(coin26_2, "turkey coin")
        AddTip("You get a turkey coin from the ground.")
    End Sub

    Private Sub paper33_4_Click(sender As Object, e As EventArgs) Handles paper33_4.Click
        RemoveOut(paper33_4)
        GainItem(paper33_4, "chemistry test paper")
        AddTip("You get the chemistry test paper.")
    End Sub

    Private Sub arrow33_1_Click(sender As Object, e As EventArgs) Handles arrow33_1.Click
        If Enable() = False Then Exit Sub
        If backward.Visible = False And backward.Tag = 75 Then
            Scene051appears()
        ElseIf backward.Tag = 108 Then
            If _
                MsgBox("Go through this door, you'll have your final battle with Atropos." & vbCrLf & "Are you ready?",
                       vbYesNo, "Last battle") = vbYes Then
                Scene084appears()
                actor.Top = Height
                actor.Visible = True
                actor.Image =
                    Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image2.wm")
                dialogue.Visible = False
                actor.Tag = 0
                MoveAtropos.Tag = 11175
                MoveAtropos.Enabled = True
                music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music18.wm"
            End If
        Else
            Scene009appears()
            If PictureBox3.Tag = 4 Then
                PictureBox3.Tag = 5
                Disappear2()
                actor.Visible = True
                dialogue.Visible = False
                actor.Image =
                    Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image5.wm")
                MoveSpeed = 3
                MoveAtropos.Enabled = True
            End If
        End If
    End Sub

    Private Sub arrow34_2_Click(sender As Object, e As EventArgs) Handles arrow34_2.Click
        If Enable() = False Then Exit Sub
        If backward.Visible And backward.Tag = 26 Then
            If Unlocked.Items.Contains("lock26_1") Then
                Scene007appears()
                If PictureBox3.Tag = 2 Then
                    PictureBox3.Tag = 3
                    Disappear2()
                    actor.Visible = True
                    actor.Top = Height
                    actor.Image =
                        Image.FromFile(
                            My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image2.wm")
                    dialogue.Visible = False
                    dialogue.ForeColor = Color.White
                    Disappear2()
                    MoveAtropos.Tag = 900
                    MoveAtropos.Enabled = True
                End If
            Else
                If SelectedItemIs("Medusa temple's key") Then
                    UseItem(lock26_1, 2)
                ElseIf SelectedItemIs("magic dispeller") Then
                    UseItem(lock26_1, 53)
                ElseIf SelectedItemIs() Then
                    deselect()
                    AddTip("This cannot open the door.")
                Else
                    If lock26_1.Tag = 1 Then
                        AddTip("The door of Medusa temple is locked.")
                    Else
                        AddTip("Atropos had set a magical shield.")
                    End If
                End If
            End If
        ElseIf backward.Visible And backward.Tag = 43 Then
            If SelectedItemIs("chlorine") Then
                UseItem(arrow34_2, 11)
                AddTip("Liquefying chlorine......")
            ElseIf SelectedItemIs() Then
                deselect()
                AddTip("This is not usable.")
            Else
                AddTip("Liquefier.")
            End If
        ElseIf backward.Visible And backward.Tag = 68 Then
            If Not Unlocked.Items.Contains("blocker added") Then
                Unlocked.Items.Add("blocker added")
                blocker68_3.Visible = True
                Disappear2()
                actor.Image = Nothing
                actor.Top = 0
                actor.Visible = True
                dialogue.Text = ""
                dialogue.Visible = True
                dialogue.ForeColor = Color.Red
                MoveAtropos.Tag = 6025
                Unlocked.Items.Add("DamnYou Frog")
                MoveAtropos.Enabled = True
            Else
                Scene049appears()
            End If
        ElseIf backward.Visible And backward.Tag = 108 Then
            Scene084appears()
        Else
            If SelectedItemIs("") Then

            ElseIf SelectedItemIs("scissors") Then
                deselect()
                AddTip("Scissors cannot cut rocks into pieces.")
            ElseIf SelectedItemIs() Then
                deselect()
                AddTip("This is useless.")
            Else
                AddTip("The road is blocked by rocks.")
            End If
        End If
    End Sub

    Private Sub arrow34_3_Click(sender As Object, e As EventArgs) Handles arrow34_3.Click
        If Enable() = False Then Exit Sub
        If backward.Visible And backward.Tag = 38 Then
            Scene014appears()
        Else
            Scene010appears()
        End If
    End Sub

    Private Sub water35_2_Click(sender As Object, e As EventArgs) Handles water35_2.Click
        If Enable() = False Then Exit Sub
        If backward.Visible And backward.Tag = 59 Then
            If SelectedItemIs("bottle") Then
                UseItem(water35_2, 16)
            ElseIf SelectedItemIs("aqua regia") Then
                deselect()
                AddTip("You already have it.")
            ElseIf SelectedItemIs() Then
                deselect()
                AddTip("This isn't a usable container.")
            Else
                AddTip("Aqua regia, you need a corrosion resistant container.")
            End If
        Else
            If SelectedItemIs("bottle") Then
                If PictureBox3.Tag = 28 Then
                    UseItem(water35_2, 20)
                ElseIf PictureBox3.Tag = 30 Then
                    If _
                        MsgBox(
                            "The pool god asked you to dump dilute sulphuric acid to the pool to activate it before getting the water, are you sure you still want to get the water without activating it?",
                            vbYesNo, "Confirm") = vbYes Then
                        PictureBox3.Tag = 31
                        UseItem(water35_2, 20)
                    Else
                        deselect()
                    End If
                End If
            ElseIf SelectedItemIs("dilute sulfuric acid") Then
                DeathFlagNum = 1
                UseItem(water35_2, 21)
            ElseIf SelectedItemIs() Then
                deselect()
                AddTip("This isn't a usable container.")
            Else
                AddTip("The duck pool is almost saturated sodium sulfide solution.")
            End If
        End If
    End Sub

    Private Sub Mresponse_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) _
        Handles Mresponse.LinkClicked
        If ResponseCode = 0 Then
            SendMessage(
                "Prince frog:" & vbCrLf &
                "As you see, I'm in Mr.Duck theme park, because our palace is occupied by Tarecgosa.", 1,
                "Who is that ""Tarecgoda""?")
        ElseIf ResponseCode = 1 Then
            SendMessage(
                "Prince frog:" & vbCrLf &
                "Tarecgosa, originally was the goddess of Lamouis, before a few years, she had gone far away. However, then she came back with evil.",
                2, "What happened?")
        ElseIf ResponseCode = 2 Then
            SendMessage(
                "Prince frog:" & vbCrLf &
                "Things will come out when we defeat her. She now is in palace, I give you the key, but you cannot get inside.",
                3, "Why?")
        ElseIf ResponseCode = 3 Then
            SendMessage(
                "Prince frog:" & vbCrLf &
                "She'll catch you. But there is a disadvantage: she has been extremely afraid of Corona Fire. If you can get that fire then she can be defeated.",
                4, "I know. Thank you.")
        ElseIf ResponseCode = 4 Then
            message.Visible = False
            GainItem(actor, "palace key")
            actor.Tag = 1
            actor.Top -= 1
            MoveAtropos.Enabled = True
        ElseIf ResponseCode = 5 Then
            SendMessage(
                "Tarecgosa:" & vbCrLf & "I will tear you up with my hands, then you will know your stupid fire useless.",
                6, "To battle.")
        ElseIf ResponseCode = 6 Then
            Hide()
            Form7.initialization(shield_level, weapon_level, 0, 300 + shield_level*150, 2000, 15, 110, 100, 1200, 1000)
            music.settings.setMode("loop", True)
            music.settings.volume = 100
            music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music10.wm"
        ElseIf ResponseCode = 7 Then
            shining.Enabled = False
            actor.Visible = True
            actor.Image = Nothing
            SendMessage("Tarecgosa suddenly disappeared on air.", 8, "Then something strange happens...")
        ElseIf ResponseCode = 8 Then
            MoveAtropos.Tag = 1799
            MoveAtropos.Enabled = True
            message.Visible = False
        ElseIf ResponseCode = 9 Then
            PictureBox3.Tag = 28
            SendMessage(
                "Just now I saw the witch making some spell on a rock, I tried to stop her, but then I was defeated by the witch, so I have to hide underwater.",
                10, "I'm sorry to hear it.")
        ElseIf ResponseCode = 10 Then
            SendMessage(
                "It's not serious. I've found the way defeating the witch, here is it. You give this Mr.Duck math workbook to the witch when you see her next time.",
                11, "What's the use of it?")
        ElseIf ResponseCode = 11 Then
            SendMessage(
                "The witch surely will be confused when she looks on the difficult sums on the workbook, then she'll be dizzy, and then she is being defeated.",
                12, "I know, thank you a lot.")
        ElseIf ResponseCode = 12 Then
            SendMessage(
                "You're welcome. The witch is in a small house on the top of Thorn Mountain, good luck, now I should go.",
                13, "Ok.")
        ElseIf ResponseCode = 13 Then
            message.Visible = False
            GainItem(actor, "mathematics workbook")
            actor.Tag = 1
            actor.Top -= 1
            MoveAtropos.Enabled = True
        ElseIf ResponseCode = 14 Then
            SendMessage(
                "A saw! Now we can saw the thorns on second floor of Thorn Mountain! Then we can find that witch on the mountain.",
                15, "I have just defeated the witch.")
        ElseIf ResponseCode = 15 Then
            SendMessage(
                "Fantastic! I had told you the great use of Mr.Duck's math workbook, it is effected! I hope your journey can be successful.",
                16, "Thank you.")
        ElseIf ResponseCode = 16 Then
            message.Visible = False
            GainItem(actor, "saw")
            actor.Tag = 1
            actor.Top -= 1
            MoveAtropos.Enabled = True
        ElseIf ResponseCode = 17 Then
            If Unlocked.Items.Contains("defeat witch") Then
                SendMessage("Rooster:" & vbCrLf & "What thing?", 18,
                            "The god of destiny, Atropos is now eager to kill you.")
            Else
                SendMessage("Rooster:" & vbCrLf & "What thing?", 19,
                            "A witch'll change to beautiful girl to charm you, then kill you.")
            End If
        ElseIf ResponseCode = 18 Then
            SendMessage("Rooster:" & vbCrLf & "I know Atropos. But how can I defend?", 19,
                        "Atropos may create something to charm you, then kill you.")
        ElseIf ResponseCode = 19 Then
            SendMessage(
                "Rooster:" & vbCrLf &
                "Atropos once killed our king by this way, she controlled Tarecgosa to charm and kill the king.", 20)
        ElseIf ResponseCode = 20 Then
            SendMessage("Rooster:" & vbCrLf & "Thank you. I surely will be more careful.", 21)
        ElseIf ResponseCode = 21 Then
            message.Visible = False
            MoveAtropos.Tag = 7551
            actor.Tag = 1
            actor.Top += 1
            MoveAtropos.Enabled = True
        ElseIf ResponseCode = 22 Then
            actor.Visible = False
            message.Visible = False
            Scene056appears()
            AddTip("A girl's scream. Go to the palace at once.")
        End If
    End Sub

    Private Sub battery35_3_Click(sender As Object, e As EventArgs) Handles battery35_3.Click
        If Enable() = False Then Exit Sub
        RemoveOut(battery35_3)
        GainItem(battery35_3, "battery")
        AddTip("You get a battery.")
    End Sub

    Private Sub arrow32_2_Click(sender As Object, e As EventArgs) Handles arrow32_2.Click
        If Enable() = False Then Exit Sub
        If DeathFlag Then
            Disappear2()
            PictureBox3.Image =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image3.wm")
            DeathTime.Enabled = True
            AddTip("There is something strange......")
        ElseIf backward.Visible And backward.Tag = 39 Then
            If Unlocked.Items.Contains(lock40_2.Name) Then
                Scene017appears()
            Else
                Scene015appears()
            End If
        ElseIf backward.Visible And backward.Tag = 27 Then
            If SelectedItemIs() Then
                deselect()
                AddTip("This is useless.")
            ElseIf lock27_1.Visible = False And lock27_2.Visible = False Then
                Scene006appears()
            ElseIf lock27_1.Visible = False Then
                AddTip("There is guard wearing iron armor on the door of palace.")
                If MsgBox("Do you want to battle with the guard and defeat it?", vbYesNo, "Battle") = vbYes Then
                    Hide()
                    Form7.Show()
                    defeat_hen = True
                    Form7.initialization(weapon_level, shield_level, 0, 300 + shield_level*150, 305, 13, 0, 100, 0, 1000)
                    music.settings.setMode("loop", True)
                    music.settings.volume = 100
                    music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music8.wm"
                End If
            Else
                AddTip("There are lock and guard near the castle.")
            End If
        ElseIf backward.Visible And backward.Tag = 29 Then
            If PictureBox3.Tag = 3 Then
                If SelectedItemIs("turkey coin") Then
                    UseItem(arrow32_2, 3)
                    PictureBox3.Tag = 4
                ElseIf SelectedItemIs() Then
                    deselect()
                    AddTip("You can not pay this as coin.")
                Else
                    AddTip("You can buy ticket by paying turkey coin.")
                End If
            ElseIf PictureBox3.Tag > 3 Then
                AddTip("You already bought the ticket.")
            Else
                AddTip("You can buy ticket by using turkey coin.")
            End If
        ElseIf backward.Visible And backward.Tag = 31 Then
            If lock31_2.Visible Then
                If SelectedItemIs("palace key") Then
                    UseItem(lock31_2, 7)
                ElseIf SelectedItemIs() Then
                    deselect()
                    AddTip("No.")
                Else
                    AddTip("The door requires a key.")
                End If
            Else
                Scene016appears()
                If PictureBox3.Tag = 5 Then
                    Disappear2()
                    backward.Visible = True
                    actor.Top = 0
                    actor.Visible = True
                    dialogue.Visible = False
                    backward.BringToFront()
                    backward.Top = PictureBox3.Height - backward.Height
                    backward.Left = 0
                    actor.Image =
                        Image.FromFile(
                            My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image6.wm")
                    AddTip("Strong power surrounds her, she is Tarecgosa.")
                ElseIf PictureBox3.Tag = 37 Then
                    If mute.Checked = False Then _
                        My.Computer.Audio.Play(
                            My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue56.wm")
                    shining.Enabled = True
                    AddTip("It comes from here!", True)
                ElseIf PictureBox3.Tag >= 44 And Not Unlocked.Items.Contains("break gem") Then
                    Disappear2()
                    MoveAtropos.Tag = 10110
                    MoveAtropos.Enabled = True
                End If
            End If
        ElseIf backward.Visible = False And backward.Tag = 49 Then
            Scene025appears()
            If PictureBox3.Tag = 11 Then
                PictureBox3.Tag = 12
                Disappear2()
                actor.Visible = True
                dialogue.Visible = True
                MoveAtropos.Tag = 2200
                MoveAtropos.Enabled = True
                Unlocked.Items.Add(lock51_Mistake.Name)
                Unlocked.Items.Add(skull51_3.Name)
            ElseIf PictureBox3.Tag = 7 Then
                PictureBox3.Tag = 8
                Disappear2()
                actor.Visible = True
                dialogue.Visible = True
                MoveAtropos.Tag = 1900
                MoveAtropos.Enabled = True
            ElseIf PictureBox3.Tag = 35 Then
                Disappear2()
                PictureBox3.Tag = 36
                actor.Top = Height
                actor.Image =
                    Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image2.wm")
                dialogue.Visible = False
                actor.Visible = True
                MoveAtropos.Tag = 7650
                MoveAtropos.Enabled = True
            End If
        ElseIf backward.Visible And backward.Tag = 60 Then
            If PictureBox3.Tag = 36 Then
                Disappear2()
                actor.Top = 0
                MoveAtropos.Tag = 7774
                MoveAtropos.Enabled = True
            ElseIf PictureBox3.Tag = 24 Then
                PictureBox3.Tag = 25
                Disappear2()
                shining.Tag = 0
                shining.Interval = 200
                shining.Enabled = True
                PictureBox3.Image =
                    Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image8.wm")
                If Not mute.Checked Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound51.wm")
            End If
        ElseIf backward.Visible And backward.Tag = 61 Then
            Scene037appears()
        ElseIf backward.Visible And backward.Tag = 77 Then
            Scene053appears()
        ElseIf backward.Visible And backward.Tag = 78 Then
            Scene054appears()
            If PictureBox3.Tag = 32 Or PictureBox3.Tag = 33 Then
                PictureBox3.Tag = 34
                Disappear2()
                actor.Top = 0
                MoveAtropos.Tag = 7525
                dialogue.Visible = False
                actor.Visible = True
                actor.Image =
                    Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image26.wm")
                MoveAtropos.Enabled = True
            End If
        ElseIf backward.Visible And backward.Tag = 89 Then
            Scene065appears()
        ElseIf backward.Visible And backward.Tag = 91 Then
            If lock91_1.Visible Then
                If SelectedItemIs("turtle") Then
                    UseItem(lock91_1, 44)
                ElseIf SelectedItemIs() Then
                    deselect()
                    AddTip("It needs only turtle, the bigger the better.")
                Else
                    AddTip("turtle lock")
                End If
            Else
                Scene069appears()
            End If
        ElseIf backward.Visible And backward.Tag = 32 Then
            Scene079appears()
        End If
    End Sub

    Private Sub DeathTime_Tick(sender As Object, e As EventArgs) Handles DeathTime.Tick
        DeathTime.Tag += 1
        If DeathFlagNum = 1 Then
            If DeathTime.Tag = 1 Then
                SetHeight(479, - 1)
                AddTip("Something is going wrong.", True)
            ElseIf DeathTime.Tag = 3 Then
                DeathTime.Enabled = False
                GameOver("Hydrogen sulfide poisons you.")
            End If
        Else
            If DeathTime.Tag = 1 Then
                SetHeight(479, - 1)
                music.Ctlcontrols.stop()
                If mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound32.wm")
                PictureBox3.Image =
                    Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image4.wm")
            ElseIf DeathTime.Tag = 3 Then
                DeathTime.Enabled = False
                GameOver("You are destroyed.")
            End If
        End If
    End Sub

    Private Sub arrow37_2_Click(sender As Object, e As EventArgs) Handles arrow37_2.Click
        If Unlocked.Items.Contains(warning37_3.Name) Then
            Scene044appears()
        Else
            If SelectedItemIs("saw") Then
                UseItem(warning37_3, 23)
            ElseIf SelectedItemIs("scissors") Then
                deselect()
                AddTip("The scissors become powerless in front of massive thorns.")
            ElseIf SelectedItemIs("witch house key") Then
                UseItem(warning37_3, 34)
            ElseIf SelectedItemIs() Then
                deselect()
                AddTip("It can do nothing.")
            Else
                AddTip("Upper the road is witch's house, you need a key to unlock the thorns or straight cut them.")
            End If
        End If
    End Sub

    Private Sub go_back_Click(sender As Object, e As EventArgs) Handles backward.Click
        If Enable() = False Then Exit Sub
        If backward.Tag = 26 Then
            If Not Enable() Then Exit Sub
            If PictureBox3.Tag > 5 Then
                AddTip("The machine is currently broken.")
            ElseIf SelectedItemIs("battery") Then
                If _
                    MsgBox(
                        "The battery can give energy to the time machine. But you haven't finish your mission currently, do you still want to do it?",
                        vbYesNo, "charge") = vbYes Then
                    UseItem(backward, 6)
                Else
                    deselect()
                End If
            Else
                AddTip("The energy of time machine has run out.")
            End If
        ElseIf backward.Tag = 27 Then
            Scene001appears()
        ElseIf backward.Tag = 28 Then
            Scene002appears()
        ElseIf backward.Tag = 29 Then
            Scene003appears()
        ElseIf backward.Tag = 30 Then
            Scene003appears()
        ElseIf backward.Tag = 31 Then
            Scene002appears()
        ElseIf backward.Tag = 32 Then
            Scene001appears()
        ElseIf backward.Tag = 33 Then
            Scene004appears()
        ElseIf backward.Tag = 34 Then
            Scene008appears()
            If PictureBox3.Tag = 32 And Unlocked.Items.Contains("defeat witch") Then
                Disappear2()
                PictureBox3.Tag = 33
                MoveSpeed = 3
                actor.Top = Height
                actor.Visible = True
                dialogue.Visible = False
                actor.Image =
                    Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image5.wm")
                MoveAtropos.Enabled = True
            End If
        ElseIf backward.Tag = 35 Then
            Scene009appears()
            If PictureBox3.Tag = 31 Then
                Disappear2()
                MoveSpeed = 2
                PictureBox3.Tag = 32
                MoveAtropos.Tag = 6650
                actor.Top = Height
                actor.Visible = True
                dialogue.Visible = True
                dialogue.Text = ""
                dialogue.ForeColor = Color.Yellow
                MoveAtropos.Enabled = True
                actor.Image =
                    Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image23.wm")
            End If
        ElseIf backward.Tag = 37 Then
            Scene005appears()
        ElseIf backward.Tag = 38 Then
            Scene008appears()
        ElseIf backward.Tag = 39 Then
            Scene013appears()
        ElseIf backward.Tag = 40 Then
            Scene014appears()
        ElseIf backward.Tag = 41 Then
            If PictureBox3.Tag = 5 Then
                actor.Top = Height
                actor.Visible = False
                backward.Top = PictureBox3.Height - backward.Height
                backward.Left = (PictureBox3.Width - backward.Width)/2
            End If
            Scene006appears()
        ElseIf backward.Tag = 42 Then
            Scene014appears()
        ElseIf backward.Tag = 43 Then
            Scene017appears()
        ElseIf backward.Tag = 44 Then
            Scene018appears()
        ElseIf backward.Tag = 45 Then
            Scene017appears()
        ElseIf backward.Tag = 46 Then
            Scene020appears()
        ElseIf backward.Tag = 47 Then
            Scene019appears()
        ElseIf backward.Tag = 48 Then
            Scene021appears()
            PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage
        ElseIf backward.Tag = 50 Then
            Scene024appears()
        ElseIf backward.Tag = 51 Then
            Scene025appears()
        ElseIf backward.Tag = 52 Then
            Scene026appears()
        ElseIf backward.Tag = 53 Then
            Scene025appears()
        ElseIf backward.Tag = 54 Then
            Scene028appears()
        ElseIf backward.Tag = 55 Then
            Scene029appears()
        ElseIf backward.Tag = 56 Then
            Scene030appears()
        ElseIf backward.Tag = 57 Then
            Scene031appears()
            If PictureBox3.Tag = - 1 And items.Items.Contains("magic dispeller") Then
                PictureBox3.Tag = 16
                Disappear2()
                MoveSpeed = 2
                actor.Visible = True
                MoveAtropos.Enabled = True
            End If
        ElseIf backward.Tag = 58 Then
            Scene029appears()
        ElseIf backward.Tag = 59 Then
            Scene033appears()
        ElseIf backward.Tag = 60 Then
            Scene032appears()
        ElseIf backward.Tag = 61 Then
            Scene016appears()
        ElseIf backward.Tag = 62 Then
            Scene036appears()
        ElseIf backward.Tag = 63 Then
            Scene037appears()
        ElseIf backward.Tag = 64 Then
            Scene013appears()
        ElseIf backward.Tag = 65 Then
            Scene039appears()
        ElseIf backward.Tag = 66 Then
            Scene040appears()
        ElseIf backward.Tag = 67 Then
            Scene038appears()
        ElseIf backward.Tag = 68 Then
            Scene041appears()
        ElseIf backward.Tag = 69 Then
            Scene012appears()
        ElseIf backward.Tag = 70 Then
            Scene044appears()
        ElseIf backward.Tag = 71 Then
            Scene045appears()
        ElseIf backward.Tag = 72 Then
            Scene043appears()
        ElseIf backward.Tag = 73 Then
            Scene041appears()
        ElseIf backward.Tag = 74 Then
            Scene043appears()
        ElseIf backward.Tag = 75 Then
            Scene048appears()
        ElseIf backward.Tag = 76 Then
            Scene050appears()
        ElseIf backward.Tag = 77 Then
            Scene049appears()
        ElseIf backward.Tag = 78 Then
            Scene052appears()
        ElseIf backward.Tag = 79 Then
            Scene053appears()
        ElseIf backward.Tag = 80 Then
            Scene054appears()
        ElseIf backward.Tag = 84 Then
            Scene016appears()
        ElseIf backward.Tag = 85 Then
            Scene037appears()
        ElseIf backward.Tag = 86 Then
            Scene056appears()
        ElseIf backward.Tag = 87 Then
            Scene021appears()
        ElseIf backward.Tag = - 1 Then
            Scene061appears()
        ElseIf backward.Tag = 88 Then
            Scene047appears()
        ElseIf backward.Tag = 89 Then
            Scene063appears()
        ElseIf backward.Tag = 90 Then
            Scene064appears()
        ElseIf backward.Tag = 91 Then
            Scene065appears()
        ElseIf backward.Tag = 92 Then
            Scene065appears()
        ElseIf backward.Tag = 93 Then
            Scene067appears()
        ElseIf backward.Tag = 94 Then
            Scene066appears()
        ElseIf backward.Tag = 95 Then
            Scene069appears()
        ElseIf backward.Tag = 96 Then
            Scene068appears()
        ElseIf backward.Tag = 97 Then
            If Unlocked.Items.Contains(gas93_1.Name) Then
                Scene071appears()
            Else
                If SelectedItemIs("sodium hydroxide") Then
                    UseItem(backward, 43)
                Else
                    AddTip("Things behind are poisonous hydrogen sulfide.")
                End If
            End If
        ElseIf backward.Tag = 98 Then
            Scene072appears()
        ElseIf backward.Tag = 99 Then
            Scene072appears()
        ElseIf backward.Tag = 100 Then
            Scene074appears()
        ElseIf backward.Tag = 101 Then
            Scene074appears()
        ElseIf backward.Tag = 102 Then
            Scene076appears()
        ElseIf backward.Tag = 103 Then
            Scene077appears()
        ElseIf backward.Tag = 104 Then
            Scene007appears()
        ElseIf backward.Tag = 105 Then
            Scene079appears()
        ElseIf backward.Tag = 106 Then
            Scene080appears()
        ElseIf backward.Tag = 107 Then
            Disappear2()
            DeathFlagNum = 12
            shining.Tag = 0
            shining.Enabled = True
            shining.Interval = 200
            PictureBox3.Image =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image8.wm")
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound51.wm")
        ElseIf backward.Tag = 108 Then
            Scene078appears()
        End If
    End Sub

    Private Sub worm37_4_Click(sender As Object, e As EventArgs) Handles worm37_4.Click
        RemoveOut(worm37_4)
        GainItem(worm37_4, "laughing worm")
        AddTip("You pick up a laughing worm.")
    End Sub

    Private Sub arrow33_3_Click(sender As Object, e As EventArgs) Handles arrow33_3.Click
        If Enable() = False Then Exit Sub
        If backward.Visible And backward.Tag = 46 Then
            If items.Items.Contains("manganese dioxide") Or items.Items.Contains("hydrochloric acid") Then
                Scene023appears()
                AddTip("MnO2 and HCl generate Cl2.")
            Else
                AddTip("You have no enough reagent to do the experiment.")
            End If
        ElseIf backward.Visible And backward.Tag = 56 Then
            Scene032appears()
            If PictureBox3.Tag = 15 Then
                PictureBox3.Tag = - 1
                Disappear2()
                actor.Visible = True
                MoveAtropos.Enabled = True
            End If
        ElseIf backward.Visible And backward.Tag = 104 Then
            Scene080appears()
        Else
            If Unlocked.Items.Contains(lock33_4.Name) Then
                Scene013appears()
            Else
                If SelectedItemIs("laughing worm") Then
                    UseItem(lock33_4, 8)
                ElseIf SelectedItemIs() Then
                    deselect()
                    AddTip("This is not a worm.")
                Else
                    AddTip("You need a worm to open the door.")
                End If
            End If
        End If
    End Sub

    Private Sub arrow40_1_Click(sender As Object, e As EventArgs) Handles arrow40_1.Click
        If lock40_2.Visible Then
            If SelectedItemIs("physics test paper") Then
                UseItem(lock40_2, 9)
            ElseIf SelectedItemIs("chemistry test paper") Then
                deselect()
                AddTip("This paper is too filmy.")
            ElseIf SelectedItemIs() Then
                deselect()
                AddTip("This cannot be used as a paper.")
            Else
                AddTip("You need a card to get inside.")
            End If
        Else
            Scene017appears()
        End If
    End Sub

    Private Sub actor_Click(sender As Object, e As EventArgs) Handles actor.Click
        If Enable() = False Then Exit Sub
        If PictureBox3.Tag = 5 And backward.Tag = 41 And backward.Visible Then
            If SelectedItemIs("solar ball") Then
                UseItem(actor, 12)
            ElseIf SelectedItemIs() Then
                deselect()
                AddTip("This is useless to her.")
            Else
                AddTip("The power is too strong, we should find the solar fire to burn her.")
                backward.BringToFront()
            End If
        ElseIf SelectedItemIs("mathematics workbook") And MoveAtropos.Tag >= 6776 And MoveAtropos.Tag <= 6850 Then
            MoveAtropos.Enabled = False
            UseItem(actor, 22)
        ElseIf DeathFlagNum = 5 And SelectedItemIs("MP3 player with SixGod") Then
            DeathFlagNum = 6
            UseItem(actor, 33)
        ElseIf DeathFlagNum = 7 And PictureBox3.Tag = 39 Then
            If SelectedItemIs("sodium hydroxide") Then
                DeathFlagNum = 0
                PictureBox3.Tag = 40
                UseItem(actor, 37)
            ElseIf SelectedItemIs() Then
                AddTip("This cannot suck up the positive gas of the cow.")
            Else
                DeathFlagNum = 0
                PictureBox3.Tag = 40
                GoTo cow_battle
            End If
        ElseIf DeathFlagNum = 8 Then
            cow_battle:
            Hide()
            Form7.Show()
            Form7.initialization(shield_level, weapon_level, 0, 350 + shield_level*150, 450, 21, 50, 110, 456, 950)
            music.settings.setMode("loop", True)
            music.settings.volume = 100
            music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music8.wm"
        ElseIf DeathFlagNum = 12 Then
            If SelectedItemIs("trailer with mirror") Then
                MoveAtropos.Enabled = False
                UseItem(actor, 65)
            End If
        ElseIf MoveAtropos.Tag > 8700 And MoveAtropos.Tag < 8950 Then
            If SelectedItemIs("mathematics workbook") Then
                MoveAtropos.Enabled = False
                UseItem(actor, 66)
            End If
        ElseIf MoveAtropos.Tag > 11176 And MoveAtropos.Tag <= 12790 Then
            If _
                SelectedItemIs("XuTianhao artifact") Or SelectedItemIs("XuTianhao artifact -1") Or
                SelectedItemIs("XuTianhao artifact -2") Then
                deselect()
                AddTip("Use it later.")
            End If
        ElseIf MoveAtropos.Tag > 12790 And MoveAtropos.Tag < 12940 Then
            If SelectedItemIs("XuTianhao artifact") Then
                UseItem(actor, 67)
                MoveAtropos.Enabled = False
            ElseIf SelectedItemIs("XuTianhao artifact -1") Or SelectedItemIs("XuTianhao artifact -2") Then
                deselect()
                AddTip("Sorry, this is useless. The artifact is unactivated.")
            End If
        End If
    End Sub

    Private Sub paper39_1_Click(sender As Object, e As EventArgs) Handles paper39_1.Click
        If Enable() = False Then Exit Sub
        RemoveOut(paper39_1)
        GainItem(paper39_1, "physics test paper")
        AddTip("You get a flunked physics monthly test paper.")
    End Sub

    Private Sub arrow41_1_Click(sender As Object, e As EventArgs) Handles arrow41_1.Click
        If Enable() = False Then Exit Sub
        If backward.Visible And backward.Tag = 41 Then
            If Unlocked.Items.Contains(lock41_2.Name) Then
                If PictureBox3.Tag = 38 Or PictureBox3.Tag = 39 Then
                    target_:
                    PictureBox3.Tag = 39
                    Scene059appears()
                    Disappear2()
                    actor.Visible = True
                    actor.Image = Nothing
                    actor.Top = 0
                    dialogue.Visible = False
                    MoveAtropos.Tag = 7875
                    MoveAtropos.Enabled = True
                Else
                    Scene059appears()
                End If
            Else
                If PictureBox3.Tag = 38 Then
                    RemoveOut(lock41_2)
                    GoTo target_
                Else
                    If SelectedItemIs() Then
                        deselect()
                        AddTip("It is not the key.")
                    Else
                        AddTip("The door is locked")
                    End If
                End If
            End If
        ElseIf backward.Visible And backward.Tag = 42 Then
            Scene018appears()
        End If
    End Sub

    Private Sub place42_1_Click(sender As Object, e As EventArgs) Handles place42_1.Click
        If Enable() = False Then Exit Sub
        Scene020appears()
    End Sub

    Private Sub place43_1_Click(sender As Object, e As EventArgs) Handles place43_1.Click
        If Enable() = False Then Exit Sub
        Scene019appears()
    End Sub

    Private Sub place44_1_Click(sender As Object, e As EventArgs) Handles place44_1.Click
        If Enable() = False Then Exit Sub
        Scene018appears()
    End Sub

    Private Sub place44_2_Click(sender As Object, e As EventArgs) Handles place44_2.Click
        If Enable() = False Then Exit Sub
        If Unlocked.Items.Contains(lock44_4.Name) Then
            Scene022appears()
        Else
            If SelectedItemIs("orange key") Then
                UseItem(place44_2, 13)
            ElseIf SelectedItemIs() Then
                deselect()
                AddTip("This is not the right key.")
            Else
                AddTip("The door is locked.")
            End If
        End If
    End Sub

    Private Sub paper44_3_Click(sender As Object, e As EventArgs) Handles paper44_3.Click
        If Enable() = False Then Exit Sub
        Hide()
        Form15.Show()
        Form15.ChangeImage(18)
    End Sub

    Private Sub arrow45_1_Click(sender As Object, e As EventArgs) Handles arrow45_1.Click
        If Enable() = False Then Exit Sub
        Scene021appears()
    End Sub

    Private Sub stick43_2_Click(sender As Object, e As EventArgs) Handles stick43_2.Click
        If Enable() = False Then Exit Sub
        RemoveOut(stick43_2)
        GainItem(stick43_2, "carbolic stick")
        AddTip("You get a carbolic stick.")
    End Sub

    Private Sub blood45_2_Click(sender As Object, e As EventArgs) Handles blood45_2.Click
        If Enable() = False Then Exit Sub
        RemoveOut(blood45_2)
        GainItem(blood45_2, "chicken blood")
        AddTip("You collect some chicken blood.")
    End Sub

    Private Sub place26_4_Click(sender As Object, e As EventArgs) Handles place26_4.Click
        If Not Enable() Then Exit Sub
        If backward.Visible And backward.Tag = 27 Then
            If PictureBox3.Tag = 1 Then
                PictureBox3.Tag = 2
                SetHeight(599, - 1)
                items.Items.Clear()
                itemlist.Visible = True
                If witch_book Then items.Items.Add("witch's book")
                RefreshItems()
            End If
            Scene003appears()
        ElseIf backward.Visible And backward.Tag = 29 Then
            If Unlocked.Items.Contains("lock29_1") Then
                Scene008appears()
            Else
                If SelectedItemIs("Mr.Duck ticket") Then
                    UseItem(place26_4, 4)
                ElseIf SelectedItemIs() Then
                    deselect()
                    AddTip("This is useless.")
                Else
                    AddTip("You have no ticket to enter the theme park.")
                End If
            End If
        ElseIf backward.Visible And backward.Tag = 50 Then
            Scene026appears()
            MoveAtropos.Enabled = False
            If PictureBox3.Tag = 8 Then
                PictureBox3.Tag = 9
                Disappear2()
                actor.Visible = True
                dialogue.Visible = True
                MoveAtropos.Tag = 2000
                MoveAtropos.Enabled = True
            End If
        ElseIf backward.Visible = False And backward.Tag = 75 Then
            Scene048appears()
        Else
            Scene002appears()
            If PictureBox3.Tag = 0 Then
                PictureBox3.Tag = 1
                actor.Visible = True
                actor.Top = Height
                actor.Image =
                    Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image2.wm")
                dialogue.Visible = True
                dialogue.ForeColor = Color.White
                Disappear2()
                MoveAtropos.Enabled = True
            End If
        End If
    End Sub

    Private Sub magic45_3_Click(sender As Object, e As EventArgs) Handles magic45_3.Click
        If Enable() = False Then Exit Sub
        RemoveOut(magic45_3)
        magics.Items.Add("Curative box")
        AddTip("You get a new magic: curative box.")
    End Sub

    Private Sub arrow46_1_Click(sender As Object, e As EventArgs) Handles arrow46_1.Click
        If Enable() = False Then Exit Sub
        If backward.Visible And backward.Tag = 66 Then
            Scene043appears()
        ElseIf backward.Visible And backward.Tag = 90 Then
            Scene067appears()
        Else
            If lock46_2.Visible = False Then
                Scene062appears()
            Else
                If SelectedItemIs("turtle") Then
                    UseItem(lock46_2, 41)
                ElseIf SelectedItemIs() Then
                    deselect()
                    AddTip("Not at all.")
                Else
                    AddTip("The door is locked, the keyhole is a turtle.")
                End If
            End If
        End If
    End Sub

    Private Sub magic46_3_Click(sender As Object, e As EventArgs) Handles magic46_3.Click
        RemoveOut(magic46_3)
        magics.Items.Add("HCl gun")
        AddTip("You get a new magic: HCl gun")
    End Sub

    Private Sub scissors35_4_Click(sender As Object, e As EventArgs) Handles scissors35_4.Click
        If Enable() = False Then Exit Sub
        RemoveOut(scissors35_4)
        GainItem(scissors35_4, "scissors")
        AddTip("You get a pair of scissors.")
    End Sub

    Friend Sub SendMessage(content As String, code As Integer, Optional response As String = "Next.")
        ResponseCode = code
        message.Visible = True
        Mcontent.Text = content
        Mresponse.Text = response
        Mresponse.LinkVisited = False
    End Sub

    Private Sub paper46_4_Click(sender As Object, e As EventArgs) Handles paper46_4.Click
        If Enable() = False Then Exit Sub
        Form15.Show()
        If backward.Visible And backward.Tag = 67 Then
            Form15.ChangeImage(21)
        Else
            Form15.ChangeImage(20)
        End If
        Hide()
    End Sub

    Private Sub ball46_5_Click(sender As Object, e As EventArgs) Handles ball46_5.Click
        If Enable() = False Then Exit Sub
        RemoveOut(ball46_5)
        GainItem(ball46_5, "solar shell")
        AddTip("You get the solar shell from the desk.")
    End Sub

    Private Sub potion47_1_Click(sender As Object, e As EventArgs) Handles potion47_1.Click
        If Enable() = False Then Exit Sub
        RemoveOut(potion47_1)
        GainItem(potion47_1, "manganese dioxide")
        AddTip("You get the manganese dioxide from the desk.")
    End Sub

    Private Sub potion47_2_Click(sender As Object, e As EventArgs) Handles potion47_2.Click
        If Enable() = False Then Exit Sub
        RemoveOut(potion47_2)
        GainItem(potion47_2, "hydrochloric acid")
        AddTip("You get the hydrochloric acid from the desk.")
    End Sub

    Private Sub dive38_1_Click(sender As Object, e As EventArgs) Handles dive38_1.Click
        If Enable() = False Then Exit Sub
        Scene039appears()
    End Sub

    Private Sub leftmove_Click(sender As Object, e As EventArgs) Handles leftmove.Click
        Dim usable = False
        For x = 0 To items.Items.Count - 1
            If SelectedItemIs(items.Items(x)) Then
                usable = True
                items.SelectedItem = items.Items(x)
            End If
        Next
        If usable Then
            Dim i As Integer = items.SelectedIndex
            If i > 0 Then
                Dim obj As Object
                obj = items.SelectedItem
                items.Items.RemoveAt(i)
                items.Items.Insert(i, items.Items.Item(i - 1))
                items.Items.RemoveAt(i - 1)
                items.Items.Insert(i - 1, obj)
            End If
            RefreshItems()
        End If
    End Sub

    Private Sub rightmove_Click(sender As Object, e As EventArgs) Handles rightmove.Click
        Dim usable = False
        For x = 0 To items.Items.Count - 1
            If SelectedItemIs(items.Items(x)) Then
                usable = True
                items.SelectedItem = items.Items(x)
            End If
        Next
        If usable Then
            Dim i As Integer = items.SelectedIndex
            If i < items.Items.Count - 1 Then
                Dim obj As Object
                obj = items.SelectedItem
                items.Items.RemoveAt(i)
                items.Items.Insert(i + 1, obj)
            End If
            RefreshItems()
        End If
    End Sub

    Private Sub shining_Tick(sender As Object, e As EventArgs) Handles shining.Tick
        If DeathFlagNum = 3 Then
            shining.Tag += 1
            If Temp1 = True Then
                Temp1 = False
                actor.Image = Nothing
            Else
                Temp1 = True
                actor.Image =
                    Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image10.wm")
            End If
            If shining.Tag >= 25 Then
                shining.Tag = 0
                shining.Enabled = False
                actor.Image = Nothing
            End If
        ElseIf PictureBox3.Tag = 37 Then
            shining.Tag += 1
            If arrow41_1.BackColor = Color.Red Then arrow41_1.BackColor = Color.Transparent Else _
                arrow41_1.BackColor = Color.Red
            If shining.Tag >= 20 Then
                PictureBox3.Tag = 38
                shining.Tag = 0
                shining.Enabled = False
                arrow41_1.BackColor = Color.Transparent
                Scene016appears()
                topic.Text = "Chapter4"
                topic.Visible = True
                topic.Width = PictureBox3.Width
                DifTip.Visible = True
                RemoveTitle.Enabled = True
                topic.BringToFront()
                DifTip.BringToFront()
                SaveGame("Chapter4", "Floor1, stairs", 7, False)
            End If
        ElseIf DeathFlagNum = 4 Then
            shining.Tag += 1
            If leg70_3.BackColor = Color.Red Then leg70_3.BackColor = Color.Transparent Else _
                leg70_3.BackColor = Color.Red
            If shining.Tag >= 20 Then
                shining.Tag = 0
                shining.Enabled = False
                leg70_3.BackColor = Color.Transparent
                Scene045appears()
            End If
        ElseIf DeathFlagNum = 13 Then
            shining.Tag += 1
            If Temp1 = True Then
                Temp1 = False
                actor.Image = Nothing
            Else
                Temp1 = True
                actor.Image =
                    Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image44.wm")
            End If
            If shining.Tag >= 15 Then
                shining.Tag = 0
                shining.Enabled = False
                MoveAtropos.Enabled = True
            End If
        ElseIf DeathFlagNum = 14 Then
            shining.Tag += 1
            If Temp1 = True Then
                Temp1 = False
                actor.Image = Nothing
            Else
                Temp1 = True
                actor.Image =
                    Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image45.wm")
            End If
            If shining.Tag >= 15 Then
                shining.Tag = 0
                shining.Enabled = False
                MoveAtropos.Enabled = True
            End If
        ElseIf PictureBox3.Tag = 6 Then
            If actor.Visible = True Then actor.Visible = False Else actor.Visible = True
        ElseIf PictureBox3.Tag = 18 Then
            If Temp1 = True Then
                Temp1 = False
                actor.Image = Nothing
            Else
                Temp1 = True
                actor.Image =
                    Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image15.wm")
            End If
        ElseIf _
            PictureBox3.Tag = 7 Or PictureBox3.Tag = 10 Or PictureBox3.Tag = 19 Or PictureBox3.Tag = 25 Or
            PictureBox3.Tag = 35 Or DeathFlagNum = 9 Or DeathFlagNum = 10 Or DeathFlagNum = 11 Or DeathFlagNum = 12 Then
            shining.Tag += 1
            If arrow41_3.Tag = 1 Then
                arrow41_3.Tag = 2
                PictureBox3.Image =
                    Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image9.wm")
            Else
                arrow41_3.Tag = 1
                PictureBox3.Image =
                    Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image8.wm")
            End If
            If shining.Tag >= 25 Then
                shining.Tag = 0
                If PictureBox3.Tag = 10 Then
                    PictureBox3.Tag = 11
                    shining.Enabled = False
                    Scene024appears()
                    AddTip("What the hell!!", True)
                ElseIf PictureBox3.Tag = 19 Then
                    PictureBox3.Tag = 20
                    shining.Enabled = False
                    Scene024appears()
                    AddTip("Once again.")
                ElseIf PictureBox3.Tag = 25 Then
                    Scene016appears()
                    shining.Enabled = False
                    AddTip("Finally, you come back. You finished the first journey, but what did Atropos mean?", True)
                    music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music14.wm"
                    SaveGame("Chapter3", "Floor1, stairs", 6, False)
                ElseIf PictureBox3.Tag = 35 Then
                    shining.Enabled = False
                    Scene024appears()
                    RemoveOut(lock57_4)
                    Unlocked.Items.Remove(lock57_2.Name)
                    AddTip("You're teleported into the ghost place.")
                ElseIf DeathFlagNum >= 9 Then
                    shining.Enabled = False
                    If DeathFlagNum = 9 Then Scene072appears()
                    If DeathFlagNum = 10 Then Scene070appears()
                    If DeathFlagNum = 11 Then Scene082appears()
                    If DeathFlagNum = 12 Then Scene081appears()
                Else
                    shining.Enabled = False
                    Scene024appears()
                    AddTip("Where am I??", True)
                    music.settings.volume = BackgroundVolume
                    music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music16.wm"
                End If
            End If
        End If
    End Sub

    Private Sub arrow41_3_Click(sender As Object, e As EventArgs) Handles arrow41_3.Click
        If Enable() = False Then Exit Sub
        If backward.Tag = 53 And backward.Visible Then
            Scene029appears()
            If PictureBox3.Tag = - 1 Then
                Disappear2()
                PictureBox3.Tag = 13
                actor.Visible = True
                dialogue.Visible = True
                actor.Top = 0
                dialogue.Top = 0
                dialogue.Left = 0
                actor.Image = Nothing
                MoveAtropos.Enabled = True
            ElseIf PictureBox3.Tag = 21 Then
                PictureBox3.Tag = 22
                actor.Visible = True
                actor.Top = 0
                actor.Image = Nothing
                dialogue.Visible = True
                dialogue.Text = ""
                dialogue.ForeColor = Color.Red
                Disappear2()
                MoveAtropos.Enabled = True
            End If
        ElseIf backward.Visible And backward.Tag = 76 Then
            If SelectedItemIs("") Then

            Else
                AddTip("A teleporter between points of time, but it's unactivated.")
            End If
        ElseIf backward.Visible And backward.Tag = 88 Then
            Scene064appears()
            If PictureBox3.Tag = 44 Then
                PictureBox3.Tag = 44.5
                SaveGame("Chapter4", "Magic area", 9, False)
            End If
        ElseIf backward.Tag = 97 Then
            Scene074appears()
        Else
            If PictureBox3.Tag = 6 Then
                Disappear2()
                arrow41_3.Tag = 1
                PictureBox3.Tag = 7
                shining.Interval = 200
                shining.Enabled = True
                music.Ctlcontrols.stop()
                PictureBox3.Image =
                    Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image8.wm")
                If Not mute.Checked Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound51.wm")
            Else
                Scene036appears()
            End If
        End If
    End Sub

    Private Sub arrow50_1_Click(sender As Object, e As EventArgs) Handles arrow50_1.Click
        If Enable() = False Then Exit Sub
        If backward.Visible And backward.Tag = 52 Then
            Disappear2()
            arrow41_3.Tag = 1
            shining.Tag = 0
            shining.Interval = 200
            shining.Enabled = True
            PictureBox3.Image =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image8.wm")
            If Not mute.Checked Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound51.wm")
        ElseIf backward.Visible And backward.Tag = 50 Then
            If lock50_Mistake.Visible Then
                If SelectedItemIs("skull") Then
                    UseItem(lock50_Mistake, 14)
                ElseIf SelectedItemIs() Then
                    deselect()
                    AddTip("This is useless.")
                Else
                    AddTip("The door is locked, it needs a skull.")
                End If
            Else
                MoveAtropos.Enabled = False
                Scene028appears()
                If PictureBox3.Tag = 12 Then
                    PictureBox3.Tag = - 1
                    actor.Visible = True
                    actor.Top = Height
                    actor.Image =
                        Image.FromFile(
                            My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image2.wm")
                    dialogue.Visible = False
                    dialogue.ForeColor = Color.White
                    Disappear2()
                    MoveAtropos.Enabled = True
                ElseIf PictureBox3.Tag = 20 Then
                    PictureBox3.Tag = 21
                    actor.Visible = True
                    actor.Top = 0
                    actor.Image = Nothing
                    dialogue.Visible = True
                    dialogue.Text = ""
                    dialogue.ForeColor = Color.Red
                    Disappear2()
                    MoveAtropos.Enabled = True
                End If
            End If
        ElseIf backward.Visible And backward.Tag = 51 Then
            If lock51_Mistake.Visible Then
                If SelectedItemIs("") Then

                ElseIf SelectedItemIs() Then
                    deselect()
                    AddTip("This is useless.")
                Else
                    AddTip("The door is locked.")
                End If
            Else
                Scene027appears()
                If PictureBox3.Tag = 9 Then
                    PictureBox3.Tag = 10
                    Disappear2()
                    actor.Visible = True
                    dialogue.Visible = True
                    MoveAtropos.Tag = 2100
                    MoveAtropos.Enabled = True
                End If
            End If
        ElseIf backward.Visible And backward.Tag = 58 Then
            Scene034appears()
            If PictureBox3.Tag = 17 Then
                PictureBox3.Tag = 18
                Disappear2()
                actor.Top = Height
                actor.Image =
                    Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image10.wm")
                actor.Visible = True
                dialogue.Text = ""
                dialogue.Visible = True
                MoveAtropos.Enabled = True
            ElseIf PictureBox3.Tag = 23 Then
                PictureBox3.Tag = 24
                actor.Visible = True
                actor.Top = 0
                actor.Image = Nothing
                dialogue.Visible = True
                dialogue.Text = ""
                dialogue.ForeColor = Color.Red
                Disappear2()
                MoveAtropos.Enabled = True
            End If
        ElseIf backward.Visible And backward.Tag = 65 Then
            Scene041appears()
            If PictureBox3.Tag = 26 Then
                Disappear2()
                PictureBox3.Tag = 27
                MoveSpeed = 3
                actor.Visible = True
                actor.Image =
                    Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image5.wm")
                actor.Tag = 2
                actor.Top = Height
                MoveAtropos.Enabled = True
            End If
        ElseIf backward.Visible And backward.Tag = 72 Then
            If lock72_1.Visible Then
                If SelectedItemIs("underwater magical key") Then
                    UseItem(lock72_1, 42)
                ElseIf SelectedItemIs() Then
                    deselect()
                    AddTip("The door isn't common.")
                Else
                    AddTip("The door has been locked magically.")
                End If
            Else
                Scene063appears()
                If PictureBox3.Tag = 43 Then
                    Disappear2()
                    PictureBox3.Tag = 44
                    music.settings.volume = BackgroundVolume
                    music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music17.wm"
                    actor.Image =
                        Image.FromFile(
                            My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image2.wm")
                    actor.Top = Height
                    actor.Visible = True
                    dialogue.Visible = False
                    MoveAtropos.Tag = 9150
                    MoveAtropos.Enabled = True
                End If
            End If
        ElseIf backward.Visible And backward.Tag = 74 Then
            Scene052appears()
        ElseIf backward.Visible And backward.Tag = 93 Then
            If gas93_1.Visible Then
                If SelectedItemIs("sodium hydroxide") Then
                    UseItem(gas93_1, 43)
                ElseIf SelectedItemIs() Then
                    deselect()
                    AddTip("We need effective item to remove all these hepatic gas.")
                Else
                    AddTip("Things in the front are thick hydrogen sulfide.")
                End If
            Else
                Scene071appears()
            End If
        ElseIf backward.Visible And backward.Tag = 102 Then
            If Unlocked.Items.Contains("build stairs") Then
                Scene078appears()
            Else
                If SelectedItemIs("ladder") Then
                    UseItem(PictureBox3, 45)
                Else
                    AddTip("It is too high to reach.")
                End If
            End If
        End If
    End Sub

    Private Sub skull50_3_Click(sender As Object, e As EventArgs) Handles skull51_3.Click
        skull51_3.Visible = False
        Unlocked.Items.Remove(skull51_3.Name)
        GainItem(skull51_3, "skull")
        AddTip("You get a skull.")
    End Sub

    Private Sub arrow55_1_Click(sender As Object, e As EventArgs) Handles arrow55_1.Click
        If Enable() = False Then Exit Sub
        If backward.Visible And backward.Tag = 80 Then
            Scene056appears()
        Else
            Scene031appears()
            If PictureBox3.Tag = 14 Then
                PictureBox3.Tag = 15
                Disappear2()
                actor.Visible = True
                MoveAtropos.Enabled = True
            End If
        End If
    End Sub

    Private Sub potion57_5_Click(sender As Object, e As EventArgs) Handles potion57_5.Click
        If Enable() = False Then Exit Sub
        RemoveOut(potion57_5)
        GainItem(potion57_5, "magic dispeller")
        AddTip("You get the magic dispeller.")
    End Sub

    Private Sub arrow57_3_Click(sender As Object, e As EventArgs) Handles arrow57_3.Click
        If lock57_4.Visible Then
            If SelectedItemIs() Then
                deselect()
                AddTip("Not this.")
            Else
                AddTip("It needs a key to be unlocked.")
            End If
        Else
            Scene058appears()
        End If
    End Sub

    Private Sub arrow57_1_Click(sender As Object, e As EventArgs) Handles arrow57_1.Click
        If backward.Tag = 99 Then
            Scene076appears()
        Else
            If lock57_2.Visible Then
                If SelectedItemIs("aqua regia") Then
                    UseItem(lock57_2, 17)
                ElseIf SelectedItemIs("duck vector launcher") Then
                    UseItem(lock57_2, 35)
                ElseIf SelectedItemIs() Then
                    deselect()
                    If PictureBox3.Tag = 36 Then AddTip("You need vector arrow and bow, then combine them.") Else _
                        AddTip("×")
                Else
                    If PictureBox3.Tag = 36 Then AddTip("If you shoot vector arrow to the door, it will open.") Else _
                        AddTip("")
                End If
            Else
                Scene035appears()
            End If
        End If
    End Sub

    Private Sub bottle58_1_Click(sender As Object, e As EventArgs) Handles bottle58_1.Click
        RemoveOut(bottle58_1)
        GainItem(bottle58_1, "bottle")
        AddTip("You get a glass bottle.")
    End Sub

    Private Sub arrow62_1_Click(sender As Object, e As EventArgs) Handles arrow62_1.Click
        If Enable() = False Then Exit Sub
        If backward.Visible And backward.Tag = 62 Then
            Scene038appears()
        ElseIf backward.Tag = 94 Then
            Scene070appears()
        End If
    End Sub

    Private Sub arrow63_1_Click(sender As Object, e As EventArgs) Handles arrow63_1.Click
        If Enable() = False Then Exit Sub
        If lock63_4.Visible Then
            If SelectedItemIs("Aurora music room key") Then
                UseItem(arrow63_1, 19)
            ElseIf SelectedItemIs() Then
                deselect()
                AddTip("It is not the correct key.")
            Else
                AddTip("The door is locked.")
            End If
        Else
            Scene042appears()
        End If
    End Sub

    Private Sub machine63_3_Click(sender As Object, e As EventArgs) Handles machine63_3.Click
        If Enable() = False Then Exit Sub
        RemoveOut(machine63_3)
        GainItem(machine63_3, "portable submarine")
        AddTip("You get a portable submarine.")
    End Sub

    Private Sub laptop63_2_Click(sender As Object, e As EventArgs) Handles laptop63_2.Click
        If SelectedItemIs("USB") Then
            UseItem(laptop63_2, 58)
        Else
            Hide()
            Form17.Show()
            Unlocked.Items.Remove("Internet")
            Form17.ToIcon3()
        End If
    End Sub

    Private Sub key66_3_Click(sender As Object, e As EventArgs) Handles key66_3.Click
        RemoveOut(key66_3)
        GainItem(key66_3, "Aurora music room key")
        AddTip("You get the key to Aurora's music room.")
    End Sub

    Private Sub arrow66_1_Click(sender As Object, e As EventArgs) Handles arrow66_1.Click
        If lock66_2.Visible Then
            Hide()
            Form18.Show()
            Form18.RefreshAll()
            Form18.GroupBox1.Visible = True
            If Unlocked.Items.Contains("a=-2") Then Form18.a = - 2
            If Unlocked.Items.Contains("a=-1") Then Form18.a = - 1
            If Unlocked.Items.Contains("a=0") Then Form18.a = 0
            If Unlocked.Items.Contains("a=1") Then Form18.a = 1
            If Not Form18.a = 6 Then Form18.Label5.Text = "a=" & Form18.a
        Else
            Scene048appears()
        End If
    End Sub

    Private Sub blocker68_3_Click(sender As Object, e As EventArgs) Handles blocker68_3.Click
        If Enable() = False Then Exit Sub
        If SelectedItemIs("shrinking potion") Then
            UseItem(blocker68_3, 29)
        ElseIf SelectedItemIs() Then
            deselect()
            AddTip("This is powerless.")
        Else
            AddTip("A big bottle of hydrogen peroxide blocked your path.")
        End If
    End Sub

    Private Sub paper46_5_Click(sender As Object, e As EventArgs) Handles paper46_5.Click
        If Enable() = False Then Exit Sub
        Hide()
        Form15.Show()
        Form15.ChangeImage(22)
    End Sub

    Private Sub bottle65_1_Click(sender As Object, e As EventArgs) Handles bottle65_1.Click
        If Enable() = False Then Exit Sub
        RemoveOut(bottle65_1)
        GainItem(bottle65_1, "bottle")
        AddTip("You get a glass bottle.")
    End Sub

    Private Sub apple71_2_Click(sender As Object, e As EventArgs) Handles apple71_2.Click
        If Enable() = False Then Exit Sub
        RemoveOut(apple71_2)
        GainItem(apple71_2, "golden apple")
        AddTip("You get the golden apple.")
    End Sub

    Private Sub arrow69_1_Click(sender As Object, e As EventArgs) Handles arrow69_1.Click
        If backward.Tag = 96 Then
            Scene072appears()
        Else
            If Unlocked.Items.Contains(lock69_2.Name) Then
                Scene045appears()
                If Not Unlocked.Items.Contains("find frog leg") Then
                    Unlocked.Items.Add("find frog leg")
                    Disappear2()
                    leg70_3.Visible = True
                    DeathFlagNum = 4
                    shining.Enabled = True
                    AddTip("Oh my god!! The frog leg!! Who had cooked the frog??", True)
                    If Not mute.Checked Then _
                        My.Computer.Audio.Play(
                            My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound25.wm")
                End If
            Else
                If SelectedItemIs("saw") Then
                    UseItem(lock69_2, 24)
                ElseIf SelectedItemIs("witch house key") Then
                    UseItem(lock69_2, 25)
                ElseIf SelectedItemIs() Then
                    deselect()
                    AddTip("This do not have the ability to unlock the door.")
                Else
                    AddTip("A cracked but locked door.")
                End If
            End If
        End If
    End Sub

    Private Sub leg70_3_Click(sender As Object, e As EventArgs) Handles leg70_3.Click
        If Enable() = False Then Exit Sub
        AddTip("Who cooked that frog?")
    End Sub

    Private Sub arrow70_1_Click(sender As Object, e As EventArgs) Handles arrow70_1.Click
        If backward.Visible And backward.Tag = 92 Then
            Scene068appears()
        Else
            If lock70_2.Visible Then
                If SelectedItemIs("witch house key") Then
                    UseItem(lock70_2, 26)
                ElseIf SelectedItemIs("saw") Then
                    deselect()
                    AddTip("The door is very solid.")
                ElseIf SelectedItemIs() Then
                    deselect()
                    AddTip("This is not a usable key for the door.")
                Else
                    AddTip("A locked door.")
                End If
            Else
                Scene046appears()
            End If
        End If
    End Sub

    Private Sub arrow68_1_Click(sender As Object, e As EventArgs) Handles arrow68_1.Click
        If Enable() = False Then Exit Sub
        If lock68_2.Visible Then
            If SelectedItemIs("saw") Then
                UseItem(lock68_2, 27)
            ElseIf SelectedItemIs("underwater cave key") Then
                UseItem(lock68_2, 28)
            ElseIf SelectedItemIs() Then
                deselect()
                AddTip("This is not a usable key for the door.")
            Else
                AddTip("The cave door is locked.")
            End If
        Else
            Scene047appears()
        End If
    End Sub

    Private Sub key72_3_Click(sender As Object, e As EventArgs) Handles key72_3.Click
        If Enable() = False Then Exit Sub
        RemoveOut(key72_3)
        GainItem(key72_3, "witch house key")
        AddTip("You get the key to the witch's house.")
    End Sub

    Private Sub chicken72_2_Click(sender As Object, e As EventArgs) Handles chicken72_2.Click
        If Enable() = False Then Exit Sub
        If Not mute.Checked Then _
            My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound39.wm")
        If MsgBox("Do you want to catch the chicken?", vbYesNo, "Confirm") = vbYes Then
            Hide()
            Form7.Show()
            Form7.initialization(shield_level, weapon_level, 0, 350 + shield_level*150, 400, 20, 0, 110, 0, 900)
            music.settings.setMode("loop", True)
            music.settings.volume = 100
            music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music8.wm"
        End If
    End Sub

    Private Sub arrow73_1_Click(sender As Object, e As EventArgs) Handles arrow73_1.Click
        Scene050appears()
    End Sub

    Private Sub arrow79_1_Click(sender As Object, e As EventArgs) Handles arrow79_1.Click
        If backward.Visible And backward.Tag = 79 Then
            Scene055appears()
            If PictureBox3.Tag = 34 Then
                PictureBox3.Tag = 35
                Disappear2()
                MoveSpeed = 3
                actor.Visible = True
                actor.Image =
                    Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image27.wm")
                actor.Tag = 2
                actor.Top = Height
                MoveAtropos.Tag = 7550
                MoveAtropos.Enabled = True
            End If
        ElseIf backward.Visible = False And backward.Tag = 81 Then
            If lock81_2.Visible Then
                If SelectedItemIs("scissors") Then
                    UseItem(lock81_2, 38)
                ElseIf SelectedItemIs("saw") Then
                    deselect()
                    AddTip("It is too thick, scissors are enough.")
                ElseIf SelectedItemIs() Then
                    deselect()
                    AddTip("unable")
                Else
                    AddTip("the door is locked by a paper tape.")
                End If
            Else
                Scene061appears()
            End If
        End If
    End Sub

    Private Sub downward81_1_Click(sender As Object, e As EventArgs) Handles downward81_1.Click
        If Enable() = False Then Exit Sub
        If backward.Visible = False And backward.Tag = 81 Then
            Scene055appears()
        End If
    End Sub

    Private Sub arrow81_3_Click(sender As Object, e As EventArgs) Handles arrow81_3.Click
        If Enable() = False Then Exit Sub
        If backward.Visible = False And backward.Tag = 81 Then
            Scene057appears()
        ElseIf backward.Visible And backward.Tag = 90 Then
            Scene066appears()
        ElseIf backward.Tag = 97 Then
            Scene073appears()
        End If
    End Sub

    Private Sub answer73_3_Click(sender As Object, e As EventArgs) Handles answer73_3.Click
        If Enable() = False Then Exit Sub
        If SelectedItemIs("carbolic stick") Then
            UseItem(answer73_3, 30)
        ElseIf SelectedItemIs("red stick") Then
            UseItem(answer73_3, 31)
        Else
            AddTip("It's too high to reach.")
        End If
    End Sub

    Private Sub arrow82_1_Click(sender As Object, e As EventArgs) Handles arrow82_1.Click
        If backward.Visible = False And backward.Tag = 82 Then
            Scene056appears()
            If PictureBox3.Tag = 36 Then
                PictureBox3.Tag = 37
                Disappear2()
                actor.Visible = True
                actor.Top = 0
                MoveAtropos.Tag = 7825
                MoveAtropos.Enabled = True
            End If
        End If
    End Sub

    Private Sub letter82_2_Click(sender As Object, e As EventArgs) Handles letter82_2.Click
        If Enable() = False Then Exit Sub
        RemoveOut(letter82_2)
        Disappear2()
        shining.Enabled = True
        shining.Interval = 200
        shining.Tag = 0
        DeathFlagNum = 0
        actor.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image8.wm")
        If mute.Checked = False Then _
            My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound51.wm")
    End Sub

    Private Sub bow92_2_Click(sender As Object, e As EventArgs) Handles bow92_2.Click
        If Enable() = False Then Exit Sub
        RemoveOut(bow92_2)
        GainItem(bow92_2, "bow")
        AddTip("You get the bow.")
    End Sub

    Private Sub arrow92_3_Click(sender As Object, e As EventArgs) Handles arrow92_3.Click
        If Enable() = False Then Exit Sub
        RemoveOut(arrow92_3)
        GainItem(arrow92_3, "Mr.Duck vector")
        AddTip("You get Mr.Duck vector.")
    End Sub

    Private Sub arrow92_1_Click(sender As Object, e As EventArgs) Handles arrow92_1.Click
        If Enable() = False Then Exit Sub
        Scene032appears()
    End Sub

    Private Sub card81_3_Click(sender As Object, e As EventArgs) Handles card81_3.Click
        If Enable() = False Then Exit Sub
        RemoveOut(card81_3)
        GainItem(card81_3, "access card of Aurora's room")
        AddTip("You get access card of Aurora's room.")
    End Sub

    Private Sub box85_1_Click(sender As Object, e As EventArgs) Handles box85_1.Click
        If Enable() = False Then Exit Sub
        RemoveOut(box85_1)
        GainItem(box85_1, "paper box")
        AddTip("You get the paper box.")
    End Sub

    Private Sub chest74_1_Click(sender As Object, e As EventArgs) Handles chest74_1.Click
        If Enable() = False Then Exit Sub
        If SelectedItemIs("golden apple") Then
            UseItem(chest74_1, 32)
        ElseIf SelectedItemIs() Then
            deselect()
            AddTip("It cannot open the box.")
        Else
            AddTip("A golden apple is required.")
        End If
    End Sub

    Private Sub colloid84_1_Click(sender As Object, e As EventArgs) Handles colloid84_1.Click
        If Enable() = False Then Exit Sub
        RemoveOut(colloid84_1)
        GainItem(colloid84_1, "magical colloid")
        AddTip("You get the magical colloid.")
    End Sub

    Private Sub gas87_1_Click(sender As Object, e As EventArgs) Handles gas87_1.Click
        If Enable() = False Then Exit Sub
        RemoveOut(gas87_1)
        GainItem(gas87_1, "liquid nitrogen")
        AddTip("You get the liquid nitrogen.")
    End Sub

    Private Sub paper87_2_Click(sender As Object, e As EventArgs) Handles paper87_2.Click
        Hide()
        Form15.Show()
        Form15.ChangeImage(23)
    End Sub

    Private Sub ghostbox86_1_Click(sender As Object, e As EventArgs) Handles ghostbox86_1.Click
        If Enable() = False Then Exit Sub
        If Not Unlocked.Items.Contains("ghost meet") Then
            Disappear2()
            Unlocked.Items.Add("ghost meet")
            actor.Image =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image32.wm")
            dialogue.ForeColor = Color.Black
            MoveAtropos.Tag = 8075
            actor.Top = Height
            MoveSpeed = 2
            actor.Visible = True
            dialogue.Visible = False
            MoveAtropos.Enabled = True
        Else
            If SelectedItemIs("final examination paper") Then
                UseItem(ghostbox86_1, 52)
            Else
                deselect()
                AddTip("The ghost needs math final examination paper to revive.")
            End If
        End If
    End Sub

    Private Sub arrow99_1_Click(sender As Object, e As EventArgs) Handles arrow99_1.Click
        If Enable() = False Then Exit Sub
        Scene075appears()
    End Sub

    Private Sub arrow101_2_Click(sender As Object, e As EventArgs) Handles arrow101_2.Click
        If Enable() = False Then Exit Sub
        Scene077appears()
    End Sub

    Private Sub arrow103_1_Click(sender As Object, e As EventArgs) Handles arrow103_1.Click
        If Enable() = False Then Exit Sub
        Scene083appears()
    End Sub

    Private Sub arrow105_1_Click(sender As Object, e As EventArgs) Handles arrow105_1.Click
        If Enable() = False Then Exit Sub
        Scene081appears()
    End Sub

    Private Sub teleporter95_1_Click(sender As Object, e As EventArgs) Handles teleporter95_1.Click
        If backward.Tag = 95 Then
            If Unlocked.Items.Contains("mirror1deflect") Then
                If SelectedItemIs("trailer with mirror") Then
                    UseItem(teleporter95_1, 59)
                ElseIf SelectedItemIs("mirror") Then
                    UseItem(teleporter95_1, 60)
                Else
                    AddTip("You may need to put the mirror back.")
                End If
                Exit Sub
            Else
                If SelectedItemIs("portable trailer") Then
                    UseItem(teleporter95_1, 61)
                    Exit Sub
                End If
            End If
            DeathFlagNum = 9
        ElseIf backward.Tag = 97 Then
            If Unlocked.Items.Contains("mirror2deflect") Then
                If SelectedItemIs("trailer with mirror") Then
                    UseItem(teleporter95_1, 62)
                ElseIf SelectedItemIs("mirror") Then
                    UseItem(teleporter95_1, 63)
                Else
                    AddTip("You may need to put the mirror back.")
                End If
                Exit Sub
            Else
                If SelectedItemIs("portable trailer") Then
                    UseItem(teleporter95_1, 64)
                    Exit Sub
                End If
            End If
            DeathFlagNum = 10
        End If
        Disappear2()
        shining.Tag = 0
        shining.Enabled = True
        shining.Interval = 200
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image8.wm")
        If mute.Checked = False Then _
            My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound51.wm")
    End Sub

    Private Sub card96_1_Click(sender As Object, e As EventArgs) Handles card96_1.Click
        If Enable() = False Then Exit Sub
        RemoveOut(card96_1)
        GainItem(card96_1, "static card")
        AddTip("You get the static card.")
    End Sub

    Private Sub box98_1_Click(sender As Object, e As EventArgs) Handles box98_1.Click
        If Unlocked.Items.Contains("open HF box") Then
            RemoveOut(box98_1)
            GainItem(box98_1, "hydrofluoric acid")
            actor.Image = Nothing
            actor.Top = 0
            actor.Visible = True
            MoveAtropos.Tag = 10200
            MoveAtropos.Enabled = True
        Else
            If SelectedItemIs("screwdriver") Then
                UseItem(box98_1, 46)
            ElseIf SelectedItemIs("scissors") Then
                deselect()
                AddTip("The plank on the box is very, very thick. The same to the nails.")
            ElseIf SelectedItemIs() Then
                deselect()
                AddTip("Not this tool.")
            Else
                AddTip("There are words ""hazardous chemicals"" on the box. You need tool to open it.")
            End If
        End If
    End Sub

    Private Sub box100_1_Click(sender As Object, e As EventArgs) Handles box100_1.Click
        If SelectedItemIs("duck function") Then
            UseItem(box100_1, 47)
        ElseIf SelectedItemIs() Then
            deselect()
            AddTip("It needs only duck function. I promise.")
        Else
            AddTip("The box said it will open, as long as you give it the duck function.")
        End If
    End Sub

    Private Sub paper98_2_Click(sender As Object, e As EventArgs) Handles paper98_2.Click
        If Enable() = False Then Exit Sub
        RemoveOut(paper98_2)
        GainItem(paper98_2, "paper")
    End Sub

    Private Sub machine102_1_Click(sender As Object, e As EventArgs) Handles machine102_1.Click
        If Enable() = False Then Exit Sub
        If Unlocked.Items.Contains("electricity of gambling machine") Then
            If Unlocked.Items.Contains("lucky draw") Then
                AddTip("You've already gotten the duck function.")
                Exit Sub
            End If
            Disappear2()
            GroupBox2.Visible = True
            GroupBox2.Location = New Point(0, 0)
            GroupBox2.Size = New Size(PictureBox3.Width, PictureBox3.Height)
            upperline.BringToFront()
            downline.BringToFront()
            GroupBox3.BringToFront()
            drawer1.Top = 113
            drawer2.Top = 193
            drawer3.Top = 273
            drawer4.Top = 353
            Label2.BringToFront()
            Label6.BringToFront()
            Label4.BringToFront()
            Label3.BringToFront()
            Button9.Enabled = False
            drawit.Enabled = True
            gobackdraw.Enabled = True
            headdraw.Text = "draw a lottery! If you get the duck, you can get the duck function."
            Drawer = {drawer1, drawer2, drawer3, drawer4}
            Dim random_ As String = GenerateRandom(4, "0,1,2,3,4,5,6")
            Dim numbercount As Integer = - 1
            For Each draweritem In Drawer
                numbercount += 1
                draweritem.SizeMode = PictureBoxSizeMode.StretchImage
                Dim complex_or_simple As Integer = random_.Substring(numbercount, 1)
                draweritem.Image = ImageList2.Images(complex_or_simple)
                draweritem.Tag = random_.Substring(numbercount, 1)
            Next
            drawer3.Image = Nothing
            drawer3.Tag = - 1
        Else
            If SelectedItemIs("battery") Then
                UseItem(machine102_1, 48)
            Else
                AddTip("There isn't electricity in the machine.")
            End If
        End If
    End Sub

    Function GenerateRandom(Length As Integer, strtemp As String) As String
        Dim constant() As String = Nothing
        constant = strtemp.Split(",")
        Dim NewRandom = New StringBuilder(Length)
        Dim rd = New Random()
        Dim i As Integer
        For i = 0 To Length - 1 Step i + 1
            NewRandom.Append(constant(rd.Next(constant.Length - 1)))
        Next
        Return NewRandom.ToString()
    End Function

    Private Sub drawit_Click(sender As Object, e As EventArgs) Handles drawit.Click
        If Enable() = False Then Exit Sub
        drawit.Enabled = False
        gobackdraw.Enabled = False
        headdraw.Text = "The rotary table is rotating..."
        drawtime.Tag = 0
        drawtime.Enabled = True
    End Sub

    Private Sub gobackdraw_Click(sender As Object, e As EventArgs) Handles gobackdraw.Click
        If Enable() = False Then Exit Sub
        GroupBox2.Visible = False
        Scene077appears()
    End Sub

    Private Sub drawtime_Tick(sender As Object, e As EventArgs) Handles drawtime.Tick
        drawtime.Tag += 1
        For Each draweritem In Drawer
            If drawtime.Tag >= 300 Then
                draweritem.Top += 1
            ElseIf drawtime.Tag >= 200 Then
                draweritem.Top += (300 - drawtime.Tag)/10 + 1
            Else
                draweritem.Top += 10
            End If
            If draweritem.Top > 433 - 10 And draweritem.Top < 433 + 10 Then
                draweritem.Top = 113
                Dim random_ As String = GenerateRandom(5, "0,1,2,3,4,5,6")
                random_ = random_.ToString.Substring(New Random(Now.Date.Second).Next(0, 5), 1)
                Dim random2 As Integer = random_
                draweritem.Image = ImageList2.Images(random2)
                draweritem.Tag = random2
            End If
        Next
        If _
            drawtime.Tag >= 300 AndAlso Not ChosenDrawer().name = PictureBox3.Name AndAlso Not ChosenDrawer.tag = 5 AndAlso
            (drawtime.Tag >= 400 OrElse GenerateRandom(1, "0,1,2") = 0) Then
            drawtime.Tag = 0
            drawtime.Enabled = False
            headdraw.Text = "The next time you will be more lucky."
            gobackdraw.Enabled = True
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If ChosenDrawer.tag <> 5 Then
            MsgBox("Do not modify the status of button.", 16, "Error")
            Exit Sub
        End If
        If Enable() = False Then Exit Sub
        items.Items.Remove("eraser")
        items.Items.Remove("palette")
        If items.Items.Contains("painting tool") Then
            items.Items.Remove("painting tool")
            items.Items.Add("carbolic stick")
        End If
        If mute.Checked = False Then _
            My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound61.wm")
        AddTip("You are so lucky! You get the final exam paper!")
        GroupBox2.Visible = False
        Scene077appears()
        Unlocked.Items.Add("lucky draw")
        GainItem(machine102_1, "final examination paper")
    End Sub

    Private Sub drawer1_Click(sender As Object, e As EventArgs) Handles drawer1.Click
        AffectOnDrawer(drawer1)
    End Sub

    Private Sub drawer2_Click(sender As Object, e As EventArgs) Handles drawer2.Click
        AffectOnDrawer(drawer2)
    End Sub

    Private Sub drawer3_Click(sender As Object, e As EventArgs) Handles drawer3.Click
        AffectOnDrawer(drawer3)
    End Sub

    Private Sub drawer4_Click(sender As Object, e As EventArgs) Handles drawer4.Click
        AffectOnDrawer(drawer4)
    End Sub

    Private Sub eraser107_3_Click(sender As Object, e As EventArgs) Handles eraser107_3.Click
        If Enable() = False Then Exit Sub
        RemoveOut(eraser107_3)
        GainItem(eraser107_3, "eraser")
    End Sub

    Private Sub password98_2_Click(sender As Object, e As EventArgs) Handles password98_3.Click
        If Enable() = False Then Exit Sub
        RemoveOut(password98_3)
        GainItem(password98_3, "Aurora's password")
    End Sub

    Private Sub arrow98_4_Click(sender As Object, e As EventArgs) Handles arrow98_4.Click
        If Enable() = False Then Exit Sub
        Scene072appears()
    End Sub

    Private Sub potion94_2_Click(sender As Object, e As EventArgs) Handles potion94_2.Click
        If Enable() = False Then Exit Sub
        RemoveOut(potion94_2)
        GainItem(potion94_2, "package")
    End Sub

    Private Sub vortex106_1_Click(sender As Object, e As EventArgs) Handles vortex106_1.Click
        If Enable() = False Then Exit Sub
        Disappear2()
        DeathFlagNum = 11
        shining.Tag = 0
        shining.Enabled = True
        shining.Interval = 200
        PictureBox3.Image =
            Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image8.wm")
        If mute.Checked = False Then _
            My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound51.wm")
    End Sub

    Private Sub printer107_2_Click(sender As Object, e As EventArgs) Handles printer107_2.Click
        If Enable() = False Then Exit Sub
        If Unlocked.Items.Contains("ink") = False Then
            If SelectedItemIs("ink cartridge") Then
                UseItem(printer107_2, 54)
            Else
                AddTip("The printer needs ink.")
            End If
        ElseIf Unlocked.Items.Contains("paper inserted") = False Then
            If SelectedItemIs("paper") Then
                UseItem(printer107_2, 55)
            Else
                AddTip("The printer needs paper to print.")
            End If
        Else
            If Unlocked.Items.Contains("printed") Then
                AddTip("You had already printed the file needed (the duck function).")
            Else
                AddTip("If you want to print, open the computer, click on the file you want to print.")
            End If
        End If
    End Sub

    Private Sub computer107_1_Click(sender As Object, e As EventArgs) Handles computer107_1.Click
        If SelectedItemIs("USB") Then
            UseItem(computer107_1, 58)
        Else
            Hide()
            Form17.Show()
            If Not Unlocked.Items.Contains("Internet") Then Unlocked.Items.Add("Internet")
            Form17.ToIcon3()
        End If
    End Sub

    Private Sub gem101_1_Click(sender As Object, e As EventArgs) Handles gem101_1.Click
        If Unlocked.Items.Contains("break gem") Then
            AddTip("Atropos's nuclear gem.")
        Else
            If SelectedItemIs("hydrofluoric acid") Then
                UseItem(gem101_1, 56)
            ElseIf SelectedItemIs Then
                deselect()
                AddTip("No effect.")
            Else
                AddTip("Atropos's nuclear gem.")
            End If
        End If
    End Sub

    Private Sub safe67_3_Click(sender As Object, e As EventArgs) Handles safe67_3.Click
        If Enable() = False Then Exit Sub
        If Unlocked.Items.Contains("open safe") Then
            AddTip("Opened.")
        Else
            If SelectedItemIs("Aurora's password") Then
                UseItem(safe67_3, 57)
            ElseIf SelectedItemIs() Then
                deselect()
                AddTip("This is not a password.")
            Else
                AddTip("It needs password. If you have it, use it on the safe.")
            End If
        End If
    End Sub

    Private Sub statue_fault_Click(sender As Object, e As EventArgs) Handles statue_fault.Click
        If Enable() = False Then Exit Sub
        If Not Unlocked.Items.Contains("defeat Medusa") Then
            Unlocked.Items.Add("defeat Medusa")
            Disappear2()
            MoveSpeed = 2
            actor.Top = Height
            actor.Image =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image36.wm")
            dialogue.Visible = False
            actor.Visible = True
            MoveAtropos.Tag = 10625
            MoveAtropos.Enabled = True
        Else
            RemoveOut(statue_fault)
            GainItem(statue_fault, "XuTianhao artifact -2")
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound63.wm")
        End If
    End Sub

    Private Sub ladder106_fault_Click(sender As Object, e As EventArgs) Handles ladder106_fault.Click
        If Enable() = False Then Exit Sub
        If MsgBox("Do you want to climb up the ladder?", vbYesNo, "Climb up") = vbYes Then
            AddTip("Nothing upper the ladder.")
        Else
            If MsgBox("Do you want to get the ladder?", vbYesNo + MsgBoxStyle.DefaultButton2, "Ladder") = vbYes Then
                RemoveOut(ladder106_fault)
                GainItem(ladder106_fault, "ladder")
            End If
        End If
    End Sub

    Private Sub trailer92_1_Click(sender As Object, e As EventArgs) Handles trailer92_1.Click
        If Enable() = False Then Exit Sub
        RemoveOut(trailer92_1)
        GainItem(trailer92_1, "portable trailer")
    End Sub

    Private Sub answerbox_TextChanged(sender As Object, e As EventArgs) Handles answerbox.TextChanged
        Dim temp As Integer = answerbox.SelectionStart
        answerbox.Text = answerbox.Text.Replace(" ", "")
        answerbox.Text = answerbox.Text.Replace("＋", "+")
        answerbox.Text = answerbox.Text.Replace("—", "-")
        answerbox.Text = answerbox.Text.Replace("×", "x")
        answerbox.Text = answerbox.Text.Replace("÷", "/")
        answerbox.Text = answerbox.Text.Replace("（", "(")
        answerbox.Text = answerbox.Text.Replace("）", ")")
        answerbox.Text = answerbox.Text.Replace("【", "[")
        answerbox.Text = answerbox.Text.Replace("】", "]")
        answerbox.Text = answerbox.Text.Replace("，", ",")
        answerbox.Text = answerbox.Text.Replace("。", ".")
        answerbox.Text = answerbox.Text.Replace("pai", "π")
        answerbox.Text = answerbox.Text.Replace("miu", "μ")
        answerbox.Text = answerbox.Text.Replace("fai", "φ")
        answerbox.Text = answerbox.Text.ToLower()
        If answerbox.Text = "" Then answerclear.Enabled = False Else answerclear.Enabled = True
        If answerbox.Text = "" Then answerbutton.Enabled = False Else answerbutton.Enabled = True
        If answerbox.TextLength < 23 Then GroupBox5.Enabled = True Else GroupBox5.Enabled = False
        answerbox.SelectionStart = temp
        answerbox.ScrollToCaret()
        answerbox.Focus()
    End Sub

    Private Sub answerbutton_Click(sender As Object, e As EventArgs) Handles answerbutton.Click
        If answerworm.Visible Then
            MoveAtropos.Enabled = False
            AddTip("Your answer is correct.")
            MsgBox("Your answer is correct.", 0, "Correct!")
            GroupBox4.Visible = False
            MoveAtropos.Tag = 15400
            MoveAtropos.Enabled = True
        Else
            answerbox.Clear()
            AddTip("Your answer is incorrect.")
        End If
    End Sub

    Private Sub InsertText(char_ As String)
        Dim temp As Integer = answerbox.SelectionStart
        If answerbox.TextLength < 23 Then answerbox.Text = answerbox.Text.Insert(answerbox.SelectionStart, char_)
        answerbox.SelectionStart = temp + 1
        answerbox.ScrollToCaret()
        answerbox.Focus()
    End Sub

    Private Sub key1_Click(sender As Object, e As EventArgs) Handles key1.Click
    End Sub

    Private Sub key2_Click(sender As Object, e As EventArgs) Handles key2.Click
        InsertText("-")
    End Sub

    Private Sub key3_Click(sender As Object, e As EventArgs) Handles key3.Click
        InsertText("x")
    End Sub

    Private Sub key4_Click(sender As Object, e As EventArgs) Handles key4.Click
        InsertText("/")
    End Sub

    Private Sub key5_Click(sender As Object, e As EventArgs) Handles key5.Click
        InsertText("(")
    End Sub

    Private Sub key6_Click(sender As Object, e As EventArgs) Handles key6.Click
        InsertText(")")
    End Sub

    Private Sub key7_Click(sender As Object, e As EventArgs) Handles key7.Click
        InsertText("π")
    End Sub

    Private Sub key8_Click(sender As Object, e As EventArgs) Handles key8.Click
        InsertText("[")
    End Sub

    Private Sub key9_Click(sender As Object, e As EventArgs) Handles key9.Click
        InsertText("]")
    End Sub

    Private Sub key10_Click(sender As Object, e As EventArgs) Handles key10.Click
        InsertText("√")
    End Sub

    Private Sub key11_Click(sender As Object, e As EventArgs) Handles key11.Click
        InsertText("^")
    End Sub

    Private Sub key12_Click(sender As Object, e As EventArgs) Handles key12.Click
        InsertText("∞")
    End Sub

    Private Sub answerclear_Click(sender As Object, e As EventArgs) Handles answerclear.Click
        If answerworm.Visible Then
            answerworm.Visible = False
            answerbox.Visible = True
            GainItem(answerbox, "Mr.Duck standard answer")
            GroupBox5.Enabled = True
        End If
        answerbox.Clear()
        answerclear.Enabled = False
    End Sub

    Private Sub chest82_3_Click(sender As Object, e As EventArgs) Handles chest82_3.Click
        If Enable() = False Then Exit Sub
        If SelectedItemIs("Aurora's password") Then
            UseItem(chest82_3, 51)
        ElseIf SelectedItemIs() Then
            deselect()
            AddTip("This is not a password.")
        Else
            AddTip("It needs password. If you have it, use it on the chest.")
        End If
    End Sub

    Private Sub duckfunction_Click(sender As Object, e As EventArgs) Handles duckfunction.Click
        If Enable() = False Then Exit Sub
        If SelectedItemIs("Mr.Duck standard answer") Then
            UseItem(answerbox, 68)
        End If
    End Sub

    Dim OneMeterPx As Double, MainTopSmallCount As Double, MainLeftSmallCount As Double

    Private Sub PhysicsButton_Click(sender As Object, e As EventArgs) Handles PhysicsButton.Click
        If PhysicsButton.Text = "Stop" Then
            MainBlock.Location = New Point(59, 124)
            MainBlock.Top = PhysicsUpperground.Top - MainBlock.Height
            frontbar.Visible = False
            frontbar.Tag = 0
            PhysicsTimetip.BackColor = Color.Blue
            PhysicsTimetick.ForeColor = Color.Blue
            PhysicsButton.Text = "Launch"
            PhysicsV0.Enabled = True
            PhysicsLabel1.Enabled = True
            PhysicsLabel2.Enabled = True
            MainTopSmallCount = 0
            MainLeftSmallCount = 0
            PhysicsTime.Tag = 1
            PhysicsTime.Enabled = True
        Else
            PhysicsV0.Enabled = False
            PhysicsLabel1.Enabled = False
            PhysicsLabel2.Enabled = False
            MainBlock.Tag = 0
            PhysicsMain.Enabled = True
            PhysicsButton.Enabled = False
        End If
    End Sub

    Private Sub PhysicsGround_Click(sender As Object, e As EventArgs) Handles PhysicsGround.Click
        If PhysicsButton.Text = "Stop" Then Exit Sub
        PhysicsGround.Tag = 0
        PhysicsTime.Enabled = True
    End Sub

    Private Sub TimerPhysics_Tick(sender As Object, e As EventArgs) Handles PhysicsTime.Tick
        If PhysicsGround.Tag = 0 Then
            If PhysicsGround.Top > 300 Then
                PhysicsGround.Top -= 2
                PhysicsMiddle.Height -= 2
            Else
                PhysicsGround.Tag = 1
            End If
        Else
            If PhysicsGround.Top >= 383 Then
                PhysicsTime.Enabled = False
            Else
                PhysicsGround.Top += 2
                PhysicsMiddle.Height += 2
            End If
        End If
    End Sub

    Private Sub PhysicsMain_Tick(sender As Object, e As EventArgs) Handles PhysicsMain.Tick
        Dim TimeShrink = 40
        OneMeterPx = (Physics2Ground.Bottom - PhysicsTemp1.Top)/66.67
        If MainBlock.Left > PhysicsUpperground.Right Then MainBlock.Tag += 9.8/TimeShrink
        Dim RealBlockTop As Double = MainBlock.Tag*OneMeterPx/TimeShrink + MainTopSmallCount
        MainTopSmallCount = RealBlockTop - Int(RealBlockTop)
        MainBlock.Top += Int(RealBlockTop)
        Dim RealBlockLeft As Double = PhysicsV0.Value*OneMeterPx/TimeShrink + MainLeftSmallCount
        MainLeftSmallCount = RealBlockLeft - Int(RealBlockLeft)
        MainBlock.Left += Int(RealBlockLeft)
        If MainBlock.Bottom >= PhysicsGround.Top Then
            MainBlock.Top = PhysicsGround.Top - MainBlock.Height
            PhysicsMain.Enabled = False
            PhysicsButton.Text = "Stop"
            PhysicsButton.Enabled = True
            PhysicsTime.Enabled = False
            If PhysicsTimetip.BackColor = Color.Green Then
                MoveAtropos.Enabled = False
                AddTip("Great! You did it!")
                MsgBox("You did it! You successfully let the object hit the ground in 3 seconds!!", 0, "Success!")
                Physics.Visible = False
                MoveAtropos.Tag = 18175
                MoveAtropos.Enabled = True
            End If
        Else
            frontbar.Tag += 1
            frontbar.Width = backbar.Width*frontbar.Tag/200
            frontbar.Visible = True
            If frontbar.Tag <= 120 Then
                PhysicsTimetip.BackColor = Color.Green
                PhysicsTimetick.ForeColor = Color.Green
            Else
                PhysicsTimetip.BackColor = Color.Red
                PhysicsTimetick.ForeColor = Color.Red
            End If
        End If
    End Sub

    Private Sub AffectOnDrawer(target As PictureBox)
        If drawtime.Enabled = False And gobackdraw.Enabled Then
            If SelectedItemIs("eraser") Then
                DrawerAffectTarget = target
                UseItem(target, 49)
            ElseIf SelectedItemIs("painting tool") Then
                If target.Tag = - 1 Then
                    DrawerAffectTarget = target
                    UseItem(target, 50)
                ElseIf target.Tag = 5 Then
                    deselect()
                    AddTip("This is already a duck.")
                Else
                    deselect()
                    AddTip("You should erase the original pattern first.")
                End If
            End If
        End If
    End Sub

    Private Sub paper87_3_Click(sender As Object, e As EventArgs) Handles paper87_3.Click
        Hide()
        Form15.Show()
        Form15.ChangeImage(24)
    End Sub

    Private Function ChosenDrawer()
        For Each draweritem In Drawer
            If draweritem.Top = 273 Then
                Return draweritem
            End If
        Next
        Return PictureBox3
    End Function

    Private Sub key71_1_Click(sender As Object, e As EventArgs) Handles key71_1.Click
        If Enable() = False Then Exit Sub
        RemoveOut(key71_1)
        GainItem(key71_1, "underwater cave key")
        AddTip("You get the underwater cave key.")
    End Sub

    Private Sub mp67_1_Click(sender As Object, e As EventArgs) Handles mp67_1.Click
        If Enable() = False Then Exit Sub
        RemoveOut(mp67_1)
        GainItem(mp67_1, "MP3 player")
        AddTip("You get an MP3 player.")
    End Sub

    Private Sub dive64_1_Click(sender As Object, e As EventArgs) Handles dive64_1.Click
        If Enable() = False Then Exit Sub
        If backward.Visible And backward.Tag = 86 Then
            If PictureBox3.Tag > 42 Then
                AddTip("You've already gotten the key.")
            Else
                Disappear2()
                backward.Tag = - 1
                backward.Visible = True
                PictureBox3.Image =
                    Image.FromFile(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image" &
                        Math.Max(29, PictureBox3.Tag - 11) & ".wm")
                AddTip("The mould can be used to make an magical key.")
            End If
        Else
            If SelectedItemIs("portable submarine") Then
                UseItem(dive64_1, 18)
            Else
                AddTip("You can't dive.")
            End If
        End If
    End Sub

    Private Sub arrow54_1_Click(sender As Object, e As EventArgs) Handles arrow54_1.Click
        If Enable() = False Then Exit Sub
        Scene030appears()
        If PictureBox3.Tag = 13 Then
            PictureBox3.Tag = 14
            Disappear2()
            actor.Visible = True
            actor.Top = 0
            MoveAtropos.Enabled = True
        End If
    End Sub

    Private Function MixThings(target As PictureBox)
        If Enable() = False Then Return False
        Dim source As PictureBox
        For x = 0 To 4
            If ItemBox(x).BackColor = Color.Yellow Then source = ItemBox(x)
        Next
        If _
            Unlocked.Items.Contains("recipe") And target.Tag.ToString.Split("/")(1) = "carbolic stick" And
            SelectedItemIs("chicken blood") Then
            Mix(source, target, "red stick")
            AddTip("You dip the stick into the blood.")
            Return True
        ElseIf _
            Unlocked.Items.Contains("recipe") And target.Tag.ToString.Split("/")(1) = "chemistry test paper" And
            SelectedItemIs("red stick") Then
            Mix(source, target, "chemistry test paper (passed)", True)
            AddTip("The chemistry flunked test paper is rewritten.")
            Return True
        ElseIf _
            Unlocked.Items.Contains("recipe") And target.Tag.ToString.Split("/")(1) = "physics test paper" And
            SelectedItemIs("red stick") Then
            Mix(source, target, "physics test paper (passed)", True)
            AddTip("The physics flunked test paper is rewritten.")
            Return True
        ElseIf target.Tag.ToString.Split("/")(1) = "solar shell" And SelectedItemIs("liquefied chlorine") Then
            Mix(source, target, "solar ball")
            AddTip("You get the solar ball.")
            Return True
        ElseIf target.Tag.ToString.Split("/")(1) = "chicken" And SelectedItemIs("duck pool water") Then
            Mix(source, target, "shrinking potion")
            AddTip("You get the shrinking potion.")
            Return True
        ElseIf target.Tag.ToString.Split("/")(1) = "MP3 player" And SelectedItemIs("SixGod SD card") Then
            If (backward.Tag >= 65 And backward.Tag <= 68) Or (backward.Tag >= 72 And backward.Tag <= 74) Then
                Mix(source, target, "MP3 player with SixGod")
                AddTip("You put the SixGod SD card into MP3 player.")
                Unable = True
                Return True
            Else
                AddTip("You should do it underwater, and near the door which tells you to attract the mermaid.")
                Return False
            End If
        ElseIf target.Tag.ToString.Split("/")(1) = "bow" And SelectedItemIs("Mr.Duck vector") Then
            Mix(source, target, "duck vector launcher")
            AddTip("You get the duck vector launcher.")
            Return True
        ElseIf target.Tag.ToString.Split("/")(1) = "paper box" And SelectedItemIs("scissors") Then
            Mix(source, target, "sodium hydroxide", True)
            AddTip("You cut the box and get the sodium hydroxide in the paper box.")
        ElseIf _
            Unlocked.Items.Contains("recipe") And target.Tag.ToString.Split("/")(1) = "painting tool" And
            SelectedItemIs("chicken blood") Then
            Mix(source, target, "red stick")
            items.Items.Add("palette")
        ElseIf target.Tag.ToString.Split("/")(1) = "palette" And SelectedItemIs("red stick") Then
            Mix(source, target, "painting tool")
            items.Items.Add("chicken blood")
        ElseIf target.Tag.ToString.Split("/")(1) = "palette" And SelectedItemIs("carbolic stick") Then
            Mix(source, target, "painting tool")
        ElseIf target.Tag.ToString.Split("/")(1) = "package" And SelectedItemIs("scissors") Then
            Mix(source, target, "magic dispeller", True)
            AddTip("You cut the box and get the magic dispeller in the paper box.")
        ElseIf _
            target.Tag.ToString.Split("/")(1) = "XuTianhao artifact -2" And
            SelectedItemIs("physics test paper (passed)") Then
            Mix(source, target, "XuTianhao artifact -1")
        ElseIf _
            target.Tag.ToString.Split("/")(1) = "XuTianhao artifact -2" And
            SelectedItemIs("chemistry test paper (passed)") Then
            Mix(source, target, "XuTianhao artifact -1")
        ElseIf _
            target.Tag.ToString.Split("/")(1) = "XuTianhao artifact -1" And
            SelectedItemIs("physics test paper (passed)") Then
            Mix(source, target, "XuTianhao artifact")
        ElseIf _
            target.Tag.ToString.Split("/")(1) = "XuTianhao artifact -1" And
            SelectedItemIs("chemistry test paper (passed)") Then
            Mix(source, target, "XuTianhao artifact")
        Else
            Return False
        End If
    End Function

    Private Sub Mix(source As PictureBox, target As PictureBox, resultant As String,
                    Optional ByVal recycle As Boolean = False)
        MoveTarget = target
        MovingItem.SizeMode = PictureBoxSizeMode.Zoom
        MovingItem.Size = New Size(source.Width, source.Height)
        MovingItem.Location = New Point(source.Left + itemlist.Left, source.Top + itemlist.Top)
        MovingItem.BorderStyle = BorderStyle.FixedSingle
        MovingItem.BackColor = Color.Yellow
        MovingItem.Image = source.Image
        If Not recycle Then items.Items.Remove(source.Tag.ToString.Split("/")(1))
        Dim origin As String = target.Tag.ToString.Split("/")(1)
        RefreshItems()
        items.Items.Remove(origin)
        If resultant = "MP3 player with SixGod" Then MP3mixture = True
        MovingItem.Visible = True
        MovingItem.Tag = resultant
        Controls.Add(MovingItem)
        MovingItem.BringToFront()
        MoveItem.Enabled = True
        MoveItem.Tag = 0
        If Not mute.Checked And Not actor.Visible Then _
            My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound50.wm")
    End Sub

    Private Sub answerbox_Click(sender As Object, e As EventArgs) Handles answerbox.Click
        If Enable() = False Then Exit Sub
        If SelectedItemIs("Mr.Duck standard answer") Then
            UseItem(answerbox, 68)
        End If
    End Sub

    Dim Blocks() As Label,
        MouseX As Integer,
        MouseY As Integer,
        MoveX1 As Double,
        MoveY1 As Double,
        MoveX2 As Double,
        MoveY2 As Double,
        TransportX As Double,
        Ground1 As Boolean = False,
        Ground2 As Boolean = False,
        Point01 As Single,
        Point02 As Single,
        EndTime As Single = 0

    Dim ReadOnly rCycleTime(1, 1) As Integer
    Dim ReadOnly rCyclingNumber(1, 1, 1) As Single
    Dim ReadOnly rCycled(1, 1) As Boolean
    Dim ReadOnly rAgain(1, 1) As Boolean
    Public NoMoreForm1 As Boolean = False

    Private Sub card107_x_Click(sender As Object, e As EventArgs) Handles card107_x.Click
        If Enable() = False Then Exit Sub
        RemoveOut(card107_x)
        GainItem(card107_x, "mirror card")
    End Sub

    Private Sub Physics_μ_Click(sender As Object, e As EventArgs) Handles Physics_μ.Click
        If SelectedItemIs("red stick") Then UseItem(Physics_μ, 69)
    End Sub

    Private Sub MainBlock2_Click(sender As Object, e As EventArgs) Handles MainBlock2.Click
        MsgBox(MainBlock2.Location)
    End Sub

    Private Sub PhysicsAdd_Click(sender As Object, e As EventArgs) Handles PhysicsAdd.Click
        If _
            Physics2Launch.Text = "Stop" And stabber.Size = New Size(15, 16) And PhysicsTemp1.Text <= 3 And
            Not PhysicsAdd.BackColor = Color.Yellow Then
            PhysicsTemp1.Text += 10
            PhysicsAdd.ForeColor = Color.Black
            PhysicsAdd.BackColor = Color.Yellow
        End If
    End Sub

    Private Sub MoveBomb_Tick(sender As Object, e As EventArgs) Handles MoveBomb.Tick
        If PhysicsBomb.Visible Then
            PhysicsBomb.BringToFront()
            PhysicsBomb.Left = Math.Max(
                Math.Min(Physics2Ground.Right - PhysicsBomb.Width, Cursor.Position.X - Left - MouseX),
                Physics2Ground.Right/2)
            PhysicsBomb.Top = Math.Min(Math.Max(Cursor.Position.Y - Top - MouseY, PhysicsTemp1.Top),
                                       Physics2Ground.Bottom - PhysicsBomb.Height)
            If _
                PhysicsBomb.Bottom > block02.Top And PhysicsBomb.Top < block25.Bottom And
                PhysicsBomb.Right > block02.Left And PhysicsBomb.Left < block25.Right Then
                PhysicsBomb.BackColor = Color.Red
            Else
                PhysicsBomb.BackColor = Color.Black
            End If
        Else
            Dim Unable = 0
            For Each block In Blocks
                block.BringToFront()
                If block.Visible = False Then
                    Unable += 1
                    Continue For
                End If
                Randomize()
                block.Tag = block.Tag.ToString.Split(",")(0) & "," & block.Tag.ToString.Split(",")(1) + Rnd()*2.5
                Dim Move As Integer = block.Tag.ToString.Split(",")(1)
                If block.Tag.ToString.Split(",")(0) = 0 Then
                    block.Top += Move
                ElseIf block.Tag.ToString.Split(",")(0) = 1 Then
                    block.Left += Move
                ElseIf block.Tag.ToString.Split(",")(0) = 2 Then
                    block.Top += Move
                    block.Left += Move
                ElseIf block.Tag.ToString.Split(",")(0) = 3 Then
                    block.Top -= Move
                ElseIf block.Tag.ToString.Split(",")(0) = 4 Then
                    block.Left -= Move
                ElseIf block.Tag.ToString.Split(",")(0) = 5 Then
                    block.Top -= Move
                    block.Left -= Move
                End If
                If _
                    block.Bottom < startlabel.Top Or block.Top > Physics2Ground.Bottom Or
                    block.Right < physicstemp2.Left Or block.Left > PhysicsTemp1.Right Then block.Visible = False
            Next
            If Unable = Blocks.Count Then MoveBomb.Enabled = False
        End If
    End Sub

    Private Sub debug1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Blocks =
            {block01, block02, block03, block04, block05, block06, block07, block08, block09, block10, block11, block12,
             block13, block14, block15, block16, block17, block18, block19, block20, block21, block22, block23, block24,
             block25}
    End Sub

    Private Sub stabtime_Tick(sender As Object, e As EventArgs) Handles stabtime.Tick
        PhysicsTemp1.Text -= 1
        If PhysicsTemp1.Text = "0" Then stabtime.Enabled = False
    End Sub

    Private Sub PhysicsBomb_MouseDown(sender As Object, e As MouseEventArgs) Handles PhysicsBomb.MouseDown
        If Physics2Launch.Text = "Launch" Then
            MouseX = e.X
            MouseY = e.Y
            MoveBomb.Enabled = True
        End If
    End Sub

    Private Sub Physics2Launch_Click(sender As Object, e As EventArgs) Handles Physics2Launch.Click
        If Physics2Launch.Text = "Launch" Then
            frontbar1.Tag = "0"
            frontbar2.Tag = "0"
            Physics2Launch.Text = "Stop"
            MainBlock1.Tag = "0,0"
            MainBlock2.Tag = "0,0"
            stabtime.Enabled = True
            gravity.Enabled = False
            glabel1.Enabled = False
            glabel2.Enabled = False
            glabel3.Enabled = False
            frontbar1.Visible = True
            frontbar2.Visible = True
            PhysicsBomb.Location = New Point(477, 130)
            Physics2Main.Enabled = True
        Else
            MoverLeft.Tag = 0
            Physics2Launch.Text = "Launch"
            Physics2Main.Enabled = False
            stabtime.Enabled = False
            gravity.Enabled = True
            glabel1.Enabled = True
            glabel2.Enabled = True
            glabel3.Enabled = True
            frontbar1.Visible = False
            frontbar2.Visible = False
            PhysicsRocket.Visible = False
            MainBlock1.BackColor = Color.SaddleBrown
            MainBlock2.BackColor = Color.SaddleBrown
            EndTime = 0
            Ground1 = False
            Ground2 = False
            MainBlock1.Location = New Point(34, 123)
            MainBlock2.Location = New Point(283, 123)
            MoverLeft.Size = New Size(38, 16)
            MoverRight.Size = New Size(38, 16)
            MoverLeft.Location = New Point(20, 187)
            MoverRight.Location = New Point(57, 187)
            stabber.Location = New Point(328, 123)
            'stabber.Location = New Point(283, 123)
            stabber.Size = New Size(20, 16)
            'stabber.Size = New Size(64, 16)
            PhysicsRocket.Location = New Point(392, 267)
            PhysicsTemp1.Text = 3
            MainBlock1.Visible = True
            MainBlock2.Visible = True
            PhysicsInterval.Visible = False
            PhysicsIntervalFore.Visible = False
            Point01 = 0
            Point02 = 0
            PhysicsAdd.BackColor = Color.Black
            PhysicsAdd.ForeColor = Color.White
            rCycled(0, 0) = False
            rCycleTime(0, 0) = 0
            rCyclingNumber(0, 0, 0) = 0
            rCyclingNumber(0, 0, 1) = 0
            rCycled(1, 0) = False
            rCycleTime(1, 0) = 0
            rCyclingNumber(1, 0, 0) = 0
            rCyclingNumber(1, 0, 1) = 0
            rCycled(0, 1) = False
            rCycleTime(0, 1) = 0
            rCyclingNumber(0, 1, 0) = 0
            rCyclingNumber(0, 1, 1) = 0
            rCycled(1, 1) = False
            rCycleTime(1, 1) = 0
            rCyclingNumber(1, 1, 0) = 0
            rCyclingNumber(1, 1, 1) = 0
        End If
    End Sub

    Private Sub Physics2Main_Tick(sender As Object, e As EventArgs) Handles Physics2Main.Tick
        '调节时间间隙
        Dim TimeSet As Double = Physics2Main.Interval/1000
        '物体额外运动
        '传送带
        Dim TransporterSpeed As Double = Physics_v.Text.Split("=")(1).Split("m")(0)
        Transporter.Left += OneMeterPx*TransporterSpeed*TimeSet
        If _
            Transporter.Left > - OneMeterPx*TransporterSpeed*TimeSet And
            Transporter.Left < OneMeterPx*TransporterSpeed*TimeSet Then _
            Transporter.Left = PhysicsBlocker.Left - Transporter.Width
        '移动开关门
        If MoverLeft.Tag = 1 And MoverLeft.Width > 0 Then
            MoverLeft.Width -= 1
            MoverRight.Left += 1
            MoverRight.Width -= 1
        End If
        '移动火箭
        If PhysicsRocket.Visible Then
            PhysicsRocket.SendToBack()
            PhysicsRocket.Left -= 200*OneMeterPx*TimeSet
        End If
        '弹簧移动
        If PhysicsTemp1.Text = 0 And stabber.Width < 64 And stabber.Left >= MainBlock2.Right - MainBlock2.Width/3 Then
            stabber.Left -= 1
            stabber.Width += 1
        End If
        '两物体质量
        Dim m(1) As Single
        m(0) = 10
        m(1) = 10
        '碰撞时的反弹力度
        Dim rebounce As Single = 10
        '两个木块的摩擦因数
        Dim μm1m2 As Single = 0.03
        '对两个物体进行速度识别
        If frontbar1.Tag = - 1 Then
            frontbar1.Text = "Out of range"
        Else
            Dim Vm1 As Double =
                    Math.Pow(
                        Math.Pow(MainBlock1.Tag.ToString.Split(",")(0), 2) +
                        Math.Pow(MainBlock1.Tag.ToString.Split(",")(1), 2), 0.5)
            frontbar1.Text = Math.Round(Vm1, 1)
            If frontbar1.Text.Contains(".") = False And frontbar1.Text <> 0 Then frontbar1.Text = frontbar1.Text & ".0"
            If frontbar1.Text <> 0 Then frontbar1.Text = frontbar1.Text & "m/s"
            frontbar1.Width = (((- Math.Pow(1.04, - Vm1) + 1)*0.85) + 0.15)*backbar1.Width
            frontbar1.BackColor = Color.FromArgb(255*frontbar1.Width/backbar1.Width,
                                                 255*(1 - frontbar1.Width/backbar1.Width),
                                                 255*(1 - frontbar1.Width/backbar1.Width))
        End If
        If frontbar2.Tag = - 1 Then
            frontbar2.Text = "Out of range"
        Else
            Dim Vm2 As Double =
                    Math.Pow(
                        Math.Pow(MainBlock2.Tag.ToString.Split(",")(0), 2) +
                        Math.Pow(MainBlock2.Tag.ToString.Split(",")(1), 2), 0.5)
            frontbar2.Text = Math.Round(Vm2, 1)
            If frontbar2.Text.Contains(".") = False And frontbar2.Text <> 0 Then frontbar2.Text = frontbar2.Text & ".0"
            If frontbar2.Text <> 0 Then frontbar2.Text = frontbar2.Text & "m/s"
            frontbar2.Width = (((- Math.Pow(1.04, - Vm2) + 1)*0.85) + 0.15)*backbar2.Width
            frontbar2.BackColor = Color.FromArgb(255*frontbar2.Width/backbar2.Width,
                                                 255*(1 - frontbar2.Width/backbar1.Width),
                                                 255*(1 - frontbar2.Width/backbar2.Width))
        End If
        '移动两个物体
        Dim RealX1 As Double = MainBlock1.Tag.ToString.Split(",")(0)*OneMeterPx*TimeSet + MoveX1
        MoveX1 = RealX1 - Int(RealX1)
        Dim RealY1 As Double = MainBlock1.Tag.ToString.Split(",")(1)*OneMeterPx*TimeSet + MoveY1
        MoveY1 = RealY1 - Int(RealY1)
        'If Math.Abs(CType(MainBlock1.Tag.ToString.Split(",")(1), Double)) > 10 Then MsgBox(MainBlock1.Tag.ToString.Split(",")(1))
        Dim RealX2 As Double = MainBlock2.Tag.ToString.Split(",")(0)*OneMeterPx*TimeSet + MoveX2
        MoveX2 = RealX2 - Int(RealX2)
        Dim RealY2 As Double = MainBlock2.Tag.ToString.Split(",")(1)*OneMeterPx*TimeSet + MoveY2
        MoveY2 = RealY2 - Int(RealY2)
        MainBlock1.BringToFront()
        MainBlock2.BringToFront()
        If frontbar1.Text <> "Out of range" Then _
            MainBlock1.Location = New Point(MainBlock1.Left + Int(RealX1), MainBlock1.Top + Int(RealY1))
        If frontbar2.Text <> "Out of range" Then _
            MainBlock2.Location = New Point(MainBlock2.Left + Int(RealX2), MainBlock2.Top + Int(RealY2))
        '计算两个物体的加速度
        Dim acceleration(1, 1) As Single
        acceleration(0, 0) = 0
        acceleration(0, 1) = 0
        acceleration(1, 0) = 0
        acceleration(1, 1) = 0
        '对于
        Dim target As Integer = - 1
        For Each object_ As Control In {MainBlock1, MainBlock2}
            target += 1
            Dim power(1) As Single
            Dim resistance(1) As Single
            power(0) = 0
            power(1) = 0
            resistance(0) = 0
            resistance(1) = 0
            power(1) += gravity.Value
            Dim pressure As Single
            If Forced(MainBlock1, MainBlock2) Then pressure = m(0) + m(1) Else pressure = m(target)
            If Forced(object_, MoverLeft, ForceDirection.FromUp) Or Forced(object_, MoverRight, ForceDirection.FromUp) _
                Then
                '位于开关上
                power(1) -= gravity.Value
                object_.Top = MoverLeft.Top - object_.Height
                If IsIgnorable(object_.Tag.ToString.Split(",")(1), target, 1) Then
                    MoverLeft.Tag = 1
                    object_.Tag = object_.Tag.ToString.Split(",")(0) & "," & 0
                Else
                    power(1) -= object_.Tag.ToString.Split(",")(1)*rebounce
                End If
            End If
            If Forced(object_, Transporter, ForceDirection.FromUp) And object_.Left < PhysicsBlocker.Left Then
                '位于传送带上
                power(1) -= gravity.Value
                object_.Top = Transporter.Top - object_.Height
                If IsIgnorable(object_.Tag.ToString.Split(",")(1), target, 1) Then
                    object_.Tag = object_.Tag.ToString.Split(",")(0) & "," & 0
                Else
                    power(1) -= object_.Tag.ToString.Split(",")(1)*rebounce
                End If
                If Physics_μ.Text.Split("=")(1) <> 0 Then
                    If IsIgnorable(object_.Tag.ToString.Split(",")(0) - TransporterSpeed, target, 0) Then
                        object_.Tag = TransporterSpeed & "," & object_.Tag.ToString.Split(",")(1)
                    ElseIf object_.Tag.ToString.Split(",")(0) > TransporterSpeed Then
                        power(0) -= Physics_μ.Text.Split("=")(1)*pressure*gravity.Value
                    Else
                        power(0) += Physics_μ.Text.Split("=")(1)*pressure*gravity.Value
                    End If
                    If PhysicsBomb.Visible AndAlso object_.Left > PhysicsBlocker.Left/2 Then _
                        PhysicsRocket.Visible = True
                End If
            ElseIf Forced(object_, Transporter, ForceDirection.FromRight) And object_.Left < PhysicsBlocker.Left Then
                '从右侧撞传送带
                object_.Left = PhysicsBlocker.Left
                If IsIgnorable(object_.Tag.ToString.Split(",")(0), target, 0) Then
                    object_.Tag = 0 & "," & object_.Tag.ToString.Split(",")(1)
                Else
                    power(0) -= object_.Tag.ToString.Split(",")(0)*rebounce
                End If
            End If
            Dim subobject As Control
            If target = 0 Then subobject = MainBlock2 Else subobject = MainBlock1
            If PhysicsRocket.Visible AndAlso Forced(PhysicsRocket, object_) Then
                '撞上火箭
                power(0) -= 2000
                object_.Left = PhysicsRocket.Left - object_.Width
            End If
            If Forced(stabber, object_, ForceDirection.FromRight) Then
                '弹簧弹射
                power(0) -= (stabber.Width - 20)*10
            End If
            If Forced(object_, m2supporter, ForceDirection.FromUp) Then
                '上层平面降落
                If IsIgnorable(object_.Tag.ToString.Split(",")(0), target, 0) Then
                    object_.Tag = 0 & "," & object_.Tag.ToString.Split(",")(1)
                Else
                    resistance(0) += upperμ.Text.Split("=")(1)*pressure*gravity.Value
                End If
                power(1) -= gravity.Value
                object_.Top = m2supporter.Top - object_.Height
                If IsIgnorable(object_.Tag.ToString.Split(",")(1), target, 1) Then
                    object_.Tag = object_.Tag.ToString.Split(",")(0) & "," & 0
                Else
                    power(1) -= object_.Tag.ToString.Split(",")(1)*rebounce
                End If
            End If
            If Forced(object_, Physics2Ground, ForceDirection.FromUp) Then
                '落地
                power(1) -= gravity.Value
                object_.Top = Physics2Ground.Top - object_.Height
                If IsIgnorable(object_.Tag.ToString.Split(",")(1), target, 1) Then
                    object_.Tag = object_.Tag.ToString.Split(",")(0) & "," & 0
                    object_.BackColor = Color.Yellow
                Else
                    power(1) -= object_.Tag.ToString.Split(",")(1)*rebounce
                End If
                If IsIgnorable(object_.Tag.ToString.Split(",")(0), target, 0) Then
                    object_.Tag = 0 & "," & object_.Tag.ToString.Split(",")(1)
                Else
                    resistance(0) += Groundμ.Text.Split("=")(1)*pressure*gravity.Value
                End If
            End If
            If Forced(object_, PhysicsMiddle2, ForceDirection.FromRight) Then
                '右侧碰撞
                object_.Left = PhysicsMiddle2.Right
                If IsIgnorable(object_.Tag.ToString.Split(",")(0), target, 0) Then
                    object_.Tag = 0 & "," & object_.Tag.ToString.Split(",")(1)
                Else
                    power(0) -= object_.Tag.ToString.Split(",")(0)*rebounce
                End If
            End If
            If Forced(object_, subobject, ForceDirection.FromUp) Then
                '上侧碰撞     
                power(1) -= gravity.Value
                object_.Top = subobject.Top - object_.Height
                If IsIgnorable(object_.Tag.ToString.Split(",")(1), target, 1) Then
                    object_.Tag = object_.Tag.ToString.Split(",")(0) & "," & 0
                Else
                    power(1) -= object_.Tag.ToString.Split(",")(1)*rebounce
                End If
                If IsIgnorable(object_.Tag.ToString.Split(",")(0) - subobject.Tag.ToString.Split(",")(0), target, 0) _
                    Then
                    object_.Tag = subobject.Tag.ToString.Split(",")(0) & "," & object_.Tag.ToString.Split(",")(1)
                ElseIf object_.Tag.ToString.Split(",")(0) > subobject.Tag.ToString.Split(",")(0) Then
                    power(0) -= μm1m2*m(target)*gravity.Value
                Else
                    power(0) += μm1m2*m(target)*gravity.Value
                End If
            ElseIf Forced(object_, subobject, ForceDirection.FromDown) Then
            ElseIf Forced(object_, subobject, ForceDirection.FromLeft) Then
                object_.Left = subobject.Right
                If IsIgnorable(object_.Tag.ToString.Split(",")(0), target, 0) Then
                    object_.Tag = 0 & "," & object_.Tag.ToString.Split(",")(1)
                Else
                    power(0) -= object_.Tag.ToString.Split(",")(0)*rebounce
                End If
            ElseIf Forced(object_, subobject, ForceDirection.FromRight) Then
                object_.Left = subobject.Left - object_.Width
                If IsIgnorable(object_.Tag.ToString.Split(",")(0), target, 0) Then
                    object_.Tag = 0 & "," & object_.Tag.ToString.Split(",")(1)
                Else
                    power(0) -= object_.Tag.ToString.Split(",")(0)*rebounce
                End If
            End If
            For x = 0 To 1
                If object_.Tag.ToString.Split(",")(x) < 0 Then
                    resistance(x) = - Math.Abs(resistance(x))
                ElseIf object_.Tag.ToString.Split(",")(x) > 0 Then
                    resistance(x) = Math.Abs(resistance(x))
                Else
                    resistance(x) = 0
                End If
                acceleration(target, x) = power(x) - resistance(x)
            Next
        Next
        If Not MainBlock1.BackColor = Color.Yellow Then Point01 += TimeSet
        If Not MainBlock2.BackColor = Color.Yellow Then Point02 += TimeSet
        '增加速度
        MainBlock1.Tag = MainBlock1.Tag.ToString.Split(",")(0) + acceleration(0, 0)*TimeSet & "," &
                         MainBlock1.Tag.ToString.Split(",")(1) + acceleration(0, 1)*TimeSet
        MainBlock2.Tag = MainBlock2.Tag.ToString.Split(",")(0) + acceleration(1, 0)*TimeSet & "," &
                         MainBlock2.Tag.ToString.Split(",")(1) + acceleration(1, 1)*TimeSet
        '检测超出边界
        If MainBlock1.Right < 0 Or MainBlock1.Left > physics2.Width Then
            frontbar1.Tag = - 1
            MainBlock1.Visible = False
        End If
        If MainBlock2.Right < 0 Or MainBlock2.Left > physics2.Width Then
            frontbar2.Tag = - 1
            MainBlock2.Visible = False
        End If
        '检测时间结束
        If _
            (frontbar1.Text = "0" Or frontbar1.Text = "Out of range") And
            (frontbar2.Text = "0" Or frontbar2.Text = "Out of range") Then
            EndTime += TimeSet
            If EndTime >= 2 Then
                stabtime.Enabled = False
                Physics2Main.Enabled = False
                Physics2Launch.Text = "Reset"
                PhysicsInterval.Visible = True
                PhysicsIntervalFore.Visible = True
                If MainBlock1.BackColor = Color.Yellow And MainBlock2.BackColor = Color.Yellow Then
                    PhysicsInterval.Text = Math.Round(Point02 - Point01, 2)
                    If PhysicsInterval.Text.Split(".").Count = 0 Then PhysicsInterval.Text = PhysicsInterval.Text & "."
                    PhysicsInterval.Text = PhysicsInterval.Text.Split(".")(0) & "." &
                                           PhysicsInterval.Text.Split(".")(1).PadRight(2, "0")
                    PhysicsInterval.Text = Math.Abs(CType(PhysicsInterval.Text.Split(".")(0), Single)) & "." &
                                           PhysicsInterval.Text.Split(".")(1)
                    If PhysicsInterval.Text <= 2 Then
                        MoveAtropos.Enabled = False
                        AddTip("Wonderful!")
                        MsgBox("Super job! You completed this abnormal physics exam subject!", 0, "Success!")
                        physics2.Visible = False
                        MoveAtropos.Tag = 24475
                        MoveAtropos.Enabled = True
                    End If
                Else
                    PhysicsInterval.Text = "Failed"
                End If
            End If
        Else
            EndTime = 0
        End If
    End Sub

    Private Function Converted(control1 As Control, control2 As Control)
        If _
            control1.Bottom >= control2.Top And control1.Bottom <= control2.Bottom And control1.Right >= control2.Left And
            control1.Right <= control2.Right Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub PhysicsBomb_MouseUp(sender As Object, e As MouseEventArgs) Handles PhysicsBomb.MouseUp
        MoveBomb.Enabled = False
        If PhysicsBomb.BackColor = Color.Red Then
            PhysicsBomb.Visible = False
            If mute.Checked = False Then _
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound32.wm")
            Randomize()
            For Each block In Blocks
                block.Tag = Math.Max(Int(Rnd()*6), 5) & ",0"
            Next
            MoveBomb.Enabled = True
        End If
    End Sub

    ''' <summary>
    '''     物体的碰撞方向。
    ''' </summary>
    Enum ForceDirection As Integer
        ''' <summary>
        '''     从任意方向碰撞，即两个物体相互接触。
        ''' </summary>
        Anyway = 0
        ''' <summary>
        '''     从上方碰撞。
        ''' </summary>
        FromUp = 1
        ''' <summary>
        '''     从下方碰撞。
        ''' </summary>
        FromDown = 2
        ''' <summary>
        '''     从左方碰撞。
        ''' </summary>
        FromLeft = 3
        ''' <summary>
        '''     从右方碰撞。
        ''' </summary>
        FromRight = 4
    End Enum

    ''' <summary>
    '''     检测两个物体是否发生相互碰撞。
    ''' </summary>
    ''' <param name="object1">第一个物体。检测方向性碰撞时，检测第一个物体碰撞第二个物体的单向碰撞。</param>
    ''' <param name="object2">第二个物体。</param>
    ''' <param name="direction">碰撞的方向。</param>
    ''' <returns></returns>
    Function Forced(object1 As Control, object2 As Control, Optional direction As ForceDirection = ForceDirection.Anyway)
        Dim AnywayCanSucceed = False
        Dim half_completed = False
        Dim forcer1 As Control = object1
        Dim forcer2 As Control = object2
        next_stage:
        If half_completed Then
            forcer1 = object2
            forcer2 = object1
        End If
        If _
            ((forcer1.Top >= forcer2.Top And forcer1.Top <= forcer2.Bottom) Or
             (forcer1.Bottom >= forcer2.Top And forcer1.Bottom <= forcer2.Bottom)) And
            ((forcer1.Left >= forcer2.Left And forcer1.Left <= forcer2.Right) Or
             (forcer1.Right >= forcer2.Left And forcer1.Right <= forcer2.Right)) Then AnywayCanSucceed = True
        If half_completed Then
            forcer1 = object1
            forcer2 = object2
        Else
            half_completed = True
            GoTo next_stage
        End If
        If AnywayCanSucceed Then
            If direction = ForceDirection.Anyway Then
                Return True
            ElseIf direction = ForceDirection.FromUp Then
                If forcer1.Bottom >= forcer2.Top And forcer1.Bottom <= forcer2.Top + forcer2.Height/3 Then
                    Return True
                Else
                    Return False
                End If
            ElseIf direction = ForceDirection.FromDown Then
                If forcer1.Top <= forcer2.Bottom And forcer1.Top >= forcer2.Bottom - forcer2.Height/3 Then
                    Return True
                Else
                    Return False
                End If
            ElseIf direction = ForceDirection.FromLeft Then
                If forcer1.Right >= forcer2.Left And forcer1.Right >= forcer2.Left + forcer2.Width/3 Then
                    Return True
                Else
                    Return False
                End If
            ElseIf direction = ForceDirection.FromRight Then
                If forcer1.Left <= forcer2.Right And forcer1.Left >= forcer2.Right - forcer2.Width/3 Then
                    Return True
                Else
                    Return False
                End If
            End If
        Else
            Return False
        End If
    End Function

    Function IsIgnorable(Value As Single, BlockNum As Integer, xySpeed As Integer)
        rCycleTime(BlockNum, xySpeed) += 1
        Dim bricks(1) As Control
        bricks(0) = MainBlock1
        bricks(1) = MainBlock2
        Dim CheckingSpeed As Single = bricks(BlockNum).Tag.ToString.Split(",")(xySpeed)
        If rCycled(BlockNum, xySpeed) = False Then
            If CheckingSpeed <> 0 Then
                If rAgain(BlockNum, xySpeed) Then
                    rAgain(BlockNum, xySpeed) = False
                Else
                    rCycled(BlockNum, xySpeed) = True
                End If
                If rCycled(BlockNum, xySpeed) = False Then
                    'MsgBox("")
                    rCyclingNumber(BlockNum, xySpeed, 0) = CheckingSpeed
                Else
                    If rCyclingNumber(BlockNum, xySpeed, 0) <> CheckingSpeed Then _
                        rCyclingNumber(BlockNum, xySpeed, 1) = CheckingSpeed
                End If
            End If
        Else
            rAgain(BlockNum, xySpeed) = True
            rCycled(BlockNum, xySpeed) = False
            If _
                Not _
                (CheckingSpeed = rCyclingNumber(BlockNum, xySpeed, 0) Or
                 CheckingSpeed = rCyclingNumber(BlockNum, xySpeed, 1)) Then
                rAgain(BlockNum, xySpeed) = True
                rCycled(BlockNum, xySpeed) = False
                rCycleTime(BlockNum, xySpeed) = 0
                rCyclingNumber(BlockNum, xySpeed, 0) = 0
                rCyclingNumber(BlockNum, xySpeed, 1) = 0
            End If
        End If
        If (Value > - 0.1 And Value < 0.1) Or rCycleTime(BlockNum, xySpeed) > 2 Then
            rAgain(BlockNum, xySpeed) = False
            rCycled(BlockNum, xySpeed) = False
            rCycleTime(BlockNum, xySpeed) = 0
            rCyclingNumber(BlockNum, xySpeed, 0) = 0
            rCyclingNumber(BlockNum, xySpeed, 1) = 0
            Return True
        Else
            Return False
        End If
    End Function
End Class
