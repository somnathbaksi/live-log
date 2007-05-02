using System;
using System.Collections.Generic;
using System.Text;
using Live5.Xps.Framework.Core;
using Live5.Xps.Framework.Model;
using System.Data;
using Live5.Xps.Framework.Utils;

namespace Live5.Xps.Framework.BuiltIn
{
    public class BuiltInDataProvider : IEntryDataProvider
    {
        #region IEntryDataProvider Members

        public Live5.Xps.Framework.Model.IEntry SelectEntry(string entryId)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool InsertEntry(Live5.Xps.Framework.Model.IEntry entry)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool DeleteEntry(string entryId)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool UpdateEntry(Live5.Xps.Framework.Model.IEntry entry)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IList<Live5.Xps.Framework.Model.IEntry> SearchEntries(IQuery query)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IList<Live5.Xps.Framework.Model.IEntry> SearchEntries(string searchKey)
        {
            IList<IEntry> entrys = new List<IEntry>();
            IEntry entry = null;
            IDataReader dr = SqlDbTool.ExecuteQuery("sp_EntrySearch", searchKey);
            while (dr.Read())
            {
                entry = EntryFactory.CreateEntry(dr);
                entrys.Add(entry);
            }
            return entrys;
        }

        #endregion
    }
}
