Imports Microsoft.AspNet.SignalR.Client.Hubs
Imports Microsoft.AspNet.SignalR


Public Class DashHub
    Inherits Hub
    Public Sub BroadcastMessageToAll(message As String)
        Clients.All.newMessageReceived(message)
    End Sub

    Public Sub JoinAGroup(group As String)
        Groups.Add(Context.ConnectionId, group)
    End Sub

    Public Sub RemoveFromAGroup(group As String)
        Groups.Remove(Context.ConnectionId, group)
    End Sub

    Public Sub BroadcastToGroup(message As String, group As String)
        Clients.Group(group).newMessageReceived(message)
    End Sub
End Class
