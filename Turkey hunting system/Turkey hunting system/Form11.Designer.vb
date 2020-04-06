<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form11
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Form1.ExitProgram()
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form11))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.title = New System.Windows.Forms.Label()
        Me.content = New System.Windows.Forms.Label()
        Me.Images = New System.Windows.Forms.ImageList(Me.components)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.match = New System.Windows.Forms.TextBox()
        Me.microscope = New System.Windows.Forms.ProgressBar()
        Me.microtime = New System.Windows.Forms.Timer(Me.components)
        CType(Me.PictureBox1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(9, 10)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(225, 260)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = false
        '
        'title
        '
        Me.title.Font = New System.Drawing.Font("Cambria", 24!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.title.Location = New System.Drawing.Point(238, 8)
        Me.title.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.title.Name = "title"
        Me.title.Size = New System.Drawing.Size(264, 43)
        Me.title.TabIndex = 1
        Me.title.Text = "Unable to enter"
        Me.title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'content
        '
        Me.content.Font = New System.Drawing.Font("Cambria", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.content.Location = New System.Drawing.Point(238, 51)
        Me.content.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.content.Name = "content"
        Me.content.Size = New System.Drawing.Size(264, 149)
        Me.content.TabIndex = 2
        Me.content.Text = "Oh my god! The English teacher has set corona ball near the door, it starts to at"& _ 
    "tack! You must defeat it or it won't stop."&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Images
        '
        Me.Images.ImageStream = CType(resources.GetObject("Images.ImageStream"),System.Windows.Forms.ImageListStreamer)
        Me.Images.TransparentColor = System.Drawing.Color.Transparent
        Me.Images.Images.SetKeyName(0, "%B4%AB%B4%AB%B8%D0%D3%EB%CE%DBȾ.jpg")
        Me.Images.Images.SetKeyName(1, "1497_P_1343410563834.jpg")
        Me.Images.Images.SetKeyName(2, "47.jpg")
        Me.Images.Images.SetKeyName(3, "78408665_p0.png")
        Me.Images.Images.SetKeyName(4, "timg.jpg")
        Me.Images.Images.SetKeyName(5, "medium_3_ac736eae931eaba9139086e94c029982.jpg")
        Me.Images.Images.SetKeyName(6, "677a8a7fjw1eu6x2w8g9kj21400o0gpg.jpg")
        Me.Images.Images.SetKeyName(7, "sy_201206181604233300.jpg")
        Me.Images.Images.SetKeyName(8, "78408665_p0 - Copy.png")
        Me.Images.Images.SetKeyName(9, "201601280255366903.jpg")
        Me.Images.Images.SetKeyName(10, "20140129143018-1177674112.png")
        Me.Images.Images.SetKeyName(11, "98361.jpg")
        Me.Images.Images.SetKeyName(12, "Image 1.jpg")
        Me.Images.Images.SetKeyName(13, "n33N8iFSpaRjv1QrHTSHRA==_7916887240756495370.jpg")
        Me.Images.Images.SetKeyName(14, "ori_53158955b6fe3.jpg")
        Me.Images.Images.SetKeyName(15, "20130314103812.jpg")
        Me.Images.Images.SetKeyName(16, "Mr.Duck.jpg")
        Me.Images.Images.SetKeyName(17, "battler6.png")
        Me.Images.Images.SetKeyName(18, "64380cd7912397dd885bed545b82b2b7d0a287bb.jpg")
        Me.Images.Images.SetKeyName(19, "b201303111448108772.jpg")
        Me.Images.Images.SetKeyName(20, "9c88cab1tbf69777a5fa6&690.jpg")
        Me.Images.Images.SetKeyName(21, "48246f1f-6226-420d-88f1-a01342deeb4c.jpg")
        Me.Images.Images.SetKeyName(22, "18839336_092827461129_2.jpg")
        Me.Images.Images.SetKeyName(23, "654c472cnd162d9a5b6d3&690.jpg")
        Me.Images.Images.SetKeyName(24, "58fe66e3565677662488e.jpg")
        Me.Images.Images.SetKeyName(25, "20120120224820_QmZWx.thumb.600_0.jpg")
        Me.Images.Images.SetKeyName(26, "040411_83441_content.jpg")
        Me.Images.Images.SetKeyName(27, "20160817015522412.jpg")
        Me.Images.Images.SetKeyName(28, "7b1fb4ec08fa513d588eec9c3c6d55fbb3fbd9d9.jpg")
        Me.Images.Images.SetKeyName(29, "wKhQcFRbCvmEbrOtAAAAAHu41Oc898.jpg")
        Me.Images.Images.SetKeyName(30, "20141206214153_nGHff.jpeg")
        Me.Images.Images.SetKeyName(31, "gpic722.jpg")
        Me.Images.Images.SetKeyName(32, "IMG_0683.JPG")
        Me.Images.Images.SetKeyName(33, "132453607_title1n.jpg")
        Me.Images.Images.SetKeyName(34, "13-169296733.jpg")
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Cambria", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Button1.Location = New System.Drawing.Point(238, 236)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(264, 35)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Go out from inside."
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.UseVisualStyleBackColor = true
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Cambria", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Button2.Location = New System.Drawing.Point(238, 196)
        Me.Button2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(264, 35)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Use six god to dispel."
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.UseVisualStyleBackColor = true
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Cambria", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Button3.Location = New System.Drawing.Point(238, 156)
        Me.Button3.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(264, 35)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "Rush without defending."
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.UseVisualStyleBackColor = true
        '
        'match
        '
        Me.match.BackColor = System.Drawing.Color.White
        Me.match.Font = New System.Drawing.Font("DengXian", 42!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134,Byte))
        Me.match.Location = New System.Drawing.Point(9, 10)
        Me.match.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.match.Name = "match"
        Me.match.ReadOnly = true
        Me.match.Size = New System.Drawing.Size(226, 66)
        Me.match.TabIndex = 6
        Me.match.Text = "100"
        Me.match.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.match.Visible = false
        '
        'microscope
        '
        Me.microscope.Location = New System.Drawing.Point(9, 10)
        Me.microscope.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.microscope.Name = "microscope"
        Me.microscope.Size = New System.Drawing.Size(225, 17)
        Me.microscope.TabIndex = 7
        Me.microscope.Tag = "0"
        Me.microscope.Visible = false
        '
        'microtime
        '
        Me.microtime.Interval = 10
        '
        'Form11
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(512, 281)
        Me.Controls.Add(Me.microscope)
        Me.Controls.Add(Me.match)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.content)
        Me.Controls.Add(Me.title)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "Form11"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Active Window"
        CType(Me.PictureBox1,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents title As Label
    Friend WithEvents content As Label
    Friend WithEvents Images As ImageList
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents match As TextBox
    Friend WithEvents microscope As ProgressBar
    Friend WithEvents microtime As Timer
End Class
