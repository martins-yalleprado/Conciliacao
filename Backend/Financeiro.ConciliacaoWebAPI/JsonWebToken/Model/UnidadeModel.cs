using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JsonWebToken.Model
{
  public class UnidadeModel
  {
    public int codUnidade { get; set; }
    public string nomUnidade { get; set; }
    public string desUnidade { get; set; }
    public string situacao { get; set; }
    public int codFuncionario { get; set; }
    public string situacaoLabel { get; set; }
  }
}
