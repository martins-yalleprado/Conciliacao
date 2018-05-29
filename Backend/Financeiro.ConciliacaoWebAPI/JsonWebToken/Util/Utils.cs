using System.Collections.Generic;
using System.Configuration;

namespace JsonWebToken.Util
{
  public class Utils
  {
    private static List<object> roles;

    public static string ORACLE_CONNECCAO = ConfigurationManager.ConnectionStrings["OracleConexao"].ConnectionString;

    #region properties

    public static string UserCodeLDAP { get; set; }

    public static List<object> RolesObject
    {
      get { return roles.Count == 0 ? new List<object>() : roles; }
      set { roles = value; }
    }

    #endregion

  }
}
