using System;
using System.Collections.Generic;
using System.Text;
using Live5.Xps.Framework.Core;
namespace Live5.Xps.Framework.BuiltIn
{
   public class BuiltInQueryCreator:IQueryCreator
    {

       public BuiltInQueryCreator()
       {
           // Protect to be instancialized.
       }

        #region IQueryCreator Members

       public IQuery Create(string text)
        {
            BuiltInQuery q = new BuiltInQuery();
            q.Title = text;
            q.HasText.Value = text;
            q.HasText.FieldName = "Text";
            return q;
        }

        #endregion
    }
}
