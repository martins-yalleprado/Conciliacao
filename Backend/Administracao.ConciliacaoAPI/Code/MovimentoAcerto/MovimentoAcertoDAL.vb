Imports Administracao.ConciliacaoAPI
Imports Administracao.ConciliacaoAPI.Model
Imports Administracao.ConciliacaoAPI.Util
Imports Oracle.ManagedDataAccess.Client
Namespace Code.MovimentoAcerto
  Public Class MovimentoAcertoDAL

    Private oracleConnection As OracleConnection
    Public Sub New()
      Try
        oracleConnection = New OracleConnection(Utils.ORACLE_CONNECCAO)
        oracleConnection.Open()
      Catch ex As Exception
        Throw New Exception("Erro ao conectar ao banco de dados.")
      End Try
    End Sub
    Public Sub UpdateMovimentoAcerto(MovimentoAcerto As MovimentoAcertoModel)
      Dim command As New OracleCommand()
      command.Connection = oracleConnection
      Dim transaction As OracleTransaction
      Dim sql As New MovimentoAcertoSQL()
      ' Start a local transaction
      transaction = oracleConnection.BeginTransaction()
      ' Assign transaction object for a pending local transaction
      command.Transaction = transaction

      Try
        command.CommandText = sql.UpdateMovimentoAcerto()

        command.Parameters.Add("VLRMOVCOB", MovimentoAcerto.VlrMovimentoCobranca)
        command.Parameters.Add("VLRMOVCTB", MovimentoAcerto.VlrMovimentoContabil)
        command.Parameters.Add("DESACE", MovimentoAcerto.DesAcertoConciliacaoBancaria)
        command.Parameters.Add("CODIDTCTB", MovimentoAcerto.CodIdentidadeContabil)
        command.Parameters.Add("DATMOV", MovimentoAcerto.DataMovimento)
        command.Parameters.Add("NUMSEQLMT", MovimentoAcerto.NumSequenciaLancamento)
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

    Public Sub InsertMovimentoAcerto(MovimentoAcerto As MovimentoAcertoModel)
      Dim command As New OracleCommand()
      command.Connection = oracleConnection
      Dim transaction As OracleTransaction
      Dim sql As New MovimentoAcertoSQL()
      ' Start a local transaction
      transaction = oracleConnection.BeginTransaction()
      ' Assign transaction object for a pending local transaction
      command.Transaction = transaction

      Try
        command.CommandText = sql.InsertMovimentoAcerto()

        command.Parameters.Add("VLRMOVCOB", MovimentoAcerto.VlrMovimentoCobranca)
        command.Parameters.Add("CODIDTCTB", MovimentoAcerto.CodIdentidadeContabil)
        command.Parameters.Add("DATMOV", MovimentoAcerto.DataMovimento)
        command.Parameters.Add("NUMSEQLMT", MovimentoAcerto.NumSequenciaLancamento)
        command.Parameters.Add("VLRMOVCTB", MovimentoAcerto.VlrMovimentoContabil)
        command.Parameters.Add("DESACE", MovimentoAcerto.DesAcertoConciliacaoBancaria)
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
    Public Function SelectMovimentoAcerto() As List(Of MovimentoAcertoModel)
      Dim sql As New MovimentoAcertoSQL()

      Dim command As New OracleCommand()
      command.Connection = oracleConnection
      command.CommandText = sql.SelectMovimentoAcerto()
      command.CommandType = System.Data.CommandType.Text
      Dim reader As OracleDataReader = command.ExecuteReader()
      Dim list As New List(Of MovimentoAcertoModel)()

      Try
        While reader.Read()
          list.Add(New MovimentoAcertoModel() With {
                   .DataMovimento = reader.GetDateTime(0),
                   .NumSequenciaLancamento = reader.GetInt32(1),
                   .VlrMovimentoContabil = reader.GetDecimal(2),
                   .VlrMovimentoCobranca = reader.GetDecimal(3),
                   .DesAcertoConciliacaoBancaria = reader.GetString(4),
                   .CodIdentidadeContabil = reader.GetInt32(5),
          .MovimentoContabilModel = New MovimentoContabilModel() With {.CodIdentidadeContabil = reader.GetInt32(5),
                                                                 .CodUnidadeNegocio = reader.GetInt32(6),
                                                                 .CodContaContabil = reader.GetInt32(7),
                                                                 .NomSistemaInformacao = reader.GetString(8),
                                                                 .CodEventoContabil = reader.GetInt32(9),
                                                                 .CodFatoContabil = reader.GetInt32(10),
                                                                 .DesEventoContabil = reader.GetString(11),
                                                                 .DesFatoContabil = reader.GetString(12)
                   }
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
    Public Function SelectMovimentoAcerto(dataMov As DateTime) As List(Of MovimentoAcertoModel)
      Dim sql As New MovimentoAcertoSQL()


      Dim command As New OracleCommand()
      command.Connection = oracleConnection
      command.CommandText = sql.SelectMovimentoAcertoPorData()
      command.CommandType = System.Data.CommandType.Text
      command.Parameters.Add("DATMOV", dataMov.ToString("yyyy-MM-dd"))
      Dim reader As OracleDataReader = command.ExecuteReader()
      Dim list As New List(Of MovimentoAcertoModel)()

      Try
        While reader.Read()
          list.Add(New MovimentoAcertoModel() With {
                   .DataMovimento = reader.GetDateTime(0),
                   .NumSequenciaLancamento = reader.GetInt32(1),
                   .VlrMovimentoContabil = reader.GetDecimal(2),
                   .VlrMovimentoCobranca = reader.GetDecimal(3),
                   .DesAcertoConciliacaoBancaria = reader.GetString(4),
                   .CodIdentidadeContabil = reader.GetInt32(5),
          .MovimentoContabilModel = New MovimentoContabilModel() With {.CodIdentidadeContabil = reader.GetInt32(5),
                                                                 .CodUnidadeNegocio = reader.GetInt32(6),
                                                                 .CodContaContabil = reader.GetInt32(7),
                                                                 .NomSistemaInformacao = reader.GetString(8),
                                                                 .CodEventoContabil = reader.GetInt32(9),
                                                                 .CodFatoContabil = reader.GetInt32(10),
                                                                 .DesEventoContabil = reader.GetString(11),
                                                                 .DesFatoContabil = reader.GetString(12)
                   }
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



    Public Sub DeleteMovimentoAcerto(sequencial As Integer, data As Date, CodIdentidadeContabil As Integer)
      Dim command As New OracleCommand()
      command.Connection = oracleConnection
      Dim transaction As OracleTransaction
      Dim sql As New MovimentoAcertoSQL()
      ' Start a local transaction
      transaction = oracleConnection.BeginTransaction()
      ' Assign transaction object for a pending local transaction
      command.Transaction = transaction

      Try
        command.CommandText = sql.InsertMovimentoAcerto()


        command.Parameters.Add("CODIDTCTB", CodIdentidadeContabil)
        command.Parameters.Add("DATMOV", data)
        command.Parameters.Add("NUMSEQLMT", sequencial)

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

    Public Function SelectMovimentoAcertoPorId(sequencial As Integer, data As Date, CodIdentidadeContabil As Integer) As MovimentoAcertoModel
      'Throw New NotImplementedException()
      Dim sql As New MovimentoAcertoSQL()


      Dim command As New OracleCommand()
      command.Connection = oracleConnection
      command.CommandText = sql.SelectMovimentoAcertoPorId()
      command.CommandType = System.Data.CommandType.Text
      command.Parameters.Add("CODIDTCTB", CodIdentidadeContabil)
      command.Parameters.Add("DATMOV", data)
      command.Parameters.Add("NUMSEQLMT", sequencial)
      Dim reader As OracleDataReader = command.ExecuteReader()
      Dim MovimentoAcertoModel As MovimentoAcertoModel = Nothing

      Try

        If reader.Read() Then
          MovimentoAcertoModel = New MovimentoAcertoModel() With {
                   .DataMovimento = reader.GetDateTime(0),
                   .NumSequenciaLancamento = reader.GetInt32(1),
                   .VlrMovimentoContabil = reader.GetDecimal(2),
                   .VlrMovimentoCobranca = reader.GetDecimal(3),
                   .DesAcertoConciliacaoBancaria = reader.GetString(4),
                   .CodIdentidadeContabil = reader.GetInt32(5),
          .MovimentoContabilModel = New MovimentoContabilModel() With {.CodIdentidadeContabil = reader.GetInt32(5),
                                                                 .CodUnidadeNegocio = reader.GetInt32(6),
                                                                 .CodContaContabil = reader.GetInt32(7),
                                                                 .NomSistemaInformacao = reader.GetString(8),
                                                                 .CodEventoContabil = reader.GetInt32(9),
                                                                 .CodFatoContabil = reader.GetInt32(10)}
          }
        End If
        Return MovimentoAcertoModel
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

