using NUnit.Framework;
using SpotkajmySie.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotkajmySie.Tests
{
    [TestFixture]
    public class CalendarTests
    {
        [TestCase]
        public void CalendarTest()
        {

            Calendar cal1 = CalendarBuilder.Build(@"C:\Users\mariu\Desktop\SpotkajmySie\SpotkajmySie\Input\Tests\calendar3");
            Calendar cal2 = CalendarBuilder.Build(@"C:\Users\mariu\Desktop\SpotkajmySie\SpotkajmySie\Input\Tests\calendar4");

            var range = CalendarManager.FindTimeForMetting(cal1, cal2, 30);

            Assert.AreEqual(1, range.Count());
            Assert.AreEqual(new TimeSpan(11, 10, 0), range[0].Start);
            Assert.AreEqual(new TimeSpan(11, 40, 0), range[0].End);
        }
    }
}
