Imports System.Web.Http

Public Class WebApiConfig

  Friend Shared Sub Register(config As HttpConfiguration)
    config.MapHttpAttributeRoutes()
    config.Routes.MapHttpRoute(
        name:="DefaultApi",
        routeTemplate:="api/{controller}/{id}",
        defaults:=New With {.id = RouteParameter.[Optional]
    })
  End Sub

  'Friend Shared Sub Register(obj As HttpConfiguration)
  '  Throw New NotImplementedException()
  'End Sub
End Class
