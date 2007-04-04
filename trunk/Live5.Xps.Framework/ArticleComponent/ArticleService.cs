using System;
using System.Collections.Generic;
using System.Text;
using Live5.Xps.Framework;
using Live5.Xps.Framework.Core;
namespace Live5.Xps.ArticleComponent
{
    public class ArticleService :  IService
    {

        #region IService Members


        public Type QueryType
        {
            get { return typeof(ArticleQuery); }
        }


        public IQueryCreator QueryCreator
        {
            get {
                return new ArticleQueryCreator();
            }
        }

        public IEntryDataProvider DataProvider
        {
            get { return new ArticleDataProvider(); }
        }

        public IQueryExecutor QueryExecutor
        {
            get { return new ArticleQueryExecutor(); }
        }

        #endregion
    }
}
