using JsonWebToken.Code;
using JsonWebToken.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JsonWebToken.Controllers
{
  public class PeriodoController : ApiController
  {
    // GET api/<controller>
    public IEnumerable<PeriodoModel> Get(string nome, string situacao)
    {
      PeriodoBLL bll = new PeriodoBLL();
      if (nome != null) {
        nome = "%"+ nome + "%";
      }
      return bll.selectPeriodo(nome,situacao);
    }
    // GET api/<controller>
    public IEnumerable<PeriodoModel> Get()
    {
      PeriodoBLL bll = new PeriodoBLL();
      
      return bll.selectPeriodo(null,null);
    }
    // GET api/<controller>
    public IEnumerable<PeriodoModel> Get(string nome)
    {
      PeriodoBLL bll = new PeriodoBLL();
      if (nome != null)
      {
        nome = "%" + nome + "%";
      }
      return bll.selectPeriodo(nome, null);
    }
    // GET api/<controller>/5
    public PeriodoModel Get(int id)
    {
      PeriodoBLL bll = new PeriodoBLL();

      return bll.selectPeriodoPorId(id);
    }

    // POST api/<controller>
    public void Post([FromBody]PeriodoModel periodo)
    {
      PeriodoBLL bll = new PeriodoBLL();
      if (bll.selectPeriodo(periodo.nome, null).Count > 0)
      {
        throw new Exception("Nome do Período já existente");
      }
      bll.insertPeriodo(periodo);
    }

    // PUT api/<controller>/5
    public void Put( [FromBody]PeriodoModel periodo, string acao)
    {
      PeriodoBLL bll = new PeriodoBLL();
      if (acao.ToLower().Equals("ativar")|| acao.ToLower().Equals("desativar"))
      {
        bll.ativarDesativarPeriodo(periodo);
      } else 
      {
        bll.updatePeriodo(periodo);
      }
    }

    // DELETE api/<controller>/5
    public void Delete(int id)
    {
      PeriodoBLL bll = new PeriodoBLL();
      bll.deletePeriodo(id);
    }
  }
}
