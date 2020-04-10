<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form10
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form10))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.content = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.revive = New System.Windows.Forms.Button()
        Me.SuspendLayout
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("DengXian", 22.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134,Byte))
        Me.Button1.Location = New System.Drawing.Point(202, 184)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(150, 43)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Next"
        Me.Button1.UseVisualStyleBackColor = true
        '
        'content
        '
        Me.content.Font = New System.Drawing.Font("Microsoft YaHei", 18!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134,Byte))
        Me.content.ForeColor = System.Drawing.Color.Black
        Me.content.Location = New System.Drawing.Point(9, 77)
        Me.content.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.content.Name = "content"
        Me.content.Size = New System.Drawing.Size(344, 104)
        Me.content.TabIndex = 7
        Me.content.Text = "You've been defeated by the turkey egg!"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei", 36!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134,Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(9, 8)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(344, 69)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Defeat!"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'revive
        '
        Me.revive.Font = New System.Drawing.Font("DengXian", 22.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134,Byte))
        Me.revive.Location = New System.Drawing.Point(48, 184)
        Me.revive.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.revive.Name = "revive"
        Me.revive.Size = New System.Drawing.Size(150, 43)
        Me.revive.TabIndex = 9
        Me.revive.Text = "Revive(0)"
        Me.revive.UseVisualStyleBackColor = true
        Me.revive.Visible = false
        '
        'Form10
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(362, 237)
        Me.Controls.Add(Me.revive)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.content)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "Form10"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Defeat!"
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents content As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents revive As Button
End Class
