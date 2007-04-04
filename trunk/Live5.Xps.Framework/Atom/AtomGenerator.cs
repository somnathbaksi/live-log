using System;
using System.Collections.Generic;
using System.Text;

namespace Live5.Xps.Framework.Atom
{
    public class AtomGenerator 
    {
        private string m_Text;
        private Uri m_Uri;
        private string m_Version;

        #region Constructor

        internal AtomGenerator()
        {
            this.m_Text = AtomConstants.GeneratorMessage;
            this.m_Uri = AtomConstants.GeneratorUri;
            this.m_Version = AtomConstants.GeneratorVersion;
        }

        #endregion Constructor

       
    }
}
