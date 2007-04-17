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
        string withStyle = context.Request.QueryString["style"];
        bool style = true;
        if (!string.IsNullOrEmpty(withStyle))
        {
            style = bool.Parse(withStyle);
        }
     
      
        QueryService s = new QueryService();
        //IFeed feed =null;
        //if (qid!=null)
        //{
        //   feed = s.GetFeed(qid);
        //}
        //AtomWriter writer = new AtomWriter(context.Response.OutputStream);
        //writer.WriteFeed(feed);

        System.Xml.XmlDocument xml = s.GetXmlFeed(qid);
        if (style)
        {
            context.Response.ContentType = "text/html";
            XslCompiledTransform myXslTransform=new XslCompiledTransform();
           
            myXslTransform.Load(context.Request.PhysicalApplicationPath+"/App_Themes/Default/atom03.xsl");
            myXslTransform.Transform(xml, null, context.Response.OutputStream); 
        
        }
        else
        {
            context.Response.ContentType = "text/xml";
            // Create a procesing instruction.
            System.Xml.XmlProcessingInstruction newPI;
            String PItext = "type='text/xsl' href='App_Themes/Default/atom03.xsl'";
            newPI = xml.CreateProcessingInstruction("xml-stylesheet", PItext);
            xml.InsertAfter(newPI, xml.ChildNodes[0]);

        }
       
      
        
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