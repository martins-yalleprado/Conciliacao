

Namespace Code.MovimentoAcerto
  Public Class MovimentoAcertoSQL
    Public Function UpdateMovimentoAcerto() As String
      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append("  update    MRT.MOVACECLO  ")
      stringBuilder.Append("  set  ")
      stringBuilder.Append("        VLRMOVCOB =:VLRMOVCOB, ")
      stringBuilder.Append("       VLRMOVCTB = :VLRMOVCTB, ")
      stringBuilder.Append("       DESACE = :DESACE ")
      stringBuilder.Append(" where CODIDTCTB =:CODIDTCTB And Datmov =:Datmov And Numseqlmt =:Numseqlmt ")

      Return stringBuilder.ToString()
    End Function

    Public Function InsertMovimentoAcerto() As String
      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append(" insert into  MRT.MOVACECLO(  VLRMOVCOB,CODIDTCTB,DATMOV,NUMSEQLMT,VLRMOVCTB,DESACE) ")
      stringBuilder.Append(" values (  :VLRMOVCOB,:CODIDTCTB,:DATMOV,:NUMSEQLMT,:VLRMOVCTB,:DESACE) ")
      Return stringBuilder.ToString()
    End Function

    Public Function SelectMovimentoAcerto() As String
      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append(" Select  a.DATMOV, a.NUMSEQLMT,a.VLRMOVCTB, a.VLRMOVCOB,a.DESACE, a.CODIDTCTB, b.CODUNDNGC,b.CODCNTCTB, b.NOMSISINF, b.CODEVTCTB, b.CODFTOCTB,d.DESEVTCTB,c.DESFTOCTB ")
      stringBuilder.Append(" FROM  MRT.MOVACECLO  a                                                                                                                                               ")
      stringBuilder.Append(" inner Join MRT.MOVIDTCTBCLO  b On b.CODIDTCTB = a.CODIDTCTB                                                                                                          ")
      stringBuilder.Append(" INNER JOIN MRT.T0123590 d  On b.NOMSISINF  = d.NOMSISINF And b.CODEVTCTB = d.CODEVTCTB                                                                               ")
      stringBuilder.Append(" INNER JOIN MRT.T0108435 c  On c.CODFTOCTB    = b.CODFTOCTB                                                                                                           ")
      stringBuilder.Append(" ORDER BY a.DATMOV, b.CODUNDNGC, b.CODCNTCTB, b.NOMSISINF,b.CODEVTCTB, b.CODFTOCTB, a.NUMSEQLMT                                                                       ")
    End Function
    Public Function SelectMovimentoAcertoPorData() As String
      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append(" Select  a.DATMOV, a.NUMSEQLMT,a.VLRMOVCTB, a.VLRMOVCOB,a.DESACE, a.CODIDTCTB, b.CODUNDNGC,b.CODCNTCTB, b.NOMSISINF, b.CODEVTCTB, b.CODFTOCTB,d.DESEVTCTB,c.DESFTOCTB ")
      stringBuilder.Append(" FROM  MRT.MOVACECLO  a                                                                                                                                               ")
      stringBuilder.Append(" inner Join MRT.MOVIDTCTBCLO  b On b.CODIDTCTB = a.CODIDTCTB                                                                                                          ")
      stringBuilder.Append(" INNER JOIN MRT.T0123590 d  On b.NOMSISINF  = d.NOMSISINF And b.CODEVTCTB = d.CODEVTCTB                                                                               ")
      stringBuilder.Append(" INNER JOIN MRT.T0108435 c  On c.CODFTOCTB    = b.CODFTOCTB                                                                                                           ")
      stringBuilder.Append(" WHERE TO_char(a.Datmov, 'YYYY-MM-DD') =  :DATMOV                                                                                                                     ")
      stringBuilder.Append(" ORDER BY a.DATMOV, b.CODUNDNGC, b.CODCNTCTB, b.NOMSISINF,b.CODEVTCTB, b.CODFTOCTB, a.NUMSEQLMT                                                                       ")
      Return stringBuilder.ToString()
    End Function

    Public Function DeleteMovimentoAcerto() As String
      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append("   Delete MRT.MOVACECLO where CODIDTCTB=:CODIDTCTB and Datmov =:Datmov and Numseqlmt=:Numseqlmt ")
      Return stringBuilder.ToString()
    End Function

    Public Function SelectMovimentoAcertoPorId() As String
      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append("   Select * from MRT.MOVACECLO where CODIDTCTB=:CODIDTCTB and Datmov=:Datmov and Numseqlmt=:Numseqlmt ")
      Return stringBuilder.ToString()
    End Function
  End Class
End Namespace

