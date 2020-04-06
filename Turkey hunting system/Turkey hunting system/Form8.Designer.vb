<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form8
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form8))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.skill1 = New System.Windows.Forms.Label()
        Me.skill1t = New System.Windows.Forms.Label()
        Me.skill2t = New System.Windows.Forms.Label()
        Me.skill2 = New System.Windows.Forms.Label()
        Me.skill3t = New System.Windows.Forms.Label()
        Me.skill3 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.EnemyName = New System.Windows.Forms.Label()
        Me.start = New System.Windows.Forms.Button()
        Me.boss = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微软雅黑", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(326, 31)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Here're your enemy's skills:"
        '
        'skill1
        '
        Me.skill1.BackColor = System.Drawing.Color.White
        Me.skill1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.skill1.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.skill1.Location = New System.Drawing.Point(12, 71)
        Me.skill1.Name = "skill1"
        Me.skill1.Size = New System.Drawing.Size(160, 30)
        Me.skill1.TabIndex = 1
        Me.skill1.Text = "Bump"
        Me.skill1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'skill1t
        '
        Me.skill1t.BackColor = System.Drawing.Color.White
        Me.skill1t.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.skill1t.Font = New System.Drawing.Font("微软雅黑", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.skill1t.Location = New System.Drawing.Point(12, 100)
        Me.skill1t.Name = "skill1t"
        Me.skill1t.Size = New System.Drawing.Size(160, 90)
        Me.skill1t.TabIndex = 2
        Me.skill1t.Text = "Cause 12 damage."
        '
        'skill2t
        '
        Me.skill2t.BackColor = System.Drawing.Color.White
        Me.skill2t.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.skill2t.Font = New System.Drawing.Font("微软雅黑", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.skill2t.Location = New System.Drawing.Point(178, 100)
        Me.skill2t.Name = "skill2t"
        Me.skill2t.Size = New System.Drawing.Size(160, 90)
        Me.skill2t.TabIndex = 4
        Me.skill2t.Text = "Unable."
        '
        'skill2
        '
        Me.skill2.BackColor = System.Drawing.Color.White
        Me.skill2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.skill2.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.skill2.Location = New System.Drawing.Point(178, 71)
        Me.skill2.Name = "skill2"
        Me.skill2.Size = New System.Drawing.Size(160, 30)
        Me.skill2.TabIndex = 3
        Me.skill2.Text = "Defend"
        Me.skill2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'skill3t
        '
        Me.skill3t.BackColor = System.Drawing.Color.White
        Me.skill3t.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.skill3t.Font = New System.Drawing.Font("微软雅黑", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.skill3t.Location = New System.Drawing.Point(344, 100)
        Me.skill3t.Name = "skill3t"
        Me.skill3t.Size = New System.Drawing.Size(160, 90)
        Me.skill3t.TabIndex = 6
        Me.skill3t.Text = "Unable."
        '
        'skill3
        '
        Me.skill3.BackColor = System.Drawing.Color.White
        Me.skill3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.skill3.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.skill3.Location = New System.Drawing.Point(344, 71)
        Me.skill3.Name = "skill3"
        Me.skill3.Size = New System.Drawing.Size(160, 30)
        Me.skill3.TabIndex = 5
        Me.skill3.Text = "Magic"
        Me.skill3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("微软雅黑", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label8.Location = New System.Drawing.Point(12, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(148, 31)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "The enemy:"
        '
        'EnemyName
        '
        Me.EnemyName.BackColor = System.Drawing.Color.White
        Me.EnemyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.EnemyName.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.EnemyName.Location = New System.Drawing.Point(166, 9)
        Me.EnemyName.Name = "EnemyName"
        Me.EnemyName.Size = New System.Drawing.Size(338, 31)
        Me.EnemyName.TabIndex = 8
        Me.EnemyName.Text = "Turkey egg"
        Me.EnemyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'start
        '
        Me.start.Font = New System.Drawing.Font("微软雅黑", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.start.Location = New System.Drawing.Point(254, 193)
        Me.start.Name = "start"
        Me.start.Size = New System.Drawing.Size(250, 50)
        Me.start.TabIndex = 9
        Me.start.Text = "Start!"
        Me.start.UseVisualStyleBackColor = True
        '
        'boss
        '
        Me.boss.Font = New System.Drawing.Font("微软雅黑", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.boss.ForeColor = System.Drawing.Color.Red
        Me.boss.Location = New System.Drawing.Point(12, 193)
        Me.boss.Name = "boss"
        Me.boss.Size = New System.Drawing.Size(236, 50)
        Me.boss.TabIndex = 10
        Me.boss.Text = "BOSS"
        Me.boss.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.boss.Visible = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 10000
        Me.ToolTip1.InitialDelay = 500
        Me.ToolTip1.ReshowDelay = 100
        '
        'Form8
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(516, 255)
        Me.Controls.Add(Me.boss)
        Me.Controls.Add(Me.start)
        Me.Controls.Add(Me.EnemyName)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.skill3t)
        Me.Controls.Add(Me.skill3)
        Me.Controls.Add(Me.skill2t)
        Me.Controls.Add(Me.skill2)
        Me.Controls.Add(Me.skill1t)
        Me.Controls.Add(Me.skill1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form8"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Battle status"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents skill1 As Label
    Friend WithEvents skill1t As Label
    Friend WithEvents skill2t As Label
    Friend WithEvents skill2 As Label
    Friend WithEvents skill3t As Label
    Friend WithEvents skill3 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents EnemyName As Label
    Friend WithEvents start As Button
    Friend WithEvents boss As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents ToolTip1 As ToolTip
End Class
