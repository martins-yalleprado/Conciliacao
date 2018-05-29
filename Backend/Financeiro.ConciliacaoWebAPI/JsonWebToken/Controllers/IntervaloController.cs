using System;
using System.Collections.Generic;
using JsonWebToken.Code;
using System.Web.Http;

namespace JsonWebToken.Model
{
  public class IntervaloController : ApiController
  {
    // GET api/<controller>
    public IEnumerable<IntervaloModel> Get(int periodo)
    {
      IntervaloBLL bll = new IntervaloBLL();

      return bll.selectIntervalo(periodo);
    }

    // GET api/<controller>/5
  //  public string Get(int id)
  //  {
  //    return "value";
  //  }

    // POST api/<controller>
    public void Post([FromBody]IntervaloModel intervalo)
    {
      IntervaloBLL bll = new IntervaloBLL();
      bll.insertIntervalo(intervalo);
    }

    // PUT api/<controller>/5
    public void Put( [FromBody]IntervaloModel intervalo,string acao)
    {
      IntervaloBLL bll = new IntervaloBLL();
      if (acao.ToLower().Equals("ativar") || acao.ToLower().Equals("desativar"))
      {
        bll.ativarDesativarIntervalo(intervalo);
      }
      else
      {
        bll.updateIntervalo(intervalo);
      }
    }

    // DELETE api/<controller>/5
    public void Delete(int id)
    {
    }
  }
}
