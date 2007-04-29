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
using System.Collections.Generic;
using Live5.Xps.Framework.Model;
using Live5.Xps.Framework.Dal;

public partial class PublishArticle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DropDownList1.DataSource = GetCategories();
            DropDownList1.DataTextField="CategoryName";
            DropDownList1.DataValueField="CategoryId";
            DropDownList1.DataBind();
        }
        else
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
    private IList<Category> GetCategories()
    {
       return CategoryDao.GetCategories();
    }
}
