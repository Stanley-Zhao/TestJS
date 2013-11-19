using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestJQ001
{
    /// <summary>
    /// This page is used to read temp.txt
    /// </summary>
    public partial class GetMessage : System.Web.UI.Page
    {   
        public GetMessage()
        {
            Common.File = Path.Combine(Server.MapPath(Common.RootPath), Common.FileName);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string tmp = string.Empty;
            // when page is called, open temp.txt file as "FileShare.Write" mode
            using (FileStream fs = File.Open(Common.File, FileMode.Open, FileAccess.Read, FileShare.Write))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    tmp = sr.ReadToEnd(); // read to file's end

                    // see if anything new is written in temp.txt
                    if (tmp.CompareTo(Common.Temp) != 0)
                    {
                        // get new information, send it back to frontend with out any "..."
                        Response.Write(tmp);
                        Common.Temp = tmp;
                        Common.Loading = string.Empty;
                    }
                    else
                    {
                        // nothing new, add more "..." in the end of current status
                        Common.Loading+= ".";
                        Response.Write(Common.Temp + Common.Loading);
                    }
                }
            }
        }
    }
}