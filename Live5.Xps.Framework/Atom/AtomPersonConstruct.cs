/* 
  	* AtomPersonConstruct.cs
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
	/// The class representing all person constructs.
	/// </summary>
	[Serializable]
	public class AtomPersonConstruct 
	{
        private Guid m_Id;
        private string m_Name;
        private Uri m_Uri ;
        private string m_Email;


		#region Properties


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

		/// <summary>
		/// The name of the person.
		/// </summary>
		public string Name
		{
			get { return m_Name; }
			set { m_Name = value; }
		}

		/// <summary>
		/// The email of the person.
		/// </summary>
		public string Email
		{
			get { return m_Email; }
			set
			{
                if (Utils.IsEmail(value))
                {
                    m_Email = value;
                }
			}
		}

        public Uri Uri
        {
            get
            {
                if (m_Uri == null)
                {
                   m_Uri= AtomConstants.DefaultUri;
                }
                return m_Uri;
            }
            set { m_Uri = value; }
        }
 
		#endregion Properties
	}
}
