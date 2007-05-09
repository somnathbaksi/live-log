using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Live5.Xps.Framework.Utils;
using Live5.Xps.Framework.Model;
using Live5.Xps.Framework.Core;

namespace Live5.Xps.Framework.Dal
{
    public class PredefinedSearch
    {
        public static IList<IEntry> GetMostRecent(string serviceType,int pageIndex,int pageSize)
        {

            IList<IEntry> entrys = new List<IEntry>();
            IEntry entry = null;
            IDataReader dr = SqlDbTool.ExecuteQuery("sp_GetMostRecent", DateTime.Now.AddDays(-1), serviceType,pageIndex,pageSize);
            while (dr.Read())
            {
                entry = EntryFactory.CreateEntry(dr);
                entrys.Add(entry);
            }
            return entrys;
        }

    }
}
