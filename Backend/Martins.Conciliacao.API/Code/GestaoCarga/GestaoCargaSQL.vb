Namespace Code.GestaoCarga
  Public Class GestaoCargaSQL
    Public Function selectGestaoCargaPorId() As String
      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append("    Select GC.*,NVL(  ")
      stringBuilder.Append("  case UPPER(TIPRGTCLO) WHEN  'TIT' then(Select Sum(NVL(VLRMOV, 0)) vltTTl  ")
      stringBuilder.Append("                                          from MOVTITCLOSYSCOB tit where tit.NUMSEQCRGTAB = gc.NUMSEQRGTCLO)  ")
      stringBuilder.Append("                          WHEN  'CTB' then(Select Sum(NVL(VLRCRDLMTCTB, 0) - NVL(VLRDBTLMTCTB, 0)) vltTTl  ")
      stringBuilder.Append("                                            from MOVCTBCLOSYSCOB ctb where ctb.NUMSEQCRGTAB = gc.NUMSEQRGTCLO)  ")
      stringBuilder.Append("                          WHEN  'AGN' then(Select Sum(NVL(VLRSLDTIT, 0)) vltTTl  ")
      stringBuilder.Append("                                            from MOVAGNCLOSYSCOB agn where agn.NUMSEQCRGTAB = gc.NUMSEQRGTCLO) end,0.0) vltTTl  ,")
      stringBuilder.Append("  case UPPER(TIPRGTCLO) WHEN  'TIT' then(Select count(1) qtd ")
      stringBuilder.Append("                                          from MOVTITCLOSYSCOB tit where tit.NUMSEQCRGTAB = gc.NUMSEQRGTCLO)  ")
      stringBuilder.Append("                          WHEN  'CTB' then(Select count(1) qtd  ")
      stringBuilder.Append("                                            from MOVCTBCLOSYSCOB ctb where ctb.NUMSEQCRGTAB = gc.NUMSEQRGTCLO)  ")
      stringBuilder.Append("                          WHEN  'AGN' then(Select count(1) qtd  ")
      stringBuilder.Append("                                            from MOVAGNCLOSYSCOB agn where agn.NUMSEQCRGTAB = gc.NUMSEQRGTCLO) end qtd  ")
      stringBuilder.Append("  from RLCRGTMOVCLO GC ")
      stringBuilder.Append(" where GC.NUMSEQRGTCLO=:codigo ")
      Return stringBuilder.ToString()
    End Function
    Public Function selectGestaoCarga() As String
      Dim stringBuilder As New StringBuilder()

      stringBuilder.Append("    Select GC.*,NVL(  ")
      stringBuilder.Append("  case UPPER(TIPRGTCLO) WHEN  'TIT' then(Select Sum(NVL(VLRMOV, 0)) vltTTl  ")
      stringBuilder.Append("                                          from MOVTITCLOSYSCOB tit where tit.NUMSEQCRGTAB = gc.NUMSEQRGTCLO)  ")
      stringBuilder.Append("                          WHEN  'CTB' then(Select Sum(NVL(VLRCRDLMTCTB, 0) - NVL(VLRDBTLMTCTB, 0)) vltTTl  ")
      stringBuilder.Append("                                            from MOVCTBCLOSYSCOB ctb where ctb.NUMSEQCRGTAB = gc.NUMSEQRGTCLO)  ")
      stringBuilder.Append("                          WHEN  'AGN' then(Select Sum(NVL(VLRSLDTIT, 0)) vltTTl  ")
      stringBuilder.Append("                                            from MOVAGNCLOSYSCOB agn where agn.NUMSEQCRGTAB = gc.NUMSEQRGTCLO) end,0.0) vltTTl  ,")
      stringBuilder.Append("  case UPPER(TIPRGTCLO) WHEN  'TIT' then(Select count(1) qtd ")
      stringBuilder.Append("                                          from MOVTITCLOSYSCOB tit where tit.NUMSEQCRGTAB = gc.NUMSEQRGTCLO)  ")
      stringBuilder.Append("                          WHEN  'CTB' then(Select count(1) qtd  ")
      stringBuilder.Append("                                            from MOVCTBCLOSYSCOB ctb where ctb.NUMSEQCRGTAB = gc.NUMSEQRGTCLO)  ")
      stringBuilder.Append("                          WHEN  'AGN' then(Select count(1) qtd  ")
      stringBuilder.Append("                                            from MOVAGNCLOSYSCOB agn where agn.NUMSEQCRGTAB = gc.NUMSEQRGTCLO) end qtd  ")
      stringBuilder.Append("  from RLCRGTMOVCLO GC where TO_char(DATGRCRGTCLO, 'YYYY-MM-DD') =:dataref and NVL(:tipo, TIPRGTCLO) = NVL(TIPRGTCLO,:tipo)  ")

      Return stringBuilder.ToString()
    End Function
    Public Function deleteGestaoCarga() As String

      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append("delete RLCRGTMOVCLO  where NUMSEQRGTCLO=:codigo ")
      Return stringBuilder.ToString()
    End Function
    Public Function deleteGestaoCargaCtb() As String
      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append("delete MOVCTBCLOSYSCOB  where NUMSEQCRGTAB =:codigo ")
      Return stringBuilder.ToString()
    End Function
    Public Function deleteGestaoCargaTit() As String

      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append("delete MOVTITCLOSYSCOB  where NUMSEQCRGTAB =:codigo ")
      Return stringBuilder.ToString()
    End Function
    Public Function deleteGestaoCargaAgn() As String

      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append("delete MOVAGNCLOSYSCOB  where NUMSEQCRGTAB =:codigo ")
      Return stringBuilder.ToString()
    End Function

    Public Function updateGestaoCargaVersaoOficialAtivar() As String
      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append("update RLCRGTMOVCLO set IDTVRSRGTATV='1' where NUMSEQRGTCLO=:codigoUpdate ")
      Return stringBuilder.ToString()
    End Function
    Public Function updateGestaoCargaVersaoOficialInativar() As String
      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append("update RLCRGTMOVCLO set IDTVRSRGTATV='0' where NUMSEQRGTCLO<>:codigoUpdate and TO_char(DATGRCRGTCLO, 'YYYY-MM-DD') =:datarefUpdate and TIPRGTCLO=:tipoUpdate  ")
      Return stringBuilder.ToString()
    End Function
    Public Function insertLoteAging() As String
      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append("insert into MOVAGNCLOSYSCOB                                                             ")
      stringBuilder.Append("select :Codigo NUMSEQCRGTAB,AGN.* from MOVAGNCLOCOB AGN where  TO_char( AGN.DATREF, 'YYYY-MM-DD') =:datamov             ")
      Return stringBuilder.ToString()
    End Function
    Public Function insertLoteTitulo() As String
      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append(" insert into MOVTITCLOSYSCOB                                                           ")
      stringBuilder.Append("select :Codigo NUMSEQCRGTAB, TIT.* from MOVTITCLOCOB TIT where   TO_char( TIT.DATMOV, 'YYYY-MM-DD') =:datamov      ")

      Return stringBuilder.ToString()
    End Function
    Public Function insertLoteContabil() As String
      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append("insert into MOVCTBCLOSYSCOB                                                                                       ")
      stringBuilder.Append("select :Codigo NUMSEQCRGTAB,CTB.* from MOVCTBCLOCOB CTB where   TO_char( CTB.DATEFTLMTCTB, 'YYYY-MM-DD') =:datamov   ")
      Return stringBuilder.ToString()
    End Function


    Public Function insertGestaoCarga() As String
      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append("INSERT INTO RLCRGTMOVCLO ( NUMSEQRGTCLO,DATCRISEQRGTCLO,DATGRCRGTCLO,TIPRGTCLO,NUMVRSRGTCLO,IDTVRSRGTATV) VALUES(:codigo, SYSDATE, :datamov, :tipo, :versao, '1')")
      Return stringBuilder.ToString()
    End Function
    Public Function selectMaxVersion() As String
      Dim stringBuilder As New StringBuilder()

      stringBuilder.Append("  Select NVL( MAx (GC. NUMVRSRGTCLO )+1,1) NUMVRSRGTCLO                                                                                  ")
      stringBuilder.Append("  from RLCRGTMOVCLO GC where TO_char(DATCRISEQRGTCLO, 'YYYY-MM-DD') =:dataRefVer and  TIPRGTCLO=:tipoVer  ")

      Return stringBuilder.ToString()
    End Function

    Public Function proximoCodigoGestaoCarga() As String
      Dim stringBuilder As New StringBuilder()

      stringBuilder.Append(" SELECT MAX(NUMSEQRGTCLO)+1 NUMSEQRGTCLO FROM RLCRGTMOVCLO  ")

      Return stringBuilder.ToString()
    End Function
  End Class
End Namespace



