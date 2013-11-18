using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestJQ001
{
    public partial class Fake_MakeBuild : System.Web.UI.Page
    {
        private string rootPath = "~/.";
        private string fileName = "temp.txt";
        const int SECOND = 1000;
        string file = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            file = Path.Combine(Server.MapPath(rootPath), fileName);

            if (File.Exists(file))
                File.Delete(file);

            new Thread(new ThreadStart(DoBuild)).Start();
        }

        private void DoBuild()
        {
            DateTime start = DateTime.Now;

            File.AppendAllText(file, "** Start to make Build**</br>");
            Thread.Sleep(SECOND);
            File.AppendAllText(file, "Step 1 - Try to get latest codes from TFS.</br>");
            Thread.Sleep(SECOND * 30);
            File.AppendAllText(file, "Step 2 - Try to make build of Tradex.</br>");
            Thread.Sleep(SECOND * 20);
            File.AppendAllText(file, "Step 3 - ZIP Tradex build to package.</br>");
            Thread.Sleep(SECOND * 5);
            File.AppendAllText(file, "Step 4 - Upload ZIP package to shared folder.</br>");
            File.AppendAllText(file, "** END to make Build**</br></br>");

            TimeSpan ts = DateTime.Now - start;
            File.AppendAllText(file, string.Format("[[  Used time: {0} mins, {1} secs  ]]", ts.Minutes.ToString(), ts.Seconds.ToString()));
        }
    }
}