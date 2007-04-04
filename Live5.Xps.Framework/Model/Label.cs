using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Live5.Xps.Framework.Model
{
    public class Label
    {
        private Guid m_LabelId;

        public Guid LabelId
        {
            get { return m_LabelId; }
            set { m_LabelId = value; }
        }
        private string m_LabelName;

        public string LabelName
        {
            get { return m_LabelName; }
            set { m_LabelName = value; }
        }
        public Label(IDataRecord dr)
        {
            for (int i = 0; i < dr.FieldCount; i++)
            {
                if (dr.GetName(i).Equals("LabelId", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (!dr.IsDBNull(i))
                    {
                        m_LabelId = dr.GetGuid(i);
                    }
                }
                if (dr.GetName(i).Equals("LabelName", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (!dr.IsDBNull(i))
                    {
                        m_LabelName = dr.GetString(i);
                    }
                }
            }
        }

    }
}
