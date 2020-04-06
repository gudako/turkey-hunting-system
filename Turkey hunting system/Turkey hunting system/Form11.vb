Public Class Form11
    Private code As Integer
    Public try_to_avoid As Boolean = False
    Private BombBlow As Integer = 0
    Private Question As Integer = 0
    Public Sub start(picture_index As Integer, title_ As String, content_ As String, choice1 As String, Optional choice2 As String = "", Optional choice3 As String = "")
        Form1.Hide()
        Show()
        code = picture_index
        PictureBox1.Image = Images.Images(picture_index)
        title.Text = title_
        content.Text = content_
        If choice1 = "" Then
            Button1.Visible = False
        Else
            Button1.Visible = True
            Button1.Text = choice1
        End If
        If choice2 = "" Then
            Button2.Visible = False
        Else
            Button2.Visible = True
            Button2.Text = choice2
        End If
        If choice3 = "" Then
            Button3.Visible = False
        Else
            Button3.Visible = True
            Button3.Text = choice3
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If code = 0 Then
            Hide()
            Form1.Show()
        ElseIf code = 1 Then
            Hide()
            Form1.Show()
            Form1.six_god = True
        ElseIf code = 2 Then
            code = 3
            PictureBox1.Image = Images.Images(3)
            Form1.weapon_level = 1
            title.Text = "New weapon!"
            content.Text = "You get a big rabbit rock! You can use it as weapon in next battle."
            Button1.Text = "That's good."
        ElseIf code = 6 Then
            Hide()
            Form1.Show()
            Form1.place4_3.Tag = 1
            Form1.picturebox1.Tag = 6
            Form1.place4_3.Visible = True
        ElseIf code = 7 Or code = 8 Or code = 23 Then
            Hide()
            Form1.Show()
        ElseIf code = 10 Then
            MsgBox("It was because that many students didn't submit homework which made the English teacher angry, so she set the corona ball to compel students doing the homework.", 48, "The corona ball")
            Hide()
            Form7.Show()
            Form7.initialization(Form1.shield_level, Form1.weapon_level, 0, 300 + Form1.shield_level * 150, 270, 3)
            Form1.music.settings.volume = 100
            Form1.music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music7.wm"
        ElseIf code = 12 Then
            Hide()
            Form1.Show()
            Form1.physical_power.Visible = True
            Form1.Restore.Enabled = True
        ElseIf code = 13 Then
            Hide()
            Form7.Show()
            Form7.initialization(Form1.shield_level, Form1.weapon_level, 0, 300 + Form1.shield_level * 150, 440, 4)
            Form1.music.settings.setMode("loop", True)
            Form1.music.settings.volume = 100
            Form1.music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music7.wm"
        ElseIf code = 14 Then
            Hide()
            Form7.Show()
            Form7.initialization(Form1.shield_level, Form1.weapon_level, 0, 300 + Form1.shield_level * 150, 160, 5)
            Form1.music.settings.setMode("loop", True)
            Form1.music.settings.volume = 100
            Form1.music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music7.wm"
        ElseIf code = 9 Then
            Hide()
            Form1.weapon_level = 2
        ElseIf code = 15 Then
            MsgBox("No. You have no power to struggle.")
            Hide()
            Form1.Show()
            MsgBox("This time you have no way to escape.")
            MsgBox("However...")
            If Form1.mute.Checked = False Then My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound28.wm")
            MsgBox("What's the sound??")
            Form6.start("It is Mr.Duck!", 15)
        ElseIf code = 16 Then
            Hide()
            Form7.Show()
            Form7.initialization(Form1.shield_level, Form1.weapon_level, 0, 300 + Form1.shield_level * 150, 160, 6)
            Form1.music.settings.setMode("loop", True)
            Form1.music.settings.volume = 100
            Form1.music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music7.wm"
        ElseIf code = 17 Then
            code = -1
            PictureBox1.Image = Images.Images(15)
            content.Text = "It is the ""Turkfish""! It's mixed organism! It's dangerous! Destroy it!"
            Button1.Text = "Fight→"
        ElseIf code = -1 Then
            Hide()
            Form7.Show()
            Form7.initialization(Form1.shield_level, Form1.weapon_level, 0, 300 + Form1.shield_level * 150, 270, 7)
            Form1.music.settings.setMode("loop", True)
            Form1.music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music7.wm"
        ElseIf code = 18 Then
            code = -2
            content.Text = "Turkfish Lord:" & vbCrLf & "Destroy you! For our master!"
            Button1.Text = "Master??"
        ElseIf code = -2 Then
            code = -3
            content.Text = "Turkfish Lord:" & vbCrLf & "Our master created our species! For our master, slay you!"
            Button1.Text = "What's the reason??"
        ElseIf code = -3 Then
            code = -4
            content.Text = "Turkfish Lord:" & vbCrLf & "Because you'll expose the secret of our biologic creation!!"
            Button1.Text = "→"
        ElseIf code = -4 Then
            code = -5
            content.Text = "Turkfish Lord:" & vbCrLf & "Go to die!!"
            Button1.Text = "→"
        ElseIf code = -5 Then
            Hide()
            Form7.Show()
            Form7.initialization(Form1.shield_level, Form1.weapon_level, 0, 300 + Form1.shield_level * 150, 1000, 8)
            Form1.music.settings.setMode("loop", True)
            Form1.music.settings.volume = 100
            Form1.music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music10.wm"
        ElseIf code = 20 Then
            BombBlow = Math.Max(0, (BombBlow - 1) / 2)
            Hide()
            Form1.Show()
        ElseIf code = 21 Then
            Hide()
            Form1.Show()
            MsgBox("Chairman:" & vbCrLf & "Please be fast.", 0, "Chairman")
            Form1.picturebox2.Tag = 9
        ElseIf code = -6 Then
            If Question = 1 Then
                MsgBox("Chairman:" & vbCrLf & "[...] chooses C, sorry, it's wrong. It gains no point." & vbCrLf & "We cannot eat a hen on that day.", 0, "No")
            ElseIf Question = 2 Then
                MsgBox("Chairman:" & vbCrLf & "[...] chooses C, sorry, it's wrong. It gains no point." & vbCrLf & "The big smelly milk cow and turkey can breed a TurkCow.", 0, "No")
            ElseIf Question = 3 Then
                MsgBox("Chairman:" & vbCrLf & "[...] chooses C, sorry, it's wrong. It gains no point." & vbCrLf & "Only sky shit turkey likes eating shit.", 0, "No")
            ElseIf Question = 4 Then
                MsgBox("Chairman:" & vbCrLf & "[...] chooses C, correct! It gains 20 points.", 0, "Yes")
                match.Text += 20
            ElseIf Question = 5 Then
                If Form1.destroy_nest Then
                    MsgBox("Chairman:" & vbCrLf & "[...] chooses C, correct! It gains 20 points.", 0, "Yes")
                    match.Text += 20
                Else
                    MsgBox("Chairman:" & vbCrLf & "[...] chooses C, sorry, it's wrong. It gains no point." & vbCrLf & "The turkey surely has a nest.", 0, "No")
                End If
            ElseIf Question = 6 Then
                MsgBox("Chairman:" & vbCrLf & "[...] chooses C, sorry, it's wrong. It gains no point." & vbCrLf & "Turkey's psychology is differ from human's.", 0, "No")
            End If
            ToQuestion(Question + 1)
        ElseIf code = 22 Then
            Hide()
            Form6.start("Big cow:" & vbCrLf & "Just now while I was giving milk, something bit me continuously. Then I looked like now.", 21)
        ElseIf code = -7 Then
            If microscope.Value >= 90 Then
                code = -8
                microtime.Enabled = False
                MsgBox("Completed!")
                microscope.Visible = False
                PictureBox1.Image = Images.Images(24)
                content.Text = "There're massive turkey eater worm eggs! They're small but still visible! It's the turkey eater worm bit our cow!"
                Button1.Text = "Oh!"
            Else
                MsgBox("It's unqualified. Try again.")
            End If
        ElseIf code = -8 Then
            code = -9
            If Form1.mute.Checked = False Then My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound36.wm")
            PictureBox1.Image = Images.Images(25)
            title.Text = "The Witch!"
            content.Text = "The witch:" & vbCrLf & "Hahahahahahahahaha! You even exposed my secret!"
        ElseIf code = -9 Then
            MsgBox("The witch disappeared at once.")
            If Form1.witch_book Then MsgBox("What the hell of the witch?? We have the witch's book, but can not understand its content at all.", 0, "Mystery")
            MsgBox("Though we do not know the truth, but the foremost thing is to catch the turkey.")
            Hide()
            Form1.Show()
            MsgBox("We've saved the cow, now we can go outside and catch the turkey. It's still near the lecture hall.", 0, "Resume hunting the turkey.")
        ElseIf code = 31 Then
            If Button1.Text = "Then" Then
                Hide()
                Form7.Show()
                Form7.initialization(Form1.shield_level, Form1.weapon_level, 0, 300 + Form1.shield_level * 150, 470, 12)
                Form1.music.settings.setMode("loop", True)
                Form1.music.settings.volume = 100
                Form1.music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music7.wm"
            Else
                Button1.Text = "Then"
                content.Text = "The robot:" & vbCrLf & "For honour! For the lunch! Catch the lunch invader!"
            End If
        ElseIf code = 33 Then
            If Rnd() < 0.2 Then
                MsgBox("You waked up yourself and...", 0, "Next")
                If Form1.mute.Checked = False Then My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound32.wm")
                MsgBox("You heard something exploded." & vbCrLf & "When you moved back your head, you saw the school building was on fire!", 0, "Fire")
                Hide()
                Form14.Show()
                Form14.GroupBox3.Visible = True
                Form14.GroupBox3.BringToFront()
            Else
                MsgBox("You failed. You're still in stun mode. Try again.", 0, "Try again")
            End If
        Else
            Hide()
            Form1.Show()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If code = 0 Then
            Hide()
            Form5.start(8, "Spreading Six God in toilet...", 6)
        ElseIf code = 4 Then
            Hide()
            Form1.Show()
            Form1.witch_book = True
            Form6.start("You picked up the book, nothing happened.", -1)
        ElseIf code = 6 Then
            Hide()
            Form1.Show()
            Form1.picturebox1.Tag = 9
        ElseIf code = 13 Then
            try_to_avoid = True
            MsgBox("The murloc is so insane: You can hardly avoid." & vbCrLf & "·You get 60.00 damage.", 16, "Impossible")
            Hide()
            Form7.Show()
            Form7.initialization(Form1.shield_level, Form1.weapon_level, 0, 300 + Form1.shield_level * 150, 440, 4)
            Form1.music.settings.setMode("loop", True)
            Form1.music.settings.volume = 100
            Form1.music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music7.wm"
        ElseIf code = 20 Then
            If Form1.mute.Checked = False Then My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound12.wm")
            MsgBox("You kicked it.", 0, "Kick")
            BombBlow += 3
            If BombBlow >= 5 Then
                Form1.music.Dispose()
                If Form1.mute.Checked = False Then My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound32.wm")
                MsgBox("BOOM!!", 0, "")
                Hide()
                Form1.GameOver("No zuo no die.")
            End If
        ElseIf code = 21 Then
            MsgBox("Chairman:" & vbCrLf & "Now let's explain the rules. Listen carefully.", 0, "Chairman")
            MsgBox("Chairman:" & vbCrLf & "The first part of it is the required questions.", 0, "Chairman")
            MsgBox("Chairman:" & vbCrLf & "Each one of you has a score table. In this part everyone gets ten questions to answer. When you correctly answer one question, gain 20 points, wrong answer does not deduct point.", 0, "Chairman")
            MsgBox("Chairman:" & vbCrLf & "Now let us start.", 0, "Chairman")
            code = -6
            match.Visible = True
            ToQuestion(1)
            Button1.Visible = True
            Button2.Visible = True
            Button3.Visible = True
        ElseIf code = -6 Then
            If Question = 1 Then
                MsgBox("Chairman:" & vbCrLf & "[...] chooses B, sorry, it's wrong. It gains no point." & vbCrLf & "It's unreasonable to eat rooster, though it's also a type of chick.", 0, "No")
            ElseIf Question = 2 Then
                MsgBox("Chairman:" & vbCrLf & "[...] chooses B, correct! It gains 20 points.", 0, "Yes")
                match.Text += 20
            ElseIf Question = 3 Then
                MsgBox("Chairman:" & vbCrLf & "[...] chooses B, correct! It gains 20 points.", 0, "Yes")
                match.Text += 20
            ElseIf Question = 4 Then
                MsgBox("Chairman:" & vbCrLf & "[...] chooses B, sorry, it's wrong. It gains no point." & vbCrLf & "The turkey will hibernate while we're having Christmas.", 0, "No")
            ElseIf Question = 5 Then
                MsgBox("Chairman:" & vbCrLf & "[...] chooses B, sorry, it's wrong. It gains no point." & vbCrLf & "The hen has nest in class, but the turkey does not.", 0, "No")
            ElseIf Question = 6 Then
                MsgBox("Chairman:" & vbCrLf & "[...] chooses B, correct! It gains 20 points.", 0, "Yes")
                match.Text += 20
            End If
            ToQuestion(Question + 1)
        ElseIf code = 23 Then
            code = -7
            Form1.picturebox2.Tag = 13
            content.Text = "Please push down the ""Aim"" when the bar become very long."
            Button1.Text = "Aim"
            Button2.Visible = False
            microscope.Visible = True
            microtime.Enabled = True
        ElseIf code = 26 Then
            Form1.picturebox2.Tag = 23
            Form1.place07_3.Tag = 2
            If Form1.mute.Checked = False Then My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound13.wm")
            Hide()
            Form1.Show()
            Form1.items.Items.Add("Physics lab key")
            MsgBox("The worms are destroyed and being melted into liquid, but you can't go through these liquid.")
            MsgBox("You get key to physics lab from one of the worms' body.", 0, "A Key")
        ElseIf code = 29 Then
            If Form1.items.Items.Contains("Mr.Duck's plank") Then
                If MsgBox("Do you want to upgrade Duck function by using Mr.Duck's plank?", vbYesNo, "Upgrade confirm") = vbYes Then
                    If Form1.mute.Checked = False Then My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound19.wm")
                    MsgBox("Successfully upgraded!" & vbCrLf & "You get:" & vbCrLf & "The key to time machine," & vbCrLf & "The key to Amber Nest," & vbCrLf & "Duck function+.", 0, "Upgrade!")
                    Form1.items.Items.Add("Amber key")
                    Form1.items.Items.Add("Time machine key")
                    Form1.magics.Items.Remove("Duck function")
                    Form1.magics.Items.Add("Duck function+")
                    Hide()
                    Form1.Show()
                End If
            Else
                MsgBox("It needs Mr.Duck's chalk to upgrade.", 0, "Requirement")
            End If
        ElseIf code = 32 Then
            If Form1.items.Items.Contains("Duck pool water") Then
                If Form1.mute.Checked = False Then My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound19.wm")

            Else
                MsgBox("This time it needs the water in Mr.Duck's duck pool.", 0, "Requirement")
            End If
        ElseIf code = 34 Then
            If MsgBox("Are you sure?", vbYesNo, "Confirm") = vbYes Then
                If MsgBox("Are you sure??", vbYesNo, "Confirm") = vbYes Then
                    If MsgBox("Are you sure????", vbYesNo, "Confirm") = vbYes Then
                        MsgBox("You eat. You die.", 0, "Death!")
                        Hide()
                        Form1.fire.Enabled = False
                        Form1.firecost.Enabled = False
                        Form1.GameOver("cherish life, keep away from cyanides.")
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If code = 20 Then
            If Form1.mute.Checked = False Then My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound3.wm")
            MsgBox("You hit it.", 0, "Hit")
            BombBlow += 2
            If BombBlow >= 5 Then
                Form1.music.Dispose()
                If Form1.mute.Checked = False Then My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound32.wm")
                MsgBox("BOOM!!", 0, "")
                Hide()
                Form1.GameOver("No zuo no die.")
            End If
        ElseIf code = -6 Then
            If Question = 1 Then
                MsgBox("Chairman:" & vbCrLf & "[...] chooses A, correct! It gains 20 points.", 0, "Yes")
                match.Text += 20
            ElseIf Question = 2 Then
                MsgBox("Chairman:" & vbCrLf & "[...] chooses A, sorry, it's wrong. It gains no point." & vbCrLf & "Turkey can probably breed a hen.", 0, "No")
            ElseIf Question = 3 Then
                MsgBox("Chairman:" & vbCrLf & "[...] chooses A, sorry, it's wrong." & vbCrLf & "I think the attraction completely useless.", 0, "No")
                MsgBox("Chairman:" & vbCrLf & "You're too lascivious that just know beauty!", 0, "Chairman")
                MsgBox("The angry chairman deducts you 30 points.", 0, "Deduction")
                match.Text -= 30
            ElseIf Question = 4 Then
                MsgBox("Chairman:" & vbCrLf & "[...] chooses A, sorry, it's wrong. It gains no point." & vbCrLf & "You even didn't have caught it, how can you eat it at once? Impossible.", 0, "No")
            ElseIf Question = 5 Then
                If Form1.destroy_nest Then
                    MsgBox("Chairman:" & vbCrLf & "[...] chooses A, sorry, it's wrong. It gains no point." & vbCrLf & "The nest has already been destroyed.", 0, "No")
                Else
                    MsgBox("Chairman:" & vbCrLf & "[...] chooses A, correct! It gains 20 points.", 0, "Yes")
                    match.Text += 20
                End If
            ElseIf Question = 6 Then
                MsgBox("Chairman:" & vbCrLf & "[...] chooses A, sorry, it's wrong. It gains no point." & vbCrLf & "Biology helps you to research, but we need to hunt it.", 0, "No")
            End If
            ToQuestion(Question + 1)
        ElseIf code = 34 Then
            MsgBox("The cyanides are cleared.", 0, "Clear")
            Form1.place03_3.Tag = 2
            Hide()
            Form1.Show()
        End If
    End Sub

    Private Sub ToQuestion(ByVal code As Integer)
        Question = code
        If code = 1 Then
            content.Text = "1. What can we eat on Thanksgiving day?"
            Button3.Text = "A. Turkey."
            Button2.Text = "B. Rooster."
            Button1.Text = "C. Big white hen."
        ElseIf code = 2 Then
            content.Text = "2. Which of the followings cannot be bred by turkey and another animal?"
            Button3.Text = "A. Hen."
            Button2.Text = "B. Murloc."
            Button1.Text = "C. TurkCow."
        ElseIf code = 3 Then
            content.Text = "3. What is turkey's favourite?"
            Button3.Text = "A. Beauty."
            Button2.Text = "B. Laying egg."
            Button1.Text = "C. Eating shit."
        ElseIf code = 4 Then
            content.Text = "4. When can we eat turkey?"
            Button3.Text = "A. Now."
            Button2.Text = "B. On Christmas."
            Button1.Text = "C. 2016.11 physical."
        ElseIf code = 5 Then
            content.Text = "5. Where is the turkey's nest?"
            Button3.Text = "A. In toilet."
            Button2.Text = "B. In class 6."
            Button1.Text = "C. There is none nest."
        ElseIf code = 6 Then
            content.Text = "6. To learn how to hunt turkey, we should explore in:"
            Button3.Text = "A. Biology."
            Button2.Text = "B. Zoology."
            Button1.Text = "C. Psychology."
        ElseIf code = 7 Then
            If Form1.mute.Checked = False Then My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound33.wm")
            MsgBox("What's the sound??", 32, "Doubt")
            MsgBox("Suddenly a big worm drills out from underground!", 48, "Big worm!")
            Hide()
            Form7.Show()
            Form7.initialization(Form1.shield_level, Form1.weapon_level, 0, 300 + Form1.shield_level * 150, 500, 9)
            Form1.music.settings.setMode("loop", True)
            Form1.music.settings.volume = 100
            Form1.music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music7.wm"
            match.Visible = False
        End If
    End Sub

    Private Sub match_TextChanged(sender As Object, e As EventArgs) Handles match.TextChanged
        If match.Text >= 200 And Form1.magics.Items.Contains("Fireball") = False Then
            Form1.magics.Items.Add("Fireball")
            MsgBox("Your score has reached 200! You get the Fireball magic as bouns!", 48, "Super Job")
        End If
    End Sub

    Private Sub microtime_Tick(sender As Object, e As EventArgs) Handles microtime.Tick
        If microscope.Tag = 0 Then
            microscope.Value += 1
            If microscope.Value = microscope.Maximum Then microscope.Tag = 1
        Else
            microscope.Value -= 1
            If microscope.Value = microscope.Minimum Then microscope.Tag = 0
        End If
    End Sub
End Class