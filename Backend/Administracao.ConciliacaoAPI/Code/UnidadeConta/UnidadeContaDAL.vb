Imports Administracao.ConciliacaoAPI.Model
Imports Administracao.ConciliacaoAPI.Util
Imports Oracle.ManagedDataAccess.Client

Namespace Code.UnidadeConta
    Public Class UnidadeContaDAL

        Public oracleConnection As OracleConnection
        Public Sub New()
            Try
                oracleConnection = New OracleConnection(Utils.ORACLE_CONNECCAO)
                oracleConnection.Open()
            Catch ex As Exception
                Throw New Exception("Erro ao conectar ao banco de dados.")
            End Try
        End Sub
        Public Function SelectUnidadeConta() As List(Of UnidadeContaModel)
            Dim sql As New UnidadeContaSQL()


            Dim command As New OracleCommand()
            command.Connection = oracleConnection
            command.CommandText = sql.SelectUnidadeConta()
            command.CommandType = System.Data.CommandType.Text
            Dim reader As OracleDataReader = command.ExecuteReader()
            Dim list As New List(Of UnidadeContaModel)()

            Try

                While reader.Read()
                    Dim unidadeConta As New UnidadeContaModel()

                    unidadeConta.CodEmpresa = reader.GetInt32(0)
                    unidadeConta.FLAG = reader.GetString(1)
                    unidadeConta.FlagLabel = If(reader.GetString(1) = "1", "Ativo", "Inativo")
                    Dim unidadeModel As New UnidadeModel()
                    unidadeModel.CodEmpresa = reader.GetInt32(2)
                    unidadeModel.CodUnidade = reader.GetInt32(3)
                    unidadeModel.DesUnidade = reader.GetString(4)
                    unidadeModel.CodFilialCentroAdministrativo = reader.GetInt32(5)
                    unidadeModel.CodFilialTituloPagamento = reader.GetInt32(6)
                    unidadeModel.DataCadastro = If(IsDBNull(reader.GetValue(7)), Nothing, reader.GetDateTime(7))
                    unidadeModel.DataDesativacao = If(IsDBNull(reader.GetValue(8)), Nothing, reader.GetDateTime(8))
                    unidadeModel.CodLivroContabil = reader.GetInt32(9)
                    unidadeModel.CodNumericosMaiores = reader.GetInt32(10)
                    unidadeConta.UnidadeModel = unidadeModel
                    Dim conta As New ContaModel()
                    conta.CodContaContabil = reader.GetInt32(11)
                    conta.NumGrauContaContabil = reader.GetInt32(12)
                    conta.DescricaoDaContaContabil = reader.GetString(13)
                    conta.DataCadastro = If(IsDBNull(reader.GetValue(14)), Nothing, reader.GetDateTime(14))
                    conta.DataDesativacao = If(IsDBNull(reader.GetValue(15)), Nothing, reader.GetDateTime(15))
                    conta.Flag = reader.GetString(16)
                    conta.Flaglabel = If(reader.GetString(16) = "1", "ativo", "Inativo")

                    unidadeConta.ContaModel = conta
                    list.Add(unidadeConta)
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
        Public Function SelectUnidadeConta(CodUnidade As Integer, codConta As Integer) As List(Of UnidadeContaModel)
            Dim sql As New UnidadeContaSQL()


            Dim command As New OracleCommand()
            command.Connection = oracleConnection
            command.CommandText = sql.SelectUnidadeContaPorId()
            If codConta = 0 Then
                command.Parameters.Add("CODCNTCTB", DBNull.Value)
            Else
                command.Parameters.Add("CODCNTCTB", codConta)
            End If
            If CodUnidade = 0 Then
                command.Parameters.Add("CODUNDNGC", DBNull.Value)
            Else
                command.Parameters.Add("CODUNDNGC", CodUnidade)
            End If
            command.CommandType = System.Data.CommandType.Text
            Dim reader As OracleDataReader = command.ExecuteReader()
            Dim list As New List(Of UnidadeContaModel)()

            Try

                While reader.Read()
                    Dim unidadeConta As New UnidadeContaModel()

                    unidadeConta.CodEmpresa = reader.GetInt32(0)
                    unidadeConta.FLAG = reader.GetString(1)
                    unidadeConta.FlagLabel = If(reader.GetString(1) = "1", "Ativo", "Inativo")
                    Dim unidadeModel As New UnidadeModel()
                    unidadeModel.CodEmpresa = reader.GetInt32(2)
                    unidadeModel.CodUnidade = reader.GetInt32(3)
                    unidadeModel.DesUnidade = reader.GetString(4)
                    unidadeModel.CodFilialCentroAdministrativo = reader.GetInt32(5)
                    unidadeModel.CodFilialTituloPagamento = reader.GetInt32(6)
                    unidadeModel.DataCadastro = If(IsDBNull(reader.GetValue(7)), Nothing, reader.GetDateTime(7))
                    unidadeModel.DataDesativacao = If(IsDBNull(reader.GetValue(8)), Nothing, reader.GetDateTime(8))
                    unidadeModel.CodLivroContabil = reader.GetInt32(9)
                    unidadeModel.CodNumericosMaiores = reader.GetInt32(10)
                    unidadeConta.UnidadeModel = unidadeModel
                    Dim conta As New ContaModel()
                    conta.CodContaContabil = reader.GetInt32(11)
                    conta.NumGrauContaContabil = reader.GetInt32(12)
                    conta.DescricaoDaContaContabil = reader.GetString(13)
                    conta.DataCadastro = If(IsDBNull(reader.GetValue(14)), Nothing, reader.GetDateTime(14))
                    conta.DataDesativacao = If(IsDBNull(reader.GetValue(15)), Nothing, reader.GetDateTime(15))
                    conta.Flag = reader.GetString(16)
                    conta.Flaglabel = If(reader.GetString(16) = "1", "ativo", "Inativo")

                    unidadeConta.ContaModel = conta
                    list.Add(unidadeConta)
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
        Public Sub AtivarInativarUnidadeConta(unidadeConta As UnidadeContaModel)
            Dim command As New OracleCommand()
            command.Connection = oracleConnection
            Dim transaction As OracleTransaction
            Dim sql As New UnidadeContaSQL()
            ' Start a local transaction
            transaction = oracleConnection.BeginTransaction()
            ' Assign transaction object for a pending local transaction
            command.Transaction = transaction

            Try
                command.CommandText = sql.AtivarInativarUnidadeConta()
                command.Parameters.Clear()
                command.Parameters.Add("codConta", unidadeConta.ContaModel.CodContaContabil)
                command.Parameters.Add("codUnidade", unidadeConta.UnidadeModel.CodUnidade)
                command.Parameters.Add("codEmpresa", unidadeConta.CodEmpresa)
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
                command.Parameters.Add("codConta", unidadeConta.ContaModel.CodContaContabil)
                command.Parameters.Add("codUnidade", unidadeConta.UnidadeModel.CodUnidade)
                command.Parameters.Add("codEmpresa", unidadeConta.CodEmpresa)
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
