using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Data;
namespace Live5.Xps.Framework.Core
{
    public enum QueryType
    {
        Literal,
        SingleEntry,
        Label,
        Category,
        Predefined
    }
    [Serializable]
    [XmlRoot("Query")]
    public class Query : IQuery
    {
        private Guid m_Id = Guid.Empty;
        private string m_ServiceType;
        private string m_Title;
        private QueryType m_MatchType;

        public QueryType MatchType
        {
            get { return m_MatchType; }
            set { m_MatchType = value; }
        }

        public Query()
        {
        }

        public Query(string serviceType)
        {
            m_ServiceType = serviceType;
        }
        public Query(IDataRecord dr)
        {
            int fieldIndex = dr.GetOrdinal("QueryId");
            if (!dr.IsDBNull(fieldIndex))
            {
                m_Id = dr.GetGuid(fieldIndex);
            }
            fieldIndex = dr.GetOrdinal("ServiceType");
            if (!dr.IsDBNull(fieldIndex))
            {
                m_ServiceType = dr.GetString(fieldIndex);
            }
        }
        private string m_PredefinedName;

        public string PredefinedName
        {
            get { return m_PredefinedName; }
            set { m_PredefinedName = value; }
        }

        #region IQuery Members

        [XmlAttribute("ServiceType")]
        public virtual string ServiceType
        {
            get
            {
                if (string.IsNullOrEmpty(m_ServiceType))
                {
                    m_ServiceType = Constants.BuiltInServiceType;
                }
                return m_ServiceType;
            }
            set
            {
                m_ServiceType = value;
            }
            
        }
        private int m_PageSize;

        public int PageSize
        {
            get { return m_PageSize; }
            set { m_PageSize = value; }
        }
        private int m_PageIndex;

        public int PageIndex
        {
            get { return m_PageIndex; }
            set { m_PageIndex = value; }
        }

        public Guid Id
        {
            get
            {
                if (m_Id == Guid.Empty)
                {
                    m_Id = Guid.NewGuid();
                }
                return m_Id;
            }
            set
            {
                m_Id = value;
            }
        }
        private QueryItem<Guid> m_EntryId;

        public QueryItem<Guid> EntryId
        {
            get
            {
                if (m_EntryId==null)
                {
                    m_EntryId = new QueryItem<Guid>();
                } 
                return m_EntryId;
            }
            set { m_EntryId = value; }
        }

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

        private bool m_IsSingleMatch;

        public bool IsSingleMatch
        {
            get { return m_IsSingleMatch; }
            set { m_IsSingleMatch = value; }
        }

        #endregion

        #region Query Terms

        private QueryItem<string> m_TermTitle;

        public QueryItem<string> TermTitle
        {
            get
            {
                if (m_TermTitle == null)
                {
                    m_TermTitle = new QueryItem<string>();
                }
                return m_TermTitle;
            }
            set
            {
                m_TermTitle = value;
            }
        }

        private QueryItem<DateTime> m_Updated;

        [XmlElement(IsNullable = true)]
        public QueryItem<DateTime> Updated
        {
            get
            {
                if (m_Updated == null)
                {
                    m_Updated = new QueryItem<DateTime>();
                } return m_Updated;
            }
            set { m_Updated = value; }
        }

        private string m_MediaType;

        public string MediaType
        {
            get { return m_MediaType; }
            set { m_MediaType = value; }
        }
        private QueryItem<string> m_HasText;
        public QueryItem<string> HasText
        {
            get
            {
                if (m_HasText == null)
                {
                    m_HasText = new QueryItem<string>();
                    m_HasText.FieldName = "All";
                    m_HasText.CompairType = "In";
                    m_HasText.Value = "";
                }

                return m_HasText;
            }
            set
            {
                m_HasText = value;
            }
        }
        #endregion
    }
}
