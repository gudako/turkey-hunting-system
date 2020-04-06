<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form12
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        UnifiedAction()
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form12))
        Me.skillt = New System.Windows.Forms.Label()
        Me.skill = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.content = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.manacost = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'skillt
        '
        Me.skillt.BackColor = System.Drawing.Color.White
        Me.skillt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.skillt.Font = New System.Drawing.Font("微软雅黑", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.skillt.Location = New System.Drawing.Point(12, 74)
        Me.skillt.Name = "skillt"
        Me.skillt.Size = New System.Drawing.Size(160, 90)
        Me.skillt.TabIndex = 4
        Me.skillt.Text = "Slow down your enemy's cool down."
        '
        'skill
        '
        Me.skill.BackColor = System.Drawing.Color.White
        Me.skill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.skill.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.skill.Location = New System.Drawing.Point(12, 45)
        Me.skill.Name = "skill"
        Me.skill.Size = New System.Drawing.Size(160, 30)
        Me.skill.TabIndex = 3
        Me.skill.Text = "Splash"
        Me.skill.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微软雅黑", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(251, 36)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Select your magic"
        '
        'ListBox1
        '
        Me.ListBox1.Font = New System.Drawing.Font("Cambria", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 27
        Me.ListBox1.Items.AddRange(New Object() {"Water egg", "Mirror", "Fireball"})
        Me.ListBox1.Location = New System.Drawing.Point(178, 48)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(217, 112)
        Me.ListBox1.TabIndex = 6
        '
        'content
        '
        Me.content.Font = New System.Drawing.Font("Cambria", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.content.Location = New System.Drawing.Point(12, 164)
        Me.content.Name = "content"
        Me.content.Size = New System.Drawing.Size(383, 140)
        Me.content.TabIndex = 7
        Me.content.Text = "Each magic item can enable a magic skill, in one battle you can only bring one ma" &
    "gic power. Each magic skill has different charge time and cool down time."
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Consolas", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(195, 307)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(200, 40)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "To Battle."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 10
        '
        'manacost
        '
        Me.manacost.BackColor = System.Drawing.Color.White
        Me.manacost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.manacost.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.manacost.ForeColor = System.Drawing.Color.Blue
        Me.manacost.Location = New System.Drawing.Point(132, 139)
        Me.manacost.Name = "manacost"
        Me.manacost.Size = New System.Drawing.Size(40, 25)
        Me.manacost.TabIndex = 9
        Me.manacost.Text = "20"
        Me.manacost.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.manacost.Visible = False
        '
        'Form12
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(407, 359)
        Me.Controls.Add(Me.manacost)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.content)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.skillt)
        Me.Controls.Add(Me.skill)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form12"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Choose your magic"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents skillt As Label
    Friend WithEvents skill As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents content As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents manacost As Label
End Class
