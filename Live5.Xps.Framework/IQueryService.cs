using System;
using System.Collections.Generic;
using System.Text;
using Live5.Xps.Framework.Model;
namespace Live5.Xps.Framework
{
   public interface IQueryService
    {
      IFeed GetFeed(string queryId);
    }
}
