using JsonWebToken.Model;
using JsonWebToken.Util;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JsonWebToken.Code.Conta
{
  public class ContaDAL
  {

    public OracleConnection oracleConnection;
    public ContaDAL()
    {
      oracleConnection = new OracleConnection(Utils.ORACLE_CONNECCAO);
      oracleConnection.Open();
    }
    public List<ContaModel> SelectConta()
    {
      ContaSQL sql = new ContaSQL();


      OracleCommand command = new OracleCommand();
      command.Connection = oracleConnection;
      command.CommandText = sql.SelectConta();
      command.CommandType = System.Data.CommandType.Text;
      OracleDataReader reader = command.ExecuteReader();
      List<ContaModel> Conta = new List<ContaModel>();

      try
      {

        while (reader.Read())
        {
          Conta.Add(new ContaModel { codConta = reader.GetInt32(0), nomConta = reader.GetString(1), desConta = reader.GetString(2), situacao = reader.GetString(3), codFuncionario = reader.GetInt32(4), situacaoLabel = reader.GetString(3) == "1" ? "ativo" : "Inativo" });
        }


        return Conta;
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

    public void AtivarConta(ContaModel Conta)
    {
      OracleCommand command = new OracleCommand();
      command.Connection = oracleConnection;
      OracleTransaction transaction;
      ContaSQL sql = new ContaSQL();
      // Start a local transaction
      transaction = oracleConnection.BeginTransaction();
      // Assign transaction object for a pending local transaction
      command.Transaction = transaction;

      try
      {
        command.CommandText = sql.AtivarConta();
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

    public void InativarConta(ContaModel Conta)
    {
      OracleCommand command = new OracleCommand();
      command.Connection = oracleConnection;
      OracleTransaction transaction;
      ContaSQL sql = new ContaSQL();
      // Start a local transaction
      transaction = oracleConnection.BeginTransaction();
      // Assign transaction object for a pending local transaction
      command.Transaction = transaction;

      try
      {
        command.CommandText = sql.InativarConta();
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

    public void InsertConta(ContaModel Conta)
    {

      OracleCommand command = new OracleCommand();
      command.Connection = oracleConnection;
      OracleTransaction transaction;
      ContaSQL sql = new ContaSQL();
      // Start a local transaction
      transaction = oracleConnection.BeginTransaction();
      // Assign transaction object for a pending local transaction
      command.Transaction = transaction;

      try
      {
        command.CommandText = sql.InsertConta();
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
