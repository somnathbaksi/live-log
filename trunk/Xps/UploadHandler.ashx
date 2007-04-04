<%@ WebHandler Language="C#" Class="UploadHandler" %>

using System;
using System.Web;
using Live5.Xps.Framework.Utils;
public class UploadHandler : IHttpHandler {
    private string fileName;
    public void ProcessRequest (HttpContext context) {

        HttpFileCollection uploadedFiles = context.Request.Files;
        string ffmpeg = context.Server.MapPath(BaseConfig.AppVirtualPath + "/Bin/ffmpeg.exe");
        string Path = BaseConfig.UploadPhysicalPath;
        for (int i = 0; i < uploadedFiles.Count; i++)
        {
            HttpPostedFile F = uploadedFiles[i];

            if (uploadedFiles[i] != null && F.ContentLength > 0)
            {
                string newName = F.FileName.Substring(F.FileName.LastIndexOf("\\") + 1);
                fileName = Path + "/" + newName;
                F.SaveAs(fileName);
            }
        }
        FlvConvertor converter = new FlvConvertor(ffmpeg);

        converter.Complete += new EventHandler(converter_Complete);
        converter.ConvertFlv(fileName, fileName + ".flv");
        context.Response.ContentType = "text/plain";
        context.Response.Write("Hello World");
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }
    void converter_Complete(object sender, EventArgs e)
    {
        return;
    }

}