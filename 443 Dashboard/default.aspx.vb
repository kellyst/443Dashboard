Public Class _default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim jsonForNY As JSONTest = New JSONTest()
        Dim jsonData As NYTimes_json = New NYTimes_json()

        lblInfo.Text = jsonData.author & " : " & jsonData.title & " : " & jsonData.abstract

    End Sub

End Class