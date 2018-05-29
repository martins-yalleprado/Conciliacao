using System;
using System.Collections.Generic;


namespace JsonWebToken.Model
{
  public class GestaoCargaModel
  {
    public int codGestaoCarga { get; set; }
    public DateTime data { get; set; }
    public DateTime dataMovimentacao { get; set; }
    public string tipo { get; set; }
    public int versao { get; set; }
    public string versaoOficial { get; set; }
    public float valor { get; set; }
    public string versaoOficialLabel { get; set; }

  }
}
