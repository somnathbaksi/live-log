using System;
using System.Collections.Generic;
using System.Text;

namespace Live5.Xps.Framework.Core
{
    [Serializable]
   public class QueryItem<TValue>
    {
        private string m_FieldName;

        public string FieldName
        {
            get { return m_FieldName; }
            set { m_FieldName = value; }
        }
        private string m_CompairType;

        public string CompairType
        {
            get { return m_CompairType; }
            set { m_CompairType = value; }
        }
        private TValue m_Value;

        public TValue Value
        {
            get { return m_Value; }
            set { m_Value = value; }
        }

       private bool m_IsEmpty;
       public bool IsEmpty
       {
           get
           {
               return m_IsEmpty;
           }
           set
           {
               m_IsEmpty = value;
           }
       }

    }
}
