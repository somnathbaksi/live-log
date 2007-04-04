using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Live5.Xps.Framework.Atom;
namespace Live5.Xps.Framework.Model
{
    public interface IFeed
    {
        ICollection<Person> AuthorList { get;}
        ICollection<AtomCategory> CategoryList { get;}
        ICollection<Person> ContributorList { get;}
        AtomGenerator Generator { get;set;}
        Uri Icon { get;set;}
        Uri Id { get;set;}
        ICollection<AtomLink> LinkList { get;}
        string Logo { get;set;}
        string Rights { get;set;}
        string SubTitle { get;set;}
        string Title { get;set;}
        DateTime Updated { get;set;}
        ICollection<IEntry> EntryList { get;}
        ICollection<ScopedElement> AdditionalElements { get;}
    }
}
