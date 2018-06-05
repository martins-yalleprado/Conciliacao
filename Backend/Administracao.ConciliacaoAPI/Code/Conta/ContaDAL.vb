Imports Oracle.ManagedDataAccess.Client
Imports Martins.Conciliacao.Model
Imports Martins.Conciliacao.Util

Namespace Code.Conta
  Public Class ContaDAL

    Public oracleConnection As OracleConnection
    Public Sub New()
      oracleConnection = New OracleConnection(Utils.ORACLE_CONNECCAO)
      oracleConnection.Open()
    End Sub
    Public Function SelectConta() As List(Of ContaModel)
      Dim sql As New ContaSQL()


      Dim command As New OracleCommand()
      command.Connection = oracleConnection
      command.CommandText = sql.SelectConta()
      command.CommandType = System.Data.CommandType.Text
      Dim reader As OracleDataReader = command.ExecuteReader()
      Dim Conta As New List(Of ContaModel)()

      Try

        While reader.Read()
          Conta.Add(New ContaModel() With {
                         .codConta = reader.GetInt32(0),
                         .nomConta = reader.GetString(1),
                         .desConta = reader.GetString(2),
                         .situacao = reader.GetString(3),
                         .codFuncionario = reader.GetInt32(4),
                         .situacaoLabel = If(reader.GetString(3) = "1", "ativo", "Inativo")
                    })
        End While


        Return Conta
      Catch ex As Exception
        Throw ex
      Finally

        If oracleConnection IsNot Nothing Then
          oracleConnection.Close()
        End If
      End Try
    End Function

    Public Sub AtivarConta(Conta As ContaModel)
      Dim command As New OracleCommand()
      command.Connection = oracleConnection
      Dim transaction As OracleTransaction
      Dim sql As New ContaSQL()
      ' Start a local transaction
      transaction = oracleConnection.BeginTransaction()
      ' Assign transaction object for a pending local transaction
      command.Transaction = transaction

      Try
        command.CommandText = sql.AtivarConta()
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

    Public Sub InativarConta(Conta As ContaModel)
      Dim command As New OracleCommand()
      command.Connection = oracleConnection
      Dim transaction As OracleTransaction
      Dim sql As New ContaSQL()
      ' Start a local transaction
      transaction = oracleConnection.BeginTransaction()
      ' Assign transaction object for a pending local transaction
      command.Transaction = transaction

      Try
        command.CommandText = sql.InativarConta()
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

    Public Sub InsertConta(Conta As ContaModel)

      Dim command As New OracleCommand()
      command.Connection = oracleConnection
      Dim transaction As OracleTransaction
      Dim sql As New ContaSQL()
      ' Start a local transaction
      transaction = oracleConnection.BeginTransaction()
      ' Assign transaction object for a pending local transaction
      command.Transaction = transaction

      Try
        command.CommandText = sql.InsertConta()
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
  End Class
End Namespace
