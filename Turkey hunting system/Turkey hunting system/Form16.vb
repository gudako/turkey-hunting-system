Imports System.IO

Public Class Form16
    Private Sub exit__Click(sender As Object, e As EventArgs) Handles exit_.Click
        End
    End Sub

    Public Sub Initialization()
        time_.Text = My.Settings.savetime
        chapter.Text = My.Settings.chapter
        place.Text = My.Settings.place
        If My.Settings.weapon = 0 Then
            weapon.Text = "Null"
        ElseIf My.Settings.weapon = 1 Then
            weapon.Text = "Rabbit stone"
        ElseIf My.Settings.weapon = 2 Then
            weapon.Text = "Light sword"
        ElseIf My.Settings.weapon = 3 Then
            weapon.Text = "Dragon paw"
        ElseIf My.Settings.weapon = 4 Then
            weapon.Text = "Sword"
        End If
        If My.Settings.shield = 0 Then
            shield.Text = "Null"
        ElseIf My.Settings.shield = 1 Then
            shield.Text = "Aluminum shield"
        ElseIf My.Settings.shield = 2 Then
            shield.Text = "Fish scale shield"
        ElseIf My.Settings.shield = 3 Then
            shield.Text = "Dragon shield"
        End If
        magicitems.Text = My.Settings.magics.Split("/").Count - 1
        revivalpotions.Text = My.Settings.revival
        curativepotions.Text = My.Settings.curative
        Label15.Text = "Magic item" & Form13.CheckS(magicitems.Text) & ":"
        Label9.Text = "Revival potion" & Form13.CheckS(revivalpotions.Text) & ":"
        Label11.Text = "Curative potion" & Form13.CheckS(curativepotions.Text) & ":"
    End Sub

    Private Sub newgame_Click(sender As Object, e As EventArgs) Handles newgame.Click
        If MsgBox("Do you want to clear your last game and start a new game?", 48 + vbYesNo, "Restart?") = vbYes Then
            My.Settings.savetime = ""
            My.Settings.Save()
            Hide()
            Form2.Show()
            Form2.title.Text = "Prologue of legend"
            Form2.content.Text = "Once upon a time there was a turkey lord which had ultimate power."
        End If
    End Sub

    Private Sub continue__Click(sender As Object, e As EventArgs) Handles continue_.Click
        Hide()
        Form1.Show()
        Form1.topic.BringToFront()
        Form1.DifTip.BringToFront()
        Form1.savetip.BringToFront()
        Form1.weapon_level = My.Settings.weapon
        Form1.shield_level = My.Settings.shield
        For i = 0 To My.Settings.magics.Split("/").Count - 2
            Form1.magics.Items.Add(My.Settings.magics.Split("/")(i))
        Next
        Form1.revive = My.Settings.revival
        Form1.heal = My.Settings.curative
        Form1.destroy_nest = My.Settings.nest_destroyed
        Form1.witch_book = My.Settings.witch_book
        If Not My.Settings.potionshop = "" Then
            Form13.Show()
            Form13.Hide()
            For i = 0 To ((My.Settings.potionshop.Split("/").Count - 1)/3) - 1
                Dim NewItem = New ListViewItem
                With NewItem
                    .SubItems(0).Text = My.Settings.potionshop.Split("/")(0 + 3*i)
                    .SubItems.Add(My.Settings.potionshop.Split("/")(1 + 3*i))
                    .SubItems.Add(My.Settings.potionshop.Split("/")(2 + 3*i))
                End With
                Form13.ItemsList.Items.Add(NewItem)
            Next
        End If
        For i = 0 To My.Settings.items.Split("/").Count - 2
            Form1.items.Items.Add(My.Settings.items.Split("/")(i))
        Next
        For i = 0 To My.Settings.unlocked.Split("/").Count - 2
            Form1.Unlocked.Items.Add(My.Settings.unlocked.Split("/")(i))
        Next
        If My.Settings.appendix = 0 Then
            Form1.Width = Form1.topic.Width + 10 + Form1.width_append
            Form1.Height = 427 + Form1.height_append
            Form1.step_ = 10
            Form1.Button1.Visible = False
            Form1.picturebox1.Visible = True
            Form1.place3_1.Visible = True
            Form1.place3_2.Visible = True
            Form1.place3_3.Visible = True
            Form1.place3_4.Visible = True
            Form1.place3_5.Visible = True
            Form1.BackColor = Color.White
            Form1.picturebox1.Image =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\scene1.wm")
            Form1.content.Text = "Please select a place to search the turkey." & vbCrLf & vbCrLf &
                                 "The sound ensures the turkey is in the school."
            Form1.topic.Text = "Chapter1"
            Form1.topic.Visible = True
            Form1.DifTip.Visible = True
            Form1.RemoveTitle.Enabled = True
            Form1.music.settings.setMode("loop", True)
            Form1.music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music1.wm"
            Form1.music.Ctlcontrols.play()
        ElseIf My.Settings.appendix = 1 Then
            Form1.step_ = 10
            Form1.Button1.Visible = False
            Form1.place9_1.Visible = False
            Form1.picturebox2.Visible = True
            Form1.Width = 578 + Form1.width_append
            Form1.Height = 479 + Form1.height_append
            Form1.topic.Text = "Chapter2"
            Form1.topic.Visible = True
            Form1.topic.Width = Form1.picturebox2.Width
            Form1.DifTip.Visible = True
            Form1.RemoveTitle.Enabled = True
            Form1.picturebox2.Tag = 0
            Form1.Scene1Appears()
            Form1.Restore.Enabled = True
            Form1.music.settings.setMode("loop", True)
            Form1.music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music1.wm"
            Form1.music.Ctlcontrols.play()
        ElseIf My.Settings.appendix = 2 Then
            Form1.step_ = 10
            Form1.picturebox2.Tag = 5
            Form1.Button1.Visible = False
            Form1.picturebox2.Visible = True
            Form1.Width = 578 + Form1.width_append
            Form1.Height = 479 + Form1.height_append
            Form1.Scene5Appears()
            Form1.physical_power.Visible = True
            Form1.Restore.Enabled = True
            Form1.music.settings.setMode("loop", True)
            Form1.music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music1.wm"
            Form1.music.Ctlcontrols.play()
        ElseIf My.Settings.appendix = 3 Then
            Form1.step_ = 10
            Form1.picturebox2.Tag = 33
            Form1.Button1.Visible = False
            Form1.picturebox2.Visible = True
            Form1.Width = 578 + Form1.width_append
            Form1.Height = 479 + Form1.height_append
            Form1.lock10_2.Tag = 0
            Form1.physical_power.Visible = True
            Form1.Restore.Enabled = True
            Form1.Scene14Appears()
            Form1.music.settings.setMode("loop", True)
            Form1.music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music12.wm"
            Form1.music.Ctlcontrols.play()
        ElseIf My.Settings.appendix = 4 Then
            Form1.Width = 578 + Form1.width_append
            Form1.Height = 479 + Form1.height_append
            Form1.Button1.Visible = False
            Form1.picturebox1.Visible = False
            Form1.picturebox2.Visible = False
            Form1.PictureBox3.Visible = True
            Form1.PictureBox3.Tag = 0
            Form1.SetParent1()
            Form1.Scene001appears()
            Form1.music.settings.setMode("loop", True)
            Form1.music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music14.wm"
            Form1.music.Ctlcontrols.play()
            Form1.topic.Text = "Chapter3"
            Form1.topic.Visible = True
            Form1.topic.Width = Form1.PictureBox3.Width
            Form1.DifTip.Visible = True
            Form1.RemoveTitle.Enabled = True
            Form1.topic.BringToFront()
            Form1.DifTip.BringToFront()
        ElseIf My.Settings.appendix = 5 Then
            Form1.Width = 578 + Form1.width_append
            Form1.Height = 599 + Form1.height_append
            Form1.Button1.Visible = False
            Form1.picturebox1.Visible = False
            Form1.picturebox2.Visible = False
            Form1.PictureBox3.Visible = True
            Form1.PictureBox3.Tag = 6
            Form1.SetParent1()
            Form1.Scene016appears()
            Form1.music.settings.setMode("loop", True)
            Form1.music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music14.wm"
            Form1.music.Ctlcontrols.play()
            Form1.RefreshItems()
            Form1.Disappear2()
            Form1.lock26_1.Tag = 2
            Form1.lock26_1.Image = Form1.ImageList1.Images(4)
            Form1.actor.Image =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image6.wm")
            Form1.actor.Visible = True
            Form1.shining.Enabled = True
            Form1.itemlist.Visible = True
            Form1.SendMessage("Tarecgosa:" & vbCrLf & "The fire... is too strong!!", 7)
        ElseIf My.Settings.appendix = 6 Then
            Form1.Width = 578 + Form1.width_append
            Form1.Height = 599 + Form1.height_append
            Form1.Button1.Visible = False
            Form1.picturebox1.Visible = False
            Form1.picturebox2.Visible = False
            Form1.PictureBox3.Visible = True
            Form1.PictureBox3.Tag = 25
            Form1.SetParent1()
            Form1.Scene016appears()
            Form1.music.settings.setMode("loop", True)
            Form1.music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music14.wm"
            Form1.music.Ctlcontrols.play()
            Form1.RefreshItems()
            Form1.lock26_1.Tag = 2
            Form1.lock26_1.Image = Form1.ImageList1.Images(4)
            Form1.itemlist.Visible = True
        ElseIf My.Settings.appendix = 7 Then
            Form1.Width = 578 + Form1.width_append
            Form1.Height = 599 + Form1.height_append
            Form1.Button1.Visible = False
            Form1.picturebox1.Visible = False
            Form1.picturebox2.Visible = False
            Form1.PictureBox3.Visible = True
            Form1.PictureBox3.Tag = 38
            Form1.SetParent1()
            Form1.Scene016appears()
            Form1.music.settings.setMode("loop", True)
            Form1.music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music14.wm"
            Form1.music.Ctlcontrols.play()
            Form1.RefreshItems()
            Form1.lock26_1.Tag = 2
            Form1.lock26_1.Image = Form1.ImageList1.Images(4)
            Form1.itemlist.Visible = True
            Form1.topic.Text = "Chapter4"
            Form1.topic.Visible = True
            Form1.topic.Width = Form1.PictureBox3.Width
            Form1.DifTip.Visible = True
            Form1.RemoveTitle.Enabled = True
            If Not Form1.Unlocked.Items.Contains(Form1.lock41_2.Name) Then Form1.Unlocked.Items.Add(Form1.lock41_2.Name)
        ElseIf My.Settings.appendix = 8 Then
            Form1.Width = 578 + Form1.width_append
            Form1.Height = 599 + Form1.height_append
            Form1.Button1.Visible = False
            Form1.picturebox1.Visible = False
            Form1.picturebox2.Visible = False
            Form1.PictureBox3.Visible = True
            Form1.PictureBox3.Tag = 43
            Form1.SetParent1()
            Form1.Scene047appears()
            Form1.music.settings.setMode("loop", True)
            Form1.music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music14.wm"
            Form1.music.Ctlcontrols.play()
            Form1.RefreshItems()
            Form1.lock26_1.Tag = 2
            Form1.lock26_1.Image = Form1.ImageList1.Images(4)
            Form1.itemlist.Visible = True
        ElseIf My.Settings.appendix = 9 Or My.Settings.appendix = 10 Then
            Form1.Width = 578 + Form1.width_append
            Form1.Height = 599 + Form1.height_append
            Form1.Button1.Visible = False
            Form1.picturebox1.Visible = False
            Form1.picturebox2.Visible = False
            Form1.PictureBox3.Visible = True
            Form1.SetParent1()
            If My.Settings.appendix = 9 Then Form1.Scene064appears() Else Form1.Scene076appears()
            Form1.music.settings.setMode("loop", True)
            Form1.music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music17.wm"
            Form1.music.Ctlcontrols.play()
            Form1.RefreshItems()
            Form1.lock26_1.Tag = 2
            Form1.lock26_1.Image = Form1.ImageList1.Images(4)
            Form1.itemlist.Visible = True
            Form1.PictureBox3.Tag = 44.5
        ElseIf My.Settings.appendix = 11 Then
            Form1.Width = 578 + Form1.width_append
            Form1.Height = 599 + Form1.height_append
            Form1.Button1.Visible = False
            Form1.picturebox1.Visible = False
            Form1.picturebox2.Visible = False
            Form1.PictureBox3.Visible = True
            Form1.SetParent1()
            Form1.Scene084appears()
            Form1.music.Ctlcontrols.stop()
            Form1.actor.Image =
                Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image2.wm")
            Form1.actor.Visible = True
            Form1.actor.Top = 0
            Form1.MoveAtropos.Tag = 25185
            Form1.MoveAtropos.Enabled = True
            Form1.Disappear2()
            Form1.RefreshItems()
            Form1.itemlist.Visible = True
        ElseIf My.Settings.appendix = 12 Then
            Form1.Hide()
            Form20.Show()
            Form20.ImportFromRecord()
            Form20.SceneAppears(14)
            Form20.scene.Tag = 13
            Form1.music.settings.setMode("loop", True)
            Form1.music.URL = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\music17.wm"
            Form1.music.Ctlcontrols.play()
        End If
        'Form1.Scene080appears()
        'Form1.PictureBox3.Tag = 12
        'Form1.Scene028appears()
        'Form1.MoveAtropos.Tag = 3050
        'Form1.actor.Image = Image.FromFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\image15.wm")
        'Form1.MoveAtropos.Enabled = True
        'Form1.actor.Visible = True
        'Form1.dialogue.Visible = True
        'Form1.items.Items.Add("bottle")
        'Form1.items.Items.Add("mathematics workbook")

        'Form1.Scene057appears()
        'Form1.PictureBox3.Tag = 43
        'Form1.items.Items.Add("underwater magical key")
        'Form1.items.Items.Add("sodium hydroxide")
        'Form1.items.Items.Add("turtle")
        'Form1.Unlocked.Items.Add("electricity of gambling machine")
        'Form1.items.Items.Add("palette")
        'Form1.items.Items.Add("eraser")
        'Form1.items.Items.Remove("duck vector launcher")
        'Form1.items.Items.Add("carbolic stick")
        'Form1.items.Items.Add("trailer with mirror")
        'Form1.items.Items.Add("XuTianhao artifact")
        'Form1.items.Items.Add("final examination paper")
        'Form1.Unlocked.Items.Add("ghost meet")
        'Form1.Scene083appears()
        'Form1.Unlocked.Items.Add("freeze score")
        'Form1.items.Items.Add("Mr.Duck standard answer")

        Form1.music.settings.volume = Form1.BackgroundVolume
        Form1.music.settings.setMode("loop", True)
        Form1.Left = (Screen.PrimaryScreen.Bounds.Width - Form1.Width)/2
        Form1.Top = (Screen.PrimaryScreen.Bounds.Height - Form1.Height)/2
    End Sub

    Private Sub SaveProgress_Click(sender As Object, e As EventArgs) Handles SaveProgress.Click
        Dim sd = New SaveFileDialog()
        sd.Filter="*.txt|*.txt"
        sd.ShowDialog()
        if sd.FileName="" Then Exit Sub
        Try
            Dim sw =New StreamWriter(sd.FileName)
            sw.WriteLine(My.Settings.savetime)
            sw.WriteLine(My.Settings.chapter)
            sw.WriteLine(My.Settings.place)
            sw.WriteLine(My.Settings.weapon)
            sw.WriteLine(My.Settings.shield)
            sw.WriteLine(My.Settings.magics)
            sw.WriteLine(My.Settings.revival)
            sw.WriteLine(My.Settings.curative)
            sw.WriteLine(My.Settings.appendix)
            sw.WriteLine(My.Settings.potionshop)
            sw.WriteLine(My.Settings.items)
            sw.WriteLine(My.Settings.nest_destroyed)
            sw.WriteLine(My.Settings.witch_book)
            sw.WriteLine(My.Settings.unlocked)
            sw.WriteLine(My.Settings.missions)
            sw.Close()
        Catch ex As Exception
            MessageBox.Show("error")
        End Try
    End Sub

    Private Sub LoadProgress_Click(sender As Object, e As EventArgs) Handles LoadProgress.Click
        dim rd = New OpenFileDialog()
        rd.Multiselect=false
        rd.Filter="*.txt|*.txt"
        rd.ShowDialog()
        if rd.FileName="" Then exit Sub
        Try
            Dim sr =New StreamReader(rd.FileName)
            My.Settings.savetime=sr.ReadLine()
            My.Settings.chapter=sr.ReadLine()
            My.Settings.place=sr.ReadLine()
            My.Settings.weapon=sr.ReadLine()
            My.Settings.shield=sr.ReadLine()
            My.Settings.magics=sr.ReadLine()
            My.Settings.revival=sr.ReadLine()
            My.Settings.curative=sr.ReadLine()
            My.Settings.appendix=sr.ReadLine()
            My.Settings.potionshop=sr.ReadLine()
            My.Settings.items=sr.ReadLine()
            My.Settings.nest_destroyed=sr.ReadLine()
            My.Settings.witch_book=sr.ReadLine()
            My.Settings.unlocked=sr.ReadLine()
            My.Settings.missions=sr.ReadLine()
            sr.Close()
            My.Settings.Save()
            MessageBox.Show("got it")
            End
        Catch ex As Exception
            MessageBox.Show("error")
        End Try
    End Sub
End Class