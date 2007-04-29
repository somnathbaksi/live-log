using System;
using System.Collections.Generic;
using System.Text;
using Live5.Xps.Framework;
using Live5.Xps.Framework.Model;
using Live5.Xps.Framework.Utils;
using System.Data;
using Live5.Xps.Framework.Core;
namespace Live5.Xps.Framework.Dal
{
    public class EntryDao
    {
        public static IList<IEntry> SearchEntrys(string searchTerm)
        {
        
            IList<IEntry> entrys = new List<IEntry>();
            IEntry entry = null;
            IDataReader dr = SqlDbTool.ExecuteQuery("sp_EntrySearch", searchTerm);
            while (dr.Read())
            {
                entry = EntryFactory.CreateEntry(dr);
                entrys.Add(entry);
            }
            return entrys;
        }

        public static string GetEntryType(string entryUri)
        {
            string entryType = null;
            IDataReader dr = SqlDbTool.ExecuteQuery("sp_SelectEntryType", new Guid(entryUri));
            if (dr.Read())
            {
                entryType = dr.GetString(0);
            }
            return entryType;
        }
    }
}
