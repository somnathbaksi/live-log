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
using System.Collections.Generic;

public partial class Admin_QueryManage : System.Web.UI.Page
{
    HiddenField hfQueryId;
    Label lblQueryTitle;
    Button btnExport;
    CheckBox chxQuerySelected;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.Repeater1.DataSource = QuerySqlProvider.GetAllQuery();
            this.Repeater1.DataBind();
            this.DropDownList1.DataSource = Live5.Xps.Framework.Dal.LabelDao.GetLabels();
            this.DropDownList1.DataTextField = "LabelName";
            this.DropDownList1.DataValueField = "LabelId";
            this.DropDownList1.DataBind();
        }
    }
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType==ListItemType.Item||e.Item.ItemType==ListItemType.AlternatingItem)
        {
            BindControls(e.Item);
            IQuery q=e.Item.DataItem as IQuery;
            hfQueryId.Value = q.Id.ToString();
            lblQueryTitle.Text = q.Title;
            btnExport.CommandArgument = q.Id.ToString();
        }
    }
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Export":
                QuerySqlProvider p = new QuerySqlProvider();
                Guid qid = new Guid(e.CommandArgument.ToString());
                p.ExportQuery(qid,BaseConfig.AppPhysicalPath+ "/Querys/");
                break;
            default:
                break;
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        IList<Guid> queries = new List<Guid>();
        for (int i = 0; i < Repeater1.Items.Count; i++)
        {
            BindControls(Repeater1.Items[i]);
            if (chxQuerySelected.Checked)
            {
                queries.Add(new Guid(hfQueryId.Value));
            }
        }
        if (queries.Count>0)
        {
            Guid labelId = new Guid(DropDownList1.SelectedValue);
            Live5.Xps.Framework.Dal.LabelDao.ApplyLabel(labelId, queries);
        }

    }

    private void BindControls(RepeaterItem item){
        chxQuerySelected = item.FindControl("CheckBox1") as CheckBox;
        hfQueryId = item.FindControl("HiddenField1") as HiddenField;
        lblQueryTitle = item.FindControl("Label1") as Label;
        btnExport = item.FindControl("Button1") as Button;
    }
}
