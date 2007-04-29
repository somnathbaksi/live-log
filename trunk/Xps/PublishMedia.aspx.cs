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
using Live5.Xps.Framework.Utils;
using Live5.Xps.ArticleComponent;
using Live5.Xps.Framework.Model;
using Live5.Xps.MediaComponent;
using Live5.Xps.Framework;
public partial class Publish : System.Web.UI.Page
{
    private string fileName;
    protected string FlashVars = "uploadPage=";
    protected void Page_Load(object sender, System.EventArgs e)
    {
        FlashVars += Request.ApplicationPath + "/Upload.ashx";
        Label1.Text = BaseConfig.AppVirtualPath + BaseConfig.UploadPath;
        Label1.Text += BaseConfig.UploadPhysicalPath;

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        bool success = false;

        switch (this.DropDownList1.SelectedValue)
        {
            case "Article":

                success = PublishArticle();
                break;
            case "Media":
                success = PublishMedia();
                break;
            default:
                break;
        }



        if (success)
        {
            Label1.Text += "Success";
            //this.TextBox4.Text = XmlTool.ObjectToXml(entry).InnerText;
        }

    }
    bool PublishMedia()
    {
        Media entry = new Media();
        entry.Summary = this.TextBox2.Text;
        entry.Title = this.TextBox3.Text;
        entry.Content = this.TextBox1.Text;
        entry.ContentMediaType.SetType(DropDownList2.SelectedValue);
        PublishService p = new PublishService();

        return p.PutEntry(entry);
    }
    bool PublishArticle()
    {
        Article entry = new Article();
        entry.Summary = this.TextBox2.Text;
        entry.Title = this.TextBox3.Text;
        entry.Content = this.TextBox1.Text;
        PublishService p = new PublishService();
        return p.PutEntry(entry);
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedValue=="Media")
        {
            DropDownList2.Visible = true;
        }
        else
        {
            DropDownList2.Visible = false;
        }
    }
}
