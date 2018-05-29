Imports Oracle.ManagedDataAccess.Client
Imports Martins.Conciliacao.Model
Imports Martins.Conciliacao.Util

Namespace Code.Unidade
  Public Class UnidadeDAL


    Public oracleConnection As OracleConnection
    Public Sub New()
      oracleConnection = New OracleConnection(Utils.ORACLE_CONNECCAO)
      oracleConnection.Open()
    End Sub
    Public Function SelectUnidade() As List(Of UnidadeModel)
      Dim sql As New UnidadeSQL()


      Dim command As New OracleCommand()
      command.Connection = oracleConnection
      command.CommandText = sql.SelectUnidade()
      command.CommandType = System.Data.CommandType.Text
      Dim reader As OracleDataReader = command.ExecuteReader()
      Dim Unidade As New List(Of UnidadeModel)()

      Try

        While reader.Read()
          Unidade.Add(New UnidadeModel() With {
                         .codUnidade = reader.GetInt32(0),
                         .nomUnidade = reader.GetString(1),
                         .desUnidade = reader.GetString(2),
                         .situacao = reader.GetString(3),
                         .codFuncionario = reader.GetInt32(4),
                         .situacaoLabel = If(reader.GetString(3) = "1", "ativo", "Inativo")
                    })
        End While


        Return Unidade
      Catch ex As Exception
        Throw ex
      Finally

        If oracleConnection IsNot Nothing Then
          oracleConnection.Close()
        End If
      End Try
    End Function
    Public Function SelectUnidadePorId(unidade__1 As Integer) As List(Of UnidadeModel)
      Dim sql As New UnidadeSQL()


      Dim command As New OracleCommand()
      command.Connection = oracleConnection
      command.CommandText = sql.SelectUnidadePorId()
      command.Parameters.Add("CODEMP", unidade__1)
      command.CommandType = System.Data.CommandType.Text
      Dim reader As OracleDataReader = command.ExecuteReader()
      Dim Unidade__2 As New List(Of UnidadeModel)()

      Try

        While reader.Read()
          Unidade__2.Add(New UnidadeModel() With {
                         .codUnidade = reader.GetInt32(0),
                         .nomUnidade = reader.GetString(1),
                         .desUnidade = reader.GetString(2),
                         .situacao = reader.GetString(3),
                         .codFuncionario = reader.GetInt32(4),
                         .situacaoLabel = If(reader.GetString(3) = "1", "ativo", "Inativo")
                    })
        End While


        Return Unidade__2
      Catch ex As Exception
        Throw ex
      Finally

        If oracleConnection IsNot Nothing Then
          oracleConnection.Close()
        End If
      End Try
    End Function

    Public Sub AtivarUnidade(Unidade As UnidadeModel)
      Dim command As New OracleCommand()
      command.Connection = oracleConnection
      Dim transaction As OracleTransaction
      Dim sql As New UnidadeSQL()
      ' Start a local transaction
      transaction = oracleConnection.BeginTransaction()
      ' Assign transaction object for a pending local transaction
      command.Transaction = transaction

      Try
        command.CommandText = sql.AtivarUnidade()
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

    Public Sub InativarUnidade(Unidade As UnidadeModel)
      Dim command As New OracleCommand()
      command.Connection = oracleConnection
      Dim transaction As OracleTransaction
      Dim sql As New UnidadeSQL()
      ' Start a local transaction
      transaction = oracleConnection.BeginTransaction()
      ' Assign transaction object for a pending local transaction
      command.Transaction = transaction

      Try
        command.CommandText = sql.InativarUnidade()
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

    Public Sub InsertUnidade(Unidade As UnidadeModel)

      Dim command As New OracleCommand()
      command.Connection = oracleConnection
      Dim transaction As OracleTransaction
      Dim sql As New UnidadeSQL()
      ' Start a local transaction
      transaction = oracleConnection.BeginTransaction()
      ' Assign transaction object for a pending local transaction
      command.Transaction = transaction

      Try
        command.CommandText = sql.InsertUnidade()
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
