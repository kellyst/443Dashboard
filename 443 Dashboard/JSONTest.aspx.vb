Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.IO
Imports Microsoft.AspNet.SignalR
Imports System.Web.UI.HtmlControls

Public Class JSONTest
    Inherits System.Web.UI.Page
    Dim obj As NYTimes_json

    Public Property title As JArray = New JArray()
    Public Property byline As JArray = New JArray()

    Public Property published_date As JArray = New JArray()
    Public Property url As JArray = New JArray()
    Public Property media As JArray = New JArray()

    Public Property abstract As JArray = New JArray()





    Public Sub New()




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

End Class

''' <summary>
''' 
''' </summary>
''' <remarks></remarks>
Public Class NYTimes_json

    '    Public Function occupy() As String
    '        Dim x As Integer = 0
    '        Dim listCollection As New List(Of Collection)
    '        Dim infoCollection As New Collection
    '        Dim resultsArr As Newtonsoft.Json.Linq.JArray = results
    '        Dim colle As JEnumerable(Of JToken)
    '        Dim title, byline, abstract, url, author As JArray
    '        title = New JArray()

    '        'Dim a As JToken = colle.Item("title")
    '        Dim urls, titles, bylines, abstracts, authors As JToken
    '        url = New JArray()
    '        title = New JArray()
    '        byline = New JArray()


    '        urls = resultsArr.Item(x).Item("url")
    '        url.Add(urls)
    '        titles = resultsArr.Item(x).Item("title")
    '        title.Add(titles)
    '        bylines = resultsArr.Item(x).Item("byline")
    '        byline.Add(bylines)






    '        ' While x = 0 <> 15

    '        'url = resultsArr.Next.Item("url")

    '        ''url = resultsArr.First.Item("url")
    '        'infoCollection.Add("url", url)
    '        'title = resultsArr.First.Item("title")
    '        'infoCollection.Add("title", title)
    '        'author = resultsArr.First.Item("byline")
    '        'infoCollection.Add("author", author) ' byline is author.. idk why
    '        'abstract = resultsArr.First.Item("abstract")
    '        'infoCollection.Add("abstract", abstract)

    '        'listCollection.Add(infoCollection)
    '        'infoCollection.Clear()

    '        'End While


    '        Return "bye"
    '    End Function
    Public Property status As String
    Public Property num_results As Integer
    Public Property results As Object
    Public Property title As Object
    Public Property author As Object
    Public Property url As Object
    Public Property id As Object
    Public Property abstract As Object

    Public Property image As Object


End Class