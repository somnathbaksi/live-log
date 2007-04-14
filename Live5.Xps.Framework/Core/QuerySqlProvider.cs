using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Xml;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Live5.Xps.Framework.Utils;
using System.Data;
using Live5.Xps.Framework.External;
using System.IO;
using Live5.Xps.Framework.BuiltIn;
namespace Live5.Xps.Framework.Core
{
    public class QuerySqlProvider
    {
        #region IQueryProvider Members

        public void SaveQuery(IQuery query)
        {
            Database db = DatabaseFactory.CreateDatabase();
            XmlDocument xmlDoc = XmlTool.ObjectToXml(query);
            string xmlStr = xmlDoc.InnerXml;
            DbCommand cmd = db.GetStoredProcCommand(Constants.Sp_InsertQuery, query.Id, query.ServiceType, xmlStr);
            db.ExecuteNonQuery(cmd);
        }
        public void SaveTempQuery(IQuery query)
        {
            Database db = DatabaseFactory.CreateDatabase();
            XmlDocument xmlDoc = XmlTool.ObjectToXml(query);
            string xmlStr = xmlDoc.InnerXml;
            DbCommand cmd = db.GetStoredProcCommand(Constants.Sp_SaveTempQuery, query.Id, query.ServiceType, xmlStr);
            db.ExecuteNonQuery(cmd);
        }
        //public IQuery GetQuery<T>(Guid queryId)
        //{
        //    Database db = DatabaseFactory.CreateDatabase();
        //    DbCommand cmd = db.GetStoredProcCommand(Constants.Sp_SelectQuery, queryId);
        //    IDataReader dr = db.ExecuteReader(cmd);
        //    dr.Read();
        //    XmlDocument doc = new XmlDocument();
        //    doc.LoadXml(dr.GetString(2));
        //    IQuery q = XmlTool.XmlToObject<T>(doc) as IQuery;

        //    return q;
        //}

        #endregion
        public static IList<IQuery> GetAllQuery()
        {
            IList<IQuery> queries = new List<IQuery>();
            IDataReader dr = SqlDbTool.ExecuteQuery("sp_SelectAllQuery");
            while (dr.Read())
            {
                string tStr = null;
                IQuery q = new Query(dr);
                string content = null;
                //tStr = q.ServiceType;
                IService service = ServiceFactory.Instance.GetService(q.ServiceType);

                switch (q.ServiceType)
                {
                    case Constants.BuiltInServiceType:
                        tStr = "Live5.Xps.Framework.BuiltIn.BuiltInQuery";
                        break;
                    case Constants.ExternalServiceType:
                        tStr = "Live5.Xps.Framework.External.ExternalQuery";
                        break;
                    default:
                        tStr = q.ServiceType;
                        break;
                }

                // Todo:Bug: Cannot get type which need dynamic load in.
                Type t = Type.GetType(tStr);
                XmlDocument doc = new XmlDocument();
                int fieldIndex = dr.GetOrdinal("QueryContent");
                if (!dr.IsDBNull(fieldIndex))
                {
                    content = dr.GetString(fieldIndex);
                }
                doc.LoadXml(content);
                q = XmlTool.XmlToObject(service.QueryType, doc) as IQuery;
                queries.Add(q);
            }
            return queries;
        }

        /// <summary>
        /// Get Query from query provider.
        /// </summary>
        /// <param name="queryId">Query Id.</param>
        /// <returns>Query found by Id, if query not found, return null.</returns>
        public static IQuery GetQuery(Guid queryId)
        {
            string content = null;
            IDataReader dr = SqlDbTool.ExecuteQuery(Constants.Sp_SelectQuery, queryId);
            if (!dr.Read())
            {
                return null;
            }
            IQuery q = new Query(dr);
            IService s = ServiceFactory.Instance.GetService(q.ServiceType);

            XmlDocument doc = new XmlDocument();
            int fieldIndex = dr.GetOrdinal("QueryContent");
            if (!dr.IsDBNull(fieldIndex))
            {
                content = dr.GetString(fieldIndex);
            }
            doc.LoadXml(content);
            q = XmlTool.XmlToObject(s.QueryType, doc) as IQuery;
            return q;
        }
        public static IQuery GetDefaultQuery()
        {
            BuiltInQuery q = new BuiltInQuery();
            q.Title = "Default query";
            return q;
        }
        public void ExportQuery(Guid queryId,string filePath)
        {
            string content = null;
            IDataReader dr = SqlDbTool.ExecuteQuery(Constants.Sp_SelectQuery, queryId);
            if (!dr.Read())
            {
                throw new Exception("query not found");
            }
            IQuery q = new Query(dr);
            IService s = ServiceFactory.Instance.GetService(q.ServiceType);

            XmlDocument doc = new XmlDocument();
            int fieldIndex = dr.GetOrdinal("QueryContent");
            if (!dr.IsDBNull(fieldIndex))
            {
                content = dr.GetString(fieldIndex);
            }
            doc.LoadXml(content);
            doc.Save(Path.Combine(filePath,q.Id.ToString("N")));
        }
        public void ImportQuery(Guid queryId, string filePath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Path.Combine(filePath, queryId.ToString("N")));
            string serviceType = doc.SelectSingleNode("/ServiceType").InnerText;
            IService s = ServiceFactory.Instance.GetService(serviceType);

            IQuery q = XmlTool.XmlToObject(s.QueryType, doc) as IQuery;
            this.SaveQuery(q);
        }
        public IList<IQuery> GetLabeledQuery(Guid labelId)
        {
            IList<IQuery> queries = new List<IQuery>();
            IDataReader dr = SqlDbTool.ExecuteQuery(Constants.Sp_GetQueryByLabel,labelId);
            while (dr.Read())
            {
                string tStr = null;
                IQuery q = new Query(dr);
                string content = null;
                //tStr = q.ServiceType;
                IService service = ServiceFactory.Instance.GetService(q.ServiceType);

                switch (q.ServiceType)
                {
                    case Constants.BuiltInServiceType:
                        tStr = "Live5.Xps.Framework.BuiltIn.BuiltInQuery";
                        break;
                    case Constants.ExternalServiceType:
                        tStr = "Live5.Xps.Framework.External.ExternalQuery";
                        break;
                    default:
                        tStr = q.ServiceType;
                        break;
                }

                // Todo:Bug: Cannot get type which need dynamic load in.
                Type t = Type.GetType(tStr);
                XmlDocument doc = new XmlDocument();
                int fieldIndex = dr.GetOrdinal("QueryContent");
                if (!dr.IsDBNull(fieldIndex))
                {
                    content = dr.GetString(fieldIndex);
                }
                doc.LoadXml(content);
                q = XmlTool.XmlToObject(service.QueryType, doc) as IQuery;
                queries.Add(q);
            }
            return queries;
        }
    }
}
