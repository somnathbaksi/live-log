using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Xml.Serialization;
using Live5.Xps.Framework.Core;
namespace Live5.Xps.MediaComponent
{
    [Serializable]
    [XmlRoot("Query")]
    public class MediaQuery : Query
    {
        private string m_Kind = ServiceConfig.ServiceType;

        #region IQuery Members

        [XmlAttribute]
        public override string ServiceType
        {
            get { return m_Kind; }
        }

        #endregion

    
        private QueryItem<string> m_Content;

        public QueryItem<string> TermContent
        {
            get
            {
                if (m_Content == null)
                {
                    m_Content = new QueryItem<string>();
                    m_Content.FieldName = "Content";
                    m_Content.Value = string.Empty;
                    m_Content.CompairType = "=";
                }
                return m_Content;
            }
            set { m_Content = value; }
        }

    }
}
