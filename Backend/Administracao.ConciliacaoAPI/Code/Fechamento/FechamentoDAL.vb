Imports Oracle.ManagedDataAccess.Client
Imports Administracao.ConciliacaoAPI.Model
Imports Administracao.ConciliacaoAPI.Util

Namespace Code.Fechamento
  Public Class FechamentoDAL


    Public oracleConnection As OracleConnection
    Public Sub New()
      Try
        oracleConnection = New OracleConnection(Utils.ORACLE_CONNECCAO)
        oracleConnection.Open()
      Catch ex As Exception
        Throw New Exception("Erro ao conectar ao banco de dados.")
      End Try
    End Sub
    Public Function SelectFechamento() As List(Of FechamentoModel)
      Dim sql As New FechamentoSQL()


      Dim command As New OracleCommand()
      command.Connection = oracleConnection
      command.CommandText = sql.SelectFechamento()
      command.CommandType = System.Data.CommandType.Text
      Dim reader As OracleDataReader = command.ExecuteReader()
      Dim list As New List(Of FechamentoModel)()

      Try

                While reader.Read()
                    Dim Fechamento As New FechamentoModel()
                    Fechamento = New FechamentoModel()
                    Fechamento.CodFechamento = reader.GetInt32(0)
                    Fechamento.DataInicioPeriodo = reader.GetDateTime(1)
                    Fechamento.DataFimPeriodo = reader.GetDateTime(2)
                    Fechamento.DataInclusao = reader.GetDateTime(3)
                    Fechamento.TipoFechamento = reader.GetString(4)
                    Fechamento.Usuario = reader.GetString(5)
                    Fechamento.SaldoFechamento = reader.GetDecimal(7)
                    Fechamento.StatusFechamento = reader.GetString(8)
                    list.Add(Fechamento)
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
        Public Function SelectFechamentoPorTipoID(TipoFechamento As String, CodFechamento As Integer, CodUnidade As Integer, CodConta As Integer) As List(Of FechamentoModel)
            Dim sql As New FechamentoSQL()
            Dim command As New OracleCommand()
            command.Connection = oracleConnection
            command.CommandText = sql.SelectFechamentoPorTipo()
            If String.IsNullOrWhiteSpace(TipoFechamento) Then
                command.Parameters.Add("TipoFechamento", DBNull.Value)
            Else
                command.Parameters.Add("TipoFechamento", TipoFechamento)
            End If
            If CodFechamento = 0 Then
                command.Parameters.Add("CodFechamento", DBNull.Value)
            Else
                command.Parameters.Add("CodFechamento", CodFechamento)
            End If
            If CodUnidade = 0 Then
                command.Parameters.Add("CODUNDNGC", DBNull.Value)
            Else
                command.Parameters.Add("CODUNDNGC", CodUnidade)
            End If
            If CodConta = 0 Then
                command.Parameters.Add("CODCNTCTB", DBNull.Value)
            Else
                command.Parameters.Add("CODCNTCTB", CodConta)
            End If

            command.CommandType = System.Data.CommandType.Text
            Dim reader As OracleDataReader = command.ExecuteReader()
            Dim list As New List(Of FechamentoModel)()

            Try

                While reader.Read()
                    Dim Fechamento As New FechamentoModel()
                    Fechamento = New FechamentoModel()
                    Fechamento.CodFechamento = reader.GetInt32(0)
                    Fechamento.DataInicioPeriodo = reader.GetDateTime(1)
                    Fechamento.DataFimPeriodo = reader.GetDateTime(2)
                    Fechamento.DataInclusao = reader.GetDateTime(3)
                    Fechamento.TipoFechamento = reader.GetString(4)
                    Fechamento.Usuario = reader.GetString(5)
                    Fechamento.SaldoFechamento = reader.GetDecimal(7)
                    Fechamento.StatusFechamento = reader.GetString(8)
                    list.Add(Fechamento)
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

        Public Sub AtivarFechamento(Fechamento As FechamentoModel)
      Dim command As New OracleCommand()
      command.Connection = oracleConnection
      Dim transaction As OracleTransaction
      Dim sql As New FechamentoSQL()
      ' Start a local transaction
      transaction = oracleConnection.BeginTransaction()
      ' Assign transaction object for a pending local transaction
      command.Transaction = transaction

      Try
        command.CommandText = sql.AtivarFechamento()
        command.Parameters.Clear()
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

    Public Sub InativarFechamento(Fechamento As FechamentoModel)
      Dim command As New OracleCommand()
      command.Connection = oracleConnection
      Dim transaction As OracleTransaction
      Dim sql As New FechamentoSQL()
      ' Start a local transaction
      transaction = oracleConnection.BeginTransaction()
      ' Assign transaction object for a pending local transaction
      command.Transaction = transaction

      Try
        command.CommandText = sql.InativarFechamento()
        command.Parameters.Clear()
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

    Public Sub InsertFechamento(Fechamento As FechamentoModel)

      Dim command As New OracleCommand()
      command.Connection = oracleConnection
      Dim transaction As OracleTransaction
      Dim sql As New FechamentoSQL()
      ' Start a local transaction
      transaction = oracleConnection.BeginTransaction()
      ' Assign transaction object for a pending local transaction
      command.Transaction = transaction
      Try
                command.CommandText = sql.InsertFechamento()
                'command.Parameters.Add("CodFechamento", Fechamento.CodFechamento)
                command.Parameters.Add("DataInicioPeriodo", Fechamento.DataInicioPeriodo)
                command.Parameters.Add("DataFimPeriodo", Fechamento.DataFimPeriodo)
                command.Parameters.Add("DataInclusao", Fechamento.DataInclusao)
                command.Parameters.Add("TipoFechamento", Fechamento.TipoFechamento)
                command.Parameters.Add("usuario", Fechamento.Usuario)
                command.Parameters.Add("SaldoFechamento", Fechamento.SaldoFechamento)
                command.Parameters.Add("StatusFechamento", Fechamento.StatusFechamento)
                command.Parameters.Add("CODUNDNGC", Fechamento.CodUnidade)
                command.Parameters.Add("CODCNTCTB", Fechamento.CodConta)


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
  End Class
End Namespace
