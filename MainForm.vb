Imports System.Drawing
Imports System.Drawing.Image

Public Class MainForm
#Region "Declarations"
    Private currentFile As String
#End Region
    Private Sub NewDocumentButtonTS_Click(sender As Object, e As EventArgs) Handles NewDocumentButtonTS.Click, NewDocumentButtonMS.Click
        If QWRTB.Modified Then
            Dim answer As Integer
            answer = MessageBox.Show("This project has not been saved yet. Do you want to continue without saving? All progress will be--well, you know the drill.", "Unsaved QuickWrite Document", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If answer = Windows.Forms.DialogResult.Yes Then
                QWRTB.Clear()
            Else
                Exit Sub
            End If
        Else
            QWRTB.Clear()
        End If
        currentFile = ""
        Me.Text = "New QuickWrite Document"
    End Sub
    Private Sub SaveButtonTS_Click(sender As Object, e As EventArgs) Handles SaveButtonTS.Click, SaveButtonMS.Click
        If currentFile = "" Then
            SaveAsButtonMS_Click(Me, e)
            Exit Sub
        End If
        Dim strExt As String
        strExt = System.IO.Path.GetExtension(currentFile)
        strExt = strExt.ToUpper()
        Select Case strExt
            Case ".RTF"
                QWRTB.SaveFile(currentFile)
            Case Else
                Dim txtWriter As System.IO.StreamWriter
                txtWriter = New System.IO.StreamWriter(currentFile)
                txtWriter.Write(QWRTB.Text)
                txtWriter.Close()
                txtWriter = Nothing
                QWRTB.SelectionStart = 0
                QWRTB.SelectionLength = 0
                QWRTB.Modified = False
        End Select
        Me.Text = currentFile.ToString() & " • QuickWrite"
    End Sub
    Private Sub SaveAsButtonMS_Click(sender As Object, e As EventArgs) Handles SaveAsButtonMS.Click
        SaveFileDialog1.Title = "QuickWrite Save File"
        SaveFileDialog1.DefaultExt = ".rtf"
        SaveFileDialog1.Filter = "Rich Text Files|*.rtf|Text Files|*.txt|HTML Files|*.htm|All Files|*.*"
        SaveFileDialog1.FilterIndex = 1
        SaveFileDialog1.ShowDialog()
        If SaveFileDialog1.FileName = "" Then Exit Sub
        Dim strExt As String
        strExt = System.IO.Path.GetExtension(SaveFileDialog1.FileName)
        strExt = strExt.ToUpper()
        Select Case strExt
            Case ".RTF"
                QWRTB.SaveFile(SaveFileDialog1.FileName, RichTextBoxStreamType.RichText)
            Case Else
                Dim txtWriter As System.IO.StreamWriter
                txtWriter = New System.IO.StreamWriter(SaveFileDialog1.FileName)
                txtWriter.Write(QWRTB.Text)
                txtWriter.Close()
                txtWriter = Nothing
                QWRTB.SelectionStart = 0
                QWRTB.SelectionLength = 0
        End Select
        currentFile = SaveFileDialog1.FileName
        QWRTB.Modified = False
        Me.Text = currentFile.ToString() & " • QuickWrite"
        SavedStatusLabel.Text = "Status: saved"
    End Sub
    Private Sub OpenFile()
        OpenFileDialog1.Title = "QuickWrite File Selection"
        OpenFileDialog1.DefaultExt = ".rtf"
        OpenFileDialog1.Filter = "Rich Text Files|*.rtf|Text Files|*.txt|HTML Files|*.htm|All Files|*.*"
        OpenFileDialog1.FilterIndex = 1
        OpenFileDialog1.ShowDialog()
        If OpenFileDialog1.FileName = "" Then Exit Sub
        Dim strExt As String
        strExt = System.IO.Path.GetExtension(OpenFileDialog1.FileName)
        strExt = strExt.ToUpper()
        Select Case strExt
            Case ".RTF"
                QWRTB.LoadFile(OpenFileDialog1.FileName, RichTextBoxStreamType.RichText)
            Case Else
                Dim txtReader As System.IO.StreamReader
                txtReader = New System.IO.StreamReader(OpenFileDialog1.FileName)
                QWRTB.Text = txtReader.ReadToEnd
                txtReader.Close()
                txtReader = Nothing
                QWRTB.SelectionStart = 0
                QWRTB.SelectionLength = 0
        End Select
        currentFile = OpenFileDialog1.FileName
        QWRTB.Modified = False
        Me.Text = currentFile.ToString() & " • QuickWrite"
    End Sub
    Private Sub OpenButtonTS_Click(sender As Object, e As EventArgs) Handles OpenButtonTS.Click, OpenButtonMS.Click
        If QWRTB.Modified Then
            Dim answer As Integer
            answer = MessageBox.Show("This project has not been saved yet. Do you want to continue without saving? All progress will be--well, you know the drill.", "Unsaved QuickWrite Document", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If answer = Windows.Forms.DialogResult.No Then
                Exit Sub
            Else
                OpenFile()
            End If
        Else
            OpenFile()
        End If
    End Sub
    Private Sub UndoButtonTS_Click(sender As Object, e As EventArgs) Handles UndoButtonTS.Click, UndoButtonMS.Click
        QWRTB.Undo()
    End Sub
    Private Sub RedoButtonTS_Click(sender As Object, e As EventArgs) Handles RedoButtonTS.Click, RedoButtonMS.Click
        QWRTB.Redo()
    End Sub
    Private Sub FontButtonTS_Click(sender As Object, e As EventArgs) Handles FontButtonTS.Click, FontButtonMS.Click
        If Not QWRTB.SelectionFont Is Nothing Then
            FontDialog1.Font = QWRTB.SelectionFont
        Else
            FontDialog1.Font = Nothing
        End If
        FontDialog1.ShowApply = False
        If FontDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            QWRTB.SelectionFont = FontDialog1.Font
        End If
    End Sub
    Private Sub FontColorButtonTS_Click(sender As Object, e As EventArgs) Handles FontColorButtonTS.Click, FontColorButtonMS.Click
        ColorDialog1.Color = QWRTB.ForeColor
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            QWRTB.SelectionColor = ColorDialog1.Color
        End If
    End Sub
    Private Sub BoldButtonTS_Click(sender As Object, e As EventArgs) Handles BoldButtonTS.Click
        If Not QWRTB.SelectionFont Is Nothing Then
            Dim currentFont As System.Drawing.Font = QWRTB.SelectionFont
            Dim newFontStyle As System.Drawing.FontStyle
            If QWRTB.SelectionFont.Bold = True Then
                newFontStyle = FontStyle.Regular
            Else
                newFontStyle = FontStyle.Bold
            End If
            QWRTB.SelectionFont = New Font(currentFont.FontFamily, currentFont.Size, newFontStyle)
        End If
    End Sub
    Private Sub ItalicButtonTS_Click(sender As Object, e As EventArgs) Handles ItalicButtonTS.Click
        If Not QWRTB.SelectionFont Is Nothing Then
            Dim currentFont As System.Drawing.Font = QWRTB.SelectionFont
            Dim newFontStyle As System.Drawing.FontStyle
            If QWRTB.SelectionFont.Italic = True Then
                newFontStyle = FontStyle.Regular
            Else
                newFontStyle = FontStyle.Italic
            End If
            QWRTB.SelectionFont = New Font(currentFont.FontFamily, currentFont.Size, newFontStyle)
        End If
    End Sub
    Private Sub UnderlineButtonTS_Click(sender As Object, e As EventArgs) Handles UnderlineButtonTS.Click
        If Not QWRTB.SelectionFont Is Nothing Then
            Dim currentFont As System.Drawing.Font = QWRTB.SelectionFont
            Dim newFontStyle As System.Drawing.FontStyle
            If QWRTB.SelectionFont.Underline = True Then
                newFontStyle = FontStyle.Regular
            Else
                newFontStyle = FontStyle.Underline
            End If
            QWRTB.SelectionFont = New Font(currentFont.FontFamily, currentFont.Size, newFontStyle)
        End If
    End Sub
    Private Sub StrikeoutButtonTS_Click(sender As Object, e As EventArgs) Handles StrikeoutButtonTS.Click
        If Not QWRTB.SelectionFont Is Nothing Then
            Dim currentFont As System.Drawing.Font = QWRTB.SelectionFont
            Dim newFontStyle As System.Drawing.FontStyle
            If QWRTB.SelectionFont.Strikeout = True Then
                newFontStyle = FontStyle.Regular
            Else
                newFontStyle = FontStyle.Strikeout
            End If
            QWRTB.SelectionFont = New Font(currentFont.FontFamily, currentFont.Size, newFontStyle)
        End If
    End Sub
    Private Sub AlignLeftButtonTS_Click(sender As Object, e As EventArgs) Handles AlignLeftButtonTS.Click, AlignLeftButtonMS.Click
        QWRTB.SelectionAlignment = HorizontalAlignment.Left
    End Sub
    Private Sub AlignCenterButtonTS_Click(sender As Object, e As EventArgs) Handles AlignCenterButtonTS.Click, AlignCenterButtonMS.Click
        QWRTB.SelectionAlignment = HorizontalAlignment.Center
    End Sub
    Private Sub AlignRightButtonTS_Click(sender As Object, e As EventArgs) Handles AlignRightButtonTS.Click, AlignRightButtonMS.Click
        QWRTB.SelectionAlignment = HorizontalAlignment.Right
    End Sub
    Private Sub FindandReplaceButtonTS_Click(sender As Object, e As EventArgs) Handles FindandReplaceButtonTS.Click, FindandReplaceButtonMS.Click
        Dim FNRF As New FindandReplaceForm
        FNRF.Show()
    End Sub
    Private Sub PlaceImageButtonTS_Click(sender As Object, e As EventArgs) Handles PlaceImageButtonTS.Click, PlaceImageButtonMS.Click
        OpenFileDialog1.Title = "QuickWrite Image Selection"
                                    OpenFileDialog1.DefaultExt = ".png"
                                    OpenFileDialog1.Filter = "Bitmap Files|*.bmp|JPEG Files|*.jpg|GIF Files|*.gif|PNG Files|*.png"
        OpenFileDialog1.FilterIndex = 1
        OpenFileDialog1.ShowDialog()
        If OpenFileDialog1.FileName = "" Then Exit Sub
        Try
            Dim strImagePath As String = OpenFileDialog1.FileName
            Dim img As Image
            img = Image.FromFile(strImagePath)
            Clipboard.SetDataObject(img)
            Dim df As DataFormats.Format
            df = DataFormats.GetFormat(DataFormats.Bitmap)
            If QWRTB.CanPaste(df) Then
                QWRTB.Paste(df)
            End If
        Catch ex As Exception
            MessageBox.Show("Sorry, our optics must be scratched...the selected image was unable to be processed.", "QuickWrite Paste Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub BackgroundColorButtonTS_Click(sender As Object, e As EventArgs) Handles BackgroundColorButtonTS.Click, OtherToolStripMenuItem.Click
        ColorDialog1.Color = Me.BackColor
        ColorDialog1.Color = QWRTB.BackColor
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.BackColor = ColorDialog1.Color
            QWRTB.BackColor = ColorDialog1.Color
        End If
    End Sub
    Private Sub SearchDictionaryButtonTS_Click(sender As Object, e As EventArgs) Handles SearchDictionaryButtonTS.Click
        Dim DF As New DictionaryForm
        DF.Show()
    End Sub
    Private Sub AddBulletsButtonMS_Click(sender As Object, e As EventArgs) Handles AddBulletsButtonMS.Click
        QWRTB.BulletIndent = 10
        QWRTB.SelectionBullet = True
    End Sub
    Private Sub RemoveBulletButtonMS_Click(sender As Object, e As EventArgs) Handles RemoveBulletButtonMS.Click
        QWRTB.SelectionBullet = False
    End Sub
    Private Sub PButton1MS_Click(sender As Object, e As EventArgs) Handles PButton1MS.Click
        QWRTB.SelectionIndent = 0
    End Sub
    Private Sub PButton2MS_Click(sender As Object, e As EventArgs) Handles PButton2MS.Click
        QWRTB.SelectionIndent = 5
    End Sub
    Private Sub PButton3MS_Click(sender As Object, e As EventArgs) Handles PButton3MS.Click
        QWRTB.SelectionIndent = 10
    End Sub
    Private Sub PButton4MS_Click(sender As Object, e As EventArgs) Handles PButton4MS.Click
        QWRTB.SelectionIndent = 15
    End Sub
    Private Sub PButton5MS_Click(sender As Object, e As EventArgs) Handles PButton5MS.Click
        QWRTB.SelectionIndent = 20
    End Sub
    Private Sub PButton6MS_Click(sender As Object, e As EventArgs) Handles PButton6MS.Click
        QWRTB.SelectionIndent = 25
    End Sub
    Private Sub PButton7MS_Click(sender As Object, e As EventArgs) Handles PButton7MS.Click
        QWRTB.SelectionIndent = 30
    End Sub
    Private Sub SelectAllButtonMS_Click(sender As Object, e As EventArgs) Handles SelectAllButtonMS.Click
        Try
            QWRTB.SelectAll()
        Catch exc As Exception
            MessageBox.Show("Unable to select all the document content. Please hang up the phone and try again.", "QuickWrite Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ClearAllButtonMS_Click(sender As Object, e As EventArgs) Handles ClearAllButtonMS.Click
        QWRTB.Clear()
    End Sub
    Private Sub NewWindowButtonMS_Click(sender As Object, e As EventArgs) Handles NewWindowButtonMS.Click
        Dim NW As New MainForm
        NW.Show()
    End Sub
    Private Sub QWRTB_TextChanged(sender As Object, e As EventArgs) Handles QWRTB.TextChanged
        SavedStatusLabel.Text = "Status: unsaved"
        CharacterCountLabel.Text = "Characters: " & QWRTB.TextLength.ToString()
        If QWRTB.CanUndo = True Then
            UndoButtonMS.Enabled = True
            UndoButtonTS.Enabled = True
        Else
            UndoButtonMS.Enabled = False
            UndoButtonTS.Enabled = False
        End If
        If QWRTB.CanRedo = True Then
            RedoButtonMS.Enabled = True
            RedoButtonTS.Enabled = True
        Else
            RedoButtonMS.Enabled = False
            RedoButtonTS.Enabled = False
        End If
        'Easter Eggs'
        If QWRTB.Text.Contains("swords") Then
            Dim answer As Integer
            answer = MessageBox.Show("It's dangerous to go alone! Take this.", "Jotet Easter Egg Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        If QWRTB.Text.Contains("sneak like Snake") Then
            Dim answer As Integer
            answer = MessageBox.Show("Just a box.", "Jotet Easter Egg Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        If QWRTB.Text.Contains("navi") Then
            Dim answer As Integer
            answer = MessageBox.Show("Hey! Listen!", "Jotet Easter Egg Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        If QWRTB.Text.Contains("wake me up") Then
            Dim answer As Integer
            answer = MessageBox.Show("Inside", "Jotet Easter Egg Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        If QWRTB.Text.Contains("Searchin'") Then
            Dim answer As Integer
            answer = MessageBox.Show("...seek, seek and destroy!", "Jotet Easter Egg Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        If QWRTB.Text.Contains("Psalm 23") Then
            Dim answer As Integer
            answer = MessageBox.Show("Yahweh [The Lord] is my shepherd: I shall lack nothing. He makes me lie down in green pastures. He leads me beside still waters. He restores my soul. He guides me in the paths of righteousness for his name’s sake. Even though I walk through the valley of the shadow of death, I will fear no evil, for you are with me. Your rod and your staff, they comfort me. You prepare a table before me in the presence of my enemies. You anoint my head with oil. My cup runs over. Surely goodness and loving kindness shall follow me all the days of my life, and I will dwell in Yahweh’s house forever.", "Jotet Easter Egg Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        If QWRTB.Text.Contains("John 15") Then
            Dim answer As Integer
            answer = MessageBox.Show("I am the True vine, And My Father Is the farmer. Every branch in me that doesn't bear fruit, he takes away. Every branch that bears fruit, he prunes, that it may bear more fruit. You are already pruned clean because of the word which I have spoken to you. Remain in me, and I in you. As the branch can’t bear fruit by itself, unless it remains in the vine, so neither can you, unless you remain in me. I am the vine. You are the branches. He who remains in me, and I in him, the same bears much fruit, for apart from me you can do nothing. If a man doesn’t remain in me, he is thrown out as a branch, and is withered; and they gather them, throw them into the fire, and they are burned. If you remain in me, and my words remain in you, you will ask whatever you desire, and it will be done for you. In this Is my Father glorified, that you bear much fruit; And so you will be my disciples. Even As the Father has loved Me, I also have loved you. Remain In my love. If you keep my commandments, you will remain in my love; even as I have kept my Father's commandments, and remain in his love. I have spoken these things to you, that my joy may remain in you, and that your joy may be made full. This is my commandment, that you love one another, even as I have loved you. Greater love has no one than this, that someone lay down his life for his friends. You are my friends, if you do whatever I command you. No longer do I call you servants, for the servant doesn’t know what his lord does. But I have called you friends, for everything that I heard from my Father, I have made known to you. You didn’t choose me, but I chose you, and appointed you, that you should go and bear fruit, and that your fruit should remain; that whatever you will ask of the Father in my name, he may give it to you. I command these things to you, that you may love one another. If the world hates you, you know that it has hated me before it hated you. If you were of the world, the world would love its own. But because you are not of the world, since I chose you out of the world, therefore the world hates you. Remember the word that I said to you: ‘A servant is not greater than his lord.’ If they persecuted me, they will also persecute you. If they kept my word, they will also keep yours. But all these things will they do to you for my name’s sake, because they don’t know him who sent me. If I had not come and spoken to them, they would not have had sin; but now they have no excuse for their sin. He who hates me, hates my Father also. If I hadn’t done among them the works which no one else did, they wouldn’t have had sin. But now have they seen and also hated both me and my Father. But this happened so that the word may be fulfilled which was written in their law, ‘They hated me without a cause. When the Counselor has come, whom I will send To you from the Father, the Spirit Of truth, who proceeds from the Father, he will testify about Me. You will also testify, because you have been With Me from the beginning.", "Jotet Easter Egg Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        If QWRTB.Text.Contains("I need Jesus") Then
            Dim answer As Integer
            answer = MessageBox.Show("Good News: He's waiting for you with open arms. :) Jesus loves you and wants to have a relationship with you. Do you want to follow Him today? ", "Jotet Easter Egg Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        End If
        If QWRTB.Text.Contains("Why do I feel like") Then
            Dim answer As Integer
            answer = MessageBox.Show("...somebody's watchin' me?", "Jotet Easter Egg Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        If QWRTB.Text.Contains("80's") Then
            Dim answer As Integer
            answer = MessageBox.Show("Tubular, dude! Like, totally rad to the max, man! Dude!", "Jotet Easter Egg Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        If QWRTB.Text.Contains("I hate easter eggs.") Then
            Dim answer As Integer
            answer = MessageBox.Show("Oh, do you? Hey, do you know what it's like to try to write easter eggs? Huh? Huh? Do you know the pressure there is to be funny but also tatseful at the same time? Do yah? Do yah? I bet you don't. I could have been a simple message box but noooo I had to be an easter egg. 'But maybe it would be funny,' he says. 'But maybe people will appreciate these random references,' he says. Grrr...maybe next time you'll appreciate your local easter egg, because when you need me, I won't be there. So, nyah! Some people...", "Jotet Easter Egg Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Private Sub CutButtonMS_Click(sender As Object, e As EventArgs) Handles CutButtonMS.Click, CutToolStripMenuItem.Click
        Try
            QWRTB.Cut()
        Catch exc As Exception
            MessageBox.Show("Unable to select all the document content. Please hang up the phone and try again.", "QuickWrite Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub CopyButtonMS_Click(sender As Object, e As EventArgs) Handles CopyButtonMS.Click, CopyToolStripMenuItem.Click
        Try
            QWRTB.Copy()
        Catch exc As Exception
            MessageBox.Show("Unable to select all the document content. Please hang up the phone and try again.", "QuickWrite Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub PasteButtonMS_Click(sender As Object, e As EventArgs) Handles PasteButtonMS.Click, PasteToolStripMenuItem.Click
        Try
            QWRTB.Paste()
        Catch exc As Exception
            MessageBox.Show("Unable to select all the document content. Please hang up the phone and try again.", "QuickWrite Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ExitButtonMS_Click(sender As Object, e As EventArgs) Handles ExitButtonMS.Click
        If QWRTB.Modified Then
            Dim answer As Integer
            answer = MessageBox.Show("This project has not been saved yet. Do you want to continue without saving? All progress will be--well, you know the drill.", "Unsaved QuickWrite Document", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If answer = Windows.Forms.DialogResult.No Then
                Exit Sub
            Else
                Application.Exit()
            End If
        Else
            Application.Exit()
        End If
    End Sub
    Private Sub AboutButtonMS_Click(sender As Object, e As EventArgs) Handles AboutButtonMS.Click
        Dim AF As New AboutForm
        AF.Show()
    End Sub
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
        UndoButtonMS.Enabled = False
        UndoButtonTS.Enabled = False
        RedoButtonMS.Enabled = False
        RedoButtonTS.Enabled = False
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        TimeDateLabel.Text = DateTime.Now.ToString("dddd, MMMM d, h:mm tt")
    End Sub
    Private Sub ShowStatusButtonMS_Click(sender As Object, e As EventArgs) Handles ShowStatusButtonMS.Click
        If ShowStatusButtonMS.Checked = True Then
            StatusStrip1.Visible = True
        End If
        If ShowStatusButtonMS.Checked = False Then
            StatusStrip1.Visible = False
        End If
    End Sub
    Private Sub AquaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AquaToolStripMenuItem.Click
        Me.BackColor = Color.LightCyan
        QWRTB.BackColor = Color.LightCyan
        Me.ForeColor = Color.Orange
        QWRTB.ForeColor = Color.Orange
    End Sub
    Private Sub ContructionSitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ContructionSitToolStripMenuItem.Click
        Me.BackColor = Color.Orange
        QWRTB.BackColor = Color.Orange
        Me.ForeColor = Color.White
        QWRTB.ForeColor = Color.White
    End Sub
    Private Sub WhiteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WhiteToolStripMenuItem.Click
        Me.BackColor = Color.White
        QWRTB.BackColor = Color.White
        Me.ForeColor = Color.Black
        QWRTB.ForeColor = Color.Black
    End Sub
    Private Sub ZoomInToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ZoomInToolStripMenuItem.Click
        QWRTB.ZoomFactor += 0.5
        If QWRTB.ZoomFactor = 1 Then
            ZoomOutToolStripMenuItem.Enabled = True
        End If
        ZoomLabel.Text = "Zoom: " & QWRTB.ZoomFactor.ToString()
    End Sub
    Private Sub ZoomOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ZoomOutToolStripMenuItem.Click
        QWRTB.ZoomFactor -= 0.5
        If QWRTB.ZoomFactor = 0.5 Then
            ZoomOutToolStripMenuItem.Enabled = False
        End If
        ZoomLabel.Text = "Zoom: " & QWRTB.ZoomFactor.ToString()
    End Sub
    Private Sub RestoreToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestoreToolStripMenuItem.Click
        QWRTB.ZoomFactor = 1
        ZoomLabel.Text = "Zoom: " & QWRTB.ZoomFactor.ToString()
    End Sub
    Private Sub InsertTimeAndDateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InsertTimeAndDateToolStripMenuItem.Click
        QWRTB.SelectedText = Now.ToString("dddd, MMMM dd, yyyy @ h:mm tt")
    End Sub
    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        QWRTB.SelectedText = ""
    End Sub
End Class
