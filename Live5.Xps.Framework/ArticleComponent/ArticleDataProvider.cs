using System;
using System.Collections.Generic;
using System.Text;
using Live5.Xps.Framework.Core;
using Live5.Xps.Framework.Model;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using Live5.Xps.Framework.Utils;
using System.Data;
namespace Live5.Xps.ArticleComponent
{
    public class ArticleDataProvider : IEntryDataProvider
    {
        #region IEntryDataProvider Members

        public IEntry SelectEntry(string entryId)
        {
            Guid id = new Guid(entryId);

            IDataReader dr = SqlDbTool.ExecuteQuery("sp_SelectEntry", id);
            IEntry entry = null;
            if (dr.Read())
            {
                entry = new Article(dr);
            }
            return entry;
        }

        public bool InsertEntry(IEntry entry)
        {
            Guid id = Guid.Empty;
            foreach (Person p in entry.Authors)
            {
                id = p.Id;
            }
            if (id==Guid.Empty)
            {
                id = Guid.NewGuid();
            }
            int result = SqlDbTool.ExecuteNonQuery(ServiceConstants.Sp_InsertArticle, entry.EntryId, entry.Title, entry.Summary, entry.ServiceType, id, entry.Content,entry.ContentMediaType.ToString());

            return result >= 0 ? true : false;

        }

        public bool DeleteEntry(string entryId)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool UpdateEntry(IEntry entry)
        {
            throw new Exception("The method or operation is not implemented.");
        }


        public IList<IEntry> SearchEntries(IQuery query)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region IEntryDataProvider Members


        public IList<IEntry> SearchEntries(string searchKey)
        {
            IList<IEntry> entrys = new List<IEntry>();
            IEntry entry = null;
            IDataReader dr = SqlDbTool.ExecuteQuery(ServiceConstants.Sp_ArticleSearch, searchKey);
            while (dr.Read())
            {
                entry = new Article(dr);
                entrys.Add(entry);
            }
            return entrys;
        }

        #endregion
    }
}
