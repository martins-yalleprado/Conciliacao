using JsonWebToken.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JsonWebToken.Code.UnidadeConta
{
  public class UnidadeContaBLL
  {
    public List<UnidadeContaModel> SelectUnidadeConta()
    {
      try
      {
        UnidadeContaDAL dal = new UnidadeContaDAL();
        return dal.SelectUnidadeConta();
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
    public void AtivarUnidadeConta(UnidadeContaModel unidadeConta)
    {
      try
      {
        UnidadeContaDAL dal = new UnidadeContaDAL();
         dal.AtivarUnidadeConta( unidadeConta);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
    public void InativarUnidadeConta(UnidadeContaModel unidadeConta)
    {
      try
      {
        UnidadeContaDAL dal = new UnidadeContaDAL();
         dal.InativarUnidadeConta( unidadeConta);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
    public void InsertUnidadeConta(UnidadeContaModel unidadeConta)
    {
      try
      {
        UnidadeContaDAL dal = new UnidadeContaDAL();
         dal.InsertUnidadeConta(unidadeConta);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
  }
}
