
using System.Text;


namespace JsonWebToken.Code.GestaoCarga
{
  public class GestaoCargaSQL
  {
    public string selectGestaoCargaPorId()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("    Select GC.*,NVL(  ");
      stringBuilder.Append("  case UPPER(TIPRGTCLO) WHEN  'TIT' then(Select Sum(NVL(VLRMOV, 0)) vltTTl  ");
      stringBuilder.Append("                                          from MOVTITCLOSYSCOB tit where tit.NUMSEQCRGTAB = gc.NUMSEQRGTCLO)  ");
      stringBuilder.Append("                          WHEN  'CTB' then(Select Sum(NVL(VLRCRDLMTCTB, 0) - NVL(VLRDBTLMTCTB, 0)) vltTTl  ");
      stringBuilder.Append("                                            from MOVCTBCLOSYSCOB ctb where ctb.NUMSEQCRGTAB = gc.NUMSEQRGTCLO)  ");
      stringBuilder.Append("                          WHEN  'CTB' then(Select Sum(NVL(VLRSLDTIT, 0)) vltTTl  ");
      stringBuilder.Append("                                            from MOVAGNCLOSYSCOB agn where agn.NUMSEQCRGTAB = gc.NUMSEQRGTCLO) end,0.0) vltTTl  ");
      stringBuilder.Append("  from RLCRGTMOVCLO GC ");
      stringBuilder.Append(" where GC.NUMSEQRGTCLO=:codigo ");
      return stringBuilder.ToString();
    }
    public string selectGestaoCarga()
    {
      StringBuilder stringBuilder = new StringBuilder();

      stringBuilder.Append("    Select GC.*,NVL(  ");
      stringBuilder.Append("  case UPPER(TIPRGTCLO) WHEN  'TIT' then(Select Sum(NVL(VLRMOV, 0)) vltTTl  ");
      stringBuilder.Append("                                          from MOVTITCLOSYSCOB tit where tit.NUMSEQCRGTAB = gc.NUMSEQRGTCLO)  ");
      stringBuilder.Append("                          WHEN  'CTB' then(Select Sum(NVL(VLRCRDLMTCTB, 0) - NVL(VLRDBTLMTCTB, 0)) vltTTl  ");
      stringBuilder.Append("                                            from MOVCTBCLOSYSCOB ctb where ctb.NUMSEQCRGTAB = gc.NUMSEQRGTCLO)  ");
      stringBuilder.Append("                          WHEN  'CTB' then(Select Sum(NVL(VLRSLDTIT, 0)) vltTTl  ");
      stringBuilder.Append("                                            from MOVAGNCLOSYSCOB agn where agn.NUMSEQCRGTAB = gc.NUMSEQRGTCLO) end,0.0) vltTTl  ");
      stringBuilder.Append("  from RLCRGTMOVCLO GC where TO_char(DATCRISEQRGTCLO, 'YYYY-MM-DD') =:dataref and NVL(:tipo, TIPRGTCLO) = NVL(TIPRGTCLO,:tipo)  ");

      return stringBuilder.ToString();
    }
    public string deleteGestaoCarga()
    {

      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("delete RLCRGTMOVCLO  where NUMSEQRGTCLO=:codigo ");
      return stringBuilder.ToString();
    }
    public string deleteGestaoCargaCtb()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("delete MOVCTBCLOSYSCOB  where NUMSEQCRGTAB =:codigo ");
      return stringBuilder.ToString();
    }
    public string deleteGestaoCargaTit()
    {

      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("delete MOVTITCLOSYSCOB  where NUMSEQCRGTAB =:codigo ");
      return stringBuilder.ToString();
    }
    public string deleteGestaoCargaAgn()
    {

      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("delete MOVAGNCLOSYSCOB  where NUMSEQCRGTAB =:codigo ");
      return stringBuilder.ToString();
    }

    public string updateGestaoCargaVersaoOficialAtivar()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("update RLCRGTMOVCLO set IDTVRSRGTATV='1' where NUMSEQRGTCLO=:codigoUpdate ");
      return stringBuilder.ToString();
    }
    public string updateGestaoCargaVersaoOficialInativar()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("update RLCRGTMOVCLO set IDTVRSRGTATV='0' where NUMSEQRGTCLO<>:codigoUpdate and TO_char(DATCRISEQRGTCLO, 'YYYY-MM-DD') =:datarefUpdate and TIPRGTCLO=:tipoUpdate  ");
      return stringBuilder.ToString();
    }
    public string insertLoteAging()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("insert into MOVAGNCLOSYSCOB                                                             ");
      stringBuilder.Append("select :Codigo NUMSEQCRGTAB,AGN.* from MOVAGNCLOCOB AGN where  TO_char( AGN.DATREF, 'YYYY-MM-DD') =:datamov             ");
      return stringBuilder.ToString();
    }
    public string insertLoteTitulo()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(" insert into MOVTITCLOSYSCOB                                                           ");
      stringBuilder.Append("select :Codigo NUMSEQCRGTAB, TIT.* from MOVTITCLOCOB TIT where   TO_char( TIT.DATMOV, 'YYYY-MM-DD') =:datamov      ");

      return stringBuilder.ToString();
    }
    public string insertLoteContabil()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("insert into MOVCTBCLOSYSCOB                                                                                       ");
      stringBuilder.Append("select :Codigo NUMSEQCRGTAB,CTB.* from MOVCTBCLOCOB CTB where   TO_char( CTB.DATEFTLMTCTB, 'YYYY-MM-DD') =:datamov   ");
      return stringBuilder.ToString();
    }

 
    public string insertGestaoCarga() { 
    StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("INSERT INTO RLCRGTMOVCLO ( NUMSEQRGTCLO,DATCRISEQRGTCLO,DATGRCRGTCLO,TIPRGTCLO,NUMVRSRGTCLO,IDTVRSRGTATV) VALUES(:codigo, SYSDATE, :datamov, :tipo, :versao, '1')");
      return stringBuilder.ToString();
}
    public string selectMaxVersion()
    {
      StringBuilder stringBuilder = new StringBuilder();

      stringBuilder.Append("  Select NVL( MAx (GC. NUMVRSRGTCLO )+1,1) NUMVRSRGTCLO                                                                                  ");
      stringBuilder.Append("  from RLCRGTMOVCLO GC where TO_char(DATCRISEQRGTCLO, 'YYYY-MM-DD') =:dataRefVer and  TIPRGTCLO=:tipoVer  ");

      return stringBuilder.ToString();
    }

    public string proximoCodigoGestaoCarga()
    {
      StringBuilder stringBuilder = new StringBuilder();

      stringBuilder.Append(" SELECT MAX(NUMSEQRGTCLO)+1 NUMSEQRGTCLO FROM RLCRGTMOVCLO  ");

      return stringBuilder.ToString();
    }
  }
 }



