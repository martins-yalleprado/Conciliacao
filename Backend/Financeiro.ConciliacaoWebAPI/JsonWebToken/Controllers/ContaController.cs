using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JsonWebToken.Code.Conta;

namespace JsonWebToken.Model
{
  public class ContaController : ApiController
  {
    public IEnumerable<ContaModel> Get()
    {
      ContaBLL bll = new ContaBLL();
      return bll.SelectConta();
    }

    // GET api/<controller>/5
    public string Get(int id)
    {
      // ContaBLL bll = new ContaBLL();
      return "value";
    }

    // POST api/<controller>
    public void Post([FromBody]ContaModel Conta)
    {
      ContaBLL bll = new ContaBLL();

      bll.InsertConta(Conta);
    }

    // PUT api/<controller>/5
    public void Put([FromBody]ContaModel Conta, string acao)
    {
      ContaBLL bll = new ContaBLL();
      if (acao.ToLower().Equals("ativar"))
      {
        bll.AtivarConta(Conta);
      }
      else if (acao.ToLower().Equals("inativar"))
      {
        bll.InativarConta(Conta);
      }

    }

    // DELETE api/<controller>/5
    public void Delete(int id)
    {
      //não realiza esta operacao
      //  ContaBLL bll = new ContaBLL();

    }
  }
}
