﻿
Imports System.IO
Imports System.Text

Public Class Form2
    Private step_ As Integer = 0
    Private s As Stream

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
    End Sub

    Private Sub EndPrologue()
        Hide()
        Form1.Show()
        Form1.Height = 241 + Form1.height_append
        Form1.Width = Form1.topic.Width + 10 + Form1.width_append
        Form1.Left = Screen.PrimaryScreen.Bounds.Width.ToString/2 - Form1.Width/2
        Form1.Top = Screen.PrimaryScreen.Bounds.Height.ToString/2 - Form1.Height/2
        Form1.topic.BringToFront()
        Form1.DifTip.BringToFront()
        Form1.savetip.BringToFront()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If step_ = 0 Then
            step_ = 1
            content.Text =
                "The turkey lord often rampaged with his minions. He commanded a large turkey army and got great power."
        ElseIf step_ = 1 Then
            step_ = 2
            content.Text =
                "However, the immortality of turkey had fallen apart after a physics class. In an accidental chance, the physics teacher Ms. Li sat down on him and killed the turkey lord. Then he didn't appear again until one day..."
        ElseIf step_ = 2 Then
            step_ = 3
            content.Text =
                "One day when the teacher went into class and opened the door of host computer, massive turkey eggs dropped out from inside. People mentioned the turkey lord. He has resurrected!!"
        ElseIf step_ = 3 Then
            step_ = 4
            content.Text =
                "He had lost his powerful power and become a common turkey after he was sat down by Ms. Li. He was eager for power. But we... just desire his delicious meat for Thanksgiving day."
        ElseIf step_ = 4 Then
            step_ = 5
            Button1.Text = "Get ready!"
            content.Text = "We must hunt him at once... Without any delay."
        ElseIf step_ = 5 Then
            EndPrologue()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        If _
            Not _
            My.Computer.FileSystem.DirectoryExists(
                My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files") Then
            restart:
            Label1.Visible = True
            Timer2.Enabled = True
        Else
            retry:
            For i = 0 To ListBox1.Items.Count - 1
                If _
                    My.Computer.FileSystem.FileExists(
                        My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\" & ListBox1.Items(i) &
                        ".wm") = False Then
                    Dim ComplexMsg =
                            MsgBox(
                                "The program has to restart, probably it is because of an update (a new vision of program has run). Press ""Ignore"" then you can normally start the program. If this situation lasts endlessly, press ""Abort"" to stop the program.",
                                vbAbortRetryIgnore, "Restart")
                    If ComplexMsg = vbAbort Then
                        End
                        Exit Sub
                    ElseIf ComplexMsg = MsgBoxResult.Retry Then
                        GoTo retry
                    Else

                        GoTo restart
                    End If
                End If
            Next
            If My.Computer.FileSystem.FileExists("settings.ini") Then
                Dim RT As StreamReader
                RT = New StreamReader("settings.ini", ASCIIEncoding.Default)
                My.Settings.savetime = RT.ReadLine().Split(":")(1)
                My.Settings.chapter = RT.ReadLine().Split(":")(1)
                My.Settings.place = RT.ReadLine().Split(":")(1)
                My.Settings.weapon = RT.ReadLine().Split(":")(1)
                My.Settings.shield = RT.ReadLine().Split(":")(1)
                My.Settings.magics = RT.ReadLine().Split(":")(1)
                My.Settings.revival = RT.ReadLine().Split(":")(1)
                My.Settings.curative = RT.ReadLine().Split(":")(1)
                My.Settings.appendix = RT.ReadLine().Split(":")(1)
                My.Settings.potionshop = RT.ReadLine().Split(":")(1)
                My.Settings.items = RT.ReadLine().Split(":")(1)
                My.Settings.nest_destroyed = RT.ReadLine().Split(":")(1)
                My.Settings.witch_book = RT.ReadLine().Split(":")(1)
                My.Settings.unlocked = RT.ReadLine().Split(":")(1)
                My.Settings.Save()
                RT.Close()
                My.Computer.FileSystem.DeleteFile("settings.ini")
                GoTo nextpage
            ElseIf My.Settings.savetime = "" Then
                title.Text = "Prologue of legend"
                content.Text = "Once upon a time there was a turkey lord which had ultimate power."
            Else
                nextpage:
                Hide()
                Form16.Show()
                Form16.Initialization()
            End If
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Timer2.Enabled = False
        My.Computer.FileSystem.CreateDirectory(
            My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files")
        Export(My.Resources.Cities_of_Tomorrow, "music1")
        Export(My.Resources.Defeat, "sound1")
        Export(My.Resources.bump, "sound3")
        Export(My.Resources.defend, "sound4")
        Export(My.Resources.turkey, "sound5")
        Export(My.Resources.miss, "sound6")
        Export(My.Resources.Game_Over, "sound7")
        Export(My.Resources.win, "sound8")
        Export(My.Resources.floor3, "scene1")
        Export(My.Resources.rabbit, "battler1")
        Export(My.Resources.rabbit_voice, "sound9")
        Export(My.Resources.corona_ball, "sound10")
        Export(My.Resources.outside, "scene2")
        Export(My.Resources.library, "scene3")
        Export(My.Resources.outside2, "scene4")
        Export(My.Resources.GYM1, "scene5")
        Export(My.Resources.GYM2, "scene6")
        Export(My.Resources.ring, "sound11")
        Export(My.Resources.outside3, "scene7")
        Export(My.Resources.thump, "sound12")
        Export(My.Resources.splash, "sound13")
        Export(My.Resources.big_white_hen, "battler2")
        Export(My.Resources.childoflight_spiderbgm, "music5")
        Export(My.Resources.bite, "sound14")
        Export(My.Resources.power_up, "sound15")
        Export(My.Resources.lay_egg, "sound16")
        Export(My.Resources.corona_ball1, "battler3")
        Export(My.Resources.down, "sound17")
        Export(My.Resources.lightning, "sound18")
        Export(My.Resources.heal, "sound19")
        Export(My.Resources.heal2, "sound20")
        Export(My.Resources.down1, "sound21")
        Export(My.Resources.heavy, "sound22")
        Export(My.Resources.Untitled_Session_1_mixdown, "music7")
        Export(My.Resources.sounds_sfx_pck_0000001651, "music8")
        Export(My.Resources.sounds_sfx_pck_0000001593, "music9")
        Export(My.Resources.gunstrike, "sound23")
        Export(My.Resources.shoot, "sound24")
        Export(My.Resources.strike, "sound25")
        Export(My.Resources.class6, "scene8")
        Export(My.Resources.end_of_capture1, "scene9")
        Export(My.Resources.comprehensive_building, "scene10")
        Export(My.Resources.small_black_hen, "battler4")
        Export(My.Resources.staircase, "scene11")
        Export(My.Resources.floor2_left, "scene12")
        Export(My.Resources.floor3_left, "scene13")
        Export(My.Resources.biology_lab, "scene14")
        Export(My.Resources.murloc, "sound26")
        Export(My.Resources.Turkey_Murloc, "sound27")
        Export(My.Resources.murloc1, "battler5_1")
        Export(My.Resources.murloc2, "battler5_2")
        Export(My.Resources.murloc3, "battler5_3")
        Export(My.Resources.battler5_4, "battler5_4")
        Export(My.Resources.turkey_murloc1, "battler6")
        Export(My.Resources.duck, "sound28")
        Export(My.Resources.turkfish_lord, "battler8")
        Export(My.Resources.Beyond_Heaven, "music10")
        Export(My.Resources.sounds_sfx_pck_0000001566, "prelude1")
        Export(My.Resources.bio_lab, "background1")
        Export(My.Resources.chop, "sound29")
        Export(My.Resources.strike1, "sound30")
        Export(My.Resources.sounds_sfx_pck_0000001695, "victory1")
        Export(My.Resources.lecture_hall, "scene15")
        Export(My.Resources.class_start, "sound31")
        Export(My.Resources.explode, "sound32")
        Export(My.Resources.soil, "sound33")
        Export(My.Resources.worm, "battler9")
        Export(My.Resources.laser, "sound34")
        Export(My.Resources.cow, "sound35")
        Export(My.Resources.witch, "sound36")
        Export(My.Resources.witch1, "sound37")
        Export(My.Resources.big_milk_cow, "battler10")
        Export(My.Resources.cowmilk, "sound38")
        Export(My.Resources.floor2_right, "scene16")
        Export(My.Resources.chemistry_lab, "scene17")
        Export(My.Resources.HNO3, "potion2")
        Export(My.Resources._0H2SO4, "potion3")
        Export(My.Resources.Cu, "potion4")
        Export(My.Resources.Cs, "potion5")
        Export(My.Resources.Na, "potion6")
        Export(My.Resources.soundtrack_2, "music11")
        Export(My.Resources.Extinction, "music12")
        Export(My.Resources.scene18, "scene18")
        Export(My.Resources.rooster, "sound39")
        Export(My.Resources.page, "sound40")
        Export(My.Resources.floor3_right, "scene19")
        Export(My.Resources.intro1, "intro1")
        Export(My.Resources.intro2, "intro2")
        Export(My.Resources.intro3, "intro3")
        Export(My.Resources.intro4, "intro4")
        Export(My.Resources.intro5, "intro5")
        Export(My.Resources.top_right, "scene20")
        Export(My.Resources.A_turkey, "sound41")
        Export(My.Resources.Avogadro_turkey, "battler11")
        Export(My.Resources.purchase, "sound42")
        Export(My.Resources.intro6, "intro6")
        Export(My.Resources.intro7, "intro7")
        Export(My.Resources.intro8, "intro8")
        Export(My.Resources.intro9, "intro9")
        Export(My.Resources.intro10, "intro10")
        Export(My.Resources.intro11, "intro11")
        Export(My.Resources.intro12, "intro12")
        Export(My.Resources.switch, "sound43")
        Export(My.Resources.floor4_mid__left, "scene21")
        Export(My.Resources.floor4_right__left, "scene22")
        Export(My.Resources.general_room, "scene23")
        Export(My.Resources.ice, "sound44")
        Export(My.Resources.robot, "sound45")
        Export(My.Resources.lunch_contending_robot, "battler12")
        Export(My.Resources.turkey_association, "scene24")
        Export(My.Resources.problem, "sound46")
        Export(My.Resources.through, "sound47")
        Export(My.Resources.lock, "sound48")
        Export(My.Resources.odd_playground, "scene25")
        Export(My.Resources.intro13, "intro13")
        Export(My.Resources.intro14, "intro14")
        Export(My.Resources.intro15, "intro15")
        Export(My.Resources.intro16, "intro16")
        Export(My.Resources.intro17, "intro17")
        Export(My.Resources.voice1, "voice1")
        Export(My.Resources.voice2, "voice2")
        Export(My.Resources.voice3, "voice3")
        Export(My.Resources.voice4, "voice4")
        Export(My.Resources.voice5, "voice5")
        Export(My.Resources.voice6, "voice6")
        Export(My.Resources.voice7, "voice7")
        Export(My.Resources.voice8, "voice8")
        Export(My.Resources.voice9, "voice9")
        Export(My.Resources.voice10, "voice10")
        Export(My.Resources.voice11, "voice11")
        Export(My.Resources.voice12, "voice12")
        Export(My.Resources.voice13, "voice13")
        Export(My.Resources.voice14, "voice14")
        Export(My.Resources.voice15, "voice15")
        Export(My.Resources.voice16, "voice16")
        Export(My.Resources.voice17, "voice17")
        Export(My.Resources.psychology_room, "scene26")
        Export(My.Resources.mysterious_room, "scene27")
        Export(My.Resources.amber_corridor, "scene28")
        Export(My.Resources.light_corridor, "scene29")
        Export(My.Resources.music_room, "scene30")
        Export(My.Resources.art_room, "scene31")
        Export(My.Resources.amber_toilet, "scene32")
        Export(My.Resources.floor4_left, "scene33")
        Export(My.Resources.Disaster_, "music13")
        Export(My.Resources.worm_symbol, "image1")
        Export(My.Resources.light_empty_room, "scene34")
        Export(My.Resources.ancient_world, "scene35")
        Export(My.Resources.Trine_3_Main_Theme, "music14")
        Export(My.Resources.Atropos, "image2")
        Export(My.Resources.outside_aurora_palace, "scene36")
        Export(My.Resources.dialogue1, "dialogue1")
        Export(My.Resources.dialogue2, "dialogue2")
        Export(My.Resources.dialogue3, "dialogue3")
        Export(My.Resources.dialogue4, "dialogue4")
        Export(My.Resources.dialogue5, "dialogue5")
        Export(My.Resources.mr_duck_square, "scene37")
        Export(My.Resources.mr_duck_park_entrance, "scene38")
        Export(My.Resources.thorn1, "scene39")
        Export(My.Resources.guard, "battler13")
        Export(My.Resources.aurorapalace1, "scene40")
        Export(My.Resources.medusa_temple_door, "scene41")
        Export(My.Resources.dialogue6, "dialogue6")
        Export(My.Resources.dialogue7, "dialogue7")
        Export(My.Resources.dialogue8, "dialogue8")
        Export(My.Resources.dialogue9, "dialogue9")
        Export(My.Resources.dialogue10, "dialogue10")
        Export(My.Resources.Mr_duck_park, "scene42")
        Export(My.Resources.Mr_duck_road, "scene43")
        Export(My.Resources.Mr_duck_pool, "scene44")
        Export(My.Resources.housedoor_df, "scene45")
        Export(My.Resources.inside_df, "image3")
        Export(My.Resources.tarecgosa_destroyer, "image4")
        Export(My.Resources.frog, "image5")
        Export(My.Resources.thorn_mountain2, "scene46")
        Export(My.Resources.duck_grassland, "scene47")
        Export(My.Resources.duck_southern_gate, "scene48")
        Export(My.Resources.solar_factory, "scene49")
        Export(My.Resources.aurora_palace1, "scene50")
        Export(My.Resources.tarecgosa, "image6")
        Export(My.Resources.burned_tarecgosa, "image7")
        Export(My.Resources.opened_factory, "scene51")
        Export(My.Resources.Chemistry_lab_01, "scene52")
        Export(My.Resources.Chemistry_lab_02, "scene53")
        Export(My.Resources.Biochemistry_lab_01, "scene54")
        Export(My.Resources.Biochemistry_lab_02, "scene55")
        Export(My.Resources.artifact_recipe, "intro18")
        Export(My.Resources.artifact_location, "intro19")
        Export(My.Resources.solar_ball_recipe, "intro20")
        Export(My.Resources.chemistry_lab_03, "scene56")
        Export(My.Resources.make_Cl2, "scene57")
        Export(My.Resources.tarecgosa_battler, "battler14")
        Export(My.Resources.childoflight_bossbgm, "music15")
        Export(My.Resources.hclgun, "sound49")
        Export(My.Resources.write, "sound50")
        Export(My.Resources.vortex, "sound51")
        Export(My.Resources.witch_voice1, "voice18")
        Export(My.Resources.vortex1, "image8")
        Export(My.Resources.vortex2, "image9")
        Export(My.Resources.Season_of_Nights, "music16")
        Export(My.Resources.backroom1, "scene58")
        Export(My.Resources.backroom2, "scene59")
        Export(My.Resources.backroom3, "scene60")
        Export(My.Resources.backroom4, "scene61")
        Export(My.Resources.backroom5, "scene60_2")
        Export(My.Resources.witch_voice2, "voice19")
        Export(My.Resources.witch_voice3, "voice20")
        Export(My.Resources.witch_voice4, "voice21")
        Export(My.Resources.witch_voice5, "voice22")
        Export(My.Resources.backroom6, "scene62")
        Export(My.Resources.backroom7, "scene63")
        Export(My.Resources.dialogue11, "dialogue11")
        Export(My.Resources.dialogue12, "dialogue12")
        Export(My.Resources.dialogue13, "dialogue13")
        Export(My.Resources.ghost, "battler15")
        Export(My.Resources.distort, "sound52")
        Export(My.Resources._throw, "sound53")
        Export(My.Resources.dialogue14, "dialogue14")
        Export(My.Resources.dialogue15, "dialogue15")
        Export(My.Resources.dialogue16, "dialogue16")
        Export(My.Resources.dialogue17, "dialogue17")
        Export(My.Resources.dialogue18, "dialogue18")
        Export(My.Resources.backroom8, "scene64")
        Export(My.Resources.dialogue19, "dialogue19")
        Export(My.Resources.dialogue20, "dialogue20")
        Export(My.Resources.dialogue21, "dialogue21")
        Export(My.Resources.backroom9, "scene65")
        Export(My.Resources.backroom10, "scene66")
        Export(My.Resources.backroom11, "scene67")
        Export(My.Resources.backroom12, "scene68")
        Export(My.Resources.dialogue22, "dialogue22")
        Export(My.Resources.dialogue23, "dialogue23")
        Export(My.Resources.dialogue24, "dialogue24")
        Export(My.Resources.witch2, "image10")
        Export(My.Resources.Untitled_1, "image11")
        Export(My.Resources.Untitled_2, "image12")
        Export(My.Resources.Untitled_3, "image13")
        Export(My.Resources.Untitled_4, "image14")
        Export(My.Resources.untitled_5, "image15")
        Export(My.Resources.dialogue25, "dialogue25")
        Export(My.Resources.dialogue26, "dialogue26")
        Export(My.Resources.dialogue27, "dialogue27")
        Export(My.Resources.dialogue28, "dialogue28")
        Export(My.Resources.dialogue29, "dialogue29")
        Export(My.Resources.dialogue30, "dialogue30")
        Export(My.Resources.dialogue31, "dialogue31")
        Export(My.Resources.dialogue32, "dialogue32")
        Export(My.Resources.dialogue33, "dialogue33")
        Export(My.Resources.dialogue34, "dialogue34")
        Export(My.Resources.dialogue35, "dialogue35")
        Export(My.Resources.turtle, "image16")
        Export(My.Resources.turkey1, "image17")
        Export(My.Resources.dialogue36, "dialogue36")
        Export(My.Resources.dialogue37, "dialogue37")
        Export(My.Resources.dialogue38, "dialogue38")
        Export(My.Resources.dialogue39, "dialogue39")
        Export(My.Resources.dialogue40, "dialogue40")
        Export(My.Resources.dialogue41, "dialogue41")
        Export(My.Resources.dialogue42, "dialogue42")
        Export(My.Resources.dawn, "scene69")
        Export(My.Resources.palace_stair1, "scene70")
        Export(My.Resources.palace_room, "scene71")
        Export(My.Resources.office, "scene72")
        Export(My.Resources.computer_image_hcl, "image18")
        Export(My.Resources.computer_IMG_0486, "image19")
        Export(My.Resources.computer_IMG_0487, "image20")
        Export(My.Resources.computer_IMG_0488, "image21")
        Export(My.Resources.duckpool0, "scene73")
        Export(My.Resources.duckpool1, "scene74")
        Export(My.Resources.duckpool2, "scene75")
        Export(My.Resources.dive, "sound54")
        Export(My.Resources.aurora_music_room, "scene76")
        Export(My.Resources.mermaid, "image22")
        Export(My.Resources.intro21, "intro21")
        Export(My.Resources.duckpool3, "scene77")
        Export(My.Resources.dialogue43, "dialogue43")
        Export(My.Resources.drop, "sound55")
        Export(My.Resources.intro22, "intro22")
        Export(My.Resources.dialogue44, "dialogue44")
        Export(My.Resources.dialogue45, "dialogue45")
        Export(My.Resources.dialogue46, "dialogue46")
        Export(My.Resources.disguised_god, "image23")
        Export(My.Resources.dialogue47, "dialogue47")
        Export(My.Resources.deadend1, "image24")
        Export(My.Resources.gas, "sound56")
        Export(My.Resources.dialogue48, "dialogue48")
        Export(My.Resources.witch_being_confused, "image25")
        Export(My.Resources.dialogue49, "dialogue49")
        Export(My.Resources.dialogue50, "dialogue50")
        Export(My.Resources.dialogue51, "dialogue51")
        Export(My.Resources.mirror, "sound57")
        Export(My.Resources.curse, "sound58")
        Export(My.Resources.dialogue52, "dialogue52")
        Export(My.Resources.dialogue53, "dialogue53")
        Export(My.Resources.saw, "sound59")
        Export(My.Resources.ghosthouse0, "scene78")
        Export(My.Resources.ghosthouse1, "scene79")
        Export(My.Resources.ghosthouse2, "scene80")
        Export(My.Resources.duckpool4, "scene81")
        Export(My.Resources.duckpool5, "scene82")
        Export(My.Resources.chicken, "battler16")
        Export(My.Resources.duckpool6, "scene83")
        Export(My.Resources.Christmas_room, "scene84")
        Export(My.Resources.Christmas, "scene85")
        Export(My.Resources.duckcastle0, "scene86")
        Export(My.Resources.duckcastle1, "scene87")
        Export(My.Resources.duckcastle2, "scene88")
        Export(My.Resources.duckcastle3, "scene89")
        Export(My.Resources.duckcastle4, "scene90")
        Export(My.Resources.duckcastle5, "scene91")
        Export(My.Resources.Atropos_with_gem, "image26")
        Export(My.Resources.rooster1, "image27")
        Export(My.Resources.dialogue54, "dialogue54")
        Export(My.Resources.dialogue55, "dialogue55")
        Export(My.Resources.blank, "image28")
        Export(My.Resources.vector_room, "scene92")
        Export(My.Resources.arrow, "sound60")
        Export(My.Resources.scream, "dialogue56")
        Export(My.Resources.jail_wall, "scene93")
        Export(My.Resources.aurora_indoor, "scene94")
        Export(My.Resources.positive_cow, "battler18")
        Export(My.Resources.negative_cow, "battler19")
        Export(My.Resources.floating_cow, "battler20")
        Export(My.Resources.dialogue57, "dialogue57")
        Export(My.Resources.dialogue58, "dialogue58")
        Export(My.Resources.last_castle, "scene95")
        Export(My.Resources.biochemistry_last_lab, "scene96")
        Export(My.Resources.magic_forest, "scene97")
        Export(My.Resources.makekey1, "image29")
        Export(My.Resources.makekey2, "image30")
        Export(My.Resources.makekey3, "image31")
        Export(My.Resources.intro23, "intro23")
        Export(My.Resources.aurora_ghost, "image32")
        Export(My.Resources.dialogue59, "dialogue59")
        Export(My.Resources.dialogue60, "dialogue60")
        Export(My.Resources.dialogue61, "dialogue61")
        Export(My.Resources.intro24, "intro24")
        Export(My.Resources.dialogue62, "dialogue62")
        Export(My.Resources.dialogue63, "dialogue63")
        Export(My.Resources.WinterSpell, "music17")
        Export(My.Resources.dialogue64, "dialogue64")
        Export(My.Resources.dialogue65, "dialogue65")
        Export(My.Resources.dialogue66, "dialogue66")
        Export(My.Resources.dialogue67, "dialogue67")
        Export(My.Resources.dialogue68, "dialogue68")
        Export(My.Resources.dialogue69, "dialogue69")
        Export(My.Resources.magic_forest_frontier, "scene98")
        Export(My.Resources.byroad, "scene99")
        Export(My.Resources.magic_castle, "scene100")
        Export(My.Resources.seapath, "scene101")
        Export(My.Resources.seabridge, "scene102")
        Export(My.Resources.scene103, "scene103")
        Export(My.Resources.scene104, "scene104")
        Export(My.Resources.scene105, "scene105")
        Export(My.Resources.scene106, "scene106")
        Export(My.Resources.scene107, "scene107")
        Export(My.Resources.scene108, "scene108")
        Export(My.Resources.scene109, "scene109")
        Export(My.Resources.scene110, "scene110")
        Export(My.Resources.scene111, "scene111")
        Export(My.Resources.scene112, "scene112")
        Export(My.Resources.scene113, "scene113")
        Export(My.Resources.scene114, "scene114")
        Export(My.Resources.scene115, "scene115")
        Export(My.Resources.scene116, "scene116")
        Export(My.Resources.scene117, "scene117")
        Export(My.Resources.scene118, "scene118")
        Export(My.Resources.scene111_1, "scene111_1")
        Export(My.Resources.castle_explode, "image33")
        Export(My.Resources.castle_exploded, "image34")
        Export(My.Resources.applause, "sound61")
        Export(My.Resources.dialogue70, "dialogue70")
        Export(My.Resources.dialogue71, "dialogue71")
        Export(My.Resources.dialogue72, "dialogue72")
        Export(My.Resources.aurora_ghost_pure, "image35")
        Export(My.Resources.dialogue73, "dialogue73")
        Export(My.Resources.break, "sound62")
        Export(My.Resources.Medusa_close, "image36")
        Export(My.Resources.Medusa, "image37")
        Export(My.Resources.Medusa_petrified, "image38")
        Export(My.Resources.dialogue74, "dialogue74")
        Export(My.Resources.dialogue75, "dialogue75")
        Export(My.Resources.dialogue76, "dialogue76")
        Export(My.Resources.dialogue77, "dialogue77")
        Export(My.Resources.dialogue78, "dialogue78")
        Export(My.Resources.getitem, "sound63")
        Export(My.Resources.dialogue79, "dialogue79")
        Export(My.Resources.dialogue80, "dialogue80")
        Export(My.Resources.dialogue81, "dialogue81")
        Export(My.Resources.dialogue82, "dialogue82")
        Export(My.Resources.dialogue83, "dialogue83")
        Export(My.Resources.dialogue84, "dialogue84")
        Export(My.Resources.dialogue85, "dialogue85")
        Export(My.Resources.dialogue86, "dialogue86")
        Export(My.Resources.dialogue87, "dialogue87")
        Export(My.Resources.dialogue88, "dialogue88")
        Export(My.Resources.dialogue90, "dialogue90")
        Export(My.Resources.dialogue91, "dialogue91")
        Export(My.Resources.dialogue92, "dialogue92")
        Export(My.Resources.dialogue93, "dialogue93")
        Export(My.Resources.dialogue94, "dialogue94")
        Export(My.Resources.dialogue95, "dialogue95")
        Export(My.Resources.dialogue96, "dialogue96")
        Export(My.Resources.dialogue97, "dialogue97")
        Export(My.Resources.dialogue98, "dialogue98")
        Export(My.Resources.dialogue99, "dialogue99")
        Export(My.Resources.For_The_Win, "music18")
        Export(My.Resources.Atropos_spell, "image39")
        Export(My.Resources.Atropos_phone, "image40")
        Export(My.Resources.Atropos_statue1, "image41")
        Export(My.Resources.Atropos_statue2, "image42")
        Export(My.Resources.Mr_Duck, "image43")
        Export(My.Resources.Mr_Duck_phantom, "image44")
        Export(My.Resources.short_magic, "sound64")
        Export(My.Resources.long_magic, "sound65")
        Export(My.Resources.Mr_Duck_phantom_shot, "image45")
        Export(My.Resources.dialogue100, "dialogue100")
        Export(My.Resources.dialogue101, "dialogue101")
        Export(My.Resources.background1, "background1")
        Export(My.Resources.sounds_sfx_pck_0000001667, "victory2")
        Export(My.Resources.NewScene1, "NewScene1")
        Export(My.Resources.NewIntro1, "NewScene-1")
        Export(My.Resources.NewIntro2, "NewScene-2")
        Export(My.Resources.NewIntro3, "NewScene-3")
        Export(My.Resources.NewIntro4, "NewScene-4")
        Export(My.Resources.NewIntro5, "NewScene-5")
        Export(My.Resources.NewIntro6, "NewScene-6")
        Export(My.Resources.NewIntro7, "NewScene-7")
        Export(My.Resources.newvoice1, "newvoice1")
        Export(My.Resources.newvoice2, "newvoice2")
        Export(My.Resources.newvoice3, "newvoice3")
        Export(My.Resources.newvoice4, "newvoice4")
        Export(My.Resources.newvoice5, "newvoice5")
        Export(My.Resources.scathach, "image46")
        Export(My.Resources.newvoice6, "newvoice6")
        Export(My.Resources.newvoice7, "newvoice7")
        Export(My.Resources.newvoice8, "newvoice8")
        Export(My.Resources.highlaser, "sound66")
        Export(My.Resources.imm, "sound67")
        Export(My.Resources.magichole, "image47")
        Export(My.Resources.TurkeyMusic, "music19")
        Export(My.Resources.newvoice9, "newvoice9")
        Export(My.Resources.newvoice10, "newvoice10")
        Export(My.Resources.newvoice11, "newvoice11")
        Export(My.Resources.newvoice12, "newvoice12")
        Export(My.Resources.barrack1, "NewScene2")
        Export(My.Resources.barrack2, "NewScene3")
        Export(My.Resources.barrack3, "NewScene4")
        Export(My.Resources.barrack4, "NewScene5")
        Export(My.Resources.barrack5, "NewScene6")
        Export(My.Resources.barrack6, "NewScene7")
        Export(My.Resources.barrack7, "NewScene8")
        Export(My.Resources.barrack8, "NewScene9")
        Export(My.Resources.barrack9, "NewScene10")
        Export(My.Resources.barrack10, "NewScene11")
        Export(My.Resources.barrack11, "NewScene12")
        Export(My.Resources.drillmaster, "image48")
        Export(My.Resources.newvoice13, "newvoice13")
        Export(My.Resources.newvoice14, "newvoice14")
        Export(My.Resources.newvoice15, "newvoice15")
        Export(My.Resources.newvoice16, "newvoice16")
        Export(My.Resources.pontiff, "image49")
        Export(My.Resources.NewScene13, "NewScene13")
        Export(My.Resources.tentacle, "image50")
        Export(My.Resources.magic_circle, "image51")
        Export(My.Resources.cardback, "image52")
        Export(My.Resources.grail_rider, "image53")
        Export(My.Resources.soldier_distorted, "image54")
        Export(My.Resources.NewScene14, "NewScene14")
        Export(My.Resources.newvoice17, "newvoice17")
        Export(My.Resources.newvoice18, "newvoice18")
        Export(My.Resources.sword, "image55")
        Export(My.Resources.small_dormitory, "NewScene15")
        Export(My.Resources.laughter, "sound68")
        Export(My.Resources.newvoice19, "newvoice19")
        Export(My.Resources.newvoice20, "newvoice20")
        Export(My.Resources.newvoice21, "newvoice21")
        Export(My.Resources.new_mission, "sound69")
        Export(My.Resources.mission_completed, "sound70")
        Export(My.Resources.warning, "image56")
        Export(My.Resources.canteen_outside, "NewScene16")
        Export(My.Resources.canteen, "NewScene17")
        Export(My.Resources.newvoice22, "newvoice22")
        Export(My.Resources.newvoice23, "newvoice23")
        Export(My.Resources.newvoice24, "newvoice24")
        Export(My.Resources.newvoice25, "newvoice25")
        Export(My.Resources.newvoice26, "newvoice26")
        Export(My.Resources.newvoice27, "newvoice27")
        Export(My.Resources.newvoice28, "newvoice28")
        Export(My.Resources.defeatsign, "image57")
        Export(My.Resources.NewScene18, "NewScene18")
        Export(My.Resources.NewScene19, "NewScene19")
        Export(My.Resources.NewScene20, "NewScene20")
        Export(My.Resources.NewScene21, "NewScene21")
        '特别注意！下一次统一测试前必须对Form1进行渐变效果附加！
        Export(My.Resources.NewScene22, "NewScene22")
        Export(My.Resources.NewScene23, "NewScene23")
        Export(My.Resources.NewScene24, "NewScene24")
        Export(My.Resources.NewScene25, "NewScene25")
        Export(My.Resources.NewScene26, "NewScene26")
        Export(My.Resources.NewScene27, "NewScene27")
        Export(My.Resources.NewScene28_1, "NewScene28_1")
        Export(My.Resources.NewScene28_2, "NewScene28_2")
        Export(My.Resources.NewScene28_3, "NewScene28_3")
        Export(My.Resources.NewScene29, "NewScene29")
        '特别注意！下一次统一测试前必须对Form1进行渐变效果附加！


        s.Close()
        Dim fileInfo As New FileInfo(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files")
        fileInfo.Attributes = FileAttributes.Hidden
        'Shell(Application.ExecutablePath, vbNormalFocus)
        End
        Exit Sub
    End Sub

    Private Sub Export(resourceItem As Byte(), path As String)
        s = File.Create(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\temporary files\" & path & ".wm")
        s.Write(resourceItem, 0, resourceItem.Length)
    End Sub
End Class