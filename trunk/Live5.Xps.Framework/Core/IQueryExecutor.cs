using System;
using System.Collections.Generic;
using System.Text;
using Live5.Xps.Framework.Model;
using Live5.Xps.Framework.Core;
using System.Xml;
namespace Live5.Xps.Framework.Core
{
   public interface IQueryExecutor
    {
       IFeed Execute(IQuery query);
       //XmlDocument GetXmlFeed(IQuery query);
    }
}
