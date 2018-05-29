Imports JsonWebToken.Code.Log
Imports Newtonsoft.Json
Imports Oracle.ManagedDataAccess.Client
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Reflection
Imports System.Runtime.InteropServices

Namespace Util
  Module LogUtil

    Private _captions As List(Of String) = New List(Of String)()
    Private Property Captions As List(Of String)
      Get
        Return _captions
      End Get
      Set(ByVal value As List(Of String))
        _captions = value
      End Set
    End Property

    Public Property Captions1 As List(Of String)
      Get
        Return _captions
      End Get
      Set(value As List(Of String))
        _captions = value
      End Set
    End Property

    Private Function GeraConsulta(ByVal param As String, ByVal table As String, ByVal clause As String) As String
      Return String.Format(" select {0} from {1} {2}", param, table, clause)
    End Function

    Private Function ListaAlteracoes(ByVal command As OracleCommand, ByVal [select] As String) As List(Of Object)
      Dim lst = New List(Of Object)()

      Try
        command.CommandText = [select]
        Dim dt As DataTable = New DataTable()
        dt.Load(command.ExecuteReader())
        Dim captions = New List(Of String)()

        For Each column As DataColumn In dt.Columns
          captions.Add(column.ColumnName)
        Next

        captions = captions

        For Each row As DataRow In dt.Rows
          Dim dict = New Dictionary(Of String, Object)()

          For Each caption As String In captions
            dict.Add(caption, row(caption))
          Next

          lst.Add(dict)
        Next

      Catch ex As Exception
        Throw ex
      End Try

      Return lst
    End Function

    Private Function FormataValores(ByVal lstObj As List(Of Object)) As String
      Dim tmp As List(Of String) = New List(Of String)()

      For Each dic As Dictionary(Of String, Object) In lstObj
        Dim tmp2 = New List(Of String)()

        For Each item In dic
          tmp2.Add(String.Format("{0} = {1}", item.Key, item.Value))
        Next

        tmp.Add(String.Join(" , ", tmp2))
      Next

      Return String.Join(" | ", tmp)
    End Function

    Public Sub Execute(ByVal param As Dictionary(Of String, Object), ByVal table As String, ByVal command As OracleCommand, Optional ByVal where As String = "")
      Dim comando = CType(command.Clone(), OracleCommand)

      If Not String.IsNullOrEmpty(where) Then

        For i As Integer = (command.Parameters.Count - 1) To 0
          If Not where.ToLower().Contains(command.Parameters(i).ParameterName.ToLower()) Then comando.Parameters.RemoveAt(i)
        Next
      End If

      Try
        Dim op As String = String.Empty
        Dim dt As DataTable = New DataTable()
        If comando.CommandText.IndexOf("insert") <> -1 Then op = "insert"
        If comando.CommandText.IndexOf("update") <> -1 Then op = "update"
        If comando.CommandText.IndexOf("delete") <> -1 Then op = "delete"
        Dim clause = comando.CommandText.Substring(comando.CommandText.ToLower().IndexOf("where"))
        If Not String.IsNullOrEmpty(where) Then clause = where
        Dim lst As List(Of String) = Nothing
        Dim values = "*"
        Dim [select] = GeraConsulta(values, table, clause)
        Dim lstObjAntes = ListaAlteracoes(comando, [select])
        lst = New List(Of String)()

        For Each caption In Captions

          For Each item In param
            lst.Add(If(caption.ToLower().Equals(item.Key.ToLower()), String.Format("{0} as {1}", item.Value, item.Key), caption))
          Next
        Next

        values = If(lst.Count > 0, String.Join(",", lst), "*")
        [select] = GeraConsulta(values, table, clause)
        Dim lstObjDepois = ListaAlteracoes(comando, [select])
        Dim vlStatement = New Object()

        If op.Equals("insert") Then
          vlStatement = New With {
                        .items = New Object() {New With {
                            .name = "operacao",
                            .values = op
                        }, New With {
                            .name = "depois",
                            .values = FormataValores(lstObjDepois)
                        }, New With {
                            .name = "comando",
                            .values = comando
                        }}
                    }
        ElseIf op.Equals("update") Then
          vlStatement = New With {
                        .items = New Object() {New With {
                            .name = "operacao",
                            .values = op
                        }, New With {
                            .name = "antes",
                            .values = FormataValores(lstObjAntes)
                        }, New With {
                            .name = "depois",
                            .values = FormataValores(lstObjDepois)
                        }, New With {
                            .name = "comando",
                            .values = comando
                        }}
                    }
        ElseIf op.Equals("delete") Then
          vlStatement = New With {
                        .items = New Object() {New With {
                            .name = "operacao",
                            .values = op
                        }, New With {
                            .name = "antes",
                            .values = FormataValores(lstObjAntes)
                        }, New With {
                            .name = "comando",
                            .values = comando
                        }}
                    }
        End If

        Dim vlStatementJson As String = JsonConvert.SerializeObject(vlStatement)

        Dim logBLL As LogBLL = New LogBLL()
        logBLL.InsertLogOperacao(Utils.UserCodeLDAP, vlStatementJson)

      Catch ex As Exception
        Throw ex
      End Try
    End Sub
  End Module
End Namespace
