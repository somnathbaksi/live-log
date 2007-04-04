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
using Live5.Xps.Framework.External;
using Live5.Xps.Framework.Core;
using System.Xml;
public partial class Mock_Ups_External : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string queryId=string.Empty;
        ExternalQuery q = new ExternalQuery();
         QueryService queryService=new QueryService();
        if (!string.IsNullOrEmpty(Request.Params["q"]))
        {
            queryId = Request.Params["q"];
        }
        else
        {
            q.SourceUrl = "http://tv.mofile.com/cn/rss/rssrecommend.do";
            QuerySqlProvider target = new QuerySqlProvider();
            target.SaveQuery(q);
            queryId=q.Id.ToString();
        }


        XmlDocument rss = queryService.GetXmlFeed(queryId);
         String stylesheet = "type=\"text/xsl\" href=\"/Xps/App_Themes/Default/default.xsl\"";
         XmlProcessingInstruction xslNode = rss.CreateProcessingInstruction("xml-stylesheet", stylesheet);
         rss.InsertBefore(xslNode, rss.DocumentElement);
        this.Response.ClearContent();
       
        this.Response.ContentType = "text/xml";
        this.Response.Output.Write(rss.OuterXml);

        Response.Flush();
        Response.Close();
    }
}
