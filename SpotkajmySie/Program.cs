using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SpotkajmySie.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SpotkajmySie
{

 
    class Program
    {
        static void Main(string[] args)
        {
            FileDirection file = new FileDirection();
            string path = file.GetFile();

            Calendar cal1 = CalendarBuilder.Build( path + "Input\\calendar1");
            Calendar cal2 = CalendarBuilder.Build( path  + "Input\\calendar2");

            var range = CalendarManager.FindTimeForMetting(cal1, cal2, 30);
            string result = "[";

            for (int i = 0; i < range.Count(); i++)
                result += ($"[{range[i]}]" + ", ").ToString();

            result += "]";
            result = result.Replace("], ]", "]]");
            Console.WriteLine(result);
            //Console.ReadKey();
        }
    }
}


