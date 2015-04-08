Imports Microsoft.AspNet.SignalR

Public Class DashHub
    Inherits Hub

    Dim com As Hub
    Dim connection As IHubContext
    Dim dash As DashHub


    Public Sub New()
        dash = New DashHub()
    End Sub

    Public Sub New(ByVal hub As DashHub)
        dash = hub
    End Sub

    Public Sub Switch(ByVal id As String)


    End Sub


    Public Overrides Function OnConnected() As Threading.Tasks.Task
        connection = GlobalHost.ConnectionManager.GetHubContext(Of DashHub)()

        Return MyBase.OnConnected()
    End Function
End Class
