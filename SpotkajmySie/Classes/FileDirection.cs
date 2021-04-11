using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotkajmySie.Classes
{
    class FileDirection
    {
        static string filePath;

        public string GetFile()
        {
            string[] x = System.Environment.CurrentDirectory.Split('\\');
            string filePath = "";
            for (int i = 0; i <= 5; i++)
            {
                filePath += x[i] + "\\";
            }
            return filePath;
        }
    }
}
