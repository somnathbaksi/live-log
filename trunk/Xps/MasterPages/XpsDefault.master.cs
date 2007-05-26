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

public partial class Mock_Ups_XpsDefault : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
      MembershipUser u =  Membership.GetUser();
      if (u!=null)
      {
          Label1.Text = Page.User.Identity.Name;
      }
    }
}
