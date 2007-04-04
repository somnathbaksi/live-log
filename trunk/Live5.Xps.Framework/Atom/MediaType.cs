using System;
using System.Collections.Generic;
using System.Text;

namespace Live5.Xps.Framework.Atom
{
    public class MediaType
    {
        private MimeType m_MimeType = MimeType.UnknownType;
        private AtomBasicType m_AtomBasicType = AtomBasicType.Text;

        public void SetType(MimeType mimeType)
        {
            // Set basic atom type to default.
            if (m_AtomBasicType != AtomBasicType.None)
            {
                m_AtomBasicType = AtomBasicType.None;
            }
            m_MimeType = mimeType;
        }

        public void SetType(AtomBasicType basicType)
        {
            // Set mime type to default.
            if (m_MimeType != MimeType.UnknownType)
            {
                m_MimeType = MimeType.UnknownType;
            }
            m_AtomBasicType = basicType;
        }
        public void SetType(string mediaType)
        {
            try
            {
                AtomBasicType obj = (AtomBasicType)Enum.Parse(typeof(AtomBasicType), mediaType, true);
                SetType(obj);
            }
            catch (ArgumentException)
            {
                // Parse to atombasictype failed, parse to mimetype.
                SetType(Utils.ParseMediaType(mediaType));
            }
        }
        public bool IsAtomBisicType
        {
            get
            {
                return m_AtomBasicType != AtomBasicType.None;
            }
        }
        public MimeType GetMimeType
        {
            get
            {
                return m_MimeType;
            }
        }
        public AtomBasicType GetAtomBasicType
        {
            get
            {
                return m_AtomBasicType;
            }
        }
        public override string ToString()
        {
            string stringValue = null;
            if (IsAtomBisicType)
            {
                stringValue = Enum.Format(typeof(AtomBasicType), m_AtomBasicType, "G").ToLowerInvariant();
            }
            else
            {
                stringValue = Utils.ParseMediaType(m_MimeType);
            }


            return stringValue;
        }
    }
}
