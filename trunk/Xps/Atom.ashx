<%@ WebHandler Language="C#" Class="Atom" %>

using System;
using System.Web;
using System.Xml.Xsl;
using Live5.Xps.Framework;
using Live5.Xps.Framework.Atom;
using Live5.Xps.Framework.Model;

public class Atom : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        string qid = context.Request.QueryString["q"];

        context.Response.ContentType = "text/xml";
        QueryService s = new QueryService();
        //IFeed feed =null;
        //if (qid!=null)
        //{
        //   feed = s.GetFeed(qid);
        //}
        //AtomWriter writer = new AtomWriter(context.Response.OutputStream);
        //writer.WriteFeed(feed);

        System.Xml.XmlDocument xml = s.GetXmlFeed(qid);
        // Create a procesing instruction.
        System.Xml.XmlProcessingInstruction newPI;
        String PItext = "type='text/xsl' href='App_Themes/Default/atom03.xsl'";
        newPI = xml.CreateProcessingInstruction("xml-stylesheet", PItext);
        xml.InsertAfter(newPI, xml.ChildNodes[0]);

        //XslTransform myXslTransform;
        //myXslTransform = new XslTransform();
        //myXslTransform.Load("Xps/App_Themes/Default/atom03.xsl");
        //myXslTransform.Transform(xml, null, context.Response.OutputStream); 
        
        
        xml.Save(context.Response.OutputStream);
        context.Response.Flush();
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}