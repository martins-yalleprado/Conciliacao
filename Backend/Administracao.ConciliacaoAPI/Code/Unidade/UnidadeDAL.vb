Imports Oracle.ManagedDataAccess.Client
Imports Administracao.ConciliacaoAPI.Model
Imports Administracao.ConciliacaoAPI.Util

Namespace Code.Unidade
  Public Class UnidadeDAL


    Public oracleConnection As OracleConnection
    Public Sub New()
      Try
        oracleConnection = New OracleConnection(Utils.ORACLE_CONNECCAO)
        oracleConnection.Open()
      Catch ex As Exception
        Throw New Exception("Erro ao conectar ao banco de dados.")
      End Try
    End Sub
    Public Function SelectUnidade() As List(Of UnidadeModel)
      Dim sql As New UnidadeSQL()


      Dim command As New OracleCommand()
      command.Connection = oracleConnection
      command.CommandText = sql.SelectUnidade()
      command.CommandType = System.Data.CommandType.Text
      Dim reader As OracleDataReader = command.ExecuteReader()
      Dim list As New List(Of UnidadeModel)()

      Try

        While reader.Read()

          Dim unidadeModel As New UnidadeModel()
          unidadeModel.CodEmpresa = reader.GetInt32(0)
          unidadeModel.CodUnidade = reader.GetInt32(1)
          unidadeModel.DesUnidade = reader.GetString(2)
          unidadeModel.CodFilialCentroAdministrativo = reader.GetInt32(3)
          unidadeModel.CodFilialTituloPagamento = reader.GetInt32(4)
          unidadeModel.DataCadastro = reader.GetDateTime(5)
          If Not IsDBNull(reader.GetValue(6)) Then
            unidadeModel.DataDesativacao = reader.GetDateTime(6)
          End If
          unidadeModel.CodLivroContabil = reader.GetInt32(7)
          unidadeModel.CodNumericosMaiores = reader.GetInt32(8)
          list.Add(UnidadeModel)
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
    Public Function SelectUnidadePorId(codUnidade As Integer) As UnidadeModel
      Dim sql As New UnidadeSQL()


      Dim command As New OracleCommand()
      command.Connection = oracleConnection
      command.CommandText = sql.SelectUnidadePorId()
      command.Parameters.Add("CODUNDNGC", codUnidade)
      command.CommandType = System.Data.CommandType.Text
      Dim reader As OracleDataReader = command.ExecuteReader()
      Dim unidade As UnidadeModel = Nothing

      Try

                If reader.Read() Then
                    unidade = New UnidadeModel()
                    unidade.CodEmpresa = reader.GetInt32(0)
                    unidade.CodUnidade = reader.GetInt32(1)
                    unidade.DesUnidade = reader.GetString(2)
                    unidade.CodFilialCentroAdministrativo = reader.GetInt32(3)
                    unidade.CodFilialTituloPagamento = reader.GetInt32(4)
                    unidade.DataCadastro = reader.GetDateTime(5)
                    If Not IsDBNull(reader.GetValue(6)) Then
                        unidade.DataDesativacao = reader.GetDateTime(6)
                    End If
                    unidade.CodLivroContabil = reader.GetInt32(7)
                    unidade.CodNumericosMaiores = reader.GetInt32(8)
                End If

                Return unidade
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
        command.Parameters.Add("CodEmpresa", Unidade.CodEmpresa)
        command.Parameters.Add("CodUnidade", Unidade.CodUnidade)
        command.Parameters.Add("DesUnidade", Unidade.DesUnidade)
        command.Parameters.Add("CodFilialCentroAdministrativo", Unidade.CodFilialCentroAdministrativo)
        command.Parameters.Add("CodFilialTituloPagamento", Unidade.CodFilialTituloPagamento)
        command.Parameters.Add("DataCadastro", Unidade.DataCadastro)
        command.Parameters.Add("DataDesativacao", Unidade.DataDesativacao)
        command.Parameters.Add("CodLivroContabil", Unidade.CodLivroContabil)
        command.Parameters.Add("CodNumericosMaiores", Unidade.CodNumericosMaiores)
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
