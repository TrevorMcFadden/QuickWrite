Public Class FindandReplaceForm
    Private Sub FindButton_Click(sender As Object, e As EventArgs) Handles FindButton.Click
        Dim StartPosition As Integer
        Dim SearchType As CompareMethod
        If MatchCaseCheckbox.Checked = True Then
            SearchType = CompareMethod.Binary
        Else
            SearchType = CompareMethod.Text
        End If
        StartPosition = InStr(1, MainForm.QWRTB.Text, FindBox.Text, SearchType)
        If StartPosition = 0 Then
            MessageBox.Show("Sorry, '" & FindBox.Text.ToString() & "' was not found in the document.", "QuickWrite Match Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If
        MainForm.QWRTB.Select(StartPosition - 1, FindBox.Text.Length)
        MainForm.QWRTB.ScrollToCaret()
        MainForm.Focus()
    End Sub
    Private Sub FindNextButton_Click(sender As Object, e As EventArgs) Handles FindNextButton.Click
        Dim StartPosition As Integer = MainForm.QWRTB.SelectionStart + 2
        Dim SearchType As CompareMethod
        If MatchCaseCheckbox.Checked = True Then
            SearchType = CompareMethod.Binary
        Else
            SearchType = CompareMethod.Text
        End If
        StartPosition = InStr(1, MainForm.QWRTB.Text, FindBox.Text, SearchType)
        If StartPosition = 0 Then
            MessageBox.Show("Sorry, '" & FindBox.Text.ToString() & "' was not found in the document.", "QuickWrite Match Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If
        MainForm.QWRTB.Select(StartPosition - 1, FindBox.Text.Length)
        MainForm.QWRTB.ScrollToCaret()
        MainForm.Focus()
    End Sub
    Private Sub ReplaceButton_Click(sender As Object, e As EventArgs) Handles ReplaceButton.Click
        If MainForm.QWRTB.SelectedText.Length <> 0 Then
            MainForm.QWRTB.SelectedText = ReplaceBox.Text
        End If
        Dim StartPosition As Integer = MainForm.QWRTB.SelectionStart + 2
        Dim SearchType As CompareMethod
        If MatchCaseCheckbox.Checked = True Then
            SearchType = CompareMethod.Binary
        Else
            SearchType = CompareMethod.Text
        End If
        StartPosition = InStr(StartPosition, MainForm.QWRTB.Text, FindBox.Text, SearchType)
        If StartPosition = 0 Then
            MessageBox.Show("Sorry, '" & FindBox.Text.ToString() & "' was not found in the document.", "QuickWrite Match Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If
        MainForm.QWRTB.Select(StartPosition - 1, FindBox.Text.Length)
        MainForm.QWRTB.ScrollToCaret()
        MainForm.Focus()
    End Sub
    Private Sub ReplaceAllButton_Click(sender As Object, e As EventArgs) Handles ReplaceAllButton.Click
        Dim currentPosition As Integer = MainForm.QWRTB.SelectionStart
        Dim currentSelect As Integer = MainForm.QWRTB.SelectionLength
        MainForm.QWRTB.Rtf = Replace(MainForm.QWRTB.Rtf, Trim(FindBox.Text), Trim(ReplaceBox.Text))
        MainForm.QWRTB.SelectionStart = currentPosition
        MainForm.QWRTB.SelectionLength = currentSelect
        MainForm.Focus()
    End Sub
End Class