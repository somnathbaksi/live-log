using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using Live5.Xps.Framework.Model;
using Live5.Xps.Framework.Atom;

namespace Live5.Xps.Framework.Atom
{
    public class AtomWriter
    {
        XmlTextWriter m_Writer;
        private string outOfLineMediaType;
        public AtomWriter(Stream stream)
        {
            m_Writer = new XmlTextWriter(stream, Encoding.UTF8);
            m_Writer.Formatting = Formatting.Indented;
            m_Writer.Indentation = 2;
        }
        public void WriteFeed(IFeed feed)
        {
            m_Writer.WriteStartDocument();
            m_Writer.WriteStartElement(AtomConstants.Feed, AtomConstants.NameSpace);

            #region Write Atom Author

            if (feed.AuthorList.Count != 0)
            {
                WritePerson(AtomConstants.Author, feed.AuthorList);
            }

            #endregion

            #region Write Feed Category

            // Todo: 

            #endregion

            #region Write Feed Contributor

            // Todo:

            #endregion

            #region Write Feed Generator

            // todo:

            #endregion

            #region Write Feed Icon

            // todo:

            #endregion

            #region Write Feed Id

            m_Writer.WriteElementString(AtomConstants.Id, feed.Id.ToString());

            #endregion

            #region Write Feed Link

            WriteLink(AtomConstants.Link, feed.LinkList);

            #endregion

            #region Write Feed Logo


            // todo:

            #endregion


            #region Write Feed Rights

            // todo:

            #endregion

            #region Write Feed Subtitle

            // todo:

            #endregion

            #region Write Feed Title

            // todo: Write complex title.
            m_Writer.WriteElementString(AtomConstants.Title, feed.Title);

            #endregion

            #region Write Feed Updated

            WriteDateTime(AtomConstants.Updated, feed.Updated);

            #endregion

            #region Write Feed ExtensionElement

            // todo:

            #endregion

            #region Write Entry

            if (feed.EntryList.Count != 0)
            {
                foreach (IEntry entry in feed.EntryList)
                {
                    WriteEntry(entry);
                }
            }

            #endregion
            m_Writer.WriteEndElement();
            m_Writer.Flush();
        }
        private void WriteLink(string localName, ICollection<AtomLink> links)
        {
            if (links.Count == 0)
            {
                return;
            }
            foreach (AtomLink link in links)
            {
                // todo:
                m_Writer.WriteStartElement(localName);
                m_Writer.WriteAttributeString(AtomConstants.Href, link.HRef.ToString());
                m_Writer.WriteAttributeString(AtomConstants.Rel,Utils.ParseRelationship(link.Rel));
                if (link.Length!=0)
                {
                    m_Writer.WriteAttributeString(AtomConstants.Length, link.Length.ToString());
                }
                if (link.HrefLang != LanguageTag.UnknownLanguage)
                {
                    m_Writer.WriteAttributeString(AtomConstants.Language, Utils.ParseLanguage(link.HrefLang));
                }
                if (!string.IsNullOrEmpty(link.Title))
                {
                    m_Writer.WriteAttributeString(AtomConstants.Title,link.Title);
                }
                m_Writer.WriteEndElement();
            }

        }
        private void WritePerson(string localName, ICollection<Person> persons)
        {
            foreach (Person p in persons)
            {
                m_Writer.WriteStartElement(localName);
                m_Writer.WriteElementString(AtomConstants.Name, p.Name);
                if (p.Uri != null)
                {
                    m_Writer.WriteElementString(AtomConstants.Uri, p.Uri.ToString());
                }
                if (!string.IsNullOrEmpty(p.Email))
                {
                    m_Writer.WriteElementString(AtomConstants.Email, p.Email);
                }
                m_Writer.WriteEndElement();
            }
        }
        private void WriteDateTime(string localName, DateTime dateTime)
        {
            DateTime localDateTime;
            if (dateTime.Kind == DateTimeKind.Unspecified)
            {
                localDateTime = DateTime.SpecifyKind(dateTime, DateTimeKind.Local);
            }
            else
            {
                localDateTime = dateTime;
            }
            TimeSpan ts = TimeSpan.MinValue;

            string utcOffset = null;
            switch (localDateTime.Kind)
            {
                case DateTimeKind.Local:
                    ts = TimeZone.CurrentTimeZone.GetUtcOffset(dateTime);
                    int ahead = ts.CompareTo(TimeSpan.Zero);
                    if (ahead > 0)
                    {
                        utcOffset = "+" + ts.ToString().Substring(0, 5);
                    }
                    else if (ahead < 0)
                    {
                        utcOffset = ts.ToString().Substring(0, 6);
                    }
                    else
                    {
                        utcOffset = "Z";
                    }
                    break;

                case DateTimeKind.Unspecified:

                    utcOffset = "-00:00";

                    break;

                case DateTimeKind.Utc:
                    utcOffset = "Z";
                    break;

                default:
                    // All the posible value is enumed.
                    break;
            }
            m_Writer.WriteElementString(localName, localDateTime.ToString("s") + utcOffset);
        }


