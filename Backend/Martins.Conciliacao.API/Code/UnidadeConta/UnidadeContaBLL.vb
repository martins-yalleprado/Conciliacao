Imports Martins.Conciliacao.Model

Namespace Code.UnidadeConta
  Public Class UnidadeContaBLL
    Public Function SelectUnidadeConta() As List(Of UnidadeContaModel)
      Try
        Dim dal As New UnidadeContaDAL()
        Return dal.SelectUnidadeConta()
      Catch ex As Exception
        Throw ex
      End Try
    End Function
    Public Sub AtivarUnidadeConta(unidadeConta As UnidadeContaModel)
      Try
        Dim dal As New UnidadeContaDAL()
        dal.AtivarUnidadeConta(unidadeConta)
      Catch ex As Exception
        Throw ex
      End Try
    End Sub
    Public Sub InativarUnidadeConta(unidadeConta As UnidadeContaModel)
      Try
        Dim dal As New UnidadeContaDAL()
        dal.InativarUnidadeConta(unidadeConta)
      Catch ex As Exception
        Throw ex
      End Try
    End Sub
    Public Sub InsertUnidadeConta(unidadeConta As UnidadeContaModel)
      Try
        Dim dal As New UnidadeContaDAL()
        dal.InsertUnidadeConta(unidadeConta)
      Catch ex As Exception
        Throw ex
      End Try
    End Sub
  End Class
End Namespace
