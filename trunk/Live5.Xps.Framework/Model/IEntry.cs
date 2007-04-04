using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Live5.Xps.Framework.Atom;
namespace Live5.Xps.Framework.Model
{
    public interface IEntry
    {
        ICollection<Person> Authors{get;}
        Uri Id { get;set;}
        Guid EntryId { get;set;}
        DateTime Published { get;set;}
        string Rights { get;set;}
        string Source { get;set;}
        string Summary { get;set;}
        string Title { get;set;}
        DateTime Updated { get;set;}
        string Content { get;set;}
        MediaType ContentMediaType { get;}
        /// <summary>
        /// Extend element.
        /// </summary>
        string ServiceType { get;set;}
       
    }
}
