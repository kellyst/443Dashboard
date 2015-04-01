Imports Microsoft.Owin
Imports Owin
<Assembly: OwinStartup(GetType(dashboard.Startup))> 
Namespace dashboard
    Public Class Startup
        Public Sub Configuration(app As IAppBuilder)
            ' HUB CONNECTION GOES HERE
            app.MapSignalR()
        End Sub
    End Class
End Namespace
