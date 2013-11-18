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
    public partial class GetMessage : System.Web.UI.Page
    {
        private string rootPath = "~/.";
        private string fileName = "temp.txt";
        const int SECOND = 1000;
        string file = string.Empty;
        private static string loading = string.Empty;

        private static string temp = string.Empty;

        public GetMessage()
        {
            file = Path.Combine(Server.MapPath(rootPath), fileName);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string tmp = string.Empty;
            using (FileStream fs = File.Open(file, FileMode.Open, FileAccess.Read, FileShare.Write))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    tmp = sr.ReadToEnd();

                    if (tmp.CompareTo(temp) != 0)
                    {
                        Response.Write(tmp);
                        temp=tmp;
                        loading = string.Empty;
                    }
                    else
                    {
                        loading+=".";
                        Response.Write(temp+loading);
                    }
                }
            }
        }
    }
}