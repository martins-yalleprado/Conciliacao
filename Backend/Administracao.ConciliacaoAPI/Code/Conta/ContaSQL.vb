Namespace Code.Conta
  Public Class ContaSQL
    Public Function SelectConta() As String
      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append(" Select   CODCNTCTB,NUMGRACNTCTB,DESCNTCTB,DATCAD,DATDST,FLGATVCLOCOB ")
			stringBuilder.Append(" from MRT.T0123566")
			Return stringBuilder.ToString()
    End Function
    Public Function SelectContaPorId() As String
      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append(" Select   CODCNTCTB,NUMGRACNTCTB,DESCNTCTB,DATCAD,DATDST,FLGATVCLOCOB ")
      stringBuilder.Append(" from MRT.T0123566 ")
      stringBuilder.Append(" where CODCNTCTB=:codigo ")
      Return stringBuilder.ToString()
    End Function
    Public Function AtivarConta() As String
      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append(" update MRT.T0123566 ")
      stringBuilder.Append(" set FLGATVCLOCOB='1' ")
      stringBuilder.Append(" where CODCNTCTB=:codigo ")
      Return stringBuilder.ToString()
    End Function
    Public Function InativarConta() As String
      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append(" update MRT.T0123566 ")
      stringBuilder.Append(" set FLGATVCLOCOB='0' ")
      stringBuilder.Append(" where CODCNTCTB=:codigo ")
      Return stringBuilder.ToString()
    End Function
    Public Function InsertConta() As String
      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append(" insert Into MRT.T0123566 (CODCNTCTB,NUMGRACNTCTB,DESCNTCTB,DATCAD,DATDST,FLGATVCLOCOB)                            ")
      stringBuilder.Append(" values (:CodContaContabil,:NumGrauContaContabil,:DescricaoDaContaContabil,:DataCadastro,:DataDesativacao,:Flag  )    ")
      Return stringBuilder.ToString()
    End Function
  End Class
End Namespace
