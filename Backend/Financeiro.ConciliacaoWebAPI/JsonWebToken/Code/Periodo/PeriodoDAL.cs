using JsonWebToken.Model;
using System;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
using JsonWebToken.Util;

namespace JsonWebToken.Code.Periodo
{
  public class PeriodoDAL
  {

    public OracleConnection oracleConnection;

    public PeriodoDAL()
    {
      oracleConnection = new OracleConnection(Utils.ORACLE_CONNECCAO);
      oracleConnection.Open();

    }
    public PeriodoModel selectPeriodoPorId(int id)
    {
      {

        PeriodoSQL sql = new PeriodoSQL();


        OracleCommand command = new OracleCommand();
        command.Connection = oracleConnection;
        command.CommandText = sql.selectPeriodoPorId();

        command.Parameters.Add("codigo", id);
        command.CommandType = System.Data.CommandType.Text;
        OracleDataReader reader = command.ExecuteReader();
        PeriodoModel Periodo = null;

        try
        {
          if (reader.Read())
          {
            Periodo = new PeriodoModel { codPeriodo = reader.GetInt32(0), nome = reader.GetString(1), situacao = reader.GetString(2), situacaoLabel = reader.GetString(2) == "1" ? "Ativo" : "Inativo" };
          }

          return Periodo;
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
    public void deletePeriodo(int id)
    {
      OracleCommand command = new OracleCommand();
      OracleTransaction transaction = oracleConnection.BeginTransaction();
      // Assign transaction object for a pending local transaction
      command.Connection = oracleConnection;
      command.Transaction = transaction;

      try
      {
        PeriodoSQL sql = new PeriodoSQL();
        command.CommandText = sql.deletePeriodo();
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

    public List<PeriodoModel> selectPeriodo(string nome,string situacao)
    {

      PeriodoSQL sql = new PeriodoSQL();


      OracleCommand command = new OracleCommand();
      command.Connection = oracleConnection;
      command.CommandText = sql.selectPeriodo();

      command.Parameters.Add("nome", nome);
      command.Parameters.Add("nome", nome);
      command.Parameters.Add("situacao", situacao);
      command.Parameters.Add("situacao", situacao);
      command.CommandType = System.Data.CommandType.Text;
      OracleDataReader reader = command.ExecuteReader();
      List<PeriodoModel> Periodo = new List<PeriodoModel>();

      try
      {
        while (reader.Read())
        {
          Periodo.Add(new PeriodoModel { codPeriodo = reader.GetInt32(0), nome = reader.GetString(1), situacao = reader.GetString(2), situacaoLabel = reader.GetString(2) == "1" ? "Ativo" : "Inativo" });
        }

        return Periodo;
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
    public void inserirPeriodo(PeriodoModel Periodo)
    {
      OracleCommand command = new OracleCommand();
      OracleTransaction transaction = oracleConnection.BeginTransaction();
      // Assign transaction object for a pending local transaction
      command.Connection = oracleConnection;
      command.Transaction = transaction;
      try
      {
        PeriodoSQL sql = new PeriodoSQL();
        command.CommandText = sql.inserirPeriodo();
        command.Parameters.Add("nome", Periodo.nome);
        command.Parameters.Add("situacao", "1");
        command.ExecuteNonQuery();
        transaction.Commit();
      }
      catch (Exception ex)
      {
        transaction.Rollback();

        throw ex;
      }
    }
    public void ativarPeriodo(int codigo)
    {
      OracleCommand command = new OracleCommand();
      OracleTransaction transaction = oracleConnection.BeginTransaction();
      // Assign transaction object for a pending local transaction
      command.Connection = oracleConnection;
      command.Transaction = transaction;
      try
      {
        PeriodoSQL sql = new PeriodoSQL();
        command.CommandText = sql.ativarPeriodo();
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
    public void desativarPeriodo(int codigo)
    {
      OracleCommand command = new OracleCommand();
      OracleTransaction transaction = oracleConnection.BeginTransaction();
      // Assign transaction object for a pending local transaction
      command.Connection = oracleConnection;
      command.Transaction = transaction;
      try
      {
        PeriodoSQL sql = new PeriodoSQL();
        command.CommandText = sql.desativarPeriodo();
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
    public void updatePeriodo(PeriodoModel Periodo)
    {
      OracleCommand command = new OracleCommand();
      OracleTransaction transaction = oracleConnection.BeginTransaction();
      // Assign transaction object for a pending local transaction
      command.Connection = oracleConnection;
      command.Transaction = transaction;
      try
      {
        PeriodoSQL sql = new PeriodoSQL();
        command.CommandText = sql.updatePeriodo();
        command.Parameters.Add("nome", Periodo.nome.Trim());
        command.Parameters.Add("codigo", Periodo.codPeriodo);
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
