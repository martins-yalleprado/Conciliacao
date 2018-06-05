Imports System.IdentityModel.Tokens
Imports Microsoft.Owin.Security
Imports Microsoft.Owin.Security.DataHandler.Encoder
Imports Thinktecture.IdentityModel.Tokens



Public Class CustomJwtFormat
  Implements ISecureDataFormat(Of AuthenticationTicket)

  Private ReadOnly _issuer As String = String.Empty

  Public Sub New(ByVal issuer As String)
    _issuer = issuer
  End Sub

  Public Function Unprotect(ByVal protectedText As String) As AuthenticationTicket
    Throw New NotImplementedException()
  End Function

  Private Function ISecureDataFormat_Protect(data As AuthenticationTicket) As String Implements ISecureDataFormat(Of AuthenticationTicket).Protect
    If data Is Nothing Then Throw New ArgumentNullException("data")
    Dim audience As String = data.Properties.Dictionary("audience")
    If String.IsNullOrWhiteSpace(audience) Then Throw New InvalidOperationException("ClientId e AccessKey não foi encontrado")
    Dim keys = audience.Split(":"c)
    Dim client_id = keys.First()
    Dim accessKey = keys.Last()
    Dim applicationAccess = WebApplicationAccess.Find(client_id)
    Dim keyByteArray = TextEncodings.Base64Url.Decode(applicationAccess.SecretKey)
    Dim signingKey = New HmacSigningCredentials(keyByteArray)
    Dim issued = data.Properties.IssuedUtc
    Dim expires = data.Properties.ExpiresUtc



    '    Optional signingCredentials As SigningCredentials = Nothing

    Dim token = New JwtSecurityToken(_issuer, client_id, data.Identity.Claims, issued.Value.UtcDateTime, expires.Value.UtcDateTime, signingKey)
    Dim handler = New JwtSecurityTokenHandler()
    Dim jwt = handler.WriteToken(token)
    Return jwt
  End Function

  Private Function ISecureDataFormat_Unprotect(protectedText As String) As AuthenticationTicket Implements ISecureDataFormat(Of AuthenticationTicket).Unprotect
    Throw New NotImplementedException()
  End Function
End Class
