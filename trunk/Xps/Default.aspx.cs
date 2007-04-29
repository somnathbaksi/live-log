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
using Live5.Xps.Framework.Core;
using Live5.Xps.Framework.Dal;
using Live5.Xps.Framework.BuiltIn;
using Live5.Xps.ArticleComponent;
using Live5.Xps.Framework.External;
using Live5.Xps.Framework;
using System.Xml.Xsl;
using System.Xml;
using System.IO;

public partial class Mock_Ups_Default : System.Web.UI.Page
{
    private Guid queryId;
    public string QueryId
    {
        get
        {
            return queryId.ToString("N");
        }
    }
    protected string FlashVars = "feed=";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FlashVars += "http://localhost:8080/Xps/atom.ashx?q=254c84d2-80ef-48f7-9f50-2ca0acfad155";
            if (queryId == Guid.Empty)
            {
                queryId = new Guid("837740bd-3b62-4f17-8061-678481a04bd6");
            }
            DropDownList1.DataSource = LabelDao.GetLabels();
            DropDownList1.DataTextField = "LabelName";
            DropDownList1.DataValueField = "LabelId";
            DropDownList1.DataBind();

            Guid labelId = new Guid(DropDownList1.SelectedValue);
            QuerySqlProvider p = new QuerySqlProvider();
            Repeater1.DataSource = p.GetLabeledQuery(labelId);
            Repeater1.DataBind();
        }
    }
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal l = e.Item.FindControl("Literal1") as Literal;
            LinkButton lnkBtn = e.Item.FindControl("LinkButton6") as LinkButton;

            IQuery q = e.Item.DataItem as IQuery;
            
            l.Text = "<span style='cursor:pointer' onclick=\"LoadFeed('" + q.Id.ToString("N") + "')\">" + q.Title + "</span>";

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        QueryCreator c = new QueryCreator();
        IQuery q = c.Create(TextBox1.Text.Trim(), DropDownList2.SelectedValue);

        QuerySqlProvider p = new QuerySqlProvider();
        p.SaveTempQuery(q);
        queryId = q.Id;

        //Get feed.
        QueryService s = new QueryService();
        System.Xml.XmlDocument xml = s.GetXmlFeed(queryId.ToString());

        MemoryStream ms = new MemoryStream();
        XslCompiledTransform myXslTransform = new XslCompiledTransform();

        myXslTransform.Load(Request.PhysicalApplicationPath + "/App_Themes/Default/atom_inline.xsl");
        myXslTransform.Transform(xml, null, ms);
        ms.Position = 0;
        TextReader rd = new StreamReader(ms);
        Literal1.Text = rd.ReadToEnd();
        FlashVars += "http://localhost:8080/Xps/atom.ashx?q=" + queryId.ToString();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        QueryCreator c = new QueryCreator();
        IQuery q = c.Create(TextBox1.Text.Trim(), DropDownList2.SelectedValue);

        QuerySqlProvider p = new QuerySqlProvider();
        p.SaveQuery(q);
        queryId = q.Id;
    }

}
