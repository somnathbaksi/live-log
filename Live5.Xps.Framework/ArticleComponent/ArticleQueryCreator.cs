using System;
using System.Collections.Generic;
using System.Text;
using Live5.Xps.Framework.Core;
namespace Live5.Xps.ArticleComponent
{
   public class ArticleQueryCreator:IQueryCreator
    {
       private ArticleQuery query;
       public IQuery Create()
       {
           query = new ArticleQuery();
           return query;
       }

       #region IQueryCreator Members

       public IQuery Create(string text)
       {
           query = new ArticleQuery();
           query.Title = text;
           query.TermContent.Value = text;
           query.TermTitle.FieldName = "Title";
           query.TermTitle.CompairType = "=";
           query.TermTitle.Value = text;
           return query;
       }

       #endregion
   }
}
