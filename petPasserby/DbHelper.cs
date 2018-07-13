using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using QQLite.Framework.Dapper;

namespace petPasserby
{
    public class DbHelper
    {
        private IDbConnection dbConn;
        private IDbCommand dbCommand;
        private IDataReader dataReader;

        private static bool bNeedToResetConnection = true;
        private static string connectionString = string.Empty;  //连接字符串

        #region 私有构造函数和方法
        private DbHelper() { }  //私有构造函数，该函数不使用实例

        
        #endregion 私有构造函数和方法结束
        /// <summary>
        /// 根据数据源、密码、版本号设置Sqlite连接字符串。
        /// </summary>
        /// <param name="datasource">数据源。</param>
        /// <param name="password">密码。</param>
        /// <param name="version">版本号（缺省为3）。</param>
        public static void setSqlLiteConnectionString(string dataSource, string password = "", int version = 3)
        {
            bNeedToResetConnection = true;
            connectionString = string.Format("Data Source={0};Version={1};password={2}", dataSource, version, password);
        }
    }
}
