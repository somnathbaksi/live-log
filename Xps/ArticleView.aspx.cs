using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Live5.Xps.Framework;
using Live5.Xps.ArticleComponent;
using Live5.Xps.Framework.Model;

public partial class ArticleView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string articleId = Request.QueryString["q"];
       IFeed feed =QueryService.SearchSingleEntry(new Guid(articleId), "Live5.Xps.ArticleComponent.ArticleService");
       foreach (IEntry var in feed.EntryList)
       {
           Label1.Text+=var.Content;
       }

    }
}
