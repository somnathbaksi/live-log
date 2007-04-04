using System;
using System.Collections.Generic;
using System.Text;
using Live5.Xps.Framework.Core;

namespace Live5.Xps.Framework.External
{
    public class ExternalService : IService
    {

        #region IService Members


        public Type QueryType
        {
            get { return typeof(ExternalQuery);
            }
        }


        public IQueryCreator QueryCreator
        {
            get {
                return new ExternalQueryCreator();
            }
        }

        public IEntryDataProvider DataProvider
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public IQueryExecutor QueryExecutor
        {
            get { return new ExternalQueryExecutor(); }
        }

        #endregion

    }
}
