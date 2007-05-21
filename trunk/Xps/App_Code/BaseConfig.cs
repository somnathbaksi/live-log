using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Configuration;

/// <summary>
/// Summary description for BaseConfig
/// </summary>
public class BaseConfig
{
    public BaseConfig()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static string AppFullPath
    {
        get
        {
            int appPathIndex = HttpContext.Current.Request.Url.AbsoluteUri.IndexOf(AppVirtualPath);
            return HttpContext.Current.Request.Url.AbsoluteUri.Substring(0,appPathIndex);
        }
    }
    public static string AppVirtualPath
    {
        get
        {
           return HttpContext.Current.Request.ApplicationPath;
        }
    }
    public static string AppPhysicalPath
    {
        get
        {
            return HttpContext.Current.Server.MapPath(AppVirtualPath) ;
        }
    }
    public static string UploadPath
    {
        get
        {
           return AppVirtualPath +WebConfigurationManager.AppSettings["UploadPath"];
        }
    }
    public static string UploadPhysicalPath
    {
        get
        {
             return HttpContext.Current.Server.MapPath(UploadPath);
        }
    }
}
