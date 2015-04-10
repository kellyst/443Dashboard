Imports Newtonsoft.Json
Imports LinqToTwitter
Imports System.IO
Imports Microsoft.AspNet.SignalR
Imports System.Net
Public Class JSONTwitter
    Inherits System.Web.UI.Page

    Dim consumer As String = ConfigurationManager.AppSettings.Get("ConsumerKey")
    Dim cSecret As String = ConfigurationManager.AppSettings.Get("ConsumerSecret")
    'Dim consumer As String = "xvz1evFS4wEEPTGEFPHBog"
    'Dim cSecret As String = "L8qq9PZyRg6ieKGEKhZolGC0vJWLw8iEJ88DRdyOg"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim webClient As New System.Net.WebClient
        'Dim twitResource As String = webClient.DownloadString("https://userstream.twitter.com/1.1/user.json")
        'Dim oAuthResource As String = webClient.DownloadString("https://api.twitter.com/oauth/authenticate")





    End Sub

    Private Function tAuthenticate() As Integer


        Dim resource As String = "https://api.twitter.com/oauth2/token"
        'Dim client As System.Net.WebRequest = System.Net.WebRequest.Create(resource)
        Dim customRequest As HttpWebRequest = HttpWebRequest.Create(resource)

        Dim encodedString = consumer & ":" & cSecret
        Dim b64String As String
        Dim byteArr() As Byte
        byteArr = System.Text.Encoding.ASCII.GetBytes(encodedString)
        b64String = System.Convert.ToBase64String(byteArr)

        customRequest.Host = "api.twitter.com"
        customRequest.UserAgent = "443 Dashboard"
        customRequest.ContentType = "application/x-www-form-urlencoded;charset=UTF-8"
        customRequest.ContentLength = "29"
        customRequest.Method = "POST"
        customRequest.Headers.Set("Authorization", "Basic " & b64String)
        Dim dstream As Stream = customRequest.GetRequestStream()
        Dim resp As WebResponse = customRequest.GetResponse()

        'response.ContentLength = "29"
        'response.ContentType = "application/x-www-form-urlencode;charset=UTF-8"
        'response = customRequest.GetResponse()

        Return 0

    End Function

    

    Private Async Sub twitter(sender As Object, e As EventArgs) Handles Me.Load
        Dim tContext As TwitterContext

        Dim twAuth = New SingleUserAuthorizer() With { _
          .CredentialStore = New SingleUserInMemoryCredentialStore() With { _
             .ConsumerKey = ConfigurationManager.AppSettings("consumerKey"), _
             .ConsumerSecret = ConfigurationManager.AppSettings("consumerSecret"), _
             .AccessToken = ConfigurationManager.AppSettings("accessToken"), _
             .AccessTokenSecret = ConfigurationManager.AppSettings("accessTokenSecret") _
       } _
    }


        tContext = New TwitterContext(twAuth)
        Dim user = New User()
        Dim alltweets As New List(Of Status)
        Dim tweets = (From tweet In tContext.Status Where tweet.Type = StatusType.Home And tweet.ExcludeReplies = True Select tweet).ToList()
        Dim x As Integer = 0
        If tweets.Count > 0 Then
            alltweets.AddRange(tweets)

        End If

        For Each tweet In alltweets

            Dim divControl As New HtmlGenericControl("div")
            Dim pl As PlaceHolder = Me.FindControl("Pl1")

            divControl.Attributes.Add("class", "holder")
            divControl.InnerHtml = "<div class=""img""> <img src=" & tweet.User.ProfileImageUrl & "/> </div> <b>" & tweet.User.Name & "</b> --- " & tweet.Text & " <br>"
            pl.Controls.Add(divControl)





            Debug.WriteLine(tweet.User.Name & "(@" & tweet.User.ScreenNameList & ") " & " :: " & tweet.Text)

        Next
    End Sub

    Public Function getTweetInfo(context As TwitterContext, id As Integer)
        Dim user As Status


    End Function



End Class