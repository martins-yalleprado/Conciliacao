Namespace Code.MovimentoContabil
  Public Class MovimentoContabilSQL
    Public Function DeleteMovimentoContabil() As String
      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append(" delete MRT.MOVIDTCTBCLO ")
      stringBuilder.Append(" where CODIDTCTB=:codigo")
      Return stringBuilder.ToString()
    End Function

    Public Function UpdateMovimentoContabil() As String
      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append(" update MRT.MOVIDTCTBCLO set ")
      stringBuilder.Append("  CODCNTCTB=:CODCNTCTB  ")
      stringBuilder.Append(" ,CODEVTCTB=:CODEVTCTB  ")
      stringBuilder.Append(" ,NOMSISINF=:NOMSISINF  ")
      stringBuilder.Append(" ,CODFTOCTB=:CODFTOCTB  ")
      stringBuilder.Append(" ,CODUNDNGC=:CODUNDNGC  ")
      stringBuilder.Append(" where CODIDTCTB=:CODIDTCTB ")
      Return stringBuilder.ToString()
    End Function
    Public Function SelectMovimentoContabilPorUnidadeConta() As String
      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append(" SELECT a.CODCNTCTB,a.CODEVTCTB,a.NOMSISINF,a.CODFTOCTB,a.CODUNDNGC,a.CODIDTCTB,b.DESEVTCTB,c.DESFTOCTB   ")
      stringBuilder.Append("  FROM MRT.MOVIDTCTBCLO a                                                                                 ")
      stringBuilder.Append("  INNER JOIN MRT.T0123590 b  On b.NOMSISINF  = a.NOMSISINF And b.CODEVTCTB = a.CODEVTCTB                  ")
      stringBuilder.Append("  INNER JOIN MRT.T0108435 c  On c.CODFTOCTB    = a.CODFTOCTB                                              ")
      stringBuilder.Append("  WHERE   a.CODUNDNGC =NVL(:CODUNDNGC,a.CODUNDNGC)                                                        ")
      stringBuilder.Append("      And a.CODCNTCTB   =NVL(:CODCNTCTB,a.CODCNTCTB)                                                      ")
      stringBuilder.Append("      And a.CODEVTCTB   =NVL(:CODEVTCTB, a.CODEVTCTB)                                                     ")
      stringBuilder.Append("      And a.CODFTOCTB   =NVL(:CODFTOCTB, a.CODFTOCTB)                                                     ")
      stringBuilder.Append("      And UPPER( b.DESEVTCTB ) Like UPPER(NVL(:DESEVTCTB, b.DESEVTCTB))                                   ")
      stringBuilder.Append("      And UPPER(c.DESFTOCTB )Like UPPER( NVL(:DESFTOCTB, c.DESFTOCTB) )                                   ")
      stringBuilder.Append("      And UPPER( a.NOMSISINF) Like UPPER( NVL(:NOMSISINF, a.NOMSISINF) )                                  ")
      stringBuilder.Append("      ORDER BY a.CODUNDNGC, a.CODCNTCTB, a.NOMSISINF, a.CODEVTCTB, a.CODFTOCTB                            ")

      Return stringBuilder.ToString()
    End Function
    Public Function SelectMovimentoContabil() As String
      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append(" Select a.CODCNTCTB,a.CODEVTCTB,a.NOMSISINF,a.CODFTOCTB,a.CODUNDNGC,a.CODIDTCTB, b.DESEVTCTB, c.DESFTOCTB")
      stringBuilder.Append(" from MRT.MOVIDTCTBCLO a ")
      stringBuilder.Append(" inner join MRT.T0123590  b on b.NOMSISINF = a.NOMSISINF And  b.CODEVTCTB = a.CODEVTCTB  ")
      stringBuilder.Append(" inner Join MRT.T0108435  c on 		  c.CODFTOCTB = a.CODFTOCTB ")
      stringBuilder.Append(" Order By a.CODUNDNGC, a.CODCNTCTB, a.NOMSISINF, a.CODEVTCTB, a.CODFTOCTB ")
      Return stringBuilder.ToString()
    End Function

    Public Function InsertMovimentoContabil() As String
      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append(" insert into MRT.MOVIDTCTBCLO(CODCNTCTB,CODEVTCTB,NOMSISINF,CODFTOCTB,CODUNDNGC,CODIDTCTB) ")
      stringBuilder.Append(" values (:CODCNTCTB,:CODEVTCTB,:NOMSISINF,:CODFTOCTB,:CODUNDNGC,NVL((select max(CODIDTCTB)+1 from MRT.MOVIDTCTBCLO),1)) ")
      Return stringBuilder.ToString()
    End Function

    Public Function SelectMovimentoContabilPorId() As String
      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append(" Select a.CODCNTCTB,a.CODEVTCTB,a.NOMSISINF,a.CODFTOCTB,a.CODUNDNGC,a.CODIDTCTB, b.DESEVTCTB, c.DESFTOCTB")
      stringBuilder.Append(" from MRT.MOVIDTCTBCLO a ")
      stringBuilder.Append(" inner join MRT.T0123590  b on b.NOMSISINF = a.NOMSISINF And  b.CODEVTCTB = a.CODEVTCTB  ")
      stringBuilder.Append(" inner Join MRT.T0108435  c on 		  c.CODFTOCTB = a.CODFTOCTB ")
      stringBuilder.Append(" where a.CODIDTCTB=:codigo")
      Return StringBuilder.ToString()
    End Function
  End Class
End Namespace
