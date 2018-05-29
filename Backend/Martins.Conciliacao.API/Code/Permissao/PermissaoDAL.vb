Imports Oracle.ManagedDataAccess.Client
Imports Martins.Conciliacao.Model
Imports Martins.Conciliacao.Util

Namespace Code.Permissao
	Public Class PermissaoDAL
		Public Function SelectPermissao(lstNomGrpAcs As List(Of String)) As List(Of PermissaoModel)
			Dim permissoes = New List(Of PermissaoModel)()
			Dim lstUpdNomGrpAcs = New List(Of String)()

            For Each item As Object In lstNomGrpAcs
                lstUpdNomGrpAcs.Add(String.Format("'{0}'", item))
            Next

            Dim strNomGrpAcs = String.Join(",", lstUpdNomGrpAcs)

			If lstNomGrpAcs.Count = 0 OrElse String.IsNullOrEmpty(strNomGrpAcs) Then
				Return permissoes
			End If

      Dim databaseCommand As OracleCommand = Nothing
      Dim command As OracleCommand = Nothing

			Try
				Dim sqlCmd As New PermissaoSQL()

				command = New OracleCommand(sqlCmd.SelectPermissao(strNomGrpAcs), New OracleConnection(Utils.ORACLE_CONNECCAO))

				command.Connection.Open()

				Dim dt As New DataTable()
				dt.Load(command.ExecuteReader())

				For Each row As DataRow In dt.Rows
          permissoes.Add(New PermissaoModel() With {
                        .CODACSFUN = row.Field(Of Long)("CODACSFUN"),
                        .NOMACSFUN = row.Field(Of [String])("NOMACSFUN")
                    })
        Next
			Catch ex As Exception
				Throw ex
			Finally
				If command IsNot Nothing AndAlso command.Connection.State = ConnectionState.Open Then
					command.Connection.Close()
				End If

				If databaseCommand IsNot Nothing AndAlso databaseCommand.Connection IsNot Nothing AndAlso databaseCommand.Connection.State = ConnectionState.Open Then
					databaseCommand.Connection.Close()
				End If
			End Try

			Return permissoes
		End Function
	End Class
End Namespace
