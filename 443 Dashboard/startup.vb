Imports Microsoft.AspNet.SignalR
Imports Microsoft.Owin
Imports Owin
<Assembly: OwinStartup(GetType(dashboard.startup))> 
Namespace dashboard
    Public Class startup
        Public Sub Configuration(app As IAppBuilder)
            ' Any connection or hub wire up and configuration should go here
            app.MapSignalR()
        End Sub
    End Class
End Namespace
