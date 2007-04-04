using System;
using System.Collections.Generic;
using System.Text;
using Live5.Xps.Framework.Core;

namespace Live5.Xps.Framework.External
{
    public class ExternalQueryCreator:IQueryCreator
    {
        public IQuery Create(string externalUri)
        {
            ExternalQuery q = new ExternalQuery();
            q.SourceUrl = externalUri;
            return q;
        }
    }
}
