using System;
using System.Collections.Generic;
using System.Text;

namespace Live5.Xps.Framework.Atom
{
    public class AtomCategory
    {
        private string m_Term;

        public string Term
        {
            get { return m_Term; }
            set { m_Term = value; }
        }
        private string  m_Label;

        public string  Label
        {
            get { return m_Label; }
            set { m_Label = value; }
        }
        private Uri m_Scheme;

        public Uri Scheme
        {
            get { return m_Scheme; }
            set { m_Scheme = value; }
        }

        private string m_UndefinedContent;

        public string UndefinedContent
        {
            get { return m_UndefinedContent; }
            set { m_UndefinedContent = value; }
        }

    }
}
