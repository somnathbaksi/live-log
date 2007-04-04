using System;
using System.Collections.Generic;
using System.Text;
using Live5.Xps.Framework;
using Live5.Xps.Framework.Model;
using Live5.Xps.Framework.Utils;
using System.Data;
namespace Live5.Xps.Framework.Dal
{
    public class EntryDao
    {
        public static IList<IEntry> SearchEntrys(string searchTerm)
        {
            bool isOutOfLineMedia = false;
            IList<IEntry> entrys = new List<IEntry>();
            IEntry entry = null;
            IDataReader dr = SqlDbTool.ExecuteQuery("sp_EntrySearch", searchTerm);
            while (dr.Read())
            {
                isOutOfLineMedia = false;
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    if (dr.GetName(i).Equals("MediaType",StringComparison.InvariantCultureIgnoreCase))
                    {
                        if (!dr.IsDBNull(i))
                        {
                            isOutOfLineMedia = true;
                        }
                    }
                }
                if (isOutOfLineMedia)
                {
                    entry = new MediaComponent.Media(dr);
                    entrys.Add(entry);
                }
                else
                {
                    entry = new Entry(dr);
                    entrys.Add(entry);
                }
               
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
