Imports JsonWebToken.Model
Imports Martins.Conciliacao.Model
Imports Newtonsoft.Json
Imports RestSharp
Imports System
Imports System.Net
Imports System.Web.Configuration
Imports System.Web.Http

Namespace Controllers

  <Authorize>
  Public Class PermissaoController
    Inherits ApiController

    <HttpPost>
    Public Function PostAuthenticateAD(user As String, password As String) As AuthenticateAdModel
      Try
        Dim client = New RestClient(WebConfigurationManager.AppSettings("urlAuthenticationAPI"))

        Dim request = New RestRequest(String.Format("/Data/authenticateAD?user={0}&password={1}", user, password), Method.POST)
        request.RequestFormat = DataFormat.Json

        Dim response = client.Execute(request)

        If (response.StatusCode = HttpStatusCode.OK) Then
          Return JsonConvert.DeserializeObject(Of AuthenticateAdModel)(response.Content)
        Else
          Return New AuthenticateAdModel()
        End If

      Catch ex As Exception
        Throw ex
      End Try
    End Function

    '<HttpPost>
    'Public Function PostAuthenticateAD(user As String, password As String) As IHttpActionResult
    '  Try
    '    Dim client = New RestClient(WebConfigurationManager.AppSettings("urlAuthenticationAPI"))

    '    Dim request = New RestRequest(String.Format("/Data/authenticateAD?user={0}&password={1}", user, password), Method.POST)
    '    request.RequestFormat = DataFormat.Json

    '    Dim response = client.Execute(request)

    '    If (response.StatusCode = HttpStatusCode.OK) Then
    '      Dim resp As AuthenticateAdModel = JsonConvert.DeserializeObject(Of AuthenticateAdModel)(response.Content)

    '      Return Ok(resp)
    '    Else
    '      Return Unauthorized()
    '    End If

    '  Catch ex As Exception
    '    Return BadRequest(ex.Message)
    '  End Try
    'End Function

    '<HttpPost>
    'Public Function PostAuthenticateAD(user As String, password As String) As AuthenticateAdModel
    '  Try
    '    Dim client = New WebClient()
    '    client.Headers.Add("User-Agent", "Nobody")

    '    Try
    '      Dim response = client.DownloadString(New Uri(WebConfigurationManager.AppSettings("urlAuthenticationAPI")))
    '      Dim resposta As AuthenticateAdModel = JsonConvert.DeserializeObject(Of AuthenticateAdModel)(response)
    '      Return resposta
    '    Catch ex As Exception
    '      Return New AuthenticateAdModel()
    '    End Try
    '  Catch ex As Exception
    '    Throw ex
    '  End Try
    'End Function

  End Class
End Namespace
