Imports Administracao.ConciliacaoAPI
Imports Administracao.ConciliacaoAPI.Model
Imports Administracao.ConciliacaoAPI.Util
Imports Oracle.ManagedDataAccess.Client
Namespace Code.MovimentoContabil
  Public Class MovimentoContabilDAL

    Private oracleConnection As OracleConnection
    Public Sub New()
      Try
        oracleConnection = New OracleConnection(Utils.ORACLE_CONNECCAO)
        oracleConnection.Open()
      Catch ex As Exception
        Throw New Exception("Erro ao conectar ao banco de dados.")
      End Try
    End Sub
    Public Sub UpdateMovimentoContabil(MovimentoContabil As MovimentoContabilModel)
      Dim command As New OracleCommand()
      command.Connection = oracleConnection
      Dim transaction As OracleTransaction
      Dim sql As New MovimentoContabilSQL()
      ' Start a local transaction
      transaction = oracleConnection.BeginTransaction()
      ' Assign transaction object for a pending local transaction
      command.Transaction = transaction

      Try
        command.CommandText = sql.UpdateMovimentoContabil()
        command.Parameters.Add("CODCNTCTB", MovimentoContabil.CodContaContabil)
        command.Parameters.Add("CODEVTCTB", MovimentoContabil.CodEventoContabil)
        command.Parameters.Add("NOMSISINF", MovimentoContabil.NomSistemaInformacao)
        command.Parameters.Add("CODFTOCTB", MovimentoContabil.CodFatoContabil)
        command.Parameters.Add("CODUNDNGC", MovimentoContabil.CodUnidadeNegocio)
        command.Parameters.Add("CODIDTCTB", MovimentoContabil.CodIdentidadeContabil)
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

    Public Sub InsertMovimentoContabil(movimentoContabil As MovimentoContabilModel)
      Dim command As New OracleCommand()
      command.Connection = oracleConnection
      Dim transaction As OracleTransaction
      Dim sql As New MovimentoContabilSQL()
      ' Start a local transaction
      transaction = oracleConnection.BeginTransaction()
      ' Assign transaction object for a pending local transaction
      command.Transaction = transaction

      Try
        command.CommandText = sql.InsertMovimentoContabil()
        command.Parameters.Add("CODCNTCTB", movimentoContabil.CodContaContabil)
        command.Parameters.Add("CODEVTCTB", movimentoContabil.CodEventoContabil)
        command.Parameters.Add("NOMSISINF", movimentoContabil.NomSistemaInformacao)
        command.Parameters.Add("CODFTOCTB", movimentoContabil.CodFatoContabil)
        command.Parameters.Add("CODUNDNGC", movimentoContabil.CodUnidadeNegocio)
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

    Public Function SelectMovimentoContabil() As IEnumerable(Of MovimentoContabilModel)
      Dim sql As New MovimentoContabilSQL()


      Dim command As New OracleCommand()
      command.Connection = oracleConnection
      command.CommandText = sql.SelectMovimentoContabil()
      command.CommandType = System.Data.CommandType.Text
      Dim reader As OracleDataReader = command.ExecuteReader()
      Dim list As New List(Of MovimentoContabilModel)()

      Try

        While reader.Read()
          list.Add(New MovimentoContabilModel() With {
         .CodContaContabil = reader.GetInt32(0),
         .CodEventoContabil = reader.GetInt32(1),
          .NomSistemaInformacao = reader.GetString(2),
          .CodFatoContabil = reader.GetInt32(3),
          .CodUnidadeNegocio = reader.GetInt32(4),
          .CodIdentidadeContabil = reader.GetInt32(5),
          .DesEventoContabil = reader.GetString(6),
          .DesFatoContabil = reader.GetString(7)
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

    Public Sub DeleteMovimentoContabil(id As Integer)
      Dim command As New OracleCommand()
      Dim transaction As OracleTransaction = oracleConnection.BeginTransaction()
      ' Assign transaction object for a pending local transaction
      command.Connection = oracleConnection
      command.Transaction = transaction
      Try
        Dim sql As New MovimentoContabilSQL()
        command.CommandText = sql.DeleteMovimentoContabil()
        command.Parameters.Add("codigo", id)
        command.ExecuteNonQuery()

        transaction.Commit()
      Catch ex As Exception
        transaction.Rollback()

        Throw ex
      End Try
    End Sub

    Public Function SelectMovimentoContabilPorId(id As Integer) As MovimentoContabilModel
      Dim sql As New MovimentoContabilSQL()


      Dim command As New OracleCommand()
      command.Connection = oracleConnection
      command.CommandText = sql.SelectMovimentoContabilPorId()
      command.CommandType = System.Data.CommandType.Text
      command.Parameters.Add("codigo", id)
      Dim reader As OracleDataReader = command.ExecuteReader()
      Dim MovimentoContabilModel As MovimentoContabilModel = Nothing

      Try

        If reader.Read() Then
          MovimentoContabilModel = New MovimentoContabilModel() With {
                  .CodContaContabil = reader.GetInt32(0),
         .CodEventoContabil = reader.GetInt32(1),
          .NomSistemaInformacao = reader.GetString(2),
          .CodFatoContabil = reader.GetInt32(3),
          .CodUnidadeNegocio = reader.GetInt32(4),
          .CodIdentidadeContabil = reader.GetInt32(5),
          .DesEventoContabil = reader.GetString(6),
          .DesFatoContabil = reader.GetString(7)
          }
        End If
        Return MovimentoContabilModel
      Catch ex As Exception
        Throw ex
      Finally

        If oracleConnection IsNot Nothing Then
          oracleConnection.Close()
        End If
      End Try
    End Function
    Public Function SelectMovimentoContabilPorUnidadeConta(ByVal codunidade As Integer, ByVal codConta As Integer, ByVal CodEventoContabil As Integer, ByVal CodFatoContabil As Integer, ByVal DesEventoContabil As String, ByVal DesFatoContabil As String, ByVal NomSistemaInformacao As String) As List(Of MovimentoContabilModel)
      Dim sql As New MovimentoContabilSQL()


      Dim command As New OracleCommand()
      command.Connection = oracleConnection
      command.CommandText = sql.SelectMovimentoContabilPorUnidadeConta()
      command.CommandType = System.Data.CommandType.Text
      If codunidade = 0 Then
        command.Parameters.Add("CODUNDNGC", DBNull.Value)
      Else
        command.Parameters.Add("CODUNDNGC", codunidade)
      End If
      If codConta = 0 Then
        command.Parameters.Add("CODCNTCTB", DBNull.Value)
      Else
        command.Parameters.Add("CODCNTCTB", codConta)
      End If
      If CodEventoContabil = 0 Then
        command.Parameters.Add("CODEVTCTB", DBNull.Value)
      Else
        command.Parameters.Add("CODEVTCTB", CodEventoContabil)
      End If
      If CodFatoContabil = 0 Then
        command.Parameters.Add("CODFTOCTB", DBNull.Value)
      Else
        command.Parameters.Add("CODFTOCTB", CodFatoContabil)
      End If
      If String.IsNullOrEmpty(DesEventoContabil) Then
        command.Parameters.Add("DESEVTCTB", DBNull.Value)
      Else
        command.Parameters.Add("DESEVTCTB", "%" + DesEventoContabil + "%")
      End If
      If String.IsNullOrEmpty(DesFatoContabil) Then
        command.Parameters.Add("DESFTOCTB", DBNull.Value)
      Else
        command.Parameters.Add("DESFTOCTB", "%" + DesFatoContabil + "%")
      End If
      If String.IsNullOrEmpty(NomSistemaInformacao) Then
        command.Parameters.Add("NOMSISINF", DBNull.Value)
      Else
        command.Parameters.Add("NOMSISINF", "%" + NomSistemaInformacao + "%")
      End If
      Dim reader As OracleDataReader = command.ExecuteReader()
      Dim list As New List(Of MovimentoContabilModel)()

      Try

        While reader.Read()
          list.Add(New MovimentoContabilModel() With {
         .CodContaContabil = reader.GetInt32(0),
         .CodEventoContabil = reader.GetInt32(1),
          .NomSistemaInformacao = reader.GetString(2),
          .CodFatoContabil = reader.GetInt32(3),
          .CodUnidadeNegocio = reader.GetInt32(4),
          .CodIdentidadeContabil = reader.GetInt32(5),
          .DesEventoContabil = reader.GetString(6),
          .DesFatoContabil = reader.GetString(7)
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
