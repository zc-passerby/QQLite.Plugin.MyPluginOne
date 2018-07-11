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
        private DbBase dbBase;
        private IDbConnection dbConn;
        private IDbCommand dbCommand;
        private IDataReader dataReader;

        public DbHelper(string connectionString)
        {
            dbBase = new DbBase(connectionString);
            dbConn = dbBase.Conn;
        }

        public void CloseConnection()
        {
            if (dbCommand != null)
                dbCommand.Cancel();
            dbCommand = null;
            if (dataReader != null)
                dataReader.Close();
            dataReader = null;
            if (dbConn != null)
                dbConn.Close();
            dbConn = null;
        }

        public IDataReader ExecuteQuery(string queryString)
        {
            dbCommand = dbConn.CreateCommand();
            dbCommand.CommandText = queryString;
            dataReader = dbCommand.ExecuteReader();

            return dataReader;
        }
    }
}
