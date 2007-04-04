using System;
using System.Collections.Generic;
using System.Text;
using Live5.Xps.Framework.Core;
using System.Data;
using System.Xml.XPath;
using System.Xml;
using System.Xml.Serialization;
namespace Live5.Xps.Framework.BuiltIn
{
    [XmlRoot("Query")]
    public class BuiltInQuery:Query
    {
        public BuiltInQuery()
        {
        }
        public BuiltInQuery(IDataRecord dr)
            : base(dr)
        {
            
            int fieldIndex = dr.GetOrdinal("QueryContent");
            if (dr.IsDBNull(fieldIndex))
            {
                XmlDocument x = new XmlDocument();
                x.LoadXml(dr.GetString(fieldIndex));
                
            }
        }
        [XmlAttribute("ServiceType")]
        public override string ServiceType
        {
            get
            {
                return Constants.BuiltInServiceType;
            }
        }
        private QueryItem<string> m_HasText;
        public QueryItem<string> HasText
        {
            get
            {
                if (m_HasText==null)
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
    }
}
