Public Class Form15
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If PictureBox1.Tag = 5 Then
            If Form1.picturebox2.Tag = 25 Then
                Form1.lock10_2.Tag = 0
                Form1.lock10_2.Visible = False
                MsgBox("You find the floor4's key inside the book.", 0, "Key")
                Form1.ChangeMusic.Interval = 81000
                Form1.ChangeMusic.Enabled = True
                Form1.music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music11.wm"
            End If
            Hide()
            Form1.Show()
            If Form1.picturebox2.Tag = 25 Then
                Form1.picturebox2.Tag = 26
                MsgBox("What a mystery!", 0, "Mystery")
                MsgBox("Nobody know what happened between them... But the chaos has been formed in silence.", 0, "Mystery")
            End If
        ElseIf PictureBox1.Tag = 12 Then
            If Form1.picturebox2.Tag = 30 Then
                Form1.ChangeMusic.Interval = 81000
                Form1.ChangeMusic.Enabled = True
                Form1.music.settings.volume = Form1.BackgroundVolume
                Form1.music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music11.wm"
            End If
            Hide()
            Form1.Show()
            If Form1.picturebox2.Tag = 30 Then
                Form1.picturebox2.Tag = 31
                MsgBox("The witch is quite harmful. All these chaos are formed by the witch. She is the real mastermind behind all of these.", 0, "Mystery")
                My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound31.wm")
                MsgBox("Mr.Duck's class ends.", 0, "Class is over")
                MsgBox("The next class is general technology. The classroom is on floor4, beyond the biology lab.", 0, "Next class")
                MsgBox("The teacher surely will turn on the light of floor4, then we can go up.", 0, "The light")
            End If
        ElseIf PictureBox1.Tag = 17 Then
            If Form1.picturebox2.Tag = 37 Then
                Form1.items.Items.Add("Psychology key")
                MsgBox("You get the key to psychology room from the book.", 0, "Key")
                Form1.ChangeMusic.Interval = 81000
                Form1.ChangeMusic.Enabled = True
                Form1.music.settings.volume = Form1.BackgroundVolume
                Form1.music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music11.wm"
            End If
            Hide()
            Form1.Show()
            If Form1.picturebox2.Tag = 37 Then
                Form1.picturebox2.Tag = 38
                MsgBox("The reality cannot be changed anymore. Their tragedy is doomed. Except going to the past, or things're impossible.", 0, "Their Doom")
            End If
        ElseIf PictureBox1.Tag = 19 Then
            Hide()
            Form1.Show()
            If Form1.Unlocked.Items.Contains("recipe") Then
                Form1.AddTip("Follow these steps to make the artifact then Atropos can be defeated.")
            Else
                Form1.Unlocked.Items.Add("recipe")
                Form1.AddTip("Follow these steps to make the artifact then Atropos can be defeated.", True)
            End If
        ElseIf PictureBox1.Tag = 20 Then
            Hide()
            Form1.Show()
            If Form1.Unlocked.Items.Contains("solar recipe") = False Then
                Form1.Unlocked.Items.Add("solar recipe")
                Form1.GainItem(Form1.paper46_4, "orange key")
                Form1.AddTip("You get the key to chemistry lab compartment.")
            End If
        ElseIf PictureBox1.Tag = 21 Or PictureBox1.Tag = 22 Or PictureBox1.Tag = 23 Or PictureBox1.Tag = 24 Then
            Hide()
            Form1.Show()
        Else
            If Form1.mute.Checked = False Then My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound40.wm")
            ChangeImage(PictureBox1.Tag + 1)
        End If
    End Sub

    Public Sub ChangeImage(ByVal code As Integer)
        PictureBox1.Tag = code
        PictureBox1.BackColor = Color.Transparent
        PictureBox1.Image = Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\intro" & code & ".wm")
        If Form1.mute.Checked = False And code < 18 Then My.Computer.Audio.Play(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\voice" & code & ".wm")
    End Sub
End Class