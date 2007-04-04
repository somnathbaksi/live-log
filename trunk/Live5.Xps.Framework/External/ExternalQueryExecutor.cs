using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Live5.Xps.Framework.Core;
using Live5.Xps.Framework.Utils;
using Live5.Xps.Framework.Model;
using Microsoft.Practices.EnterpriseLibrary.Logging;
namespace Live5.Xps.Framework.External
{
    public class ExternalQueryExecutor : IQueryExecutor
    {
        #region IQueryExecutor Members

        public IFeed Execute(IQuery query)
        {
            ExternalQuery q = query as ExternalQuery;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(q.SourceUrl);
            IFeed feed = XmlTool.XmlToObject<IFeed>(xmlDoc);
            return feed;
        }
        public XmlDocument GetXmlFeed(IQuery query)
        {
            ExternalQuery q = query as ExternalQuery;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(q.SourceUrl);
            return xmlDoc;
        }
        #endregion
    }
}
