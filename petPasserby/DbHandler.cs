using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace petPasserby
{
    public class DbHandler
    {
        public static string getClusterIsEnabled(string clusterId)
        {
            string SelectSql = "select IsEnabled from GroupConfig where GroupId='{0}';";
            SelectSql = string.Format(SelectSql, clusterId);
            object isEnabled = DbHelper.ExecuteScalar(SelectSql);
            if(isEnabled != null)
            {
                return isEnabled.ToString();
            }
            else
            {
                return "-1";
            }

        }
    }
}
