using JsonWebToken.Code.Intervalo;
using JsonWebToken.Model;
using System;
using System.Collections.Generic;

namespace JsonWebToken.Code
{
  public class IntervaloBLL
  {

    public IntervaloModel selectIntervaloPorId(int id)
    {
      try
      {
        IntervaloDAL DAL = new IntervaloDAL();
        return DAL.selectIntervaloPorId(id);
      }
      catch (Exception e)
      {
        throw e;
      }
    }
    public List<IntervaloModel> selectIntervalo(int periodo)
    {
      try
      {
        IntervaloDAL DAL = new IntervaloDAL();
        List<IntervaloModel> list = DAL.selectIntervalo(periodo);
        return list;
      }
      catch (Exception e)
      {
        throw e;
      }
    }


    public void deleteIntervalo(int id)
    {
      try
      {
        IntervaloDAL DAL = new IntervaloDAL();
        DAL.deleteIntervalo(id);

      }
      catch (Exception e)
      {
        throw e;
      }
    }

    public void updateIntervalo(IntervaloModel intervalo)
    {
      try
      {
        IntervaloDAL DAL = new IntervaloDAL();
        DAL.updateIntervalo(intervalo);

      }
      catch (Exception e)
      {
        throw e;
      }
    }

    public void insertIntervalo(IntervaloModel intervalo)
    {
      try
      {
        IntervaloDAL DAL = new IntervaloDAL();
        DAL.inserirIntervalo(intervalo);

      }
      catch (Exception e)
      {
        throw e;
      }

    }
    public void ativarDesativarIntervalo(IntervaloModel Intervalo)
    {
      try
      {
        IntervaloDAL DAL = new IntervaloDAL();
        if (Intervalo.situacao.Equals("0"))
        {
          DAL.ativarIntervalo(Intervalo.codIntervalo);
        }
        else
        {
          DAL.desativarIntervalo(Intervalo.codIntervalo);
        }
      }
      catch (Exception e)
      {
        throw e;
      }

    }
  }
}
