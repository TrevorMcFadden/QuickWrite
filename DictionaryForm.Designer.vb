<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DictionaryForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DictionaryForm))
        Me.Navi = New Microsoft.Web.WebView2.WinForms.WebView2()
        CType(Me.Navi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Navi
        '
        Me.Navi.CreationProperties = Nothing
        Me.Navi.DefaultBackgroundColor = System.Drawing.Color.White
        Me.Navi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Navi.Location = New System.Drawing.Point(0, 0)
        Me.Navi.Name = "Navi"
        Me.Navi.Size = New System.Drawing.Size(800, 450)
        Me.Navi.Source = New System.Uri("https://www.merriam-webster.com", System.UriKind.Absolute)
        Me.Navi.TabIndex = 0
        Me.Navi.ZoomFactor = 1.0R
        '
        'DictionaryForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Navi)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "DictionaryForm"
        Me.Text = "QuickWrite Dictionary"
        CType(Me.Navi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Navi As Microsoft.Web.WebView2.WinForms.WebView2
End Class
