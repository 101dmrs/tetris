<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.lbl_score = New System.Windows.Forms.Label()
        Me.lbl_score_count = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbl_gameOver = New System.Windows.Forms.Label()
        Me.btn_restart = New System.Windows.Forms.Button()
        Me.lbl_timer = New System.Windows.Forms.Label()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.btn_joker = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lbl_score
        '
        Me.lbl_score.AutoSize = True
        Me.lbl_score.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.lbl_score.Location = New System.Drawing.Point(325, 32)
        Me.lbl_score.Name = "lbl_score"
        Me.lbl_score.Size = New System.Drawing.Size(86, 29)
        Me.lbl_score.TabIndex = 2
        Me.lbl_score.Text = "Score:"
        '
        'lbl_score_count
        '
        Me.lbl_score_count.AutoSize = True
        Me.lbl_score_count.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.lbl_score_count.Location = New System.Drawing.Point(325, 61)
        Me.lbl_score_count.Name = "lbl_score_count"
        Me.lbl_score_count.Size = New System.Drawing.Size(27, 29)
        Me.lbl_score_count.TabIndex = 3
        Me.lbl_score_count.Text = "0"
        '
        'Timer1
        '
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(335, 457)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(76, 22)
        Me.TextBox1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(327, 434)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 60)
        Me.Label1.TabIndex = 4
        '
        'lbl_gameOver
        '
        Me.lbl_gameOver.Font = New System.Drawing.Font("Microsoft Sans Serif", 40.0!)
        Me.lbl_gameOver.Location = New System.Drawing.Point(13, 198)
        Me.lbl_gameOver.Name = "lbl_gameOver"
        Me.lbl_gameOver.Size = New System.Drawing.Size(403, 89)
        Me.lbl_gameOver.TabIndex = 5
        Me.lbl_gameOver.Text = "Game Over!"
        Me.lbl_gameOver.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_gameOver.Visible = False
        '
        'btn_restart
        '
        Me.btn_restart.Location = New System.Drawing.Point(330, 531)
        Me.btn_restart.Name = "btn_restart"
        Me.btn_restart.Size = New System.Drawing.Size(75, 27)
        Me.btn_restart.TabIndex = 7
        Me.btn_restart.Text = "Restart"
        Me.btn_restart.UseVisualStyleBackColor = True
        '
        'lbl_timer
        '
        Me.lbl_timer.AutoSize = True
        Me.lbl_timer.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.lbl_timer.Location = New System.Drawing.Point(325, 121)
        Me.lbl_timer.Name = "lbl_timer"
        Me.lbl_timer.Size = New System.Drawing.Size(24, 26)
        Me.lbl_timer.TabIndex = 8
        Me.lbl_timer.Text = "0"
        '
        'Timer2
        '
        '
        'btn_joker
        '
        Me.btn_joker.Location = New System.Drawing.Point(330, 497)
        Me.btn_joker.Name = "btn_joker"
        Me.btn_joker.Size = New System.Drawing.Size(75, 28)
        Me.btn_joker.TabIndex = 9
        Me.btn_joker.Text = "Joker"
        Me.btn_joker.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(428, 570)
        Me.Controls.Add(Me.btn_joker)
        Me.Controls.Add(Me.lbl_timer)
        Me.Controls.Add(Me.btn_restart)
        Me.Controls.Add(Me.lbl_gameOver)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.lbl_score_count)
        Me.Controls.Add(Me.lbl_score)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "Form1"
        Me.Text = "Tetris"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_score As Label
    Friend WithEvents lbl_score_count As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lbl_gameOver As Label
    Friend WithEvents btn_restart As Button
    Friend WithEvents lbl_timer As Label
    Friend WithEvents Timer2 As Timer
    Friend WithEvents btn_joker As Button
End Class
