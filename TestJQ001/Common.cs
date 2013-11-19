using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestJQ001
{
    public static class Common
    {
        public static string RootPath = "~/."; // the root absolute path of current page
        public static string FileName = "temp.txt"; // default file name
        public const int SECOND = 1000; // a second
        public static string File = string.Empty; // file name
        public static string Loading = string.Empty; // used for making "...."
        public static string Temp = string.Empty; // used for storing temp text string
    }
}