using System;
using System.Collections.Generic;
using System.Text;

namespace Live5.Xps.Framework.Core
{
   public interface IService
    {
       IEntryDataProvider DataProvider { get;}
       IQueryExecutor QueryExecutor { get;}
       IQueryCreator QueryCreator { get;}
       Type QueryType { get;}
    }
}
