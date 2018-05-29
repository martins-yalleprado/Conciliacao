using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JsonWebToken.Model
{
  public class PeriodoModel
  {
    public int codPeriodo { get; set; }
    public string nome { get; set; }
    public string situacao { get; set; }
    public string situacaoLabel { get; set; }
  }
}
