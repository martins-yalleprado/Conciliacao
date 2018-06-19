

Namespace Code.Saldo
  Public Class SaldoSQL
    Public Function UpdateSaldo() As String
      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append(" update MRT.TBSLDCNT                                                    ")
      stringBuilder.Append(" set  VLRSLDCTB=:VLRSLDCTB, VLRSLDCOB=:VLRSLDCOB,                       ")
      stringBuilder.Append("      VLRSLDCTBINF=:VLRSLDCTBINF , VLRSLDCOBINF=:VLRSLDCOBINF           ")
      stringBuilder.Append(" where CODUNDNGC=:CODUNDNGC and CODCNTCTB=:CODCNTCTB and DATMOV=:DATMOV ")
      Return stringBuilder.ToString()
    End Function

    Public Function InsertSaldo() As String
      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append(" Insert into MRT.TBSLDCNT( CODUNDNGC, CODCNTCTB , DATMOV, VLRSLDCTB, VLRSLDCOB, VLRSLDCTBINF , VLRSLDCOBINF) ")
      stringBuilder.Append(" values (:CODUNDNGC, :CODCNTCTB , :DATMOV, :VLRSLDCTB, :VLRSLDCOB, :VLRSLDCTBINF , :VLRSLDCOBINF) ")
      Return stringBuilder.ToString()
    End Function

    Public Function SelectSaldo() As String
      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append(" Select CODUNDNGC, CODCNTCTB , DATMOV, VLRSLDCTB, VLRSLDCOB, VLRSLDCTBINF , VLRSLDCOBINF  ")
      stringBuilder.Append("  from MRT.TBSLDCNT                                                                       ")
      Return stringBuilder.ToString()
    End Function

    Public Function DeleteSaldo() As String
      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append(" delete MRT.TBSLDCNT                                                    ")
      stringBuilder.Append(" where CODUNDNGC=:CODUNDNGC and CODCNTCTB=:CODCNTCTB and DATMOV=:DATMOV ")
      Return stringBuilder.ToString()
    End Function

    Public Function SelectSaldoPorId() As String
      Dim stringBuilder As New StringBuilder()
            stringBuilder.Append(" Select  CODUNDNGC, CODCNTCTB , DATMOV, VLRSLDCTB, VLRSLDCOB, VLRSLDCTBINF , VLRSLDCOBINF             ")
            stringBuilder.Append(" from MRT.TBSLDCNT                                                                                    ")
            stringBuilder.Append(" where CODUNDNGC=:CODUNDNGC and CODCNTCTB=:CODCNTCTB and TO_char(DATMOV, 'YYYY-MM-DD')=:DATMOV        ")
            Return stringBuilder.ToString()
    End Function


  End Class
End Namespace
