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

namespace JsonWebToken.Code.Periodo
{
  public class PeriodoSQL
  {
    public string selectPeriodoPorId()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("Select CODPODAGN,NOMPODAGN,IDTSITPODAGN from CADPODAGN where CODPODAGN =:codigo");
      return stringBuilder.ToString();
    }
    public string selectPeriodo() {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("Select CODPODAGN,NOMPODAGN,IDTSITPODAGN from CADPODAGN where NVL(NOMPODAGN,:nome) like NVL(:nome,NOMPODAGN) and  NVL(IDTSITPODAGN,:situacao) =NVL(:situacao,IDTSITPODAGN)");
      return stringBuilder.ToString();
    }

    public string deletePeriodo()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("delete CADPODAGN where CODPODAGN =:codigo");
      return stringBuilder.ToString();
    }
    public string updatePeriodo()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("update CADPODAGN set NOMPODAGN=:nome where CODPODAGN =:codigo");
      return stringBuilder.ToString();
    }
    public string ativarPeriodo()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("update CADPODAGN set IDTSITPODAGN='1' where CODPODAGN =:codigo");
      return stringBuilder.ToString();
    }
    public string desativarPeriodo()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("update CADPODAGN set IDTSITPODAGN='0' where CODPODAGN =:codigo");
      return stringBuilder.ToString();
    }
    public string inserirPeriodo()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(" insert into  CADPODAGN  (CODPODAGN,NOMPODAGN,IDTSITPODAGN) values (NVL ((Select MAx(CODPODAGN)+1 from CADPODAGN),1),:nome,:situacao) ");
      return stringBuilder.ToString();
    }
  }
}