        private void WriteContent(string localName, string serviceType, string content)
        {
            string output = null;

            Mode mode = AtomConstants.GetContentMode(serviceType);
            MimeType mediaType = AtomConstants.GetContentType(serviceType);
            string type = null;
            //switch (mediaType)
            //{
            //    case MediaType.Text:
            //        output = content;

            //        break;
            //    case MediaType.Html:
            //        output = Utils.Escape(content);
            //        break;
            //    case MediaType.Xhtml:
            //        type = Utils.ParseMediaType(mediaType);
            //        output = "<div xmlns=\"http://www.w3.org/1999/xhtml\">" + content + "</div>";
            //        break;
            //    default:
            //        type = Utils.ParseMediaType(mediaType);
            //        output = content;
            //        break;
            //}

            switch (mode)
            {
                case Mode.InlineTextContent:
                    if (mediaType==MimeType.Html)
                    {
                        output = Utils.Escape(content);
                    }
                    else
                    {
                        output = content;
                    }
                    
                    break;
                case Mode.InlineXhtmlContent:
                    type = Utils.ParseMediaType(mediaType);
                    output = "<div xmlns=\"http://www.w3.org/1999/xhtml\">" + content + "</div>";
                    break;
                case Mode.InlineOtherContent:
                    type = Utils.ParseMediaType(mediaType);
                    output =Utils.Base64Encode(content);
                    break;
                case Mode.OutOfLineContent:
                    type = outOfLineMediaType;
                    output = content;
                    break;
                default:
                    break;
            }
            m_Writer.WriteStartElement(localName);
            if (!string.IsNullOrEmpty(type))
            {
                m_Writer.WriteAttributeString("type", type);
            }
            if (mediaType == MimeType.Xhtml)
            {
                m_Writer.WriteRaw(output);
            }
            else
            {
                m_Writer.WriteAttributeString("src", content);
            }
            

            m_Writer.WriteEndElement();


        }
        private void WriteEntry(IEntry entry)
        {
            if (entry is MediaComponent.Media)
            {
                MediaComponent.Media v=entry as MediaComponent.Media;
                outOfLineMediaType = v.ContentMediaType.ToString();
            }
            m_Writer.WriteStartElement(AtomConstants.Entry);

            #region Entry Author

            if (entry.Authors.Count != 0)
            {
                WritePerson(AtomConstants.Author, entry.Authors);
            }

            #endregion


            #region Entry Category

            // todo:

            #endregion

            #region Entry Contributor

            // todo:

            #endregion

            #region Entry Id

            m_Writer.WriteElementString(AtomConstants.Id, entry.Id.ToString());

            #endregion

            #region Entry Content

            WriteContent(AtomConstants.Content, entry.ServiceType, entry.Content);

            #endregion

            #region Entry Link

            // todo:

            #endregion


            #region Entry Published

            // Todo:

            #endregion

            #region Entry Rights

            // todo:
            #endregion

            #region Entry Source

            // todo:

            #endregion

            #region Entry Summary

            m_Writer.WriteElementString(AtomConstants.Summary, entry.Summary);

            #endregion

            #region Title

            m_Writer.WriteElementString(AtomConstants.Title, entry.Title);

            #endregion

            #region Updated

            WriteDateTime(AtomConstants.Updated, entry.Updated);

            #endregion

            m_Writer.WriteEndElement();
        }
    }
}
