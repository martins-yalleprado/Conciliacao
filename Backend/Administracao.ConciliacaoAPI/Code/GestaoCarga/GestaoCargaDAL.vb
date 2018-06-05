Imports Oracle.ManagedDataAccess.Client
Imports Martins.Conciliacao.Model
Imports Martins.Conciliacao.Util

Namespace Code.GestaoCarga
	Public Class GestaoCargaDAL

		Public oracleConnection As OracleConnection
		Public Sub New()
			oracleConnection = New OracleConnection(Utils.ORACLE_CONNECCAO)
			oracleConnection.Open()
		End Sub


		Public Function selectGestaoCargaPorId(id As Integer) As GestaoCargaModel

			Dim sql As New GestaoCargaSQL()


			Dim command As New OracleCommand()
			command.Connection = oracleConnection
			command.CommandText = sql.selectGestaoCargaPorId()

			command.Parameters.Add("codigo", id)
			command.CommandType = System.Data.CommandType.Text
			Dim reader As OracleDataReader = command.ExecuteReader()
			Dim gestaoCarga As GestaoCargaModel = Nothing

			Try
				If reader.Read() Then
                    gestaoCarga = New GestaoCargaModel() With {
                         .codGestaoCarga = reader.GetInt32(0),
                        .data = reader.GetDateTime(1),
                        .dataMovimentacao = reader.GetDateTime(2),
                        .tipo = reader.GetString(3),
                        .versao = reader.GetInt32(4),
                        .versaoOficial = reader.GetString(5),
                        .valor = reader.GetFloat(6),
                         .versaoOficialLabel = If(reader.GetString(5) = "1", "Sim", "Não")
                    }
                End If


				Return gestaoCarga
			Catch ex As Exception
				Throw ex
			Finally

				If oracleConnection IsNot Nothing Then
					oracleConnection.Close()
				End If
			End Try
		End Function
		Public Sub deleteGestaoCarga(id As Integer)

			Dim command As New OracleCommand()
			Dim transaction As OracleTransaction = oracleConnection.BeginTransaction()
			' Assign transaction object for a pending local transaction
			command.Connection = oracleConnection
			command.Transaction = transaction
			Try
				Dim sql As New GestaoCargaSQL()
				command.CommandText = sql.deleteGestaoCargaCtb()
                command.Parameters.Add("codigo", id)

                LogUtil.Execute(New Dictionary(Of String, Object)(), "MOVCTBCLOSISCOB", command)

                command.ExecuteNonQuery()
				command.CommandText = sql.deleteGestaoCargaTit()
				command.ExecuteNonQuery()
				command.CommandText = sql.deleteGestaoCargaAgn()
				command.ExecuteNonQuery()
				command.CommandText = sql.deleteGestaoCarga()
				command.ExecuteNonQuery()
				transaction.Commit()
			Catch ex As Exception
				transaction.Rollback()

				Throw ex
			End Try
		End Sub

		Public Function selectGestaoCarga(dataRef As DateTime, tipo As [String]) As List(Of GestaoCargaModel)
			Dim sql As New GestaoCargaSQL()


			Dim command As New OracleCommand()
			command.Connection = oracleConnection
			command.CommandText = sql.selectGestaoCarga()

			command.Parameters.Add("dataref", dataRef.ToString("yyyy-MM-dd"))
      command.Parameters.Add("tipo", tipo)
      command.CommandType = System.Data.CommandType.Text
			Dim reader As OracleDataReader = command.ExecuteReader()
			Dim gestaoCarga As New List(Of GestaoCargaModel)()

			Try

				While reader.Read()
          gestaoCarga.Add(New GestaoCargaModel() With {
                        .codGestaoCarga = reader.GetInt32(0),
                        .data = reader.GetDateTime(1),
                        .dataMovimentacao = reader.GetDateTime(2),
                        .tipo = reader.GetString(3),
                        .versao = reader.GetInt32(4),
                        .versaoOficial = reader.GetString(5),
                        .valor = reader.GetFloat(6),
                        .versaoOficialLabel = If(reader.GetString(5) = "1", "Sim", "Não"),
                        .quantidade = reader.GetInt32(7)
                    })
        End While


				Return gestaoCarga
			Catch ex As Exception
				Throw ex
			Finally

				If oracleConnection IsNot Nothing Then
					oracleConnection.Close()
				End If
			End Try
		End Function

		Private Sub updateGestaoCarga(gestaoCargaModel As GestaoCargaModel, command As OracleCommand)

            Dim sql As New GestaoCargaSQL()

            command.CommandText = sql.updateGestaoCargaVersaoOficialAtivar()
            command.Parameters.Clear()
            command.Parameters.Add("codigoUpdate", gestaoCargaModel.codGestaoCarga)

			command.ExecuteNonQuery()
			command.CommandText = sql.updateGestaoCargaVersaoOficialInativar()
      command.Parameters.Add("datarefUpdate", gestaoCargaModel.dataMovimentacao.ToString("yyyy-MM-dd"))
      command.Parameters.Add("tipoUpdate", gestaoCargaModel.tipo)
			command.ExecuteNonQuery()

            Dim dic = New Dictionary(Of String, Object)()
            dic.Add("IDTVRSRGTATV", 0)
      LogUtil.Execute(dic, "RLCRGTMOVCLO", command)

      command.ExecuteNonQuery()

		End Sub

    Public Sub insertGestaoCarga(dataRef As DateTime, tipo As String, codUnidade As Integer)

      If "TIT".Equals(tipo) OrElse "TODOS".Equals(tipo) Then
        inserirLoteTitulo(dataRef, codUnidade)
      End If
      If "CTB".Equals(tipo) OrElse "TODOS".Equals(tipo) Then
        inserirLoteContabil(dataRef, codUnidade)
      End If
            If "AGI".Equals(tipo) OrElse "TODOS".Equals(tipo) Then
                inserirLoteAging(dataRef, codUnidade)
            End If

        End Sub
    Public Function proximoCodigoGestaoCarga(command As OracleCommand) As Integer
			Dim sql As New GestaoCargaSQL()
			command.CommandText = sql.proximoCodigoGestaoCarga()
			command.CommandType = System.Data.CommandType.Text
			Dim reader As OracleDataReader = command.ExecuteReader()
			Dim codGestaoCarga As Integer = 0
			If reader.Read() Then
				codGestaoCarga = reader.GetInt32(0)
			End If
			Return codGestaoCarga
		End Function
    Private Sub inserirLoteAging(dataRef As DateTime, codUnidade As Integer)
      Dim command As New OracleCommand()
      command.Connection = oracleConnection
      Dim transaction As OracleTransaction

      ' Start a local transaction
      transaction = oracleConnection.BeginTransaction()
      ' Assign transaction object for a pending local transaction
      command.Transaction = transaction

      Try

        Dim sql As New GestaoCargaSQL()

                Dim gestaoCargaModel As GestaoCargaModel = gerarGestaoCargaModel(dataRef, "AGI", codUnidade, command)


                command.CommandText = sql.insertLoteAging()
        command.CommandType = System.Data.CommandType.Text
        command.Parameters.Clear()
        command.Parameters.Add("Codigo", gestaoCargaModel.codGestaoCarga)
        command.Parameters.Add("datamov", gestaoCargaModel.dataMovimentacao)
        command.ExecuteNonQuery()
        transaction.Commit()
      Catch ex As Exception
        transaction.Rollback()

        Throw ex
      End Try
    End Sub
    Public Function gerarGestaoCargaModel(dataref As DateTime, tipo As String, codUnidade As Integer, command As OracleCommand) As GestaoCargaModel

      Dim gestaoCargaModel As New GestaoCargaModel()
      gestaoCargaModel.codGestaoCarga = proximoCodigoGestaoCarga(command)
      gestaoCargaModel.tipo = tipo
      gestaoCargaModel.data = DateTime.Now
      gestaoCargaModel.dataMovimentacao = dataref
      gestaoCargaModel.codUnidade = codUnidade
      gestaoCargaModel.versao = selectMaxVersao(dataref, gestaoCargaModel.tipo, command)
      Dim sql As New GestaoCargaSQL()
      command.CommandText = sql.insertGestaoCarga()
      command.Parameters.Clear()
      command.Parameters.Add("codigo", gestaoCargaModel.codGestaoCarga)
      command.Parameters.Add("datamov", gestaoCargaModel.dataMovimentacao)
      command.Parameters.Add("tipo", gestaoCargaModel.tipo)
      command.Parameters.Add("versao", gestaoCargaModel.versao)
      command.ExecuteNonQuery()
      updateGestaoCarga(gestaoCargaModel, command)
      Return gestaoCargaModel
    End Function

    Private Function selectMaxVersao(data As DateTime, tipo As String, command As OracleCommand) As Integer

			Dim sql As New GestaoCargaSQL()
			command.CommandText = sql.selectMaxVersion()
			command.CommandType = System.Data.CommandType.Text
			command.Parameters.Add("dataRefVer", data.ToString("yyyy-MM-dd"))
			command.Parameters.Add("tipoVer", tipo)
			Dim reader As OracleDataReader = command.ExecuteReader()
			Dim versao As Integer = 0
			If reader.Read() Then
				versao = reader.GetInt32(0)
			End If
			Return versao
		End Function

    Private Sub inserirLoteContabil(dataRef As DateTime, codUnidade As Integer)

      Dim transaction As OracleTransaction

      ' Start a local transaction
      transaction = oracleConnection.BeginTransaction()
      ' Assign transaction object for a pending local transaction
      Dim command As New OracleCommand()
      command.Connection = oracleConnection
      command.Transaction = transaction

      Try
        Dim sql As New GestaoCargaSQL()
        Dim gestaoCargaModel As GestaoCargaModel = gerarGestaoCargaModel(dataRef, "CTB", codUnidade, command)

        command.CommandText = sql.insertLoteContabil()
        command.CommandType = System.Data.CommandType.Text
        command.Parameters.Clear()
        command.Parameters.Add("Codigo", gestaoCargaModel.codGestaoCarga)
        command.Parameters.Add("datamov", gestaoCargaModel.dataMovimentacao)
        command.ExecuteNonQuery()
        transaction.Commit()
      Catch ex As Exception
        transaction.Rollback()

        Throw ex
      End Try
    End Sub

    Private Sub inserirLoteTitulo(dataRef As DateTime, codUnidade As Integer)


      Dim transaction As OracleTransaction

      ' Start a local transaction
      transaction = oracleConnection.BeginTransaction()
      ' Assign transaction object for a pending local transaction
      Dim command As New OracleCommand()
      command.Connection = oracleConnection
      command.Transaction = transaction

      Try
        Dim sql As New GestaoCargaSQL()

        Dim gestaoCargaModel As GestaoCargaModel = gerarGestaoCargaModel(dataRef, "TIT", codUnidade, command)

        command.CommandText = sql.insertLoteTitulo()
        command.CommandType = System.Data.CommandType.Text
        command.Parameters.Clear()
        command.Parameters.Add("Codigo", gestaoCargaModel.codGestaoCarga)
        command.Parameters.Add("datamov", gestaoCargaModel.dataMovimentacao)
        command.ExecuteNonQuery()

                LogUtil.Execute(New Dictionary(Of String, Object)(), "MOVTITCLOSISCOB", command, "where NUMSEQCRGTAB = :Codigo")

                transaction.Commit()
			Catch ex As Exception
				transaction.Rollback()

        Throw ex
      End Try
    End Sub
    Public Sub atualizarVersao(gestaoCargaModel As GestaoCargaModel)
			Dim command As New OracleCommand()
			command.Connection = oracleConnection
			Dim transaction As OracleTransaction

			' Start a local transaction
			transaction = oracleConnection.BeginTransaction()
			' Assign transaction object for a pending local transaction
			command.Transaction = transaction

			Try
				updateGestaoCarga(gestaoCargaModel, command)
				transaction.Commit()
			Catch ex As Exception
				transaction.Rollback()

				Throw ex
			End Try
		End Sub
	End Class
End Namespace
