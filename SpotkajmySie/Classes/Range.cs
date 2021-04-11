using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotkajmySie
{
    public class Range
    {
        public Range(TimeSpan start, TimeSpan end)
        {
            Start = start;
            End = end;
        }

        public Range(string start, string end)
        {
            Start = TimeSpan.Parse(start);
            End = TimeSpan.Parse(end);
        }

        public Range(int startHours, int startMinutes, int startSeconds, int endHours, int endMinutes, int endSeconds)
        {
            Start = new TimeSpan(startHours, startMinutes, startSeconds);
            End = new TimeSpan(endHours, endMinutes, endSeconds);
        }

        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }

        public override string ToString()
        {
            return ($"\"{Start.ToString(@"hh\:mm")}\"" + ", " + $"\"{End.ToString(@"hh\:mm")}\"");
        }

        public double Duration()
        {
            double x = End.Subtract(Start).TotalMinutes;
            return x;
        }
        public Range GetInterSection(Range range)
        {
            if (this.Start >= range.End)
            {
                return null;
            }
            else if (this.Start < range.End && this.End > range.End)
            {
                if (range.Start >= this.Start)
                    return range;
                else
                    return new Range(this.Start, range.End);
            }
            else if (range.Start >= this.Start && range.End <= this.End)
            {
                return range;
            }
            else if (range.End > this.End && range.Start <= this.End)
            {
                if (range.Start < this.Start)
                    return this;
                else if (range.Start == this.End)
                    return null;
                else
                    return new Range(range.Start, this.End);
            }
            else return null;

        }

        public Range GenerateFreeRange(Range range)
        {
            if (this.Start > range.Start && this.Start > range.End)
            {
                return new Range(range.End, this.Start);
            }

            if (this.End < range.Start)
            {
                return new Range(this.End, range.Start);
            }

            else
                return null;            
        }

    }

}
