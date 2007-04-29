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
using Live5.Xps.Framework.Model;
using System.Collections.Generic;
using Live5.Xps.Framework.Dal;
using Live5.Xps.Framework.BuiltIn;
using Live5.Xps.Framework.Core;
using Live5.Xps.ArticleComponent;
using Live5.Xps.Framework.External;
public partial class QueryEditor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //    this.DataList1.DataSource = QuerySqlProvider.GetAllQuery();
        //    this.DataList1.DataBind();
        //}
        if (!IsPostBack)
        {
            this.Repeater1.DataSource = QuerySqlProvider.GetAllQuery();
            this.Repeater1.DataBind();
        }
      
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        QueryCreator c = new QueryCreator();
        IQuery q = c.Create(TextBox1.Text.Trim(), DropDownList1.SelectedValue);
        QueryExecutor ex = new QueryExecutor();
       
      // QuerySqlProvider p = new QuerySqlProvider();
      // IQuery q2= p.GetQuery<BuiltInQuery>(new Guid("c8ab16ad-1d06-4265-8ddd-469b303a82d0"));
       //p.SaveQuery(q);
       IFeed f = ex.Execute(q);
       //IList<IEntry> entries = ex.GetEntryList(q);
        this.GridView1.DataSource = f.EntryList;
        this.GridView1.DataBind();
        this.Repeater1.DataSource = QuerySqlProvider.GetAllQuery();
        this.Repeater1.DataBind();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {

        QueryCreator c = new QueryCreator();
        IQuery q = c.Create(TextBox1.Text.Trim(), DropDownList1.SelectedValue);
        QueryExecutor ex = new QueryExecutor();

        // QuerySqlProvider p = new QuerySqlProvider();
        // IQuery q2= p.GetQuery<BuiltInQuery>(new Guid("c8ab16ad-1d06-4265-8ddd-469b303a82d0"));
        //p.SaveQuery(q);
  
        QuerySqlProvider p = new QuerySqlProvider();
        p.SaveQuery(q);

        IFeed f = ex.Execute(q);
        this.GridView1.DataSource = f.EntryList;
        this.GridView1.DataBind();
        this.Repeater1.DataSource = QuerySqlProvider.GetAllQuery();
        this.Repeater1.DataBind();
       
    }

    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        
        
      HyperLink link =  e.Item.FindControl("HyperLink1") as HyperLink;
      IQuery q= e.Item.DataItem as IQuery;
      link.Text = q.Title;
      link.NavigateUrl = "atom.ashx?q=" + q.Id.ToString("N");
      link.Target = "_blank";
    }
}
