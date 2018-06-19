Imports Oracle.ManagedDataAccess.Client
Imports Administracao.ConciliacaoAPI.Model
Imports Administracao.ConciliacaoAPI.Util

Namespace Code.Periodo
	Public Class PeriodoDAL

		Public oracleConnection As OracleConnection

		Public Sub New()
      Try
        oracleConnection = New OracleConnection(Utils.ORACLE_CONNECCAO)
        oracleConnection.Open()
      Catch ex As Exception
        Throw New Exception("Erro ao conectar ao banco de dados.")
      End Try
    End Sub
		Public Function selectPeriodoPorId(id As Integer) As PeriodoModel
			If True Then

				Dim sql As New PeriodoSQL()


				Dim command As New OracleCommand()
				command.Connection = oracleConnection
				command.CommandText = sql.selectPeriodoPorId()

				command.Parameters.Add("codigo", id)
				command.CommandType = System.Data.CommandType.Text
				Dim reader As OracleDataReader = command.ExecuteReader()
				Dim Periodo As PeriodoModel = Nothing

				Try
					If reader.Read() Then
                        Periodo = New PeriodoModel() With {
                            .codPeriodo = reader.GetInt32(0),
                            .nome = reader.GetString(1),
                            .situacao = reader.GetInt32(2),
                            .situacaoLabel = If(reader.GetInt32(2) = "1", "Ativo", "Inativo")
                        }
                    End If

					Return Periodo
				Catch ex As Exception
					Throw ex
				Finally

					If oracleConnection IsNot Nothing Then
						oracleConnection.Close()
					End If
				End Try
			End If
		End Function
		Public Sub deletePeriodo(id As Integer)
			Dim command As New OracleCommand()
			Dim transaction As OracleTransaction = oracleConnection.BeginTransaction()
			' Assign transaction object for a pending local transaction
			command.Connection = oracleConnection
			command.Transaction = transaction

			Try
				Dim sql As New PeriodoSQL()
				command.CommandText = sql.deletePeriodo()
				command.Parameters.Add("codigo", id)
				command.ExecuteNonQuery()
				transaction.Commit()
			Catch ex As Exception
				transaction.Rollback()

				Throw ex
			End Try
		End Sub

		Public Function selectPeriodo(nome As String, situacao As String) As List(Of PeriodoModel)

			Dim sql As New PeriodoSQL()


			Dim command As New OracleCommand()
			command.Connection = oracleConnection
			command.CommandText = sql.selectPeriodo()

			command.Parameters.Add("nome", nome)
			command.Parameters.Add("nome", nome)
      command.Parameters.Add("situacao", situacao)
      command.Parameters.Add("situacao", situacao)
      command.CommandType = System.Data.CommandType.Text
			Dim reader As OracleDataReader = command.ExecuteReader()
            Dim Periodo As New List(Of PeriodoModel)()

            Try
                While reader.Read()
                    Periodo.Add(New PeriodoModel() With {
                        .codPeriodo = reader.GetInt32(0),
                        .nome = reader.GetString(1),
                        .situacao = reader.GetInt32(2),
                        .situacaoLabel = If(reader.GetInt32(2) = 1, "Ativo", "Inativo")
                    })
                End While

				Return Periodo
			Catch ex As Exception
				Throw ex
			Finally

				If oracleConnection IsNot Nothing Then
					oracleConnection.Close()
				End If
			End Try
		End Function
		Public Sub inserirPeriodo(Periodo As PeriodoModel)
			Dim command As New OracleCommand()
			Dim transaction As OracleTransaction = oracleConnection.BeginTransaction()
			' Assign transaction object for a pending local transaction
			command.Connection = oracleConnection
			command.Transaction = transaction
			Try
				Dim sql As New PeriodoSQL()
				command.CommandText = sql.inserirPeriodo()
				command.Parameters.Add("nome", Periodo.nome)
                command.Parameters.Add("situacao", 1)
                command.ExecuteNonQuery()
				transaction.Commit()
			Catch ex As Exception
				transaction.Rollback()

				Throw ex
			End Try
		End Sub
		Public Sub ativarPeriodo(codigo As Integer)
			Dim command As New OracleCommand()
			Dim transaction As OracleTransaction = oracleConnection.BeginTransaction()
			' Assign transaction object for a pending local transaction
			command.Connection = oracleConnection
			command.Transaction = transaction
			Try
				Dim sql As New PeriodoSQL()
				command.CommandText = sql.ativarPeriodo()
				command.Parameters.Add("codigo", codigo)
				command.ExecuteNonQuery()
				transaction.Commit()
			Catch ex As Exception
				transaction.Rollback()

				Throw ex
			End Try
		End Sub
		Public Sub desativarPeriodo(codigo As Integer)
			Dim command As New OracleCommand()
			Dim transaction As OracleTransaction = oracleConnection.BeginTransaction()
			' Assign transaction object for a pending local transaction
			command.Connection = oracleConnection
			command.Transaction = transaction
			Try
				Dim sql As New PeriodoSQL()
				command.CommandText = sql.desativarPeriodo()
				command.Parameters.Add("codigo", codigo)
				command.ExecuteNonQuery()
				transaction.Commit()
			Catch ex As Exception
				transaction.Rollback()

				Throw ex
			End Try
		End Sub
		Public Sub updatePeriodo(Periodo As PeriodoModel)
			Dim command As New OracleCommand()
			Dim transaction As OracleTransaction = oracleConnection.BeginTransaction()
			' Assign transaction object for a pending local transaction
			command.Connection = oracleConnection
			command.Transaction = transaction
			Try
				Dim sql As New PeriodoSQL()
				command.CommandText = sql.updatePeriodo()
				command.Parameters.Add("nome", Periodo.nome.Trim())
				command.Parameters.Add("codigo", Periodo.codPeriodo)
				command.ExecuteNonQuery()
				transaction.Commit()
			Catch ex As Exception
				transaction.Rollback()

				Throw ex
			End Try
		End Sub
	End Class
End Namespace
