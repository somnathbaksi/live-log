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

public partial class ArticleView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string articleId = Request.QueryString["q"];
        PublishService ps = new PublishService();
       Article a= ps.GetEntry(articleId) as Article;
       Label1.Text = a.Content;
    }
}
