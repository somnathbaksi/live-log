using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections.ObjectModel;
using System.Xml.XPath;
using Live5.Xps.Framework.Atom;
using Live5.Xps.Framework.Core;
namespace Live5.Xps.Framework.Model
{
    public class Entry : IEntry
    {
        private Guid m_EntryId = Guid.Empty;

        private string m_ServiceType;

        public Entry()
        {
        }
        public Entry(IDataRecord dr)
        {
            for (int i = 0; i < dr.FieldCount; i++)
            {
                if (dr.GetName(i).Equals("Id", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (!dr.IsDBNull(i))
                    {
                        m_EntryId = dr.GetGuid(i);
                    }
                    continue;
                }
                if (dr.GetName(i).Equals("Title", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (!dr.IsDBNull(i))
                    {
                        Title = dr.GetString(i);
                    }
                    continue;
                }
                if (dr.GetName(i).Equals("Updated", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (!dr.IsDBNull(i))
                    {
                        Updated = dr.GetDateTime(i);
                    }
                    continue;
                }
                if (dr.GetName(i).Equals("Summary", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (!dr.IsDBNull(i))
                    {
                        Summary = dr.GetString(i);
                    }
                    continue;
                }
                if (dr.GetName(i).Equals("Published", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (!dr.IsDBNull(i))
                    {
                        Published = dr.GetDateTime(i);
                    }
                }
                if (dr.GetName(i).Equals("Author", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (!dr.IsDBNull(i))
                    {
                        Person p = new Person();
                        p.Id = dr.GetGuid(i);
                        p.Name = p.Id.ToString();
                        Authors.Add(p);

                    }
                }
                if (dr.GetName(i).Equals("ServiceType", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (!dr.IsDBNull(i))
                    {
                        m_ServiceType = dr.GetString(i);
                    }
                }
                if (dr.GetName(i).Equals("Content", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (!dr.IsDBNull(i))
                    {
                        m_Content = dr.GetString(i);
                    }
                }

            }

        }

        #region IEntry Members

        private Uri m_Id;
        public virtual Uri Id
        {
            get
            {
                return new Uri(Constants.DefaultUri, "entryview.aspx?q=" + EntryId.ToString());
            }
            set
            {
                m_Id = value;
            }
        }

        public virtual string ServiceType
        {
            get
            {
                return m_ServiceType;
            }
            set
            {
                m_ServiceType = value;
            }
        }

        public Guid EntryId
        {
            get
            {
                if (m_EntryId == Guid.Empty)
                {
                    m_EntryId = Guid.NewGuid();
                }
                return m_EntryId;
            }
            set
            {
                m_EntryId = value;
            }
        }

        private DateTime m_Published;
        public DateTime Published
        {
            get
            {
                return m_Published;
            }
            set
            {
                m_Published = value;
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

        private string m_Summary;
        public string Summary
        {
            get
            {
                return m_Summary;
            }
            set
            {
                m_Summary = value;
            }
        }
        private DateTime m_Updated;
        public DateTime Updated
        {
            get
            {
                if (m_Updated == DateTime.MinValue)
                {
                    m_Updated = m_Published;
                }
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

        private string m_Content;
        public string Content
        {
            get
            {

                return m_Content;
            }
            set
            {
                m_Content = value;
            }
        }

        private ICollection<Person> m_Authors;
        public ICollection<Person> Authors
        {
            get
            {
                if (m_Authors == null)
                {
                    m_Authors = new Collection<Person>();
                }
                return m_Authors;
            }
        }

        public string Source
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

        private MediaType m_ContentMediaType;
        public MediaType ContentMediaType
        {
            get
            {
                if (m_ContentMediaType==null)
                {
                    m_ContentMediaType = new MediaType();
                }
                return m_ContentMediaType;
            }
        }

        private Mode m_ContentMode;
        public Mode ContentMode
        {
            get
            {
                return m_ContentMode;
            }
            set
            {
                m_ContentMode = value;
            }
        }
        #endregion
    }
}
