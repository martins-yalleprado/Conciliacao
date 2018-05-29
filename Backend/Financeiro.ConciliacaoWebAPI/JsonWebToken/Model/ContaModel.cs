using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JsonWebToken.Model
{
  public class ContaModel
  {
    public int codConta { get; set; }
    public string nomConta { get; set; }
    public string desConta { get; set; }
    public string situacao { get; set; }
    public int codFuncionario { get; set; }
    public string situacaoLabel { get; set; }
  }
}
