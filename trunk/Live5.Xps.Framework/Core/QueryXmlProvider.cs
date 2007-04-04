using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Live5.Xps.Framework.Utils;
namespace Live5.Xps.Framework.Core
{
   public class QueryXmlProvider
    {
        #region IQueryProvider Members

        public void SaveQuery(IQuery query)
        {
            XmlDocument xmlDoc = XmlTool.ObjectToXml(query);
            xmlDoc.Save(query.Id + ".xml");
        }

       public IQuery GetQuery<T>(Guid queryId)
        {
            XmlDocument xmlQuery = new XmlDocument();
            xmlQuery.Load(queryId + ".xml");

            IQuery q = XmlTool.XmlToObject<T>(xmlQuery) as IQuery;
            return q;
        }

        #endregion
    }
}
