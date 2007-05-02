using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Live5.Xps.Framework.Utils;
using Live5.Xps.Framework.Core;
using Live5.Xps.Framework.Model;

namespace Live5.Xps.Framework.Dal
{
   public class CategoryDao
    {
        public static IList<Category> GetCategories()
        {
            IList<Category> categories = null;
            IDataReader dr = SqlDbTool.ExecuteQuery(Constants.Sp_GetCategories);
            while (dr.Read())
            {
                if (categories == null)
                {
                    categories = new List<Category>();
                }
                Category category = new Category(dr);
                categories.Add(category);
            }
            return categories;
        }
    }
}
