using System;
using System.Collections.Generic;
using System.Text;
using Live5.Xps.Framework;
using Live5.Xps.Framework.Model;
using System.Data;
using Live5.Xps.Framework.Core;
namespace Live5.Xps.ArticleComponent
{
    public class Article:Entry
    {
        public Article()
        {
        }
        public Article(IDataRecord dr):base(dr)
        {
            int fieldIndex = dr.GetOrdinal("Content");

            if (!dr.IsDBNull(fieldIndex))
            {
                this.Content = dr.GetString(fieldIndex);
            }
        }
        public override string ServiceType
        {
            get
            {
                return ServiceConfig.ServiceType;
            }
            set
            {
                base.ServiceType = value;
            }
        }
        public override Uri Id
        {
            get
            {
                return new Uri(Constants.DefaultUri, "articleview.aspx?q=" + EntryId.ToString());
            
            }
            set
            {
                base.Id = value;
            }
        }
    }
}
