using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Reflection;
using System.IO;
using Live5.Xps.Framework.Model;
using Live5.Xps.Framework.Core;
using Live5.Xps.Framework.Dal;
using Live5.Xps.Framework.Utils;
using System.Xml;

namespace Live5.Xps.Framework
{
    public class PublishService : IPublishService
    {
        private IService m_Service;

        private List<IService> m_ServiceList = new List<IService>();
        
        private Dictionary<string, IService> m_Services = new Dictionary<string, IService>();
        #region IPublishService Members
        public PublishService()
        {
        }
        public bool PutEntry(IEntry entry)
        {
            m_Service = ServiceFactory.Instance.GetService(entry.ServiceType);
            return m_Service.DataProvider.InsertEntry(entry) ;
        }

        public IEntry GetEntry(string entryUri)
        {
           string entryType= EntryDao.GetEntryType(entryUri);
           m_Service = ServiceFactory.Instance.GetService(entryType);
           return m_Service.DataProvider.SelectEntry(entryUri);
        }
        public XmlDocument GetXmlEntry(string entryUri)
        {
            IEntry entry1 = GetEntry(entryUri);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(entry1.ToString());
            /*
            AtomEntry entry = new AtomEntry();

            entry.Title = new AtomContentConstruct("title", entry1.Title);
            entry.Links.Add(new AtomLink(new Uri("http://www.w3.org"), Relationship.Alternate,
                MediaType.TextPlain, "The title of the link."));
            entry.Contributors.Add(new AtomPersonConstruct("contributor","Uncle Bob", new Uri("http://people.w3.org"), "foo@bar.com"));
            entry.Id = new Uri("http://localhost/foo/id1");
            entry.Modified = new AtomDateConstruct("modified", DateTime.Now,
                TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now));
            entry.Issued = new AtomDateConstruct("issued", DateTime.Now,
                TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now));
            entry.Summary = new AtomContentConstruct("summary", entry1.Summary);
            entry.Contents.Add(new AtomContent("The content of the entry."));

            string s = entry.ToString();
             */
            return xmlDoc;
        }

        public bool DeleteEntry(string entryUri)
        {
            string entryType = EntryDao.GetEntryType(entryUri);
            m_Service = ServiceFactory.Instance.GetService(entryType);
            return m_Service.DataProvider.DeleteEntry(entryUri);
        }

        #endregion


    }
}
