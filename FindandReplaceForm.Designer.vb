<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FindandReplaceForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FindandReplaceForm))
        Me.FindButton = New System.Windows.Forms.Button()
        Me.FindBox = New System.Windows.Forms.TextBox()
        Me.ReplaceBox = New System.Windows.Forms.TextBox()
        Me.FindNextButton = New System.Windows.Forms.Button()
        Me.ReplaceButton = New System.Windows.Forms.Button()
        Me.ReplaceAllButton = New System.Windows.Forms.Button()
        Me.FindLabel = New System.Windows.Forms.Label()
        Me.ReplaceLabel = New System.Windows.Forms.Label()
        Me.MatchCaseCheckbox = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'FindButton
        '
        Me.FindButton.Location = New System.Drawing.Point(118, 26)
        Me.FindButton.Name = "FindButton"
        Me.FindButton.Size = New System.Drawing.Size(75, 23)
        Me.FindButton.TabIndex = 0
        Me.FindButton.Text = "Find"
        Me.FindButton.UseVisualStyleBackColor = True
        '
        'FindBox
        '
        Me.FindBox.Location = New System.Drawing.Point(12, 27)
        Me.FindBox.Name = "FindBox"
        Me.FindBox.Size = New System.Drawing.Size(100, 23)
        Me.FindBox.TabIndex = 1
        '
        'ReplaceBox
        '
        Me.ReplaceBox.Location = New System.Drawing.Point(12, 71)
        Me.ReplaceBox.Name = "ReplaceBox"
        Me.ReplaceBox.Size = New System.Drawing.Size(100, 23)
        Me.ReplaceBox.TabIndex = 2
        '
        'FindNextButton
        '
        Me.FindNextButton.Location = New System.Drawing.Point(199, 26)
        Me.FindNextButton.Name = "FindNextButton"
        Me.FindNextButton.Size = New System.Drawing.Size(75, 23)
        Me.FindNextButton.TabIndex = 3
        Me.FindNextButton.Text = "Find next"
        Me.FindNextButton.UseVisualStyleBackColor = True
        '
        'ReplaceButton
        '
        Me.ReplaceButton.Location = New System.Drawing.Point(118, 71)
        Me.ReplaceButton.Name = "ReplaceButton"
        Me.ReplaceButton.Size = New System.Drawing.Size(75, 23)
        Me.ReplaceButton.TabIndex = 4
        Me.ReplaceButton.Text = "Replace"
        Me.ReplaceButton.UseVisualStyleBackColor = True
        '
        'ReplaceAllButton
        '
        Me.ReplaceAllButton.Location = New System.Drawing.Point(199, 70)
        Me.ReplaceAllButton.Name = "ReplaceAllButton"
        Me.ReplaceAllButton.Size = New System.Drawing.Size(75, 23)
        Me.ReplaceAllButton.TabIndex = 5
        Me.ReplaceAllButton.Text = "Replace all"
        Me.ReplaceAllButton.UseVisualStyleBackColor = True
        '
        'FindLabel
        '
        Me.FindLabel.AutoSize = True
        Me.FindLabel.Location = New System.Drawing.Point(12, 9)
        Me.FindLabel.Name = "FindLabel"
        Me.FindLabel.Size = New System.Drawing.Size(33, 15)
        Me.FindLabel.TabIndex = 6
        Me.FindLabel.Text = "Find:"
        '
        'ReplaceLabel
        '
        Me.ReplaceLabel.AutoSize = True
        Me.ReplaceLabel.Location = New System.Drawing.Point(12, 53)
        Me.ReplaceLabel.Name = "ReplaceLabel"
        Me.ReplaceLabel.Size = New System.Drawing.Size(77, 15)
        Me.ReplaceLabel.TabIndex = 7
        Me.ReplaceLabel.Text = "Replace with:"
        '
        'MatchCaseCheckbox
        '
        Me.MatchCaseCheckbox.AutoSize = True
        Me.MatchCaseCheckbox.Checked = True
        Me.MatchCaseCheckbox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.MatchCaseCheckbox.Location = New System.Drawing.Point(291, 73)
        Me.MatchCaseCheckbox.Name = "MatchCaseCheckbox"
        Me.MatchCaseCheckbox.Size = New System.Drawing.Size(86, 19)
        Me.MatchCaseCheckbox.TabIndex = 8
        Me.MatchCaseCheckbox.Text = "Match case"
        Me.MatchCaseCheckbox.UseVisualStyleBackColor = True
        '
        'FindandReplaceForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(388, 119)
        Me.Controls.Add(Me.MatchCaseCheckbox)
        Me.Controls.Add(Me.ReplaceLabel)
        Me.Controls.Add(Me.FindLabel)
        Me.Controls.Add(Me.ReplaceAllButton)
        Me.Controls.Add(Me.ReplaceButton)
        Me.Controls.Add(Me.FindNextButton)
        Me.Controls.Add(Me.ReplaceBox)
        Me.Controls.Add(Me.FindBox)
        Me.Controls.Add(Me.FindButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FindandReplaceForm"
        Me.Text = "QuickWrite Find and Replace"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents FindButton As Button
    Friend WithEvents FindBox As TextBox
    Friend WithEvents ReplaceBox As TextBox
    Friend WithEvents FindNextButton As Button
    Friend WithEvents ReplaceButton As Button
    Friend WithEvents ReplaceAllButton As Button
    Friend WithEvents FindLabel As Label
    Friend WithEvents ReplaceLabel As Label
    Friend WithEvents MatchCaseCheckbox As CheckBox
End Class
