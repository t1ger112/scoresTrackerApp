<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class teamDataFRM
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
        Me.notesTextBox = New System.Windows.Forms.TextBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.notesLBL = New System.Windows.Forms.Label()
        Me.SuspendLayout()
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
        Me.notesTextBox.TabIndex = 20
        Me.notesTextBox.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Notes Are Unavaliable On This Screen."
        Me.notesTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ListBox1
        '
        Me.ListBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.HorizontalScrollbar = True
        Me.ListBox1.ItemHeight = 20
        Me.ListBox1.Location = New System.Drawing.Point(0, 1)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(544, 304)
        Me.ListBox1.TabIndex = 19
        Me.ListBox1.TabStop = False
        '
        'notesLBL
        '
        Me.notesLBL.AutoSize = True
        Me.notesLBL.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.notesLBL.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.notesLBL.Location = New System.Drawing.Point(-5, 323)
        Me.notesLBL.Name = "notesLBL"
        Me.notesLBL.Size = New System.Drawing.Size(141, 25)
        Me.notesLBL.TabIndex = 18
        Me.notesLBL.Text = "Player Notes:"
        '
        'teamDataFRM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(552, 439)
        Me.Controls.Add(Me.notesTextBox)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.notesLBL)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Location = New System.Drawing.Point(322, 57)
        Me.Name = "teamDataFRM"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "teamDataFRM"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents notesTextBox As TextBox
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents notesLBL As Label
End Class
