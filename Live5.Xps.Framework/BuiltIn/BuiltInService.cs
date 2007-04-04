using System;
using System.Collections.Generic;
using System.Text;
using Live5.Xps.Framework.Core;

namespace Live5.Xps.Framework.BuiltIn
{
   public class BuiltInService:IService
    {

        #region IService Members


        public Type QueryType
        {
            get { return typeof(BuiltInQuery); }
        }


        public IQueryCreator QueryCreator
        {
            get {
                return new BuiltInQueryCreator();
            }
        }

        public IEntryDataProvider DataProvider
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public IQueryExecutor QueryExecutor
        {
            get { return new BuiltInQueryExecutor(); }
        }

        #endregion
    }
}
