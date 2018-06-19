Imports Administracao.ConciliacaoAPI
Imports Administracao.ConciliacaoAPI.Model
Imports Administracao.ConciliacaoAPI.Util
Imports Oracle.ManagedDataAccess.Client
Namespace Code.Saldo
  Public Class SaldoDAL

    Private oracleConnection As OracleConnection
    Public Sub New()
      Try
        oracleConnection = New OracleConnection(Utils.ORACLE_CONNECCAO)
        oracleConnection.Open()
      Catch ex As Exception
        Throw New Exception("Erro ao conectar ao banco de dados.")
      End Try
    End Sub
    Public Sub UpdateSaldo(Saldo As SaldoModel)
      Dim command As New OracleCommand()
      command.Connection = oracleConnection
      Dim transaction As OracleTransaction
      Dim sql As New SaldoSQL()
      ' Start a local transaction
      transaction = oracleConnection.BeginTransaction()
      ' Assign transaction object for a pending local transaction
      command.Transaction = transaction

      Try
        command.CommandText = sql.UpdateSaldo()
        command.Parameters.Add("VLRSLDCTB", Saldo.VlrSaldoContabil)
        command.Parameters.Add("VLRSLDCOB", Saldo.VlrSaldoCobranca)
        command.Parameters.Add("VLRSLDCTBINF", Saldo.VlrSaldoContabilInf)
        command.Parameters.Add("VLRSLDCOBINF", Saldo.VlrSaldoCobrancaInf)
        command.Parameters.Add("CODUNDNGC", Saldo.CodUnidade)
        command.Parameters.Add("CODCNTCTB", Saldo.CodConta)
        command.Parameters.Add("DATMOV", Saldo.DataMovimentacao)
        command.ExecuteNonQuery()
        transaction.Commit()
      Catch ex As Exception
        transaction.Rollback()
        If oracleConnection IsNot Nothing Then
          oracleConnection.Close()
        End If
        Throw ex
      End Try
    End Sub

    Public Sub InsertSaldo(Saldo As SaldoModel)
      Dim command As New OracleCommand()
      command.Connection = oracleConnection
      Dim transaction As OracleTransaction
      Dim sql As New SaldoSQL()
      ' Start a local transaction
      transaction = oracleConnection.BeginTransaction()
      ' Assign transaction object for a pending local transaction
      command.Transaction = transaction

      Try
        command.CommandText = sql.InsertSaldo()
        command.Parameters.Add("CODUNDNGC", Saldo.CodUnidade)
        command.Parameters.Add("CODCNTCTB", Saldo.CodConta)
        command.Parameters.Add("DATMOV", Saldo.DataMovimentacao)
        command.Parameters.Add("VLRSLDCTB", Saldo.VlrSaldoContabil)
        command.Parameters.Add("VLRSLDCOB", Saldo.VlrSaldoCobranca)
        command.Parameters.Add("VLRSLDCTBINF", Saldo.VlrSaldoContabilInf)
        command.Parameters.Add("VLRSLDCOBINF", Saldo.VlrSaldoCobrancaInf)

        command.ExecuteNonQuery()
        transaction.Commit()
      Catch ex As Exception
        transaction.Rollback()
        If oracleConnection IsNot Nothing Then
          oracleConnection.Close()
        End If
        Throw ex
      End Try
    End Sub

    Public Function SelectSaldo() As List(Of SaldoModel)
      Dim sql As New SaldoSQL()


      Dim command As New OracleCommand()
      command.Connection = oracleConnection
      command.CommandText = sql.SelectSaldo()
      command.CommandType = System.Data.CommandType.Text
      command.Parameters.Add("FLGRGTMOV", "0")
      Dim reader As OracleDataReader = command.ExecuteReader()
      Dim list As New List(Of SaldoModel)()

      Try

        While reader.Read()
          list.Add(New SaldoModel() With {
          .CodConta = reader.GetInt32(0),
          .CodUnidade = reader.GetInt32(1),
          .DataMovimentacao = reader.GetDateTime(2),
          .VlrSaldoContabil = reader.GetDecimal(3),
          .VlrSaldoCobranca = reader.GetDecimal(4),
          .VlrSaldoContabilInf = reader.GetDecimal(5),
          .VlrSaldoCobrancaInf = reader.GetDecimal(6)
          })
        End While



        Return list
      Catch ex As Exception
        Throw ex
      Finally

        If oracleConnection IsNot Nothing Then
          oracleConnection.Close()
        End If
      End Try
    End Function

    Public Sub DeleteSaldo(ByVal CodUnidade As Integer, ByVal CodConta As Integer, ByVal DataMov As DateTime)
      Dim command As New OracleCommand()
      Dim transaction As OracleTransaction = oracleConnection.BeginTransaction()
      ' Assign transaction object for a pending local transaction
      command.Connection = oracleConnection
      command.Transaction = transaction
      Try
        Dim sql As New SaldoSQL()
        command.CommandText = sql.DeleteSaldo()
        command.Parameters.Add("CODUNDNGC", CodUnidade)
        command.Parameters.Add("CODCNTCTB", CodConta)
        command.Parameters.Add("DATMOV", DataMov)
        command.ExecuteNonQuery()

        transaction.Commit()
      Catch ex As Exception
        transaction.Rollback()

        Throw ex
      End Try
    End Sub

        Public Function SelectSaldoPorId(ByVal CodUnidade As Integer, ByVal CodConta As Integer, ByVal DataMov As DateTime) As List(Of SaldoModel)
            Dim sql As New SaldoSQL()


            Dim command As New OracleCommand()
            command.Connection = oracleConnection
            command.CommandText = sql.SelectSaldoPorId()
            command.CommandType = System.Data.CommandType.Text
            command.Parameters.Add("CODUNDNGC", CodUnidade)
            command.Parameters.Add("CODCNTCTB", CodConta)
            command.Parameters.Add("DATMOV", DataMov.ToString("yyyy-MM-dd"))
            Dim reader As OracleDataReader = command.ExecuteReader()

            Dim list As New List(Of SaldoModel)()

            Try

                While reader.Read()
                    list.Add(New SaldoModel() With {
          .CodConta = reader.GetInt32(0),
          .CodUnidade = reader.GetInt32(1),
          .DataMovimentacao = reader.GetDateTime(2),
          .VlrSaldoContabil = reader.GetDecimal(3),
          .VlrSaldoCobranca = reader.GetDecimal(4),
          .VlrSaldoContabilInf = reader.GetDecimal(5),
          .VlrSaldoCobrancaInf = reader.GetDecimal(6)
          })
                End While



                Return list
            Catch ex As Exception
                Throw ex
            Finally

                If oracleConnection IsNot Nothing Then
                    oracleConnection.Close()
                End If
            End Try
        End Function
    End Class
End Namespace
