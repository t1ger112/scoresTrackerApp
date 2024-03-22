<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class homepageFRM
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.notesTextBox = New System.Windows.Forms.TextBox()
        Me.newPlayerBTN = New System.Windows.Forms.Button()
        Me.removeBTN = New System.Windows.Forms.Button()
        Me.renameBTN = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.notesLBL = New System.Windows.Forms.Label()
        Me.scoresLBL = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.testBTN = New System.Windows.Forms.Button()
        Me.collapseallBTN = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TreeView1
        '
        Me.TreeView1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TreeView1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TreeView1.Location = New System.Drawing.Point(12, 57)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(299, 438)
        Me.TreeView1.TabIndex = 0
        '
        'notesTextBox
        '
        Me.notesTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.notesTextBox.Location = New System.Drawing.Point(323, 408)
        Me.notesTextBox.MaxLength = 5000
        Me.notesTextBox.Multiline = True
        Me.notesTextBox.Name = "notesTextBox"
        Me.notesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.notesTextBox.Size = New System.Drawing.Size(544, 87)
        Me.notesTextBox.TabIndex = 1
        '
        'newPlayerBTN
        '
        Me.newPlayerBTN.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.newPlayerBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.newPlayerBTN.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.newPlayerBTN.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.newPlayerBTN.Location = New System.Drawing.Point(13, 12)
        Me.newPlayerBTN.Name = "newPlayerBTN"
        Me.newPlayerBTN.Size = New System.Drawing.Size(147, 38)
        Me.newPlayerBTN.TabIndex = 2
        Me.newPlayerBTN.Text = "Add Player/Teams"
        Me.newPlayerBTN.UseVisualStyleBackColor = False
        '
        'removeBTN
        '
        Me.removeBTN.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.removeBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.removeBTN.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.removeBTN.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.removeBTN.Location = New System.Drawing.Point(264, 12)
        Me.removeBTN.Name = "removeBTN"
        Me.removeBTN.Size = New System.Drawing.Size(47, 38)
        Me.removeBTN.TabIndex = 2
        Me.removeBTN.Text = "BIN"
        Me.removeBTN.UseVisualStyleBackColor = False
        '
        'renameBTN
        '
        Me.renameBTN.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.renameBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.renameBTN.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.renameBTN.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.renameBTN.Location = New System.Drawing.Point(211, 12)
        Me.renameBTN.Name = "renameBTN"
        Me.renameBTN.Size = New System.Drawing.Size(47, 38)
        Me.renameBTN.TabIndex = 2
        Me.renameBTN.Text = "Rename"
        Me.renameBTN.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(323, 135)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(544, 229)
        Me.DataGridView1.TabIndex = 4
        '
        'notesLBL
        '
        Me.notesLBL.AutoSize = True
        Me.notesLBL.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.notesLBL.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.notesLBL.Location = New System.Drawing.Point(318, 380)
        Me.notesLBL.Name = "notesLBL"
        Me.notesLBL.Size = New System.Drawing.Size(141, 25)
        Me.notesLBL.TabIndex = 5
        Me.notesLBL.Text = "Player Notes:"
        '
        'scoresLBL
        '
        Me.scoresLBL.AutoSize = True
        Me.scoresLBL.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.scoresLBL.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.scoresLBL.Location = New System.Drawing.Point(318, 107)
        Me.scoresLBL.Name = "scoresLBL"
        Me.scoresLBL.Size = New System.Drawing.Size(152, 25)
        Me.scoresLBL.TabIndex = 5
        Me.scoresLBL.Text = "Player Scores:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(374, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(366, 31)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Priestley Scores Tracker App" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'testBTN
        '
        Me.testBTN.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.testBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.testBTN.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.testBTN.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.testBTN.Location = New System.Drawing.Point(803, 12)
        Me.testBTN.Name = "testBTN"
        Me.testBTN.Size = New System.Drawing.Size(65, 38)
        Me.testBTN.TabIndex = 6
        Me.testBTN.Text = "EXIT"
        Me.testBTN.UseVisualStyleBackColor = False
        '
        'collapseallBTN
        '
        Me.collapseallBTN.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.collapseallBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.collapseallBTN.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.collapseallBTN.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.collapseallBTN.Location = New System.Drawing.Point(166, 12)
        Me.collapseallBTN.Name = "collapseallBTN"
        Me.collapseallBTN.Size = New System.Drawing.Size(39, 38)
        Me.collapseallBTN.TabIndex = 2
        Me.collapseallBTN.Text = "^"
        Me.collapseallBTN.UseVisualStyleBackColor = False
        '
        'homepageFRM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(880, 507)
        Me.Controls.Add(Me.testBTN)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.scoresLBL)
        Me.Controls.Add(Me.notesLBL)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.collapseallBTN)
        Me.Controls.Add(Me.renameBTN)
        Me.Controls.Add(Me.removeBTN)
        Me.Controls.Add(Me.newPlayerBTN)
        Me.Controls.Add(Me.notesTextBox)
        Me.Controls.Add(Me.TreeView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "homepageFRM"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Homepage Form"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents notesTextBox As TextBox
    Friend WithEvents newPlayerBTN As Button
    Friend WithEvents removeBTN As Button
    Friend WithEvents renameBTN As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents notesLBL As Label
    Friend WithEvents scoresLBL As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents testBTN As Button
    Friend WithEvents collapseallBTN As Button
End Class
