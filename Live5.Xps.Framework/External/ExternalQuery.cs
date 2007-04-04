using System;
using System.Collections.Generic;
using System.Text;
using Live5.Xps.Framework.Core;

namespace Live5.Xps.Framework.External
{
   public class ExternalQuery:Query
    {
       public ExternalQuery()
       {
       }
       public override string ServiceType
       {
           get
           {
               return Constants.ExternalServiceType;
           }
       }
       private string  m_SourceUrl;

       public string  SourceUrl
       {
           get { return m_SourceUrl; }
           set { m_SourceUrl = value; }
       }

    }
}
