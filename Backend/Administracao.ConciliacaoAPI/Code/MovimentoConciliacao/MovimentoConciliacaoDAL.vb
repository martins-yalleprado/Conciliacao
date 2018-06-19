Imports Administracao.ConciliacaoAPI
Imports Administracao.ConciliacaoAPI.Model
Imports Administracao.ConciliacaoAPI.Util
Imports Oracle.ManagedDataAccess.Client
Namespace Code.MovimentoConciliacao
    Public Class MovimentoConciliacaoDAL

        Private oracleConnection As OracleConnection
        Public Sub New()
            Try
                oracleConnection = New OracleConnection(Utils.ORACLE_CONNECCAO)
                oracleConnection.Open()
            Catch ex As Exception
                Throw New Exception("Erro ao conectar ao banco de dados.")
            End Try
        End Sub
        Public Sub UpdateMovimentoConciliacao(movimentoConciliacao As MovimentoConciliacaoModel)
            Dim command As New OracleCommand()
            command.Connection = oracleConnection
            Dim transaction As OracleTransaction
            Dim sql As New MovimentoConciliacaoSQL()
            ' Start a local transaction
            transaction = oracleConnection.BeginTransaction()
            ' Assign transaction object for a pending local transaction
            command.Transaction = transaction

            Try
                command.CommandText = sql.UpdateMovimentoConciliacao()
                command.Parameters.Add("CODEMTTIT", movimentoConciliacao.CodEmitenteTitulo)
                command.Parameters.Add("CODFRMPGT", movimentoConciliacao.CodFormaPagamento)
                command.Parameters.Add("CODSITENVORGFSC", movimentoConciliacao.CodSituacaoTituloOrgaoFiscal)
                command.Parameters.Add("CODORIPED", movimentoConciliacao.CodOrigemPedido)
                command.Parameters.Add("CODPTATIT", movimentoConciliacao.CodProprietarioTitulo)
                command.Parameters.Add("CODRPNRSCCRD", movimentoConciliacao.CodResponsavelRiscoCredito)
                command.Parameters.Add("TIPCHQ", movimentoConciliacao.TipoCheque)
                command.Parameters.Add("CODSITTITVDR", movimentoConciliacao.CodSituacaoTituloVendor)
                command.Parameters.Add("CODSITVNCTIT", movimentoConciliacao.CodSituacaoVencimentoTitulo)
                command.Parameters.Add("CODTIPCOB", movimentoConciliacao.CodTipoCobranca)
                command.Parameters.Add("CODTIPMOVTIT", movimentoConciliacao.CodTipoMovimentacaoTituloReceber)
                command.Parameters.Add("FLGRGTMOV", movimentoConciliacao.MarcacaoRegistroMovimentoConciliacao)
                command.Parameters.Add("CODIDTCTB", movimentoConciliacao.CodIdentidadeContabil)
                command.Parameters.Add("CODIDTMOV", movimentoConciliacao.CodMovimentoConciliacao)
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

        Public Function SelectMovimentoConciliacaoPorMovimentoContabil(codIdentidadeContabil As Integer) As List(Of MovimentoConciliacaoModel)
            Dim sql As New MovimentoConciliacaoSQL()


            Dim command As New OracleCommand()
            command.Connection = oracleConnection
            command.CommandText = sql.SelectMovimentoConciliacaoPorMovimentoContabil()
            command.CommandType = System.Data.CommandType.Text
            command.Parameters.Add("CODIDTCTB", codIdentidadeContabil)
            Dim reader As OracleDataReader = command.ExecuteReader()
            Dim list As New List(Of MovimentoConciliacaoModel)()

            Try

                While reader.Read()
                    list.Add(New MovimentoConciliacaoModel() With {
                   .CodEmitenteTitulo = reader.GetString(0),
                   .CodFormaPagamento = reader.GetInt32(1),
                    .CodSituacaoTituloOrgaoFiscal = reader.GetString(2),
                    .CodOrigemPedido = reader.GetString(3),
                    .CodProprietarioTitulo = reader.GetString(4),
                    .CodResponsavelRiscoCredito = reader.GetString(5),
                    .TipoCheque = reader.GetString(6),
                    .CodSituacaoTituloVendor = reader.GetString(7),
                    .CodSituacaoVencimentoTitulo = reader.GetString(8),
                    .CodTipoCobranca = reader.GetString(9),
                    .CodTipoMovimentacaoTituloReceber = reader.GetInt32(10),
                    .MarcacaoRegistroMovimentoConciliacao = reader.GetString(11),
                    .CodMovimentoConciliacao = reader.GetInt32(12),
                    .CodIdentidadeContabil = reader.GetInt32(13)
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

        Public Sub InsertMovimentoConciliacao(movimentoConciliacao As MovimentoConciliacaoModel)
            Dim command As New OracleCommand()
            command.Connection = oracleConnection
            Dim transaction As OracleTransaction
            Dim sql As New MovimentoConciliacaoSQL()
            ' Start a local transaction
            transaction = oracleConnection.BeginTransaction()
            ' Assign transaction object for a pending local transaction
            command.Transaction = transaction

            Try
                command.CommandText = sql.InsertMovimentoConciliacao()
                command.Parameters.Add("CODEMTTIT", movimentoConciliacao.CodEmitenteTitulo)
                command.Parameters.Add("CODFRMPGT", movimentoConciliacao.CodFormaPagamento)
                command.Parameters.Add("CODSITENVORGFSC", movimentoConciliacao.CodSituacaoTituloOrgaoFiscal)
                command.Parameters.Add("CODORIPED", movimentoConciliacao.CodOrigemPedido)
                command.Parameters.Add("CODPTATIT", movimentoConciliacao.CodProprietarioTitulo)
                command.Parameters.Add("CODRPNRSCCRD", movimentoConciliacao.CodResponsavelRiscoCredito)
                command.Parameters.Add("TIPCHQ", movimentoConciliacao.TipoCheque)
                command.Parameters.Add("CODSITTITVDR", movimentoConciliacao.CodSituacaoTituloVendor)
                command.Parameters.Add("CODSITVNCTIT", movimentoConciliacao.CodSituacaoVencimentoTitulo)
                command.Parameters.Add("CODTIPCOB", movimentoConciliacao.CodTipoCobranca)
                command.Parameters.Add("CODTIPMOVTIT", movimentoConciliacao.CodTipoMovimentacaoTituloReceber)
                command.Parameters.Add("FLGRGTMOV", movimentoConciliacao.MarcacaoRegistroMovimentoConciliacao)
                command.Parameters.Add("CODIDTCTB", movimentoConciliacao.CodIdentidadeContabil)
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

        Public Function SelectMovimentoConciliacao() As IEnumerable(Of MovimentoConciliacaoModel)
            Dim sql As New MovimentoConciliacaoSQL()


            Dim command As New OracleCommand()
            command.Connection = oracleConnection
            command.CommandText = sql.SelectMovimentoConciliacao()
            command.CommandType = System.Data.CommandType.Text
            command.Parameters.Add("FLGRGTMOV", "0")
            Dim reader As OracleDataReader = command.ExecuteReader()
            Dim list As New List(Of MovimentoConciliacaoModel)()

            Try

                While reader.Read()
                    list.Add(New MovimentoConciliacaoModel() With {
                   .CodEmitenteTitulo = reader.GetString(0),
                   .CodFormaPagamento = reader.GetInt32(1),
                    .CodSituacaoTituloOrgaoFiscal = reader.GetString(2),
                    .CodOrigemPedido = reader.GetString(3),
                    .CodProprietarioTitulo = reader.GetString(4),
                    .CodResponsavelRiscoCredito = reader.GetString(5),
                    .TipoCheque = reader.GetString(6),
                    .CodSituacaoTituloVendor = reader.GetString(7),
                    .CodSituacaoVencimentoTitulo = reader.GetString(8),
                    .CodTipoCobranca = reader.GetString(9),
                    .CodTipoMovimentacaoTituloReceber = reader.GetInt32(10),
                    .MarcacaoRegistroMovimentoConciliacao = reader.GetString(11),
                    .CodMovimentoConciliacao = reader.GetInt32(12),
                    .CodIdentidadeContabil = reader.GetInt32(13)
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

        Public Sub DeleteMovimentoConciliacao(id As Integer)
            Dim command As New OracleCommand()
            Dim transaction As OracleTransaction = oracleConnection.BeginTransaction()
            ' Assign transaction object for a pending local transaction
            command.Connection = oracleConnection
            command.Transaction = transaction
            Try
                Dim sql As New MovimentoConciliacaoSQL()
                command.CommandText = sql.DeleteMovimentoConciliacao()
                command.Parameters.Add("codigo", id)
                command.ExecuteNonQuery()

                transaction.Commit()
            Catch ex As Exception
                transaction.Rollback()

                Throw ex
            End Try
        End Sub

        Public Function SelectMovimentoConciliacaoPorId(id As Integer) As MovimentoConciliacaoModel
            Dim sql As New MovimentoConciliacaoSQL()


            Dim command As New OracleCommand()
            command.Connection = oracleConnection
            command.CommandText = sql.SelectMovimentoConciliacaoPorId()
            command.CommandType = System.Data.CommandType.Text
            command.Parameters.Add("codigo", id)
            Dim reader As OracleDataReader = command.ExecuteReader()
            Dim movimentoConciliacaoModel As MovimentoConciliacaoModel = Nothing

            Try

                If reader.Read() Then
                    movimentoConciliacaoModel = New MovimentoConciliacaoModel() With {
                   .CodEmitenteTitulo = reader.GetString(0),
                   .CodFormaPagamento = reader.GetInt32(1),
                    .CodSituacaoTituloOrgaoFiscal = reader.GetString(2),
                    .CodOrigemPedido = reader.GetString(3),
                    .CodProprietarioTitulo = reader.GetString(4),
                    .CodResponsavelRiscoCredito = reader.GetString(5),
                    .TipoCheque = reader.GetString(6),
                    .CodSituacaoTituloVendor = reader.GetString(7),
                    .CodSituacaoVencimentoTitulo = reader.GetString(8),
                    .CodTipoCobranca = reader.GetString(9),
                    .CodTipoMovimentacaoTituloReceber = reader.GetInt32(10),
                    .MarcacaoRegistroMovimentoConciliacao = reader.GetString(11),
                    .CodMovimentoConciliacao = reader.GetInt32(12),
                    .CodIdentidadeContabil = reader.GetInt32(13)
                    }
                End If
                Return movimentoConciliacaoModel
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
