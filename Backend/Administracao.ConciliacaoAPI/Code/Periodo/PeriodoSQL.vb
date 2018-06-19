Namespace Code.Periodo
  Public Class PeriodoSQL
    Public Function selectPeriodoPorId() As String
      Dim stringBuilder As New StringBuilder()
            stringBuilder.Append("Select CODPODAGI,NOMPODAGI,IDTSITPODAGI from MRT.CADPODAGI where CODPODAGI =:codigo")
            Return stringBuilder.ToString()
    End Function
    Public Function selectPeriodo() As String
      Dim stringBuilder As New StringBuilder()
            stringBuilder.Append("Select CODPODAGI,NOMPODAGI,IDTSITPODAGI from MRT.CADPODAGI where NVL(LOWER(NOMPODAGI),LOWER(:nome)) like NVL(LOWER(:nome),LOWER(NOMPODAGI)) and  NVL(IDTSITPODAGI,:situacao) =NVL(:situacao,IDTSITPODAGI)")
            Return stringBuilder.ToString()
    End Function

    Public Function deletePeriodo() As String
      Dim stringBuilder As New StringBuilder()
            stringBuilder.Append("delete MRT.CADPODAGI where CODPODAGI =:codigo")
            Return stringBuilder.ToString()
    End Function
    Public Function updatePeriodo() As String
      Dim stringBuilder As New StringBuilder()
            stringBuilder.Append("update MRT.CADPODAGI set NOMPODAGI=:nome where CODPODAGI =:codigo")
            Return stringBuilder.ToString()
    End Function
    Public Function ativarPeriodo() As String
      Dim stringBuilder As New StringBuilder()
            stringBuilder.Append("update MRT.CADPODAGI set IDTSITPODAGI=1 where CODPODAGI =:codigo")
            Return stringBuilder.ToString()
    End Function
    Public Function desativarPeriodo() As String
      Dim stringBuilder As New StringBuilder()
            stringBuilder.Append("update MRT.CADPODAGI set IDTSITPODAGI=0 where CODPODAGI =:codigo")
            Return stringBuilder.ToString()
    End Function
    Public Function inserirPeriodo() As String
      Dim stringBuilder As New StringBuilder()
            stringBuilder.Append(" insert into  MRT.CADPODAGI  (CODPODAGI,NOMPODAGI,IDTSITPODAGI) values (NVL ((Select MAx(CODPODAGI)+1 from MRT.CADPODAGI),1),:nome,:situacao) ")
            Return stringBuilder.ToString()
    End Function
  End Class
End Namespace

