<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form5
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form5))
        Me.content = New System.Windows.Forms.Label()
        Me.bar = New System.Windows.Forms.ProgressBar()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout
        '
        'content
        '
        Me.content.Font = New System.Drawing.Font("Microsoft YaHei", 18!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134,Byte))
        Me.content.ForeColor = System.Drawing.Color.Black
        Me.content.Location = New System.Drawing.Point(9, 8)
        Me.content.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.content.Name = "content"
        Me.content.Size = New System.Drawing.Size(385, 128)
        Me.content.TabIndex = 2
        Me.content.Text = "Please wait while we're catching turkey."
        '
        'bar
        '
        Me.bar.Location = New System.Drawing.Point(9, 237)
        Me.bar.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.bar.Name = "bar"
        Me.bar.Size = New System.Drawing.Size(385, 20)
        Me.bar.TabIndex = 3
        '
        'Timer1
        '
        '
        'Form5
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Yellow
        Me.ClientSize = New System.Drawing.Size(403, 267)
        Me.Controls.Add(Me.bar)
        Me.Controls.Add(Me.content)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "Form5"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Please wait..."
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents content As Label
    Friend WithEvents bar As ProgressBar
    Friend WithEvents Timer1 As Timer
End Class
