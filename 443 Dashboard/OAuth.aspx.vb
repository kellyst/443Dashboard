Imports LinqToTwitter

Public Class OAuth
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim connect As PinAuthorizer = New PinAuthorizer()
        Dim auth As InMemoryCredentialStore = New InMemoryCredentialStore

        connect.CredentialStore = auth

        connect.GoToTwitterAuthorization = Function(PageLink) Process.Start(PageLink)
        connect.AuthorizeAsync()

    End Sub



End Class