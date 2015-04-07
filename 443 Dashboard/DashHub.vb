Imports Microsoft.AspNet.SignalR

Public Class DashHub
    Inherits Hub

    Dim com As Hub

    Public Sub Init()

    End Sub

    Public Sub Switch(ByVal clicked As View)


    End Sub

    Public Overrides Function OnConnected() As Threading.Tasks.Task



        Return MyBase.OnConnected()
    End Function
End Class
