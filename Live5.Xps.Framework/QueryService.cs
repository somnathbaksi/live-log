using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Live5.Xps.Framework.Utils;
using Live5.Xps.Framework.Model;
using Live5.Xps.Framework.Core;
using Live5.Xps.Framework.Atom;
using System.IO;
using Live5.Xps.Framework.Dal;
namespace Live5.Xps.Framework
{
    public class QueryService : IQueryService
    {

        #region IQueryService Members


        public IFeed GetFeed(Guid queryId)
        {
            IQuery query = QuerySqlProvider.GetQuery(queryId);
            if (query == null)
            {
                query = QuerySqlProvider.GetDefaultQuery();
            }

            QueryExecutor queryExecutor = new QueryExecutor();

            IFeed feed = ExecuteQuery(query);
            return feed;
        }
        public IFeed GetFeed(string queryId)
        {
            Guid queryGuid = new Guid(queryId);
            return GetFeed(queryGuid);
        }

        #endregion


        public XmlDocument GetXmlFeed(string queryId)
        {
            IFeed feed = GetFeed(queryId);
            return FeedToXml(feed);
        }
        public static XmlDocument FeedToXml(IFeed feed)
        {
            MemoryStream stream = new MemoryStream();
            XmlDocument xml = new XmlDocument();
            AtomWriter writer = new AtomWriter(stream);
            writer.WriteFeed(feed);
            stream.Position = 0;
            xml.Load(stream);
            return xml;
        }


        public static IFeed ExecuteQuery(IQuery query)
        {
            Query q = query as Query;
            IFeed feed = null;
            switch (q.MatchType)
            {
                case QueryType.Literal:
                    feed = Search(q);
                    break;
                case QueryType.SingleEntry:
                    feed = SearchSingleEntry(q);
                    break;
                case QueryType.Label:
                    break;
                case QueryType.Category:
                    break;
                case QueryType.Predefined:
                    break;
                default:
                    feed = Search(q);
                    break;
            }
            return feed;
        }

        #region Simple Search

        public static IFeed Search(string searchKey)
        {
            return Search(searchKey, Constants.BuiltInServiceType);
        }
        public static IFeed Search(Query query)
        {
            return Search(query.HasText.Value, query.ServiceType);
        }
        public static IFeed Search(string searchKey, string serviceType)
        {
            IService service = ServiceFactory.Instance.GetService(serviceType);

            IList<IEntry> entries = service.DataProvider.SearchEntries(searchKey);
            IFeed feed = new Feed();
            feed.LinkList.Add(new AtomLink(feed.Id, Relationship.Self, MimeType.Text));
            feed.Title = searchKey;
            feed.Updated = DateTime.Now;
            Guid feedId = Guid.NewGuid();
            feed.Id = new Uri(Constants.DefaultUri, feedId.ToString());


            foreach (IEntry var in entries)
            {
                feed.EntryList.Add(var);
            }
            return feed;
        }
        public static IFeed SearchAndSave(string searchKey, string serviceType)
        {
            IFeed feed = Search(searchKey, serviceType);
            // Save Query.
            Query q = new Query(serviceType);

            q.Title = searchKey;
            q.HasText.Value = searchKey;
            q.HasText.FieldName = "Text";
            QuerySqlProvider p = new QuerySqlProvider();
            p.SaveQuery(q);

            return feed;
        }

        #endregion

        #region Single Entry Search

        public static IQuery CreateSingleEntryQuery(Guid entryId, string serviceType)
        {
            //Save query.
            Query q = new Query(serviceType);
            q.MatchType = QueryType.SingleEntry;
            q.EntryId.Value = entryId;
            QuerySqlProvider p = new QuerySqlProvider();
            p.SaveTempQuery(q);
            return q;

        }

        public static IFeed SearchSingleEntry(Guid entryId)
        {
            return SearchSingleEntry(entryId, Constants.BuiltInServiceType);
        }
        public static IFeed SearchSingleEntry(Query query)
        {
            return SearchSingleEntry(query.EntryId.Value, query.ServiceType);
        }
        public static IFeed SearchSingleEntry(Guid entryId, string serviceType)
        {
            IService service = ServiceFactory.Instance.GetService(serviceType);

            IEntry entry = service.DataProvider.SelectEntry(entryId.ToString());
            IFeed feed = new Feed();
            feed.LinkList.Add(new AtomLink(feed.Id, Relationship.Self, MimeType.Text));
            feed.Title = entry.Title;
            feed.Updated = DateTime.Now;
            Guid feedId = Guid.NewGuid();
            feed.Id = new Uri(Constants.DefaultUri, feedId.ToString());
            //ICollection<IEntry> es = entries as ICollection<IEntry>;

            feed.EntryList.Add(entry);

            //Save query.
            Query q = new Query(serviceType);
            q.MatchType = QueryType.SingleEntry;
            q.EntryId.Value = entryId;
            QuerySqlProvider p = new QuerySqlProvider();
            p.SaveTempQuery(q);

            return feed;
        }

        #endregion

        public static IFeed GetMostRecent(string serviceType,int pageIndex,int pageSize)
        {
            IList<IEntry> entries = PredefinedSearch.GetMostRecent(serviceType, pageIndex, pageSize);
            IFeed feed = new Feed();
            feed.LinkList.Add(new AtomLink(feed.Id, Relationship.Self, MimeType.Text));
            feed.Title = "Most Recent";
            feed.Updated = DateTime.Now;
            Guid feedId = Guid.NewGuid();
            feed.Id = new Uri(Constants.DefaultUri, feedId.ToString());

            foreach (IEntry var in entries)
            {
                feed.EntryList.Add(var);
            }
            return feed;
            
        }

    }
}
