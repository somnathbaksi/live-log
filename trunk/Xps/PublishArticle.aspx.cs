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
        if (IsPostBack)
        {
            bool success = PubArticle();
            Trace.Write(FCKeditor1.Value);
        }
        
        
    }
    bool PubArticle()
    {
        Article entry = new Article();
        entry.Summary = TextBox1.Text;
        entry.Title = TextBox2.Text;
        entry.Content = FCKeditor1.Value;
        PublishService p = new PublishService();
        return p.PutEntry(entry);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
}
