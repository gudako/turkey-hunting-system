Public Class Form12

    Public Sub initialization()
        skill.Text = ""
        skillt.Text = ""
        manacost.Text = ""
        skill.Visible = False
        skillt.Visible = False
        manacost.Visible = False
        Button1.Enabled = True
        ListBox1.Items.Clear()
        For i As Integer = 0 To Form1.magics.Items.Count - 1
            ListBox1.Items.Add(Form1.magics.Items(i))
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        UnifiedAction()
    End Sub

    Private Sub UnifiedAction()
        If Form7.battle = 12 And Not ListBox1.SelectedItem = "Snowflake" Then
            MsgBox("You should use the mana-required magic ""Snowflake"" to complete the battle.", 0, "Unable.")
            Exit Sub
        End If
        Form7.pause.Enabled = True
        If Form7.battle = 8 Or Form7.battle = 15 Or Form7.battle = 19 Then
            Button1.Enabled = False
            Timer1.Enabled = True
            Button1.Text = Math.Round(Form1.music.currentMedia.duration, 2)
            Form1.music.Ctlcontrols.play()
            Exit Sub
        End If
        Hide()
        Form7.Show()
        Form7.Mana1restore.Enabled = Form7.mana1b.Visible
        Form7.Mana2restore.Enabled = Form7.mana2b.Visible
        Form7.BackColor = Color.SeaShell
        If Form7.battle <= 2 Then
            Form7.heal.Visible = False
        Else
            Form7.heal.Visible = True
        End If
        If Form7.battle = 5 Then
            Form7.enemies_number.Visible = True
            Form7.number.Maximum = 13
            Form7.number.Value = 13
            Form7.numberT.Text = 13
            Form7.heal.Enabled = False
            Form7.StatusCheck.Enabled = True
            Form7.EnemyAction.Enabled = True
            Form8.EnemyName.Text = "insane murloc" & Form7.number.Maximum - Form7.number.Value + 1
        ElseIf Form7.battle = 6 Then
            MsgBox("Mr.Duck can peck the murloc, the damage will be increased eightfold.", 64, "Battle Tip")
            Form7.enemies_number.Visible = True
            Form7.StatusCheck.Enabled = True
            Form7.EnemyAction.Enabled = True
            Form8.EnemyName.Text = "insane murloc" & Form7.number.Maximum - Form7.number.Value + 1
            Form7.assist.Tag = 0
            Form7.assist.Visible = True
            Form7.assist.Text = "Mr.Duck"
            Form7.assist1.Text = "Peck"
            Form7.assist1t.Text = "Cause 14 damage, octuple to murloc."
            Form7.assist2.Text = "Math wave"
            Form7.assist2t.Text = "Puzzle your enemy. Dispel statuses."
            Form7.assist3.Text = "Function"
            Form7.assist3t.Text = "Cause 100|sin(x°)| damage. x=your enemy's health."
            Form7.assist.Enabled = True
        ElseIf Form7.battle = 7 Then
            MsgBox("The mixed turk&fish can attack very, very fast. You have less time for thinking." & vbCrLf & "Mr.Duck's function will be effective when the enemy's life is near 90 or 270, it can cause 120 damage when the life is 90 or 270." & vbCrLf & "The ""function"" is an absolute attack (The damage cannot be changed by other cause.)", 64, "Battle Tip")
            Form7.StatusCheck.Enabled = True
            Form7.EnemyAction.Enabled = True
            Form7.assist.Tag = 0
            Form7.assist.Visible = True
            Form7.assist.Text = "Mr.Duck"
            Form7.assist1.Text = "Peck"
            Form7.assist1t.Text = "Cause 14 damage, octuple to murloc."
            Form7.assist2.Text = "Math wave"
            Form7.assist2t.Text = "Puzzle your enemy. Dispel statuses."
            Form7.assist3.Text = "Function"
            Form7.assist3t.Text = "Cause 120|sin(x°)| damage. x=your enemy's health."
            Form7.assist.Enabled = True
            Form7.enemies_number.Visible = False
        ElseIf Form7.battle = 9 Then
            Form7.assist.Visible = False
            Form7.StatusCheck.Enabled = True
            Form7.EnemyAction.Enabled = True
        Else
            Form7.StatusCheck.Enabled = True
            Form7.EnemyAction.Enabled = True
            If Form7.mana1enabled Then Form7.Mana1restore.Enabled = True
            If Form7.mana2enabled Then Form7.Mana2restore.Enabled = True
        End If
        If ListBox1.SelectedItems.Count = 0 Then
            Form7.magic.Enabled = False
            Form7.magict.Enabled = False
            Form7.magic.Text = "Magic"
            Form7.magict.Text = "Unable."
        Else
            Form7.magic.Enabled = True
            Form7.magict.Enabled = True
            Form7.magic.Text = skill.Text
            Form7.magict.Text = skillt.Text
        End If
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        skill.Visible = True
        skillt.Visible = True
        If ListBox1.SelectedItem = "Water egg" Then
            skill.Text = "Splash"
            skillt.Text = "Slow down your enemy's cool down."
            content.Text = "This skill will slow down both your enemy's cool down speed and charge time in some seconds."
            Form7.magic_type = 1
            manacost.Visible = False
        ElseIf ListBox1.SelectedItem = "Cockscomb gun" Then
            skill.Text = "Launch"
            skillt.Text = "Cause 60 damage."
            content.Text = "This skill needs less time to charge, but its cool down time will be very long. It still has the probability to miss the target."
            Form7.magic_type = 2
            manacost.Visible = False
        ElseIf ListBox1.SelectedItem = "Solar light" Then
            skill.Text = "Shine"
            skillt.Text = "Numb your enemy for 3 seconds."
            content.Text = "This skill needs long time to charge but less time to cool down. It can benumb your enemy, he cannot do anything while being numbed, after that he'll get ""Slow down""."
            Form7.magic_type = 3
            manacost.Visible = False
        ElseIf ListBox1.SelectedItem = "Duck function" Then
            skill.Text = "Function"
            skillt.Text = "Cause 70|sin(x°)| damage, x=enemy life. (Absolute damage)"
            content.Text = "This skill needs both short time to charge or cool down. The damage ups to enemy life: 90 or 270, 450... can cause full damage. Exact full damage will become critical."
            Form7.magic_type = 4
            manacost.Visible = False
        ElseIf ListBox1.SelectedItem = "Fireball" Then
            skill.Text = "Fireball"
            skillt.Text = "Cause 100 damage and burn the enemy."
            content.Text = "This skill needs long time to charge but less time to cool down. It burns the enemy causing continuous damage, the defence can prevent the damage."
            Form7.magic_type = 5
            manacost.Visible = False
        ElseIf ListBox1.SelectedItem = "Snowflake" Then
            skill.Text = "Freeze"
            skillt.Text = "Cause 40 damage, freeze the enemy."
            content.Text = "This skill takes mana to spell. It can cause magic damage and freeze the enemy, freezed enemy can still cool down, but cannot charge or do action."
            Form7.magic_type = 6
            manacost.Visible = True
            manacost.Text = "27"
        ElseIf ListBox1.SelectedItem = "Duck function+" Then
            skill.Text = "Function"
            skillt.Text = "Cause 120|cos(x°)| damage, x=enemy life. (Absolute damage)"
            content.Text = "This skill needs both short time to charge or cool down. The damage ups to enemy life: 0 or 180, 360... can cause full damage. Exact full damage will become critical."
            Form7.magic_type = 7
            manacost.Visible = True
            manacost.Text = "24"
        ElseIf ListBox1.SelectedItem = "Curative box" Then
            skill.Text = "Cure"
            skillt.Text = "Do 66 cure."
            content.Text = "-"
            Form7.magic_type = 8
            manacost.Visible = True
            manacost.Text = "30"
        ElseIf ListBox1.SelectedItem = "HCl gun" Then
            skill.Text = "Launch"
            skillt.Text = "Cause 45 damage and corrode the enemy."
            content.Text = "The HCl gun launches to the enemy, corrodes enemy, then it'll start to lose 1 percent of life per sec. It is especially useful to strong enemy or BOSS."
            Form7.magic_type = 9
            manacost.Visible = True
            manacost.Text = "51"
        ElseIf ListBox1.SelectedItem = "Homework generator" Then
            skill.Text = "Generate"
            skillt.Text = "confuse, discombobulate, numb the enemy."
            content.Text = "It has 70% probability to confuse, 45% to discombobulate, 20% to numb the enemy. These statuses can be superposed. It also has the probability to cause no effect."
            Form7.magic_type = 10
            manacost.Visible = True
            manacost.Text = "34"
        ElseIf ListBox1.SelectedItem = "H2S ejector" Then
            skill.Text = "Eject"
            skillt.Text = "Cause 500 damage, spread high poison."
            content.Text = "The high-risk magic causes high damage, then poison both you and the enemy. Poisoned battler gets 25 damage per sec, this lasts for 25 secs."
            Form7.magic_type = 11
            manacost.Visible = True
            manacost.Text = "96"
        Else
            skill.Visible = False
            skillt.Visible = False
            content.Text = "Each magic item can enable a magic skill, in one battle you can only bring one magic power. Each magic skill has different charge time and cool down time."
            Form7.magic_type = 0
            manacost.Visible = False
        End If
        Form8.ToolTip1.SetToolTip(skill, skill.Text)
        Form8.ToolTip1.SetToolTip(skillt, skillt.Text)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Button1.Text -= 0.0155
        If Button1.Text <= 0 Then
            Timer1.Enabled = False
            Button1.Text = "To battle."
            If ListBox1.SelectedItems.Count = 0 Then
                Form7.magic.Enabled = False
                Form7.magict.Enabled = False
                Form7.magic.Text = "Magic"
                Form7.magict.Text = "Unable."
            Else
                Form7.magic.Enabled = True
                Form7.magict.Enabled = True
                Form7.magic.Text = skill.Text
                Form7.magict.Text = skillt.Text
            End If
            If Form7.battle = 8 Then
                Form1.music.settings.volume = Form1.BackgroundVolume
                Form1.music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music5.wm"
                Form7.StatusCheck.Enabled = True
                Form7.EnemyAction.Enabled = True
                Form7.assist.Tag = 0
                Form7.assist.Visible = True
                Form7.assist.Text = "Mr.Duck"
                Form7.assist1.Text = "Peck"
                Form7.assist1t.Text = "Cause 15 damage."
                Form7.assist2.Text = "Math wave"
                Form7.assist2t.Text = "Puzzle your enemy. Dispel statuses."
                Form7.assist3.Text = "Function"
                Form7.assist3t.Text = "Cause 100|cos(x°)| damage. x=your enemy's health."
                Form7.assist.Enabled = True
                Form7.BackColor = Color.MistyRose
                Form7.SetParent()
                Hide()
                Form7.Show()
            ElseIf Form7.battle = 15 Then
                Form1.music.settings.volume = 100
                Form1.music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music15.wm"
                Form7.StatusCheck.Enabled = True
                Form7.EnemyAction.Enabled = True
                Form7.BackColor = Color.MistyRose
                Form7.Mana1restore.Enabled = True
                Form7.Mana2restore.Enabled = True
                Hide()
                Form7.Show()
            ElseIf Form7.battle = 19 Then
                Form1.music.settings.volume = 100
                Form1.music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music5.wm"
                Form7.StatusCheck.Enabled = True
                Form7.EnemyAction.Enabled = True
                Form7.BackColor = Color.MistyRose
                Form7.Mana1restore.Enabled = True
                Form7.Mana2restore.Enabled = True
                Hide()
                Form7.Show()
            End If
        End If
    End Sub
End Class