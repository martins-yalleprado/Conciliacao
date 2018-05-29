using JsonWebToken.Code.Unidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JsonWebToken.Model
{
  public class UnidadeController : ApiController
  { // GET api/<controller>
    public IEnumerable<UnidadeModel> Get()
    {
      UnidadeBLL bll = new UnidadeBLL();
      return bll.SelectUnidade();
    }

    // GET api/<controller>/5
    public string Get(int id)
    {
      // UnidadeBLL bll = new UnidadeBLL();
      return "value";
    }

    // POST api/<controller>
    public void Post([FromBody]UnidadeModel Unidade)
    {
      UnidadeBLL bll = new UnidadeBLL();

      bll.InsertUnidade(Unidade);
    }

    // PUT api/<controller>/5
    public void Put([FromBody]UnidadeModel Unidade, string acao)
    {
      UnidadeBLL bll = new UnidadeBLL();
      if (acao.ToLower().Equals("ativar"))
      {
        bll.AtivarUnidade(Unidade);
      }
      else if (acao.ToLower().Equals("inativar"))
      {
        bll.InativarUnidade(Unidade);
      }

    }

    // DELETE api/<controller>/5
    public void Delete(int id)
    {
      //não realiza esta operacao
      //  UnidadeBLL bll = new UnidadeBLL();

    }
  }
}
