Imports Oracle.ManagedDataAccess.Client
Imports Administracao.ConciliacaoAPI.Model
Imports Administracao.ConciliacaoAPI.Util

Namespace Code.Conta
    Public Class ContaDAL

        Public oracleConnection As OracleConnection
        Public Sub New()
            Try
                oracleConnection = New OracleConnection(Utils.ORACLE_CONNECCAO)
                oracleConnection.Open()
            Catch ex As Exception
                Throw New Exception("Erro ao conectar ao banco de dados.")
            End Try
        End Sub
        Public Function SelectContaPorId(id As Integer) As ContaModel
            Dim sql As New ContaSQL()


            Dim command As New OracleCommand()
            command.Connection = oracleConnection
            command.CommandText = sql.SelectConta()
            command.CommandType = System.Data.CommandType.Text
            Dim reader As OracleDataReader = command.ExecuteReader()
            Dim Conta As ContaModel = Nothing

            Try

                If reader.Read() Then

                    Conta = New ContaModel() With {
                                   .CodContaContabil = reader.GetInt32(0),
                                   .NumGrauContaContabil = reader.GetInt32(1),
                                   .DescricaoDaContaContabil = reader.GetString(2),
                                   .DataCadastro = reader.GetDateTime(3),
                                   .DataDesativacao = reader.GetDateTime(4),
                                   .Flag = reader.GetString(5),
                                   .Flaglabel = If(reader.GetString(5) = "1", "ativo", "Inativo")
                              }
                End If


                Return Conta
            Catch ex As Exception
                Throw ex
            Finally

                If oracleConnection IsNot Nothing Then
                    oracleConnection.Close()
                End If
            End Try
        End Function
        Public Function SelectConta() As List(Of ContaModel)
            Dim sql As New ContaSQL()


            Dim command As New OracleCommand()
            command.Connection = oracleConnection
            command.CommandText = sql.SelectConta()
            command.CommandType = System.Data.CommandType.Text
            Dim reader As OracleDataReader = command.ExecuteReader()
            Dim Conta As New List(Of ContaModel)()
            Dim ContaModel As ContaModel
            Try

                While reader.Read()
                    ContaModel = New ContaModel
                    ContaModel.CodContaContabil = reader.GetInt32(0)
                    ContaModel.NumGrauContaContabil = reader.GetInt32(1)
                    ContaModel.DescricaoDaContaContabil = reader.GetString(2)
                    ContaModel.DataCadastro = reader.GetDateTime(3)
                    ContaModel.DataDesativacao = If(IsDBNull(reader(4)), Nothing, reader.GetDateTime(4))
                    If Not IsDBNull(reader(5)) Then
                        ContaModel.Flag = reader.GetString(5)
                        ContaModel.Flaglabel = If(reader.GetString(5) = "1", "ativo", "Inativo")
                    End If
                    Conta.Add(ContaModel)
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
                command.Parameters.Add("codigo", Conta.CodContaContabil)
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
                command.Parameters.Add("codigo", Conta.CodContaContabil)
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
                command.Parameters.Add("CodContaContabil", Conta.CodContaContabil)
                command.Parameters.Add("NumGrauContaContabil", Conta.NumGrauContaContabil)
                command.Parameters.Add("DescricaoDaContaContabil", Conta.DescricaoDaContaContabil)
                command.Parameters.Add("DataCadastro", Conta.DataCadastro)
                command.Parameters.Add("DataDesativacao", Conta.DataDesativacao)
                command.Parameters.Add("Flag", Conta.Flag)
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
