Imports Newtonsoft.Json
Imports System.IO
Imports Microsoft.AspNet.SignalR

Public Class JSONTest
    Inherits System.Web.UI.Page
    Dim obj As NYTimes_json

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim webClient As New System.Net.WebClient
        Dim jsonDB As New Dictionary(Of String, Object)
        Dim jsStream As String = webClient.DownloadString("http://api.nytimes.com/svc/mostpopular/v2/mostviewed/all-sections/1.json?api-key=d657c0a64ae6788a338a7f090ec5d7cc:7:71710801")
        'Dim jsReader As StreamReader = New StreamReader(jsStream)
        'Dim jsonread As JsonTextReader = New JsonTextReader(jsReader)
        'Got to a point where I can seperate the different properties using the class below.. But I have not been able to manipulate the sub arrays such as 
        'results -> title, author, url. 
        obj = JsonConvert.DeserializeObject(Of NYTimes_json)(jsStream)
        Dim newDiv As New System.Web.UI.HtmlControls.HtmlGenericControl()
        newDiv.Attributes.Add("class", "holder")
        newDiv.Attributes.Add("id", "test")

        Dim s As String = obj.occupy()

        newDiv.InnerHtml = "<b>" & s & "</b>"
        Me.Controls.Add(newDiv)
        ' LblInfo.Text = obj.author & " : " & obj.title & " : " & obj.abstract
    End Sub
End Class

Public Class NYTimes_json

    Public Function occupy() As String
        Dim x As Integer
        Dim resultsArr As Newtonsoft.Json.Linq.JArray = results
        While x = 0 <> 15
            

            url = resultsArr.First.Item("url")
            title = resultsArr.First.Item("title")
            author = resultsArr.First.Item("byline")
            abstract = resultsArr.First.Item("abstract")

            Return author

        End While


        Return 0
    End Function
    Public Property status As String
    Public Property num_results As Integer
    Public Property results As Object
    Public Property title As Object
    Public Property author As Object
    Public Property url As Object
    Public Property id As Object
    Public Property abstract As Object


End Class