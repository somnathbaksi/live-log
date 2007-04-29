using System;
using System.Collections.Generic;
using System.Text;
using Live5.Xps.Framework.Model;
namespace Live5.Xps.Framework.Core
{
   public interface IEntryDataProvider
    {
       IEntry SelectEntry(string entryId);
       bool InsertEntry(IEntry entry);
       bool DeleteEntry(string entryId);
       bool UpdateEntry(IEntry entry);
       IList<IEntry> SearchEntries(IQuery query);
       IList<IEntry> SearchEntries(string searchKey);
    }
}
