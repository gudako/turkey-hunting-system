Public Class Form10
    Private code As Integer

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        UnifiedAction()
    End Sub

    Private Sub UnifiedAction()
        Hide()
        If Form1.NoMoreForm1 Then Form20.Show() Else Form1.Show()
        If Form1.NoMoreForm1 Then Form20.AfterBattle(code) Else Form1.AfterBattle(code)
        If Form1.physical_power.Visible Then
            Form1.power.Tag = 0
            Form1.power.Value = 0
            Form1.refreshPowerText()
        End If
    End Sub

    Public Sub start(code_ As Integer, text_ As String)
        code = code_
        content.Text = text_
        revive.Text = "Revive(" & Form1.revive & ")"
        If Form1.revive >= 1 Then
            revive.Enabled = True
            revive.ForeColor = Color.Red
            Button1.ForeColor = Color.Gray
            If Form7.battle = 5 Or Form7.battle = 14 Or Form7.battle = 23 Then
                revive.ForeColor = Color.Gray
                Button1.ForeColor = Color.Green
            End If
        Else
            revive.Enabled = False
            revive.ForeColor = Color.Black
            Button1.ForeColor = Color.Black
        End If
    End Sub

    Private Sub revive_Click(sender As Object, e As EventArgs) Handles revive.Click
        MsgBox("测试版没有复活功能")
        Exit Sub
        If Form7.battle = 5 Or Form7.battle = 14 Or Form7.battle = 23 Then
            MsgBox("You need not to revive.")
            Exit Sub
        End If
        Hide()
        Form7.Show()
        Form1.revive -= 1
        Form7.initialization(Form7.defend_type, Form7.attack_type, Form7.magic_type, Form7.life2b.Tag, Form7.life1b.Tag,
                             Form7.battle)
        Form1.music.settings.volume = 100
        If Form7.battle < 8 Then
            Form1.music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music7.wm"
        ElseIf Form7.battle = 8 Then
            Form1.music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music10.wm"
        ElseIf Form7.battle > 8 Then
            Form1.music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music8.wm"
        End If
    End Sub
End Class