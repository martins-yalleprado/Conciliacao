using JsonWebToken.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using JsonWebToken.Util;

namespace JsonWebToken.Code.Permissao
{
  public class PermissaoDAL
  {
    public List<PermissaoModel> SelectPermissao(List<string> lstNomGrpAcs)
    {
      var permissoes = new List<PermissaoModel>();
      var lstUpdNomGrpAcs = new List<string>();

      foreach (var item in lstNomGrpAcs)
      {
        lstUpdNomGrpAcs.Add(string.Format("'{0}'", item));
      }

      var strNomGrpAcs = string.Join(",", lstUpdNomGrpAcs);

      if (lstNomGrpAcs.Count == 0 || string.IsNullOrEmpty(strNomGrpAcs))
        return permissoes;

      DbCommand databaseCommand = null;
      OracleCommand command = null;

      try
      {
        PermissaoSQL sqlCmd = new PermissaoSQL();

        command = new OracleCommand(sqlCmd.SelectPermissao(strNomGrpAcs), new OracleConnection(Utils.ORACLE_CONNECCAO));

        command.Connection.Open();

        DataTable dt = new DataTable();
        dt.Load(command.ExecuteReader());

        foreach (DataRow row in dt.Rows)
        {
          permissoes.Add(new PermissaoModel
          {
            CODACSFUN = row.Field<long>("CODACSFUN"),
            NOMACSFUN = row.Field<String>("NOMACSFUN")
          });
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
      finally
      {
        if (command != null && command.Connection.State == ConnectionState.Open)
          command.Connection.Close();

        if (databaseCommand != null && databaseCommand.Connection != null && databaseCommand.Connection.State == ConnectionState.Open)
          databaseCommand.Connection.Close();
      }

      return permissoes;
    }
  }
}
