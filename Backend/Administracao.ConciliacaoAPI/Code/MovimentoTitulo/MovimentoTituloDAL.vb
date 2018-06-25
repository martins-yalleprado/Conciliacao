Imports Oracle.ManagedDataAccess.Client
Imports Administracao.ConciliacaoAPI.Model
Imports Administracao.ConciliacaoAPI.Util

Namespace Code.MovimentoTitulo
    Public Class MovimentoTituloDAL

        Public oracleConnection As OracleConnection
        Public Sub New()
            Try
                oracleConnection = New OracleConnection(Utils.ORACLE_CONNECCAO)
                oracleConnection.Open()
            Catch ex As Exception
                Throw New Exception("Erro ao conectar ao banco de dados.")
            End Try
        End Sub


        Public Function selectDatasTitulosPorCarga(numSeqCarga As Integer) As List(Of Date)

            Dim sql As New MovimentoTituloSQL()


            Dim command As New OracleCommand()
            command.Connection = oracleConnection
            command.CommandText = sql.selectDatasTitulosPorCarga()

            command.Parameters.Add("codigoCarga", numSeqCarga)
            command.CommandType = System.Data.CommandType.Text
            Dim reader As OracleDataReader = command.ExecuteReader()
            Dim listaDatas As New List(Of Date)()

            Try
                While reader.Read()
                    Dim data As New Date()
                    data = reader.GetDateTime(0)
                    listaDatas.Add(data)
                End While

                Return listaDatas
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
