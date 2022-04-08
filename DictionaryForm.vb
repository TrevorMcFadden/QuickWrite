Imports Microsoft.Web.WebView2
Imports Microsoft.Web.WebView2.Core

Public Class DictionaryForm
    Private Sub Navi_NavigationStarting(sender As Object, e As CoreWebView2NavigationStartingEventArgs) Handles Navi.NavigationStarting
        Me.Text = "Dictionary is loading..."
    End Sub
    Private Sub Navi_NavigationCompleted(sender As Object, e As CoreWebView2NavigationCompletedEventArgs) Handles Navi.NavigationCompleted
        Me.Text = "QuickWrite Dictionary"
    End Sub
End Class