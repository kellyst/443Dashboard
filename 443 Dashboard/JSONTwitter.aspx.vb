Imports Newtonsoft.Json
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
        
        tAuthenticate()




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
        Dim reader As StreamReader = New StreamReader(dstream)
        Console.WriteLine(reader.ReadToEnd())








        Return 0

    End Function


End Class