Public Class Form17
    Private CurrentPath As String
    Private Enable As Boolean = True
    Public username As String = ""
    Public password As String = ""
    Public scoreurl As String = ""
    Public LockTime As Integer = 4

    Public Sub RefreshAll()
        Deselect()
        MainIcon.Image = Nothing
        MainIcon.BringToFront()
        Unconnected.Visible = False
        RefreshButton.Visible = False
        FileListView.Visible = False
        FileListView.Items.Clear()
        GroupBox1.Visible = False
        GroupBox2.Visible = False
        TextBox1.Visible = False
        PictureBox1.Visible = False
        FileListView.Location = New Point(9, 47)
        FileListView.Size = New Size(494, 358)
        GroupBox2.Location = New Point(9, 47)
        GroupBox2.Size = New Size(494, 358)
        realpath.Text = ""
        Enable = True
        exam1.Visible = False
        exam2.Visible = False
        examback.Visible = False
        exambutton1.Visible = False
        exambutton2.Visible = False
        examtext1.Visible = False
        examtext2.Visible = False
        examtip.Visible = False
        GroupBox3.Visible = False
        TextBox2.Clear()
        TextBox2.ReadOnly = False
        PictureBox2.Visible = False
        examtext1.Clear()
        examtext2.Clear()
    End Sub

    Private Sub Deselect()
        Icon1.BackColor = Color.FromArgb(64, 64, 64)
        Icon2.BackColor = Color.FromArgb(64, 64, 64)
        Icon3.BackColor = Color.FromArgb(64, 64, 64)
        icon4.BackColor = Color.FromArgb(64, 64, 64)
    End Sub

    Private Function FileItem(name_ As String)
        Dim ReturnValue As ListViewItem = Nothing
        For x = 0 To FileListView.Items.Count - 1
            If FileListView.Items(x).Text = name_ Then
                ReturnValue = FileListView.Items(x)
            End If
        Next
        Return ReturnValue
    End Function

    Private Function FileGroup(name_ As String)
        Dim ReturnValue As ListViewGroup = Nothing
        For x = 0 To FileListView.Groups.Count - 1
            If FileListView.Groups(x).Header = name_ Then
                ReturnValue = FileListView.Groups(x)
            End If
        Next
        Return ReturnValue
    End Function

    Friend Sub ToIcon1()
        If Enable = False Then Exit Sub
        RefreshAll()
        Icon1.BackColor = Color.Silver
        Hide()
        Form1.Show()
    End Sub

    Friend Sub ToIcon2()
        If Enable = False Then Exit Sub
        RefreshAll()
        Icon2.BackColor = Color.Silver
        MainIcon.Image = Programs.Images(1)
        FileListView.Items.Clear()
        If Form1.Unlocked.Items.Contains("Internet") Then
            AddItem("Enabled", "Internet", 4, "The Internet is usable.")
        Else
            AddItem("Unable", "Internet", 3, "There is no Internet connected.")
        End If
        AddItem("Local disk (C:)", "Fixed disk", 0)
        AddItem("Local disk (D:)", "Fixed disk", 1, "The disk is locked.")
        AddItem("Local disk (E:)", "Fixed disk", 1)
        If Form1.Unlocked.Items.Contains("DiskF") Then AddItem("Removable disk (F:)", "Removable disk", 2)
        FileListView.Visible = True
    End Sub

    Friend Sub ToIcon3()
        If Enable = False Then Exit Sub
        RefreshAll()
        Icon3.BackColor = Color.Silver
        MainIcon.Image = Programs.Images(0)
        If Form1.Unlocked.Items.Contains("Internet") Then
            GroupBox3.Visible = True
        Else
            Unconnected.Visible = True
            RefreshButton.Visible = True
        End If
    End Sub

    Private Sub AddItem(Name_ As String, Group_ As String, ImageIndex As Integer, Optional ToolTipText As String = "")
        Dim Prepared = New ListViewItem
        With Prepared
            .Text = Name_
            .Group = FileGroup(Group_)
            .ImageIndex = ImageIndex
            .ToolTipText = ToolTipText
        End With
        FileListView.Items.Add(Prepared)
    End Sub

    Private Sub Icon1_Click(sender As Object, e As EventArgs) Handles Icon1.Click
        Enable = True
        ToIcon1()
        If Not LockTime = 0 Then LockTime = 5
    End Sub

    Private Sub Icon2_Click(sender As Object, e As EventArgs) Handles Icon2.Click
        ToIcon2()
    End Sub

    Private Sub Icon3_Click(sender As Object, e As EventArgs) Handles Icon3.Click
        ToIcon3()
    End Sub

    Private Sub FileListView_DoubleClick(sender As Object, e As EventArgs) Handles FileListView.DoubleClick
        If Enable = False Then Exit Sub
        If FileListView.SelectedItems(0).Text = "Local disk (C:)" Then
            C1()
        ElseIf FileListView.SelectedItems(0).Text = "Local disk (D:)" Then
            If Form1.Unlocked.Items.Contains("DiskD") Then
                d1
            Else
                Enable = False
                GroupBox1.Size = New Size(375, 160)
                GroupBox1.Location = New Point((Width - GroupBox1.Width)/2, (Height - GroupBox1.Height)/2)
                password_circle.Clear()
                GroupBox1.Visible = True
                GroupBox1.BringToFront()
            End If
        ElseIf FileListView.SelectedItems(0).Text = "Local disk (E:)" Then
            E1()
        ElseIf FileListView.SelectedItems(0).Text = "Removable disk (F:)" Then
            f1()
        ElseIf CurrentPath = "C:\" And FileListView.SelectedItems(0).Text = "Program Files" Then
            C2()
        ElseIf FileListView.SelectedItems(0).Text = "..." Then
            If CurrentPath = "C:\" Or CurrentPath = "D:\" Or CurrentPath = "E:\" Or CurrentPath = "F:\" Then
                ToIcon2()
            ElseIf CurrentPath = "C:\Program Files" Then
                C1()
            ElseIf CurrentPath = "E:\Order for arrest" Then
                E1()
            End If
        ElseIf FileListView.SelectedItems(0).Text = "Windows" Then
            MsgBox("You cannot modify system files.", 0, "Windows")
        ElseIf FileListView.SelectedItems(0).Text = "TheTruth.txt" Then
            Enable = False
            GroupBox2.BringToFront()
            GroupBox2.Visible = True
            GroupBox2.Text = "E:\TheTruth.txt"
            TextBox1.Text = "Tarecgosa wrongfully became Lamouis's goddess, it was because two things." & vbCrLf &
                            "One is that she was always decorating herself with beauty and luxury, but it's not primary." &
                            vbCrLf &
                            "The most important one is a thing happened a long time ago. It hangs a long tale. once upon a time, she carelessly splashed a big bottle of hydrochloric acid on her body, she got no harm and acquired the power of fire instead, people thought her differ from mortals, so she became goddess." &
                            vbCrLf &
                            "However... disappointedly, then people found the real source, it was someone's rumour, this thing did never happen. But this time she had unremovably become their goddess." &
                            vbCrLf & vbCrLf & "Lamouis's princess, Aurora."
            TextBox1.Visible = True
        ElseIf FileListView.SelectedItems(0).Text = "image.jpg" Then
            Enable = False
            GroupBox2.BringToFront()
            GroupBox2.Visible = True
            GroupBox2.Text = "E:\image.jpg"
            PictureBox1.Image =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image18.wm")
            PictureBox1.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            PictureBox1.Visible = True
        ElseIf FileListView.SelectedItems(0).Text = "Order for arrest" Then
            E2()
        ElseIf FileListView.SelectedItems(0).Text = "wanted.txt" Then
            Enable = False
            GroupBox2.BringToFront()
            GroupBox2.Visible = True
            GroupBox2.Text = "E:\Order for arrest\wanted.txt"
            TextBox1.Text =
                "411 international turkey hunting department has sent the order of arresting A++ wanted turkey. The turkey has a long mysterious history, after being sat down by Ms.Li, he revived again, and the greatest mystery is no more than his revival." &
                vbCrLf &
                "This is the source why 411 upgraded him to [A++] wanted turkey, meanwhile, the turkey's partner, big white hen has also been listed in 411 order of arrest." &
                vbCrLf &
                "However, I think the resurrection of turkey is just owing to Atropos. Only she can do these odd things, not it? And we are all mortals, we do not have the power to do that, of course." &
                vbCrLf & vbCrLf & "Lamouis's princess, Aurora."
            TextBox1.Visible = True
        ElseIf FileListView.SelectedItems(0).Text = "IMG_0486.jpg" Then
            Enable = False
            GroupBox2.BringToFront()
            GroupBox2.Visible = True
            GroupBox2.Text = "E:\Order for arrest\IMG_0486.jpg"
            PictureBox1.Image =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image19.wm")
            PictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            PictureBox1.Visible = True
        ElseIf FileListView.SelectedItems(0).Text = "IMG_0487.jpg" Then
            Enable = False
            GroupBox2.BringToFront()
            GroupBox2.Visible = True
            GroupBox2.Text = "E:\Order for arrest\IMG_0487.jpg"
            PictureBox1.Image =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image20.wm")
            PictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            PictureBox1.Visible = True
        ElseIf FileListView.SelectedItems(0).Text = "IMG_0488.jpg" Then
            Enable = False
            GroupBox2.BringToFront()
            GroupBox2.Visible = True
            GroupBox2.Text = "E:\Order for arrest\IMG_0488.jpg"
            PictureBox1.Image =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image21.wm")
            PictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            PictureBox1.Visible = True
        ElseIf FileListView.SelectedItems(0).Text = "readme.txt" Then
            Enable = False
            GroupBox2.BringToFront()
            GroupBox2.Visible = True
            GroupBox2.Text = "D:\readme.txt"
            TextBox1.Text =
                "The duck function is then being used in final examination, but because of its extreme difficulty, the instructor eventually deleted it from the examination."
            TextBox1.Visible = True
        ElseIf FileListView.SelectedItems(0).Text = "time point.txt" Then
            Enable = False
            GroupBox2.BringToFront()
            GroupBox2.Visible = True
            GroupBox2.Text = "D:\time point.txt"
            TextBox1.Text = "Chelsea wrote in his book ""parallel universe"":" & vbCrLf &
                            """We are alive, but in other parallel universe we may be dead. When we die, in other parallel universe, probably we've just born. We always say that passed time won't come again, but in other parallel universe it is very possible to experience the past. When we die, we may get our birth in another parallel universe. Parallel universe goes beyond birth and death. In our mind, it's impossible, but in fact, really nothing is impossible.""" &
                            vbCrLf & "What the big hell inside! I cannot imagine. We cannot imagine. He is really mad."
            TextBox1.Visible = True
        ElseIf FileListView.SelectedItems(0).Text = "two points.txt" Then
            Enable = False
            GroupBox2.BringToFront()
            GroupBox2.Visible = True
            GroupBox2.Text = "D:\two points.txt"
            TextBox1.Text =
                "Medusa put the teleporter of time to her temple, the two computers on two time points are almost same. When one is being modified, the another one changes."
            TextBox1.Visible = True
        ElseIf FileListView.SelectedItems(0).Text = "Duck function.docx" Then
            If Form1.Unlocked.Items.Contains("printed") Then
                MsgBox("The function is already printed.")
            Else
                If MsgBox("Do you want to print the duck function?", vbYesNo, "Print the file") = vbYes Then
                    If Form1.Unlocked.Items.Contains("ink") = False Then
                        MsgBox("Unable to print: No ink in the printer.", 0, "Error")
                    ElseIf Form1.Unlocked.Items.Contains("paper inserted") = False Then
                        MsgBox("Unable to print: No paper in the printer.", 0, "Error")
                    Else
                        Form1.Unlocked.Items.Add("printed")
                        Hide()
                        RefreshAll()
                        Form5.Show()
                        Form5.start(17, "printing......", 10)
                    End If
                End If
            End If
        ElseIf FileListView.SelectedItems(0).Text = "exam website.txt" Then
            Enable = False
            GroupBox2.BringToFront()
            GroupBox2.Visible = True
            GroupBox2.Text = "F:\exam website.txt"
            TextBox1.Text = "URL: " & scoreurl & vbCrLf & "username: " & username & vbCrLf & "password: " & password
            TextBox1.Visible = True
        End If
    End Sub

    Private Sub unlock__Click(sender As Object, e As EventArgs) Handles unlock_.Click
        If password_circle.Text = "turtle" And Form1.items.Items.Contains("Aurora's password") Then
            Form1.Unlocked.Items.Add("DiskD")
            MsgBox("The disk is unlocked.")
            D1()
            Enable = True
            GroupBox1.Visible = False
        ElseIf password_circle.Text = "" Then
            MsgBox("The password is empty.")
        ElseIf password_circle.Text = "password" Then
            MsgBox("No. Not this. It needs the real password.")
            password_circle.Clear()
        Else
            MsgBox("The password isn't right (or you haven't gotten it).")
            password_circle.Clear()
        End If
    End Sub

    Private Sub exit__Click(sender As Object, e As EventArgs) Handles exit_.Click
        Enable = True
        GroupBox1.Visible = False
    End Sub

    Private Sub C1()
        CurrentPath = "C:\"
        realpath.Text = CurrentPath
        FileListView.Items.Clear()
        AddItem("...", Nothing, 5)
        AddItem("Windows", Nothing, 6)
        AddItem("Program Files", Nothing, 7)
    End Sub

    Private Sub C2()
        CurrentPath = "C:\Program Files"
        realpath.Text = CurrentPath
        FileListView.Items.Clear()
        AddItem("...", Nothing, 5)
    End Sub

    Private Sub E1()
        CurrentPath = "E:\"
        realpath.Text = CurrentPath
        FileListView.Items.Clear()
        AddItem("...", Nothing, 5)
        AddItem("Order for arrest", Nothing, 7)
        AddItem("image.jpg", Nothing, 8)
        AddItem("TheTruth.txt", Nothing, 9)
    End Sub

    Private Sub F1()
        CurrentPath = "F:\"
        realpath.Text = CurrentPath
        FileListView.Items.Clear()
        AddItem("...", Nothing, 5)
        AddItem("exam website.txt", Nothing, 9)
    End Sub

    Private Sub E2()
        CurrentPath = "E:\Order for arrest"
        realpath.Text = CurrentPath
        FileListView.Items.Clear()
        AddItem("...", Nothing, 5)
        AddItem("wanted.txt", Nothing, 9)
        AddItem("IMG_0486.jpg", Nothing, 8)
        AddItem("IMG_0487.jpg", Nothing, 8)
        AddItem("IMG_0488.jpg", Nothing, 8)
    End Sub

    Private Sub exit2_Click(sender As Object, e As EventArgs) Handles exit2.Click
        Enable = True
        GroupBox2.Visible = False
        TextBox1.Visible = False
        PictureBox1.Visible = False
    End Sub

    Private Sub examtip_Click(sender As Object, e As EventArgs) Handles examtip.Click
        examtip.Visible = False
    End Sub

    Private Sub exambutton1_Click(sender As Object, e As EventArgs) Handles exambutton1.Click
        MsgBox("information from webpage:" & vbCrLf & "You should ask your teacher to register.", 0,
               "information from webpage")
    End Sub

    Private Sub showwebsite()
        Dim temp = TextBox2.Text
        RefreshAll()
        TextBox2.Text = temp
        GroupBox3.Visible = True
        exam1.Visible = True
        exam2.Visible = True
        exambutton1.Visible = True
        exambutton2.Visible = True
        examtext1.Visible = True
        examtext2.Visible = True
        TextBox2.ReadOnly = True
        MainIcon.Image = Programs.Images(0)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox2.Text = "" Then
            MsgBox("information from webpage:" & vbCrLf & "The URL entered is empty.", 0, "information from webpage")
        ElseIf TextBox2.Text = scoreurl Then
            showwebsite()
        Else
            MsgBox(
                "information from webpage:" & vbCrLf & "disallow: " & TextBox2.Text & vbCrLf &
                "Your administrator just allow you visiting school website.", 0, "information from webpage")
            TextBox2.Clear()
        End If
    End Sub

    Private Sub exambutton2_Click(sender As Object, e As EventArgs) Handles exambutton2.Click
        If LockTime = 0 And examtext1.Text = username Then
            examtip.Text = "Your account is frozen. Ask officer to defreeze."
            examtip.Visible = True
            Exit Sub
        End If
        If examtext1.Text = "" Then
            examtip.Text = "Username is empty."
            examtip.Visible = True
        ElseIf examtext2.Text = "" Then
            examtip.Text = "Password is empty."
            examtip.Visible = True
        ElseIf examtext1.Text <> username Then
            examtip.Text = "Inexistent username."
            examtip.Visible = True
            examtext1.Clear()
            examtext2.Clear()
        ElseIf examtext2.Text <> password Then
            LockTime -= 1
            If LockTime > 1 Then examtip.Text = "Incorrect password. You have " & LockTime & " turns left." Else _
                examtip.Text = "Incorrect password. You have " & LockTime & " turn left."
            examtip.Visible = True
            examtext1.Clear()
            examtext2.Clear()
            If LockTime = 0 Then Form1.Unlocked.Items.Add("freeze score")
        ElseIf examtext1.Text = username And examtext2.Text = password Then
            Dim temp = TextBox2.Text
            RefreshAll()
            TextBox2.Text = temp
            MainIcon.Image = Programs.Images(0)
            LockTime = 5
            GroupBox3.Visible = True
            PictureBox2.Visible = True
            examback.Visible = True
            TextBox2.ReadOnly = True
            examback.BringToFront()
        End If
    End Sub

    Private Sub examback_Click(sender As Object, e As EventArgs) Handles examback.Click
        showwebsite()
    End Sub

    Private Sub D1()
        CurrentPath = "D:\"
        realpath.Text = CurrentPath
        FileListView.Items.Clear()
        AddItem("...", Nothing, 5)
        AddItem("Duck function.docx", Nothing, 10)
        AddItem("readme.txt", Nothing, 9)
        AddItem("time point.txt", Nothing, 9)
        AddItem("two points.txt", Nothing, 9)
    End Sub
End Class