using System.Text;

namespace JsonWebToken.Code.UnidadeConta
{
  public class UnidadeContaSQL
  {
    public string SelectUnidadeConta()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(" select CODCADCNTUND,CODCNTCTB,CODUNDNGC,SITCNTUND,CODFNC from CADCNTUND ");
      return stringBuilder.ToString();
    }
    public string AtivarUnidadeConta()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("  Update CADCNTUND  set SITCNTUND='1' where CODCADCNTUND=:codUnidadeConta ");
      return stringBuilder.ToString();
    }
     public string InativarUnidadeConta()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("  Update CADCNTUND  set SITCNTUND='0' where CODCADCNTUND=:CodUnidadeConta ");
      return stringBuilder.ToString();
    }
    public string InsertUnidadeConta()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("  insert into CADCNTUND  (CODCADCNTUND,CODCNTCTB,CODUNDNGC,SITCNTUND,CODFNC) values (:codUnidadeConta,:codConta,:codUnidade,'1',:codFuncionario) ");
      return stringBuilder.ToString();
    }
  }
}
