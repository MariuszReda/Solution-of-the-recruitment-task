using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SpotkajmySie.Range;

namespace SpotkajmySie
{
    public class Calendar
    {
        public Calendar()
        {
            FreeRanges = new List<Range>();
            BusyRanges = new List<Range>();
            
        }

        public Range WorkingHours { get; set; } 
        public List<Range> BusyRanges {get; set; } 
        public List<Range> FreeRanges { get; set; }



        public void CalculateFreeRanges()
        {
            if(BusyRanges[0].Start > WorkingHours.Start)
            {
                FreeRanges.Add(new Range(WorkingHours.Start, BusyRanges[0].Start));
            }
            for(int i = 0; i < BusyRanges.Count()-1; i++)
            {
                FreeRanges.Add(BusyRanges[i].GenerateFreeRange(BusyRanges[i + 1]));
            }

            if (BusyRanges[BusyRanges.Count()-1].End < WorkingHours.End)
            {
                FreeRanges.Add(new Range(BusyRanges[BusyRanges.Count() - 1].End, WorkingHours.End));
            }
        }


    }

}
