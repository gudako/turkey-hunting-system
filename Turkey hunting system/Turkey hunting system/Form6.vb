Public Class Form6
    Private code_ As Integer

    Private Sub next__Click(sender As Object, e As EventArgs) Handles next_.Click
        UnifiedAction()
    End Sub

    Private Sub UnifiedAction()
        Hide()
        Form1.Show()
        Form1.Information(code_)
    End Sub

    Public Sub start(ByVal text_ As String, code As Integer)
        Form1.Hide()
        code_ = code
        content.Text = text_
        Show()
    End Sub
End Class