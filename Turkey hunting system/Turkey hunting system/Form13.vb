Public Class Form13
    Public potionbox As GroupBox() = {Nothing, Nothing, Nothing}
    Public potion As PictureBox() = {Nothing, Nothing, Nothing}
    Public price As Label() = {Nothing, Nothing, Nothing}
    Public ItemsList As ListView = New ListView
    Public table As Label() = {Nothing, Nothing, Nothing}

    Private Sub Form13_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        potionbox(0) = potionbox1
        potionbox(1) = potionbox2
        potionbox(2) = potionbox3
        potion(0) = potion1
        potion(1) = potion2
        potion(2) = potion3
        price(0) = price1
        price(1) = price2
        price(2) = price3
        table(0) = table1
        table(1) = table2
        table(2) = table3
    End Sub

    Public Sub RefreshAll()
        For i = 0 To 2
            If ItemsList.Items.Count >= i + 1 Then
                With ItemsList.Items(i)
                    potionbox(i).Visible = True
                    potionbox(i).Text = .SubItems(0).Text
                    potion(i).Image =
                        Image.FromFile(
                            My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\potion" &
                            .SubItems(1).Text & ".wm")
                    price(i).Tag = .SubItems(2).Text
                    price(i).Text = AddDot(.SubItems(2).Text)
                    table(i).Text = "solar corona coin" & CheckS(.SubItems(2).Text)
                End With
            Else
                potionbox(i).Visible = False
            End If
        Next
        If potionbox(0).Visible Then
            sold.Visible = False
        Else
            sold.Visible = True
        End If
        Label11.Text = "Your solar corona coin" & CheckS(coins.Tag) & ":"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        UnifiedAction()
    End Sub

    Private Sub UnifiedAction()
        If Form1.picturebox2.Tag = 16 Then
            MsgBox("Buy that 0 price thing first.", 0, "For Free!")
        Else
            If Form1.picturebox2.Tag = 17 Then
                Form1.picturebox2.Tag = 18
                MsgBox(
                    "There is a safe in toilet of floor2, we can have a look, probably there'll be solar coins near it.",
                    0, "Go to toilet")
            End If
            Hide()
            Form1.Show()
        End If
    End Sub

    Private Sub purchase1_Click(sender As Object, e As EventArgs) Handles purchase1.Click
        purchase(0)
    End Sub

    Private Sub purchase2_Click(sender As Object, e As EventArgs) Handles purchase2.Click
        purchase(1)
    End Sub

    Private Sub purchase3_Click(sender As Object, e As EventArgs) Handles purchase3.Click
        purchase(2)
    End Sub

    Public Sub SetCoins(target As Integer)
        coins.Tag = target
        coins.Text = AddDot(target)
        Label11.Text = "Your solar corona coin" & CheckS(target) & ":"
    End Sub

    Private Function AddDot(number As Integer)
        Dim number_ = ""
        If number.ToString.Length >= 3 Then
            For i = 0 To number.ToString.Length/3 - 1
                If i = 0 Then
                    number_ = number.ToString.Substring(number.ToString.Length - 3*(i + 1), 3)
                Else
                    number_ = number.ToString.Substring(number.ToString.Length - 3*(i + 1), 3) & "," & number_
                End If
            Next
        End If
        If number.ToString.Length Mod 3 = 0 Then
            Return number_
        Else
            If number.ToString.Length > 3 Then
                Return Strings.Left(number.ToString, number.ToString.Length Mod 3) & "," & number_
            Else
                Return Strings.Left(number.ToString, number.ToString.Length)
            End If
        End If
    End Function


    Friend Function CheckS(number As Integer)
        If number > 1 Then
            Return "s"
        Else
            Return ""
        End If
    End Function

    Private Sub purchase(code As Integer)
        If _
            MsgBox(
                "Do you want to buy """ & potionbox(code).Text & """ for " & price(code).Text & " solar coin" &
                CheckS(price(code).Text) & "?", vbYesNo, "Confirm") = vbYes Then
            If coins.Tag < price(code).Tag Then
                MsgBox(
                    "Insufficient corona coin." & vbCrLf & "You need another " &
                    AddDot(Int(price(code).Tag) - Int(coins.Tag)) & " corona coin" &
                    CheckS(AddDot(Int(price(code).Tag) - Int(coins.Tag))) & ".", 0, "You need more")
            Else
                SetCoins(coins.Tag - price(code).Tag)
                If Form1.mute.Checked = False Then _
                    My.Computer.Audio.Play(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound42.wm")
                If potionbox(code).Text = "Sulphuric acid (0%)" Then
                    Form1.picturebox2.Tag = 17
                    MsgBox("0% sulphuric acid! It Is Water! What the ghost... there's no use to buy.", 0, "0%!")
                ElseIf potionbox(code).Text = "Nitric acid" Then
                    MsgBox("You successfully bought the Nitric acid.", 0, "Purchase")
                    Form1.items.Items.Add("Nitric acid")
                ElseIf potionbox(code).Text = "Copper powder" Then
                    MsgBox("You successfully bought the Copper powder.", 0, "Purchase")
                    If Form1.mute.Checked = False Then _
                        My.Computer.Audio.Play(
                            My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound46.wm")
                    MsgBox("A problem happened to the vendor machine!", 0, "Machine problem")
                    If Form1.mute.Checked = False Then _
                        My.Computer.Audio.Play(
                            My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\sound42.wm")
                    MsgBox("The Caesium dropped out the machine! You got the Caesium.", 0, "Machine problem")
                    DeleteThing("Caesium")
                    Form1.items.Items.Add("Caesium")
                ElseIf potionbox(code).Text = "Sodium" Then
                    Form1.items.Items.Add("Sodium")
                End If
                DeleteThing(potionbox(code).Text)
                RefreshAll()
            End If
        End If
    End Sub

    Public Sub AddThing(thing As String, imagecode As Integer, price As Integer)
        Dim NewItem = New ListViewItem
        With NewItem
            .SubItems(0).Text = thing
            .SubItems.Add(imagecode)
            .SubItems.Add(price)
        End With
        ItemsList.Items.Add(NewItem)
    End Sub

    Public Sub DeleteThing(thing As String)
        For i = 0 To ItemsList.Items.Count - 1
            If ItemsList.Items(i).SubItems(0).Text = thing Then
                ItemsList.Items.Remove(ItemsList.Items(i))
                Exit For
            End If
        Next
    End Sub
End Class