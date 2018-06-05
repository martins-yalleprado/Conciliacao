Imports System.Data.Common
Imports Martins.Conciliacao.Util
Imports Oracle.ManagedDataAccess.Client

Public Class LogDAL
  Public Function InsertLog(ByVal CODFNC As String, ByVal VLSTATEMENT As String) As Boolean
    Dim databaseCommand As DbCommand = Nothing
    Dim command As OracleCommand = Nothing
    Dim retorno As Boolean = False

    Try
      Dim sqlCmd As LogSQL = New LogSQL()
      command = New OracleCommand(sqlCmd.InsertLog(), New OracleConnection(Utils.ORACLE_CONNECCAO))
      command.Parameters.Add(New OracleParameter("CODFNC", CODFNC))
      command.Parameters.Add(New OracleParameter("VLSTATEMENT", VLSTATEMENT))
      command.Connection.Open()
      retorno = If(command.ExecuteNonQuery() > 0, True, False)
    Catch ex As Exception
      Throw ex
    Finally
      If command IsNot Nothing AndAlso command.Connection.State = ConnectionState.Open Then command.Connection.Close()
      If databaseCommand IsNot Nothing AndAlso databaseCommand.Connection IsNot Nothing AndAlso databaseCommand.Connection.State = ConnectionState.Open Then databaseCommand.Connection.Close()
    End Try

    Return retorno
  End Function
End Class
