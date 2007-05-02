using System;
using System.Collections.Generic;
using System.Text;

namespace Live5.Xps.Framework.Core
{
    public class QueryCreator
    {
        public IQuery Create(string text)
        {
            Query q = new Query();
            q.Title = text;
            q.HasText.Value = text;
            q.HasText.FieldName = "Text";
            return q;
        }
        public IQuery Create(string text, string serviceType)
        {
            Query q = new Query(serviceType);
            q.Title = text;
            q.HasText.Value = text;
            q.HasText.FieldName = "Text";
           
            return q;
        }
        public IQuery Create(Guid entryId,string serviceType)
        {
            Query q = new Query(serviceType);
            q.MatchType = QueryType.SingleEntry;
            q.EntryId.Value = entryId;
            return q;
        }
    }
}
