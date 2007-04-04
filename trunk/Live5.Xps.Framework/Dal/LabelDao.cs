using System;
using System.Collections.Generic;
using System.Text;
using Live5.Xps.Framework.Model;
using Live5.Xps.Framework.Utils;
using Live5.Xps.Framework.Core;
using System.Data;

namespace Live5.Xps.Framework.Dal
{
    public class LabelDao
    {
        public static IList<Label> GetLabels()
        {
            IList<Label> labels = null;
            IDataReader dr = SqlDbTool.ExecuteQuery(Constants.Sp_GetLabels);
            while (dr.Read())
            {
                if (labels == null)
                {
                    labels = new List<Label>();
                }
                Label label = new Label(dr);
                labels.Add(label);
            }
            return labels;
        }
        public static int ApplyLabel(Guid labelId, IList<Guid> queries)
        {
            int result = 0;
            foreach (Guid query in queries)
            {
                result=SqlDbTool.ExecuteNonQuery(Constants.Sp_ApplyLabel, labelId, query);
            }
            return result;
        }
    }
}
