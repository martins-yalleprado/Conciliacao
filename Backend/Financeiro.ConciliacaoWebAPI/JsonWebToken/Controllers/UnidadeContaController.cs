using JsonWebToken.Code.UnidadeConta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JsonWebToken.Model
{
  public class UnidadeContaController : ApiController
  {
    // GET api/<controller>
    public IEnumerable<UnidadeContaModel> Get()
    {
      UnidadeContaBLL bll = new UnidadeContaBLL();
      return bll.SelectUnidadeConta();
    }

    // GET api/<controller>/5
    public string Get(int id)
    {
     // UnidadeContaBLL bll = new UnidadeContaBLL();
      return "value";
    }

    // POST api/<controller>
    public void Post([FromBody]UnidadeContaModel unidadeConta)
    {
      UnidadeContaBLL bll = new UnidadeContaBLL();
     
        bll.InsertUnidadeConta(unidadeConta);
      }

    // PUT api/<controller>/5
    public void Put([FromBody]UnidadeContaModel unidadeConta, string acao)
    {
      UnidadeContaBLL bll = new UnidadeContaBLL();
      if (acao.ToLower().Equals("ativar"))
      {
        bll.AtivarUnidadeConta(unidadeConta);
      }
      else if (acao.ToLower().Equals("inativar"))
      {
        bll.InativarUnidadeConta(unidadeConta);
      }
      
    }

    // DELETE api/<controller>/5
    public void Delete(int id)
    {
      //não realiza esta operacao
      //  UnidadeContaBLL bll = new UnidadeContaBLL();

    }
  }
}
