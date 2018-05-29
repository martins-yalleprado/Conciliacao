using JsonWebToken.Model;
using System;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
using JsonWebToken.Util;

namespace JsonWebToken.Code.GestaoCarga
{
  public class GestaoCargaDAL
  {

    public OracleConnection oracleConnection;
    public GestaoCargaDAL()
    {
      oracleConnection = new OracleConnection(Utils.ORACLE_CONNECCAO);
      oracleConnection.Open();
    }


    public GestaoCargaModel selectGestaoCargaPorId(int id)
    {

      GestaoCargaSQL sql = new GestaoCargaSQL();


      OracleCommand command = new OracleCommand();
      command.Connection = oracleConnection;
      command.CommandText = sql.selectGestaoCargaPorId();

      command.Parameters.Add("codigo", id);
      command.CommandType = System.Data.CommandType.Text;
      OracleDataReader reader = command.ExecuteReader();
      GestaoCargaModel gestaoCarga = null;

      try
      {
        if (reader.Read())
        {
          gestaoCarga = new GestaoCargaModel { codGestaoCarga = reader.GetInt32(0), data = reader.GetDateTime(1), dataMovimentacao = reader.GetDateTime(2), tipo = reader.GetString(3), versao = reader.GetInt32(4), versaoOficial = reader.GetString(5), valor = reader.GetFloat(6), versaoOficialLabel = reader.GetString(5) == "1" ? "Sim" : "Não" };
        }


        return gestaoCarga;
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
    public void deleteGestaoCarga(int id)
    {

      OracleCommand command = new OracleCommand();
      OracleTransaction transaction = oracleConnection.BeginTransaction();
      // Assign transaction object for a pending local transaction
      command.Connection = oracleConnection;
      command.Transaction = transaction;
      try
      {
        GestaoCargaSQL sql = new GestaoCargaSQL();
        command.CommandText = sql.deleteGestaoCargaCtb();
        command.Parameters.Add("codigo", id);

        LogUtil.Execute(new Dictionary<string, object>(), "MOVCTBCLOSYSCOB", command); // antes = delete

        command.ExecuteNonQuery();
        command.CommandText = sql.deleteGestaoCargaTit();
        command.ExecuteNonQuery();
        command.CommandText = sql.deleteGestaoCargaAgn();
        command.ExecuteNonQuery();
        command.CommandText = sql.deleteGestaoCarga();
        command.ExecuteNonQuery();
        transaction.Commit();
      }
      catch (Exception ex)
      {
        transaction.Rollback();

        throw ex;
      }
    }

    public List<GestaoCargaModel> selectGestaoCarga(DateTime dataRef, String tipo)
    {
      GestaoCargaSQL sql = new GestaoCargaSQL();


      OracleCommand command = new OracleCommand();
      command.Connection = oracleConnection;
      command.CommandText = sql.selectGestaoCarga();

      command.Parameters.Add("dataref", dataRef.ToString("yyyy-MM-dd"));
      command.Parameters.Add("tipo", tipo.Trim().ToUpper());
      command.CommandType = System.Data.CommandType.Text;
      OracleDataReader reader = command.ExecuteReader();
      List<GestaoCargaModel> gestaoCarga = new List<GestaoCargaModel>();

      try
      {

        while (reader.Read())
        {
          gestaoCarga.Add(new GestaoCargaModel { codGestaoCarga = reader.GetInt32(0), data = reader.GetDateTime(1), dataMovimentacao = reader.GetDateTime(2), tipo = reader.GetString(3), versao = reader.GetInt32(4), versaoOficial = reader.GetString(5), valor = reader.GetFloat(6), versaoOficialLabel = reader.GetString(5) == "1" ? "Sim" : "Não" });
        }


        return gestaoCarga;
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

    private void updateGestaoCarga(GestaoCargaModel gestaoCargaModel, OracleCommand command)

    {
      GestaoCargaSQL sql = new GestaoCargaSQL();

      command.CommandText = sql.updateGestaoCargaVersaoOficialAtivar();
      command.Parameters.Clear();
      command.Parameters.Add("codigoUpdate", gestaoCargaModel.codGestaoCarga);

      command.ExecuteNonQuery();
      command.CommandText = sql.updateGestaoCargaVersaoOficialInativar();
      command.Parameters.Add("datarefUpdate", gestaoCargaModel.data.ToString("yyyy-MM-dd"));
      command.Parameters.Add("tipoUpdate", gestaoCargaModel.tipo);

      var dic = new Dictionary<string, object>();
      dic.Add("IDTVRSRGTATV", 88);

      LogUtil.Execute(dic, "RLCRGTMOVCLO", command); // antes = update

      command.ExecuteNonQuery();

    }

    public void insertGestaoCarga(DateTime dataRef)
    {

      inserirLoteTitulo();
      inserirLoteContabil();
      inserirLoteAging();

    }
    public int proximoCodigoGestaoCarga(OracleCommand command)
    {
      GestaoCargaSQL sql = new GestaoCargaSQL();
      command.CommandText = sql.proximoCodigoGestaoCarga();
      command.CommandType = System.Data.CommandType.Text;
      OracleDataReader reader = command.ExecuteReader();
      int codGestaoCarga = 0;
      if (reader.Read())
      {
        codGestaoCarga = reader.GetInt32(0);
      }
      return codGestaoCarga;
    }
    private void inserirLoteAging()
    {
      OracleCommand command = new OracleCommand();
      command.Connection = oracleConnection;
      OracleTransaction transaction;

      // Start a local transaction
      transaction = oracleConnection.BeginTransaction();
      // Assign transaction object for a pending local transaction
      command.Transaction = transaction;

      try
      {

        GestaoCargaSQL sql = new GestaoCargaSQL();

        GestaoCargaModel gestaoCargaModel = gerarGestaoCargaModel("AGN", command);


        command.CommandText = sql.insertLoteAging();
        command.CommandType = System.Data.CommandType.Text;
        command.Parameters.Clear();
        command.Parameters.Add("Codigo", gestaoCargaModel.codGestaoCarga);
        command.Parameters.Add("datamov", gestaoCargaModel.data);
        command.ExecuteNonQuery();
        transaction.Commit();
      }
      catch (Exception ex)
      {
        transaction.Rollback();

        throw ex;
      }
    }
    public GestaoCargaModel gerarGestaoCargaModel(string tipo, OracleCommand command)
    {

      GestaoCargaModel gestaoCargaModel = new GestaoCargaModel();
      gestaoCargaModel.codGestaoCarga = proximoCodigoGestaoCarga(command);
      gestaoCargaModel.tipo = tipo;
      gestaoCargaModel.data = DateTime.Now;
      gestaoCargaModel.dataMovimentacao = DateTime.Now;

      gestaoCargaModel.versao = selectMaxVersao(gestaoCargaModel.data, gestaoCargaModel.tipo, command);
      GestaoCargaSQL sql = new GestaoCargaSQL();
      command.CommandText = sql.insertGestaoCarga();
      command.Parameters.Clear();
      command.Parameters.Add("codigo", gestaoCargaModel.codGestaoCarga);
      command.Parameters.Add("datamov", gestaoCargaModel.dataMovimentacao);
      command.Parameters.Add("tipo", gestaoCargaModel.tipo);
      command.Parameters.Add("versao", gestaoCargaModel.versao);
      command.ExecuteNonQuery();
      updateGestaoCarga(gestaoCargaModel, command);
      return gestaoCargaModel;
    }

    private int selectMaxVersao(DateTime data, string tipo, OracleCommand command)
    {

      GestaoCargaSQL sql = new GestaoCargaSQL();
      command.CommandText = sql.selectMaxVersion();
      command.CommandType = System.Data.CommandType.Text;
      command.Parameters.Add("dataRefVer", data.ToString("yyyy-MM-dd"));
      command.Parameters.Add("tipoVer", tipo);
      OracleDataReader reader = command.ExecuteReader();
      int versao = 0;
      if (reader.Read())
      {
        versao = reader.GetInt32(0);
      }
      return versao;
    }

    private void inserirLoteContabil()
    {

      OracleTransaction transaction;

      // Start a local transaction
      transaction = oracleConnection.BeginTransaction();
      // Assign transaction object for a pending local transaction
      OracleCommand command = new OracleCommand();
      command.Connection = oracleConnection;
      command.Transaction = transaction;

      try
      {
        GestaoCargaSQL sql = new GestaoCargaSQL();
        GestaoCargaModel gestaoCargaModel = gerarGestaoCargaModel("CTB", command);

        command.CommandText = sql.insertLoteContabil();
        command.CommandType = System.Data.CommandType.Text;
        command.Parameters.Clear();
        command.Parameters.Add("Codigo", gestaoCargaModel.codGestaoCarga);
        command.Parameters.Add("datamov", gestaoCargaModel.data);
        command.ExecuteNonQuery();
        transaction.Commit();
      }
      catch (Exception ex)
      {
        transaction.Rollback();

        throw ex;
      }
    }

    private void inserirLoteTitulo()
    {


      OracleTransaction transaction;

      // Start a local transaction
      transaction = oracleConnection.BeginTransaction();
      // Assign transaction object for a pending local transaction
      OracleCommand command = new OracleCommand();
      command.Connection = oracleConnection;
      command.Transaction = transaction;

      try
      {
        GestaoCargaSQL sql = new GestaoCargaSQL();

        GestaoCargaModel gestaoCargaModel = gerarGestaoCargaModel("TIT", command);

        command.CommandText = sql.insertLoteTitulo();
        command.CommandType = System.Data.CommandType.Text;
        command.Parameters.Clear();
        command.Parameters.Add("Codigo", gestaoCargaModel.codGestaoCarga);
        command.Parameters.Add("datamov", gestaoCargaModel.data);
        command.ExecuteNonQuery();

        LogUtil.Execute(new Dictionary<string, object>(), "MOVTITCLOSYSCOB", command, "where NUMSEQCRGTAB = :Codigo"); // depois = insert

        transaction.Commit();
      }
      catch (Exception ex)
      {
        transaction.Rollback();

        throw ex;
      }
    }
    public void atualizarVersao(GestaoCargaModel gestaoCargaModel)
    {
      OracleCommand command = new OracleCommand();
      command.Connection = oracleConnection;
      OracleTransaction transaction;

      // Start a local transaction
      transaction = oracleConnection.BeginTransaction();
      // Assign transaction object for a pending local transaction
      command.Transaction = transaction;

      try
      {
        updateGestaoCarga(gestaoCargaModel, command);
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
