using System;
using System.Collections.Generic;
using System.Text;
using Live5.Xps.Framework.Core;
using Live5.Xps.Framework.Model;
using Live5.Xps.Framework.Dal;
using Live5.Xps.Framework.Atom;
namespace Live5.Xps.ArticleComponent
{
   public class ArticleQueryExecutor:IQueryExecutor
    {

       #region IQueryExecutor Members

       IFeed IQueryExecutor.Execute(IQuery query)
       {
           ArticleQuery q = (ArticleQuery)query;
           IList<IEntry> entries = ArticleDataProvider.SearchEntrys(q.TermTitle.Value);
           IFeed feed = new Feed();
           feed.LinkList.Add(new AtomLink(feed.Id,Relationship.Self,MimeType.Text));
           feed.Title = q.Title;
           feed.Updated = DateTime.Now;
           feed.Id = new Uri(Constants.DefaultUri, q.Id.ToString());
           //ICollection<IEntry> es = entries as ICollection<IEntry>;
           foreach (IEntry var in entries)
           {
               feed.EntryList.Add(var);
           }
           //feed.EntryList = es as Collection<IEntry>;
           return feed;
          // return new Feed();
       }

       #endregion

       #region IQueryExecutor Members


       public System.Xml.XmlDocument GetXmlFeed(IQuery query)
       {
           throw new Exception("The method or operation is not implemented.");
       }

       #endregion
   }
}
