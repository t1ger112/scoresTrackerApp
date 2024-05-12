<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class individualsDataFRM
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
        Me.notesLBL = New System.Windows.Forms.Label()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.notesTextBox = New System.Windows.Forms.TextBox()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.txtTeamRankBig = New System.Windows.Forms.TextBox()
        Me.txtTeamScoreBig = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBox30 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'notesLBL
        '
        Me.notesLBL.AutoSize = True
        Me.notesLBL.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.notesLBL.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.notesLBL.Location = New System.Drawing.Point(-5, 323)
        Me.notesLBL.Name = "notesLBL"
        Me.notesLBL.Size = New System.Drawing.Size(141, 25)
        Me.notesLBL.TabIndex = 6
        Me.notesLBL.Text = "Player Notes:"
        '
        'ListBox1
        '
        Me.ListBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.HorizontalScrollbar = True
        Me.ListBox1.ItemHeight = 24
        Me.ListBox1.Location = New System.Drawing.Point(0, 1)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(544, 268)
        Me.ListBox1.TabIndex = 11
        Me.ListBox1.TabStop = False
        '
        'notesTextBox
        '
        Me.notesTextBox.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.notesTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.notesTextBox.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.notesTextBox.Location = New System.Drawing.Point(0, 351)
        Me.notesTextBox.MaxLength = 5000
        Me.notesTextBox.Multiline = True
        Me.notesTextBox.Name = "notesTextBox"
        Me.notesTextBox.ReadOnly = True
        Me.notesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.notesTextBox.Size = New System.Drawing.Size(544, 87)
        Me.notesTextBox.TabIndex = 17
        Me.notesTextBox.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Notes Are Unavaliable On This Screen."
        Me.notesTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTeamRankBig
        '
        Me.txtTeamRankBig.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtTeamRankBig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTeamRankBig.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtTeamRankBig.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTeamRankBig.Location = New System.Drawing.Point(452, 278)
        Me.txtTeamRankBig.Name = "txtTeamRankBig"
        Me.txtTeamRankBig.ReadOnly = True
        Me.txtTeamRankBig.Size = New System.Drawing.Size(92, 35)
        Me.txtTeamRankBig.TabIndex = 20
        Me.txtTeamRankBig.TabStop = False
        Me.txtTeamRankBig.Text = "N/A"
        Me.txtTeamRankBig.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTeamScoreBig
        '
        Me.txtTeamScoreBig.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtTeamScoreBig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTeamScoreBig.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTeamScoreBig.Location = New System.Drawing.Point(92, 278)
        Me.txtTeamScoreBig.Name = "txtTeamScoreBig"
        Me.txtTeamScoreBig.ReadOnly = True
        Me.txtTeamScoreBig.Size = New System.Drawing.Size(194, 35)
        Me.txtTeamScoreBig.TabIndex = 21
        Me.txtTeamScoreBig.TabStop = False
        Me.txtTeamScoreBig.Text = "None Selected"
        Me.txtTeamScoreBig.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label8.Location = New System.Drawing.Point(292, 277)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(161, 31)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Total Score:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label7.Location = New System.Drawing.Point(-6, 277)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(99, 31)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Player:"
        '
        'TextBox30
        '
        Me.TextBox30.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.TextBox30.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox30.Enabled = False
        Me.TextBox30.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox30.ForeColor = System.Drawing.SystemColors.ActiveBorder
        Me.TextBox30.Location = New System.Drawing.Point(0, 272)
        Me.TextBox30.Multiline = True
        Me.TextBox30.Name = "TextBox30"
        Me.TextBox30.ReadOnly = True
        Me.TextBox30.Size = New System.Drawing.Size(544, 47)
        Me.TextBox30.TabIndex = 22
        Me.TextBox30.TabStop = False
        '
        'individualsDataFRM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(552, 439)
        Me.Controls.Add(Me.txtTeamRankBig)
        Me.Controls.Add(Me.txtTeamScoreBig)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TextBox30)
        Me.Controls.Add(Me.notesTextBox)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.notesLBL)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Location = New System.Drawing.Point(322, 57)
        Me.Name = "individualsDataFRM"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "individualsDataFRM"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents notesLBL As Label
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents notesTextBox As TextBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents txtTeamRankBig As TextBox
    Friend WithEvents txtTeamScoreBig As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents TextBox30 As TextBox
End Class
