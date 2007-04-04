/* 
  	* AtomLink.cs
	* [ part of Atom.NET library: http://atomnet.sourceforge.net ]
	* Author: Lawrence Oluyede
	* License: BSD-License (see below)
    
	Copyright (c) 2003, 2004 Lawrence Oluyede
    All rights reserved.

    Redistribution and use in source and binary forms, with or without
    modification, are permitted provided that the following conditions are met:

    * Redistributions of source code must retain the above copyright notice,
    * this list of conditions and the following disclaimer.
    * Redistributions in binary form must reproduce the above copyright
    * notice, this list of conditions and the following disclaimer in the
    * documentation and/or other materials provided with the distribution.
    * Neither the name of the copyright owner nor the names of its
    * contributors may be used to endorse or promote products derived from
    * this software without specific prior written permission.

    THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
    AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
    IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
    ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE
    LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
    CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
    SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
    INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN
    CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
    ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
    POSSIBILITY OF SUCH DAMAGE.
*/
using System;
using System.Xml.XPath;

namespace Live5.Xps.Framework.Atom
{
    /// <summary>
    /// The link of an Atom feed or an entry.
    /// <seealso cref="AtomFeed"/>
    /// <seealso cref="AtomEntry"/>
    /// </summary>
    [Serializable]
    public class AtomLink
    {
        private Relationship m_Rel = AtomConstants.DefaultRel;
        private MimeType m_Type = AtomConstants.DefaultMediaType;
        private Uri m_Href = AtomConstants.DefaultUri;
        private string m_Title;
        private LanguageTag m_HrefLang = AtomConstants.DefaultLanguage;
        private int m_Length;

        public int Length
        {
            get { return m_Length; }
            set { m_Length = value; }
        }

        public LanguageTag HrefLang
        {
            get { return m_HrefLang; }
            set { m_HrefLang = value; }
        }
        #region Constructors

        /// <summary>
        /// Represents an <see cref="AtomLink"/> instance.
        /// Initialize the <see cref="HRef"/> to <see cref="AtomConstants.Uri"/>,
        /// <see cref="Title"/> to <see cref="String.Empty"/>,
        /// <see cref="Rel"/> to <see cref="AtomConstants.Rel"/>
        /// and <see cref="Type"/> to <see cref="AtomConstants.MediaType"/>.
        /// </summary>
        public AtomLink()
            : this(AtomConstants.DefaultUri, AtomConstants.DefaultRel, AtomConstants.DefaultMediaType, String.Empty)
        {
        }

        /// <summary>
        /// Represents an <see cref="AtomLink"/> instance initialized with the given <see cref="Uri"/> and title.
        /// </summary>
        /// <param name="href">The <see cref="Uri"/> of the link.</param>
        /// <param name="rel">The <see cref="Relationship"/> of the link.</param>
        /// <param name="type">The <see cref="Type"/> of the link.</param>
        public AtomLink(Uri href, Relationship rel, MimeType type)
            : this(href, rel, type, String.Empty)
        {
        }

        /// <summary>
        /// Represents an <see cref="AtomLink"/> instance initialized with the given <see cref="Uri"/>,
        /// title, <see cref="Relationship"/> and <see cref="Type"/>.
        /// </summary>
        /// <param name="href">The <see cref="Uri"/> of the link.</param>
        /// <param name="rel">The <see cref="Relationship"/> of the link.</param>
        /// <param name="type">The <see cref="Type"/> of the link.</param>
        /// <param name="title">The <see cref="Title"/> of the link.</param>
        public AtomLink(Uri href, Relationship rel, MimeType type, string title)
        {
            this.HRef = href;
            this.Title = title;
            this.Rel = rel;
            this.Type = type;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// The relationship of the link.
        /// </summary>
        public Relationship Rel
        {
            get { return m_Rel; }
            set { m_Rel = value; }
        }

        /// <summary>
        /// The media type of the link.
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
                    value = MimeType.TextPlain;
                else
                    m_Type = value;
            }
        }

        /// <summary>
        /// The url of the link.
        /// </summary>
        public Uri HRef
        {
            get { return m_Href; }
            set { m_Href = value; }
        }

        /// <summary>
        /// The title of the link.
        /// </summary>
        public string Title
        {
            get { return m_Title; }
            set { m_Title = value; }
        }

        #endregion Properties

    }
}
