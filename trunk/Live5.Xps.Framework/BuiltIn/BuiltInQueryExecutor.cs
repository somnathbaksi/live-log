using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Live5.Xps.Framework.Core;
using Live5.Xps.Framework.Model;
using Live5.Xps.Framework.Utils;
using Live5.Xps.Framework.Dal;
using System.Collections.ObjectModel;
namespace Live5.Xps.Framework.BuiltIn
{
   public class BuiltInQueryExecutor:IQueryExecutor
    {
        #region IQueryExecutor Members

        public IFeed Execute(IQuery query)
        {
           BuiltInQuery q = query as BuiltInQuery;
           IList<IEntry> entries = EntryDao.SearchEntrys(q.HasText.Value);
           IFeed feed = new Feed();
           feed.Id = new Uri(new Uri(Constants.BaseUri),q.Id.ToString());
           ICollection<IEntry> es = entries as ICollection<IEntry>;
           foreach (IEntry var in es)
           {
               feed.EntryList.Add(var);
           }
           //feed.EntryList = es as Collection<IEntry>;
           return feed;
        }

        public XmlDocument GetXmlFeed(IQuery query)
        {
            // Todo:
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
       public IList<IEntry> GetEntryList(IQuery query)
       {
           BuiltInQuery q = query as BuiltInQuery;
           return EntryDao.SearchEntrys(q.HasText.Value);
       }
    }
}
