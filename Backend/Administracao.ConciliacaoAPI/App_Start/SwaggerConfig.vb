Imports System.Web.Http
Imports Swashbuckle.Application
'<Assembly: PreApplicationStartMethod(GetType(SwaggerConfig), "Register")>

Public Class SwaggerConfig
    Public Shared Sub Register(httpConfig)
        Dim thisAssembly = GetType(SwaggerConfig).Assembly

        GlobalConfiguration.Configuration.EnableSwagger(Function(c) c.SingleApiVersion("v1", "Administracao.ConciliacaoAPI")).EnableSwaggerUi(Sub(c) c.EnableApiKeySupport("Authorization", "header"))
    End Sub

End Class