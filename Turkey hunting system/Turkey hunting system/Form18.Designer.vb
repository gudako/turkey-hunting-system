<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form18
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Hide()
        Form1.Show()
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form18))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DomainUpDown1 = New System.Windows.Forms.DomainUpDown()
        Me.DomainUpDown2 = New System.Windows.Forms.DomainUpDown()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DomainUpDown2)
        Me.GroupBox1.Controls.Add(Me.DomainUpDown1)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.ComboBox2)
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("微软雅黑", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(482, 454)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "solve the function!"
        Me.GroupBox1.Visible = False
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(12, 268)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(458, 130)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "The door has Mr.Duck's function lock, you can't open unless you solve it. You can" &
    " find the ""a"" in a Mermaid."
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(310, 401)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(160, 40)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "Exit"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(144, 401)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(160, 40)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "Complete"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("微软雅黑", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label4.Location = New System.Drawing.Point(249, 225)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(22, 36)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = ","
        '
        'ComboBox2
        '
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {")", "]"})
        Me.ComboBox2.Location = New System.Drawing.Point(379, 227)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(38, 38)
        Me.ComboBox2.TabIndex = 5
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {")", "]"})
        Me.ComboBox1.Location = New System.Drawing.Point(103, 226)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ComboBox1.Size = New System.Drawing.Size(38, 38)
        Me.ComboBox1.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("微软雅黑", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 225)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 36)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "f(x)∈"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(12, 157)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(458, 66)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "x∈[-1,0]" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "enter the range of function f(x)."
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 64)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(399, 90)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(458, 27)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "As for function:"
        '
        'DomainUpDown1
        '
        Me.DomainUpDown1.Items.Add("+∞")
        Me.DomainUpDown1.Items.Add("10")
        Me.DomainUpDown1.Items.Add("5")
        Me.DomainUpDown1.Items.Add("3")
        Me.DomainUpDown1.Items.Add("2")
        Me.DomainUpDown1.Items.Add("1.5")
        Me.DomainUpDown1.Items.Add("1")
        Me.DomainUpDown1.Items.Add("0.5")
        Me.DomainUpDown1.Items.Add("0")
        Me.DomainUpDown1.Items.Add("-0.5")
        Me.DomainUpDown1.Items.Add("-1")
        Me.DomainUpDown1.Items.Add("-1.5")
        Me.DomainUpDown1.Items.Add("-2")
        Me.DomainUpDown1.Items.Add("-3")
        Me.DomainUpDown1.Items.Add("-5")
        Me.DomainUpDown1.Items.Add("-10")
        Me.DomainUpDown1.Items.Add("-∞")
        Me.DomainUpDown1.Location = New System.Drawing.Point(147, 226)
        Me.DomainUpDown1.Name = "DomainUpDown1"
        Me.DomainUpDown1.Size = New System.Drawing.Size(96, 38)
        Me.DomainUpDown1.TabIndex = 12
        Me.DomainUpDown1.Text = "DomainUpDown1"
        '
        'DomainUpDown2
        '
        Me.DomainUpDown2.Items.Add("+∞")
        Me.DomainUpDown2.Items.Add("10")
        Me.DomainUpDown2.Items.Add("5")
        Me.DomainUpDown2.Items.Add("3")
        Me.DomainUpDown2.Items.Add("2")
        Me.DomainUpDown2.Items.Add("1.5")
        Me.DomainUpDown2.Items.Add("1")
        Me.DomainUpDown2.Items.Add("0.5")
        Me.DomainUpDown2.Items.Add("0")
        Me.DomainUpDown2.Items.Add("-0.5")
        Me.DomainUpDown2.Items.Add("-1")
        Me.DomainUpDown2.Items.Add("-1.5")
        Me.DomainUpDown2.Items.Add("-2")
        Me.DomainUpDown2.Items.Add("-3")
        Me.DomainUpDown2.Items.Add("-5")
        Me.DomainUpDown2.Items.Add("-10")
        Me.DomainUpDown2.Items.Add("-∞")
        Me.DomainUpDown2.Location = New System.Drawing.Point(277, 226)
        Me.DomainUpDown2.Name = "DomainUpDown2"
        Me.DomainUpDown2.Size = New System.Drawing.Size(96, 38)
        Me.DomainUpDown2.TabIndex = 13
        Me.DomainUpDown2.Text = "DomainUpDown2"
        '
        'Form18
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(482, 453)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form18"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Function"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents DomainUpDown2 As DomainUpDown
    Friend WithEvents DomainUpDown1 As DomainUpDown
End Class
