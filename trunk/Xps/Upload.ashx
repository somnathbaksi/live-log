<%@ WebHandler Language="C#" Class="Live5.LiveUpload.Upload" %>

using System;
using System.Web;
namespace Live5.LiveUpload
{
    /// <summary>
    /// An HttpHandler to handler flash upload requests.
    /// </summary>
    public class Upload : IHttpHandler
    {
        #region IHttpHandler Members

        /// <summary>
        /// Handle the request.
        /// </summary>
        /// <param name="context">Current http context.</param>
        public void ProcessRequest(HttpContext context)
        {

            if (context.Request.Files.Count > 0)
            {
                // Gets application physical path.
                string physicalPath =BaseConfig.UploadPhysicalPath;

                // Saves all uploaded files.
                for (int i = 0; i < context.Request.Files.Count; i++)
                {
                    HttpPostedFile uploadFile = context.Request.Files[i];

                    if (uploadFile.ContentLength > 0)
                    {
                        // Note that the flash will only send the file name to server,
                        // unlike standard form sends file name and local path. So we just append file name to the path.
                        uploadFile.SaveAs(physicalPath + uploadFile.FileName);
                    }
                }
            }

            // Used to address a bug in mac flash player that makes the 
            // onComplete event not fire
            context.Response.ContentType = "text/plain";
            context.Response.Write("Succeed");
        }

        /// <summary>
        /// Indicates whether the handler is reusable or not.
        /// </summary>
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        #endregion
    }
}