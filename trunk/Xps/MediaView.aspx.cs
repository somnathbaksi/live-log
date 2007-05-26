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
using Live5.Xps.Framework.Core;
public partial class MediaView:System.Web.UI.Page
{
    protected string FlashVars = "feed=";
    protected string FeedUrl;
    protected void Page_Load(object sender, EventArgs e)
    {
        string qid = Request.QueryString["q"];
        IQuery q =  QueryService.CreateSingleEntryQuery(new Guid(qid), "Live5.Xps.MediaComponent.MediaService");
        FeedUrl = "http://localhost:8080/Xps/atom.ashx?q=" + q.Id.ToString();
        FlashVars = FlashVars+"http://localhost:8080/Xps/atom.ashx?q=" + q.Id.ToString()+"&style=false";
    }
}
