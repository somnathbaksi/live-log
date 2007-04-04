using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Data;
namespace Live5.Xps.Framework.Core
{
    [Serializable]
    [XmlRoot("Query")]
    public class Query : IQuery
    {
        private Guid m_Id = Guid.Empty;
        private string m_ServiceType;
        private string m_Title;

        public Query()
        {
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

        #region IQuery Members

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

        #endregion
    }
}
