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

public partial class PublishArticle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Trace.Write(FCKeditor1.Value);
    }

    protected void FCKeditor1_DataBinding(object sender, EventArgs e)
    {
        bool success=PubArticle();
        Trace.Write(FCKeditor1.Value);
    }
    bool PubArticle()
    {
        Article entry = new Article();
        entry.Summary = "summary";
        entry.Title = "title";
        entry.Content = FCKeditor1.Value;
        PublishService p = new PublishService();
        return p.PutEntry(entry);
    }
}
