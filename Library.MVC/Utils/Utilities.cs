using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Library.MVC.Utils
{
    public static class Utilities
    {
        public static string AddTimpestampToFileName(string fileName)
        {
            var extension = Path.GetExtension(fileName);
            return $"_{DateTime.Now.Ticks}{extension}";
        }
    }
}