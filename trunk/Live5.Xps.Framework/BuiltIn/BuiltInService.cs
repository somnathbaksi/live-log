using System;
using System.Collections.Generic;
using System.Text;
using Live5.Xps.Framework.Core;

namespace Live5.Xps.Framework.BuiltIn
{
   public class BuiltInService:IService
    {

        #region IService Members



        public IEntryDataProvider DataProvider
        {
            get {
                return new BuiltInDataProvider();
            }
        }


        #endregion
    }
}
