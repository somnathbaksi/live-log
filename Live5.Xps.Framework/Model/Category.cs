using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Live5.Xps.Framework.Model
{
   public  class Category
    {
        private Guid m_CategoryId;

        public Guid CategoryId
        {
            get { return m_CategoryId; }
            set { m_CategoryId = value; }
        }

        private string m_CategoryName;

        public string CategoryName
        {
            get { return m_CategoryName; }
            set { m_CategoryName = value; }
        }
        private string m_Description;

        public string Description
        {
            get { return m_Description; }
            set { m_Description = value; }
        }
       public Category(IDataRecord dr)
       {
           for (int i = 0; i < dr.FieldCount; i++)
           {
               if (dr.GetName(i).Equals("CategoryId", StringComparison.InvariantCultureIgnoreCase))
               {
                   if (!dr.IsDBNull(i))
                   {
                       m_CategoryId = dr.GetGuid(i);
                   }
                   continue;
               }
               if (dr.GetName(i).Equals("CategoryName", StringComparison.InvariantCultureIgnoreCase))
               {
                   if (!dr.IsDBNull(i))
                   {
                       m_CategoryName = dr.GetString(i);
                   }
                   continue;
               }
               if ((dr.GetName(i).Equals("Description",StringComparison.InvariantCultureIgnoreCase)))
               {
                    if (!dr.IsDBNull(i))
                   {
                       m_Description = dr.GetString(i);
                   }
                   continue;
               }
           }
       }

    }
}
