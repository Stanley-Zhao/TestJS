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
    /// <summary>
    /// This page is used to write "Fake" build process into temp.txt file
    /// </summary>
    public partial class Fake_MakeBuild : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Common.File = Path.Combine(Server.MapPath(Common.RootPath), Common.FileName); // get whole file path, absolute path

            if (File.Exists(Common.File)) // delete old file
                File.Delete(Common.File);

            new Thread(new ThreadStart(DoBuild)).Start(); // start a new thread to make the "Fake" build
        }

        private void DoBuild()
        {
            DateTime start = DateTime.Now; // start date time

            // ** Start ** to write the file
            File.AppendAllText(Common.File, "** Start to make Build**</br>");
            Thread.Sleep(Common.SECOND); // wait 1 sec, simulate the start process
            File.AppendAllText(Common.File, "Step 1 - Try to get latest codes from TFS.</br>");
            Thread.Sleep(Common.SECOND * 30); // wait 30 secs, simulate the process about getting codes
            File.AppendAllText(Common.File, "Step 2 - Try to make build of Tradex.</br>");
            Thread.Sleep(Common.SECOND * 20); // wait 20 secs, simulate the process about building projects
            File.AppendAllText(Common.File, "Step 3 - ZIP Tradex build to package.</br>");
            Thread.Sleep(Common.SECOND * 5); // wait 5 secs, simulate the process about making package
            File.AppendAllText(Common.File, "Step 4 - Upload ZIP package to shared folder.</br>");
            File.AppendAllText(Common.File, "** END to make Build**</br></br>");
            // ** END ** about writing file

            TimeSpan ts = DateTime.Now - start;
            File.AppendAllText(Common.File, string.Format("[[  Used time: {0} mins, {1} secs  ]]", ts.Minutes.ToString(), ts.Seconds.ToString())); // show END information and how much time it is to make build
        }
    }
}