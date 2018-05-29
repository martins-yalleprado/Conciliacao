Imports Martins.Conciliacao.Model

Namespace Code.Unidade
  Public Class UnidadeBLL
    Public Function SelectUnidade() As List(Of UnidadeModel)
      Try
        Dim dal As New UnidadeDAL()
        Return dal.SelectUnidade()
      Catch ex As Exception
        Throw ex
      End Try
    End Function
    Public Sub AtivarUnidade(Unidade As UnidadeModel)
      Try
        Dim dal As New UnidadeDAL()
        dal.AtivarUnidade(Unidade)
      Catch ex As Exception
        Throw ex
      End Try
    End Sub
    Public Sub InativarUnidade(Unidade As UnidadeModel)
      Try
        Dim dal As New UnidadeDAL()
        dal.InativarUnidade(Unidade)
      Catch ex As Exception
        Throw ex
      End Try
    End Sub
    Public Sub InsertUnidade(Unidade As UnidadeModel)
      Try
        Dim dal As New UnidadeDAL()
        dal.InsertUnidade(Unidade)
      Catch ex As Exception
        Throw ex
      End Try
    End Sub
  End Class
End Namespace
