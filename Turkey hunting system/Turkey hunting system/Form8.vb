Public Class Form8
    Private Sub start_Click(sender As Object, e As EventArgs) Handles start.Click
        UnifiedAction()
    End Sub

    Private Sub UnifiedAction()
        Form7.boss = boss.Visible
        If Form7.battle = 8 Or Form7.battle = 15 Or Form7.battle = 19 Then
            start.Enabled = False
            Form1.music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\prelude1.wm"
            Form1.music.settings.volume = 0
            Timer1.Enabled = True
            Exit Sub
        End If
        Hide()
        Form7.tutorial.Visible = False
        If Form7.battle < 2 Then
            Form7.Show()
            Form7.pause.Enabled = True
            Form7.StatusCheck.Enabled = True
            Form7.EnemyAction.Enabled = True
        ElseIf Form7.battle = 3 Then
            Form7.Show()
            Form7.pause.Enabled = True
            Form7.spelling.Enabled = True
            Form7.StatusCheck.Enabled = True
            Form7.EnemyAction.Enabled = True
            Form7.ChangeWord()
        Else
            Form12.Show()
            Form12.initialization()
        End If
        start.Enabled = True
    End Sub

    Dim DamnUNoTip As New ToolTip

    Public Sub StupidDelay()
        DamnUNoTip.SetToolTip(skill1, skill1.Text)
        DamnUNoTip.SetToolTip(skill1t, skill1t.Text)
        DamnUNoTip.SetToolTip(skill2, skill2.Text)
        DamnUNoTip.SetToolTip(skill2t, skill2t.Text)
        DamnUNoTip.SetToolTip(skill3, skill3.Text)
        DamnUNoTip.SetToolTip(skill3t, skill3t.Text)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        Form1.music.Ctlcontrols.pause()
        Form1.music.settings.volume = 100
        Form1.music.Ctlcontrols.currentPosition = 0
        Hide()
        Form12.Show()
        Form12.initialization()
    End Sub
End Class