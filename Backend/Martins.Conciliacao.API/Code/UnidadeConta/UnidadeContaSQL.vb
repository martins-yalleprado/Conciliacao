Namespace Code.UnidadeConta
  Public Class UnidadeContaSQL
    Public Function SelectUnidadeConta() As String
      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append(" select CODCADCNTUND,CODCNTCTB,CODUNDNGC,SITCNTUND,CODFNC from CADCNTUND ")
      Return stringBuilder.ToString()
    End Function
    Public Function AtivarUnidadeConta() As String
      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append("  Update CADCNTUND  set SITCNTUND='1' where CODCADCNTUND=:codUnidadeConta ")
      Return stringBuilder.ToString()
    End Function
    Public Function InativarUnidadeConta() As String
      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append("  Update CADCNTUND  set SITCNTUND='0' where CODCADCNTUND=:CodUnidadeConta ")
      Return stringBuilder.ToString()
    End Function
    Public Function InsertUnidadeConta() As String
      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append("  insert into CADCNTUND  (CODCADCNTUND,CODCNTCTB,CODUNDNGC,SITCNTUND,CODFNC) values (:codUnidadeConta,:codConta,:codUnidade,'1',:codFuncionario) ")
      Return stringBuilder.ToString()
    End Function
  End Class
End Namespace
