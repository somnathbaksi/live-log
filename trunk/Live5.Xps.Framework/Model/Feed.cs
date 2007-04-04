using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Collections.ObjectModel;
using Live5.Xps.Framework.Core;
using Live5.Xps.Framework.Atom;
using System.Xml;
namespace Live5.Xps.Framework.Model
{
    /// <summary>
    /// Represent an atom feed.
    /// </summary>
    [Serializable]
    public class Feed : IFeed
    {

        private Uri m_Id;

        public Uri Id
        {
            get
            {
                if (m_Id == null)
                {
                    m_Id = new Uri(Constants.BaseUri);
                }
                return m_Id;
            }
            set
            {
                m_Id = value;
            }
        }

        #region IFeed Members

        private ICollection<ScopedElement> m_AdditionalElements;
        public ICollection<ScopedElement> AdditionalElements
        {
            get
            {
                if (m_AdditionalElements == null)
                {
                    m_AdditionalElements = new Collection<ScopedElement>();
                }
                return m_AdditionalElements;
            }
        }

        private ICollection<IEntry> m_EntryList;
        public ICollection<IEntry> EntryList
        {
            get
            {
                if (m_EntryList == null)
                {
                    m_EntryList = new Collection<IEntry>();
                }
                return m_EntryList;
            }
        }

        private string m_Subtitle;
        public string SubTitle
        {
            get
            {
                return m_Subtitle;
            }
            set
            {
                m_Subtitle = value;
            }
        }

        private string m_Title;
        public string Title
        {
            get
            {
                return m_Title;
            }
            set
            {
                m_Title = value;
            }
        }

        private DateTime m_Updated;
        public DateTime Updated
        {
            get
            {
                return m_Updated;
            }
            set
            {
                m_Updated = value;
            }
        }

        private string m_Rights;
        public string Rights
        {
            get
            {
                return m_Rights;
            }
            set
            {
                m_Rights = value;
            }
        }

        private ICollection<Person> m_AuthorList;
        public ICollection<Person> AuthorList
        {
            get
            {
                if (m_AuthorList == null)
                {
                    m_AuthorList = new Collection<Person>();
                }
                return m_AuthorList;
            }
        }
        private ICollection<Person> m_ContributorList;
        public ICollection<Person> ContributorList
        {
            get
            {
                if (m_ContributorList == null)
                {
                    m_ContributorList = new Collection<Person>();
                }
                return m_ContributorList;
            }
        }

        public ICollection<AtomCategory> CategoryList
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public AtomGenerator Generator
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public Uri Icon
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }
        private ICollection<AtomLink> m_LinkList;
        public ICollection<AtomLink> LinkList
        {
            get
            {
                if (m_LinkList == null)
                {
                    m_LinkList = new Collection<AtomLink>();
                }
                return m_LinkList;
            }
        }

        public string Logo
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        #endregion
    }
}
