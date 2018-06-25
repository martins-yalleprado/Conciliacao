Imports Oracle.ManagedDataAccess.Client
Imports Administracao.ConciliacaoAPI.Model
Imports Administracao.ConciliacaoAPI.Util

Namespace Code.Relatorio
    Public Class RelatorioDAL

        Public oracleConnection As OracleConnection

        Public Sub New()
            Try
                oracleConnection = New OracleConnection(Utils.ORACLE_CONNECCAO)
                oracleConnection.Open()
            Catch ex As Exception
                Throw New Exception("Erro ao conectar ao banco de dados.")
            End Try
        End Sub

        Public Function selectRelatorioPorId(id As Integer) As RelatorioModel


            Dim sql As New RelatorioSQL()


            Dim command As New OracleCommand()

            command.Connection = oracleConnection
            command.CommandText = sql.selectRelatorioPorId()
            command.Parameters.Add("codigo", id)
            command.CommandType = System.Data.CommandType.Text
            Dim reader As OracleDataReader = command.ExecuteReader()
            Dim Relatorio As RelatorioModel = Nothing

            Try
                If reader.Read() Then
                    Relatorio = New RelatorioModel() With {
                             .CodRelatorio = reader.GetInt32(0),
                            .DesRelatório = reader.GetString(1),
                            .NomArquivo = reader.GetString(2),
                            .DataCriacao = reader.GetDateTime(3),
                            .TipoRelatorio = New TipoRelatorioModel() With {.CodtipoRelatorio = reader.GetInt32(4),
                            .NomTipoRelatorio = reader.GetString(5),
                            .DestipoRelatorio = reader.GetString(6)}
                        }
                    BuscaArquivosRelatorios(Relatorio)
                End If

                Return Relatorio
            Catch ex As Exception
                Throw ex
            Finally

                If oracleConnection IsNot Nothing Then
                    oracleConnection.Close()
                End If
            End Try

        End Function

        Private Sub BuscaArquivosRelatorios(ByRef relatorio As RelatorioModel)
            Dim sql As New RelatorioSQL()


            Dim command As New OracleCommand()
            command.Connection = oracleConnection
            command.CommandText = sql.selectArquivoRelatorio()
            command.Parameters.Add("CodRelatorio", relatorio.CodRelatorio)
            command.CommandType = System.Data.CommandType.Text
            Dim reader As OracleDataReader = command.ExecuteReader()


            Try
                While reader.Read()
                    Dim arquivo As New ArquivoModel() With {
                            .CodArquivo = reader.GetInt32(0),
                            .Extensao = reader.GetString(1),
                    .Arquivo = reader.GetOracleClob(2).Value,
                    .CodRelatorio = reader.GetInt32(3)
                    }
                    relatorio.Arquivos.Add(arquivo)
                End While


            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub deleteRelatorio(id As Integer)
            Dim command As New OracleCommand()
            Dim transaction As OracleTransaction = oracleConnection.BeginTransaction()
            ' Assign transaction object for a pending local transaction
            command.Connection = oracleConnection
            command.Transaction = transaction

            Try
                Dim sql As New RelatorioSQL()
                command.CommandText = sql.deleteArquivos()
                command.Parameters.Add("codigo", id)
                command.ExecuteNonQuery()
                command.CommandText = sql.deleteRelatorio()
                command.ExecuteNonQuery()
                transaction.Commit()
            Catch ex As Exception
                transaction.Rollback()

                Throw ex
            End Try
        End Sub

        Public Function selectRelatorio() As List(Of RelatorioModel)

            Dim sql As New RelatorioSQL()


            Dim command As New OracleCommand()
            command.Connection = oracleConnection
            command.CommandText = sql.selectRelatorio()

            command.CommandType = System.Data.CommandType.Text
            Dim reader As OracleDataReader = command.ExecuteReader()
            Dim list As New List(Of RelatorioModel)()

            Try
                While reader.Read()
                    Dim relatorio As New RelatorioModel() With {
                            .CodRelatorio = reader.GetInt32(0),
                            .DesRelatório = reader.GetString(1),
                            .NomArquivo = reader.GetString(2),
                            .DataCriacao = reader.GetDateTime(3),
                            .TipoRelatorio = New TipoRelatorioModel() With {.CodtipoRelatorio = reader.GetInt32(4),
                            .NomTipoRelatorio = reader.GetString(5),
                            .DestipoRelatorio = reader.GetString(6)}
                    }
                    BuscaArquivosRelatorios(relatorio)
                    list.Add(relatorio)
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
        Public Function selectRelatorio(ByVal tipo As Integer, data As DateTime) As List(Of RelatorioModel)

            Dim sql As New RelatorioSQL()


            Dim command As New OracleCommand()
            command.Connection = oracleConnection
            command.CommandText = sql.selectRelatorioPorTipoData()
            command.Parameters.Add("tipo", tipo)
            command.Parameters.Add("data", data)
            command.CommandType = System.Data.CommandType.Text
            Dim reader As OracleDataReader = command.ExecuteReader()
            Dim list As New List(Of RelatorioModel)()

            Try
                While reader.Read()
                    Dim relatorio As New RelatorioModel() With {
                            .CodRelatorio = reader.GetInt32(0),
                            .DesRelatório = reader.GetString(1),
                            .NomArquivo = reader.GetString(2),
                            .DataCriacao = reader.GetDateTime(3),
                            .TipoRelatorio = New TipoRelatorioModel() With {.CodtipoRelatorio = reader.GetInt32(4),
                            .NomTipoRelatorio = reader.GetString(5),
                            .DestipoRelatorio = reader.GetString(6)}
                    }
                    BuscaArquivosRelatorios(relatorio)
                    list.Add(relatorio)
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

        Public Sub inserirRelatorio(Relatorio As RelatorioModel)
            Dim command As New OracleCommand()
            Dim transaction As OracleTransaction = oracleConnection.BeginTransaction()
            ' Assign transaction object for a pending local transaction
            command.Connection = oracleConnection
            command.Transaction = transaction
            Try
                Dim sql As New RelatorioSQL()
                command.CommandText = sql.inserirRelatorio()
                command.Parameters.Add("NOMARQRELCLOCOB", Relatorio.NomArquivo)
                command.Parameters.Add("DESRELCLOCOB", Relatorio.DesRelatório)
                command.Parameters.Add("CODTIPRELCLOCOB", Relatorio.TipoRelatorio.CodtipoRelatorio)
                command.Parameters.Add("CODRELCLOCOB", OracleDbType.Int32, ParameterDirection.Output)
                command.ExecuteNonQuery()
                Relatorio.CodRelatorio = CInt(command.Parameters.Item("CODRELCLOCOB").Value.ToString)
                For Each arquivo In Relatorio.Arquivos
                    arquivo.CodRelatorio = Relatorio.CodRelatorio
                    insertArquivo(arquivo)
                Next
                transaction.Commit()
            Catch ex As Exception
                transaction.Rollback()

                Throw ex
            End Try
        End Sub

        Private Sub insertArquivo(ByRef arquivo As ArquivoModel)
            Dim command As New OracleCommand()
            ' Assign transaction object for a pending local transaction
            command.Connection = oracleConnection
            Try
                Dim sql As New RelatorioSQL()
                command.CommandText = sql.insertArquivo()
                command.Parameters.Add("NOMEXNRELCLOCOB", arquivo.Extensao)
                command.Parameters.Add("CDORELCLOCOB", arquivo.Arquivo)
                command.Parameters.Add("CODRELCLOCOB", arquivo.CodRelatorio)
                command.Parameters.Add("CODCDORELCLOCOB", OracleDbType.Int32, ParameterDirection.Output)
                command.ExecuteNonQuery()
                arquivo.CodArquivo = CInt(command.Parameters.Item("CODCDORELCLOCOB").Value.ToString)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub updateRelatorio(Relatorio As RelatorioModel)
            Dim command As New OracleCommand()
            Dim transaction As OracleTransaction = oracleConnection.BeginTransaction()
            ' Assign transaction object for a pending local transaction
            command.Connection = oracleConnection
            command.Transaction = transaction
            Try
                Dim sql As New RelatorioSQL()
                command.CommandText = sql.updateRelatorio()

                command.ExecuteNonQuery()
                transaction.Commit()
            Catch ex As Exception
                transaction.Rollback()

                Throw ex
            End Try
        End Sub

    End Class
End Namespace
