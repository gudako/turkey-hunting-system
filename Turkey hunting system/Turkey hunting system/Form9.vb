Public Class Form9
    Private code As Integer

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        UnifiedAction()
    End Sub

    Private Sub UnifiedAction()
        Hide()
        If Form1.NoMoreForm1 Then Form20.Show() Else Form1.Show()
        If Form1.NoMoreForm1 Then Form20.AfterBattle(code) Else Form1.AfterBattle(code)
    End Sub

    Public Sub start(ByVal code_ As Integer, text_ As String)
        code = code_
        content.Text = text_
    End Sub
End Class