using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotkajmySie
{

    public class CalendarManager
    {
        public static List<Range> FindTimeForMetting(Calendar cal1, Calendar cal2, float minutes)
        {
            List<Range> freeRanges = new List<Range>();
            freeRanges.AddRange(cal1.FreeRanges);
            freeRanges.AddRange(cal2.FreeRanges);

            freeRanges.RemoveAll(i => i == null);

            freeRanges.Sort((x, y) => x.Start.CompareTo(y.Start));

            List<Range> intersections = new List<Range>();

            for (int i = 0; i < freeRanges.Count() - 1; i++)
            {
                Range intersection = freeRanges[i].GetInterSection(freeRanges[i + 1]);
                if (intersection == null)
                    continue;
                if (intersection.Duration() >= minutes)
                    intersections.Add(freeRanges[i].GetInterSection(freeRanges[i + 1]));
            }
            return intersections;

        }
    }
}
