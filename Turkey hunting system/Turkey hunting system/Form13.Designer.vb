<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form13
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form13))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.potionbox1 = New System.Windows.Forms.GroupBox()
        Me.purchase1 = New System.Windows.Forms.Button()
        Me.price1 = New System.Windows.Forms.Label()
        Me.table1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.potion1 = New System.Windows.Forms.PictureBox()
        Me.potionbox2 = New System.Windows.Forms.GroupBox()
        Me.purchase2 = New System.Windows.Forms.Button()
        Me.price2 = New System.Windows.Forms.Label()
        Me.table2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.potion2 = New System.Windows.Forms.PictureBox()
        Me.potionbox3 = New System.Windows.Forms.GroupBox()
        Me.purchase3 = New System.Windows.Forms.Button()
        Me.price3 = New System.Windows.Forms.Label()
        Me.table3 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.potion3 = New System.Windows.Forms.PictureBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.coins = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.sold = New System.Windows.Forms.Label()
        Me.potionbox1.SuspendLayout()
        CType(Me.potion1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.potionbox2.SuspendLayout()
        CType(Me.potion2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.potionbox3.SuspendLayout()
        CType(Me.potion3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微软雅黑", 22.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(484, 50)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Automatic Potion Vendor"
        '
        'potionbox1
        '
        Me.potionbox1.Controls.Add(Me.purchase1)
        Me.potionbox1.Controls.Add(Me.price1)
        Me.potionbox1.Controls.Add(Me.table1)
        Me.potionbox1.Controls.Add(Me.Label2)
        Me.potionbox1.Controls.Add(Me.potion1)
        Me.potionbox1.Font = New System.Drawing.Font("微软雅黑", 12.0!)
        Me.potionbox1.Location = New System.Drawing.Point(12, 94)
        Me.potionbox1.Name = "potionbox1"
        Me.potionbox1.Size = New System.Drawing.Size(212, 456)
        Me.potionbox1.TabIndex = 1
        Me.potionbox1.TabStop = False
        Me.potionbox1.Text = "potion"
        '
        'purchase1
        '
        Me.purchase1.Font = New System.Drawing.Font("微软雅黑", 15.0!)
        Me.purchase1.Location = New System.Drawing.Point(6, 410)
        Me.purchase1.Name = "purchase1"
        Me.purchase1.Size = New System.Drawing.Size(200, 40)
        Me.purchase1.TabIndex = 2
        Me.purchase1.Text = "Purchase"
        Me.purchase1.UseVisualStyleBackColor = True
        '
        'price1
        '
        Me.price1.BackColor = System.Drawing.Color.White
        Me.price1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.price1.Font = New System.Drawing.Font("微软雅黑", 15.0!)
        Me.price1.Location = New System.Drawing.Point(6, 362)
        Me.price1.Name = "price1"
        Me.price1.Size = New System.Drawing.Size(200, 30)
        Me.price1.TabIndex = 2
        Me.price1.Text = "0"
        Me.price1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'table1
        '
        Me.table1.Font = New System.Drawing.Font("微软雅黑", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.table1.Location = New System.Drawing.Point(10, 387)
        Me.table1.Name = "table1"
        Me.table1.Size = New System.Drawing.Size(200, 20)
        Me.table1.TabIndex = 3
        Me.table1.Text = "Solar corona coins"
        Me.table1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("微软雅黑", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 342)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(200, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Price:"
        '
        'potion1
        '
        Me.potion1.Location = New System.Drawing.Point(6, 39)
        Me.potion1.Name = "potion1"
        Me.potion1.Size = New System.Drawing.Size(200, 300)
        Me.potion1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.potion1.TabIndex = 0
        Me.potion1.TabStop = False
        '
        'potionbox2
        '
        Me.potionbox2.Controls.Add(Me.purchase2)
        Me.potionbox2.Controls.Add(Me.price2)
        Me.potionbox2.Controls.Add(Me.table2)
        Me.potionbox2.Controls.Add(Me.Label7)
        Me.potionbox2.Controls.Add(Me.potion2)
        Me.potionbox2.Font = New System.Drawing.Font("微软雅黑", 12.0!)
        Me.potionbox2.Location = New System.Drawing.Point(230, 94)
        Me.potionbox2.Name = "potionbox2"
        Me.potionbox2.Size = New System.Drawing.Size(212, 456)
        Me.potionbox2.TabIndex = 4
        Me.potionbox2.TabStop = False
        Me.potionbox2.Text = "potion"
        '
        'purchase2
        '
        Me.purchase2.Font = New System.Drawing.Font("微软雅黑", 15.0!)
        Me.purchase2.Location = New System.Drawing.Point(6, 410)
        Me.purchase2.Name = "purchase2"
        Me.purchase2.Size = New System.Drawing.Size(200, 40)
        Me.purchase2.TabIndex = 2
        Me.purchase2.Text = "Purchase"
        Me.purchase2.UseVisualStyleBackColor = True
        '
        'price2
        '
        Me.price2.BackColor = System.Drawing.Color.White
        Me.price2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.price2.Font = New System.Drawing.Font("微软雅黑", 15.0!)
        Me.price2.Location = New System.Drawing.Point(6, 362)
        Me.price2.Name = "price2"
        Me.price2.Size = New System.Drawing.Size(200, 30)
        Me.price2.TabIndex = 2
        Me.price2.Text = "0"
        Me.price2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'table2
        '
        Me.table2.Font = New System.Drawing.Font("微软雅黑", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.table2.Location = New System.Drawing.Point(10, 387)
        Me.table2.Name = "table2"
        Me.table2.Size = New System.Drawing.Size(200, 20)
        Me.table2.TabIndex = 3
        Me.table2.Text = "Solar corona coins"
        Me.table2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("微软雅黑", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 342)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(200, 20)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Price:"
        '
        'potion2
        '
        Me.potion2.Location = New System.Drawing.Point(6, 39)
        Me.potion2.Name = "potion2"
        Me.potion2.Size = New System.Drawing.Size(200, 300)
        Me.potion2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.potion2.TabIndex = 0
        Me.potion2.TabStop = False
        '
        'potionbox3
        '
        Me.potionbox3.Controls.Add(Me.purchase3)
        Me.potionbox3.Controls.Add(Me.price3)
        Me.potionbox3.Controls.Add(Me.table3)
        Me.potionbox3.Controls.Add(Me.Label10)
        Me.potionbox3.Controls.Add(Me.potion3)
        Me.potionbox3.Font = New System.Drawing.Font("微软雅黑", 12.0!)
        Me.potionbox3.Location = New System.Drawing.Point(448, 94)
        Me.potionbox3.Name = "potionbox3"
        Me.potionbox3.Size = New System.Drawing.Size(212, 456)
        Me.potionbox3.TabIndex = 4
        Me.potionbox3.TabStop = False
        Me.potionbox3.Text = "potion"
        '
        'purchase3
        '
        Me.purchase3.Font = New System.Drawing.Font("微软雅黑", 15.0!)
        Me.purchase3.Location = New System.Drawing.Point(6, 410)
        Me.purchase3.Name = "purchase3"
        Me.purchase3.Size = New System.Drawing.Size(200, 40)
        Me.purchase3.TabIndex = 2
        Me.purchase3.Text = "Purchase"
        Me.purchase3.UseVisualStyleBackColor = True
        '
        'price3
        '
        Me.price3.BackColor = System.Drawing.Color.White
        Me.price3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.price3.Font = New System.Drawing.Font("微软雅黑", 15.0!)
        Me.price3.Location = New System.Drawing.Point(6, 362)
        Me.price3.Name = "price3"
        Me.price3.Size = New System.Drawing.Size(200, 30)
        Me.price3.TabIndex = 2
        Me.price3.Text = "0"
        Me.price3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'table3
        '
        Me.table3.Font = New System.Drawing.Font("微软雅黑", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.table3.Location = New System.Drawing.Point(10, 387)
        Me.table3.Name = "table3"
        Me.table3.Size = New System.Drawing.Size(200, 20)
        Me.table3.TabIndex = 3
        Me.table3.Text = "Solar corona coins"
        Me.table3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("微软雅黑", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label10.Location = New System.Drawing.Point(6, 342)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(200, 20)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Price:"
        '
        'potion3
        '
        Me.potion3.Location = New System.Drawing.Point(6, 39)
        Me.potion3.Name = "potion3"
        Me.potion3.Size = New System.Drawing.Size(200, 300)
        Me.potion3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.potion3.TabIndex = 0
        Me.potion3.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("微软雅黑", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label11.Location = New System.Drawing.Point(12, 59)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(304, 32)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "Your solar corona coins:"
        '
        'coins
        '
        Me.coins.BackColor = System.Drawing.Color.White
        Me.coins.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.coins.Font = New System.Drawing.Font("微软雅黑", 15.0!)
        Me.coins.Location = New System.Drawing.Point(322, 59)
        Me.coins.Name = "coins"
        Me.coins.Size = New System.Drawing.Size(200, 32)
        Me.coins.TabIndex = 6
        Me.coins.Tag = "0"
        Me.coins.Text = "0"
        Me.coins.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("微软雅黑", 15.0!)
        Me.Button1.Location = New System.Drawing.Point(460, 556)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(200, 40)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Exit"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'sold
        '
        Me.sold.AutoSize = True
        Me.sold.Font = New System.Drawing.Font("微软雅黑", 22.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.sold.Location = New System.Drawing.Point(168, 217)
        Me.sold.Name = "sold"
        Me.sold.Size = New System.Drawing.Size(335, 50)
        Me.sold.TabIndex = 4
        Me.sold.Text = "None Item Inside"
        '
        'Form13
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(672, 608)
        Me.Controls.Add(Me.sold)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.coins)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.potionbox3)
        Me.Controls.Add(Me.potionbox2)
        Me.Controls.Add(Me.potionbox1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form13"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Chemical potion"
        Me.potionbox1.ResumeLayout(False)
        CType(Me.potion1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.potionbox2.ResumeLayout(False)
        CType(Me.potion2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.potionbox3.ResumeLayout(False)
        CType(Me.potion3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents potionbox1 As GroupBox
    Friend WithEvents purchase1 As Button
    Friend WithEvents price1 As Label
    Friend WithEvents table1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents potion1 As PictureBox
    Friend WithEvents potionbox2 As GroupBox
    Friend WithEvents purchase2 As Button
    Friend WithEvents price2 As Label
    Friend WithEvents table2 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents potion2 As PictureBox
    Friend WithEvents potionbox3 As GroupBox
    Friend WithEvents purchase3 As Button
    Friend WithEvents price3 As Label
    Friend WithEvents table3 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents potion3 As PictureBox
    Friend WithEvents Label11 As Label
    Friend WithEvents coins As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents sold As Label
End Class
