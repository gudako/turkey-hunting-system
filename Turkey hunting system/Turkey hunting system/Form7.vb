Imports System.Threading

Public Class Form7
    Private point1 As String, point2 As String
    Public defend_type As Integer
    Public attack_type As Integer
    Public magic_type As Integer
    Private step_ As Integer = 0
    Public battle As Integer
    Private ReadOnly status1 As PictureBox() = {status1_1, status1_2, status1_3, status1_4, status1_5, status1_6}
    Private ReadOnly status2 As PictureBox() = {status2_1, status2_2, status2_3, status2_4, status2_5, status2_6}
    Private StopCharge1 As Boolean = False, StopCharge2 As Boolean = False
    Private ReadOnly random_ As Random = New Random(Date.Now.Millisecond)
    Public Current_Murloc_Number As Integer
    Private MissProbability1 As Integer = 0
    Private CriticalProbability1 As Integer = 0
    Private MissProbability2 As Integer = 0
    Private CriticalProbability2 As Integer = 0
    Private AnotherCode As Boolean
    Private TargetLife1_battle9, TargetLife2_battle9 As Integer
    Private Avogadro_revive As Boolean = True
    Private point1mana As String, point2mana As String

    Private BeforeMove1 As Integer,
            BeforeMove2 As Integer,
            ForeColor1 As Color,
            ForeColor2 As Color,
            Tipcolor As Color,
            BeforeTip As Integer,
            MagicPowerStage As Integer = 0

    Public boss As Boolean = False

    Private LastMagicalDamage1 As Integer = 0,
            LockedLife1 As String,
            LockedLife2 As String,
            LockedMana1 As String,
            LockedMana2 As String

    Friend ChangeCow As Integer = 0, mana1enabled As Boolean = False, mana2enabled As Boolean = False

    Delegate Sub SetTextCallback([text] As String)

    Dim labbb As New Label
    Private demoThread As Thread = Nothing

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub ModifyLife(player1 As Boolean, value As Integer)
        If player1 Then
            If value > life1b.Tag Or value < 0 Then Exit Sub
            life1f.Tag = value
            LockedLife1 = LockNumber(value)
        Else
            If value > life2b.Tag Or value < 0 Then Exit Sub
            life2f.Tag = value
            LockedLife2 = LockNumber(value)
        End If
    End Sub

    Private Sub ModifyMana(player1 As Boolean, value As Integer)
        If player1 Then
            If value > mana1b.Tag Or value < 0 Then Exit Sub
            mana1f.Tag = value
            LockedMana1 = LockNumber(value)
        Else
            If value > mana2b.Tag Or value < 0 Then Exit Sub
            mana2f.Tag = value
            LockedMana2 = LockNumber(value)
        End If
    End Sub

    Private Sub ChangePower(Player1 As Boolean, number As Integer, Optional Critical As Boolean = False,
                            Optional Absoulte As Boolean = False, Optional NonTip As Boolean = False,
                            Optional attack_damage As Boolean = True, Optional magic_damage As Boolean = False,
                            Optional drink As Boolean = False, Optional mana As Boolean = False)
        Dim Player2 As Boolean
        If Player1 = True Then Player2 = False Else Player2 = True
        If number < 0 And Not Absoulte And Not mana Then
            If HasStatus(Player1, 0) Then number *= 0.7
            If HasStatus(Player1, 5) Then number *= 0.5
            If HasStatus(Player1, 10) Then number *= 0.33
            If HasStatus(Player1, 24) Then number *= 0.25
            If HasStatus(Player1, 25) Then number *= 1.5
            If HasStatus(Player2, 25) Then number *= 0.5
            If HasStatus(Player2, 30) Then number *= 0
            If attack_damage And HasStatus(Player2, 12) Then number *= 0.75
            If HasStatus(Player1, 21) And attack_damage And Not magic_damage Then number *= 0.25
            If HasStatus(Player1, 27) And Not magic_damage Then number *= 0
            If HasStatus(Player1, 27) And magic_damage Then number *= 2
            If HasStatus(Player1, 28) And magic_damage Then number *= 0
            If HasStatus(Player1, 28) And Not magic_damage Then number *= 2
            If HasStatus(Player1, 32) And magic_damage Then number *= 3
            If HasStatus(Player1, 3) And attack_damage Then number *= 1.91
            If HasStatus(Player1, 29) Then number *= 0.8
            If attack_damage And HasStatus(Player1, 19) Then number *= 0.7
        End If
        If drink Then ChangePower(Player2, - number, False, True, False, False, False)
        If Player1 Then
            If HasStatus(True, 17) And attack_damage And Not magic_damage And Not Critical Then _
                ChangePower(False, 0.2*number, False, False, False, False)
            If mana Then
                point1mana = LockNumber(UnlockNumber(point1mana) + number)
                If UnlockNumber(point1mana) > mana1b.Tag Then point1mana = LockNumber(mana1b.Tag)
                If UnlockNumber(point1mana) < 0 Then point1mana = LockNumber(0)
            Else
                point1 = LockNumber(UnlockNumber(point1) + number)
                If UnlockNumber(point1) > life1b.Tag Then point1 = LockNumber(life1b.Tag)
                If UnlockNumber(point1) < 0 Then point1 = LockNumber(0)
            End If
            If number < 0 And magic_damage Then LastMagicalDamage1 = number
            If Not NonTip Then
                If mana Then
                    If number > 0 Then
                        popout1.Text = "+" & TransmitNumber(number)
                        popout1.ForeColor = Color.Blue
                    Else
                        popout1.Text = TransmitNumber(number)
                        popout1.ForeColor = Color.Blue
                    End If
                Else
                    If number > 0 Then
                        popout1.Text = "+" & TransmitNumber(number)
                        popout1.ForeColor = Color.DarkGreen
                    ElseIf number = 0 Then
                        popout1.Text = number
                        popout1.ForeColor = Color.Yellow
                    ElseIf number < 0 And Not Critical Then
                        popout1.Text = "-" & TransmitNumber(- number)
                        popout1.ForeColor = Color.Firebrick
                    Else
                        popout1.Text = TransmitNumber(number) & "!"
                        popout1.ForeColor = Color.Red
                        If cd1t.ForeColor = Color.Red Then StopCharge1 = True
                    End If
                End If
                popout1.Left = (battler.Width - popout1.Width)/2
                popout1.Top = (battler.Height - popout1.Top)/2
                popout1.Visible = True
                popout1.Tag = 20
                BeforeMove1 = 0
                ForeColor1 = popout1.ForeColor
                settop1.Enabled = True
            End If
            If mana Then
                setmana1.Enabled = True
            Else
                setlife1.Enabled = True
            End If
        Else
            If HasStatus(False, 17) And attack_damage And Not magic_damage And Not Critical Then _
                ChangePower(True, 0.2*number, False, False, False, False)
            If mana Then
                point2mana = LockNumber(UnlockNumber(point2mana) + number)
                If UnlockNumber(point2mana) > mana2b.Tag Then point2mana = LockNumber(mana2b.Tag)
                If UnlockNumber(point2mana) < 0 Then point2mana = LockNumber(0)
            Else
                point2 = LockNumber(UnlockNumber(point2) + number)
                If UnlockNumber(point2) > life2b.Tag Then point2 = LockNumber(life2b.Tag)
                If UnlockNumber(point2) < 0 Then point2 = LockNumber(0)
            End If
            If Not NonTip Then
                If mana Then
                    If number > 0 Then
                        popout2.Text = "+" & TransmitNumber(number)
                        popout2.ForeColor = Color.Blue
                    Else
                        popout2.Text = "-" & TransmitNumber(- number)
                        popout2.ForeColor = Color.Blue
                    End If
                Else
                    If number > 0 Then
                        popout2.Text = "+" & TransmitNumber(number)
                        popout2.ForeColor = Color.DarkGreen
                    ElseIf number = 0 Then
                        popout2.Text = number
                        popout2.ForeColor = Color.Yellow
                    ElseIf number < 0 And Not Critical Then
                        popout2.Text = "-" & TransmitNumber(- number)
                        popout2.ForeColor = Color.Firebrick
                    Else
                        popout2.Text = TransmitNumber(number) & "!"
                        popout2.ForeColor = Color.Red
                        If cd2t.ForeColor = Color.Red Then StopCharge2 = True
                    End If
                End If
                'popout2.Left = 488
                popout2.BringToFront()
                popout2.Top = life2f.Bottom - popout2.Height
                popout2.Visible = True
                popout2.Tag = 60
                BeforeMove2 = 0
                ForeColor2 = popout2.ForeColor
                settop2.Enabled = True
            End If
            If mana Then
                setmana2.Enabled = True
            Else
                setlife2.Enabled = True
            End If
        End If
    End Sub

    Private Function TransmitNumber(number As Integer)
        If number < 1000 Then
            Return number
        ElseIf number >= 1000 And number < 100000 Then
            Return number/1000 & "K"
        ElseIf number >= 100000 And number < 1000000 Then
            Return "0." & number/100000 & "M"
        ElseIf number >= 1000000 And number < 100000000 Then
            Return number/1000000 & "M"
        ElseIf number >= 1000000000 Then
            Return number/1000000000 & "E"
        Else
            Return "Err"
        End If
    End Function

    Private Sub setlife1_Tick(sender As Object, e As EventArgs) Handles setlife1.Tick
        If life1f.Tag > UnlockNumber(point1) Then
            ModifyLife(True, life1f.Tag - 1)
            RefreshTexts()
        ElseIf life1f.tag < UnlockNumber(point1) Then
            ModifyLife(True, life1f.Tag + 1)
            RefreshTexts()
        Else
            setlife1.Enabled = False
        End If
    End Sub

    Private Sub RefreshTexts()
        life1t.Text = AddDot(life1f.Tag) & "/" & AddDot(life1b.Tag)
        If life1f.Tag*10 <= life1b.Tag Then
            life1t.ForeColor = Color.Red
        Else
            life1t.ForeColor = Color.Black
        End If
        life2t.Text = AddDot(life2f.Tag) & "/" & AddDot(life2b.Tag)
        If life2f.Tag*10 <= life2b.Tag Then
            life2t.ForeColor = Color.Red
        Else
            life2t.ForeColor = Color.Black
        End If
        life1f.Width = life1f.Tag/life1b.Tag*life1b.Width
        life2f.Width = life2f.Tag/life2b.Tag*life2b.Width
        life1f.BackColor = Color.FromArgb(255*(1 - life1f.Tag/life1b.Tag), 255*life1f.Tag/life1b.Tag, 0)
        life2f.BackColor = Color.FromArgb(255*(1 - life2f.Tag/life2b.Tag), 255*life2f.Tag/life2b.Tag, 0)
        if not mana1b.Tag = nothing then
            If mana1b.Visible Then
                mana1f.Width = mana1f.Tag/mana1b.Tag*mana1b.Width
                mana1t.Text = "Mana:" & AddDot(mana1f.Tag) & "/" & AddDot(mana1b.Tag)
            End If
            If mana2b.Visible and not mana2f.Tag = nothing Then
                mana2f.Width = mana2f.Tag/mana2b.Tag*mana2b.Width
                mana2t.Text = "Mana:" & AddDot(mana2f.Tag) & "/" & AddDot(mana2b.Tag)
            End If
        end if
        If life1f.Tag = 0 Or life2f.Tag = 0 Then
            setlife1.Enabled = False
            setlife2.Enabled = False
            setmana1.Enabled = False
            setmana2.Enabled = False
            Mana1restore.Enabled = False
            Mana2restore.Enabled = False
            cool1.Enabled = False
            cool2.Enabled = False
            titleshow.Enabled = False
            EnemyAction.Enabled = False
            hidecool1.Enabled = False
            hidecool2.Enabled = False
            attack.Enabled = False
            assist.Enabled = False
            defend.Enabled = False
            magic.Enabled = False
            StatusMove.Enabled = False
            StatusCheck.Enabled = False
            If defeat.Enabled Or shining.Enabled Then Exit Sub
            If battle = 3 Then spelling.Visible = False
            If battle = 6 Then assist.Enabled = False
            pause.Enabled = False
        End If
        If (battle = 5 Or battle = 6) And number.Value = 0 Then Exit Sub
        If life1f.Tag = 0 Then
            cd1f.Visible = False
            cd1b.Visible = False
            cd1t.Visible = False
            shining.Enabled = True
            If Not battle = 5 And Not battle = 6 And Not (battle = 11 And Avogadro_revive) Then
                ShowTitle("Victory!", Color.Green)
            End If
        ElseIf life2f.Tag = 0 Then
            cd2f.Visible = False
            cd2b.Visible = False
            cd2t.Visible = False
            defeat.Enabled = True
            ShowTitle("Defeat!", Color.Red)
        End If
        If battle = 9 And (life1f.Tag < TargetLife1_battle9 Or life2f.Tag < TargetLife2_battle9) Then
            TargetLife1_battle9 = - 1
            TargetLife2_battle9 = - 1
            setlife1.Enabled = False
            setlife2.Enabled = False
            cool1.Enabled = False
            cool2.Enabled = False
            titleshow.Enabled = False
            EnemyAction.Enabled = False
            hidecool1.Enabled = False
            hidecool2.Enabled = False
            attack.Enabled = False
            assist.Enabled = False
            defend.Enabled = False
            magic.Enabled = False
            StatusMove.Enabled = False
            pause.Enabled = False
            battler.Visible = False
            StatusCheck.Enabled = False
            life1t.Text = "Escaped."
            ShowTitle("The turkey eater worm escapes to underground.", Color.Blue)
            MsgBox(
                "The turkey eater worm suddenly escaped to underground! We can't find it anymore. The only thing remained is ropy mucus on ground adjoining the quiz machine.",
                48, "Accident!")
            Hide()
            Form1.Show()
            Form1.AfterBattle(18)
            Form1.music.settings.volume = Form1.BackgroundVolume
            Form1.music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music1.wm"
        ElseIf battle = 19 And life1f.Tag < life1f.Tag/3*2 And Not HasStatus(True, 29) Then
            setlife1.Enabled = False
            setlife2.Enabled = False
            cool1.Enabled = False
            cool2.Enabled = False
            titleshow.Enabled = False
            EnemyAction.Enabled = False
            hidecool1.Enabled = False
            hidecool2.Enabled = False
            attack.Enabled = False
            assist.Enabled = False
            defend.Enabled = False
            magic.Enabled = False
            StatusMove.Enabled = False
            pause.Enabled = False
            battler.Visible = False
            StatusCheck.Enabled = False
            life1t.Text = "Exploded."
            battler.Visible = False
            My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound32.wm")
            MsgBox("The witch suddenly exploded, and you died!")
            Hide()
            Form1.GameOver("The witch exploded.")
        End If
    End Sub

    Public Function AddDot(number As Integer)
        Dim number_ = ""
        If number.ToString.Length >= 3 Then
            For i = 0 To number.ToString.Length/3 - 1
                If i = 0 Then
                    number_ = number.ToString.Substring(number.ToString.Length - 3*(i + 1), 3)
                Else
                    number_ = number.ToString.Substring(number.ToString.Length - 3*(i + 1), 3) & "," & number_
                End If
            Next
        End If
        If number.ToString.Length Mod 3 = 0 Then
            Return number_
        Else
            If number.ToString.Length > 3 Then
                Return Strings.Left(number.ToString, number.ToString.Length Mod 3) & "," & number_
            Else
                Return Strings.Left(number.ToString, number.ToString.Length)
            End If
        End If
    End Function

    Private Sub settop1_Tick(sender As Object, e As EventArgs) Handles settop1.Tick
        If boss And BeforeMove1 < 25 Then
            BeforeMove1 += 1
            If ForeColor1 = Color.Red Then
                popout1.BackColor = Color.FromArgb(255 - BeforeMove1*10, 255, 0, 0)
            Else
                GoTo nextstep
            End If
            Exit Sub
        Else
            popout1.BackColor = Color.Transparent
        End If
        nextstep:
        If popout1.Top > 0 Then
            Me.popout1.Top -= 4
        End If
        If popout1.Tag <= 0 Then
            If boss And BeforeMove1 < 50 Then
                If BeforeMove1 < 25 Then BeforeMove1 = 25
                BeforeMove1 += 1
                If ForeColor1 = Color.Red Then
                    popout1.ForeColor = Color.FromArgb(255 - 10*(BeforeMove1 - 25), 0, 0)
                ElseIf ForeColor1 = Color.Firebrick Then
                    popout1.ForeColor = Color.FromArgb(178 + 3*(BeforeMove1 - 25), 34 + 8*(BeforeMove1 - 25),
                                                       34 + 8*(BeforeMove1 - 25))
                ElseIf ForeColor1 = Color.Green Then
                    popout1.ForeColor = Color.FromArgb(10*(BeforeMove1 - 25), 255, 10*(BeforeMove1 - 25))
                Else
                    GoTo nextstep2
                End If
                Exit Sub
            End If
            nextstep2:
            settop1.Enabled = False
            popout1.Visible = False
            If step_ = 3 Then
                tutorial.Visible = True
                next_.Enabled = True
                content.Text = "Press ""Next""."
            ElseIf content1.Tag = 2 Then
                special1.Visible = True
                content1.Tag = 3
                spelling.Enabled = False
                example.Text = "Example"
                SpellBox.Text = "Example"
                content1.Text = "Good job. You can press ""Next"" to watch the detail."
                next1.Enabled = True
            End If
        ElseIf popout1.Top <= 0 Then
            popout1.Tag -= 1
        End If
    End Sub

    Private Sub attack_Click(sender As Object, e As EventArgs) Handles attack.Click
        If IsStunned(False) Then Exit Sub
        CheckForMissCritical(False)
        If step_ = 3 Then tutorial.Visible = False
        Dim hitpower As Integer = random_.Next(1, 101)
        If attack_type = 0 Then
            If hitpower >= 95 - MissProbability2 Then
                ShowTitle("Beat the " & Form8.EnemyName.Text & " (Miss the target.)", Color.Gold)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
            ElseIf hitpower <= 5 + CriticalProbability2 Then
                ChangePower(True, - 15, True)
                ShowTitle("Beat the " & Form8.EnemyName.Text & " (Critical Hit!)", Color.Red)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound3.wm")
            Else
                ChangePower(True, - 5)
                ShowTitle("Beat the " & Form8.EnemyName.Text & ".", Color.Black)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound3.wm")
            End If
            CoolDown(False, 1)
        ElseIf attack_type = 1 Then
            If hitpower >= 92 - MissProbability2 Then
                ShowTitle("Thump the " & Form8.EnemyName.Text & " (Miss the target.)", Color.Gold)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
            ElseIf hitpower <= 8 + CriticalProbability2 Then
                ChangePower(True, - 48, True)
                ShowTitle("Thump the " & Form8.EnemyName.Text & " and stun it (Critical Hit!)", Color.Red)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound12.wm")
                AddStatus(True, 4, 6)
            Else
                ChangePower(True, - 16)
                ShowTitle("Thump the " & Form8.EnemyName.Text & ".", Color.Black)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound12.wm")
            End If
            CoolDown(False, 2.33)
        ElseIf attack_type = 2 Then
            If hitpower >= 92 - MissProbability2 Then
                ShowTitle("Chop the " & Form8.EnemyName.Text & " (Miss the target.)", Color.Gold)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
            ElseIf hitpower <= 5 + CriticalProbability2 Then
                ChangePower(True, - 60, True)
                ShowTitle("Chop the " & Form8.EnemyName.Text & " and bleed it (Critical Hit!)", Color.Red)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound29.wm")
                If hitpower <= 3 Then AddStatus(True, 13, 4)
            Else
                ChangePower(True, - 20)
                ShowTitle("Chop the " & Form8.EnemyName.Text & ".", Color.Black)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound29.wm")
                If hitpower <= 8 Then AddStatus(True, 13, 2)
            End If
            CoolDown(False, 1.89)
        ElseIf attack_type = 3 Then
            If hitpower >= 95 - MissProbability2 Then
                ShowTitle("Paw the " & Form8.EnemyName.Text & " (Miss the target.)", Color.Gold)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
            ElseIf hitpower <= 10 + CriticalProbability2 Then
                ChangePower(True, - 45, True)
                ShowTitle("Paw the " & Form8.EnemyName.Text & " (Critical Hit!)", Color.Red)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound3.wm")
                If hitpower <= 3 Then AddStatus(True, 13, 4)
            Else
                ChangePower(True, - 15)
                ShowTitle("Paw the " & Form8.EnemyName.Text & ".", Color.Black)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound3.wm")
                If hitpower <= 8 Then AddStatus(True, 13, 2)
            End If
            CoolDown(False, 0.9)
        ElseIf attack_type = 4 Then
            If hitpower >= 93 - MissProbability2 Then
                ShowTitle("Chop the " & Form8.EnemyName.Text & " (Miss the target.)", Color.Gold)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
            ElseIf hitpower <= 5 + CriticalProbability2 Then
                ChangePower(True, - 90, True)
                ShowTitle("Chop the " & Form8.EnemyName.Text & " and stun it (Critical Hit!)", Color.Red)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound29.wm")
                AddStatus(True, 4, 7.1)
            Else
                ChangePower(True, - 30)
                ShowTitle("Chop the " & Form8.EnemyName.Text & ".", Color.Black)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound29.wm")
            End If
            CoolDown(False, 1.2)
        End If
    End Sub

    Private Sub settop2_Tick(sender As Object, e As EventArgs) Handles settop2.Tick
        If boss And BeforeMove2 < 25 Then
            BeforeMove2 += 1
            If ForeColor2 = Color.Red Then
                popout2.BackColor = Color.FromArgb(255 - BeforeMove2*10, 255, 0, 0)
            Else
                GoTo nextstep
            End If
            Exit Sub
        Else
            popout2.BackColor = Color.Transparent
        End If
        nextstep:
        If popout2.Top > magic.Bottom Then popout2.Top -= 4
        If popout2.Tag <= 0 Then
            If boss And BeforeMove2 < 50 Then
                If BeforeMove2 < 25 Then BeforeMove2 = 25
                BeforeMove2 += 1
                If ForeColor2 = Color.Red Then
                    popout2.ForeColor = Color.FromArgb(255 - 10*(BeforeMove2 - 25), 0, 0)
                ElseIf ForeColor2 = Color.Firebrick Then
                    popout2.ForeColor = Color.FromArgb(178 + 3*(BeforeMove2 - 25), 34 + 8*(BeforeMove2 - 25),
                                                       34 + 8*(BeforeMove2 - 25))
                ElseIf ForeColor2 = Color.Green Then
                    popout2.ForeColor = Color.FromArgb(10*(BeforeMove2 - 25), 255, 10*(BeforeMove2 - 25))
                Else
                    GoTo nextstep2
                End If
                Exit Sub
            End If
            nextstep2:
            settop2.Enabled = False
            popout2.Visible = False
        ElseIf popout2.Top <= magict.Bottom Then
            popout2.Tag -= 1
        End If
    End Sub

    Private Sub setlife2_Tick(sender As Object, e As EventArgs) Handles setlife2.Tick
        If life2f.Tag > UnlockNumber(point2) Then
            ModifyLife(False, life2f.Tag - 1)
            RefreshTexts()
        ElseIf life2f.Tag < UnlockNumber(point2) Then
            ModifyLife(False, life2f.Tag + 1)
            RefreshTexts()
        Else
            setlife2.Enabled = False
        End If
    End Sub

    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        status1(0) = status1_1
        status1(1) = status1_2
        status1(2) = status1_3
        status1(3) = status1_4
        status1(4) = status1_5
        status1(5) = status1_6
        status2(0) = status2_1
        status2(1) = status2_2
        status2(2) = status2_3
        status2(3) = status2_4
        status2(4) = status2_5
        status2(5) = status2_6
        popout1.Parent = battler
        popout1.BackColor = Color.Transparent

        'Form1.weapon_level = 3
        'Form1.shield_level = 3
        'Form1.magics.Items.Add("Solar light")
        'Form1.magics.Items.Add("Cockscomb gun")
        'Form1.magics.Items.Add("Fireball")
        'Form1.magics.Items.Add("Duck function+")
        'Form1.magics.Items.Add("HCl gun")
        'Form1.magics.Items.Add("Curative box")
        'Form1.magics.Items.Add("Snowflake")
        'Form1.magics.Items.Add("Homework generator")
        'Hide()
        'initialization(Form1.shield_level, Form1.weapon_level, 0, 4000 + Form1.shield_level * 150, 2000, 22, 150, 110, 1000, 950)
        'Form1.music.settings.setMode("loop", True)
        'Form1.music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music8.wm"
        'debug1.Show()
    End Sub

    Private Sub cool1_Tick(sender As Object, e As EventArgs) Handles cool1.Tick
        Dim totalsec = 10
        If HasStatus(True, 2) Then totalsec *= 5
        If HasStatus(True, 9) Then totalsec *= 2
        If HasStatus(True, 29) Then totalsec *= 3.33
        cool1.Interval = totalsec
        If HasStatus(True, 20) And cd1t.Text = "Charge:" Then Exit Sub
        If Not cd1f.Tag = cd1b.Tag And Not IsStunned(True) Then cd1f.Tag += 1
        If IsStunned(True) And cd1t.Text = "Charge:" Then StopCharge1 = True
        If StopCharge1 Then
            StopCharge1 = False
            CoolDown(True, Math.Max(0, cd1t.Tag.split(",")(1)/3))
        End If
        if (cd1f.Tag > cd1b.Tag) then
            cd1f.Tag = cd1b.Tag
        End If
        cd1f.Width = cd1f.Tag/cd1b.Tag*cd1b.Width
        If cd1t.Text = "Charge:" Then
            cd1f.BackColor = Color.FromArgb(255,
                                            math.max(math.Min(255*(1 - (- Math.Pow(1.005, - cd1f.Tag) + 1)), 255), 0), 0)
        Else
            cd1f.BackColor = Color.FromArgb(math.min(math.max(255*(1 - cd1f.Tag/cd1b.Tag), 0), 255), 255, 0)
        End If
        If cd1f.Tag = cd1b.Tag Then
            If cd1t.Text = "Charge:" Then
                If cool1.Tag < 50 Then
                    cool1.Tag += 10
                    cd1t.ForeColor = Color.Green
                Else
                    cool1.Tag = 0
                    ChargeDone(cd1t.Tag.split(",")(0))
                    CoolDown(True, cd1t.Tag.split(",")(1))
                End If
            Else
                cool1.Enabled = False
                cd1t.ForeColor = Color.Green
                hidecool1.Enabled = True
            End If
        End If
    End Sub

    Private Sub magic_Click(sender As Object, e As EventArgs) Handles magic.Click
        If IsStunned(False) Then Exit Sub
        If magic_type = 1 Then
            Charge(False, 1, 0.7, 2.3)
        ElseIf magic_type = 2 Then
            Charge(False, 5, 0.5, 6.66)
        ElseIf magic_type = 3 Then
            Charge(False, 6, 3.33, 1.33)
        ElseIf magic_type = 4 Then
            Charge(False, 10, 1.89, 1.89)
        ElseIf magic_type = 5 Then
            Charge(False, 11, 4.9, 1)
        ElseIf magic_type = 6 Then
            Spell(False, 27, 0)
        ElseIf magic_type = 7 Then
            Spell(False, 24, 1)
        ElseIf magic_type = 8 Then
            Spell(False, 30, 3)
        ElseIf magic_type = 9 Then
            Spell(False, 51, 4)
        ElseIf magic_type = 10 Then
            Spell(False, 34, 9)
        ElseIf magic_type = 11 Then
            Spell(False, 96, 15)
        End If
    End Sub

    Public Sub initialization(defend_ As Integer, attack_ As Integer, magic_ As Boolean, your_life As Integer,
                              enemy_life As Integer, battle_code As Integer, Optional mana1_ As Integer = 0,
                              Optional mana2_ As Integer = 0, Optional mana1_restore As Integer = 0,
                              Optional mana2_restore As Integer = 0)
        SetParent()
        ModifyLife(True, 0)
        life1b.Tag = enemy_life
        ModifyLife(True, life1b.Tag)
        ModifyLife(False, 0)
        life2b.Tag = your_life
        ModifyLife(False, life2b.Tag)
        cd1f.Tag = cd1b.Tag
        cd2f.Tag = cd2b.Tag
        RefreshTexts()
        point1 = LockNumber(life1f.Tag)
        point2 = LockNumber(life2f.Tag)
        defend.Enabled = True
        defendt.Enabled = True
        attack.Enabled = True
        attackt.Enabled = True
        cd1f.Visible = False
        cd1b.Visible = False
        cd1t.Visible = False
        cd2f.Visible = False
        cd2b.Visible = False
        cd2t.Visible = False
        pause.Enabled = False
        defend_type = Form1.shield_level
        attack_type = Form1.weapon_level
        magic_type = magic_
        battler.Visible = True
        heal.Text = "Heal(" & Form1.heal & ")"
        paused.Width = Width
        paused.Height = Height
        Form8.start.Enabled = True
        If battle <= 2 Then
            heal.Visible = False
        Else
            heal.Visible = True
        End If
        If Form1.heal = 0 Then
            heal.Enabled = False
        Else
            heal.Enabled = True
        End If
        For i = 0 To 5
            status1(i).Visible = False
            status2(i).Visible = False
        Next
        If defend_type = 0 Then
            defend.Text = "Defend"
            defendt.Text = "Prevent 30% damage from the enemy."
        ElseIf defend_type = 1 Then
            defend.Text = "Defend"
            defendt.Text = "Prevent 50% damage from the enemy."
        ElseIf defend_type = 2 Then
            defend.Text = "Defend"
            defendt.Text = "Prevent 67% damage from the enemy."
        ElseIf defend_type = 3 Then
            defend.Text = "Defend"
            defendt.Text = "Prevent 75% damage from the enemy."
        End If
        If attack_type = 0 Then
            attack.Text = "Beat"
            attackt.Text = "Cause 5 damage."
        ElseIf attack_type = 1 Then
            attack.Text = "Thump"
            attackt.Text = "Cause 16 damage, critical hit can stun the enemy."
        ElseIf attack_type = 2 Then
            attack.Text = "Chop"
            attackt.Text = "Cause 20 damage, might bleed your enemy."
        ElseIf attack_type = 3 Then
            attack.Text = "Paw"
            attackt.Text = "Cause 15 damage, high critical probability."
        ElseIf attack_type = 4 Then
            attack.Text = "Chop+"
            attackt.Text = "Cause 30 damage, critical hit can stun the enemy."
        End If
        If mana1_ > 0 Then
            mana1f.Visible = True
            mana1b.Visible = True
            mana1t.Visible = True
            mana1t.ForeColor = Color.Blue
            mana1b.Tag = mana1_
            ModifyMana(True, mana1b.Tag/2)
            RefreshTexts()
            Mana1restore.Interval = mana1_restore
            point1mana = LockNumber(mana1f.Tag)
            mana1enabled = True
        Else
            mana1f.Visible = False
            mana1b.Visible = False
            mana1t.Visible = False
            mana1enabled = False
        End If
        If mana2_ > 0 Then
            mana2f.Visible = True
            mana2b.Visible = True
            mana2t.Visible = True
            mana2t.ForeColor = Color.Blue
            mana2b.Tag = mana2_
            ModifyMana(False, mana2b.Tag/2)
            RefreshTexts()
            Mana2restore.Interval = mana2_restore
            point2mana = LockNumber(mana2f.Tag)
            mana2enabled = True
        Else
            mana2f.Visible = False
            mana2b.Visible = False
            mana2t.Visible = False
            mana2enabled = False
        End If
        magic.Text = "Magic"
        magict.Text = "You have no magic."
        magic.Enabled = False
        magict.Enabled = False
        battle = battle_code
        StatusMove.Enabled = True
        BackgroundImage = Nothing
        If battle = 0 Then
            heal.Enabled = False
            StartTutorial()
        ElseIf battle = 1 Then
            Hide()
            Form8.Show()
            Form8.EnemyName.Text = "solar corona rabbit"
            Form8.skill1.Text = "Hit"
            Form8.skill1.Visible = True
            Form8.skill1t.Text = "Cause 4 damage."
            Form8.skill1t.Visible = True
            Form8.skill2.Text = "Corona ball"
            Form8.skill2.Visible = True
            Form8.skill2t.Text = "Cause 20 damage, burn your enemy."
            Form8.skill2t.Visible = True
            Form8.skill3.Visible = False
            Form8.skill3t.Visible = False
            defend.Enabled = True
            attack.Enabled = True
            battler.Image =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\battler1.wm")
        ElseIf battle = 2 Then
            Hide()
            Form8.Show()
            Form8.EnemyName.Text = "small black hen"
            Form8.skill1.Text = "Bite"
            Form8.skill1.Visible = True
            Form8.skill1t.Text = "Cause 4 damage."
            Form8.skill1t.Visible = True
            Form8.skill2.Text = "Accelerate"
            Form8.skill2.Visible = True
            Form8.skill2t.Text = "Increase your attack power."
            Form8.skill2t.Visible = True
            Form8.skill3.Text = "Lay egg"
            Form8.skill3.Visible = True
            Form8.skill3t.Text = "Break the egg to your enemy. Cause 31 damage."
            Form8.skill3t.Visible = True
            defend.Enabled = True
            attack.Enabled = True
            battler.Image =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\battler4.wm")
        ElseIf battle = 3 Then
            battler.Image =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\battler3.wm")
            special1.Visible = True
            defend.Enabled = False
            attack.Enabled = False
            heal.Enabled = False
        ElseIf battle = 4 Then
            Hide()
            Form8.Show()
            Form8.EnemyName.Text = "crazy murloc"
            Form8.skill1.Text = "Bite"
            Form8.skill1.Visible = True
            Form8.skill1t.Text = "Cause 7 damage."
            Form8.skill1t.Visible = True
            Form8.skill2.Text = "Roar"
            Form8.skill2.Visible = True
            Form8.skill2t.Text = "Interrupt your enemy's charge."
            Form8.skill2t.Visible = True
            Form8.skill3.Visible = False
            Form8.skill3t.Visible = False
            defend.Enabled = True
            attack.Enabled = True
            battler.Image =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\battler5_1.wm")
        ElseIf battle = 5 Or battle = 6 Then
            Hide()
            Form8.Show()
            Form8.EnemyName.Text = "insane murloc"
            Form8.skill1.Text = "Hit"
            Form8.skill1.Visible = True
            Form8.skill1t.Text = "Cause 17 damage."
            Form8.skill1t.Visible = True
            Form8.skill2.Text = "Defend"
            Form8.skill2.Visible = True
            Form8.skill2t.Text = "Prevent 67% damage."
            Form8.skill2t.Visible = True
            Form8.skill3.Visible = False
            Form8.skill3t.Visible = False
            defend.Enabled = True
            attack.Enabled = True
            Current_Murloc_Number = random_.Next(2, 5)
            battler.Image =
                Image.FromFile(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\battler5_" &
                    Current_Murloc_Number & ".wm")
        ElseIf battle = 7 Then
            Hide()
            Form8.Show()
            Form8.EnemyName.Text = "turk&fish"
            Form8.skill1.Text = "Poison bite"
            Form8.skill1.Visible = True
            Form8.skill1t.Text = "Cause 10 damage. Poison your enemy."
            Form8.skill1t.Visible = True
            Form8.skill2.Text = "Rip"
            Form8.skill2.Visible = True
            Form8.skill2t.Text = "Cause 20 damage. Bleed your enemy."
            Form8.skill2t.Visible = True
            Form8.skill3.Text = "Absorb"
            Form8.skill3.Visible = True
            Form8.skill3t.Text = "Make 30 absorption."
            Form8.skill3t.Visible = True
            defend.Enabled = True
            attack.Enabled = True
            battler.Image =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\battler6.wm")
        ElseIf battle = 8 Then
            Hide()
            Form8.Show()
            Form8.EnemyName.Text = "turk&fish lord"
            Form8.skill1.Text = "Chop"
            Form8.skill1.Visible = True
            Form8.skill1t.Text = "Cause 10 damage."
            Form8.skill1t.Visible = True
            Form8.skill2.Text = "Roar"
            Form8.skill2.Visible = True
            Form8.skill2t.Text = "Cause -15, may discombobulate the enemy."
            Form8.skill2t.Visible = True
            Form8.skill3.Text = "Strike wave"
            Form8.skill3.Visible = True
            Form8.skill3t.Text = "Cause 25 damage. Break the defence of your enemy."
            Form8.skill3t.Visible = True
            defend.Enabled = True
            attack.Enabled = True
            battler.Image =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\battler8.wm")
        ElseIf battle = 9 Then
            Hide()
            Form8.Show()
            Form8.EnemyName.Text = "turkey eater worm"
            Form8.skill1.Text = "Worry"
            Form8.skill1.Visible = True
            Form8.skill1t.Text = "Cause 14 damage."
            Form8.skill1t.Visible = True
            Form8.skill2.Text = "Mucus"
            Form8.skill2.Visible = True
            Form8.skill2t.Text = "Corrode the enemy."
            Form8.skill2t.Visible = True
            Form8.skill3.Text = "Burrow"
            Form8.skill3.Visible = True
            Form8.skill3t.Text = "Avoid attacks for 4 seconds."
            Form8.skill3t.Visible = True
            defend.Enabled = True
            attack.Enabled = True
            AddStatus(True, 17, - 1)
            battler.Image =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\battler9.wm")
            TargetLife1_battle9 = life1f.Tag*random_.Next(20, 80)/100
            TargetLife2_battle9 = life2f.Tag*random_.Next(20, 80)/100
        ElseIf battle = 10 Then
            Hide()
            Form8.Show()
            Form8.EnemyName.Text = "big milk cow"
            Form8.skill1.Text = "Impact"
            Form8.skill1.Visible = True
            Form8.skill1t.Text = "Cause 21 damage."
            Form8.skill1t.Visible = True
            Form8.skill2.Text = "Defend"
            Form8.skill2.Visible = True
            Form8.skill2t.Text = "Prevent 50% damage."
            Form8.skill2t.Visible = True
            Form8.skill3.Text = "Smelly milk"
            Form8.skill3.Visible = True
            Form8.skill3t.Text = "Cause 30 damage, may poison the enemy."
            Form8.skill3t.Visible = True
            defend.Enabled = True
            attack.Enabled = True
            AddStatus(True, 19, - 1)
            battler.Image =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\battler10.wm")
        ElseIf battle = 11 Then
            Hide()
            Form8.Show()
            Form8.EnemyName.Text = "Avogadro turkey"
            Form8.skill1.Text = "NaAlO2"
            Form8.skill1.Visible = True
            Form8.skill1t.Text = "Cause 3 damage."
            Form8.skill1t.Visible = True
            Form8.skill2.Text = "Al(OH)3"
            Form8.skill2.Visible = True
            Form8.skill2t.Text = "Cause 9 damage."
            Form8.skill2t.Visible = True
            Form8.skill3.Text = "Al2(SO4)3"
            Form8.skill3.Visible = True
            Form8.skill3t.Text = "Cause 3 or 9 damage."
            Form8.skill3t.Visible = True
            defend.Enabled = True
            attack.Enabled = True
            battler.Image =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\battler11.wm")
        ElseIf battle = 12 Then
            battler.Image =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\battler12.wm")
            special1.Visible = True
            defend.Enabled = False
            attack.Enabled = False
            heal.Enabled = False
            content1.Tag = 6
            special1.Text = "Mana Magic"
            content1.Text =
                "You've unlocked a new type of powerful magic: the mana-required magic. It costs mana to spell."
        ElseIf battle = 13 Then
            Hide()
            Form8.Show()
            Form8.EnemyName.Text = "palace guard"
            Form8.skill1.Text = "Chop"
            Form8.skill1.Visible = True
            Form8.skill1t.Text = "Cause 22 damage."
            Form8.skill1t.Visible = True
            Form8.skill2.Text = "Iron wave"
            Form8.skill2.Visible = True
            Form8.skill2t.Text = "Cause 30 damage, ignore your enemy's defence."
            Form8.skill2t.Visible = True
            Form8.skill3.Text = "Assault"
            Form8.skill3.Visible = True
            Form8.skill3t.Text = "Cause 40 damage to your enemy and 15 damage to yourself."
            Form8.skill3t.Visible = True
            defend.Enabled = True
            attack.Enabled = True
            battler.Image =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\battler13.wm")
            AddStatus(True, 21, - 1)
        ElseIf battle = 14 Then
            Hide()
            Form8.Show()
            Form8.EnemyName.Text = "Atropos"
            Form8.skill1.Text = "Destine"
            Form8.skill1.Visible = True
            Form8.skill1t.Text = "Destroy your enemy."
            Form8.skill1t.Visible = True
            Form8.skill2.Visible = False
            Form8.skill2t.Visible = False
            Form8.skill3.Visible = False
            Form8.skill3t.Visible = False
            defend.Enabled = True
            attack.Enabled = True
            battler.Image =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image2.wm")
        ElseIf battle = 15 Then
            Hide()
            Form8.Show()
            Form8.EnemyName.Text = "Tarecgosa"
            Form8.skill1.Text = "Paw"
            Form8.skill1.Visible = True
            Form8.skill1t.Text = "Cause 20 damage."
            Form8.skill1t.Visible = True
            Form8.skill2.Text = "Homework line"
            Form8.skill2.Visible = True
            Form8.skill2t.Text = "Cause 30 damage, confuse your enemy."
            Form8.skill2t.Visible = True
            Form8.skill3.Text = "Laser"
            Form8.skill3.Visible = True
            Form8.skill3t.Text = "Cause 40 damage, double to non-defence enemy."
            Form8.skill3t.Visible = True
            defend.Enabled = True
            attack.Enabled = True
            battler.Image =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\battler14.wm")
            AddStatus(True, 23, - 1)
        ElseIf battle = 16 Then
            Hide()
            Form8.Show()
            Form8.EnemyName.Text = "floating ghost"
            Form8.skill1.Text = "Scare"
            Form8.skill1.Visible = True
            Form8.skill1t.Text = "Cause 15 damage, maybe frighten the enemy."
            Form8.skill1t.Visible = True
            Form8.skill2.Text = "Curse"
            Form8.skill2.Visible = True
            Form8.skill2t.Text = "Absorb 5% of your enemy's life."
            Form8.skill2t.Visible = True
            Form8.skill3.Text = "Distort"
            Form8.skill3.Visible = True
            Form8.skill3t.Text = "Reduce 50HP and 20MP from your enemy."
            Form8.skill3t.Visible = True
            defend.Enabled = True
            attack.Enabled = True
            battler.Image =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\battler15.wm")
            AddStatus(True, 26, - 1)
        ElseIf battle = 17 Then
            battler.Image =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image15.wm")
            special1.Visible = True
            defend.Enabled = False
            attack.Enabled = False
            heal.Enabled = False
            content1.Tag = 9
            content1.Text =
                "The witch can change to turtle or turkey, the turtle is immune to physical damage but suffers more from magical damage."
        ElseIf battle = 18 Then
            Hide()
            Form8.Show()
            Form8.EnemyName.Text = "duck pool god"
            Form8.skill1.Text = "Peck"
            Form8.skill1.Visible = True
            Form8.skill1t.Text = "Cause 16 damage fast."
            Form8.skill1t.Visible = True
            Form8.skill2.Text = "Vector spike"
            Form8.skill2.Visible = True
            Form8.skill2t.Text = "Cause 29 damage and confuse your enemy."
            Form8.skill2t.Visible = True
            Form8.skill3.Text = "Aluminum triangle"
            Form8.skill3.Visible = True
            Form8.skill3t.Text = "Cause 66 damage, interrupt your enemy's charge."
            Form8.skill3t.Visible = True
            defend.Enabled = True
            attack.Enabled = True
            battler.Image =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image23.wm")
        ElseIf battle = 19 Then
            Hide()
            Form8.Show()
            Form8.EnemyName.Text = "witch"
            Form8.skill1.Text = "Energy"
            Form8.skill1.Visible = True
            Form8.skill1t.Text = "Cause 60 damage."
            Form8.skill1t.Visible = True
            Form8.skill2.Text = "Mirror"
            Form8.skill2.Visible = True
            Form8.skill2t.Text = "Mirror last gotten magical damage to your enemy."
            Form8.skill2t.Visible = True
            Form8.skill3.Text = "Charm"
            Form8.skill3.Visible = True
            Form8.skill3t.Text = "Charm your enemy."
            Form8.skill3t.Visible = True
            defend.Enabled = True
            attack.Enabled = True
            battler.Image =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image10.wm")
            If Not Form1.Unlocked.Items.Contains("straight defeat witch") Then AddStatus(True, 29, - 1)
        ElseIf battle = 20 Then
            Hide()
            Form8.Show()
            Form8.EnemyName.Text = "chicken"
            Form8.skill1.Text = "Peck"
            Form8.skill1.Visible = True
            Form8.skill1t.Text = "Cause 10 damage."
            Form8.skill1t.Visible = True
            Form8.skill2.Text = "Shoot eggs"
            Form8.skill2.Visible = True
            Form8.skill2t.Text = "Cause 50 damage, may stun the enemy."
            Form8.skill2t.Visible = True
            Form8.skill3.Visible = False
            Form8.skill3t.Visible = False
            defend.Enabled = True
            attack.Enabled = True
            battler.Image =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\battler16.wm")
        ElseIf battle = 21 Then
            Hide()
            Form8.Show()
            Form8.EnemyName.Text = "negative positive cow"
            Form8.skill1.Text = "Kick"
            Form8.skill1.Visible = True
            Form8.skill1t.Text = "Cause 17 damage."
            Form8.skill1t.Visible = True
            Form8.skill2.Text = "negative gas"
            Form8.skill2.Visible = True
            Form8.skill2t.Text = "Cause 49 damage ,may poison your enemy."
            Form8.skill2t.Visible = True
            Form8.skill3.Text = "Nether power"
            Form8.skill3.Visible = True
            Form8.skill3t.Text = "Absorb 55 from your enemy."
            Form8.skill3t.Visible = True
            defend.Enabled = True
            attack.Enabled = True
            AddStatus(True, 32, - 1)
            If Form1.DeathFlagNum = 8 Then
                battler.Image =
                    Image.FromFile(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\battler20.wm")
            Else
                battler.Image =
                    Image.FromFile(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\battler18.wm")
            End If
        ElseIf battle = 22 Then
            Hide()
            Form8.Show()
            Form8.EnemyName.Text = "Mr.Duck phantom"
            Form8.skill1.Text = "Peck"
            Form8.skill1.Visible = True
            Form8.skill1t.Text = "Cause 20 damage."
            Form8.skill1t.Visible = True
            Form8.skill2.Text = "Overload"
            Form8.skill2.Visible = True
            Form8.skill2t.Text = "Cause (x^2)/50 damage ,x= enemy mana."
            Form8.skill2t.Visible = True
            Form8.skill3.Text = "Tangent"
            Form8.skill3.Visible = True
            Form8.skill3t.Text = "Cause 40|tan(θ°)|, θ=enemy life. (Absolute damage)"
            Form8.skill3t.Visible = True
            defend.Enabled = True
            attack.Enabled = True
            battler.Image =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image44.wm")
            BackgroundImage =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\background1.wm")
            BackgroundImageLayout = ImageLayout.Stretch
            AddStatus(True, 32, - 1)
        ElseIf battle = 23 Then
            Hide()
            Form8.Show()
            Form8.EnemyName.Text = "???"
            Form8.skill1.Text = "Laser"
            Form8.skill1.Visible = True
            Form8.skill1t.Text = "Cause 100 damage."
            Form8.skill1t.Visible = True
            Form8.skill2.Text = "Pray"
            Form8.skill2.Visible = True
            Form8.skill2t.Text = "Restore 10% of your life."
            Form8.skill2t.Visible = True
            Form8.skill3.Text = "Immolate"
            Form8.skill3.Visible = True
            Form8.skill3t.Text = "The enemy loses 25%HP and 100%MP. (Absolute damage, 100% hit rate)"
            Form8.skill3t.Visible = True
            defend.Enabled = True
            attack.Enabled = True
            battler.Image = Form20.Scathach
            BackgroundImage =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\NewScene1.wm")
            BackgroundImageLayout = ImageLayout.Center
            AddStatus(True, 35, - 1)
        ElseIf battle = 24 Then
            Hide()
            Form8.Show()
            Form8.EnemyName.Text = "Turkey rider"
            Form8.skill1.Text = "Cry"
            Form8.skill1.Visible = True
            Form8.skill1t.Text = "Cry out some turkey sound."
            Form8.skill1t.Visible = True
            Form8.skill2.Text = "Kick"
            Form8.skill2.Visible = True
            Form8.skill2t.Text = "Cause 1 damage."
            Form8.skill2t.Visible = True
            Form8.skill3.Visible = False
            Form8.skill3t.Visible = False
            defend.Enabled = True
            attack.Enabled = True
            battler.Image =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image54.wm")
        End If
        Form8.StupidDelay()

        If battle = 8 Or battle = 15 Or battle = 19 Then
            Form8.start.Text = "Next"
            Form8.boss.Visible = True
            Form8.BackColor = Color.Yellow
            Form8.skill1.BackColor = Color.Orange
            Form8.skill2.BackColor = Color.Orange
            Form8.skill3.BackColor = Color.Orange
        Else
            Form8.start.Text = "Start!"
            Form8.boss.Visible = False
            Form8.BackColor = Color.WhiteSmoke
            Form8.skill1.BackColor = Color.White
            Form8.skill2.BackColor = Color.White
            Form8.skill3.BackColor = Color.White
        End If
    End Sub

    Private Sub CoolDown(player1 As Boolean, time_ As Double)
        If player1 Then
            cd1t.Text = "Cool down:"
            cd1t.ForeColor = Color.Black
            cd1f.Tag = 0
            cd1b.Tag = 100*time_
            cd1f.Visible = True
            cd1b.Visible = True
            cd1t.Visible = True
            cool1.Enabled = True
            hidecool1.Enabled = False
        Else
            cd2t.Text = "Cool down:"
            cd2t.ForeColor = Color.Black
            defend.Enabled = False
            attack.Enabled = False
            assist.Enabled = False
            magic.Enabled = False
            heal.Enabled = False
            cd2f.Tag = 0
            cd2b.Tag = 100*time_
            cd2f.Visible = True
            cd2b.Visible = True
            cd2t.Visible = True
            cool2.Enabled = True
            hidecool2.Enabled = False
        End If
    End Sub

    Private Sub cool2_Tick(sender As Object, e As EventArgs) Handles cool2.Tick
        Dim totalsec = 10
        If HasStatus(False, 2) Then totalsec *= 5
        If HasStatus(False, 9) Then totalsec *= 2
        If HasStatus(False, 22) Then totalsec *= 2
        cool2.Interval = totalsec
        If Not cd2f.Tag = cd2b.Tag And Not IsStunned(False) Then cd2f.Tag += 1
        If IsStunned(False) And cd2t.Text = "Charge:" Then StopCharge2 = True
        If StopCharge2 Then
            StopCharge2 = False
            CoolDown(False, Math.Max(0, cd2t.Tag.split(",")(1)/3))
        End If
        if (cd2f.Tag > cd2b.Tag) then
            cd2f.Tag = cd2b.Tag
        End If
        cd2f.Width = cd2f.Tag/cd2b.Tag*cd2b.Width
        If cd2t.Text = "Charge:" Then
            cd2f.BackColor = Color.FromArgb(255,
                                            math.Min(math.Max(255*(1 - (- Math.Pow(1.005, - cd2f.Tag) + 1)), 0), 255), 0)
        Else
            cd2f.BackColor = Color.FromArgb(math.max(math.min(255*(1 - cd2f.Tag/cd2b.Tag), 255), 0), 255, 0)
        End If
        If cd2f.Tag = cd2b.Tag Then
            If cd2t.Text = "Charge:" Then
                If cool2.Tag < 50 Then
                    cool2.Tag += 10
                    cd2t.ForeColor = Color.Green
                Else
                    cool2.Tag = 0
                    ChargeDone(cd2t.Tag.split(",")(0))
                    CoolDown(False, cd2t.Tag.split(",")(1))
                End If
            Else
                cool2.Enabled = False
                cd2t.ForeColor = Color.Green
                hidecool2.Enabled = True
                If Not step_ = 3 And Not step_ = 5 Then
                    defend.Enabled = True
                    attack.Enabled = True
                    assist.Enabled = True
                    magic.Enabled = magict.Enabled
                    If Form1.heal > 0 And Not battle = 5 Then heal.Enabled = True
                End If
                If step_ = 5 Then
                    tutorial.Visible = True
                    next_.Enabled = True
                    content.Text = "Press ""Next""."
                End If
            End If
        End If
    End Sub

    Private Sub defend_Click(sender As Object, e As EventArgs) Handles defend.Click
        If IsStunned(False) Then Exit Sub
        If step_ = 5 Then tutorial.Visible = False
        If defend_type = 0 Then
            CoolDown(False, 2)
            ShowTitle("Defend.", Color.Black)
            AddStatus(False, 0, 3.7)
            My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound4.wm")
        ElseIf defend_type = 1 Then
            CoolDown(False, 2.1)
            ShowTitle("Defend.", Color.Black)
            AddStatus(False, 5, 4)
            My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound4.wm")
        ElseIf defend_type = 2 Then
            CoolDown(False, 2.24)
            ShowTitle("Defend.", Color.Black)
            AddStatus(False, 10, 4.4)
            My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound4.wm")
        ElseIf defend_type = 3 Then
            CoolDown(False, 2.07)
            ShowTitle("Defend.", Color.Black)
            AddStatus(False, 24, 4.3)
            My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound4.wm")
        End If
    End Sub

    Public Sub StartTutorial()
        tutorial.Visible = True
        defend.Enabled = False
        attack.Enabled = False
    End Sub

    Private Sub titleshow_Tick(sender As Object, e As EventArgs) Handles titleshow.Tick
        If boss And BeforeTip < 25 Then
            BeforeTip += 1
            title.Tag += 1
            If Tipcolor = Color.Black Then
                title.ForeColor = Color.FromArgb(255 - 10*BeforeTip, 255 - 10*BeforeTip, 255 - 10*BeforeTip)
            ElseIf Tipcolor = Color.Red Then
                title.ForeColor = Color.FromArgb(255, 255 - 10*BeforeTip, 255 - 10*BeforeTip)
            ElseIf Tipcolor = Color.Green Then
                title.ForeColor = Color.FromArgb(255 - 10*BeforeTip, 128 - 5*BeforeTip, 255 - 10*BeforeTip)
            End If
            Exit Sub
        Else
            title.ForeColor = Tipcolor
        End If
        If title.Tag > 0 Then title.Tag -= 1
        If title.Tag = 0 Then
            If boss And BeforeTip < 50 Then
                BeforeTip += 1
                If Tipcolor = Color.Black Then
                    title.ForeColor = Color.FromArgb(10*(BeforeTip - 25), 10*(BeforeTip - 25), 10*(BeforeTip - 25))
                ElseIf Tipcolor = Color.Red Then
                    title.ForeColor = Color.FromArgb(255, 10*(BeforeTip - 25), 10*(BeforeTip - 25))
                ElseIf Tipcolor = Color.Green Then
                    title.ForeColor = Color.FromArgb(10*(BeforeTip - 25), 128 + 5*(BeforeTip - 25), 10*(BeforeTip - 25))
                End If
                Exit Sub
            End If
            titleshow.Enabled = False
            title.Visible = False
            title.ForeColor = Color.Black
        End If
    End Sub

    Private Sub ShowTitle(text_ As String, color_ As Color)
        title.Text = text_
        title.Tag = 200
        Tipcolor = color_
        BeforeTip = 0
        titleshow.Enabled = True
        title.ForeColor = color_
        title.Visible = True
    End Sub

    Private Sub next__Click(sender As Object, e As EventArgs) Handles next_.Click
        If step_ = 0 Then
            step_ = 1
            skip.Visible = False
            content.Text =
                "You'll fight the turkey egg and defeat it. The life bar in top shows the turkey's life, the bar in bottom shows yours."
        ElseIf step_ = 1 Then
            step_ = 2
            content.Text =
                "If one's life turns to 0, it'll get defeated. First, let's learn how to attack the turkey egg. Press ""Next""."
        ElseIf step_ = 2 Then
            step_ = 3
            next_.Enabled = False
            attack.Enabled = True
            content.Text =
                "There's the attack button ""Beat"", click on it, then you can cause damage to the turkey egg. After clicking it, press ""Next""."
        ElseIf step_ = 3 Then
            If Not cd2f.Tag = cd2b.Tag Then Exit Sub
            step_ = 4
            content.Text =
                "That's good. However, after each attack, there'll be cool down time, before it cools down, you cannot do anything."
        ElseIf step_ = 4 Then
            step_ = 5
            next_.Enabled = False
            defend.Enabled = True
            content.Text =
                "Your enemy also can attack. To defend its attack, you should click on the ""Defend"". Click it now, then press ""Next""."
        ElseIf step_ = 5 Then
            step_ = 6
            content.Text =
                "While you're defending, the damage you get will be reduced. It also takes cool down time. You also need not to defend all the time."
        ElseIf step_ = 6 Then
            step_ = 7
            content.Text =
                "There's also magic power, but you don't have it at present, you'll collect magic items in future which will take great effect in battle."
        ElseIf step_ = 7 Then
            step_ = 8
            content.Text = "That's all, let the battle begin."
        ElseIf step_ = 8 Then
            tutorial.Visible = False
            tutorialend()
        End If
    End Sub

    Private Sub skip_Click(sender As Object, e As EventArgs) Handles skip.Click
        If MsgBox("Do you want to skip the tutorial?", vbQuestion + vbYesNo, "Skip tutorial") = vbYes Then
            tutorial.Visible = False
            defend.Enabled = True
            attack.Enabled = True
            tutorialend()
        End If
    End Sub

    Private Sub hidecool1_Tick(sender As Object, e As EventArgs) Handles hidecool1.Tick
        hidecool1.Enabled = False
        cd1f.Visible = False
        cd1b.Visible = False
        cd1t.Visible = False
    End Sub

    Private Sub hidecool2_Tick(sender As Object, e As EventArgs) Handles hidecool2.Tick
        hidecool2.Enabled = False
        cd2f.Visible = False
        cd2b.Visible = False
        cd2t.Visible = False
    End Sub

    Private Sub EnemyAction_Tick(sender As Object, e As EventArgs) Handles EnemyAction.Tick
        CheckForCheating()
        If IsStunned(True) Or HasStatus(True, 20) Then Exit Sub
        EnemyAction.Interval = random_.Next(750, 1500)
        If cd1t.Text = "Charge:" And cool1.Enabled = False Then cd1t.Text = "Cool down:"
        If cd1f.Tag < cd1b.Tag Or cd1t.Text = "Charge:" Then Exit Sub
        CheckForMissCritical(True)
        If battle = 0 Then
            Dim hitpower As Integer = random_.Next(1, 101)
            If hitpower >= 95 - MissProbability1 Then
                ShowTitle("The turkey egg bumps (Miss the target.)", Color.Gold)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
            ElseIf hitpower <= 5 + CriticalProbability1 Then
                ChangePower(False, - 36, True)
                ShowTitle("The turkey egg bumps (Critical Hit!)", Color.Red)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound3.wm")
            Else
                ChangePower(False, - 12)
                ShowTitle("The turkey egg bumps.", Color.Black)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound3.wm")
            End If
            CoolDown(True, 2)
        ElseIf battle = 1 Then
            Dim choice As Integer = random_.Next(1, 6)
            If choice <= 4 Then
                Dim hitpower As Integer = random_.Next(1, 101)
                If hitpower >= 95 - MissProbability1 Then
                    ShowTitle("The solar corona rabbit hits (Miss the target.)", Color.Gold)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
                ElseIf hitpower <= 5 + CriticalProbability1 Then
                    ChangePower(False, - 12, True)
                    ShowTitle("The solar corona rabbit hits (Critical Hit!)", Color.Red)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound3.wm")
                Else
                    ChangePower(False, - 4)
                    ShowTitle("The solar corona rabbit hits.", Color.Black)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound3.wm")
                End If
                CoolDown(True, 0.9)
            Else
                Charge(True, 0, 1.4, 2.2)
            End If
        ElseIf battle = 2 Then
            Dim choice As Integer = random_.Next(1, 8)
            If choice <= 4 Then
                Dim hitpower As Integer = random_.Next(1, 101)
                If hitpower >= 95 - MissProbability1 Then
                    ShowTitle("The small black hen bites (Miss the target.)", Color.Gold)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
                ElseIf hitpower <= 4 + CriticalProbability1 Then
                    ChangePower(False, - 16, True)
                    ShowTitle("The small black hen bites (Critical Hit!)", Color.Red)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound14.wm")
                Else
                    ChangePower(False, - 4)
                    ShowTitle("The small black hen bites.", Color.Black)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound14.wm")
                End If
                CoolDown(True, 1.4)
            ElseIf choice = 5 Then
                AddStatus(True, 3, 17.4)
                ShowTitle("The small black hen powers up.", Color.Black)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound15.wm")
                CoolDown(True, 4.33)
            Else
                Charge(True, 2, 5.55, 3.44)
            End If
        ElseIf battle = 3 Then
            Dim choice As Integer = random_.Next(1, 12)
            If choice <= 10 Then
                Dim hitpower As Integer = random_.Next(1, 101)
                If hitpower >= 93 - MissProbability1 Then
                    ShowTitle("The solar corona ball strikes (Miss the target.)", Color.Gold)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
                ElseIf hitpower <= 20 + CriticalProbability1 Then
                    ChangePower(False, - 39, True, False, False, True, True)
                    ShowTitle("The solar corona ball strikes (Critical Hit!)", Color.Red)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound14.wm")
                Else
                    ChangePower(False, - 13, False, False, False, True, True)
                    ShowTitle("The solar corona ball strikes.", Color.Black)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound14.wm")
                End If
                CoolDown(True, 1.5)
            ElseIf choice = 10 Then
                Charge(True, 3, 2, 1.75)
            ElseIf choice = 11 Then
                If IsStunned(False) Then Exit Sub
                Charge(True, 4, 4, 1.5)
            End If
        ElseIf battle = 4 Then
            If cd2t.Text = "Charge:" Then
                ChangePower(False, 0)
                ShowTitle("The crazy murloc roars.", Color.Black)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound26.wm")
                StopCharge2 = True
                CoolDown(True, 1)
            Else
                Dim hitpower As Integer = random_.Next(1, 101)
                If hitpower >= 94 - MissProbability1 Then
                    ShowTitle("The crazy murloc bites (Miss the target.)", Color.Gold)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
                ElseIf hitpower <= 6 + CriticalProbability1 Then
                    ChangePower(False, - 21, True)
                    ShowTitle("The crazy murloc bites (Critical Hit!)", Color.Red)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound3.wm")
                Else
                    ChangePower(False, - 7)
                    ShowTitle("The crazy murloc bites.", Color.Black)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound3.wm")
                End If
                CoolDown(True, 1.84)
            End If
            If Form11.try_to_avoid Then
                Form11.try_to_avoid = False
                ChangePower(False, - 60, False, True, False, False, False)
            End If
        ElseIf battle = 5 Or battle = 6 Then
            If life1f.Tag = 0 Then Exit Sub
            Dim choice As Integer = random_.Next(1, 10)
            Dim defendpoint = 9
            If cd2t.Text = "Charge:" Then defendpoint = 5
            If choice >= defendpoint Then
                AddStatus(True, 10, 4)
                ShowTitle("The insane murloc" & number.Maximum - number.Value + 1 & " defends.", Color.Black)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound4.wm")
                CoolDown(True, 1)
            Else
                Dim hitpower As Integer = random_.Next(1, 101)
                If hitpower >= 95 - MissProbability1 Then
                    ShowTitle("The insane murloc" & number.Maximum - number.Value + 1 & " hits (Miss the target.)",
                              Color.Gold)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
                ElseIf hitpower <= 5 + CriticalProbability1 Then
                    ChangePower(False, - 51, True)
                    ShowTitle("The insane murloc" & number.Maximum - number.Value + 1 & " hits (Critical Hit!)",
                              Color.Red)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound3.wm")
                Else
                    ChangePower(False, - 17)
                    ShowTitle("The insane murloc" & number.Maximum - number.Value + 1 & " hits.", Color.Black)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound3.wm")
                End If
                CoolDown(True, 0.6)
            End If
        ElseIf battle = 7 Then
            Dim choice As Integer = random_.Next(1, 7)
            Dim hitpower As Integer = random_.Next(1, 101)
            If choice = 1 Then
                If hitpower >= 93 - MissProbability1 Then
                    ShowTitle("The turk&fish bites (Miss the target.)", Color.Gold)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
                ElseIf hitpower <= 3 + CriticalProbability1 Then
                    ChangePower(False, - 30, True)
                    AddStatus(False, 12, 45)
                    ShowTitle("The turk&fish bites (Critical Hit!)", Color.Red)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound3.wm")
                Else
                    ChangePower(False, - 10, False)
                    AddStatus(False, 12, 15)
                    ShowTitle("The turk&fish bites.", Color.Black)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound3.wm")
                End If
                CoolDown(True, 4.41)
            ElseIf choice >= 2 And choice <= 4 Then
                If hitpower >= 96 - MissProbability1 Then
                    ShowTitle("The turk&fish rips (Miss the target.)", Color.Gold)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
                ElseIf hitpower <= 5 + CriticalProbability1 Then
                    ChangePower(False, - 60, True)
                    AddStatus(False, 13, 15)
                    ShowTitle("The turk&fish rips (Critical Hit!)", Color.Red)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound14.wm")
                Else
                    ChangePower(False, - 20, False)
                    AddStatus(False, 13, 5)
                    ShowTitle("The turk&fish rips.", Color.Black)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound14.wm")
                End If
                CoolDown(True, 3.77)
            Else
                Charge(True, 8, 1.7, 3.3)
            End If
        ElseIf battle = 8 Then
            Dim choice As Integer = random_.Next(1, 10)
            Dim hitpower As Integer = random_.Next(1, 101)
            If cd2t.Text = "Charge:" And random_.Next(1, 11) <= 3 Then GoTo skill8_2
            If HasStatus(False, 0) Or HasStatus(False, 5) Or HasStatus(False, 10) And random_.Next(1, 6) <= 2 Then _
                GoTo skill8_3
            If choice <= 6 Then
                If hitpower >= 95 - MissProbability1 Then
                    ShowTitle("The turk&fish lord chops (Miss the target.)", Color.Gold)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
                ElseIf hitpower <= 5 + CriticalProbability1 Then
                    ChangePower(False, - 30, True)
                    ShowTitle("The turk&fish lord chops (Critical Hit!)", Color.Red)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound29.wm")
                Else
                    ChangePower(False, - 10, False)
                    ShowTitle("The turk&fish lord chops.", Color.Black)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound29.wm")
                End If
                CoolDown(True, 2.5)
            ElseIf choice = 7 Or choice = 8 Then
                skill8_2:
                If hitpower >= 99 - MissProbability1 Then
                    ShowTitle("The turk&fish lord roars (Failed to spell.)", Color.Gold)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
                ElseIf hitpower <= 7 + CriticalProbability1 Then
                    ChangePower(False, - 45, True, False, False, True, True)
                    ShowTitle("The turk&fish lord roars (Critical Hit!)", Color.Red)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound27.wm")
                    If New Random(Date.Now.Second).Next(1, 3) = 1 Then AddStatus(False, 14, 10)
                Else
                    ChangePower(False, - 15, False, False, False, True, True)
                    ShowTitle("The turk&fish lord roars.", Color.Black)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound27.wm")
                    If New Random(Date.Now.Second).Next(1, 5) = 1 Then AddStatus(False, 14, 5)
                End If
                CoolDown(True, 3.5)
            ElseIf choice = 9 Then
                skill8_3:
                Charge(True, 9, 0.55, 3.7)
            End If
        ElseIf battle = 9 Then
            Dim choice As Integer = random_.Next(1, 10)
            Dim hitpower As Integer = random_.Next(1, 101)
            If cd2t.Text = "Charge:" And New Random(Now.Date.Second).Next(1, 4) = 1 Then GoTo skill9_3
            If choice <= 5 Then
                skill9_1:
                If hitpower >= 95 - MissProbability1 Then
                    ShowTitle("The turkey eater worm worries (Miss the target.)", Color.Gold)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
                ElseIf hitpower <= 4 + CriticalProbability1 Then
                    ChangePower(False, - 42, True)
                    ShowTitle("The turkey eater worm worries (Critical Hit!)", Color.Red)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound14.wm")
                Else
                    ChangePower(False, - 14, False)
                    ShowTitle("The turkey eater worm worries.", Color.Black)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound14.wm")
                End If
                CoolDown(True, 1.96)
            ElseIf choice >= 6 And choice <= 8 And HasDefence(False) = False Then
                Charge(True, 12, 2.4, 1.2)
            Else
                skill9_3:
                If HasStatus(False, 18) Then GoTo skill9_1
                Charge(True, 13, 1, 4)
            End If
        ElseIf battle = 10 Then
            Dim choice As Integer = random_.Next(1, 9)
            Dim hitpower As Integer = random_.Next(1, 101)
            If HasDefence(True) = False And cd2t.Text = "Charge:" And New Random(Now.Date.Second).Next(1, 4) = 1 Then _
                GoTo skill10_3
            If choice <= 6 Then
                If hitpower >= 92 - MissProbability1 Then
                    ShowTitle("The big milk cow impacts (Miss the target.)", Color.Gold)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
                ElseIf hitpower <= 7 + CriticalProbability1 Then
                    ChangePower(False, - 60, True)
                    ShowTitle("The big milk cow impacts (Critical Hit!)", Color.Red)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound12.wm")
                Else
                    ChangePower(False, - 20, False)
                    ShowTitle("The big milk cow impacts.", Color.Black)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound12.wm")
                End If
                CoolDown(True, 2.01)
            ElseIf choice <= 8 Then
                Charge(True, 14, 2.3, 1.7)
            Else
                skill10_3:
                AddStatus(True, 5, 3)
                ShowTitle("The big milk cow defends.", Color.Black)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
                CoolDown(True, 1.9)
            End If
        ElseIf battle = 11 Then
            Dim choice As Integer = random_.Next(1, 4)
            Dim hitpower As Integer = random_.Next(1, 101)
            If choice = 1 Then
                If hitpower >= 95 - MissProbability1 Then
                    ShowTitle("The Avogadro turkey throws NaAlO2 (Miss the target.)", Color.Gold)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
                ElseIf hitpower <= 10 + CriticalProbability1 Then
                    ChangePower(False, - 9, True)
                    ShowTitle("The Avogadro turkey throws NaAlO2 (Critical Hit!)", Color.Red)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound14.wm")
                Else
                    ChangePower(False, - 3)
                    ShowTitle("The Avogadro turkey throws NaAlO2.", Color.Black)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound14.wm")
                End If
                CoolDown(True, 0.4)
            ElseIf choice = 2 Then
                If hitpower >= 90 - MissProbability1 Then
                    ShowTitle("The Avogadro turkey throws Al(OH)3 (Miss the target.)", Color.Gold)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
                ElseIf hitpower <= 5 + CriticalProbability1 Then
                    ChangePower(False, - 27, True)
                    ShowTitle("The Avogadro turkey throws Al(OH)3 (Critical Hit!)", Color.Red)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound12.wm")
                Else
                    ChangePower(False, - 9)
                    ShowTitle("The Avogadro turkey throws Al(OH)3.", Color.Black)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound12.wm")
                End If
                CoolDown(True, 1.1)
            ElseIf choice = 3 Then
                If hitpower >= 90 - MissProbability1 Then
                    ShowTitle("The Avogadro turkey throws Al2(SO4)3 (Miss the target.)", Color.Gold)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
                ElseIf hitpower <= 10 + CriticalProbability1 Then
                    If New Random(Now.Date.Second).Next(0, 2) = 0 Then
                        ChangePower(False, - 9, True)
                    Else
                        ChangePower(False, - 27, True)
                    End If
                    ShowTitle("The Avogadro turkey throws Al2(SO4)3 (Critical Hit!)", Color.Red)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound3.wm")
                Else
                    If New Random(Now.Date.Second).Next(0, 2) = 0 Then
                        ChangePower(False, - 3)
                    Else
                        ChangePower(False, - 9)
                    End If
                    ShowTitle("The Avogadro turkey throws Al2(SO4)3.", Color.Black)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound3.wm")
                End If
                CoolDown(True, 0.75)
            End If
        ElseIf battle = 12 Then
            back:
            Dim choice As Integer = random_.Next(1, 8)
            Dim hitpower As Integer = random_.Next(1, 101)
            If choice <= 4 Then
                If hitpower >= 93 - MissProbability1 Then
                    ShowTitle("The lunch contending robot scratches (Miss the target.)", Color.Gold)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
                ElseIf hitpower <= 4 + CriticalProbability1 Then
                    ChangePower(False, - 90, True)
                    ShowTitle("The lunch contending robot scratches (Critical Hit!)", Color.Red)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound12.wm")
                Else
                    ChangePower(False, - 30)
                    ShowTitle("The lunch contending robot scratches.", Color.Black)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound12.wm")
                End If
                CoolDown(True, 3)
            ElseIf choice = 5 Or choice = 6 Then
                If life1f.Tag > life1b.Tag/2 Then GoTo back
                Charge(True, 16, 2.5, 1)
            ElseIf choice = 7 Then
                Charge(True, 17, 3.5, 1.5)
            End If
        ElseIf battle = 13 Then
            back2:
            Dim choice As Integer = random_.Next(1, 8)
            Dim hitpower As Integer = random_.Next(1, 101)
            If choice <= 4 Then
                If hitpower >= 95 - MissProbability1 Then
                    ShowTitle("The palace guard chops (Miss the target.)", Color.Gold)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
                ElseIf hitpower <= 3 + CriticalProbability1 Then
                    ChangePower(False, - 66, True)
                    ShowTitle("The palace guard chops (Critical Hit!)", Color.Red)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound29.wm")
                Else
                    ChangePower(False, - 22)
                    ShowTitle("The palace guard chops.", Color.Black)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound29.wm")
                End If
                CoolDown(True, 1.7)
            ElseIf choice = 5 Or choice = 6 Then
                Charge(True, 19, 1.8, 1.15)
            ElseIf choice = 7 Then
                If life1f.Tag < life1b.Tag/3 Then GoTo back2
                If hitpower >= 97 - MissProbability1 Then
                    ChangePower(True, - 15)
                    ShowTitle("The palace guard chops (Miss the target.)", Color.Gold)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
                ElseIf hitpower <= 7 + CriticalProbability1 Then
                    ChangePower(True, - 15)
                    ChangePower(False, - 80, True)
                    ShowTitle("The palace guard chops (Critical Hit!)", Color.Red)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound24.wm")
                Else
                    ChangePower(True, - 15)
                    ChangePower(False, - 40)
                    ShowTitle("The palace guard chops.", Color.Black)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound24.wm")
                End If
                CoolDown(True, 1.4)
            End If
        ElseIf battle = 14 Then
            example.Tag += 1
            If example.Tag <= 10 Then Exit Sub
            Spell(True, 150, 2)
        ElseIf battle = 15 Then
            battle15_return:
            Dim choice As Integer = random_.Next(1, 5)
            Dim hitpower As Integer = random_.Next(1, 101)
            If choice <= 2 Then
                If hitpower >= 95 - MissProbability1 Then
                    ShowTitle("Tarecgosa paws (Miss the target.)", Color.Gold)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
                ElseIf hitpower <= 3 + CriticalProbability1 Then
                    ChangePower(False, - 60, True)
                    ShowTitle("Tarecgosa paws with her hands (Critical Hit!)", Color.Red)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound3.wm")
                Else
                    ChangePower(False, - 20)
                    ShowTitle("Tarecgosa paws.", Color.Black)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound3.wm")
                End If
                CoolDown(True, 2.4)
            ElseIf choice = 3 Then
                If Spell(True, 25, 5) = False Then GoTo battle15_return
            ElseIf choice = 4 Then
                If HasStatus(False, 22) Then GoTo battle15_return
                If Spell(True, 30, 6) = False Then GoTo battle15_return
            End If
        ElseIf battle = 16 Then
            battle16_return:
            If mana1f.Tag = mana1b.Tag And mana1f.Tag >= 40 Then GoTo battle16_full
            Dim choice As Integer = random_.Next(1, 5)
            Dim hitpower As Integer = random_.Next(1, 101)
            If choice <= 3 Then
                If hitpower >= 95 - MissProbability1 Then
                    ShowTitle("Floating ghost scares.", Color.Gold)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
                ElseIf hitpower <= 3 + CriticalProbability1 Then
                    ChangePower(False, - 60, True)
                    ShowTitle("Floating ghost scares terribly (Critical Scare!)", Color.Red)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue13.wm")
                    AddStatus(False, 25, 16.6)
                Else
                    ChangePower(False, - 20)
                    ShowTitle("Floating ghost scares.", Color.Black)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\dialogue13.wm")
                    If hitpower <= 17 Then AddStatus(False, 25, 9.6)
                End If
                CoolDown(True, 2.4)
            ElseIf choice = 4 Then
                If Spell(True, 25, 7) = False Then GoTo battle16_return
            ElseIf choice = 5 Then
                battle16_full:
                If Spell(True, 40, 8) = False Then GoTo battle16_return
            End If
        ElseIf battle = 17 Then
            If mana1f.Tag >= 22 And cd2t.Text = "Charge:" And magic_type <> 4 And magic_type <> 7 And magic_type <> 8 _
                Then
                If New Random(Now.Millisecond).Next(1, 2) = 1 Then
                    If cd2t.Text = "Charge:" Then
                        If magic_type = 2 Then
                            GoTo battle17_1
                        ElseIf magic_type <> 4 And magic_type <> 7 And magic_type <> 8 Then
                            GoTo battle17_2
                        End If
                    End If
                Else
                    Exit Sub
                End If
            Else
                battle17_next:
                If New Random(Now.Second).Next(1, 3) = 1 Then
                    GoTo battle17_1
                End If
            End If
            battle17_back:
            Dim choice As Integer = random_.Next(1, 3)
            Dim hitpower As Integer = random_.Next(1, 101)
            If choice < 3 Then
                MagicPowerStage += 1
                Spell(True, 1, 12)
            ElseIf choice = 4 Then
                battle17_1:
                If HasStatus(True, 27) Then GoTo battle17_back
                Spell(True, 22, 10)
            Else
                battle17_2:
                If HasStatus(True, 28) Then GoTo battle17_back
                Spell(True, 22, 11)
            End If
        ElseIf battle = 18 Then
            Dim choice As Integer = random_.Next(1, 7)
            Dim hitpower As Integer = random_.Next(1, 101)
            If choice <= 3 Then
                If hitpower >= 96 - MissProbability1 Then
                    ShowTitle("The god of duck pool pecks (Miss the target.)", Color.Gold)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
                ElseIf hitpower <= 2 + CriticalProbability1 Then
                    ChangePower(False, - 48, True)
                    ShowTitle("The god of duck pool pecks (Critical Hit!)", Color.Red)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound14.wm")
                Else
                    ChangePower(False, - 16)
                    ShowTitle("The god of duck pool pecks.", Color.Black)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound14.wm")
                End If
                CoolDown(True, 0.75)
            ElseIf choice <= 5 Then
                Charge(True, 28, 2.1, 1.2)
            Else
                Charge(True, 29, 3.6, 0.72)
            End If
        ElseIf battle = 19 Then
            If - LastMagicalDamage1 >= random_.Next(60, 90) And mana1f.Tag >= 25 Then GoTo battle19_2
            battle19_back:
            Dim choice As Integer = random_.Next(1, 5)
            Dim hitpower As Integer = random_.Next(1, 101)
            If choice <= 2 Then
                If hitpower >= 95 - MissProbability1 Then
                    ShowTitle("The witch launches energy ball (Miss the target.)", Color.Gold)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
                ElseIf hitpower <= 5 + CriticalProbability1 Then
                    ChangePower(False, - 120, True, False, False, True, True)
                    ShowTitle("The witch launches energy ball (Critical Hit!)", Color.Red)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound23.wm")
                Else
                    ChangePower(False, - 60, False, False, False, True, True)
                    ShowTitle("The witch launches energy ball.", Color.Black)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound24.wm")
                End If
                CoolDown(True, 1.9)
            ElseIf choice = 3 Then
                If - LastMagicalDamage1 <= random_.Next(50, 100) Then GoTo battle19_back
                battle19_2:
                Spell(True, 25, 13)
            Else
                If HasStatus(False, 30) Then GoTo battle19_back
                Spell(True, 36, 14)
            End If
        ElseIf battle = 20 Then
            Dim choice As Integer = random_.Next(1, 5)
            Dim hitpower As Integer = random_.Next(1, 101)
            If choice <= 3 Then
                If hitpower >= 97 - MissProbability1 Then
                    ShowTitle("The chicken pecks (Miss the target.)", Color.Gold)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
                ElseIf hitpower <= 8 + CriticalProbability1 Then
                    ChangePower(False, - 30, True)
                    ShowTitle("The chicken pecks (Critical Hit!)", Color.Red)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound14.wm")
                Else
                    ChangePower(False, - 10)
                    ShowTitle("The chicken pecks.", Color.Black)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound14.wm")
                End If
                CoolDown(True, 1.5)
            Else
                Charge(True, 34, 2, 1)
            End If
        ElseIf battle = 21 Then
            If Form1.DeathFlagNum = 8 Then
                ChangeCow = - 1
                Form1.DeathFlagNum = - 1
            ElseIf Not Form1.DeathFlagNum = - 1 Then
                AddStatus(True, 33, - 1)
                Form1.DeathFlagNum = - 1
            End If
            If Not ChangeCow = - 1 Then
                ChangeCow += 1
                If ChangeCow >= 6 Then
                    ChangeCow = 0
                    If HasStatus(True, 33) Then
                        RemoveStatus(True, 33)
                        AddStatus(True, 34, - 1)
                        battler.Image =
                            Image.FromFile(
                                My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\battler19.wm")
                    ElseIf HasStatus(True, 34) Then
                        RemoveStatus(True, 34)
                        AddStatus(True, 33, - 1)
                        battler.Image =
                            Image.FromFile(
                                My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\battler18.wm")
                    End If
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound35.wm")
                End If
            End If
            Dim choice As Integer = random_.Next(2, 6)
            Dim hitpower As Integer = random_.Next(1, 101)
            If choice <= 3 Then
                If hitpower >= 88 - MissProbability1 Then
                    ShowTitle("The negative positive cow kicks (Miss the target.)", Color.Gold)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
                ElseIf hitpower <= 5 + CriticalProbability1 Then
                    ChangePower(False, - 51, True)
                    ShowTitle("The negative positive cow kicks (Critical Hit!)", Color.Red)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound3.wm")
                Else
                    ChangePower(False, - 17)
                    ShowTitle("The negative positive cow kicks.", Color.Black)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound3.wm")
                End If
                CoolDown(True, 1.7)
            ElseIf choice = 4 Then
                Spell(True, 26, 16)
            ElseIf choice = 5 Then
                Spell(True, 39, 17)
            End If
        ElseIf battle = 22 Then
            If Math.Abs(Math.Tan(Math.PI/180*life2f.Tag))*40 > random_.Next(100, 200) And mana1f.Tag >= 40 Then
                Spell(True, 40, 19)
                Exit Sub
            ElseIf Math.Pow(mana2f.Tag, 2)/50 > random_.Next(75, 150) And mana1f.Tag >= 20 Then
                Spell(True, 20, 18)
                Exit Sub
            End If
            Dim hitpower As Integer = random_.Next(1, 101)
            If hitpower >= 96 - MissProbability1 Then
                ShowTitle("Mr.Duck phantom pecks (Miss the target.)", Color.Gold)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
            ElseIf hitpower <= 2 + CriticalProbability1 Then
                ChangePower(False, - 60, True)
                ShowTitle("Mr.Duck phantom pecks (Critical Hit!)", Color.Red)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound14.wm")
            Else
                ChangePower(False, - 20)
                ShowTitle("Mr.Duck phantom pecks.", Color.Black)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound14.wm")
            End If
            CoolDown(True, 1.3)
        ElseIf battle = 23 Then
            Dim choice As Integer = random_.Next(0, 5)
            If choice <= 3 Then
                Charge(True, 39, 1, 1)
            ElseIf choice = 4 And life1f.Tag <= life1b.Tag/3 Then
                Spell(True, 20, 20)
            Else
                Spell(True, 100, 21)
            End If
        ElseIf battle = 24 Then
            If random_.Next(0, 3) <> 0 Then
                Dim hitpower As Integer = random_.Next(1, 101)
                If hitpower >= 97 - MissProbability1 Then
                    ShowTitle("Turkey rider(without turkey) kicks (Miss the target.)", Color.Gold)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
                ElseIf hitpower <= 7 + CriticalProbability1 Then
                    ChangePower(False, - 100, True)
                    ShowTitle("Turkey rider(without turkey) kicks with the turkey power (Critical Hit!)", Color.Red)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound3.wm")
                Else
                    ChangePower(False, - 1)
                    ShowTitle("Turkey rider(without turkey) kicks.", Color.Black)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound3.wm")
                End If
                CoolDown(True, 1.1)
            Else
                Charge(True, 42, 0.6, 0.4)
            End If
        End If
    End Sub

    Private Sub tutorialend()
        Hide()
        Form8.Show()
        Form8.EnemyName.Text = "turkey egg"
        Form8.skill1.Text = "Bump"
        Form8.skill1.Visible = True
        Form8.skill1t.Text = "Cause 12 damage."
        Form8.skill1t.Visible = True
        Form8.skill2.Visible = False
        Form8.skill2t.Visible = False
        Form8.skill3.Visible = False
        Form8.skill3t.Visible = False
        defend.Enabled = True
        attack.Enabled = True
    End Sub

    Private Sub shining_Tick(sender As Object, e As EventArgs) Handles shining.Tick
        CheckForCheating()
        If shining.Tag <= 4000 Then
            If battler.Visible = True Then
                battler.Visible = False
            Else
                battler.Visible = True
                If battle = 17 Then _
                    battler.Image =
                        Image.FromFile(
                            My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image15.wm")
            End If
        Else
            battler.Visible = False
        End If
        shining.Tag += shining.Interval
        If shining.Tag >= 5000 Then
            shining.Tag = 0
            shining.Enabled = False
            If battle = 5 Or battle = 6 Then
                RemoveAllStatuses(True)
                ChangePower(False, 50, False, True, False, False, False)
                ShowTitle("Murloc" & number.Maximum - number.Value + 1 & " is defeated.", Color.Green)
                number.Value -= 1
                numberT.Text = number.Value
                If number.Value <= 1 Then enemies_number.Text = "Enemy"
                If number.Value > 0 Then
                    back:
                    Dim RandomMurloc As Integer = random_.Next(2, 5)
                    If RandomMurloc = Current_Murloc_Number Then GoTo back
                    Current_Murloc_Number = RandomMurloc
                    Form8.EnemyName.Text = "insane murloc" & number.Maximum - number.Value + 1
                    battler.Image =
                        Image.FromFile(
                            My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\battler5_" &
                            Current_Murloc_Number & ".wm")
                    battler.Visible = True
                    ModifyLife(True, life1b.Tag)
                    EnemyAction.Enabled = True
                    StatusCheck.Enabled = True
                    pause.Enabled = True
                    point1 = LockNumber(life1f.Tag)
                    setlife1.Enabled = True
                    setlife2.Enabled = True
                    cool1.Enabled = True
                    cool2.Enabled = True
                    titleshow.Enabled = True
                    EnemyAction.Enabled = True
                    If cd2f.Tag = cd2b.Tag Then attack.Enabled = True
                    If cd2f.Tag = cd2b.Tag Then defend.Enabled = True
                    If cd2f.Tag = cd2b.Tag Then magic.Enabled = True
                    If cd2f.Tag = cd2b.Tag Then assist.Enabled = True
                    StatusMove.Enabled = True
                    RefreshTexts()
                    Exit Sub
                End If
            ElseIf battle = 11 And Avogadro_revive Then
                Avogadro_revive = False
                ShowTitle("Avogadro turkey revives.", Color.Blue)
                ChangePower(True, 66, False, True, False, False)
                battler.Visible = True
                EnemyAction.Enabled = True
                StatusCheck.Enabled = True
                pause.Enabled = True
                setlife1.Enabled = True
                setlife2.Enabled = True
                cool1.Enabled = True
                cool2.Enabled = True
                titleshow.Enabled = True
                EnemyAction.Enabled = True
                If cd2f.Tag = cd2b.Tag Then attack.Enabled = True
                If cd2f.Tag = cd2b.Tag Then defend.Enabled = True
                If cd2f.Tag = cd2b.Tag Then magic.Enabled = True
                StatusMove.Enabled = True
                Exit Sub
            End If
            Hide()
            Form9.Show()
            Form1.music.Ctlcontrols.stop()
            If battle = 0 Then
                Form9.start(0, "You defeated the turkey egg and won the battle!")
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound8.wm")
            ElseIf battle = 1 Then
                Form9.start(2, "You defeated the corona rabbit and got his things!")
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound8.wm")
            ElseIf battle = 2 Then
                Form9.start(4, "You defeated the small black hen!")
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound8.wm")
            ElseIf battle = 3 Then
                Form9.start(6, "The solar corona ball is broken up!")
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound8.wm")
            ElseIf battle = 4 Then
                Form9.start(8, "You successfully get rid of the crazy murloc.")
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound8.wm")
            ElseIf battle = 5 Then
                Form9.start(10, "You defeated the murloc.")
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound8.wm")
            ElseIf battle = 6 Then
                Form9.start(12, "You defeated all the murlocs!")
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound8.wm")
            ElseIf battle = 7 Then
                Form9.start(14, "The mixed turk&fish is defeated.")
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound8.wm")
            ElseIf battle = 8 Then
                Form9.start(16, "The lord is defeated! You win!")
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\victory1.wm")
            ElseIf battle = 10 Then
                Form9.start(19, "The big smelly milk cow is calmed down.")
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound8.wm")
            ElseIf battle = 11 Then
                Form9.start(21, "The Avogadro turkey is defeated!")
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound8.wm")
            ElseIf battle = 12 Then
                Form9.start(23, "The robot is pushed down.")
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound8.wm")
            ElseIf battle = 13 Then
                Form9.start(25, "The guard is defeated, you can enter the palace now.")
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound8.wm")
            ElseIf battle = 14 Then
                MsgBox("An accident happened in the game.", 16, "Error")
                End
            ElseIf battle = 15 Then
                Form9.start(28, "Tarecgosa is defeated!")
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\victory1.wm")
            ElseIf battle = 16 Then
                Form9.start(30, "The ghost thing is destroyed!")
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound8.wm")
            ElseIf battle = 17 Then
                Form9.start(32, "The witch's mirroring disappeared.")
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound8.wm")
            ElseIf battle = 18 Then
                Form9.start(34, "The duck pool god is beaten down.")
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound8.wm")
            ElseIf battle = 19 Then
                Form9.start(36, "The witch is defeated!")
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\victory1.wm")
            ElseIf battle = 20 Then
                Form9.start(38, "The chicken is caught.")
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound8.wm")
            ElseIf battle = 21 Then
                Form9.start(40, "The cow suddenly becomes smelly gas and floats away.")
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound8.wm")
            ElseIf battle = 22 Then
                Form9.start(42, "The phantom disappears.")
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound8.wm")
            ElseIf battle = 22 Then
                Form9.start(1, "You win! You win!")
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound8.wm")
            ElseIf battle = 24 Then
                Form9.start(3, "So easy.")
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound8.wm")
            End If
        End If
    End Sub

    Private Sub defeat_Tick(sender As Object, e As EventArgs) Handles defeat.Tick
        CheckForCheating()
        defeat.Enabled = False
        Hide()
        Form10.Show()
        Form1.music.Ctlcontrols.stop()
        If battle = 0 Then
            Form10.start(1, "You've been defeated by the turkey egg!")
            My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound1.wm")
        ElseIf battle = 1 Then
            Form10.start(3, "The rabbit has run away.")
            My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound1.wm")
        ElseIf battle = 2 Then
            Form10.start(5, "The small black hen defeats you!")
            My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound1.wm")
        ElseIf battle = 3 Then
            Form10.start(7, "You cannot bear the attack.")
            My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound1.wm")
        ElseIf battle = 4 Then
            Form10.start(9, "The murloc insanely eats your meat.")
            My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound1.wm")
        ElseIf battle = 5 Then
            Form10.start(11, "You've been defeated.")
            My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound1.wm")
        ElseIf battle = 6 Then
            Form10.start(13, "You've been used to do biological experiments.")
            My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound1.wm")
        ElseIf battle = 7 Then
            Form10.start(15, "You can hardly bear.")
            My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound1.wm")
        ElseIf battle = 8 Then
            Form10.start(17, "Your body is being eaten by the turk&fish lord.")
            My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound1.wm")
        ElseIf battle = 10 Then
            Form10.start(20, "You're the victim on whom is impacted and becomes pieces.")
            My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound1.wm")
        ElseIf battle = 11 Then
            Form10.start(22, "You've been defeated!!")
            My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound1.wm")
        ElseIf battle = 12 Then
            Form10.start(24, "You've been eaten as the school's hellish meal.")
            My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound1.wm")
        ElseIf battle = 13 Then
            Form10.start(26, "The guard gives you to the king.")
            My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound1.wm")
        ElseIf battle = 14 Then
            Form10.start(27, "Atropos wins.")
            My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound1.wm")
        ElseIf battle = 15 Then
            Form10.start(29, "You lose.")
            My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound1.wm")
        ElseIf battle = 16 Then
            Form10.start(31, "The ghost overcame your power and occupied your body.")
            My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound1.wm")
        ElseIf battle = 17 Then
            Form10.start(33, "You belong to the witch!!!")
            My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound1.wm")
        ElseIf battle = 18 Then
            Form10.start(35, "You are defeated.")
            My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound1.wm")
        ElseIf battle = 19 Then
            Form10.start(37, "You lose.")
            My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound1.wm")
        ElseIf battle = 20 Then
            Form10.start(39, "The chicken wins.")
            My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound1.wm")
        ElseIf battle = 21 Then
            Form10.start(41, "You're defeated by a negative positive cow.")
            My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound1.wm")
        ElseIf battle = 22 Then
            Form10.start(43, "You're defeated by the phantom.")
            My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound1.wm")
        ElseIf battle = 23 Then
            Form10.start(2, "n o t  s o  s e r i o u s." & vbCrLf & "Bbeelliieevvee mmee. Believe me.")
            My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound1.wm")
        ElseIf battle = 24 Then
            Form10.start(4, "Though you lose, but your patience is admirable.")
            My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound1.wm")
        End If
    End Sub

    Private Function HasStatus(player1 As Boolean, status_code As Integer)
        Dim result = False
        For i = 0 To 5
            If player1 Then
                If status1(i).Visible AndAlso status1(i).Tag.ToString.Split(":")(0) = status_code Then result = True
            Else
                If status2(i).Visible AndAlso status2(i).Tag.ToString.Split(":")(0) = status_code Then result = True
            End If
        Next
        Return result
    End Function

    Private Sub StatusMove_Tick(sender As Object, e As EventArgs) Handles StatusMove.Tick
        For i = 0 To 5
            If status1(i).Visible AndAlso Not status1(i).Tag.split(":")(1) = "-1" Then
                status1(i).Tag = status1(i).Tag.split(":")(0) & ":" & status1(i).Tag.split(":")(1) - 0.1
                ToolTip1.SetToolTip(status1(i),
                                    CheckForString(status1(i).Tag.ToString.Split(":")(0),
                                                   status1(i).Tag.ToString.Split(":")(1)))
                If status1(i).Tag.split(":")(1) <= 0 Then
                    status1(i).Visible = False
                    If status1(i).Tag.split(":")(0) = 8 Then AddStatus(True, 9, 6)
                    If status1(i).Tag.split(":")(0) = 27 Or status1(i).Tag.split(":")(0) = 28 Then _
                        battler.Image =
                            Image.FromFile(
                                My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image15.wm")
                End If
            End If
            If status2(i).Visible AndAlso Not status2(i).Tag.split(":")(1) = "-1" Then
                status2(i).Tag = status2(i).Tag.split(":")(0) & ":" & status2(i).Tag.split(":")(1) - 0.1
                ToolTip1.SetToolTip(status2(i),
                                    CheckForString(status2(i).Tag.ToString.Split(":")(0),
                                                   status2(i).Tag.ToString.Split(":")(1)))
                If status2(i).Tag.split(":")(1) <= 0 Then
                    status2(i).Visible = False
                    If status2(i).Tag.split(":")(0) = 8 Then AddStatus(False, 9, 6)
                End If
            End If
        Next
        refreshstatus()
        If battle = 3 Then
            If IsStunned(False) Then
                SpellBox.ReadOnly = True
            Else
                If Not content1.Tag <= 3 Then SpellBox.ReadOnly = False
            End If
        End If
    End Sub

    Private Function CheckForString(status_code As String, time As Double)
        If status_code = 0 Then
            Return "Defence" & vbCrLf & "Prevent 30% damage." & CheckForTimeString(time)
        ElseIf status_code = 1 Then
            Return "Solar Fire" & vbCrLf & "Get 4 damage per second." & CheckForTimeString(time)
        ElseIf status_code = 2 Then
            Return "Water" & vbCrLf & "Get cool down and charge time increased." & CheckForTimeString(time)
        ElseIf status_code = 3 Then
            Return "Accelerate" & vbCrLf & "Increase 91% attack." & CheckForTimeString(time)
        ElseIf status_code = 4 Then
            Return "Stun" & vbCrLf & "Cannot do anything." & CheckForTimeString(time)
        ElseIf status_code = 5 Then
            Return "Defence" & vbCrLf & "Prevent 50% damage." & CheckForTimeString(time)
        ElseIf status_code = 6 Then
            Return "Shrinkage" & vbCrLf & "Your words become shorter." & CheckForTimeString(time)
        ElseIf status_code = 7 Then
            Return "Expansion" & vbCrLf & "Your words become longer." & CheckForTimeString(time)
        ElseIf status_code = 8 Then
            Return _
                "Paralysis" & vbCrLf & "Cannot do anything. After the status is removed, get ""Slow down""." &
                CheckForTimeString(time)
        ElseIf status_code = 9 Then
            Return _
                "Slow down" & vbCrLf & "Your ""charge"" speed and ""cool down"" speed get 50% reduction." &
                CheckForTimeString(time)
        ElseIf status_code = 10 Then
            Return "Defence" & vbCrLf & "Prevent 67% damage." & CheckForTimeString(time)
        ElseIf status_code = 11 Then
            Return _
                "Puzzle" & vbCrLf & "Cannot deal critical damage, get probability of launching missed-attack increased." &
                CheckForTimeString(time)
        ElseIf status_code = 12 Then
            Return _
                "Poison" & vbCrLf & "Get 12 damage per second, attack power gets 25% reduction." &
                CheckForTimeString(time)
        ElseIf status_code = 13 Then
            Return "Blood" & vbCrLf & "Get 8 damage per second." & CheckForTimeString(time)
        ElseIf status_code = 14 Then
            Return "Discombobulation" & vbCrLf & "Get 70% probability missing the attack." & CheckForTimeString(time)
        ElseIf status_code = 15 Then
            Return "Fire" & vbCrLf & "Get 10 damage per second." & CheckForTimeString(time)
        ElseIf status_code = 16 Then
            Return "Corrosion" & vbCrLf & "Lose 1% life per second." & CheckForTimeString(time)
        ElseIf status_code = 17 Then
            Return "Spike" & vbCrLf & "Mirror 20% suffered damage." & CheckForTimeString(time)
        ElseIf status_code = 18 Then
            Return "Burrow" & vbCrLf & "Attacks cannot hit on you." & CheckForTimeString(time)
        ElseIf status_code = 19 Then
            Return _
                "Charm" & vbCrLf & "Be possessed by the witch. Lose 30% attack. Lose 3 point of life per second." &
                CheckForTimeString(time)
        ElseIf status_code = 20 Then
            Return "Freeze" & vbCrLf & "Cannot do any action or charge." & CheckForTimeString(time)
        ElseIf status_code = 21 Then
            Return "Iron armor" & vbCrLf & "Prevent 75% physical damage." & CheckForTimeString(time)
        ElseIf status_code = 22 Then
            Return "Confusion" & vbCrLf & "Lose 50% speed while cooling down or charging." & CheckForTimeString(time)
        ElseIf status_code = 23 Then
            Return "Flame" & vbCrLf & "Get 6 damage per second." & CheckForTimeString(time)
        ElseIf status_code = 24 Then
            Return "Defence" & vbCrLf & "Prevent 75% damage." & CheckForTimeString(time)
        ElseIf status_code = 25 Then
            Return _
                "Scare" & vbCrLf & "Lose 50% attack power, gotten damage gets 50% increment." & CheckForTimeString(time)
        ElseIf status_code = 26 Then
            Return "Spiritualty" & vbCrLf & "Your enemy can not hit the target easily." & CheckForTimeString(time)
        ElseIf status_code = 27 Then
            Return "Physical immunity" & vbCrLf & "Be immune to physical damage." & CheckForTimeString(time)
        ElseIf status_code = 28 Then
            Return _
                "Magical immunity" & vbCrLf & "Be immune to magical damage, cannot be added new status." &
                CheckForTimeString(time)
        ElseIf status_code = 29 Then
            Return _
                "Extreme confusion" & vbCrLf &
                "Both ""cool down"" time and ""charge"" time get 70% reduction, attack power gets 20% reduction." &
                CheckForTimeString(time)
        ElseIf status_code = 30 Then
            Return "Charm" & vbCrLf & "Your attack does cause no damage." & CheckForTimeString(time)
        ElseIf status_code = 31 Then
            Return _
                "Hydrogen sulfide poison" & vbCrLf & "Get 25 damage per second, be unable to restore mana." &
                CheckForTimeString(time)
        ElseIf status_code = 32 Then
            Return "Phantom" & vbCrLf & "Your gotten magical damage gets tripled." & CheckForTimeString(time)
        ElseIf status_code = 33 Then
            Return "Positiveness" & vbCrLf & "Your attacks are all critical." & CheckForTimeString(time)
        ElseIf status_code = 34 Then
            Return "Negativeness" & vbCrLf & "Your enemy's attack cannot hit the target." & CheckForTimeString(time)
        ElseIf status_code = 35 Then
            Return "Full immunity" & vbCrLf & "Be immune to all statuses." & CheckForTimeString(time)
        Else
            Return "Tool tip missing"
        End If
    End Function

    Private Function CheckForTimeString(time As Double)
        If time = - 1 Then
            Return ""
        Else
            If Not time = 0 AndAlso time.ToString.Split(".").Count = 1 Then
                Return vbCrLf & time & ".0 seconds left."
            Else
                If time <= 1 Then
                    Return vbCrLf & time & " second left."
                Else
                    Return vbCrLf & time & " seconds left."
                End If
            End If
        End If
    End Function

    Private Sub AddStatus(player1 As Boolean, status_code As Integer, time As Double)
        For i = 0 To 5
            If player1 Then
                If HasStatus(True, 28) Or HasStatus(True, 35) Then
                    ShowTitle("The " & Form8.EnemyName.Text & " is immune to status.", Color.Gold)
                    Exit Sub
                End If
                If HasStatus(True, status_code) Then
                    If status1(i).Visible = True AndAlso status1(i).Tag.ToString.Split(":")(0) = status_code Then
                        If status1(i).Tag.ToString.Split(":")(1) < time Then
                            status1(i).Tag = status1(i).Tag.ToString.Split(":")(0) & ":" & time
                        Else
                            Exit For
                        End If
                    End If
                Else
                    If status1(i).Visible = False Then
                        status1(i).Visible = True
                        status1(i).Image = StatusImage.Images(status_code)
                        status1(i).Tag = status_code & ":" & time
                        ToolTip1.SetToolTip(status1(i), CheckForString(status_code, time))
                        Exit For
                    End If
                End If
            Else
                If HasStatus(False, status_code) Then
                    If status2(i).Visible = True AndAlso status2(i).Tag.ToString.Split(":")(0) = status_code Then
                        If status2(i).Tag.ToString.Split(":")(1) < time Then
                            status2(i).Tag = status2(i).Tag.ToString.Split(":")(0) & ":" & time
                        Else
                            Exit For
                        End If
                    End If
                Else
                    If status2(i).Visible = False Then
                        status2(i).Visible = True
                        status2(i).Image = StatusImage.Images(status_code)
                        status2(i).Tag = status_code & ":" & time
                        ToolTip1.SetToolTip(status2(i), CheckForString(status_code, time))
                        Exit For
                    End If
                End If
            End If
        Next
        refreshstatus()
    End Sub

    Sub refreshstatus()
        For i_ = 1 To 5
            For i = 1 To 5
                If status1(i).Visible And status1(i - 1).Visible = False Then
                    status1(i).Visible = False
                    status1(i - 1).Visible = True
                    status1(i - 1).Tag = status1(i).Tag
                    status1(i - 1).Image = status1(i).Image
                    ToolTip1.SetToolTip(status1(i - 1),
                                        CheckForString(status1(i).Tag.ToString.Split(":")(0),
                                                       status1(i).Tag.ToString.Split(":")(1)))
                End If
                If status2(i).Visible And status2(i - 1).Visible = False Then
                    status2(i).Visible = False
                    status2(i - 1).Visible = True
                    status2(i - 1).Tag = status2(i).Tag
                    status2(i - 1).Image = status2(i).Image
                    ToolTip1.SetToolTip(status2(i - 1),
                                        CheckForString(status2(i).Tag.ToString.Split(":")(0),
                                                       status2(i).Tag.ToString.Split(":")(1)))
                End If
            Next
        Next
    End Sub

    Private Sub Charge(player1 As Boolean, code As Integer, time As Double, cool_down As Double)
        If player1 Then
            cd1f.Tag = 0
            cd1t.Text = "Charge:"
            cd1b.Tag = time*100
            cd1t.Tag = code & "," & cool_down
            cd1t.ForeColor = Color.Red
            cd1f.Visible = True
            cd1b.Visible = True
            cd1t.Visible = True
            cool1.Enabled = True
            hidecool1.Enabled = False
        Else
            cd2f.Tag = 0
            cd2t.Text = "Charge:"
            cd2b.Tag = time*100
            cd2t.Tag = code & "," & cool_down
            cd2t.ForeColor = Color.Red
            cd2f.Visible = True
            cd2b.Visible = True
            cd2t.Visible = True
            cool2.Enabled = True
            hidecool2.Enabled = False
            defend.Enabled = False
            attack.Enabled = False
            assist.Enabled = False
            magic.Enabled = False
            heal.Enabled = False
        End If
    End Sub

    Private Sub ChargeDone(code As Integer)
        CheckForMissCritical(True)
        CheckForMissCritical(False)
        Dim hitpower As Integer = random_.Next(1, 101)
        If code = 0 Then
            If hitpower >= 97 - MissProbability1 Then
                ShowTitle("The solar corona rabbit launches a corona ball (Miss the target.)", Color.Gold)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
            ElseIf hitpower <= 6 + CriticalProbability1 Then
                ChangePower(False, - 60, True, False, False, True, True)
                ShowTitle("The solar corona rabbit launches a big corona ball (Critical Hit!)", Color.Red)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound10.wm")
                AddStatus(False, 1, 6)
            Else
                ChangePower(False, - 20, False, False, False, True, True)
                ShowTitle("The solar corona rabbit launches a corona ball!", Color.Black)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound10.wm")
                AddStatus(False, 1, 3)
            End If
        ElseIf code = 1 Then
            If hitpower >= 98 - MissProbability2 Then
                ChangePower(True, 0)
                ShowTitle("Splash water to " & Form8.EnemyName.Text & " (Miss the target.)", Color.Gold)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
            Else
                ChangePower(True, 0)
                ShowTitle("Splash water to " & Form8.EnemyName.Text & ".", Color.Black)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound13.wm")
                AddStatus(True, 2, 9)
            End If
        ElseIf code = 2 Then
            If hitpower >= 95 - MissProbability1 Then
                ShowTitle("The small black hen lays an egg and throws it (Miss the target.)", Color.Gold)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
            ElseIf hitpower <= 3 + CriticalProbability1 Then
                ChangePower(False, - 62, True)
                ShowTitle("The small black hen lays an egg and throws it (Critical Hit!)", Color.Red)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound16.wm")
                If hitpower <= 10 Then AddStatus(False, 4, 3.3)
            Else
                ChangePower(False, - 31)
                ShowTitle("The small black hen lays an egg and throws it.", Color.Black)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound16.wm")
                If hitpower <= 10 Then AddStatus(False, 4, 1.1)
            End If
        ElseIf code = 3 Then
            If hitpower <= 96 - MissProbability1 Then
                ShowTitle("The solar corona ball spreads retarding energy.", Color.Black)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound22.wm")
                AddStatus(False, 7, 12)
            Else
                ShowTitle("The solar corona ball spreads retarding energy (Miss the target.)", Color.Gold)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
            End If
        ElseIf code = 4 Then
            If hitpower <= 95 - MissProbability1 Then
                ShowTitle("The solar corona ball spreads paralytic static.", Color.Black)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound18.wm")
                AddStatus(False, 4, 8)
            Else
                ShowTitle("The solar corona ball spreads paralytic static (Miss the target.)", Color.Gold)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
            End If
        ElseIf code = 5 Then
            If hitpower > 94 - MissProbability2 Then
                ShowTitle("Launch cockscomb shoot to " & Form8.EnemyName.Text & " (Miss the target.)", Color.Gold)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
            ElseIf hitpower <= 1 + CriticalProbability2 Then
                ChangePower(True, - 180, True)
                ShowTitle("Launch cockscomb shoot to " & Form8.EnemyName.Text & " (Critical Hit!)", Color.Red)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound23.wm")
            Else
                ChangePower(True, - 60)
                ShowTitle("Launch cockscomb shoot to " & Form8.EnemyName.Text & ".", Color.Black)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound23.wm")
            End If
        ElseIf code = 6 Then
            If hitpower < 94 - MissProbability2 Then
                ChangePower(True, 0)
                AddStatus(True, 8, 3)
                ShowTitle("Numb " & Form8.EnemyName.Text & ".", Color.Black)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound18.wm")
            Else
                ChangePower(True, 0)
                ShowTitle("Numb " & Form8.EnemyName.Text & " (Miss the target.)", Color.Gold)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
            End If
        ElseIf code = 7 Then
            If hitpower < 95 - MissProbability2 Then
                ChangePower(True, 0)
                RemoveAllStatuses(True)
                RemoveAllStatuses(False)
                AddStatus(True, 11, 10.3)
                ShowTitle("Launch math wave to " & Form8.EnemyName.Text & ".", Color.Black)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound25.wm")
            Else
                ChangePower(True, 0)
                ShowTitle("Launch math wave to " & Form8.EnemyName.Text & " (Miss the target.)", Color.Gold)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
            End If
        ElseIf code = 8 Then
            If hitpower >= 99 - MissProbability1 Then
                ShowTitle("The turk&fish absorbs (Miss the target.)", Color.Gold)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
            ElseIf hitpower <= 1 + CriticalProbability1 Then
                ChangePower(False, - 60, True, False, False, True, True, True)
                ShowTitle("The turk&fish absorbs (Critical Hit!)", Color.Red)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound15.wm")
            Else
                ChangePower(False, - 30, False, False, False, True, True, True)
                ShowTitle("The turk&fish absorbs.", Color.Black)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound15.wm")
            End If
        ElseIf code = 9 Then
            If hitpower >= 94 - MissProbability1 Then
                ShowTitle("The turk&fish lord launches a strike wave (Miss the target.)", Color.Gold)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
            ElseIf hitpower <= 10 + CriticalProbability1 Then
                ChangePower(False, - 75, True, False, False, True, True)
                BreakDefence(False)
                ShowTitle("The turk&fish lord launches a strike wave (Critical Hit!)", Color.Red)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound30.wm")
            Else
                ChangePower(False, - 25, False, False, False, True, True)
                BreakDefence(False)
                ShowTitle("The turk&fish lord launches a strike wave.", Color.Black)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound30.wm")
            End If
        ElseIf code = 10 Then
            Dim damage As Double = - Math.Abs(Math.Sin(Math.PI/180*life1f.Tag))*70
            If hitpower >= 101 - MissProbability2 Then
                ShowTitle("Launch trigonometric function wave to " & Form8.EnemyName.Text & " (Miss the target.)",
                          Color.Gold)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
            ElseIf Math.Abs(Math.Sin(Math.PI/180*life1f.Tag)) = 1.0 Or hitpower <= 4 + CriticalProbability2 Then
                ChangePower(True, damage*3, True, True, False, True, True)
                ShowTitle("Launch trigonometric function wave to " & Form8.EnemyName.Text & " (Critical Hit!)",
                          Color.Red)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound24.wm")
            Else
                ChangePower(True, damage, False, True, False, True, True)
                ShowTitle("Launch trigonometric function wave to " & Form8.EnemyName.Text & ".", Color.Black)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound24.wm")
            End If
        ElseIf code = 11 Then
            If hitpower >= 96 - MissProbability1 Then
                ShowTitle("Launch fireball to " & Form8.EnemyName.Text & " (Miss the target.)", Color.Gold)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
            ElseIf hitpower <= 2 + CriticalProbability1 Then
                ChangePower(True, - 300, True, False, False, True, True)
                ShowTitle("Launch fireball to " & Form8.EnemyName.Text & " (Critical Hit!)", Color.Red)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound10.wm")
                AddStatus(True, 15, 11.8)
            Else
                ChangePower(True, - 100, False, False, False, True, True)
                ShowTitle("Launch fireball to " & Form8.EnemyName.Text & ".", Color.Black)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound10.wm")
                AddStatus(True, 15, 3.7)
            End If
        ElseIf code = 12 Then
            AddStatus(True, 18, 4)
            ShowTitle("The turkey eater worm dives into underground.", Color.Black)
            My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound33.wm")
        ElseIf code = 13 Then
            If hitpower >= 96 - MissProbability1 Then
                ChangePower(False, 0)
                ShowTitle("The turkey eater worm shoots ropy mucus (Miss the target.)" & Form8.EnemyName.Text & ".",
                          Color.Gold)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound13.wm")
            Else
                ChangePower(False, 0)
                AddStatus(False, 16, 7)
                ShowTitle("The turkey eater worm shoots ropy mucus." & Form8.EnemyName.Text & ".", Color.Black)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound13.wm")
            End If
        ElseIf code = 14 Then
            If hitpower >= 94 - MissProbability1 Then
                ShowTitle("The big milk cow gives poisonous milk (Miss the target.)", Color.Gold)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
            ElseIf hitpower <= 5 + CriticalProbability1 Then
                ChangePower(False, - 93, True)
                ShowTitle("The big milk cow gives poisonous milk (Critical Hit!)", Color.Red)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound38.wm")
            Else
                ChangePower(False, - 31)
                ShowTitle("The big milk cow gives poisonous milk.", Color.Black)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound38.wm")
            End If
            If hitpower <= 2 Then
                AddStatus(False, 12, 12)
            ElseIf hitpower <= 4 Then
                AddStatus(False, 12, 6)
            ElseIf hitpower <= 8 Then
                AddStatus(False, 12, 3)
            ElseIf hitpower <= 16 Then
                AddStatus(False, 12, 2)
            ElseIf hitpower <= 32 Then
                AddStatus(False, 12, 1)
            End If
        ElseIf code = 15 Then
            If hitpower >= 97 - MissProbability1 Then
                ShowTitle("Freeze the " & Form8.EnemyName.Text & " (Miss the target.)", Color.Gold)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
            ElseIf hitpower <= 4 + CriticalProbability1 Then
                ChangePower(True, - 100, True, False, False, True, True)
                AddStatus(True, 20, 12)
                ShowTitle("Freeze the " & Form8.EnemyName.Text & " (Critical Hit!)", Color.Red)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound44.wm")
            Else
                AddStatus(True, 20, 4)
                ChangePower(True, - 40, False, False, False, True, True)
                ShowTitle("Freeze the " & Form8.EnemyName.Text & ".", Color.Black)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound44.wm")
            End If
        ElseIf code = 16 Then
            ChangePower(True, 50)
            ShowTitle("The lunch contending robot eats a big chicken.", Color.Black)
            My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound15.wm")
        ElseIf code = 17 Then
            If hitpower >= 89 - MissProbability1 Then
                ShowTitle("The lunch contending robot throws big chicken (Miss the target.)", Color.Gold)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
            ElseIf hitpower <= 47 + CriticalProbability1 Then
                ChangePower(False, - 120, True)
                ShowTitle("The lunch contending robot throws big chicken (Critical Hit!)", Color.Red)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound16.wm")
            Else
                ChangePower(False, - 40)
                ShowTitle("The lunch contending robot throws big chicken.", Color.Black)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound16.wm")
            End If
        ElseIf code = 18 Then
            Dim damage As Double = - Math.Abs(Math.Cos(Math.PI/180*life1f.Tag))*120
            If hitpower >= 101 - MissProbability2 Then
                ShowTitle("Launch trigonometric function wave to " & Form8.EnemyName.Text & " (Miss the target.)",
                          Color.Gold)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
            ElseIf Math.Abs(Math.Sin(Math.PI/180*life1f.Tag)) = 1.0 Or hitpower <= 4 + CriticalProbability2 Then
                ChangePower(True, damage*3, True, True, False, True, True)
                ShowTitle("Launch trigonometric function wave to " & Form8.EnemyName.Text & " (Critical Hit!)",
                          Color.Red)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound24.wm")
            Else
                ChangePower(True, damage, False, True, False, True, True)
                ShowTitle("Launch trigonometric function wave to " & Form8.EnemyName.Text & ".", Color.Black)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound24.wm")
            End If
        ElseIf code = 19 Then
            If hitpower >= 93 - MissProbability1 Then
                ShowTitle("The palace guards launches iron wave (Miss the target.)", Color.Gold)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
            ElseIf hitpower <= 4 + CriticalProbability1 Then
                ChangePower(False, - 90, True, True)
                ShowTitle("The palace guards launches iron wave (Critical Hit!)", Color.Red)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound12.wm")
            Else
                ChangePower(False, - 30, False, True)
                ShowTitle("The palace guards launches iron wave.", Color.Black)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound12.wm")
            End If
        ElseIf code = 20 Then
            AddStatus(False, 4, - 1)
            ChangePower(False, - 100000, False, True, False, False, False)
            ShowTitle("Atropos destines.", Color.Red)
            My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound34.wm")
        ElseIf code = 21 Then
            ChangePower(False, 66)
            ShowTitle("Use curative box.", Color.Green)
            My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound15.wm")
        ElseIf code = 22 Then
            If hitpower >= 95 - MissProbability1 Then
                ShowTitle("Launch hydrochloric acid to " & Form8.EnemyName.Text & " (Miss the target.)", Color.Gold)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
            ElseIf hitpower <= 5 + CriticalProbability1 Then
                ChangePower(True, - 135, True)
                AddStatus(True, 16, 19.8)
                ShowTitle("Launch hydrochloric acid to " & Form8.EnemyName.Text & " (Critical Hit!)", Color.Red)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound49.wm")
            Else
                ChangePower(True, - 45)
                AddStatus(True, 16, 6.6)
                ShowTitle("Launch hydrochloric acid to " & Form8.EnemyName.Text & ".", Color.Black)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound49.wm")
            End If
        ElseIf code = 23 Then
            Dim damage = 40
            If HasDefence(False) = False Then damage *= 2
            If hitpower >= 92 - MissProbability1 Then
                ShowTitle("Tarecgosa launches laser (Miss the target.)", Color.Gold)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
            ElseIf hitpower <= 6 + CriticalProbability1 Then
                ChangePower(False, - damage*3, True)
                ShowTitle("Tarecgosa launches a big laser (Critical Hit!)", Color.Red)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound34.wm")
            Else
                ChangePower(False, - damage)
                ShowTitle("Tarecgosa launches laser.", Color.Black)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound34.wm")
            End If
        ElseIf code = 24 Then
            If hitpower >= 92 - MissProbability1 Then
                ShowTitle("Tarecgosa launches homework line (Miss the target.)", Color.Gold)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
            ElseIf hitpower <= 6 + CriticalProbability1 Then
                AddStatus(False, 22, 21)
                ChangePower(False, - 90, True)
                ShowTitle("Tarecgosa launches class suspension homework line (Critical Hit!)", Color.Red)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound30.wm")
            Else
                AddStatus(False, 22, 7)
                ChangePower(False, - 30)
                ShowTitle("Tarecgosa launches homework line.", Color.Black)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound30.wm")
            End If
        ElseIf code = 25 Then
            If hitpower >= 98 - MissProbability1 Then
                ShowTitle("Floating ghost curses (Miss the target.)", Color.Gold)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
            ElseIf hitpower <= 5 + CriticalProbability1 Then
                ChangePower(False, - life2f.Tag*0.1, True, False, False, True, True, True)
                ShowTitle("Floating ghost curses (Critical Hit!)", Color.Red)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound15.wm")
            Else
                ChangePower(False, - life2f.Tag*0.05, False, False, False, True, True, True)
                ShowTitle("Floating ghost curses.", Color.Black)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound15.wm")
            End If
        ElseIf code = 26 Then
            If hitpower >= 98 - MissProbability1 Then
                ShowTitle("Floating ghost distorts (Miss the target.)", Color.Gold)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
            ElseIf hitpower <= 5 + CriticalProbability1 Then
                ChangePower(False, - 60, True, False, False, True, True, False, True)
                ChangePower(False, - 150, True, False, False, True, True)
                ShowTitle("Floating ghost distorts (Critical Hit!)", Color.Red)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound52.wm")
            Else
                ChangePower(False, - 20, False, False, False, True, True, False, True)
                ChangePower(False, - 50, False, False, False, True, True)
                ShowTitle("Floating ghost distorts.", Color.Black)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound52.wm")
            End If
        ElseIf code = 27 Then
            If hitpower <= 70 Then AddStatus(True, 22, 12)
            If New Random(Now.Date.Second).Next(0, 101) <= 45 Then AddStatus(True, 14, 9)
            If New Random(Now.Date.Second*Now.Date.Millisecond).Next(0, 101) <= 20 Then AddStatus(True, 8, 6)
            ShowTitle("Launch massive countless homework to " & Form8.EnemyName.Text & ".", Color.Black)
            My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound53.wm")
        ElseIf code = 28 Then
            If hitpower >= 97 - MissProbability1 Then
                ShowTitle("The god of duck pool shoots vector spike (Miss the target.)", Color.Gold)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
            ElseIf hitpower <= 3 + CriticalProbability1 Then
                AddStatus(False, 22, 10)
                AddStatus(False, 13, 15)
                ChangePower(False, - 57, True)
                ShowTitle("The god of duck pool shoots vector spike (Critical Hit!)", Color.Red)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound52.wm")
            Else
                AddStatus(False, 22, 10)
                ChangePower(False, - 29)
                ShowTitle("The god of duck pool shoots vector spike.", Color.Black)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound52.wm")
            End If
        ElseIf code = 29 Then
            If hitpower >= 99 - MissProbability1 Then
                ShowTitle("The god of duck pool launches aluminum triangle (Miss the target.)", Color.Gold)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
            ElseIf hitpower <= 2 + CriticalProbability1 Then
                ChangePower(False, - 198, True)
                If cd2t.Text = "Charge:" Then StopCharge2 = True
                ShowTitle("The god of duck pool launches aluminum triangle (Critical Hit!)", Color.Red)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound23.wm")
            Else
                ChangePower(False, - 66)
                If cd2t.Text = "Charge:" Then StopCharge2 = True
                ShowTitle("The god of duck pool launches aluminum triangle.", Color.Black)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound23.wm")
            End If
        ElseIf code = 30 Then
            If hitpower >= 99 - MissProbability1 Then
                ShowTitle("The god of duck pool launches aluminum triangle (Miss the target.)", Color.Gold)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
            ElseIf hitpower <= 2 + CriticalProbability1 Then
                ChangePower(False, - 198, True)
                If cd2t.Text = "Charge:" Then StopCharge2 = True
                ShowTitle("The god of duck pool launches aluminum triangle (Critical Hit!)", Color.Red)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound57.wm")
            Else
                ChangePower(False, - 66)
                If cd2t.Text = "Charge:" Then StopCharge2 = True
                ShowTitle("The god of duck pool launches aluminum triangle.", Color.Black)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound57.wm")
            End If
        ElseIf code = 31 Then
            If hitpower >= 99 - MissProbability1 Then
                ShowTitle("The witch mirrors unsuccessfully.", Color.Gold)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
            Else
                ChangePower(False, LastMagicalDamage1, False, False, False, True, True)
                LastMagicalDamage1 = 0
                ShowTitle("The witch mirrors.", Color.Blue)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound57.wm")
            End If
        ElseIf code = 32 Then
            If hitpower >= 96 - MissProbability1 Then
                ShowTitle("The witch charms (Failed to spell.)", Color.Gold)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
            Else
                AddStatus(False, 30, 14.1)
                ShowTitle("The witch charms.", Color.Black)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound58.wm")
            End If
        ElseIf code = 33 Then
            If hitpower >= 97 - MissProbability1 Then
                ShowTitle("The ejector got seized up while ejecting (Miss the target.)", Color.Gold)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
            ElseIf hitpower <= 2 + CriticalProbability1 Then
                AddStatus(True, 31, 37.5)
                AddStatus(False, 31, 37.5)
                ChangePower(True, - 1500, True)
                If cd2t.Text = "Charge:" Then StopCharge2 = True
                ShowTitle("Eject hydrogen sulfide (Critical Hit!!)", Color.Red)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound25.wm")
            Else
                AddStatus(True, 31, 25)
                AddStatus(False, 31, 25)
                ChangePower(True, - 500)
                If cd2t.Text = "Charge:" Then StopCharge2 = True
                ShowTitle("Eject low concentration of hydrogen sulfide.", Color.Black)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound56.wm")
            End If
        ElseIf code = 34 Then
            If hitpower >= 95 - MissProbability1 Then
                ShowTitle("The chicken lays an egg and throws it (Miss the target.)", Color.Gold)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
            ElseIf hitpower <= 7 + CriticalProbability1 Then
                ChangePower(False, - 150, True)
                ShowTitle("The chicken lays an egg and throws it (Critical Hit!)", Color.Red)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound16.wm")
                AddStatus(False, 4, 9)
            Else
                ChangePower(False, - 50)
                ShowTitle("The chicken lays an egg and throws it.", Color.Black)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound16.wm")
                If hitpower <= 27 Then AddStatus(False, 4, 3)
            End If
        ElseIf code = 35 Then
            If hitpower >= 95 - MissProbability1 Then
                ShowTitle("The negative positive cow spreads negative gas (Suppressed in body.)", Color.Gold)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
            ElseIf hitpower <= 7 + CriticalProbability1 Then
                ChangePower(False, - 147, True, False, False, True, True)
                ShowTitle("The negative positive cow spreads smelly negative gas (Critical Hit!)", Color.Red)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound56.wm")
                AddStatus(False, 12, 15)
            Else
                ChangePower(False, - 49, False, False, False, True, True)
                ShowTitle("The negative positive cow spreads negative gas.", Color.Black)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound56.wm")
                If hitpower <= 44 Then AddStatus(False, 12, 5)
            End If
        ElseIf code = 36 Then
            If hitpower >= 95 - MissProbability1 Then
                ShowTitle("The negative positive cow releases power of Nether (Suppressed in body.)", Color.Gold)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
            ElseIf hitpower <= 7 + CriticalProbability1 Then
                ChangePower(False, - 110, True, False, False, True, True, True)
                ShowTitle("The negative positive cow releases extreme power of Nether (Critical Hit!)", Color.Red)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound30.wm")
            Else
                ChangePower(False, - 55, False, False, False, True, True, True)
                ShowTitle("The negative positive cow releases power of Nether.", Color.Black)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound30.wm")
            End If
        ElseIf code = 37 Then
            Dim damage As Integer = Math.Pow(mana2f.Tag, 2)/50
            If hitpower >= 95 - MissProbability1 Then
                ShowTitle("Mr.Duck phantom burns your mana (No effect.)", Color.Gold)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
            ElseIf hitpower <= 1 + CriticalProbability1 Then
                ChangePower(False, - damage*2, True, True, False, True, True)
                ShowTitle("Mr.Duck phantom burns your mana (Critical Hit!)", Color.Red)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound64.wm")
            Else
                ChangePower(False, - damage, False, True, False, True, True)
                ShowTitle("Mr.Duck phantom burns your mana.", Color.Black)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound64.wm")
            End If
        ElseIf code = 38 Then
            Dim damage As Integer
            If (life2f.Tag - 90) Mod 180 = 0 Then damage = life2f.Tag Else _
                damage = Math.Abs(40*Math.Tan(Math.PI/180*life2f.Tag))
            If hitpower >= 95 - MissProbability1 Then
                ShowTitle("Mr.Duck phantom launches tangent wave (No effect.)", Color.Gold)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
            ElseIf hitpower <= 1 + CriticalProbability1 Then
                ChangePower(False, - damage*2, True, True, False, True, True)
                ShowTitle("Mr.Duck phantom launches tangent wave (Critical Hit!)", Color.Red)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound65.wm")
            Else
                ChangePower(False, - damage, False, True, False, True, True)
                ShowTitle("Mr.Duck phantom launches tangent wave.", Color.Black)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound65.wm")
            End If
        ElseIf code = 39 Then
            If hitpower >= 98 - MissProbability1 Then
                ShowTitle("??? beamed a red laser (No effect.)", Color.Gold)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
            ElseIf hitpower <= 4 + CriticalProbability1 Then
                ChangePower(False, - 300, True, False, False, True, True)
                ShowTitle("??? beamed a big long thick red laser (Critical Hit!)", Color.Red)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound66.wm")
            Else
                ChangePower(False, - 100, False, False, False, True, True)
                ShowTitle("??? beamed a red laser.", Color.Black)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound66.wm")
            End If
        ElseIf code = 40 Then
            ChangePower(True, life1b.Tag*0.1)
            ShowTitle("??? prays.", Color.Red)
            My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound20.wm")
        ElseIf code = 41 Then
            AddStatus(True, 9, 3)
            ChangePower(False, - life2b.Tag*0.25, False, True, False, True, True)
            ChangePower(False, - mana2f.Tag, False, True, True, True, True, False, True)
            ShowTitle("??? immolates you with the power of shadow.", Color.Red)
            My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound67.wm")
        ElseIf code = 42 Then
            ShowTitle("Turkey rider crys out the turkey voice!", Color.Blue)
            My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound5.wm")
        End If
    End Sub

    Private Sub StatusCheck_Tick(sender As Object, e As EventArgs) Handles StatusCheck.Tick
        If HasStatus(True, 12) Then ChangePower(True, - 12, False, True, True, False, False)
        If HasStatus(True, 13) Then ChangePower(True, - 8, False, True, True, False, False)
        If HasStatus(True, 15) Then ChangePower(True, - 10, False, False, True, False, False)
        If HasStatus(True, 16) Then ChangePower(True, - life1b.Tag/100, False, True, True, False, False)
        If HasStatus(True, 19) Then ChangePower(True, - 3, False, True, True, False, False)
        If HasStatus(True, 23) Then ChangePower(True, - 6, False, True, True, False, False)
        If HasStatus(True, 31) Then ChangePower(True, - 25, False, True, True, False, False)
        '____opposite____
        If HasStatus(False, 12) Then ChangePower(False, - 12, False, True, True, False, False)
        If HasStatus(False, 13) Then ChangePower(False, - 8, False, True, True, False, False)
        If HasStatus(False, 15) Then ChangePower(False, - 10, False, False, True, False, False)
        If HasStatus(False, 1) Then ChangePower(False, - 4, False, False, True, False, False)
        If HasStatus(False, 16) Then ChangePower(False, - life2b.Tag/100, False, True, True, False, False)
        If HasStatus(False, 31) Then ChangePower(False, - 25, False, True, True, False, False)
    End Sub

    Private Function IsStunned(player1 As Boolean)
        Dim result = False
        If HasStatus(player1, 4) Then result = True
        If HasStatus(player1, 8) Then result = True
        Return result
    End Function

    Private Sub next1_Click(sender As Object, e As EventArgs) Handles next1.Click
        If content1.Tag = 0 Then
            content1.Tag = 1
            content1.Text =
                "You cannot use common attack, defence or magic. You can have an attack after spelling one word."
        ElseIf content1.Tag = 1 Then
            content1.Tag = 2
            next1.Enabled = False
            spelling.Visible = True
            ChangeWord("Example")
            content1.Text = "Now let's spell this word. Enter your word on the textbox."
        ElseIf content1.Tag = 3 Then
            content1.Tag = 4
            content1.Text =
                "The red word does critical damage, the green word heals you instead of damaging the enemy, the blue word shrinks the word length."
        ElseIf content1.Tag = 4 Then
            content1.Tag = 5
            content1.Text = "Good luck, good speed."
        ElseIf content1.Tag = 5 Then
            content1.Tag = 6
            special1.Visible = False
            Hide()
            Form8.Show()
            Form8.EnemyName.Text = "solar corona ball"
            Form8.skill1.Text = "Strike"
            Form8.skill1.Visible = True
            Form8.skill1t.Text = "Cause 13 damage."
            Form8.skill1t.Visible = True
            Form8.skill2.Text = "Decelerate"
            Form8.skill2.Visible = True
            Form8.skill2t.Text = "Make your enemy's words longer."
            Form8.skill2t.Visible = True
            Form8.skill3.Text = "Blast"
            Form8.skill3.Visible = True
            Form8.skill3t.Text = "Stun your enemy for 8.0 seconds."
            Form8.skill3t.Visible = True
            defend.Enabled = True
            attack.Enabled = True
            If Form1.heal > 0 Then heal.Enabled = True
        ElseIf content1.Tag = 6 Then
            content1.Tag = 7
            mana2f.Visible = True
            mana2b.Visible = True
            mana2t.Visible = True
            mana2t.ForeColor = Color.Blue
            mana2b.Tag = 100
            ModifyMana(False, 75)
            point2mana = LockNumber(mana2f.Tag)
            RefreshTexts()
            Mana2restore.Interval = 1000
            content1.Text = "Look at your mana bar, at present your max mana is 100. It can get increased in future."
        ElseIf content1.Tag = 7 Then
            content1.Tag = 8
            content1.Text =
                "You got a new item ""Snowflake"" just now, it is the mana-required spell. Try to use it in this battle."
        ElseIf content1.Tag = 8 Then
            content1.Tag = 9
            special1.Visible = False
            Hide()
            Form8.Show()
            Form8.EnemyName.Text = "lunch contending robot"
            Form8.skill1.Text = "Scratch"
            Form8.skill1.Visible = True
            Form8.skill1t.Text = "Cause 30 damage."
            Form8.skill1t.Visible = True
            Form8.skill2.Text = "Eat chicken"
            Form8.skill2.Visible = True
            Form8.skill2t.Text = "Heal 50 point of life."
            Form8.skill2t.Visible = True
            Form8.skill3.Text = "Throw chicken"
            Form8.skill3.Visible = True
            Form8.skill3t.Text = "Cause 40 damage."
            Form8.skill3t.Visible = True
            defend.Enabled = True
            attack.Enabled = True
        ElseIf content1.Tag = 9 Then
            content1.Tag = 10
            content1.Text =
                "The turkey mode of the witch is immune to magical damage, cannot be added new status, but suffers more from physical damage. The witch can instantaneously change its mode."
        ElseIf content1.Tag = 10 Then
            special1.Visible = False
            content1.Tag = 11
            Hide()
            Form8.Show()
            Form8.EnemyName.Text = "witch"
            Form8.skill1.Text = "Purple light"
            Form8.skill1.Visible = True
            Form8.skill1t.Text = "Cause 100 damage."
            Form8.skill1t.Visible = True
            Form8.skill2.Text = "Turtlify"
            Form8.skill2.Visible = True
            Form8.skill2t.Text = "Change to turtle."
            Form8.skill2t.Visible = True
            Form8.skill3.Text = "Turkify"
            Form8.skill3.Visible = True
            Form8.skill3t.Text = "Change to turkey."
            Form8.skill3t.Visible = True
            defend.Enabled = True
            attack.Enabled = True
        End If
    End Sub

    Public Sub ChangeWord(Optional word As String = "")
        If word = "" Then
            Back:
            If content1.Tag <= 3 Then Exit Sub
            Dim RandomNumber As Integer = random_.Next(0, vocabulary.Items.Count)
            If secret.Tag < secret.Text.Length Then
                If Not vocabulary.Items(RandomNumber).ToString.Substring(0, 1) = secret.Text.Substring(secret.Tag, 1) _
                    Then GoTo Back
            End If
            If HasStatus(False, 6) And HasStatus(False, 7) = False Then
                If vocabulary.Items(RandomNumber).ToString.Length > 5 Then GoTo Back
            ElseIf HasStatus(False, 6) = False And HasStatus(False, 7) Then
                If vocabulary.Items(RandomNumber).ToString.Length < 10 Then GoTo Back
            Else
                If vocabulary.Items(RandomNumber).ToString.Length <= 5 Then GoTo Back
                If vocabulary.Items(RandomNumber).ToString.Length >= 10 Then GoTo Back
            End If
            word = vocabulary.Items(RandomNumber)
            secret.Tag += 1
        End If
        SpellBox.Clear()
        example.Text = word
        SpellBox.MaxLength = word.Length
        example.Text = example.Text.Substring(0, 1).ToUpper & example.Text.Substring(1, example.Text.Length - 1).ToLower
        If content1.Tag <= 3 Then Exit Sub
        Dim RandomNumber2 As Integer = random_.Next(0, 16)
        If RandomNumber2 = 0 Then
            example.ForeColor = Color.Green
        ElseIf RandomNumber2 = 1 Then
            example.ForeColor = Color.Blue
        ElseIf RandomNumber2 = 2 Or RandomNumber2 = 3 Then
            example.ForeColor = Color.Red
        Else
            example.ForeColor = Color.Black
        End If
    End Sub

    Private Sub SpellBox_TextChanged(sender As Object, e As EventArgs) Handles SpellBox.TextChanged
        If SpellBox.TextLength = 0 Then Exit Sub
        SpellBox.Text = SpellBox.Text.Substring(0, 1).ToUpper &
                        SpellBox.Text.Substring(1, SpellBox.Text.Length - 1).ToLower
        If SpellBox.TextLength = SpellBox.MaxLength Then
            If example.Text = SpellBox.Text Then
                If content1.Tag = 2 Then special1.Visible = False
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound3.wm")
                If example.ForeColor = Color.Red Then
                    ChangePower(True, 3*(- attack_type*2 - 4), True)
                    ShowTitle("Spell (Critical!)", Color.Red)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound3.wm")
                ElseIf example.ForeColor = Color.Green Then
                    ChangePower(False, 6*(defend_type*2 + 4))
                    ShowTitle("Cure.", Color.Green)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound20.wm")
                ElseIf example.ForeColor = Color.Blue Then
                    ChangePower(False, 0)
                    ShowTitle("Shrink.", Color.Green)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound21.wm")
                    AddStatus(False, 6, 18)
                Else
                    ChangePower(True, - attack_type*2 - 4)
                    ShowTitle("Spell.", Color.Black)
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound3.wm")
                End If
            Else
                If content1.Tag = 2 Then
                    SpellBox.Clear()
                Else
                    If example.ForeColor = Color.Red Then
                        ChangePower(False, 3*(- attack_type*2 - 4), True)
                        ShowTitle("Spell (Wrong! Critical!)", Color.Red)
                        title.ForeColor = Color.Red
                        My.Computer.Audio.Play(
                            My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound3.wm")
                    ElseIf example.ForeColor = Color.Green Then
                        ChangePower(False, 0)
                        ShowTitle("Cure (Useless.)", Color.Gold)
                        My.Computer.Audio.Play(
                            My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
                    ElseIf example.ForeColor = Color.Blue Then
                        ChangePower(False, 0)
                        ShowTitle("Shrink (Useless.)", Color.Gold)
                        My.Computer.Audio.Play(
                            My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
                    Else
                        ChangePower(False, - attack_type*2 - 4)
                        ShowTitle("Spell (Wrong!)", Color.OrangeRed)
                        My.Computer.Audio.Play(
                            My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound3.wm")
                    End If
                End If
            End If
            SpellBox.Clear()
            If content1.Tag = 2 Then Exit Sub
            example.Text = ""
            ChangeWord()
        End If
        SpellBox.SelectionStart = SpellBox.Text.Length
        SpellBox.ScrollToCaret()
    End Sub

    Private Sub heal_Click(sender As Object, e As EventArgs) Handles heal.Click
        If battle = 14 Or battle = 23 Or life2f.Tag = life2b.Tag Or life2f.Tag = 0 Then
            heal.Enabled = False
            Exit Sub
        End If
        Form1.heal -= 1
        ChangePower(False, life2b.Tag*0.33, False, True, False, False, False)
        ShowTitle("Heal.", Color.Green)
        My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound19.wm")
        CoolDown(False, 0.6)
        heal.Text = "Heal(" & Form1.heal & ")"
        If Form1.heal = 0 Then heal.Enabled = False
    End Sub

    Private Sub RemoveAllStatuses(player1 As Boolean)
        For i = 0 To 5
            If player1 Then
                status1(i).Visible = False
            Else
                status2(i).Visible = False
            End If
        Next
    End Sub

    Private Sub assist1_Click(sender As Object, e As EventArgs) Handles assist1.Click
        CheckForMissCritical(False)
        Dim AddUp = 1
        Dim BossUp = 0
        If battle = 6 Then AddUp = 8
        If battle = 8 Then BossUp = - 1
        Dim hitpower As Integer = random_.Next(1, 101)
        If assist.Tag = 0 Then
            If hitpower < 95 - MissProbability2 Then
                ChangePower(True, - 14*AddUp + BossUp)
                ShowTitle("Peck the " & Form8.EnemyName.Text & ".", Color.Black)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound14.wm")
            ElseIf hitpower <= 6 + CriticalProbability2 Then
                ChangePower(True, - 42*AddUp + 3*BossUp, True)
                ShowTitle("Peck the " & Form8.EnemyName.Text & " (Critical Hit!)", Color.Red)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound14.wm")
            Else
                ShowTitle("Peck the " & Form8.EnemyName.Text & " (Miss the target.)", Color.Gold)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
            End If
            CoolDown(False, 1.6)
        End If
    End Sub

    Private Sub assist2_Click(sender As Object, e As EventArgs) Handles assist2.Click
        Charge(False, 7, 0.7, 2.4)
    End Sub

    Private Sub CheckForMissCritical(player1 As Boolean)
        If player1 Then
            MissProbability1 = 0
            CriticalProbability1 = 0
            If HasStatus(player1, 11) Then MissProbability1 = 24
            If HasStatus(player1, 11) Then CriticalProbability1 = - 101
            If HasStatus(player1, 14) Then MissProbability1 = 70
            If HasStatus(False, 18) Then MissProbability1 = 101
            If HasStatus(True, 33) Then CriticalProbability1 = 101
        Else
            MissProbability2 = 0
            CriticalProbability2 = 0
            If HasStatus(player1, 11) Then MissProbability2 = 24
            If HasStatus(player1, 11) Then CriticalProbability2 = - 101
            If HasStatus(player1, 14) Then MissProbability2 = 70
            If HasStatus(True, 18) Then MissProbability2 = 101
            If HasStatus(True, 26) Then MissProbability2 = 30
            If HasStatus(True, 34) Then MissProbability2 = 101
        End If
    End Sub

    Private Sub assist3_Click(sender As Object, e As EventArgs) Handles assist3.Click
        If assist.Tag = 0 Then
            Dim hitpower As Integer = random_.Next(1, 101)
            Dim BattleCut = 0
            If battle = 7 Then BattleCut = 20
            Dim damage As Double
            If battle = 8 Then
                damage = - Math.Abs(Math.Cos(Math.PI/180*life1f.Tag))*100
            Else
                damage = - Math.Abs(Math.Sin(Math.PI/180*life1f.Tag))*(100 + BattleCut)
            End If
            If hitpower >= 95 - MissProbability2 Then
                ShowTitle("Launch trigonometric function wave to " & Form8.EnemyName.Text & " (Miss the target.)",
                          Color.Gold)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
            ElseIf hitpower <= 5 + CriticalProbability2 Then
                ChangePower(True, damage*3, True, True, False, True, True)
                ShowTitle("Launch trigonometric function wave to " & Form8.EnemyName.Text & " (Critical Hit!)",
                          Color.Red)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound24.wm")
            Else
                ChangePower(True, damage, False, True, False, True, True)
                ShowTitle("Launch trigonometric function wave to " & Form8.EnemyName.Text & ".", Color.Black)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound24.wm")
            End If
            CoolDown(False, 5.1)
        End If
    End Sub

    Private Sub debug_Tick(sender As Object, e As EventArgs) Handles debug.Tick
        debug1.CheckBox1.Checked = EnemyAction.Enabled
        debug1.CheckBox2.Checked = setlife1.Enabled
        debug1.CheckBox3.Checked = setlife2.Enabled
        debug1.CheckBox4.Checked = setmana1.Enabled
        debug1.CheckBox5.Checked = setmana2.Enabled
        debug1.CheckBox6.Checked = Mana1restore.Enabled
        debug1.CheckBox7.Checked = Mana2restore.Enabled
        debug1.Label1.Text = "life1=" & UnlockNumber(point1)
        debug1.Label2.Text = "life2=" & UnlockNumber(point2)
        debug1.Label3.Text = "mana1=" & UnlockNumber(point1mana)
        debug1.Label4.Text = "mana2=" & UnlockNumber(point2mana)
    End Sub

    Public Sub SetParent()
        For i = 0 To 5
            status1(i).BackColor = Color.Transparent
            status2(i).BackColor = Color.Transparent
        Next
        battler.BackColor = Color.Transparent
        assist.BackColor = Color.Transparent
        cd1t.BackColor = Color.Transparent
        cd2t.BackColor = Color.Transparent
        title.BackColor = Color.Transparent
        life1t.BackColor = Color.Transparent
        life2t.BackColor = Color.Transparent
        defendt.BackColor = Color.Transparent
        attackt.BackColor = Color.Transparent
        magict.BackColor = Color.Transparent
        paused.BackColor = Color.Transparent
        popout2.BackColor = Color.Transparent
        mana1t.BackColor = Color.Transparent
        mana2t.BackColor = Color.Transparent
    End Sub

    Private Sub cd1_Click(sender As Object, e As EventArgs)
        'ModifyLife(True, 0)
    End Sub

    Private Sub RemoveStatus(player1 As Boolean, Code As Integer)
        For i = 0 To 5
            If player1 Then
                If status1(i).Visible AndAlso status1(i).Tag.ToString.Split(":")(0) = Code Then _
                    status1(i).Visible = False
            Else
                If status2(i).Visible AndAlso status2(i).Tag.ToString.Split(":")(0) = Code Then _
                    status2(i).Visible = False
            End If
        Next
    End Sub

    Private Sub BreakDefence(player1 As Boolean)
        RemoveStatus(player1, 0)
        RemoveStatus(player1, 5)
        RemoveStatus(player1, 10)
    End Sub

    Private Function HasDefence(player1 As Boolean)
        Dim result = False
        If HasStatus(player1, 0) Then result = True
        If HasStatus(player1, 5) Then result = True
        If HasStatus(player1, 10) Then result = True
        Return result
    End Function

    Private Sub pause_Click(sender As Object, e As EventArgs) Handles pause.Click
        If pause.Text = "Pause" Then
            pause.Text = "Resume"
            paused.Visible = True
            paused.BringToFront()
            pause.BringToFront()
            cool1.Enabled = False
            cool2.Enabled = False
            StatusCheck.Enabled = False
            StatusMove.Enabled = False
            EnemyAction.Enabled = False
            AnotherCode = assist.Visible
            assist.Visible = False
            Mana1restore.Enabled = False
            Mana2restore.Enabled = False
        Else
            pause.Text = "Pause"
            paused.Visible = False
            If cd1b.Visible Then cool1.Enabled = True
            If cd2b.Visible Then cool2.Enabled = True
            StatusCheck.Enabled = True
            StatusMove.Enabled = True
            EnemyAction.Enabled = True
            assist.Visible = AnotherCode
            If mana1b.Visible Then Mana1restore.Enabled = True
            If mana2b.Visible Then Mana2restore.Enabled = True
        End If
    End Sub

    Private Sub Mana1restore_Tick(sender As Object, e As EventArgs) Handles Mana1restore.Tick
        If HasStatus(True, 31) Then Exit Sub
        ChangePower(True, 1, False, False, True, False, False, False, True)
    End Sub

    Private Sub Mana2restore_Tick(sender As Object, e As EventArgs) Handles Mana2restore.Tick
        If HasStatus(False, 31) Then Exit Sub
        ChangePower(False, 1, False, False, True, False, False, False, True)
    End Sub

    Private Sub setmana1_Tick(sender As Object, e As EventArgs) Handles setmana1.Tick
        If mana1f.Tag > UnlockNumber(point1mana) Then
            ModifyMana(True, mana1f.Tag - 1)
            RefreshTexts()
        ElseIf mana1f.Tag < UnlockNumber(point1mana) Then
            ModifyMana(True, mana1f.Tag + 1)
            RefreshTexts()
        Else
            setmana1.Enabled = False
        End If
    End Sub

    Private Sub setmana2_Tick(sender As Object, e As EventArgs) Handles setmana2.Tick
        If mana2f.Tag > UnlockNumber(point2mana) Then
            ModifyMana(False, mana2f.Tag - 1)
            RefreshTexts()
        ElseIf mana2f.Tag < UnlockNumber(point2mana) Then
            ModifyMana(False, mana2f.Tag + 1)
            RefreshTexts()
        Else
            setmana2.Enabled = False
        End If
    End Sub

    Private Function Spell(player1 As Boolean, cost As Integer, code As Integer)
        If (player1 And mana1f.Tag < cost) Or (player1 = False And mana2f.Tag < cost) Then
            If player1 Then
                color1.Enabled = True
                mana1t.ForeColor = Color.Red
            Else
                color2.Enabled = True
                mana2t.ForeColor = Color.Red
            End If
            Return False
        Else
            ChangePower(player1, - cost, False, True, False, False, False, False, True)
            If code = 0 Then
                Charge(False, 15, 1.8, 1.5)
            ElseIf code = 1 Then
                Charge(False, 18, 1.7, 1.3)
            ElseIf code = 2 Then
                Charge(True, 20, 5, 20)
            ElseIf code = 3 Then
                Charge(False, 21, 0.75, 1.25)
            ElseIf code = 4 Then
                Charge(False, 22, 1.45, 1.55)
            ElseIf code = 5 Then
                Charge(True, 23, 3, 1.5)
            ElseIf code = 6 Then
                Charge(True, 24, 2, 2.5)
            ElseIf code = 7 Then
                Charge(True, 25, 2.25, 0.75)
            ElseIf code = 8 Then
                Charge(True, 26, 3, 0.75)
            ElseIf code = 9 Then
                Charge(False, 27, 1.5, 1.15)
            ElseIf code = 10 Then
                ShowTitle("The " & Form8.EnemyName.Text & " changes to turtle.", Color.Blue)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound20.wm")
                battler.Image =
                    Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image16.wm")
                RemoveStatus(True, 28)
                AddStatus(True, 27, 8.1)
                CoolDown(True, 1.5)
            ElseIf code = 11 Then
                ShowTitle("The " & Form8.EnemyName.Text & " changes to turkey.", Color.Blue)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound20.wm")
                battler.Image =
                    Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image17.wm")
                RemoveStatus(True, 27)
                AddStatus(True, 28, 8.1)
                CoolDown(True, 1.5)
            ElseIf code = 12 Then
                Dim hitpower As Integer = random_.Next(1, 101)
                ShowTitle("The witch puts magic power on you (" & MagicPowerStage & "/3)", Color.Black)
                My.Computer.Audio.Play(
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound15.wm")
                If MagicPowerStage = 3 Then
                    MagicPowerStage = 0
                    If hitpower >= 98 - MissProbability1 Then
                        ShowTitle("The magic power goes away.", Color.Gold)
                        My.Computer.Audio.Play(
                            My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound6.wm")
                    ElseIf hitpower <= 3 + CriticalProbability1 Then
                        ChangePower(False, - 200, True)
                        ShowTitle("The magic power explodes (Critical Hit!)", Color.Red)
                        My.Computer.Audio.Play(
                            My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound23.wm")
                    Else
                        ChangePower(False, - 100)
                        ShowTitle("The magic power explodes.", Color.OrangeRed)
                        My.Computer.Audio.Play(
                            My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound24.wm")
                    End If
                End If
                CoolDown(True, 2.33)
            ElseIf code = 13 Then
                Charge(True, 31, 1, 1.6)
            ElseIf code = 14 Then
                Charge(True, 32, 1.6, 1)
            ElseIf code = 15 Then
                Charge(False, 33, 1, 1.5)
            ElseIf code = 16 Then
                Charge(True, 35, 2.4, 1.3)
            ElseIf code = 17 Then
                Charge(True, 36, 1.9, 1.6)
            ElseIf code = 18 Then
                Charge(True, 37, 1.4, 1.6)
            ElseIf code = 19 Then
                Charge(True, 38, 1.6, 1.8)
            ElseIf code = 20 Then
                Charge(True, 40, 1, 2)
            ElseIf code = 21 Then
                Charge(True, 41, 3, 2)
            End If
            Return True
        End If
    End Function

    Private Sub color1_Tick(sender As Object, e As EventArgs) Handles color1.Tick
        color1.Enabled = False
        mana1t.ForeColor = Color.Blue
    End Sub

    Private Sub color2_Tick(sender As Object, e As EventArgs) Handles color2.Tick
        color2.Enabled = False
        mana2t.ForeColor = Color.Blue
    End Sub

    Private Sub CheckForCheating()
        if mana1f.Tag = nothing Or mana2f.tag = nothing then
            exit sub
        end if
        If _
            Not life1f.Tag.ToString = UnlockNumber(LockedLife1) Or Not life2f.Tag.ToString = UnlockNumber(LockedLife2) Or
            (mana1b.Visible And Not mana1f.Tag.ToString = UnlockNumber(LockedMana1)) Or
            (mana2b.Visible And Not mana2f.Tag.ToString = UnlockNumber(LockedMana2)) Then
            Form1.music.Ctlcontrols.stop()
            EnemyAction.Enabled = False
            StatusCheck.Enabled = False
            StatusMove.Enabled = False
            setlife1.Enabled = False
            setlife2.Enabled = False
            setmana1.Enabled = False
            setmana2.Enabled = False
            cool1.Enabled = False
            cool2.Enabled = False
            settop1.Enabled = False
            settop2.Enabled = False
            shining.Enabled = False
            defeat.Enabled = False
            titleshow.Enabled = False
            MsgBox(
                "An unexpected external modification is found affecting the program." & vbCrLf &
                "Turn off the external modifier, then start the program again if you want." & vbCrLf &
                "Now the program is going to close.", vbCritical, "Unexpected Modification")
            End
        End If
    End Sub

    Private Function LockNumber(number As Integer)
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
        Next
        If number < 0 Then exportion = exportion & "X"
        Return exportion
    End Function

    Private Function UnlockNumber(password As String)
        Dim exportion = ""
        If password = "" Then Return 0
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
            If password.ToString.Substring(x, 1) = "X" Then exportion = "-" & exportion
        Next
        Return exportion
    End Function
End Class