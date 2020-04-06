Public Class Form4
    Private choice1_code_ As Integer
    Private choice2_code_ As Integer

    Public Sub start(ByVal text_ As String, choice1 As String, choice1_code As Integer, choice2 As String, choice2_code As Integer)
        Form1.Hide()
        content.Text = text_
        Button1.Text = choice1
        Button2.Text = choice2
        choice1_code_ = choice1_code
        choice2_code_ = choice2_code
        Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Hide()
        Form1.Show()
        Form1.Choosing(choice1_code_)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Hide()
        Form1.Show()
        Form1.Choosing(choice2_code_)
    End Sub
End Class