Imports LinqToTwitter
Imports Newtonsoft.Json.Linq


Public Class _default

    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim jsonData As NYTimes_json = New NYTimes_json()

        ' lblInfo.Text = jsonData.author & " : " & jsonData.title & " : " & jsonData.abstract

    End Sub

    Protected Sub iBtn_nyTimes_Click(sender As Object, e As ImageClickEventArgs) Handles iBtn_nyTimes.Click
        'Call NY Times API from hub/JSON here
        Dim nyTimes As JSONTest = New JSONTest()
    End Sub

    Protected Sub iBtn_facebook_Click(sender As Object, e As ImageClickEventArgs) Handles iBtn_facebook.Click
        'Call Facebook API from hub/JSON here
    End Sub

    Protected Sub iBtn_twitter_Click(sender As Object, e As ImageClickEventArgs) Handles iBtn_twitter.Click
        'Call Twitter API from hub/JSON here
        Dim twitter As JSONTwitter = New JSONTwitter

    End Sub

   

End Class
