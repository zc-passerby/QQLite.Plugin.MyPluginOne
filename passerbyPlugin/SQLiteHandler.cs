using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PasserbyPluginNS
{
    public class SQLiteHandler
    {
        public static string getClusterIsEnabled(string GroupId)
        {
            string retStr = null;
            string SelectSql = "select IsEnabled from GroupConfig where GroupId='{0}';";
            SelectSql = string.Format(SelectSql, GroupId);
            object isEnabled = SQLiteHelper.GetSingle(SelectSql);
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
            if (SQLiteHelper.ExecuteSql(updateSql) == 1)
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
            if(SQLiteHelper.ExecuteSql(insertSql) == 1)
            {
                bRet = true;
            }
            return bRet;
        }

        public static DataSet getPokemonInfoBySn(string pokemonId)
        {
            string sqlString = "select * from PokemonBaseInfo where Sn='" + pokemonId + "';";
            DataSet ds = SQLiteHelper.Query(sqlString);
            return ds;
        }

        public static DataSet getPokemonInfoByName(string pokemonName)
        {
            string sqlString = string.Format("select * from PokemonBaseInfo where NameZh='{0}' or NameZh like '{1}【%';", pokemonName, pokemonName);
            DataSet ds = SQLiteHelper.Query(sqlString);
            return ds;
        }
    }
}
