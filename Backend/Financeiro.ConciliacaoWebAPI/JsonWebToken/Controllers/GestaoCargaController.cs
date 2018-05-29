using JsonWebToken.Code;
using JsonWebToken.Filters;
using JsonWebToken.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;

namespace JsonWebToken.Controllers
{
  [Authorize]
  public class GestaoCargaController : ApiController
  {


    // GET api/<controller>
    [HeaderFilter, Authorize(Roles = "GESTAO.CARGA.PESQUISAR")]
    public IEnumerable<GestaoCargaModel> Get(DateTime dataref,string tipo)
    {
        GestaoCargaBLL bll = new GestaoCargaBLL();
        return bll.selectGestaoCarga(dataref, tipo);
    }

    // GET api/<controller>/5
    [HeaderFilter, Authorize(Roles = "GESTAO.CARGA.PESQUISAR")]
    public GestaoCargaModel Get(int id)
    {
      GestaoCargaBLL bll = new GestaoCargaBLL();
      return bll.selectGestaoCargaPorId(id);
    }

    // POST api/<controller>
    [HeaderFilter, Authorize(Roles = "GESTAO.CARGA.CRIAR")]
    public void Post(DateTime dataref)
    {
      GestaoCargaBLL bll = new GestaoCargaBLL();
       bll.insertGestaoCarga(dataref);
    }

    // PUT api/<controller>/5
    [HeaderFilter, Authorize(Roles = "GESTAO.CARGA.EDITAR")]
    public void Put( [FromBody]GestaoCargaModel GestaoCargaModel)
    {
      GestaoCargaBLL bll = new GestaoCargaBLL();
       bll.updateGestaoCarga(GestaoCargaModel);
    }

    // DELETE api/<controller>/5
    [HeaderFilter ,Authorize(Roles = "GESTAO.CARGA.REMOVER")]    
    public void Delete(int id)
    {
      GestaoCargaBLL bll = new GestaoCargaBLL();
       bll.deleteGestaoCarga(id);
    }
  }
}
