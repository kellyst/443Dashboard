Imports Newtonsoft.Json
Imports System.IO
Imports Microsoft.AspNet.SignalR

Public Class JSONTest
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim webClient As New System.Net.WebClient
        Dim jsonDB As New Dictionary(Of String, Object)
        Dim jsStream As String = webClient.DownloadString("http://api.nytimes.com/svc/mostpopular/v2/mostviewed/all-sections/7.json?api-key=d657c0a64ae6788a338a7f090ec5d7cc:7:71710801")
        'Dim jsReader As StreamReader = New StreamReader(jsStream)
        'Dim jsonread As JsonTextReader = New JsonTextReader(jsReader)
        'Got to a point where I can seperate the different properties using the class below.. But I have not been able to manipulate the sub arrays such as 
        'results -> title, author, url. 
        Dim obj As json_result
        obj = JsonConvert.DeserializeObject(Of json_result)(jsStream)
        lblTest.Text = obj.ToString()
    End Sub
End Class

Public Class json_result
    Public Property status As String
    Public Property num_results As Integer


    Public Property results As Object
    Public Property title As Object
    Public Property author As Object
    Public Property url As Object
    Public Property id As Object
    Public Property abstract As Object


    Public Function getItems(r As Object) As Integer
        Dim resultsArr As Newtonsoft.Json.Linq.JArray = results
        url = resultsArr.First.Item("url")
        title = resultsArr.First.Item("title")
        author = resultsArr.First.Item("byline")
        abstract = resultsArr.First.Item("abstract")
        Return 0
    End Function

    Public Overrides Function ToString() As String


        Return " : " & getItems(results)
    End Function
End Class