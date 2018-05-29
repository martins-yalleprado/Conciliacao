using JsonWebToken.Model;
using JsonWebToken.Util;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JsonWebToken.Code.Unidade
{
  public class UnidadeDAL
  {


    public OracleConnection oracleConnection;
    public UnidadeDAL()
    {
      oracleConnection = new OracleConnection(Utils.ORACLE_CONNECCAO);
      oracleConnection.Open();
    }
    public List<UnidadeModel> SelectUnidade()
    {
      UnidadeSQL sql = new UnidadeSQL();


      OracleCommand command = new OracleCommand();
      command.Connection = oracleConnection;
      command.CommandText = sql.SelectUnidade();
      command.CommandType = System.Data.CommandType.Text;
      OracleDataReader reader = command.ExecuteReader();
      List<UnidadeModel> Unidade = new List<UnidadeModel>();

      try
      {

        while (reader.Read())
        {
          Unidade.Add(new UnidadeModel { codUnidade = reader.GetInt32(0), nomUnidade = reader.GetString(1), desUnidade = reader.GetString(2), situacao = reader.GetString(3), codFuncionario = reader.GetInt32(4), situacaoLabel = reader.GetString(3) == "1" ? "ativo" : "Inativo" });
        }


        return Unidade;
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
    public List<UnidadeModel> SelectUnidadePorId(int unidade)
    {
      UnidadeSQL sql = new UnidadeSQL();


      OracleCommand command = new OracleCommand();
      command.Connection = oracleConnection;
      command.CommandText = sql.SelectUnidadePorId();
      command.Parameters.Add("CODEMP", unidade);
      command.CommandType = System.Data.CommandType.Text;
      OracleDataReader reader = command.ExecuteReader();
      List<UnidadeModel> Unidade = new List<UnidadeModel>();

      try
      {

        while (reader.Read())
        {
          Unidade.Add(new UnidadeModel { codUnidade = reader.GetInt32(0), nomUnidade = reader.GetString(1), desUnidade = reader.GetString(2), situacao = reader.GetString(3), codFuncionario = reader.GetInt32(4), situacaoLabel = reader.GetString(3) == "1" ? "ativo" : "Inativo" });
        }


        return Unidade;
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

    public void AtivarUnidade(UnidadeModel Unidade)
    {
      OracleCommand command = new OracleCommand();
      command.Connection = oracleConnection;
      OracleTransaction transaction;
      UnidadeSQL sql = new UnidadeSQL();
      // Start a local transaction
      transaction = oracleConnection.BeginTransaction();
      // Assign transaction object for a pending local transaction
      command.Transaction = transaction;

      try
      {
        command.CommandText = sql.AtivarUnidade();
        command.Parameters.Clear();
        command.ExecuteNonQuery();
        transaction.Commit();
      }
      catch (Exception ex)
      {
        transaction.Rollback();
        if (oracleConnection != null)
          oracleConnection.Close();
        throw ex;
      }
    }

    public void InativarUnidade(UnidadeModel Unidade)
    {
      OracleCommand command = new OracleCommand();
      command.Connection = oracleConnection;
      OracleTransaction transaction;
      UnidadeSQL sql = new UnidadeSQL();
      // Start a local transaction
      transaction = oracleConnection.BeginTransaction();
      // Assign transaction object for a pending local transaction
      command.Transaction = transaction;

      try
      {
        command.CommandText = sql.InativarUnidade();
        command.Parameters.Clear();
        command.ExecuteNonQuery();
        transaction.Commit();
      }
      catch (Exception ex)
      {
        transaction.Rollback();
        if (oracleConnection != null)
          oracleConnection.Close();
        throw ex;
      }
    }

    public void InsertUnidade(UnidadeModel Unidade)
    {

      OracleCommand command = new OracleCommand();
      command.Connection = oracleConnection;
      OracleTransaction transaction;
      UnidadeSQL sql = new UnidadeSQL();
      // Start a local transaction
      transaction = oracleConnection.BeginTransaction();
      // Assign transaction object for a pending local transaction
      command.Transaction = transaction;

      try
      {
        command.CommandText = sql.InsertUnidade();
        command.Parameters.Clear();
        command.ExecuteNonQuery();
        transaction.Commit();
      }
      catch (Exception ex)
      {
        transaction.Rollback();
        if (oracleConnection != null)
          oracleConnection.Close();
        throw ex;
      }
    }
  }
}
