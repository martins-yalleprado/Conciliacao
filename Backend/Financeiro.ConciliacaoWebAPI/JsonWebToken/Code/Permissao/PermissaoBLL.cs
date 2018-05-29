using JsonWebToken.Code.Permissao;
using JsonWebToken.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JsonWebToken.Code
{
  public class PermissaoBLL
  {

    public List<PermissaoModel> SelectPermissao(List<string> lstNomGrpAcs)
    {
      try
      {
        return (new PermissaoDAL()).SelectPermissao(lstNomGrpAcs);
      }
      catch (Exception e)
      {
        throw e;
      }
    }
  }
}
