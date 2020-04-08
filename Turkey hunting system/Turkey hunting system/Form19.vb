Imports System.Text

Public Class Form19
    Private LockedLife1 As String, LockedLife2 As String, OriginalAtropos As Point
    Private ReadOnly CardList(1) As ListBox
    Private ReadOnly Handcards(4) As PictureBox
    Private Enable As Boolean = True

    Private ReadOnly _
        TimeLabel As _
            New Label _
        With {.Font = New Font("等线", 48.0!, FontStyle.Regular, GraphicsUnit.Point, 134), .ForeColor = Color.White,
        .BackColor = Color.Transparent, .Height = 150, .Width = 200, .TextAlign = ContentAlignment.MiddleCenter}

    Private ReadOnly MovingCard As New PictureBox
    Private ReadOnly MovingCardEx As New PictureBox
    Private MoveTarget As PictureBox
    Private ReadOnly HandCardList(1) As ListBox
    Private OneSuccess As Boolean = False
    Private TotalLong As Integer, TotalLongEx As Integer
    Private ReadOnly PlayedCard(1) As String
    Private ReadOnly Statuses(1, 2) As PictureBox
    Private ReadOnly damage(1) As PictureBox
    Private ReadOnly point(1) As String
    Private originalDamageSize As Size, DamageDelay1 As Integer, DamageDelay2 As Integer, ThrowCardOpposite As Boolean

    ''' <summary>
    '''     窗体必要的初始化。
    ''' </summary>
    Public Sub Initializate()
        draw_text.Parent = draw_pile
        draw_text.Location = New Point(draw_text.Left - draw_pile.Left, draw_text.Top - draw_pile.Top)
        discard_text.Parent = discard_pile
        discard_text.Location = New Point(discard_text.Left - discard_pile.Left, discard_text.Top - discard_pile.Top)
        damage1.Parent = board1
        damage1.Location = New Point(damage1.Left - board1.Left, damage1.Top - board1.Top)
        damage2.Parent = board2
        damage2.Location = New Point(damage2.Left - board2.Left, damage2.Top - board2.Top)
        tutorial.Text =
            "Here is the battlefield of the final battle between you and Atropos. Actually, it's a card game based on turns, each player can only play one card per turn."
        tutorial_next.Tag = 0
        OriginalAtropos = Atropos.Location
        Atropos.Top = Height
        backbar1.Tag = LockNumber(50)
        backbar2.Tag = LockNumber(50)
        point(0) = backbar1.Tag
        point(1) = backbar2.Tag
        backbar1.Visible = False
        frontbar1.Visible = False
        backbar2.Visible = False
        frontbar2.Visible = False
        ModifyLife(True, 50)
        ModifyLife(False, 50)
        Form1.music.settings.setMode("loop", True)
        Form1.music.settings.volume = 100
        Form1.music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music10.wm"
        Handcards(0) = card0
        Handcards(1) = card1
        Handcards(2) = card2
        Handcards(3) = card3
        Handcards(4) = card4
        HandCardList(0) = New ListBox
        HandCardList(1) = New ListBox
        Statuses(0, 0) = status1_1
        Statuses(0, 1) = status1_2
        Statuses(0, 2) = status1_3
        Statuses(1, 0) = status2_1
        Statuses(1, 1) = status2_2
        Statuses(1, 2) = status2_3
        damage(0) = damage1
        damage(1) = damage2
        originalDamageSize = damage1.Size
    End Sub

    ''' <summary>
    '''     修改一个玩家的生命值。
    ''' </summary>
    ''' <param name="player1">是否是一号玩家（阿特洛波斯）。</param>
    ''' <param name="value">要修改到的数字。</param>
    Private Sub ModifyLife(player1 As Boolean, value As Single)
        If player1 Then
            value = Math.Max(Math.Min(value, UnlockNumber(backbar1.Tag)), 0)
            frontbar1.Text = Math.Round(value, 1)
            If frontbar1.Text.Contains(".") = False Then frontbar1.Text = frontbar1.Text & ".0"
            LockedLife1 = LockNumber(value)
            frontbar1.Width = backbar1.Width*value/UnlockNumber(backbar1.Tag)
            frontbar1.BackColor = Color.FromArgb(255*(1 - value/UnlockNumber(backbar1.Tag)),
                                                 255*(value/UnlockNumber(backbar1.Tag)), 0)
        Else
            value = Math.Max(Math.Min(value, UnlockNumber(backbar2.Tag)), 0)
            frontbar2.Text = Math.Round(value, 1)
            If frontbar2.Text.Contains(".") = False Then frontbar2.Text = frontbar2.Text & ".0"
            LockedLife2 = LockNumber(value)
            frontbar2.Width = backbar2.Width*value/UnlockNumber(backbar2.Tag)
            frontbar2.BackColor = Color.FromArgb(255*(1 - value/UnlockNumber(backbar2.Tag)),
                                                 255*(value/UnlockNumber(backbar2.Tag)), 0)
        End If
        If UnlockNumber(LockedLife1) = 0 Or UnlockNumber(LockedLife2) = 0 Then
            MoveCard.Enabled = False
            MoveCardEx.Enabled = False
            TimeCost.Enabled = False
            setlife1.Enabled = False
            setlife2.Enabled = False
            setdamage1.Enabled = False
            setdamage2.Enabled = False
            TurnWeaver.Enabled = False
            If UnlockNumber(LockedLife1) = 0 Then
                MoveAtropos.Enabled = True
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound32.wm")
            ElseIf frontbar2.Visible And UnlockNumber(lockedlife2) = 0 Then
                Hide()
                Form10.Show()
                Form10.start(44, "You failed...")
                If Not Form1.mute.Checked Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound1.wm")
            End If
        End If
    End Sub

    ''' <summary>
    '''     锁定数据，以防止用户使用第三方修改程式修改数据。
    ''' </summary>
    ''' <param name="number">要转化为密码的数字。</param>
    ''' <returns></returns>
    Private Function LockNumber(number As Single) As String
        Dim exportion = ""
        If number = Nothing Then Return "A"
        For x = 0 To number.ToString.Length - 1
            If number.ToString.Substring(x, 1) = "0" Then exportion = exportion & "A"
            If number.ToString.Substring(x, 1) = "1" Then exportion = exportion & "B"
            If number.ToString.Substring(x, 1) = "2" Then exportion = exportion & "C"
            If number.ToString.Substring(x, 1) = "3" Then exportion = exportion & "D"
            If number.ToString.Substring(x, 1) = "4" Then exportion = exportion & "E"
            If number.ToString.Substring(x, 1) = "5" Then exportion = exportion & "F"
            If number.ToString.Substring(x, 1) = "6" Then exportion = exportion & "G"
            If number.ToString.Substring(x, 1) = "7" Then exportion = exportion & "H"
            If number.ToString.Substring(x, 1) = "8" Then exportion = exportion & "I"
            If number.ToString.Substring(x, 1) = "9" Then exportion = exportion & "J"
            If number.ToString.Substring(x, 1) = "." Then exportion = exportion & "Z"
        Next
        If number < 0 Then exportion = exportion & "X"
        Return exportion
    End Function

    Private Sub card0_Click(sender As Object, e As EventArgs) Handles card0.Click
        PlayCard(card0, 0)
    End Sub

    Private Sub Form19_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Initializate()
        LinkLabel1.Location = New Point(0, 0)
        LinkLabel1.Parent = tiptext
    End Sub

    Private Sub TimeCost_Tick(sender As Object, e As EventArgs) Handles TimeCost.Tick
        TimeLabel.Text -= 1
        If TimeLabel.Text <= 3 Then TimeLabel.ForeColor = Color.Red Else TimeLabel.ForeColor = Color.White
        If TimeLabel.Text = 0 Then
            If HasStatus(False, "timed") Then
                HandCardList(1).Items.Remove(card0.Tag)
                card0.Tag = "useless card"
                card0.Image = card_list.Images(15)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound62.wm")
            End If
            PlayCard(card0, 0)
        End If
    End Sub

    Private Sub card1_Click(sender As Object, e As EventArgs) Handles card1.Click
        PlayCard(card1, 1)
    End Sub

    Private Sub card2_Click(sender As Object, e As EventArgs) Handles card2.Click
        PlayCard(card2, 2)
    End Sub

    Private Sub card3_Click(sender As Object, e As EventArgs) Handles card3.Click
        PlayCard(card3, 3)
    End Sub

    Private Sub card4_Click(sender As Object, e As EventArgs) Handles card4.Click
        PlayCard(card4, 4)
    End Sub

    Private Sub tutorial_next_Click(sender As Object, e As EventArgs) Handles tutorial_next.Click
        If tutorial_next.Tag = 0 Then
            tutorial_next.Tag = 1
            tutorial.Text =
                "The cards contain character cards and magic cards, the most cards are character cards. When the two players put out their two character cards to the board, they will have a battle."
        ElseIf tutorial_next.Tag = 1 Then
            tutorial_next.Tag = 2
            tutorial_image1.Visible = True
            tutorial.Text = "Here is the detail Of the restraint relationship." & vbCrLf & """half"" means" & vbCrLf &
                            "0.5 damage." & vbCrLf & "Once finished," & vbCrLf & "the loser of" & vbCrLf & "the combat" &
                            vbCrLf & "will be" & vbCrLf & "correspondin-" & vbCrLf & "gly damaged."
        ElseIf tutorial_next.Tag = 2 Then
            tutorial_next.Tag = 3
            tutorial_image1.Visible = False
            tutorial_image2.Visible = True
            tutorial.Text = "Here we do show the detail of a character card."
        ElseIf tutorial_next.Tag = 3 Then
            tutorial_next.Tag = 4
            tutorial_image2.Visible = False
            tutorial.Text =
                "The magic card can cause some special effect to yourself or the enemy, the effect will be shown on the card."
        ElseIf tutorial_next.Tag = 4 Then
            tutorial_next.Tag = 5
            tutorial_image3.Visible = True
            tutorial.Text = "Here we do show the detail of a magic card."
        ElseIf tutorial_next.Tag = 5 Then
            tutorial_next.Tag = 6
            tutorial_image3.Visible = False
            tutorial.Text =
                "Here're the special items got in the game, they can give you some new kind of cards being used in the game."
            If Form1.items.Items.Contains("mirror card") Then
                If tutorial_image4.Visible = False Then
                    tutorial_image4.Visible = True
                    tutorial_image4.Image = spcard_list.Images(0)
                ElseIf tutorial_image5.Visible = False Then
                    tutorial_image5.Visible = True
                    tutorial_image5.Image = spcard_list.Images(0)
                Else
                    tutorial_image6.Visible = True
                    tutorial_image6.Image = spcard_list.Images(0)
                End If
            End If
            If Form1.items.Items.Contains("Mr.Duck card") Then
                If tutorial_image4.Visible = False Then
                    tutorial_image4.Visible = True
                    tutorial_image4.Image = spcard_list.Images(1)
                ElseIf tutorial_image5.Visible = False Then
                    tutorial_image5.Visible = True
                    tutorial_image5.Image = spcard_list.Images(1)
                Else
                    tutorial_image6.Visible = True
                    tutorial_image6.Image = spcard_list.Images(1)
                End If
            End If
            If Form1.items.Items.Contains("static card") Then
                If tutorial_image4.Visible = False Then
                    tutorial_image4.Visible = True
                    tutorial_image4.Image = spcard_list.Images(2)
                ElseIf tutorial_image5.Visible = False Then
                    tutorial_image5.Visible = True
                    tutorial_image5.Image = spcard_list.Images(2)
                Else
                    tutorial_image6.Visible = True
                    tutorial_image6.Image = spcard_list.Images(2)
                End If
            End If
            If tutorial_image4.Visible = False Then GoTo Non_card
        ElseIf tutorial_next.Tag = 6 Then
            Non_card:
            tutorial_next.Tag = 7
            tutorial_image4.Visible = False
            tutorial_image5.Visible = False
            tutorial_image6.Visible = False
            tutorial.Text =
                "It's not so easy to get a magic card: the probability is quite low. Besides luck, you should also try to use your cards wisely."
            tutorial_next.Text = "Battle"
        ElseIf tutorial_next.Tag = 7 Then
            tutorial_next.Tag = 8
            tutorial_box.Visible = False
            Atropos.Tag = 0
            MoveAtropos.Enabled = True
        ElseIf tutorial_next.Text = "Win!" Then
            Hide()
            Form1.Show()
            Form1.MoveAtropos.Enabled = True
        End If
    End Sub

    Private Sub MoveCardEx_Tick(sender As Object, e As EventArgs) Handles MoveCardEx.Tick
        If MoveCardEx.Tag = 2 Then
            MovingCardEx.Width += 10
            MovingCardEx.Height += 10
            MovingCardEx.Left = Atropos.Left + Atropos.Width/2 - MovingCardEx.Width/2
            MovingCardEx.Top = Atropos.Top + Atropos.Height/2 - MovingCardEx.Height/2
            If MovingCardEx.Width > board2.Width - 10 Or MovingCardEx.Height > board2.Height - 10 Then
                MoveCardEx.Tag = 3
            End If
        Else
            Dim ToLeft As Integer = board2.Left + board2.Width/2 - MovingCardEx.Width/2
            Dim ToTop As Integer = board2.Top + board2.Height/2 - MovingCardEx.Height/2
            Dim MoveLeft As Integer = ToLeft - MovingCardEx.Left
            Dim MoveTop As Integer = ToTop - MovingCardEx.Top
            Dim hypotenuse As Integer = Math.Pow(Math.Pow(MoveLeft, 2) + Math.Pow(MoveTop, 2), 0.5)
            Dim average As Integer = 10/(1 + Math.Abs(MoveTop)/Math.Abs(MoveLeft))
            Dim PerLeft As Integer = 1*average
            Dim PerTop As Integer = 10 - PerLeft
            MovingCardEx.Size = New Size((1 - hypotenuse/TotalLongEx)*(board1.Width - card0.Width) + card0.Width,
                                         (1 - hypotenuse/TotalLongEx)*(board1.Height - card0.Height) + card0.Height)
            If MoveTop >= 10 Then
                MovingCardEx.Top += PerTop
            ElseIf MoveTop <= - 10 Then
                MovingCardEx.Top -= PerTop
            End If
            If MoveLeft >= 10 Then
                MovingCardEx.Left += PerLeft
            ElseIf MoveLeft <= - 10 Then
                MovingCardEx.Left -= PerLeft
            End If
            If (MoveTop > - 10 And MoveTop < 10) And (MoveLeft > - 10 And MoveLeft < 10) Then
                MoveCardEx.Enabled = False
                Controls.Remove(MovingCardEx)
                If OneSuccess Then
                    OneSuccess = False
                    CharacterBattle()
                Else
                    OneSuccess = True
                End If
                board2.Visible = True
                board2.Image = GetPicture(PlayedCard(1))
            End If
        End If
    End Sub

    Private Sub MoveCard_Tick(sender As Object, e As EventArgs) Handles MoveCard.Tick
        If MoveCard.Tag <> - 1 Then
            Dim ToLeft As Integer = MoveTarget.Left + MoveTarget.Width/2 - MovingCard.Width/2
            Dim ToTop As Integer = MoveTarget.Top + MoveTarget.Height/2 - MovingCard.Height/2
            Dim MoveLeft As Integer = ToLeft - MovingCard.Left
            Dim MoveTop As Integer = ToTop - MovingCard.Top
            Dim hypotenuse As Integer = Math.Pow(Math.Pow(MoveLeft, 2) + Math.Pow(MoveTop, 2), 0.5)
            Dim average As Integer = 10/(1 + Math.Abs(MoveTop)/Math.Abs(MoveLeft))
            Dim PerLeft As Integer = 1*average
            Dim PerTop As Integer = 10 - PerLeft
            If MoveCard.Tag = 2 Then _
                MovingCard.Size = New Size((1 - hypotenuse/TotalLong)*(board2.Width - card0.Width) + card0.Width,
                                           (1 - hypotenuse/TotalLong)*(board2.Height - card0.Height) + card0.Height)
            If MoveCard.Tag = 5 Then _
                MovingCard.Size = New Size((1 - hypotenuse/TotalLong)*(discard_pile.Width - board1.Width) + board1.Width,
                                           (1 - hypotenuse/TotalLong)*(discard_pile.Height - board1.Height) +
                                           board1.Height)
            If _
                MoveCard.Tag = 3 And
                Not (MovingCard.Width > MoveTarget.Width - 10 Or MovingCard.Height > MoveTarget.Height - 10) Then
                MovingCard.Width += 10
                MovingCard.Height += 10
                MovingCard.Left = Atropos.Left + Atropos.Width/2 - MovingCard.Width/2
                MovingCard.Top = Atropos.Top + Atropos.Height/2 - MovingCard.Height/2
                Exit Sub
            End If
            If MoveTop >= 10 Then
                MovingCard.Top += PerTop
            ElseIf MoveTop <= - 10 Then
                MovingCard.Top -= PerTop
            End If
            If MoveLeft >= 10 Then
                MovingCard.Left += PerLeft
            ElseIf MoveLeft <= - 10 Then
                MovingCard.Left -= PerLeft
            End If
            If (MoveTop > - 10 And MoveTop < 10) And (MoveLeft > - 10 And MoveLeft < 10) Then
                If MoveCard.Tag = 0 Or MoveCard.Tag = 3 Or MoveCard.Tag = 4 Or MoveCard.Tag = 5 Then
                    Enable = True
                    MoveCard.Enabled = False
                    Controls.Remove(MovingCard)
                    refresh_handcards()
                    If MoveCard.Tag = 3 Or MoveCard.Tag = 4 Then
                        discard_pile.Visible = True
                        discard_pile.Image = GetPicture(MovingCard.Tag)
                    ElseIf MoveCard.Tag = 5 Then
                        discard_pile.Visible = True
                        discard_pile.Image = MovingCard.Image
                    End If
                ElseIf MoveCard.Tag = 1 Then
                    MoveCard.Tag = - 1
                    JustSize:
                    MovingCard.Width -= 10
                    MovingCard.Height -= 10
                    MovingCard.Left = MoveTarget.Left + MoveTarget.Width/2 - MovingCard.Width/2
                    MovingCard.Top = MoveTarget.Top + MoveTarget.Height/2 - MovingCard.Height/2
                    If MovingCard.Width < 10 Or MovingCard.Height < 10 Then
                        Enable = True
                        MoveCard.Enabled = False
                        Controls.Remove(MovingCard)
                    End If
                ElseIf MoveCard.Tag = 2 Then
                    MoveCard.Enabled = False
                    Controls.Remove(MovingCard)
                    If OneSuccess Then
                        OneSuccess = False
                        CharacterBattle()
                    Else
                        OneSuccess = True
                    End If
                    board1.Visible = True
                    board1.Image = GetPicture(PlayedCard(0))
                End If
            End If
        Else
            GoTo JustSize
        End If
    End Sub

    Private Sub refresh_handcards()
        For x = 0 To 4
            Handcards(x).Visible = False
        Next
        For x = 0 To HandCardList(1).Items.Count - 1
            Handcards(x).Tag = HandCardList(1).Items(x)
            Handcards(x).Image = GetPicture(HandCardList(1).Items(x))
            Handcards(x).Visible = True
        Next
    End Sub

    Private Sub setdamage2_Tick(sender As Object, e As EventArgs) Handles setdamage2.Tick
        If setdamage2.Tag = 1 Then
            DamageDelay2 -= 1
            If DamageDelay2 = 0 Then setdamage2.Tag = 2
            Exit Sub
        End If
        If setdamage2.Tag = 0 Then
            damage2.Width += 10
            damage2.Height += 10
        Else
            damage2.Width -= 10
            damage2.Height -= 10
        End If
        damage2.Left = board2.Width/2 - damage2.Width/2
        damage2.Top = board2.Height/2 - damage2.Height/2
        If _
            setdamage2.Tag = 0 AndAlso
            (damage2.Width > originalDamageSize.Width - 10 Or damage2.Height > originalDamageSize.Height - 10) Then
            setdamage2.Tag = 1
            DamageDelay2 = 50
            setlife1.Enabled = True
        ElseIf setdamage2.Tag = 2 AndAlso (damage2.Width < 10 Or damage2.Height < 10) Then
            setdamage2.Enabled = False
            damage2.Visible = False
        End If
    End Sub

    Private Sub setlife1_Tick(sender As Object, e As EventArgs) Handles setlife1.Tick
        If UnlockNumber(LockedLife1) > UnlockNumber(point(0)) Then
            ModifyLife(True, UnlockNumber(LockedLife1) - 0.5)
        ElseIf UnlockNumber(LockedLife1) < UnlockNumber(point(0)) Then
            ModifyLife(True, UnlockNumber(LockedLife1) + 0.5)
        Else
            setlife1.Enabled = False
        End If
    End Sub

    Private Sub setlife2_Tick(sender As Object, e As EventArgs) Handles setlife2.Tick
        If UnlockNumber(LockedLife2) > UnlockNumber(point(1)) Then
            ModifyLife(False, UnlockNumber(LockedLife2) - 0.5)
        ElseIf UnlockNumber(LockedLife2) < UnlockNumber(point(1)) Then
            ModifyLife(False, UnlockNumber(LockedLife2) + 0.5)
        Else
            setlife2.Enabled = False
        End If
    End Sub

    Private Sub setdamage1_Tick(sender As Object, e As EventArgs) Handles setdamage1.Tick
        If setdamage1.Tag = 1 Then
            DamageDelay1 -= 1
            If DamageDelay1 = 0 Then setdamage1.Tag = 2
            Exit Sub
        End If
        If setdamage1.Tag = 0 Then
            damage1.Width += 10
            damage1.Height += 10
        Else
            damage1.Width -= 10
            damage1.Height -= 10
        End If
        damage1.Left = board1.Width/2 - damage1.Width/2
        damage1.Top = board1.Height/2 - damage1.Height/2
        If _
            setdamage1.Tag = 0 AndAlso
            (damage1.Width > originalDamageSize.Width - 10 Or damage1.Height > originalDamageSize.Height - 10) Then
            setdamage1.Tag = 1
            DamageDelay1 = 50
            setlife2.Enabled = True
        ElseIf setdamage1.Tag = 2 AndAlso (damage1.Width < 10 Or damage1.Height < 10) Then
            setdamage1.Enabled = False
            damage1.Visible = False
        End If
    End Sub

    Private Sub TurnWeaver_Tick(sender As Object, e As EventArgs) Handles TurnWeaver.Tick
        If _
            setdamage1.Enabled Or setdamage2.Enabled Or setlife1.Enabled Or setlife2.Enabled Or
            Controls.Contains(MovingCard) Or Enable = False Then Exit Sub
        If TurnWeaver.Tag = 0 Then
            TurnWeaver.Tag = 1
            Dim LoopTime = True
            Dim myself As PictureBox = board1, opponent As PictureBox = board2
            Do
                Dim Expand = 1
                Dim AntiLoopTime As Boolean
                If LoopTime Then AntiLoopTime = False Else AntiLoopTime = True
                If HasStatus(AntiLoopTime, "power-up") Then Expand *= 2
                If myself.Tag = "shine" Then
                    CauseDamage(AntiLoopTime, - 4*Expand)
                End If
                If LoopTime Then
                    myself = board2
                    opponent = board1
                    LoopTime = False
                Else
                    Exit Do
                End If
            Loop
        ElseIf TurnWeaver.Tag = 1 Then
            TurnWeaver.Tag = 2
            Dim LoopTime = True
            Dim myself As PictureBox = board1, opponent As PictureBox = board2
            Do
                Dim Expand = 1
                Dim AntiLoopTime As Boolean
                If LoopTime Then AntiLoopTime = False Else AntiLoopTime = True
                If HasStatus(AntiLoopTime, "power-up") Then Expand *= 2
                If myself.Tag = "explode" Then
                    CauseDamage(LoopTime, GenerateRandom(1, "1,2,3,4,5,")*Expand)
                ElseIf myself.Tag = "reflect" Then
                    If opponent.Tag = "rooster" Or opponent.Tag = "hen" Then
                        CauseDamage(LoopTime, 1*Expand)
                    ElseIf opponent.Tag = "turkey" Or opponent.Tag = "witch" Then
                        CauseDamage(LoopTime, 2*Expand)
                    ElseIf opponent.Tag = "Mr.Duck" Then
                        CauseDamage(LoopTime, 3*Expand)
                    End If
                End If
                If LoopTime Then
                    myself = board2
                    opponent = board1
                    LoopTime = False
                Else
                    Exit Do
                End If
            Loop
        ElseIf TurnWeaver.Tag = 2 Then
            TurnWeaver.Tag = 3
            Dim LoopTime = True
            Dim myself As PictureBox = board1, opponent As PictureBox = board2
            Do
                Dim Expand = 1
                Dim AntiLoopTime As Boolean
                If LoopTime Then AntiLoopTime = False Else AntiLoopTime = True
                If HasStatus(AntiLoopTime, "power-up") Then Expand *= 2
                If myself.Tag = "release" Then
                    AddStatus(AntiLoopTime, "power-up", 2*Expand)
                End If
                If LoopTime Then
                    myself = board2
                    opponent = board1
                    LoopTime = False
                Else
                    Exit Do
                End If
            Loop
        ElseIf TurnWeaver.Tag = 3 Then
            TurnWeaver.Tag = 4
            Dim LoopTime = True
            Dim myself As PictureBox = board1, opponent As PictureBox = board2
            Do
                Dim Expand = 1
                Dim AntiLoopTime As Boolean
                If LoopTime Then AntiLoopTime = False Else AntiLoopTime = True
                If HasStatus(AntiLoopTime, "power-up") Then Expand *= 2
                If myself.Tag = "static" Then
                    AddStatus(LoopTime, "stunned", 3*Expand)
                ElseIf myself.Tag = "contort time" Then
                    AddStatus(LoopTime, "timed", 3*Expand)
                ElseIf myself.Tag = "flunk" Then
                    AddStatus(LoopTime, "confused", 3*Expand)
                End If
                If LoopTime Then
                    myself = board2
                    opponent = board1
                    LoopTime = False
                Else
                    Exit Do
                End If
            Loop
        ElseIf TurnWeaver.Tag = 4 Then
            TurnWeaver.Tag = 5
            Dim LoopTime = True
            Dim myself As PictureBox = board1, opponent As PictureBox = board2
            Do
                Dim Expand = 1
                Dim AntiLoopTime As Boolean
                If LoopTime Then AntiLoopTime = False Else AntiLoopTime = True
                If HasStatus(AntiLoopTime, "power-up") Then Expand *= 2
                If myself.Tag = "generate" And Not opponent.Tag = "generate" Then
                    DrawCard(AntiLoopTime)
                End If
                If LoopTime Then
                    myself = board2
                    opponent = board1
                    LoopTime = False
                Else
                    Exit Do
                End If
            Loop
        ElseIf TurnWeaver.Tag = 5 Then
            TurnWeaver.Tag = 6
            Dim LoopTime = True
            Dim myself As PictureBox = board1, opponent As PictureBox = board2
            Do
                Dim Expand = 1
                Dim AntiLoopTime As Boolean
                If LoopTime Then AntiLoopTime = False Else AntiLoopTime = True
                If HasStatus(AntiLoopTime, "power-up") Then Expand *= 2
                If myself.Tag = "vanish" And Not opponent.Tag = "vanish" Then
                    Discard(LoopTime)
                End If
                If LoopTime Then
                    myself = board2
                    opponent = board1
                    LoopTime = False
                Else
                    Exit Do
                End If
            Loop
        ElseIf TurnWeaver.Tag = 6 Then
            TurnWeaver.Tag = 7
            Dim LoopTime = True
            Dim myself As PictureBox = board1, opponent As PictureBox = board2
            Do
                Dim Expand = 1
                Dim AntiLoopTime As Boolean
                If LoopTime Then AntiLoopTime = False Else AntiLoopTime = True
                If HasStatus(AntiLoopTime, "power-up") Then Expand *= 2
                If HasStatus(AntiLoopTime, "confused") Then
                    CauseDamage(AntiLoopTime, 1.5)
                End If
                If LoopTime Then
                    myself = board2
                    opponent = board1
                    LoopTime = False
                Else
                    Exit Do
                End If
            Loop
            ThrowCardOpposite = GenerateRandom(1, "True,False,")
        ElseIf (TurnWeaver.Tag = 7 And ThrowCardOpposite = False) Or (TurnWeaver.Tag = 8 And ThrowCardOpposite) Then
            If board1.Visible Then
                If ThrowCardOpposite Then TurnWeaver.Tag = 9 Else TurnWeaver.Tag = 8
                Controls.Add(MovingCard)
                MovingCard.Size = New Size(board1.Width, board1.Height)
                MovingCard.Location = New Point(board1.Left, board1.Top)
                MovingCard.Image = board1.Image
                MovingCard.BringToFront()
                MoveTarget = discard_pile
                board1.Visible = False
                MoveCard.Tag = 5
                TotalLong =
                    Math.Pow(Math.Pow(discard_pile.Left - board1.Left, 2) + Math.Pow(discard_pile.Top - board1.Top, 2),
                             0.5)
                MoveCard.Enabled = True
            End If
        ElseIf (TurnWeaver.Tag = 8 And ThrowCardOpposite = False) Or (TurnWeaver.Tag = 7 And ThrowCardOpposite) Then
            If board2.Visible Then
                If ThrowCardOpposite Then TurnWeaver.Tag = 8 Else TurnWeaver.Tag = 9
                Controls.Add(MovingCard)
                MovingCard.Size = New Size(board2.Width, board2.Height)
                MovingCard.Location = New Point(board2.Left, board2.Top)
                MovingCard.Image = board2.Image
                MovingCard.BringToFront()
                MoveTarget = discard_pile
                board2.Visible = False
                MoveCard.Tag = 5
                TotalLong =
                    Math.Pow(Math.Pow(discard_pile.Left - board2.Left, 2) + Math.Pow(discard_pile.Top - board2.Top, 2),
                             0.5)
                MoveCard.Enabled = True
            End If
        ElseIf TurnWeaver.Tag = 9 Then
            TurnWeaver.Tag = 10
            If Not HasStatus(True, "stunned") Then DrawCard(True)
        ElseIf TurnWeaver.Tag = 10 Then
            TurnWeaver.Tag = 11
            DrawCard(False)
        ElseIf TurnWeaver.Tag = 11 Then
            TurnWeaver.Tag = 12
            For x = 0 To 1
                For y = 0 To 2
                    If Statuses(x, y).Visible Then
                        Statuses(x, y).Tag = Statuses(x, y).Tag.split(",")(0) & "," &
                                             Statuses(x, y).Tag.split(",")(1) - 1
                        ToolTip1.SetToolTip(Statuses(x, y), GetToolTip(Statuses(x, y)))
                        If Statuses(x, y).Tag.split(",")(1) <= 0 Then
                            Statuses(x, y).Visible = False
                        End If
                    End If
                Next
            Next
            refreshstatus()
            If HasStatus(False, "timed") Then
                TimeLabel.Text = 3
                TimeLabel.ForeColor = Color.Red
            Else
                TimeLabel.Text = 10
                TimeLabel.ForeColor = Color.White
            End If
            TimeLabel.Visible = True
            TimeCost.Enabled = True
            TurnWeaver.Enabled = False
            If Form1.heal > 0 Then healbutton.Enabled = True
        End If
    End Sub

    Private Sub refreshstatus()
        For x = 0 To 1
            For i_ = 1 To 2
                For i = 1 To 2
                    If Statuses(x, i).Visible And Statuses(x, i - 1).Visible = False Then
                        Statuses(x, i).Visible = False
                        Statuses(x, i - 1).Visible = True
                        Statuses(x, i - 1).Tag = Statuses(x, i).Tag
                        Statuses(x, i - 1).Image = Statuses(x, i).Image
                        ToolTip1.SetToolTip(Statuses(x, i - 1), GetToolTip(Statuses(x, i)))
                    End If
                Next
            Next
        Next
    End Sub

    Private Sub MoveAtropos_Tick(sender As Object, e As EventArgs) Handles MoveAtropos.Tick
        If Atropos.Tag = 0 Then
            Atropos.Top -= 5
            If Atropos.Top <= OriginalAtropos.Y Then Atropos.Tag = 0.5
        ElseIf Atropos.Tag = 0.5 Then
            Form1.music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\prelude1.wm"
            Form1.music.Ctlcontrols.pause()
            Atropos.Tag = 1
        ElseIf Atropos.Tag = 1 Then
            MoveAtropos.Tag += 1
            If MoveAtropos.Tag = 250 Then
                Atropos.Tag = 2
                tutorial_next.Tag = Form1.music.currentMedia.duration
                Form1.music.Ctlcontrols.play()
            End If
        ElseIf Atropos.Tag = 2 Then
            tutorial_next.Tag -= 0.3
            If tutorial_next.Tag <= 0 Then
                LinkLabel1_LinkClicked(Nothing, Nothing)
                Form1.music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music15.wm"
                backbar1.Visible = True
                frontbar1.Visible = True
                backbar2.Visible = True
                frontbar2.Visible = True
                Controls.Add(TimeLabel)
                TimeLabel.Parent = Atropos
                TimeLabel.Location = New Point((Atropos.Width - TimeLabel.Width)/2,
                                               (Atropos.Height - TimeLabel.Height)/3)
                TimeLabel.Text = 15
                TimeLabel.Visible = False
                CardList(0) = New ListBox
                CardList(1) = New ListBox
                For x = 0 To 6
                    For y = 0 To 1
                        CardList(y).Items.Add("rooster")
                        CardList(y).Items.Add("hen")
                        CardList(y).Items.Add("turkey")
                        CardList(y).Items.Add("witch")
                    Next
                    If Form1.items.Items.Contains("Mr.Duck card") Then CardList(1).Items.Add("Mr.Duck")
                Next
                For y = 0 To 1
                    CardList(y).Items.Add("generate")
                    CardList(y).Items.Add("vanish")
                    CardList(y).Items.Add("release")
                Next
                CardList(0).Items.Add("contort time")
                CardList(0).Items.Add("explode")
                CardList(0).Items.Add("flunk")
                CardList(1).Items.Add("shine")
                If Form1.items.Items.Contains("mirror card") Then CardList(1).Items.Add("reflect")
                If Form1.items.Items.Contains("static card") Then CardList(1).Items.Add("static")
                DrawCard(True)
                Atropos.Tag = 3
            End If
        ElseIf Enable And Atropos.Tag = 3 Then
            DrawCard(True)
            Atropos.Tag = 4
        ElseIf Enable And Atropos.Tag = 4 Then
            DrawCard(True)
            Atropos.Tag = 5
        ElseIf Enable And Atropos.Tag = 5 Then
            DrawCard(False)
            Atropos.Tag = 6
        ElseIf Enable And Atropos.Tag = 6 Then
            DrawCard(False)
            Atropos.Tag = 7
        ElseIf Enable And Atropos.Tag = 7 Then
            DrawCard(False)
            Atropos.Tag = 8
        ElseIf Enable And Atropos.Tag = 8 Then
            Atropos.Tag = 9
            MoveAtropos.Enabled = False
            TimeCost.Enabled = True
            TimeLabel.Visible = True
            healbutton.Visible = True
            healbutton.Text = "Heal(" & Form1.heal & ")"
            MoveAtropos.Tag = 0
        ElseIf Atropos.Tag = 9 Then
            Atropos.Top += MoveAtropos.Tag
            MoveAtropos.Tag += 1
            If Atropos.Top >= Height Then
                Form1.music.Ctlcontrols.stop()
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\victory2.wm")
                Atropos.Tag = 10
                tutorial_box.Text = "Victory!"
                tutorial_box.ForeColor = Color.Yellow
                tutorial_box.BringToFront()
                tutorial.Text = "You successfully defeated Atropos! The victor of the battle is you!!"
                tutorial_next.Text = "Win!"
                tutorial_box.Visible = True
                MoveAtropos.Enabled = False
                Form1.SaveGame("Chapter4", "Final Battle", 11, False)
            End If
        End If
    End Sub

    Private Sub healbutton_Click(sender As Object, e As EventArgs) Handles healbutton.Click
        If UnlockNumber(LockedLife1) >= UnlockNumber(backbar1.Tag) Or UnlockNumber(LockedLife1) <= 0 Then
            healbutton.Enabled = False
        Else
            point(1) = LockNumber(UnlockNumber(point(1)) + 10)
            If UnlockNumber(point(1)) > UnlockNumber(backbar1.Tag) Then point(1) = backbar1.Tag
            My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound19.wm")
            Form1.heal -= 1
            healbutton.Text = "Heal(" & Form1.heal & ")"
            If Form1.heal = 0 Then healbutton.Enabled = False
            setlife2.Enabled = True
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) _
        Handles LinkLabel1.LinkClicked
        LinkLabel1.Visible = False
        BackgroundImage = Nothing
        BackColor = Color.Black
    End Sub

    ''' <summary>
    '''     解锁数据，以供再次使用。
    ''' </summary>
    ''' <param name="password">密码字符串。</param>
    ''' <returns></returns>
    Private Function UnlockNumber(password As String) As Single
        Dim exportion = ""
        If password = Nothing Then Return "0"
        For x = 0 To password.ToString.Length - 1
            If password.ToString.Substring(x, 1) = "A" Then exportion = exportion & "0"
            If password.ToString.Substring(x, 1) = "B" Then exportion = exportion & "1"
            If password.ToString.Substring(x, 1) = "C" Then exportion = exportion & "2"
            If password.ToString.Substring(x, 1) = "D" Then exportion = exportion & "3"
            If password.ToString.Substring(x, 1) = "E" Then exportion = exportion & "4"
            If password.ToString.Substring(x, 1) = "F" Then exportion = exportion & "5"
            If password.ToString.Substring(x, 1) = "G" Then exportion = exportion & "6"
            If password.ToString.Substring(x, 1) = "H" Then exportion = exportion & "7"
            If password.ToString.Substring(x, 1) = "I" Then exportion = exportion & "8"
            If password.ToString.Substring(x, 1) = "J" Then exportion = exportion & "9"
            If password.ToString.Substring(x, 1) = "Z" Then exportion = exportion & "."
            If password.ToString.Substring(x, 1) = "X" Then exportion = "-" & exportion
        Next
        Return exportion
    End Function

    ''' <summary>
    '''     通过卡牌的名称获取卡牌的图像。
    ''' </summary>
    ''' <param name="CardName">卡牌名称。</param>
    ''' <returns></returns>
    Private Function GetPicture(CardName As String) As Image
        If CardName = "rooster" Then
            Return card_list.Images(1)
        ElseIf CardName = "hen" Then
            Return card_list.Images(2)
        ElseIf CardName = "turkey" Then
            Return card_list.Images(3)
        ElseIf CardName = "witch" Then
            Return card_list.Images(4)
        ElseIf CardName = "Mr.Duck" Then
            Return card_list.Images(5)
        ElseIf CardName = "generate" Then
            Return card_list.Images(6)
        ElseIf CardName = "vanish" Then
            Return card_list.Images(7)
        ElseIf CardName = "release" Then
            Return card_list.Images(8)
        ElseIf CardName = "shine" Then
            Return card_list.Images(9)
        ElseIf CardName = "reflect" Then
            Return card_list.Images(10)
        ElseIf CardName = "static" Then
            Return card_list.Images(11)
        ElseIf CardName = "contort time" Then
            Return card_list.Images(12)
        ElseIf CardName = "explode" Then
            Return card_list.Images(13)
        ElseIf CardName = "flunk" Then
            Return card_list.Images(14)
        ElseIf CardName = "useless card" Then
            Return card_list.Images(15)
        ElseIf CardName = "null" Then
            Return card_list.Images(16)
        Else
            Return Nothing
        End If
    End Function

    ''' <summary>
    '''     为一个玩家抽一张牌。
    ''' </summary>
    ''' <param name="player1">是否是一号玩家（阿特洛波斯）。</param>
    Private Sub DrawCard(player1 As Boolean)
        If Enable = False Then Throw New Exception("Unable to draw card: superimposed action.")
        Dim card As String
        Dim cardlistemp = ""
        Dim cardint As Integer
        If player1 Then cardint = 0 Else cardint = 1
        If HandCardList(cardint).Items.Count = 5 Then Exit Sub
        Enable = False
        For x = 0 To CardList(cardint).Items.Count - 1
            cardlistemp = cardlistemp & CardList(cardint).Items(x) & ","
        Next
        card = GenerateRandom(1, cardlistemp)
        Controls.Add(MovingCard)
        MovingCard.Tag = card
        MovingCard.Location = New Point(draw_pile.Left, draw_pile.Top)
        MovingCard.Size = New Size(draw_pile.Width, draw_pile.Height)
        MovingCard.Image = card_list.Images(0)
        MovingCard.SizeMode = PictureBoxSizeMode.StretchImage
        MovingCard.BringToFront()
        If player1 Then
            MoveTarget = Atropos
        Else
            For x = 0 To 4
                If Handcards(x).Visible = False Then
                    MoveTarget = Handcards(x)
                    Exit For
                End If
            Next
        End If
        HandCardList(cardint).Items.Add(card)
        If player1 Then MoveCard.Tag = 1 Else MoveCard.Tag = 0
        MoveCard.Enabled = True
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

    ''' <summary>
    '''     通过伤害值获得图标。
    ''' </summary>
    ''' <param name="damage">要获取图标的伤害值。</param>
    ''' <returns></returns>
    Private Function GetDamageImage(damage As Single) As Image
        If damage = 0.5 Then
            Return damage_image.Images(0)
        ElseIf damage = 1 Then
            Return damage_image.Images(1)
        ElseIf damage = 2 Then
            Return damage_image.Images(2)
        ElseIf damage = 3 Then
            Return damage_image.Images(3)
        ElseIf damage = 4 Then
            Return damage_image.Images(4)
        ElseIf damage = 5 Then
            Return damage_image.Images(5)
        ElseIf damage = 6 Then
            Return damage_image.Images(6)
        ElseIf damage = 8 Then
            Return damage_image.Images(7)
        ElseIf damage = 10 Then
            Return damage_image.Images(8)
        ElseIf damage = - 4 Then
            Return damage_image.Images(9)
        ElseIf damage = - 8 Then
            Return damage_image.Images(10)
        ElseIf damage = 1.5 Then
            Return damage_image.Images(15)
        End If
    End Function

    ''' <summary>
    '''     玩家出牌，与此同时阿特洛波斯出牌。
    ''' </summary>
    ''' <param name="TargetCard">玩家选择的卡牌。</param>
    Private Sub PlayCard(TargetCard As PictureBox, targetint As Integer)
        If _
            Enable = False Or TurnWeaver.Enabled Or Controls.Contains(MovingCard) Or Controls.Contains(MovingCardEx) Or
            TimeLabel.Visible = False Then Exit Sub
        TimeCost.Enabled = False
        TimeLabel.Visible = False
        healbutton.Enabled = False
        OneSuccess = False
        MoveCard.Tag = 2
        MoveCardEx.Tag = 2
        MoveTarget = board1
        PlayedCard(0) = TargetCard.Tag
        Dim WordChain = ""
        For x = 0 To HandCardList(0).Items.Count - 1
            WordChain = WordChain & HandCardList(0).Items(x) & ","
        Next
        PlayedCard(1) = GenerateRandom(1, WordChain)
        HandCardList(0).Items.Remove(PlayedCard(1))
        HandCardList(1).Items.RemoveAt(targetint)
        refresh_handcards()
        Controls.Add(MovingCard)
        MovingCard.Size = New Size(TargetCard.Width, TargetCard.Height)
        MovingCard.Location = New Point(TargetCard.Left, TargetCard.Top)
        MovingCard.Image = GetPicture(PlayedCard(0))
        MovingCard.BringToFront()
        If Not HasStatus(True, "stunned") Then
            Controls.Add(MovingCardEx)
            MovingCardEx.Size = New Size(0, 0)
            MovingCardEx.Location = New Point(Atropos.Left, Atropos.Top)
            MovingCardEx.Image = GetPicture(PlayedCard(1))
            MovingCardEx.SizeMode = PictureBoxSizeMode.StretchImage
            MovingCardEx.BringToFront()
        End If
        TotalLong = Math.Pow(Math.Pow(board1.Left - MovingCard.Left, 2) + Math.Pow(board1.Top - MovingCard.Top, 2), 0.5)
        TotalLongEx = Math.Pow(Math.Pow(board2.Left - MovingCardEx.Left, 2) + Math.Pow(board2.Top - MovingCardEx.Top, 2),
                               0.5)
        MoveCard.Enabled = True
        If HasStatus(True, "stunned") Then
            board2.Visible = True
            board2.Image = card_list.Images(16)
            PlayedCard(1) = "null"
            OneSuccess = True
        Else
            MoveCardEx.Enabled = True
        End If
        board1.Tag = PlayedCard(0)
        board2.Tag = PlayedCard(1)
        damage1.Parent = board1
        damage2.Parent = board2
    End Sub

    ''' <summary>
    '''     您的角色开始战斗。
    ''' </summary>
    Private Sub CharacterBattle()
        Dim LoopTime = True
        Dim myself As PictureBox = board1, opponent As PictureBox = board2
        Do
            Dim Expand = 1
            Dim AntiLoopTime As Boolean
            If LoopTime Then AntiLoopTime = False Else AntiLoopTime = True
            If HasStatus(AntiLoopTime, "power-up") Then Expand *= 2
            If myself.Tag = "rooster" And opponent.Tag = "hen" Then
                CauseDamage(LoopTime, 0.5*Expand)
            ElseIf myself.Tag = "rooster" And opponent.Tag = "turkey" Then
                CauseDamage(LoopTime, 1*Expand)
            ElseIf myself.Tag = "turkey" And opponent.Tag = "Mr.Duck" Then
                CauseDamage(LoopTime, 2*Expand)
            ElseIf myself.Tag = "witch" And opponent.Tag = "rooster" Then
                CauseDamage(LoopTime, 4*Expand)
            ElseIf myself.Tag = "witch" And opponent.Tag = "turkey" Then
                CauseDamage(LoopTime, 0.5*Expand)
            ElseIf myself.Tag = "hen" And opponent.Tag = "witch" Then
                CauseDamage(LoopTime, 1*Expand)
            ElseIf myself.Tag = "hen" And opponent.Tag = "turkey" Then
                CauseDamage(LoopTime, 0.5*Expand)
            ElseIf myself.Tag = "Mr.Duck" And opponent.Tag = "witch" Then
                CauseDamage(LoopTime, 2*Expand)
            ElseIf myself.Tag = "Mr.Duck" And opponent.Tag = "rooster" Then
                CauseDamage(LoopTime, 2*Expand)
            ElseIf myself.Tag = "Mr.Duck" And opponent.Tag = "hen" Then
                CauseDamage(LoopTime, 1*Expand)
            ElseIf myself.Tag = "rooster" And NotACharacter(opponent.Tag) Then
                CauseDamage(LoopTime, 1*Expand)
            ElseIf myself.Tag = "hen" And NotACharacter(opponent.Tag) Then
                CauseDamage(LoopTime, 1*Expand)
            ElseIf myself.Tag = "turkey" And NotACharacter(opponent.Tag) Then
                CauseDamage(LoopTime, 2*Expand)
            ElseIf myself.Tag = "witch" And NotACharacter(opponent.Tag) Then
                CauseDamage(LoopTime, 2*Expand)
            ElseIf myself.Tag = "Mr.Duck" And NotACharacter(opponent.Tag) Then
                CauseDamage(LoopTime, 3*Expand)
            End If
            If LoopTime Then
                myself = board2
                opponent = board1
                LoopTime = False
            Else
                Exit Do
            End If
        Loop
        TurnWeaver.Tag = 0
        TurnWeaver.Enabled = True
    End Sub

    Private Function NotACharacter(text_ As String) As Boolean
        If _
            text_ = "rooster" Or text_ = "hen" Or text_ = "turkey" Or text_ = "witch" Or text_ = "Mr.Duck" Or
            text_ = "reflect" Then Return False Else Return True
    End Function

    Private Sub CauseDamage(player1 As Boolean, value As Single)
        Dim playerInt As Integer
        If player1 Then playerInt = 0 Else playerInt = 1
        If value = - 1.5 Then
            My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound10.wm")
        ElseIf value > 0 Then
            If value <= 1 Then
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound14.wm")
            ElseIf value <= 2 Then
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound3.wm")
            ElseIf value <= 4 Then
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound23.wm")
            ElseIf value <= 8 Then
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound25.wm")
            Else
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound32.wm")
            End If
        ElseIf value < 0 Then
            My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound19.wm")
        End If

        Dim AntiPlayerInt As Integer
        If playerInt = 0 Then AntiPlayerInt = 1 Else AntiPlayerInt = 0
        damage(AntiPlayerInt).Image = GetDamageImage(value)
        damage(AntiPlayerInt).Size = New Size(0, 0)
        damage(AntiPlayerInt).Visible = True
        damage(AntiPlayerInt).Tag = 0
        setdamage1.Tag = 0
        setdamage2.Tag = 0
        damage(AntiPlayerInt).BringToFront()
        Dim MaximumValue As Single
        If player1 Then MaximumValue = UnlockNumber(backbar1.Tag) Else MaximumValue = UnlockNumber(backbar2.Tag)
        point(playerInt) = LockNumber(UnlockNumber(point(playerInt)) - value)
        If UnlockNumber(point(playerInt)) > MaximumValue Then point(playerInt) = LockNumber(MaximumValue)
        If player1 Then setdamage2.Enabled = True Else setdamage1.Enabled = True
    End Sub

    ''' <summary>
    '''     检查目标是否拥有状态。
    ''' </summary>
    ''' <param name="player1">是否是一号玩家（阿特洛波斯）。</param>
    ''' <param name="status_name">状态名称。</param>
    ''' <returns></returns>
    Private Function HasStatus(player1 As Boolean, status_name As String) As Boolean
        Dim playerInt As Integer
        If player1 Then playerInt = 0 Else playerInt = 1
        For x = 0 To 2
            If Statuses(playerInt, x).Visible AndAlso Statuses(playerInt, x).Tag.ToString.Split(",")(0) = status_name _
                Then Return True
        Next
        Return False
    End Function

    ''' <summary>
    '''     为一个玩家增加状态。
    ''' </summary>
    ''' <param name="player1">是否是一号玩家（阿特洛波斯）。</param>
    ''' <param name="status_name">状态名称。</param>
    ''' <param name="turns">状态持续回合数。</param>
    Private Sub AddStatus(player1 As Boolean, status_name As String, turns As Integer)
        Dim playerInt As Integer
        If player1 Then playerInt = 0 Else playerInt = 1
        For x = 0 To 2
            If _
                Statuses(playerInt, x).Visible = False OrElse
                Statuses(playerInt, x).Tag.ToString.Split(",")(0) = status_name Then
                With Statuses(playerInt, x)
                    .Visible = True
                    .Image = GetStatusImage(status_name)
                    .Tag = status_name & "," & turns
                    ToolTip1.SetToolTip(Statuses(playerInt, x), GetToolTip(Statuses(playerInt, x)))
                End With
                Exit For
            End If
        Next
        Dim AntiPlayerInt As Integer
        If playerInt = 0 Then AntiPlayerInt = 1 Else AntiPlayerInt = 0
        damage(AntiPlayerInt).Image = GetStatusPopoutImage(status_name)
        damage(AntiPlayerInt).Size = New Size(0, 0)
        damage(AntiPlayerInt).Visible = True
        damage(AntiPlayerInt).BringToFront()
        setdamage1.Tag = 0
        setdamage2.Tag = 0
        If player1 Then setdamage2.Enabled = True Else setdamage1.Enabled = True
    End Sub

    Private Function GetStatusPopoutImage(Name_ As String) As Image
        If Name_ = "timed" Then
            Return damage_image.Images(11)
        ElseIf Name_ = "stunned" Then
            Return damage_image.Images(12)
        ElseIf Name_ = "confused" Then
            Return damage_image.Images(13)
        ElseIf Name_ = "power-up" Then
            Return damage_image.Images(14)
        Else
            Return Nothing
        End If
    End Function

    ''' <summary>
    '''     得到弹出窗口。
    ''' </summary>
    ''' <param name="status">目标状态。</param>
    ''' <returns></returns>
    Private Function GetToolTip(status As PictureBox) As String
        Dim FirstText As String
        If status.Tag.ToString.Split(",")(0) = "timed" Then
            FirstText = "Timed" & vbCrLf &
                        "The player can only have 3 seconds in its turn, if time runs out, his first card will be destroyed."
        ElseIf status.Tag.ToString.Split(",")(0) = "stunned" Then
            FirstText = "Stunned" & vbCrLf & "Cannot do anything."
        ElseIf status.Tag.ToString.Split(",")(0) = "confused" Then
            FirstText = "Confused" & vbCrLf & "Lose 1.5 point of life per turn."
        ElseIf status.Tag.ToString.Split(",")(0) = "power-up" Then
            FirstText = "Power-up" & vbCrLf & "Your cards' effect get doubled."
        Else
            FirstText = "tool tip missing"
        End If
        Return _
            FirstText & vbCrLf & status.Tag.ToString.Split(",")(1) & " turn" &
            CheckForS(status.Tag.ToString.Split(",")(1)) & " left."
    End Function

    ''' <summary>
    '''     通过状态名称得到状态图片。
    ''' </summary>
    ''' <param name="status_name">状态名称。</param>
    ''' <returns></returns>
    Private Function GetStatusImage(status_name As String) As Image
        If status_name = "timed" Then
            Return status_list.Images(0)
        ElseIf status_name = "stunned" Then
            Return status_list.Images(1)
        ElseIf status_name = "confused" Then
            Return status_list.Images(2)
        ElseIf status_name = "power-up" Then
            Return status_list.Images(3)
        Else
            Return Nothing
        End If
    End Function

    Public Function CheckForS(value As Integer) As String
        If value > 1 Then Return "s" Else Return ""
    End Function

    Private Sub Discard(player1 As Boolean)
        If Enable = False Then Throw New Exception("Unable to discard: superimposed action.")
        Dim card As String
        Dim cardlistemp = ""
        Dim cardint As Integer
        If player1 Then cardint = 0 Else cardint = 1
        If HandCardList(cardint).Items.Count = 0 Then Exit Sub
        Enable = False
        Dim CardIntList = ""
        Dim ChosenCardInt As Integer
        For x = 0 To HandCardList(cardint).Items.Count - 1
            CardIntList = CardIntList & x & ","
            cardlistemp = cardlistemp & HandCardList(cardint).Items(x) & ","
        Next
        ChosenCardInt = GenerateRandom(1, CardIntList)
        card = cardlistemp.Split(",")(ChosenCardInt)
        Controls.Add(MovingCard)
        MovingCard.Tag = card
        If player1 Then
            MovingCard.Location = New Point(Atropos.Left, Atropos.Top)
            MovingCard.Size = New Size(0, 0)
        Else
            MovingCard.Location = New Point(Handcards(ChosenCardInt).Left, Handcards(ChosenCardInt).Top)
            MovingCard.Size = New Size(Handcards(ChosenCardInt).Width, Handcards(ChosenCardInt).Height)
        End If
        MovingCard.Image = GetPicture(card)
        MovingCard.SizeMode = PictureBoxSizeMode.StretchImage
        MovingCard.BringToFront()
        MoveTarget = discard_pile
        HandCardList(cardint).Items.Remove(card)
        refresh_handcards()
        If player1 Then MoveCard.Tag = 3 Else MoveCard.Tag = 4
        MoveCard.Enabled = True
    End Sub
End Class