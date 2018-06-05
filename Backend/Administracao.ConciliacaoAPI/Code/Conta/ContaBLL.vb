Imports Martins.Conciliacao.Model

Namespace Code.Conta
  Public Class ContaBLL
    Public Function SelectConta() As List(Of ContaModel)
      Try
        Dim dal As New ContaDAL()
        Return dal.SelectConta()
      Catch ex As Exception
        Throw ex
      End Try
    End Function
    Public Sub AtivarConta(Conta As ContaModel)
      Try
        Dim dal As New ContaDAL()
        dal.AtivarConta(Conta)
      Catch ex As Exception
        Throw ex
      End Try
    End Sub
    Public Sub InativarConta(Conta As ContaModel)
            Try
                Dim dal As New ContaDAL()
                dal.InativarConta(Conta)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Public Sub InsertConta(Conta As ContaModel)
            Try
                Dim dal As New ContaDAL()
                dal.InsertConta(Conta)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
    End Class
End Namespace
