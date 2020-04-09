Public Class Form14
    Private ReadOnly AnswerBox As ListBox = New ListBox

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Clear()
        Hide()
        Form1.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text = "密码" Or TextBox1.Text = "Password" Or TextBox1.Text = "password" Then
            If Form1.picturebox2.Tag = 18 Then
                Form1.picturebox2.Tag = 19
                MsgBox("You're so smart.", 0, "Good Job")
                Form13.SetCoins(Form13.coins.Tag + 999)
                MsgBox("You've opened the safe and get 999 solar coins in it!", 0, "Solar coins")
                TextBox1.Clear()
                Hide()
                Form1.Show()
                MsgBox("Now we can ask the big smelly milk cow for 1 solar coin. He is in biology lab.", 0,
                       "How to do the next step")
            End If
        ElseIf TextBox1.Text = "" Then
            MsgBox("The password is empty.", 48, "Empty")
        Else
            MsgBox("The password entered is incorrect.", 48, "Incorrect")
            TextBox1.Clear()
        End If
    End Sub

    Public Sub ClearAll()
        ComboBox1.SelectedIndex = - 1
        ComboBox2.SelectedIndex = - 1
        ComboBox3.SelectedIndex = - 1
        RefreshAnswers()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedIndex = 0 Then ComboBox1.SelectedIndex = - 1
        If ComboBox1.SelectedIndex = ComboBox2.SelectedIndex Or ComboBox1.SelectedIndex = ComboBox3.SelectedIndex Then _
            ComboBox1.SelectedIndex = - 1
        If ComboBox1.SelectedIndex = - 1 Then
            Label4.ForeColor = Color.Black
            ComboBox1.ForeColor = Color.Black
        Else
            Label4.ForeColor = Color.Blue
            ComboBox1.ForeColor = Color.Blue
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.SelectedIndex = 0 Then ComboBox2.SelectedIndex = - 1
        If ComboBox2.SelectedIndex = ComboBox1.SelectedIndex Or ComboBox2.SelectedIndex = ComboBox3.SelectedIndex Then _
            ComboBox2.SelectedIndex = - 1
        If ComboBox2.SelectedIndex = - 1 Then
            Label5.ForeColor = Color.Black
            ComboBox2.ForeColor = Color.Black
        Else
            Label5.ForeColor = Color.Blue
            ComboBox2.ForeColor = Color.Blue
        End If
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        If ComboBox3.SelectedIndex = 0 Then ComboBox3.SelectedIndex = - 1
        If ComboBox3.SelectedIndex = ComboBox1.SelectedIndex Or ComboBox3.SelectedIndex = ComboBox2.SelectedIndex Then _
            ComboBox3.SelectedIndex = - 1
        If ComboBox3.SelectedIndex = - 1 Then
            Label6.ForeColor = Color.Black
            ComboBox3.ForeColor = Color.Black
        Else
            Label6.ForeColor = Color.Blue
            ComboBox3.ForeColor = Color.Blue
        End If
    End Sub

    Private Sub RefreshAnswers()
        Dim MirrorCombobox = New ComboBox
        For i = 0 To AnswerBox.Items.Count - 1
            MirrorCombobox.Items.Add(AnswerBox.Items(i))
        Next
        ComboBox1.Items.Clear()
        ComboBox2.Items.Clear()
        ComboBox3.Items.Clear()
        For i = 0 To MirrorCombobox.Items.Count - 1
            ComboBox1.Items.Add(MirrorCombobox.Items(i))
            ComboBox2.Items.Add(MirrorCombobox.Items(i))
            ComboBox3.Items.Add(MirrorCombobox.Items(i))
        Next
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Hide()
        Form1.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Form1.picturebox2.Tag = 34 Then
            If _
                ComboBox1.SelectedItem = "I'm wrong." And ComboBox2.SelectedItem = "I certainly will correct it." And
                ComboBox3.SelectedItem = "Don't be angry." Then
                Form1.picturebox2.Tag = 35
                MsgBox("All right.", 64, "Passed")
                Form1.items.Items.Add("Turkey key")
                Form1.magics.Items.Add("Snowflake")
                MsgBox(
                    "You get two items:" & vbCrLf & "1. Snowflake magic." & vbCrLf &
                    "2. The key to turkey catching association.", 0, "New items")
                Hide()
                Form11.start(30, "Snowflake magic", "This mana-required magic helps you a lot.", "Next")
            Else
                MsgBox("ANSWER IS 1. I'm wrong. 2. I certainly will correct it. 3. Don't be angry.", 48, "Incorrect")
                ClearAll()
            End If
        End If
    End Sub

    Private Sub Form14_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AnswerBox.Items.Clear()
        AnswerBox.Items.Add("Null")
        AnswerBox.Items.Add("I'm wrong.")
        AnswerBox.Items.Add("I feel sorry.")
        AnswerBox.Items.Add("Don't be angry.")
        AnswerBox.Items.Add("Please forgive me.")
        AnswerBox.Items.Add("I certainly will correct it.")
        AnswerBox.Items.Add("Next time I surely will correct.")
        AnswerBox.Items.Add("I'll never make the fault again.")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If Button5.Text = "Rush!" Then
            If Form1.OnFire Then
                Form1.fire.Enabled = False
                Form1.firecost.Enabled = False
            Else
                Form1.Unlocked.Items.Add("without fire")
            End If
            Form1.music.Ctlcontrols.stop()
            Label11.BackColor = Color.Transparent
            Label11.Parent = PictureBox1
            Button5.Text = "Charge"
            Label11.Visible = True
            PictureBox1.Visible = True
            ProgressBar1.Visible = True
            Timer1.Enabled = True
            Label11.Top = 0
            Label11.Left = 0
        ElseIf Button5.Text = "Charge" Then
            If ProgressBar1.Value + 500 > ProgressBar1.Maximum Then
                Timer1.Enabled = False
                ProgressBar1.Value = ProgressBar1.Maximum
                Button5.Text = "Complete"
                Label12.Text = "100%"
            Else
                ProgressBar1.Value += 500
            End If
        ElseIf button5.text = "Complete" Then
            If MsgBox("Complete the Time Travel?", vbExclamation + vbYesNo + vbDefaultButton2, "Next part") = vbYes Then
                Hide()
                Form1.Show()
                Form1.SetHeight(479, - 1)
                Form1.GroupBox1.Visible = False
                Form1.life.Visible = False
                Form1.lifetext.Visible = False
                Form1.Button6.Visible = False
                Form1.Button7.Visible = False
                Form1.Button8.Visible = False
                Form1.picturebox2.Visible = False
                Form1.PictureBox3.Visible = True
                Form1.PictureBox3.Tag = 0
                Form1.SetParent1()
                Form1.Scene001appears()
                Form1.music.settings.setMode("loop", True)
                Form1.music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music14.wm"
                Form1.music.Ctlcontrols.play()
                Form1.topic.Text = "Chapter3"
                Form1.topic.Visible = True
                Form1.topic.Width = Form1.PictureBox3.Width
                Form1.DifTip.Visible = True
                Form1.RemoveTitle.Enabled = True
                Form1.SaveGame("Chapter3", "Ancient world", 4, False)
            End If
        Else
            Hide()
            Form1.Show()
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Label13.Tag += 1
        If Label13.Tag = 1 Then
            Label13.Text =
                "The fire is always spreading rapidly. If one place is on fire, it will spread fire to ambient places. If one place's fire is too strong, it'll get destroyed. If this destroyed place is required, or you're in that place, you get failed."
        ElseIf Label13.Tag = 2 Then
            Label13.Text =
                "The fire causes damage all the time, stronger fire causes higher damage. If your life turns to 0, you get failed. However, you can use the heal potion and revival potion to deal your life."
        ElseIf Label13.Tag = 3 Then
            Button6.Text = "Escape!"
            Label13.Text =
                "This time you need not to mind your physical power anymore. The only thing you required is to escape: the faster the better."
            Form1.ChangeMusic.Enabled = False
            Form1.music.settings.volume = 100
            Form1.music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music13.wm"
        ElseIf Label13.Tag = 4 Then
            Hide()
            Form1.Show()
            Form1.SetHeight(750, - 1)
            Form1.OnFire = True
            Form1.life.Maximum = 300 + Form1.shield_level*150
            Form1.life.Value = Form1.life.Maximum
            Form1.lifetext.Text = Form1.life.Value & "/" & Form1.life.Maximum
            Form1.fire.Enabled = True
            Form1.firecost.Enabled = True
            Form1.physical_power.Visible = False
            Form1.Scene17Appears()
            Form1.picturebox2.Tag = 40
            Form1.FireInit()
            GroupBox3.Visible = False
        Else
            GroupBox3.Visible = False
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If ProgressBar1.Value > 20 Then
            ProgressBar1.Value -= 20
        Else
            ProgressBar1.Value = 0
        End If
    End Sub
End Class