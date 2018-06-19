Imports System.Collections.Generic
Imports System.Configuration
Imports System.Linq
Imports System.Web

Namespace Util
    Public Class Utils

        Private Shared roles As List(Of Object)
        Public Shared ORACLE_CONNECCAO As String = ConfigurationManager.ConnectionStrings("OracleConexao").ConnectionString
        Public Shared Property UserCodeLDAP As String

        Public Shared Property CodigoConta As Long
        Public Shared Property CodigoUnidade As Long
        Public Shared Property DescricaoConta As String
        Public Shared Property DescricaoUnidade As String

        Public Shared Property RolesObject As List(Of Object)
            Get
                Return If(roles.Count = 0, New List(Of Object)(), roles)
            End Get
            Set(ByVal value As List(Of Object))
                roles = value
            End Set
        End Property

    End Class
End Namespace
