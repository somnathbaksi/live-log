using System;
using System.Collections.Generic;
using System.Text;

namespace Live5.Xps.Framework.Core
{
   public class Constants
    {
       public readonly static Uri DefaultUri = new Uri(BaseUri);
       public const string BaseUri = "http://www.live-5.com/";
       internal const string ServiceDictionaryCachingKey = "ServiceDictionaryCachingKey";
       internal const string BuiltInServiceType = "Live5.Xps.Framework.BuiltIn.BuiltInService";
       internal const string ExternalServiceType = "Live5.Xps.Framework.External.ExternalService";

       // Stored procedures.
       internal const string Sp_InsertQuery = "sp_InsertQuery";
       internal const string Sp_SelectQuery = "sp_SelectQuery";
       internal const string Sp_GetLabels = "sp_GetLabels";
       internal const string Sp_ApplyLabel="sp_ApplyLabel";
       internal const string Sp_GetQueryByLabel = "sp_GetQueryByLabel";
       internal const string Sp_SaveTempQuery = "sp_SaveTempQuery";
    }
}
