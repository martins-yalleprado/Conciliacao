using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JsonWebToken.Model;

namespace JsonWebToken.Code.Unidade
{
  public class UnidadeBLL
  {
    public List<UnidadeModel> SelectUnidade()
    {
      try
      {
        UnidadeDAL dal = new UnidadeDAL();
        return dal.SelectUnidade();
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
    public void AtivarUnidade(UnidadeModel Unidade)
    {
      try
      {
        UnidadeDAL dal = new UnidadeDAL();
        dal.AtivarUnidade(Unidade);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
    public void InativarUnidade(UnidadeModel Unidade)
    {
      try
      {
        UnidadeDAL dal = new UnidadeDAL();
        dal.InativarUnidade(Unidade);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
    public void InsertUnidade(UnidadeModel Unidade)
    {
      try
      {
        UnidadeDAL dal = new UnidadeDAL();
        dal.InsertUnidade(Unidade);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
  }
}
