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


        public IEntryDataProvider DataProvider
        {
            get { return new MediaDataProvider(); }
        }



        #endregion
    }
}
