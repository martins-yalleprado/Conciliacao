using JsonWebToken.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Text;

namespace JsonWebToken.Code.Intervalo
{
  public class IntervaloSQL
  {
    public string selectIntervaloPorId()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("Select CODIVLPODAGN,NUMINIIVLPODAGN,NUMFIMIVLPODAGN,IDTSITIVLPODAGN,CODPODAGN from CADIVLPODAGN where CODIVLPODAGN =:codigo");
      return stringBuilder.ToString();
    }
    public string selectIntervalo()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("Select CODIVLPODAGN,NUMINIIVLPODAGN,NUMFIMIVLPODAGN,IDTSITIVLPODAGN,CODPODAGN from CADIVLPODAGN where CODPODAGN=:periodo ");
      return stringBuilder.ToString();
    }
    public string deleteIntervalo()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("delete CADIVLPODAGN where CODIVLPODAGN =:codigo");
      return stringBuilder.ToString();
    }
    public string updateIntervalo()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("update CADIVLPODAGN set NUMINIIVLPODAGN= :inicio,NUMFIMIVLPODAGN=:fim,CODPODAGN =:periodo where CODIVLPODAGN=:codigo");
      return stringBuilder.ToString();
    }
    public string ativarIntervalo()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("update CADIVLPODAGN set IDTSITPODAGN='1' where CODIVLPODAGN =:codigo");
      return stringBuilder.ToString();
    }
    public string desativarIntervalo()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("update CADIVLPODAGN set IDTSITPODAGN='0' where CODIVLPODAGN =:codigo");
      return stringBuilder.ToString();
    }
    public string inserirIntervalo()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(" Insert into CADIVLPODAGN (CODIVLPODAGN,NUMINIIVLPODAGN,NUMFIMIVLPODAGN,IDTSITIVLPODAGN,CODPODAGN) values (Nvl((select MAX(CODIVLPODAGN)+1 from CADIVLPODAGN),1),:inicio,:fim ,'1',:periodo)");
      return stringBuilder.ToString();
    }
  }
}

