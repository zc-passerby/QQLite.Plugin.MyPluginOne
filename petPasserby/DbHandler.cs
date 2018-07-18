using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace petPasserby
{
    public class DbHandler
    {
        public static string getClusterIsEnabled(string GroupId)
        {
            string retStr = null;
            string SelectSql = "select IsEnabled from GroupConfig where GroupId='{0}';";
            SelectSql = string.Format(SelectSql, GroupId);
            object isEnabled = DbHelper.ExecuteScalar(SelectSql);
            if(isEnabled != null)
            {
                retStr = isEnabled.ToString();
            }
            return retStr;
        }

        public static bool setClusterIsEnabled(string GroupId, int isEnabled)
        {
            bool bRet = false;
            string updateSql = "update GroupConfig set IsEnabled={0} where GroupId='{1}';";
            updateSql = string.Format(updateSql, isEnabled, GroupId);
            if (DbHelper.ExecuteNonQuery(updateSql) == 1)
            {
                bRet = true;
            }
            return bRet;
        }

        public static bool addNewGroupInfo(string GroupId, int isEnabled)
        {
            bool bRet = false;
            string insertSql = "insert into GroupConfig (GroupId,IsEnabled) values('{0}',{1});";
            insertSql = string.Format(insertSql, GroupId, isEnabled);
            if(DbHelper.ExecuteNonQuery(insertSql) == 1)
            {
                bRet = true;
            }
            return bRet;
        }
    }
}
