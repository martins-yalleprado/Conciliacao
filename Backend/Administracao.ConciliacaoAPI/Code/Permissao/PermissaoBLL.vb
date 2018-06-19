Imports Administracao.ConciliacaoAPI.Model

Namespace Code.Permissao
  Public Class PermissaoBLL

    Public Function SelectPermissao(lstNomGrpAcs As List(Of String)) As List(Of PermissaoModel)
      Try
        Return (New PermissaoDAL()).SelectPermissao(lstNomGrpAcs)
      Catch e As Exception
        Throw e
      End Try
    End Function
  End Class
End Namespace
