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
        //private static DbBase dbBase = null;

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
        public static void setSqlLiteConnection(string dataSource, string password = "", int version = 3)
        {
            //bNeedToResetConnection = true;
            connectionString = string.Format("Data Source={0};Version={1};password={2}", dataSource, version, password);
            //dbBase = new DbBase(connectionString);
        }

        public static string getConnectionStr()
        {
            return connectionString;
        }

        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public static void closeConnection()
        {
            //if(dbBase != null)
            //{
            //    dbBase.Dispose();
            //    connectionString = string.Empty;
            //    dbBase = null;
            //}
        }

        /// <summary>
        /// 准备操作命令参数
        /// </summary>
        /// <param name="dbConn">SqlConnection</param>
        /// <param name="dbCommand">SqlCommand</param>
        /// <param name="cmdText">Sql命令文本</param>
        /// <param name="parameters">执行Sql语句需要的参数-暂时不用</param>
        private static void PrepareCommand(IDbConnection dbConn, IDbCommand dbCommand, string cmdText)//, params IDbDataParameter[] parameters)
        {
            if(dbConn.State != ConnectionState.Open)
                dbConn.Open();
            dbCommand.Parameters.Clear();
            dbCommand.CommandText = cmdText;
            dbCommand.CommandType = CommandType.Text;
            dbCommand.CommandTimeout = 30;
            //if(parameters.Length >= 0)
            //{
            //    dbCommand.Parameters.Add(parameters);
            //}
        }

        /// <summary>
        /// 对SQLite数据库执行增删改操作，返回受影响的行数。
        /// </summary>
        /// <param name="sql">要执行的增删改的SQL语句。</param>
        /// <param name="parameters">执行增删改语句所需要的参数，参数必须以它们在SQL语句中的顺序为准。--暂时不用</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static int ExecuteNonQuery(string sql)//, params IDbDataParameter[] parameters)
        {
            int affectedRows = 0;
            using (IDbConnection dbConn = new DbBase(connectionString).Conn)
            {
                using (IDbCommand dbCommand = dbConn.CreateCommand())
                {
                    try
                    {
                        PrepareCommand(dbConn, dbCommand, sql);
                        affectedRows = dbCommand.ExecuteNonQuery();
                    }
                    catch (Exception) { throw; }
                }
            }
            return affectedRows;
        }

        /// <summary>
        /// 批量处理数据操作语句。
        /// </summary>
        /// <param name="list">SQL语句集合。</param>
        /// <exception cref="Exception"></exception>
        public static void ExecuteNonQueryBatch(List<string> list)//List<KeyValuePair<string, IDbDataParameter[]>> list)
        {
            using (IDbConnection dbConn = new DbBase(connectionString).Conn)
            {
                if (dbConn.State != ConnectionState.Open)
                    dbConn.Open();
                using (IDbCommand dbCommand = dbConn.CreateCommand())
                {
                    dbCommand.Parameters.Clear();
                    using (IDbTransaction Tran = dbConn.BeginTransaction())
                    {
                        try
                        {
                            foreach (var item in list)
                            {
                                dbCommand.CommandText = item;
                                //dbCommand.CommandText = item.Key;
                                //if (item.Value != null)
                                //    dbCommand.Parameters.Add(item.Value);
                                dbCommand.ExecuteNonQuery();
                            }
                            Tran.Commit();
                        }
                        catch (Exception) { Tran.Rollback(); throw; }
                    }
                }
            }
        }

        /// <summary>
        /// 执行查询语句，并返回第一个结果。
        /// </summary>
        /// <param name="sql">查询语句。</param>
        /// <returns>查询结果。</returns>
        /// <exception cref="Exception"></exception>
        public static object ExecuteScalar(string sql)//, params IDbDataParameter[] parameters)
        {
            object result = new object();
            using (IDbConnection dbConn = new DbBase(connectionString).Conn)
            {
                using (IDbCommand dbCommand = dbConn.CreateCommand())
                {
                    try
                    {
                        PrepareCommand(dbConn, dbCommand, sql);//, parameters);
                        result = dbCommand.ExecuteScalar();
                        return result;
                    }
                    catch(Exception) { throw; }
                }
            }
        }

        /// <summary> 
        /// 执行一个查询语句，返回一个包含查询结果的DataTable。 
        /// </summary> 
        /// <param name="sql">要执行的查询语句。</param> 
        /// <param name="parameters">执行SQL查询语句所需要的参数，参数必须以它们在SQL语句中的顺序为准。</param> 
        /// <returns></returns> 
        /// <exception cref="Exception"></exception>
        public static DataTable ExecuteQuery(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                IDataReader dbReader = ExecuteReader(sql);
                dt.Load(dbReader);
                return dt;
            }
            catch (Exception) { throw; }
        }

        /// <summary> 
        /// 执行一个查询语句，返回一个关联的DataBase的DataReader实例。 
        /// </summary> 
        /// <param name="sql">要执行的查询语句。</param> 
        /// <param name="parameters">执行SQL查询语句所需要的参数，参数必须以它们在SQL语句中的顺序为准。</param> 
        /// <returns></returns> 
        /// <exception cref="Exception"></exception>
        public static IDataReader ExecuteReader(string sql)//, params IDbDataParameter[] parameters)
        {
            //using (IDbConnection dbConn = new DbBase(connectionString).Conn)
            //{
            //    using (IDbCommand dbCommand = dbConn.CreateCommand())
            //    {
            //      try
            //        {
            //            PrepareCommand(dbConn, dbCommand, sql);//, parameters);
            //            return dbCommand.ExecuteReader();
            //        }
            //        catch(Exception) { throw; }
            //    }
            //}
            IDbConnection dbConn = new DbBase(connectionString).Conn;
            IDbCommand dbCommand = dbConn.CreateCommand();
            try
            {
                PrepareCommand(dbConn, dbCommand, sql);//, parameters);
                return dbCommand.ExecuteReader();
            }
            catch (Exception) { throw; }
        }
    }
}
