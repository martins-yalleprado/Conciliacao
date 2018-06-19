Imports Administracao.ConciliacaoAPI
Imports Administracao.ConciliacaoAPI.Model
Namespace Code.Saldo
  Public Class SaldoBLL
    Public Function SelectSaldo() As List(Of SaldoModel)
      Try
        Dim dal As New SaldoDAL
        Return dal.SelectSaldo()
      Catch e As Exception
        Throw e
      End Try
    End Function

    Public Sub DeleteSaldo(ByVal CodUnidade As Integer, ByVal CodConta As Integer, ByVal DataMov As DateTime)
      Try
        Dim dal As New SaldoDAL
        dal.DeleteSaldo(CodUnidade, CodConta, DataMov)
      Catch e As Exception
        Throw e
      End Try
    End Sub

    Public Sub InsertSaldo(Saldo As SaldoModel)
      Try
        Dim dal As New SaldoDAL
        dal.InsertSaldo(Saldo)
      Catch e As Exception
        Throw e
      End Try
    End Sub

        Public Function SelectSaldoPorId(codUnidade As Integer, codConta As Integer, dataMov As Date) As List(Of SaldoModel)
            Try
                Dim dal As New SaldoDAL
                Return dal.SelectSaldoPorId(codUnidade, codConta, dataMov)
            Catch e As Exception
                Throw e
            End Try
        End Function

        Public Sub UpdateSaldo(Saldo As SaldoModel)
      Try
        Dim dal As New SaldoDAL
        dal.UpdateSaldo(Saldo)
      Catch e As Exception
        Throw e
      End Try
    End Sub
  End Class
End Namespace
