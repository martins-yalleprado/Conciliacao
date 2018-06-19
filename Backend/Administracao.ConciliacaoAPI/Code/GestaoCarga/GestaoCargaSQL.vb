Namespace Code.GestaoCarga
  Public Class GestaoCargaSQL
    Public Function selectGestaoCargaPorId() As String
      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append(" Select GC.NUMSEQRGTCLO ,GC.DATREFRGTCLO ,GC.DATHRAGRCRGTCLO,GC.TIPRGTCLO ,GC.NUMVRSRGTCLO ,GC.IDTVRSRGTATV ,GC.CODUNDNGC ,GC.CODCNTCTB ,NVL( ")
      stringBuilder.Append(" case UPPER(TIPRGTCLO) WHEN 'TIT' then(Select Sum(NVL(VLRMOV, 0)) vltTTl ")
      stringBuilder.Append(" from MRT.MOVTITCLOSISCOB tit where tit.NUMSEQCRGTAB = gc.NUMSEQRGTCLO) ")
      stringBuilder.Append(" WHEN 'CTB' then(Select Sum(NVL(VLRCRDLMTCTB, 0) - NVL(VLRDBTLMTCTB, 0)) vltTTl ")
      stringBuilder.Append(" from MRT.MOVCTBCLOSISCOB ctb where ctb.NUMSEQCRGTAB = gc.NUMSEQRGTCLO) ")
      stringBuilder.Append(" WHEN 'AGI' then(Select Sum(NVL(VLRSLDTIT, 0)) vltTTl ")
      stringBuilder.Append(" from MRT.MOVAGICLOSISCOB agi where agi.NUMSEQCRGTAB = gc.NUMSEQRGTCLO) end,0.0) vltTTl ,")
      stringBuilder.Append(" NVL(case UPPER(TIPRGTCLO) WHEN 'TIT' then(Select count(1) qtd ")
      stringBuilder.Append(" from MRT.MOVTITCLOSISCOB tit where tit.NUMSEQCRGTAB = gc.NUMSEQRGTCLO) ")
      stringBuilder.Append(" WHEN 'CTB' then(Select count(1) qtd ")
      stringBuilder.Append(" from MRT.MOVCTBCLOSISCOB ctb where ctb.NUMSEQCRGTAB = gc.NUMSEQRGTCLO) ")
      stringBuilder.Append(" WHEN 'AGI' then(Select count(1) qtd ")
      stringBuilder.Append(" from MRT.MOVAGICLOSISCOB agi where agi.NUMSEQCRGTAB = gc.NUMSEQRGTCLO) end,0) qtd ")
      stringBuilder.Append(" from MRT.RLCRGTMOVCLO GC ")
      stringBuilder.Append(" where GC.NUMSEQRGTCLO=:codigo ")
      Return stringBuilder.ToString()
    End Function
    Public Function selectGestaoCarga() As String
      Dim stringBuilder As New StringBuilder()

      stringBuilder.Append(" Select GC.NUMSEQRGTCLO ,GC.DATREFRGTCLO ,GC.DATHRAGRCRGTCLO,GC.TIPRGTCLO ,GC.NUMVRSRGTCLO ,GC.IDTVRSRGTATV ,GC.CODUNDNGC ,GC.CODCNTCTB ,NVL( ")
      stringBuilder.Append(" case UPPER(TIPRGTCLO) WHEN 'TIT' then(Select Sum(NVL(VLRMOV, 0)) vltTTl ")
      stringBuilder.Append(" from MRT.MOVTITCLOSISCOB tit where tit.NUMSEQCRGTAB = gc.NUMSEQRGTCLO) ")
      stringBuilder.Append(" WHEN 'CTB' then(Select Sum(NVL(VLRCRDLMTCTB, 0) - NVL(VLRDBTLMTCTB, 0)) vltTTl ")
      stringBuilder.Append(" from MRT.MOVCTBCLOSISCOB ctb where ctb.NUMSEQCRGTAB = gc.NUMSEQRGTCLO) ")
      stringBuilder.Append(" WHEN 'AGI' then(Select Sum(NVL(VLRSLDTIT, 0)) vltTTl ")
      stringBuilder.Append(" from MRT.MOVAGICLOSISCOB agi where agi.NUMSEQCRGTAB = gc.NUMSEQRGTCLO) end,0.0) vltTTl ,")
      stringBuilder.Append(" NVL(case UPPER(TIPRGTCLO) WHEN 'TIT' then(Select count(1) qtd ")
      stringBuilder.Append(" from MRT.MOVTITCLOSISCOB tit where tit.NUMSEQCRGTAB = gc.NUMSEQRGTCLO) ")
      stringBuilder.Append(" WHEN 'CTB' then(Select count(1) qtd ")
      stringBuilder.Append(" from MRT.MOVCTBCLOSISCOB ctb where ctb.NUMSEQCRGTAB = gc.NUMSEQRGTCLO) ")
      stringBuilder.Append(" WHEN 'AGI' then(Select count(1) qtd ")
      stringBuilder.Append(" from MRT.MOVAGICLOSISCOB agi where agi.NUMSEQCRGTAB = gc.NUMSEQRGTCLO) end ,0) qtd ")
      stringBuilder.Append(" from MRT.RLCRGTMOVCLO GC where TO_char(DATREFRGTCLO, 'YYYY-MM-DD') =:dataref and NVL(:tipo, TIPRGTCLO) = NVL(TIPRGTCLO,:tipo) ")

      Return stringBuilder.ToString()
    End Function
    Public Function deleteGestaoCarga() As String

      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append("delete MRT.RLCRGTMOVCLO where NUMSEQRGTCLO=:codigo ")
      Return stringBuilder.ToString()
    End Function
    Public Function deleteGestaoCargaCtb() As String
      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append("delete MRT.MOVCTBCLOSISCOB where NUMSEQCRGTAB =:codigo ")
      Return stringBuilder.ToString()
    End Function
    Public Function deleteGestaoCargaTit() As String

      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append("delete MRT.MOVTITCLOSISCOB where NUMSEQCRGTAB =:codigo ")
      Return stringBuilder.ToString()
    End Function
    Public Function deleteGestaoCargaAgn() As String

      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append("delete MRT.MOVAGICLOSISCOB where NUMSEQCRGTAB =:codigo ")
      Return stringBuilder.ToString()
    End Function

    Public Function updateGestaoCargaVersaoOficialAtivar() As String
      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append("update MRT.RLCRGTMOVCLO set IDTVRSRGTATV='1' where NUMSEQRGTCLO=:codigoUpdate ")
      Return stringBuilder.ToString()
    End Function
    Public Function updateGestaoCargaVersaoOficialInativar() As String
      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append("update MRT.RLCRGTMOVCLO set IDTVRSRGTATV='0' where NUMSEQRGTCLO<>:codigoUpdate and TO_char(DATREFRGTCLO, 'YYYY-MM-DD') =:datarefUpdate and TIPRGTCLO=:tipoUpdate ")
      Return stringBuilder.ToString()
    End Function
    Public Function insertLoteAging() As String
      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append("insert into MRT.MOVAGICLOSISCOB(NUMSEQCRGTAB,DATREFCTB,CODUNDNGC,CODCNTCTB,QDEDIAVNC,VLRSLDTIT,QDETIT,DATHRAGRCMOV ) ")
      stringBuilder.Append("select :Codigo NUMSEQCRGTAB,AGI.DATREFCTB,AGI.CODUNDNGC,AGI.CODCNTCTB,AGI.QDEDIAVNC,AGI.VLRSLDTIT,AGI.QDETIT,AGI.DATHRAGRCMOV  from MRT.MOVAGICLOCOB AGI where TO_char( AGI.DATHRAGRCMOV, 'YYYY-MM-DD') =:datamov ")
      Return stringBuilder.ToString()
    End Function
    Public Function insertLoteTitulo() As String
      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append(" insert into MRT.MOVTITCLOSISCOB( NUMSEQCRGTAB,CODUNDNGC, DATMOV, CODTIPMOVTIT, CODFRMPGT, CODPTATIT, CODRPNRSCCRD, CODORIPED, CODEMTTIT, TIPCHQ, CODSITTITVDR, CODSITVNCTIT, CODSITENVORGFSC, VLRMOV, CODTIPCOB, DATHRAGRCMOV, FLGSTAATV) ")
      stringBuilder.Append("select :Codigo NUMSEQCRGTAB,   TIT.CODUNDNGC, TIT.DATMOV, TIT.CODTIPMOVTIT, TIT.CODFRMPGT, TIT.CODPTATIT, TIT.CODRPNRSCCRD, TIT.CODORIPED, TIT.CODEMTTIT, TIT.TIPCHQ, TIT.CODSITTITVDR, TIT.CODSITVNCTIT, TIT.CODSITENVORGFSC, TIT.VLRMOV, TIT.CODTIPCOB, TIT.DATHRAGRCMOV, TIT.FLGSTAATV from MRT.MOVTITCLOCOB TIT where TO_char( TIT.DATHRAGRCMOV, 'YYYY-MM-DD') =:datamov ")

      Return stringBuilder.ToString()
    End Function
    Public Function insertLoteContabil() As String
      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append("insert into MRT.MOVCTBCLOSISCOB(NUMSEQCRGTAB,CODUNDNGC, DATEFTLMTCTB, CODCNTCTB, NOMSISINF, CODEVTCTB, CODFTOCTB, VLRDBTLMTCTB, VLRCRDLMTCTB, FLGSTAATV, DATHRAGRCMOV) ")
      stringBuilder.Append("select :Codigo NUMSEQCRGTAB,CTB.CODUNDNGC, CTB.DATEFTLMTCTB, CTB.CODCNTCTB, CTB.NOMSISINF, CTB.CODEVTCTB, CTB.CODFTOCTB, CTB.VLRDBTLMTCTB, CTB.VLRCRDLMTCTB, CTB.FLGSTAATV, CTB.DATHRAGRCMOV from MRT.MOVCTBCLOCOB CTB where TO_char( CTB.DATHRAGRCMOV, 'YYYY-MM-DD') =:datamov ")
      Return stringBuilder.ToString()
    End Function


    Public Function insertGestaoCarga() As String
      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append("INSERT INTO MRT.RLCRGTMOVCLO ( NUMSEQRGTCLO, DATREFRGTCLO, DATHRAGRCRGTCLO, TIPRGTCLO, NUMVRSRGTCLO, IDTVRSRGTATV, CODUNDNGC, CODCNTCTB, VLRTOTRGTCLO, DATHRACRISEQRGTCLO, QDERGTCLO) ")
      stringBuilder.Append(" VALUES  ( :NUMSEQRGTCLO, :DATREFRGTCLO, SYSDATE, :TIPRGTCLO, :NUMVRSRGTCLO, '1', :CODUNDNGC, :CODCNTCTB, 0,SYSDATE,0) ")
      Return stringBuilder.ToString()

    End Function
    Public Function selectMaxVersion() As String
      Dim stringBuilder As New StringBuilder()

      stringBuilder.Append(" Select NVL( MAx (GC. NUMVRSRGTCLO )+1,1) NUMVRSRGTCLO ")
      stringBuilder.Append(" from MRT.RLCRGTMOVCLO GC where TO_char(DATREFRGTCLO, 'YYYY-MM-DD') =:dataRefVer and TIPRGTCLO=:tipoVer ")

      Return stringBuilder.ToString()
    End Function

    Public Function proximoCodigoGestaoCarga() As String
      Dim stringBuilder As New StringBuilder()

      stringBuilder.Append(" SELECT NVL( MAX(NUMSEQRGTCLO)+1,1) NUMSEQRGTCLO FROM MRT.RLCRGTMOVCLO ")

      Return stringBuilder.ToString()
    End Function
  End Class
End Namespace
