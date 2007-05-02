using System;
using System.Collections.Generic;
using System.Text;
using Live5.Xps.Framework.Model;
using System.Data;
using Live5.Xps.ArticleComponent;
using Live5.Xps.MediaComponent;

namespace Live5.Xps.Framework.Core
{
    public sealed class EntryFactory
    {
       
        public static IEntry CreateEntry(IDataRecord dr)
        {
            string serviceType = null;
            for (int i = 0; i < dr.FieldCount; i++)
            {
                if (dr.GetName(i).Equals("ServiceType", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (!dr.IsDBNull(i))
                    {
                        serviceType = dr.GetString(i);
                    }
                }
            }
            switch (serviceType)
            {
                case "Live5.Xps.ArticleComponent.ArticleService":
                    return new Article(dr);
                    
                case "Live5.Xps.MediaComponent.MediaService":
                    return new Media(dr);
                default:
                    return new Entry(dr);
            }
        }
    }
}
