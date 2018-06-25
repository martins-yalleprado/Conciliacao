Imports Oracle.ManagedDataAccess.Client
Imports Administracao.ConciliacaoAPI.Model
Imports Administracao.ConciliacaoAPI.Util

Namespace Code.TipoRelatorio
    Public Class TipoRelatorioDAL

        Public oracleConnection As OracleConnection

        Public Sub New()
            Try
                oracleConnection = New OracleConnection(Utils.ORACLE_CONNECCAO)
                oracleConnection.Open()
            Catch ex As Exception
                Throw New Exception("Erro ao conectar ao banco de dados.")
            End Try
        End Sub

        Public Function selectTipoRelatorioPorId(id As Integer) As TipoRelatorioModel


            Dim sql As New TipoRelatorioSQL()


            Dim command As New OracleCommand()

            command.Connection = oracleConnection
            command.CommandText = sql.selectTipoRelatorioPorId()
            command.Parameters.Add("codigo", id)
            command.CommandType = System.Data.CommandType.Text
            Dim reader As OracleDataReader = command.ExecuteReader()
            Dim TipoRelatorio As TipoRelatorioModel = Nothing

            Try
                If reader.Read() Then
                    TipoRelatorio = New TipoRelatorioModel() With {
                             .CodtipoRelatorio = reader.GetInt32(0),
                             .NomTipoRelatorio = reader.GetString(1),
                            .DestipoRelatorio = reader.GetString(2)}

                End If

                Return TipoRelatorio
            Catch ex As Exception
                Throw ex
            Finally

                If oracleConnection IsNot Nothing Then
                    oracleConnection.Close()
                End If
            End Try

        End Function



        Public Sub deleteTipoRelatorio(id As Integer)
            Dim command As New OracleCommand()
            Dim transaction As OracleTransaction = oracleConnection.BeginTransaction()
            ' Assign transaction object for a pending local transaction
            command.Connection = oracleConnection
            command.Transaction = transaction

            Try
                Dim sql As New TipoRelatorioSQL()
                command.CommandText = sql.deleteTipoRelatorio()
                command.Parameters.Add("codigo", id)
                command.ExecuteNonQuery()
                transaction.Commit()
            Catch ex As Exception
                transaction.Rollback()

                Throw ex
            End Try
        End Sub

        Public Function selectTipoRelatorio() As List(Of TipoRelatorioModel)

            Dim sql As New TipoRelatorioSQL()


            Dim command As New OracleCommand()
            command.Connection = oracleConnection
            command.CommandText = sql.selectTipoRelatorio()

            command.CommandType = System.Data.CommandType.Text
            Dim reader As OracleDataReader = command.ExecuteReader()
            Dim list As New List(Of TipoRelatorioModel)()

            Try
                While reader.Read()
                    Dim TipoRelatorio = New TipoRelatorioModel() With {
                             .CodtipoRelatorio = reader.GetInt32(0),
                             .NomTipoRelatorio = reader.GetString(1),
                            .DestipoRelatorio = reader.GetString(2)}
                    list.Add(TipoRelatorio)
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


        Public Sub inserirTipoRelatorio(ByRef TipoRelatorio As TipoRelatorioModel)
            Dim command As New OracleCommand()
            Dim transaction As OracleTransaction = oracleConnection.BeginTransaction()
            ' Assign transaction object for a pending local transaction
            command.Connection = oracleConnection
            command.Transaction = transaction
            Try
                Dim sql As New TipoRelatorioSQL()
                command.CommandText = sql.inserirTipoRelatorio()
                command.Parameters.Add("DESTIPRELCLOCOB", TipoRelatorio.DestipoRelatorio)
                command.Parameters.Add("NOMTIPRELCLOCOB", TipoRelatorio.NomTipoRelatorio)
                command.Parameters.Add("CODTIPRELCLOCOB", OracleDbType.Int32, ParameterDirection.Output)
                command.ExecuteNonQuery()
                TipoRelatorio.CodtipoRelatorio = CInt(command.Parameters.Item("CODTIPRELCLOCOB").Value.ToString)
                transaction.Commit()
            Catch ex As Exception
                transaction.Rollback()

                Throw ex
            End Try
        End Sub

        Public Sub updateTipoRelatorio(TipoRelatorio As TipoRelatorioModel)
            Dim command As New OracleCommand()
            Dim transaction As OracleTransaction = oracleConnection.BeginTransaction()
            ' Assign transaction object for a pending local transaction
            command.Connection = oracleConnection
            command.Transaction = transaction
            Try
                Dim sql As New TipoRelatorioSQL()
                command.CommandText = sql.updateTipoRelatorio()

                command.ExecuteNonQuery()
                transaction.Commit()
            Catch ex As Exception
                transaction.Rollback()

                Throw ex
            End Try
        End Sub

    End Class
End Namespace
