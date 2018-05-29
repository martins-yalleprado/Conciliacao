using JsonWebToken.Code.Log;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Runtime.InteropServices;

namespace JsonWebToken.Util
{
  public static class LogUtil
  {
    private static List<string> _captions = new List<string>();

    private static List<string> Captions
    {
      get { return _captions; }
      set { _captions = value; }
    }

    private static string GeraConsulta(string param, string table, string clause)
    {
      return string.Format(" select {0} from {1} {2}", param, table, clause);
    }

    private static List<object> ListaAlteracoes(OracleCommand command, string select)
    {
      var lst = new List<object>();

      try
      {
        command.CommandText = select;

        DataTable dt = new DataTable();
        dt.Load(command.ExecuteReader());

        // CAPTION

        var captions = new List<string>();

        foreach (DataColumn column in dt.Columns)
          captions.Add(column.ColumnName);

        Captions = captions;

        // VALUES      

        foreach (DataRow row in dt.Rows)
        {
          var dict = new Dictionary<string, object>();

          foreach (string caption in captions)
            dict.Add(caption, row[caption]);

          lst.Add(dict);
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }

      return lst;
    }

    private static string FormataValores(List<object> lstObj)
    {
      List<string> tmp = new List<string>();

      foreach (Dictionary<string, object> dic in lstObj)
      {
        var tmp2 = new List<string>();

        foreach (var item in dic)
          tmp2.Add(string.Format("{0} = {1}", item.Key, item.Value));

        tmp.Add(string.Join(" , ", tmp2));
      }

      return string.Join(" | ", tmp);
    }

    public static void Execute(Dictionary<string, object> param, string table, OracleCommand command, [Optional] string where)
    {
      var comando = (OracleCommand)command.Clone();

      if (!string.IsNullOrEmpty(where))
      {
        for (int i = (command.Parameters.Count - 1); i >= 0; i--)
        {
          if (!where.ToLower().Contains(command.Parameters[i].ParameterName.ToLower()))
            comando.Parameters.RemoveAt(i);
        }
      }

      try
      {
        string op = string.Empty;
        DataTable dt = new DataTable();

        if (comando.CommandText.IndexOf("insert") != -1) op = "insert";
        if (comando.CommandText.IndexOf("update") != -1) op = "update";
        if (comando.CommandText.IndexOf("delete") != -1) op = "delete";

        var clause = comando.CommandText.Substring(comando.CommandText.ToLower().IndexOf("where"));

        if (!string.IsNullOrEmpty(where))
          clause = where;

        List<string> lst = null;

        // ANTES

        var values = "*";

        var select = GeraConsulta(values, table, clause);

        var lstObjAntes = ListaAlteracoes(comando, select);

        // DEPOIS

        lst = new List<string>();

        foreach (var caption in Captions)
          foreach (var item in param)
            lst.Add(caption.ToLower().Equals(item.Key.ToLower()) ? string.Format("{0} as {1}", item.Value, item.Key) : caption);

        values = lst.Count > 0 ? string.Join(",", lst) : "*";

        select = GeraConsulta(values, table, clause);

        var lstObjDepois = ListaAlteracoes(comando, select);

        // LOG

        var vlStatement = new object();

        if (op.Equals("insert"))
        {
          vlStatement = new
          {
            items = new object[]
            {
            new { name = "operacao", values =  op }
            ,
            new { name = "depois", values = FormataValores(lstObjDepois) }
            ,
            new { name = "comando", values = comando }
            }
          };
        }
        else if (op.Equals("update"))
        {
          vlStatement = new
          {
            items = new object[]
            {
            new { name = "operacao", values =  op }
            ,
            new { name = "antes", values = FormataValores(lstObjAntes) }
            ,
            new { name = "depois", values = FormataValores(lstObjDepois) }
            ,
            new { name = "comando", values = comando }
            }
          };
        }
        else if (op.Equals("delete"))
        {
          vlStatement = new
          {
            items = new object[]
            {
            new { name = "operacao", values =  op }
            ,
            new { name = "antes", values = FormataValores(lstObjAntes) }
            ,
            new { name = "comando", values = comando }
            }
          };
        }

        string vlStatementJson = JsonConvert.SerializeObject(vlStatement);

        (new LogBLL()).InsertLogOperacao(Utils.UserCodeLDAP, vlStatementJson);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
  }
}
