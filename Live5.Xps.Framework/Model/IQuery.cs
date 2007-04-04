using System;
using System.Collections.Generic;
using System.Text;

namespace Live5.Xps.Framework.Core
{
    public interface IQuery
    {
        string ServiceType { get;}
        Guid Id { get;set;}
        string Title { get;set;}
    }
}
