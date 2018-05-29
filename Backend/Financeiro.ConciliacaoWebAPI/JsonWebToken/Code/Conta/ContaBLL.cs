using JsonWebToken.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JsonWebToken.Code.Conta
{
  public class ContaBLL
  {
    public List<ContaModel> SelectConta()
    {
      try
      {
        ContaDAL dal = new ContaDAL();
        return dal.SelectConta();
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
    public void AtivarConta(ContaModel Conta)
    {
      try
      {
        ContaDAL dal = new ContaDAL();
        dal.AtivarConta(Conta);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
    public void InativarConta(ContaModel Conta)
    {
      try
      {
        ContaDAL dal = new ContaDAL();
        dal.InativarConta(Conta);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
    public void InsertConta(ContaModel Conta)
    {
      try
      {
        ContaDAL dal = new ContaDAL();
        dal.InsertConta(Conta);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
  }
}
