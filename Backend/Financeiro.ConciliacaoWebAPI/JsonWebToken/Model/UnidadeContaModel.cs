using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JsonWebToken.Model
{
  public class UnidadeContaModel
  {
    public int codUnidadeConta { get; set; }
    public int codUnidade { get; set; }
    public int codConta { get; set; }
    public string situacao { get; set; }
    public int codFuncionario { get; set; }
    public string situacaoLabel { get; set; }
  }
}
