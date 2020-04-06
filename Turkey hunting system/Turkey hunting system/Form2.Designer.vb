<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form2
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Me.title = New System.Windows.Forms.Label()
        Me.content = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'title
        '
        Me.title.AutoSize = True
        Me.title.Font = New System.Drawing.Font("微软雅黑", 22.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.title.Location = New System.Drawing.Point(12, 9)
        Me.title.Name = "title"
        Me.title.Size = New System.Drawing.Size(371, 50)
        Me.title.TabIndex = 0
        Me.title.Text = "Prologue of legend"
        '
        'content
        '
        Me.content.Font = New System.Drawing.Font("微软雅黑", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.content.Location = New System.Drawing.Point(12, 59)
        Me.content.Name = "content"
        Me.content.Size = New System.Drawing.Size(508, 279)
        Me.content.TabIndex = 1
        Me.content.Text = resources.GetString("content.Text")
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("微软雅黑", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Button1.Location = New System.Drawing.Point(253, 326)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(250, 50)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Next→"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("微软雅黑", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(499, 381)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Extracting files..."
        Me.Label1.Visible = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 1
        '
        'Timer2
        '
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 15
        Me.ListBox1.Items.AddRange(New Object() {"music1", "sound1", "sound3", "sound4", "sound5", "sound6", "sound7", "sound8", "scene1", "battler1", "sound9", "sound10", "scene2", "scene3", "scene4", "scene5", "scene6", "sound11", "scene7", "sound12", "sound13", "battler2", "music5", "sound14", "sound15", "sound16", "battler3", "sound17", "sound18", "sound19", "sound20", "sound21", "sound22", "music7", "music8", "music9", "sound23", "sound24", "sound25", "scene8", "scene9", "scene10", "battler4", "scene11", "scene12", "scene13", "scene14", "sound26", "sound27", "battler5_1", "battler5_2", "battler5_3", "battler5_4", "battler6", "sound28", "battler8", "music10", "prelude1", "background1", "sound29", "sound30", "victory1", "sound31", "scene15", "sound32", "sound33", "battler9", "sound34", "sound35", "sound36", "sound37", "sound38", "battler10", "scene16", "scene17", "potion2", "potion3", "potion4", "potion5", "potion6", "music11", "scene18", "scene19", "intro1", "intro2", "intro3", "intro4", "intro5", "scene20", "sound41", "battler11", "sound42", "intro6", "intro7", "intro8", "intro9", "intro10", "intro11", "intro12", "sound43", "scene21", "scene22", "scene23", "sound44", "sound45", "battler12", "scene24", "sound46", "sound47", "sound48", "scene25", "intro13", "intro14", "intro15", "intro16", "intro17", "voice1", "voice2", "voice3", "voice4", "voice5", "voice6", "voice7", "voice8", "voice9", "voice10", "voice11", "voice12", "voice13", "voice14", "voice15", "voice16", "voice17", "scene26", "scene27", "scene28", "scene29", "scene30", "scene31", "scene32", "scene33", "music13", "music12", "image1", "scene34", "scene35", "music14", "image2", "scene36", "dialogue1", "dialogue2", "dialogue3", "dialogue4", "dialogue5", "scene37", "scene38", "scene39", "battler13", "scene40", "scene41", "dialogue6", "dialogue7", "dialogue8", "dialogue9", "dialogue10", "scene42", "scene43", "scene44", "scene45", "image3", "image4", "image5", "scene46", "scene47", "scene48", "scene49", "scene50", "image6", "image7", "scene51", "scene52", "scene53", "scene54", "scene55", "scene56", "intro18", "intro19", "intro20", "scene56", "scene57", "battler14", "music15", "sound49", "sound50", "sound51", "voice18", "image8", "image9", "music16", "scene58", "scene59", "scene60", "scene61", "voice19", "voice20", "voice21", "voice22", "dialogue11", "dialogue12", "dialogue13", "battler15", "sound52", "sound53", "dialogue14", "dialogue15", "dialogue16", "dialogue17", "dialogue18", "scene64", "dialogue19", "dialogue20", "dialogue21", "scene65", "scene66", "scene67", "scene68", "dialogue22", "dialogue23", "dialogue24", "image10", "image11", "image12", "image13", "image14", "image15", "dialogue25", "dialogue26", "dialogue27", "dialogue28", "dialogue29", "dialogue30", "dialogue31", "dialogue32", "dialogue33", "dialogue34", "dialogue35", "image16", "image17", "dialogue36", "dialogue37", "dialogue38", "dialogue39", "dialogue40", "dialogue41", "dialogue42", "scene69", "scene70", "scene71", "scene72", "image18", "image19", "image20", "image21", "scene73", "scene74", "sound54", "scene76", "intro21", "scene77", "dialogue43", "sound55", "intro22", "dialogue44", "dialogue45", "dialogue46", "image23", "image24", "sound56", "image25", "dialogue47", "dialogue48", "dialogue49", "dialogue50", "dialogue51", "sound57", "sound58", "dialogue52", "dialogue53", "sound59", "scene78", "scene79", "scene80", "scene81", "scene82", "battler16", "scene83", "scene84", "scene85", "scene86", "scene87", "scene88", "scene89", "scene90", "scene91", "image26", "image27", "image28", "scene92", "sound60", "dialogue56", "scene93", "scene94", "battler18", "battler19", "battler20", "dialogue57", "dialogue58", "scene95", "scene96", "scene97", "image29", "image30", "image31", "intro23", "dialogue59", "dialogue60", "dialogue61", "intro24", "dialogue62", "music17", "dialogue63", "dialogue64", "dialogue65", "dialogue66", "dialogue67", "dialogue68", "dialogue69", "scene98", "scene99", "scene100", "scene101", "scene102", "scene103", "scene104", "scene105", "scene106", "scene107", "scene108", "scene109", "scene110", "scene111", "scene112", "scene113", "scene114", "scene115", "scene116", "scene117", "scene118", "image33", "image34", "sound61", "image35", "dialogue70", "dialogue71", "dialogue72", "dialogue73", "sound62", "image36", "image37", "image38", "dialogue74", "dialogue75", "dialogue76", "dialogue77", "dialogue78", "sound63", "dialogue79", "dialogue80", "dialogue81", "dialogue82", "dialogue83", "dialogue84", "dialogue85", "dialogue86", "dialogue87", "dialogue88", "dialogue90", "dialogue91", "dialogue92", "dialogue93", "dialogue94", "dialogue95", "dialogue96", "dialogue97", "dialogue98", "dialogue99", "music18", "image39", "image40", "image41", "image42", "sound64", "sound65", "image43", "image44", "image45", "dialogue100", "dialogue101", "background1", "victory2", "NewScene1", "NewScene-1", "NewScene-2", "NewScene-3", "NewScene-4", "NewScene-5", "NewScene-6", "NewScene-7", "newvoice1", "newvoice2", "newvoice3", "newvoice4", "newvoice5", "image46", "newvoice6", "newvoice7", "newvoice8", "sound66", "sound67", "image47", "music19", "newvoice9", "newvoice10", "newvoice11", "newvoice12", "NewScene2", "NewScene3", "NewScene4", "NewScene5", "NewScene6", "NewScene7", "NewScene8", "NewScene9", "NewScene10", "NewScene11", "NewScene12", "image48", "newvoice13", "newvoice14", "newvoice15", "newvoice16", "image49", "NewScene13", "image50", "image51", "image52", "image53", "image54", "NewScene14", "newvoice17", "newvoice18", "image55", "NewScene15", "sound68", "newvoice19", "newvoice20", "newvoice21", "sound69", "sound70", "image56", "NewScene16", "NewScene17", "newvoice22", "newvoice23", "newvoice24", "newvoice25", "newvoice26", "newvoice27", "newvoice28", "image57", "NewScene18", "NewScene19", "NewScene20", "NewScene21", "NewScene22", "NewScene23", "NewScene24", "NewScene25", "NewScene26", "NewScene27", "NewScene28_1", "NewScene28_2", "NewScene28_3", "NewScene29"})
        Me.ListBox1.Location = New System.Drawing.Point(12, 12)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(525, 409)
        Me.ListBox1.TabIndex = 4
        Me.ListBox1.Visible = False
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(535, 424)
        Me.ControlBox = False
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.content)
        Me.Controls.Add(Me.title)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form2"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Prologue"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents title As Label
    Friend WithEvents content As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Timer2 As Timer
    Friend WithEvents ListBox1 As ListBox
End Class
