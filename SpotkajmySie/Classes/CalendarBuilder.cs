using Newtonsoft.Json;
using Newtonsoft.Json.Linq; //nuget
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotkajmySie
{
    public class CalendarBuilder    
    {

        //This internal class is only for parsing purposes
        internal class TimeSpanRecord   
        {
            public string start { get; set; }
            public string end { get; set; }

        }

        public static Calendar Build(string jsonPath)
        {
            Calendar cal = new Calendar();

          using (StreamReader file = File.OpenText(jsonPath + ".json"))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                //JSON parse c#
                JObject o2 = (JObject)JToken.ReadFrom(reader);
                cal.WorkingHours = new Range(TimeSpan.Parse(o2["working_hours"]["start"].ToString()), TimeSpan.Parse(o2["working_hours"]["end"].ToString()));

                List<TimeSpanRecord> busyRanges = JsonConvert.DeserializeObject<List<TimeSpanRecord>>(o2["planned_meeting"].ToString());    //convert json to list busyRanges c# 

                foreach (TimeSpanRecord t in busyRanges)
                {
                    cal.BusyRanges.Add(new Range(TimeSpan.Parse(t.start), TimeSpan.Parse(t.end)));
                }
            }

            cal.BusyRanges.Sort((x, y) => x.Start.CompareTo(y.Start));
            cal.CalculateFreeRanges();

            return cal;
        }
    }

}
