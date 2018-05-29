Imports System.Collections.Concurrent
Imports System.Security.Cryptography
Imports Microsoft.Owin.Security.DataHandler.Encoder

Public Class WebApplicationAccess
  Public Property ClientId As String
  Public Property AccessKey As String
  Public Property SecretKey As String
  Public Property ApplicationName As String
  Public Shared WebApplicationAccessList As ConcurrentDictionary(Of String, WebApplicationAccess) = New ConcurrentDictionary(Of String, WebApplicationAccess)()

  Shared Sub New()
    WebApplicationAccessList.TryAdd("e84a2d13704647d18277966ec839d39e", New WebApplicationAccess() With {
        .AccessKey = "CgP7NyLXtaGmyOgjj3sUMwmAlrSKqa5JyZ4P1OlfQeM",
        .SecretKey = "UTboSKRUb13ZmztLtyB0W4BN37ndx_aK8__ry9sxfv8",
        .ApplicationName = "ApplicationTests",
        .ClientId = "e84a2d13704647d18277966ec839d39e"
    })
  End Sub

  Public Shared Function GrantApplication(ByVal name As String) As WebApplicationAccess
    Dim clientId = Guid.NewGuid().ToString("N")
    Dim key = New Byte(31) {}
    RNGCryptoServiceProvider.Create().GetBytes(key)
    Dim base64Secret = TextEncodings.Base64Url.Encode(key)
    Dim accessKey = New Byte(31) {}
    RNGCryptoServiceProvider.Create().GetBytes(key)
    Dim accessKeyText = TextEncodings.Base64Url.Encode(key)
    Dim newWebApplication As WebApplicationAccess = New WebApplicationAccess With {
        .ClientId = clientId,
        .SecretKey = base64Secret,
        .AccessKey = accessKeyText,
        .ApplicationName = name
    }
    WebApplicationAccessList.TryAdd(clientId, newWebApplication)
    Return newWebApplication
  End Function

  Public Shared Function Find(ByVal clientId As String) As WebApplicationAccess
    Dim webApplication As WebApplicationAccess = Nothing

    If WebApplicationAccessList.TryGetValue(clientId, webApplication) Then
      Return webApplication
    End If

    Return Nothing
  End Function
End Class
