using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace JsonWebToken.Code.Unidade
{
  public class UnidadeSQL
  {

    public string SelectUnidade()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(" Select CODEMP,CODUNDNGC,DESUNDNGC,CODFILCENADM,CODFILTITPGT,DATCAD,DATDST,CODLIVCTB,CODUNDOPE from T0123469  ");
      return stringBuilder.ToString();
    }
    public string SelectUnidadePorId()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(" Select CODEMP,CODUNDNGC,DESUNDNGC,CODFILCENADM,CODFILTITPGT,DATCAD,DATDST,CODLIVCTB,CODUNDOPE from T0123469  where CODEMP=:CODEMP  ");
      return stringBuilder.ToString();
    }
    public string AtivarUnidade()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(" update  ");
      return stringBuilder.ToString();
    }
    public string InativarUnidade()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(" ");
      return stringBuilder.ToString();
    }
    public string InsertUnidade()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("  ");
      return stringBuilder.ToString();
    }
  }
}
