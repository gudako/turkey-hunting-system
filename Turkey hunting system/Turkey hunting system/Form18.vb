Public Class Form18
    Public a As Integer = 6

    Public Sub RefreshAll()
        GroupBox1.Visible = False
        GroupBox1.Location = New Point(0, 0)
        GroupBox1.Size = New Size(Width, Height)
        ComboBox1.SelectedIndex = - 1
        ComboBox2.SelectedIndex = - 1
        DomainUpDown1.Text = "0"
        DomainUpDown2.Text = "0"
        DomainUpDown1.SelectedIndex = 8
        DomainUpDown2.SelectedIndex = 8
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Hide()
        Form1.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If a = 6 Then
            Hide()
            Form1.Show()
            Form1.AddTip("You even don't know the value of ""a"", how can you solve the function?")
        Else
            Dim solved = False
            If _
                a = - 2 And ComboBox1.SelectedIndex = 1 And DomainUpDown1.Text = "-1" And ComboBox2.SelectedIndex = 0 And
                DomainUpDown2.Text = "+∞" Then solved = True
            If _
                a = - 1 And ComboBox1.SelectedIndex = 0 And DomainUpDown1.Text = "-∞" And ComboBox2.SelectedIndex = 1 And
                DomainUpDown2.Text = "-3" Then solved = True
            If _
                a = 0 And ComboBox1.SelectedIndex = 1 And DomainUpDown1.Text = "1" And ComboBox2.SelectedIndex = 1 And
                DomainUpDown2.Text = "1" Then solved = True
            If _
                a = 1 And ComboBox1.SelectedIndex = 1 And DomainUpDown1.Text = "-1.5" And ComboBox2.SelectedIndex = 1 And
                DomainUpDown2.Text = "0" Then solved = True
            solved = true
            If solved Then
                Hide()
                Form1.Show()
                Form1.RemoveOut(Form1.lock66_2)
                Form1.items.Items.Remove("constant a")
                Form1.RefreshItems()
                Form1.AddTip("[THIS QUESTION IS BYPASSED DUE TO DEBUG REASON] You're right. The door is unlocked.")
                If Not Form1.mute.Checked Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound48.wm")
            Else
                Hide()
                Form1.Show()
                Form1.AddTip("The answer entered is incorrect.")
            End If
        End If
    End Sub

    Private Sub DomainUpDown1_SelectedItemChanged(sender As Object, e As EventArgs) _
        Handles DomainUpDown1.SelectedItemChanged
    End Sub
End Class