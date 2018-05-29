Imports Martins.Conciliacao.Model
Imports Martins.Conciliacao.Util
Imports Oracle.ManagedDataAccess.Client

Namespace Code.UnidadeConta
  Public Class UnidadeContaDAL

    Public oracleConnection As OracleConnection
    Public Sub New()
      oracleConnection = New OracleConnection(Utils.ORACLE_CONNECCAO)
      oracleConnection.Open()
    End Sub
    Public Function SelectUnidadeConta() As List(Of UnidadeContaModel)
      Dim sql As New UnidadeContaSQL()


      Dim command As New OracleCommand()
      command.Connection = oracleConnection
      command.CommandText = sql.SelectUnidadeConta()
      command.CommandType = System.Data.CommandType.Text
      Dim reader As OracleDataReader = command.ExecuteReader()
      Dim UnidadeConta As New List(Of UnidadeContaModel)()

      Try

        While reader.Read()
          UnidadeConta.Add(New UnidadeContaModel() With {
                                   .codUnidadeConta = reader.GetInt32(0),
                                   .codConta = reader.GetInt32(1),
                                   .codUnidade = reader.GetInt32(2),
                                   .situacao = reader.GetString(3),
                                   .codFuncionario = reader.GetInt32(4),
                                   .situacaoLabel = If(reader.GetString(3) = "1", "ativo", "Inativo")
                              })
        End While


        Return UnidadeConta
      Catch ex As Exception
        Throw ex
      Finally

        If oracleConnection IsNot Nothing Then
          oracleConnection.Close()
        End If
      End Try
    End Function

    Public Sub AtivarUnidadeConta(unidadeConta As UnidadeContaModel)
      Dim command As New OracleCommand()
      command.Connection = oracleConnection
      Dim transaction As OracleTransaction
      Dim sql As New UnidadeContaSQL()
      ' Start a local transaction
      transaction = oracleConnection.BeginTransaction()
      ' Assign transaction object for a pending local transaction
      command.Transaction = transaction

      Try
        command.CommandText = sql.AtivarUnidadeConta()
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

    Public Sub InativarUnidadeConta(unidadeConta As UnidadeContaModel)
      Dim command As New OracleCommand()
      command.Connection = oracleConnection
      Dim transaction As OracleTransaction
      Dim sql As New UnidadeContaSQL()
      ' Start a local transaction
      transaction = oracleConnection.BeginTransaction()
      ' Assign transaction object for a pending local transaction
      command.Transaction = transaction

      Try
        command.CommandText = sql.InativarUnidadeConta()
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

    Public Sub InsertUnidadeConta(unidadeConta As UnidadeContaModel)

      Dim command As New OracleCommand()
      command.Connection = oracleConnection
      Dim transaction As OracleTransaction
      Dim sql As New UnidadeContaSQL()
      ' Start a local transaction
      transaction = oracleConnection.BeginTransaction()
      ' Assign transaction object for a pending local transaction
      command.Transaction = transaction

      Try
        command.CommandText = sql.InsertUnidadeConta()
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
