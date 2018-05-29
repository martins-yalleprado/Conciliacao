using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JsonWebToken.Code.Permissao
{
  public class PermissaoSQL
  {
    public string SelectPermissao(string NOMGRPACS)
    {
      return string.Format(@"select DISTINCT p.CODACSFUN, p.NOMACSFUN from CADGRPACSCLO g
                                  inner Join RLCGRPACS pg on g.CODIDTGRP=pg.CODIDTGRP
                                  inner Join CADACSSISCLO p on pg.CODACSCLO=p.CODACSCLO
                                  where g.NOMGRPACS in ({0})", NOMGRPACS);
    }
  }
}
