using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestJQ001
{
    public partial class Fake_MakeBuild : System.Web.UI.Page
    {
        private string rootPath = "~/.";
        private string 
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(Server.MapPath("~/."));
        }
    }
}