using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web;
namespace Live5.Xps.Framework.Utils
{
    public class AppRuntimeEnv
    {
        public static string AppBase
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory;
            }
        }
        public static string AddInPath
        {
            //Todo:Bug: Cannot get right path when running in Web enviroment.
            get
            {
                string addIn = null;
                if (HttpContext.Current!=null)
                {
                    addIn = "Bin/AddIn";
                }
                else
                {
                    addIn = "AddIn";
                }
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, addIn);
            }
        }
        public static string ExceptionPolicyConfig_GlobalPolicy
        {
            get
            {
                return "Global Policy";
            }
        }
    }
}
