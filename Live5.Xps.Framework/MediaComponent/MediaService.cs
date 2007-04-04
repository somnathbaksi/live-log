using System;
using System.Collections.Generic;
using System.Text;
using Live5.Xps.Framework;
using Live5.Xps.Framework.Core;
namespace Live5.Xps.MediaComponent
{
    public class MediaService :  IService
    {

        #region IService Members


        public Type QueryType
        {
            get { return typeof(Media); }
        }


        public IQueryCreator QueryCreator
        {
            get {
                return new MediaQueryCreator();
            }
        }

        public IEntryDataProvider DataProvider
        {
            get { return new MediaDataProvider(); }
        }

        public IQueryExecutor QueryExecutor
        {
            get { return new MediaQueryExecutor(); }
        }

        #endregion
    }
}
