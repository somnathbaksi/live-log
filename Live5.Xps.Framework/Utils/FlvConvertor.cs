using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Web;
using System.IO;

namespace Live5.Xps.Framework.Utils
{
    public class FlvConvertor
    {
        string ffmpegPath;
        public event EventHandler Complete;
        public void ConvertFlv(string inputFile, string outputFile)
        {
            //string binPath = HttpContext.Current.Server.MapPath("/Bin");
            Process p = new Process();
            Environment.CurrentDirectory = Path.GetDirectoryName(ffmpegPath);
            p.StartInfo = new ProcessStartInfo(ffmpegPath, " -i " + inputFile + " "+ outputFile);
            p.EnableRaisingEvents = true;
            
            p.Exited += new EventHandler(p_Exited);
            p.Start();

        }
        public FlvConvertor(string ffmpegPath)
        {
            this.ffmpegPath = ffmpegPath;
        }

        private void p_Exited(object sender, EventArgs e)
        {
            OnComplete(sender, e);
        }
        private void OnComplete(object sender, EventArgs e)
        {
            if (Complete != null)
            {
                Complete(this, e);
            }
        }
    }
}
