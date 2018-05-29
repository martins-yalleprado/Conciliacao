Namespace Code.Periodo
  Public Class PeriodoSQL
    Public Function selectPeriodoPorId() As String
      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append("Select CODPODAGN,NOMPODAGN,IDTSITPODAGN from CADPODAGN where CODPODAGN =:codigo")
      Return stringBuilder.ToString()
    End Function
    Public Function selectPeriodo() As String
      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append("Select CODPODAGN,NOMPODAGN,IDTSITPODAGN from CADPODAGN where NVL(NOMPODAGN,:nome) like NVL(:nome,NOMPODAGN) and  NVL(IDTSITPODAGN,:situacao) =NVL(:situacao,IDTSITPODAGN)")
      Return stringBuilder.ToString()
    End Function

    Public Function deletePeriodo() As String
      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append("delete CADPODAGN where CODPODAGN =:codigo")
      Return stringBuilder.ToString()
    End Function
    Public Function updatePeriodo() As String
      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append("update CADPODAGN set NOMPODAGN=:nome where CODPODAGN =:codigo")
      Return stringBuilder.ToString()
    End Function
    Public Function ativarPeriodo() As String
      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append("update CADPODAGN set IDTSITPODAGN='1' where CODPODAGN =:codigo")
      Return stringBuilder.ToString()
    End Function
    Public Function desativarPeriodo() As String
      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append("update CADPODAGN set IDTSITPODAGN='0' where CODPODAGN =:codigo")
      Return stringBuilder.ToString()
    End Function
    Public Function inserirPeriodo() As String
      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append(" insert into  CADPODAGN  (CODPODAGN,NOMPODAGN,IDTSITPODAGN) values (NVL ((Select MAx(CODPODAGN)+1 from CADPODAGN),1),:nome,:situacao) ")
      Return stringBuilder.ToString()
    End Function
  End Class
End Namespace

