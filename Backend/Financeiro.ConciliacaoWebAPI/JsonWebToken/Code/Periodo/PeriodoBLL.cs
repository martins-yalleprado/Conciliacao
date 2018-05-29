using JsonWebToken.Code.Periodo;
using JsonWebToken.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JsonWebToken.Code
{
  public class PeriodoBLL
  {
    public PeriodoModel selectPeriodoPorId(int id) {
      try
      {
        PeriodoDAL DAL = new PeriodoDAL();
        return DAL.selectPeriodoPorId(id);
      }
      catch (Exception e)
      {
        throw e;
      }
    }
    public List<PeriodoModel> selectPeriodo(string nome,string situacao)
    {
      try
      {
        PeriodoDAL DAL = new PeriodoDAL();
        List<PeriodoModel> list = DAL.selectPeriodo(nome,situacao);
        return list;
      }
      catch (Exception e)
      {
        throw e;
      }
    }
  

    public void deletePeriodo(int id)
    {
      try
      {
        PeriodoDAL DAL = new PeriodoDAL();
      DAL.deletePeriodo(id);

      }
      catch (Exception e)
      {
        throw e;
      }
    }
    public void insertPeriodo(PeriodoModel periodo)
    {
      try
      {
        PeriodoDAL DAL = new PeriodoDAL();
        DAL.inserirPeriodo(periodo);

      }
      catch (Exception e)
      {
        throw e;
      }

    }

    public void updatePeriodo(PeriodoModel periodo)
    {
      try
      {
        PeriodoDAL DAL = new PeriodoDAL();
        DAL.updatePeriodo(periodo);
      }
      catch (Exception e)
      {
        throw e;
      }

    }

    public void ativarDesativarPeriodo(PeriodoModel periodo)
    {
      try
      {
        PeriodoDAL DAL = new PeriodoDAL();
        if (periodo.situacao.Equals("0"))
        {
          DAL.ativarPeriodo(periodo.codPeriodo);
        }
        else {
          DAL.desativarPeriodo(periodo.codPeriodo);
        }
      }
      catch (Exception e)
      {
        throw e;
      }

    }
  }
}
