Imports LinqToTwitter
Imports Newtonsoft.Json.Linq
Imports Newtonsoft.Json


Public Class _default

    Inherits System.Web.UI.Page

    Dim obj As NYTimes_json

    Public Property title As JArray = New JArray()
    Public Property byline As JArray = New JArray()

    Public Property published_date As JArray = New JArray()
    Public Property url As JArray = New JArray()
    Public Property media As JArray = New JArray()

    Public Property abstract As JArray = New JArray()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim jsonData As NYTimes_json = New NYTimes_json()
        'Dim twitter As JSONTwitter = New JSONTwitter()
        ' twitter.twitter(sender, e)
        ' lblInfo.Text = jsonData.author & " : " & jsonData.title & " : " & jsonData.abstract

    End Sub

    Protected Sub iBtn_nyTimes_Click(sender As Object, e As ImageClickEventArgs) Handles iBtn_nyTimes.Click
        'Call NY Times API from hub/JSON here

        Dim webClient As New System.Net.WebClient
        Dim jsonDB As New Dictionary(Of String, Object)
        Dim jsStream As String = webClient.DownloadString("http://api.nytimes.com/svc/mostpopular/v2/mostviewed/all-sections/1.json?api-key=d657c0a64ae6788a338a7f090ec5d7cc:7:71710801")
        'Dim jsReader As StreamReader = New StreamReader(jsStream)
        'Dim jsonread As JsonTextReader = New JsonTextReader(jsReader)
        'Got to a point where I can seperate the different properties using the class below.. But I have not been able to manipulate the sub arrays such as 
        'results -> title, author, url. 
        obj = JsonConvert.DeserializeObject(Of NYTimes_json)(jsStream)

        Dim resultsArr As Newtonsoft.Json.Linq.JArray = obj.results
        Dim imgArray As JArray = media

        Dim urls, titles, bylines, dates, abstracts, images, metadata As JToken
        Dim x As Integer = 0


        While x < 15

            urls = resultsArr.Item(x).Item("url")
            url.Add(urls)
            titles = resultsArr.Item(x).Item("title")
            title.Add(titles)
            bylines = resultsArr.Item(x).Item("byline")
            byline.Add(bylines)
            dates = resultsArr.Item(x).Item("published_date")
            published_date.Add(dates)
            abstracts = resultsArr.Item(x).Item("abstract")
            abstract.Add(abstracts)
            images = resultsArr.Item(x).Item("media")
            media.Add("media")
            Dim divControl As New HtmlGenericControl("div")
            Dim pl As PlaceHolder = New PlaceHolder()
            pl = Me.FindControl("place")


            divControl.Attributes.Add("class", "holder")
            divControl.InnerHtml = ControlChars.CrLf & " <b><a href=" & url.Item(x).ToString() & ">" & title.Item(x).ToString() & "</a></b> <br> " & abstract.Item(x).ToString() & "<br> " & byline.Item(x).ToString() & "     Published: " & published_date.Item(x).ToString() & "<br>"

            pl.Controls.Add(divControl)

            x += 1
        End While


        ' LblInfo.Text = obj.author & " : " & obj.title & " : " & obj.abstract
    End Sub

    Public Function getInfo(index As Integer) As Collection
        Dim coll As Collection = New Collection()


        coll.Add(url.Item(index), "url")
        coll.Add(title.Item(index), "title")
        coll.Add(byline.Item(index), "byline")
        coll.Add(published_date.Item(index), "published_date")


        Return coll
    End Function


    Protected Sub iBtn_facebook_Click(sender As Object, e As ImageClickEventArgs) Handles iBtn_facebook.Click
        'Call Facebook API from hub/JSON here
    End Sub

    Public Async Sub twitter(sender As Object, e As EventArgs)
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


        Dim alltweets As New List(Of Status)
        Dim tweets = (From tweet In tContext.Status Where tweet.Type = StatusType.Home Select tweet).ToList()
        Dim x As Integer = 0
        If tweets.Count > 0 Then
            alltweets.AddRange(tweets)

        End If

        For Each tweet In alltweets

            Dim divControl As New HtmlGenericControl("div")
            Dim pl As PlaceHolder = New PlaceHolder()
            pl = MyBase.FindControl("place")

            divControl.Attributes.Add("class", "holder")
            divControl.InnerHtml = "<div class=""img""><img width=""100%"" height=""100%"" src=""" & tweet.User.ProfileImageUrl & """ /></div> <br> <b>" & tweet.User.Name & "</b>  <br> " & tweet.Text & " <br>" & ControlChars.CrLf
            pl.Controls.Add(divControl)





            Debug.WriteLine(tweet.User.Name & "(@" & tweet.User.ScreenNameList & ") " & " :: " & tweet.Text)

        Next
    End Sub



    Protected Sub iBtn_twitter_Click(sender As Object, e As ImageClickEventArgs) Handles iBtn_twitter.Click
        'Call Twitter API from hub/JSON here
        twitter(sender, e)

    End Sub

End Class

