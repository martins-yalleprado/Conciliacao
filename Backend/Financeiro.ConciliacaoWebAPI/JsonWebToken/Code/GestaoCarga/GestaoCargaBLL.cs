using JsonWebToken.Code.GestaoCarga;
using JsonWebToken.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JsonWebToken.Code
{
  public class GestaoCargaBLL
  {
    public GestaoCargaModel selectGestaoCargaPorId(int id) {
      try
      {
        GestaoCargaDAL DAL = new GestaoCargaDAL();
        return DAL.selectGestaoCargaPorId(id);
      }
      catch (Exception e)
      {
        throw e;
      }
    }
    public List<GestaoCargaModel> selectGestaoCarga(DateTime dataRef, String tipo)
    {
      try
      {
        GestaoCargaDAL DAL = new GestaoCargaDAL();
        List<GestaoCargaModel> list = DAL.selectGestaoCarga(dataRef, tipo);
        return list;
      }
      catch (Exception e)
      {
        throw e;
      }
    }
  

    public void deleteGestaoCarga(int id)
    {
      try
      {
        GestaoCargaDAL DAL = new GestaoCargaDAL();
      DAL.deleteGestaoCarga(id);

      }
      catch (Exception e)
      {
        throw e;
      }
    }
    
    public void updateGestaoCarga(GestaoCargaModel gestaoCargaModel)
    {
      GestaoCargaDAL DAL = new GestaoCargaDAL();
      DAL.atualizarVersao(gestaoCargaModel);
    }

    public void insertGestaoCarga(DateTime dataRef )
    {
      try
      {
        GestaoCargaDAL DAL = new GestaoCargaDAL();
        DAL.insertGestaoCarga(dataRef);

      }
      catch (Exception e)
      {
        throw e;
      }
    }
  }

}

