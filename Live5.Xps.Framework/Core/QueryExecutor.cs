using System;
using System.Collections.Generic;
using System.Text;
using Live5.Xps.Framework.Model;
using Live5.Xps.Framework.Dal;
using Live5.Xps.Framework.Atom;

namespace Live5.Xps.Framework.Core
{
   public  class QueryExecutor
    {
       public IFeed Execute(IQuery query)
       {
           Query q = query as Query;
           IFeed feed = null;
           switch (q.MatchType)
           {
               case QueryType.Literal:
                   feed = SearchLiteral(q);
                   break;
               case QueryType.SingleEntry:
                   feed = SearchSingleEntry(q);
                   break;
               case QueryType.Label:
                   break;
               case QueryType.Category:
                   break;
               default:
                   break;
           }
           return feed;
         
       }
       private IFeed SearchLiteral(Query q)
       {
           IService service = ServiceFactory.Instance.GetService(q.ServiceType);

           IList<IEntry> entries = service.DataProvider.SearchEntries(q.HasText.Value);
           IFeed feed = new Feed();
           feed.LinkList.Add(new AtomLink(feed.Id, Relationship.Self, MimeType.Text));
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
       private IFeed SearchSingleEntry(Query q)
       {
           IService service = ServiceFactory.Instance.GetService(q.ServiceType);

           IEntry entry = service.DataProvider.SelectEntry(q.EntryId.Value.ToString());
           IFeed feed = new Feed();
           feed.LinkList.Add(new AtomLink(feed.Id, Relationship.Self, MimeType.Text));
           feed.Title = q.Title;
           feed.Updated = DateTime.Now;
           feed.Id = new Uri(Constants.DefaultUri, q.Id.ToString());
           //ICollection<IEntry> es = entries as ICollection<IEntry>;
          
               feed.EntryList.Add(entry);
           
           //feed.EntryList = es as Collection<IEntry>;
           return feed;
       }
    }
}
