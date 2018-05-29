using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JsonWebToken.Model
{
  public class IntervaloModel
  {
    public int codIntervalo { get; set; }
    public int inicio { get; set; }
    public int fim { get; set; }
    public string situacao { get; set; }
    public int codPeriodo { get; set; }
    public string situacaoLabel { get; set; }
  }
}
