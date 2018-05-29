using JsonWebToken.Model;
using JsonWebToken.Util;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;

namespace JsonWebToken.Code.UnidadeConta
{
  public class UnidadeContaDAL
  {

    public OracleConnection oracleConnection;
    public UnidadeContaDAL()
    {
      oracleConnection = new OracleConnection(Utils.ORACLE_CONNECCAO);
      oracleConnection.Open();
    }
    public List<UnidadeContaModel> SelectUnidadeConta()
    {
      UnidadeContaSQL sql = new UnidadeContaSQL();


      OracleCommand command = new OracleCommand();
      command.Connection = oracleConnection;
      command.CommandText = sql.SelectUnidadeConta();
      command.CommandType = System.Data.CommandType.Text;
      OracleDataReader reader = command.ExecuteReader();
      List<UnidadeContaModel> UnidadeConta = new List<UnidadeContaModel>();

      try
      {

        while (reader.Read())
        {
          UnidadeConta.Add(new UnidadeContaModel { codUnidadeConta = reader.GetInt32(0), codConta = reader.GetInt32(1), codUnidade = reader.GetInt32(2), situacao = reader.GetString(3), codFuncionario = reader.GetInt32(4), situacaoLabel = reader.GetString(3) == "1" ? "ativo" : "Inativo" });
        }


        return UnidadeConta;
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

    public void AtivarUnidadeConta(UnidadeContaModel unidadeConta)
    {
      OracleCommand command = new OracleCommand();
      command.Connection = oracleConnection;
      OracleTransaction transaction;
      UnidadeContaSQL sql = new UnidadeContaSQL();
      // Start a local transaction
      transaction = oracleConnection.BeginTransaction();
      // Assign transaction object for a pending local transaction
      command.Transaction = transaction;

      try
      {
        command.CommandText = sql.AtivarUnidadeConta();
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

    public void InativarUnidadeConta(UnidadeContaModel unidadeConta)
    {
      OracleCommand command = new OracleCommand();
      command.Connection = oracleConnection;
      OracleTransaction transaction;
      UnidadeContaSQL sql = new UnidadeContaSQL();
      // Start a local transaction
      transaction = oracleConnection.BeginTransaction();
      // Assign transaction object for a pending local transaction
      command.Transaction = transaction;

      try
      {
        command.CommandText = sql.InativarUnidadeConta();
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

    public void InsertUnidadeConta(UnidadeContaModel unidadeConta)
    {

      OracleCommand command = new OracleCommand();
      command.Connection = oracleConnection;
      OracleTransaction transaction;
      UnidadeContaSQL sql = new UnidadeContaSQL();
      // Start a local transaction
      transaction = oracleConnection.BeginTransaction();
      // Assign transaction object for a pending local transaction
      command.Transaction = transaction;

      try
      {
        command.CommandText = sql.InsertUnidadeConta();
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
