Namespace Code.UnidadeConta
  Public Class UnidadeContaSQL
    Public Function SelectUnidadeConta() As String
      Dim stringBuilder As New StringBuilder()
            stringBuilder.Append(" select CODCNTCTB,CODUNDNGC,CODEMP,FLGSTAATV from MRT.RLCEMPCNTCLO ")
            Return stringBuilder.ToString()
    End Function
    Public Function AtivarUnidadeConta() As String
      Dim stringBuilder As New StringBuilder()
            stringBuilder.Append("  Update MRT.RLCEMPCNTCLO  set FLGSTAATV='1' where CODCNTCTB=:codUnidadeConta ")
            Return stringBuilder.ToString()
    End Function
    Public Function InativarUnidadeConta() As String
      Dim stringBuilder As New StringBuilder()
            stringBuilder.Append("  Update MRT.RLCEMPCNTCLO  set FLGSTAATV='0' where CODCNTCTB=:CodUnidadeConta ")
            Return stringBuilder.ToString()
    End Function
    Public Function InsertUnidadeConta() As String
      Dim stringBuilder As New StringBuilder()
            stringBuilder.Append("  insert into MRT.RLCEMPCNTCLO  (CODCNTCTB,CODUNDNGC,CODEMP,FLGSTAATV) values (:codConta,:codUnidade,1,'1') ")
            Return stringBuilder.ToString()
    End Function
  End Class
End Namespace
