using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
namespace Live5.Xps.Framework.Utils
{
    public sealed class SqlDbTool
    {
        private static Database db;
        static SqlDbTool()
        {
            db = DatabaseFactory.CreateDatabase();
        }
        public static IDataReader ExecuteQuery(string spName,params object[] spParams){
            //Database db = DatabaseFactory.CreateDatabase();
            DbCommand cmd = db.GetStoredProcCommand(spName, spParams);
           return db.ExecuteReader(cmd);
        }
        public static int ExecuteNonQuery(string spName, params object[] spParams)
        {
            //Database db = DatabaseFactory.CreateDatabase();
            DbCommand cmd = db.GetStoredProcCommand(spName, spParams);
            return db.ExecuteNonQuery(cmd);
        }
       
    }
}
