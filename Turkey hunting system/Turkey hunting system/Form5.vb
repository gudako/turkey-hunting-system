Public Class Form5
    Private code_ As Integer
    Public Sub start(ByVal code As Integer, ByVal text_ As String, ByVal time As Integer)
        Form1.Hide()
        content.Text = text_
        bar.Value = 0
        bar.Maximum = time * 100
        Timer1.Enabled = True
        code_ = code
        Show()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        bar.Value += 100
        If bar.Value = bar.Maximum Then
            Timer1.Enabled = False
            Hide()
            Form1.Show()
            Form1.TimeDone(code_)
        End If
    End Sub
End Class