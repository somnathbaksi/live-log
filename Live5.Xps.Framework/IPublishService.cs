using System;
using System.Collections.Generic;
using System.Text;
using Live5.Xps.Framework.Model;
namespace Live5.Xps.Framework
{
    public interface IPublishService
    {
        bool PutEntry(IEntry entry);
        IEntry GetEntry(string entryUri);
        bool DeleteEntry(string entryUri);
    }
}
