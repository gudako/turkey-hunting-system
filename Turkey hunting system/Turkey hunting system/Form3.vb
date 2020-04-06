Public Class Form3

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Tag -= 1
        Button1.Text = "End.(" & Timer1.Tag & ")"
        If Timer1.Tag = 0 Then
            Form1.epilogue = True
            Timer1.Enabled = False
            End
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.epilogue = True
        Timer1.Enabled = False
        End
    End Sub
End Class