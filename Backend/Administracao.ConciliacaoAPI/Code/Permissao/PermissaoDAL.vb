Imports Oracle.ManagedDataAccess.Client
Imports Administracao.ConciliacaoAPI.Model
Imports Administracao.ConciliacaoAPI.Util

Namespace Code.Permissao
  Public Class PermissaoDAL
    Private OracleConnection As OracleConnection
    Public Sub New()
      Try
        OracleConnection = New OracleConnection(Utils.ORACLE_CONNECCAO)
        OracleConnection.Open()
      Catch ex As Exception
        Throw New Exception("Erro ao conectar ao banco de dados.")
      End Try
    End Sub
    Public Function SelectPermissao(lstNomGrpAcs As List(Of String)) As List(Of PermissaoModel)
      Dim permissoes = New List(Of PermissaoModel)()
      Dim lstUpdNomGrpAcs = New List(Of String)()

      For Each item As Object In lstNomGrpAcs
        lstUpdNomGrpAcs.Add(String.Format("'{0}'", item))
      Next

      Dim strNomGrpAcs = String.Join(",", lstUpdNomGrpAcs)

      If lstNomGrpAcs.Count = 0 OrElse String.IsNullOrEmpty(strNomGrpAcs) Then
        Return permissoes
      End If

      Dim databaseCommand As OracleCommand = Nothing
      Dim command As OracleCommand = Nothing

      Try
        Dim sqlCmd As New PermissaoSQL()

        command = New OracleCommand(sqlCmd.SelectPermissao(strNomGrpAcs), OracleConnection)

        command.Connection.Open()

        Dim dt As New DataTable()
        dt.Load(command.ExecuteReader())

        For Each row As DataRow In dt.Rows
          permissoes.Add(New PermissaoModel() With {
                        .CODACSFUN = row.Field(Of Long)("CODACSFUN"),
                        .DESACSFUN = row.Field(Of [String])("DESACSFUN")
                    })
        Next
      Catch ex As Exception
        Throw ex
      Finally
        If command IsNot Nothing AndAlso command.Connection.State = ConnectionState.Open Then
          command.Connection.Close()
        End If

        If databaseCommand IsNot Nothing AndAlso databaseCommand.Connection IsNot Nothing AndAlso databaseCommand.Connection.State = ConnectionState.Open Then
          databaseCommand.Connection.Close()
        End If
      End Try

      Return permissoes
    End Function
  End Class
End Namespace
