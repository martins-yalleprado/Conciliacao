using JsonWebToken.Model;
using System;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
using JsonWebToken.Util;

namespace JsonWebToken.Code.Intervalo
{
  public class IntervaloDAL
  {

    public OracleConnection oracleConnection;

    public IntervaloDAL()
    {
      oracleConnection = new OracleConnection(Utils.ORACLE_CONNECCAO);
      oracleConnection.Open();

    }
    public IntervaloModel selectIntervaloPorId(int id)
    {
      {

        IntervaloSQL sql = new IntervaloSQL();


        OracleCommand command = new OracleCommand();
        command.Connection = oracleConnection;
        command.CommandText = sql.selectIntervaloPorId();

        command.Parameters.Add("codigo", id);
        command.CommandType = System.Data.CommandType.Text;
        OracleDataReader reader = command.ExecuteReader();
        IntervaloModel Intervalo = null;

        try
        {
          if (reader.Read())
          {
            Intervalo = new IntervaloModel { codIntervalo = reader.GetInt32(0), inicio = reader.GetInt32(1), fim = reader.GetInt32(2), situacao = reader.GetString(3), codPeriodo = reader.GetInt32(4), situacaoLabel = reader.GetString(3)  == "1" ? "Ativo" : "Inativo" };
          }

          return Intervalo;
        }
        catch (Exception ex)
        {
          throw ex;
        }
        finally
        {

          if (oracleConnection != null)
            oracleConnection.Close();
        }
      }
    }

    public void updateIntervalo(IntervaloModel intervalo)
    {
        OracleCommand command = new OracleCommand();
        OracleTransaction transaction = oracleConnection.BeginTransaction();
        // Assign transaction object for a pending local transaction
        command.Connection = oracleConnection;
        command.Transaction = transaction;
        try
        {
          IntervaloSQL sql = new IntervaloSQL();
          command.CommandText = sql.updateIntervalo();
          command.Parameters.Add("codigo", intervalo.codIntervalo);
          command.Parameters.Add("inicio", intervalo.inicio);
          command.Parameters.Add("fim", intervalo.fim);
          command.Parameters.Add("periodo", intervalo.codPeriodo);
          command.ExecuteNonQuery();
          transaction.Commit();
        }
        catch (Exception ex)
        {
          transaction.Rollback();

          throw ex;
        }
      }

    public void deleteIntervalo(int id)
    {
      OracleCommand command = new OracleCommand();
      OracleTransaction transaction = oracleConnection.BeginTransaction();
      // Assign transaction object for a pending local transaction
      command.Connection = oracleConnection;
      command.Transaction = transaction;
      try
      {
        IntervaloSQL sql = new IntervaloSQL();
        command.CommandText = sql.deleteIntervalo();
        command.Parameters.Add("codigo", id);
        command.ExecuteNonQuery();
        transaction.Commit();
      }
      catch (Exception ex)
      {
        transaction.Rollback();

        throw ex;
      }
    }

    public List<IntervaloModel> selectIntervalo(int periodo)
    {

      IntervaloSQL sql = new IntervaloSQL();


      OracleCommand command = new OracleCommand();
      command.Connection = oracleConnection;
      command.CommandText = sql.selectIntervalo();

      command.Parameters.Add("periodo", periodo);
      command.CommandType = System.Data.CommandType.Text;
      OracleDataReader reader = command.ExecuteReader();
      List<IntervaloModel> Intervalo = new List<IntervaloModel>();

      try
      {
        while (reader.Read())
        {
          Intervalo.Add(new IntervaloModel { codIntervalo = reader.GetInt32(0), inicio = reader.GetInt32(1), fim = reader.GetInt32(2), situacao = reader.GetString(3), codPeriodo = reader.GetInt32(4) });
        }

        return Intervalo;
      }
      catch (Exception ex)
      {
        throw ex;
      }
      finally
      {

        if (oracleConnection != null)
          oracleConnection.Close();
      }
    }
    public void inserirIntervalo(IntervaloModel intervalo)
    {
      OracleCommand command = new OracleCommand();
      OracleTransaction transaction = oracleConnection.BeginTransaction();
      // Assign transaction object for a pending local transaction
      command.Connection = oracleConnection;
      command.Transaction = transaction;
      try
      {
        IntervaloSQL sql = new IntervaloSQL();
        command.CommandText = sql.inserirIntervalo();
        
          command.Parameters.Add("inicio", intervalo.inicio);
        command.Parameters.Add("fim", intervalo.fim);
        command.Parameters.Add("periodo", intervalo.codPeriodo);
        command.ExecuteNonQuery();
        transaction.Commit();
      }
      catch (Exception ex)
      {
        transaction.Rollback();

        throw ex;
      }
    }
    public void ativarIntervalo(int codigo)
    {
      OracleCommand command = new OracleCommand();
      OracleTransaction transaction = oracleConnection.BeginTransaction();
      // Assign transaction object for a pending local transaction
      command.Connection = oracleConnection;
      command.Transaction = transaction;
      try
      {
        IntervaloSQL sql = new IntervaloSQL();
        command.CommandText = sql.ativarIntervalo();
        command.Parameters.Add("codigo", codigo);
        command.ExecuteNonQuery();
        transaction.Commit();
      }
      catch (Exception ex)
      {
        transaction.Rollback();

        throw ex;
      }
    }
    public void desativarIntervalo(int codigo)
    {
      OracleCommand command = new OracleCommand();
      OracleTransaction transaction = oracleConnection.BeginTransaction();
      // Assign transaction object for a pending local transaction
      command.Connection = oracleConnection;
      command.Transaction = transaction;
      try
      {
        IntervaloSQL sql = new IntervaloSQL();
        command.CommandText = sql.desativarIntervalo();
        command.Parameters.Add("codigo", codigo);
        command.ExecuteNonQuery();
        transaction.Commit();
      }
      catch (Exception ex)
      {
        transaction.Rollback();

        throw ex;
      }
    }
  }
}
