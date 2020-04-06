<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form6
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form6))
        Me.content = New System.Windows.Forms.Label()
        Me.next_ = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'content
        '
        Me.content.Font = New System.Drawing.Font("微软雅黑", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.content.ForeColor = System.Drawing.Color.Black
        Me.content.Location = New System.Drawing.Point(12, 9)
        Me.content.Name = "content"
        Me.content.Size = New System.Drawing.Size(513, 148)
        Me.content.TabIndex = 2
        Me.content.Text = "There's voice in office."
        '
        'next_
        '
        Me.next_.Font = New System.Drawing.Font("华文细黑", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.next_.Location = New System.Drawing.Point(255, 160)
        Me.next_.Name = "next_"
        Me.next_.Size = New System.Drawing.Size(270, 81)
        Me.next_.TabIndex = 3
        Me.next_.Text = "Next."
        Me.next_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.next_.UseVisualStyleBackColor = True
        '
        'Form6
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(537, 253)
        Me.Controls.Add(Me.next_)
        Me.Controls.Add(Me.content)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form6"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Information"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents content As Label
    Friend WithEvents next_ As Button
End Class
