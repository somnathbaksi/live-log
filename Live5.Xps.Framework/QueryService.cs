using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Live5.Xps.Framework.Utils;
using Live5.Xps.Framework.Model;
using Live5.Xps.Framework.Core;
using Live5.Xps.Framework.Atom;
using System.IO;
namespace Live5.Xps.Framework
{
    public class QueryService : IQueryService
    {
        private IService m_Service;
        #region IQueryService Members

        public IFeed GetFeed(Guid queryId)
        {
            IQuery query = QuerySqlProvider.GetQuery(queryId);
            if (query==null)
            {
                query = QuerySqlProvider.GetDefaultQuery();
            }
            
            QueryExecutor queryExecutor=new QueryExecutor();
            IFeed feed = queryExecutor.Execute(query);
            return feed;
        }
        public IFeed GetFeed(string queryId)
        {
            Guid queryGuid = new Guid(queryId);
            return GetFeed(queryGuid);
        }
        public XmlDocument GetXmlFeed(string queryId)
        {
            MemoryStream stream = new MemoryStream();
            XmlDocument xml = new XmlDocument();
            IFeed feed = GetFeed(queryId);
            AtomWriter writer = new AtomWriter(stream);
            writer.WriteFeed(feed);
            stream.Position = 0;
            xml.Load(stream);
            return xml;
        }

        #endregion
    }
}
