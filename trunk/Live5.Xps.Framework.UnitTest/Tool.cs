using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
namespace Live5.Xps.Framework.UnitTest
{
    public sealed class Tool
    {
        
        public static bool isCopied = false;
        public static void CopyAddIn(TestContext testContext)
        {
           
            if (isCopied)
            {
                return;
            }
            string s = Assembly.GetExecutingAssembly().CodeBase;

            for (int i = 0; i < 4; i++)
            {
                int j = s.LastIndexOf("/");
                s = s.Substring(0, j);
            }
            s = s.Substring(8);
            
            string binPath = Path.GetDirectoryName(s + @"/bin/debug/");
            string addInPath = Path.GetDirectoryName(s+ @"/bin/debug/Addin/");
            //string addInPath = @"F:\XpsProject\Bin\Debug\AddIn\";
            xDirectory xDir = new xDirectory();
            DirectoryInfo dir = new DirectoryInfo(addInPath);

            Directory.CreateDirectory(testContext.TestDeploymentDir + @"\AddIn\");
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo var in files)
            {
                var.CopyTo(testContext.TestDeploymentDir + @"\AddIn\" + var.Name);
            }
            File.Copy(binPath + @"\mediaTypes.txt", testContext.TestDeploymentDir + @"\mediaTypes.txt");
            //xDir.StartCopy(binPath, testContext.TestDeploymentDir);
            isCopied = true;
        }
    }
}
