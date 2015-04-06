
Imports Newtonsoft.Json

Public Class JSONTest
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim webClient As New System.Net.WebClient
        Dim result As String = webClient.DownloadString("http://api.nytimes.com/svc/news/v3/content/nyt/all[/time-period][.json]?api-key=d657c0a64ae6788a338a7f090ec5d7cc:7:71710801")

        lblTest.Text = result
    End Sub

End Class