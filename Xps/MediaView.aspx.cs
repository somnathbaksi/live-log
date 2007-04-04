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

public partial class MediaView:System.Web.UI.Page
{
    protected string FlashVars = "feed=";
    protected void Page_Load(object sender, EventArgs e)
    {
        FlashVars += "http://localhost:8080/Xps/atom.ashx?q=254c84d2-80ef-48f7-9f50-2ca0acfad155";
    }
}
