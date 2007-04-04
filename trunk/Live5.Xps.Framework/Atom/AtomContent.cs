using System;
using System.Collections.Generic;
using System.Text;

namespace Live5.Xps.Framework.Atom
{
    public class AtomContent
    {
        private MimeType m_Type = MimeType.TextPlain;
        private Mode m_Mode = Mode.InlineTextContent;
        private string m_Content = String.Empty;
        #region Properties

        /// <summary>
        /// The media type of the content.
        /// </summary>
        public MimeType Type
        {
            get
            {

                return m_Type;
            }
            set
            {
                if (value == MimeType.UnknownType)
                {
                    value = MimeType.TextPlain;
                }
                else
                {
                    m_Type = value;
                }
            }
        }

        /// <summary>
        /// The encoding mode of the content.
        /// </summary>
        public Mode Mode
        {
            get { return m_Mode; }
            set { m_Mode = value; }
        }

        /// <summary>
        /// The content itself.
        /// </summary>
        public string Content
        {
            get { return m_Content; }
            set { m_Content = value; }
        }

        #endregion Properties
    }
}
