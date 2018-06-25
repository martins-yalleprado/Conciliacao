Imports Oracle.ManagedDataAccess.Client
Imports Administracao.ConciliacaoAPI.Model
Imports Administracao.ConciliacaoAPI.Util

Public Class RelatorioAgingDAL

    Public oracleConnection As OracleConnection

    Public Sub New()
        Try
            oracleConnection = New OracleConnection(Utils.ORACLE_CONNECCAO)
            oracleConnection.Open()
        Catch ex As Exception
            Throw New Exception("Erro ao conectar ao banco de dados.")
        End Try
    End Sub

    Public Function selectRelatorioAgingSintetico(ByVal data As DateTime, periodoId As Integer) As List(Of RelatorioAgingModel)

        Dim sql As New RelatorioAgingSQL()

        Dim command As New OracleCommand()
        command.Connection = oracleConnection
        command.CommandText = sql.selectRelatorioAgingSintetico1()
        command.Parameters.Add("data", Today.ToShortDateString)
        'descomentar quando o período for inserido
        'command.Parameters.Add("periodo", periodoId)
        command.CommandType = System.Data.CommandType.Text
        Dim reader As OracleDataReader = command.ExecuteReader()

        Dim valorVenc As Double
        Dim valorNaoVenc As Double
        valorVenc = 0
        valorNaoVenc = 0

        Try
            While reader.Read()
                'no fonte da aplicação antiga era "valorVenc = NullToZero(reader.GetDouble(0))" não me parecia fazer sentido, alterei 
                valorVenc += If(IsDBNull(reader.GetValue(0)), 0, reader.GetDouble(0))
            End While
            reader.Close()

            Dim command2 As New OracleCommand()
            command2.Connection = oracleConnection
            command2.CommandText = sql.selectRelatorioAgingSintetico2()
            command2.Parameters.Add("data", data.ToShortDateString)
            'descomentar quando o período for inserido
            'command.Parameters.Add("periodo", periodoId)
            command2.CommandType = System.Data.CommandType.Text

            Dim reader2 As OracleDataReader = command2.ExecuteReader()

            Dim list As New List(Of RelatorioAgingModel)()

            Dim DiaAnt = "-"

            While reader2.Read()
                Dim relatorio As New RelatorioAgingModel() With {
                    .De = DiaAnt,
                    .Ate = If(reader.GetValue(0) = 9999, "-", reader.GetInt32(0)),
                    .Quantidade = If(IsDBNull(reader.GetValue(2)), 0, reader.GetInt32(2)),
                    .ValorAberto = If(IsDBNull(reader.GetValue(1)), 0, reader.GetDouble(1))
                }
                If (relatorio.Ate < 0) Then
                    relatorio.AcumuladoVencido = valorVenc
                    relatorio.AcumuladoEsperado = 0
                    valorVenc = valorVenc - relatorio.ValorAberto
                Else
                    valorNaoVenc = valorNaoVenc + relatorio.ValorAberto
                    relatorio.AcumuladoVencido = 0
                    relatorio.AcumuladoEsperado = valorNaoVenc
                End If
                DiaAnt = relatorio.Ate + 1
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


End Class
