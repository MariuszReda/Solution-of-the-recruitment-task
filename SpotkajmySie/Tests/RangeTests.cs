using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotkajmySie.Tests
{
    [TestFixture]
   public class RangeTests
    {
        [TestCase]
        public void RangeTestIntersection()
        {

            //1
            //            _____
            //   _____

            Range r11 = new Range(new TimeSpan(12, 0, 0), new TimeSpan(13, 0, 0));
            Range r12 = new Range(new TimeSpan(9, 0, 0), new TimeSpan(10, 0, 0));

            Assert.AreEqual(null, r11.GetInterSection(r12));

            //2
            //        _____
            //   _____

            Range r13 = new Range(new TimeSpan(12, 0, 0), new TimeSpan(13, 0, 0));
            Range r14 = new Range(new TimeSpan(11, 0, 0), new TimeSpan(12, 0, 0));

            Assert.AreEqual(null, r13.GetInterSection(r14));


            //3
            //      _____
            //   _____

            Range r15 = new Range(new TimeSpan(12, 30, 0), new TimeSpan(13, 30, 0));
            Range r16 = new Range(new TimeSpan(12, 0, 0), new TimeSpan(13, 0, 0));

            Assert.AreEqual(new TimeSpan(12, 30, 0), r15.GetInterSection(r16).Start);
            Assert.AreEqual(new TimeSpan(13, 00, 0), r15.GetInterSection(r16).End);

            //4
            //      _____
            //      ___

            Range r17 = new Range(new TimeSpan(12, 30, 0), new TimeSpan(13, 30, 0));
            Range r18 = new Range(new TimeSpan(12, 30, 0), new TimeSpan(13, 0, 0));

            Assert.AreEqual(new TimeSpan(12, 30, 0), r17.GetInterSection(r18).Start);
            Assert.AreEqual(new TimeSpan(13, 00, 0), r17.GetInterSection(r18).End);


            //5
            //_______
            //  ___
            Range r7 = new Range(new TimeSpan(9, 30, 0), new TimeSpan(10, 30, 0));
            Range r8 = new Range(new TimeSpan(9, 45, 0), new TimeSpan(10, 15, 0));

            Assert.AreEqual(new TimeSpan(9, 45, 0), r7.GetInterSection(r8).Start);
            Assert.AreEqual(new TimeSpan(10, 15, 0), r7.GetInterSection(r8).End);

            //6
            //_______
            //    ___
            Range r20 = new Range(new TimeSpan(9, 0, 0), new TimeSpan(10, 0, 0));
            Range r21 = new Range(new TimeSpan(9, 45, 0), new TimeSpan(10, 0, 0));

            Assert.AreEqual(new TimeSpan(9, 45, 0), r20.GetInterSection(r21).Start);
            Assert.AreEqual(new TimeSpan(10, 0, 0), r20.GetInterSection(r21).End);

            //7
            //_____
            //   _____

            Range r1 = new Range(new TimeSpan(9, 0, 0), new TimeSpan(10, 10, 0));
            Range r2 = new Range(new TimeSpan(9, 30, 0), new TimeSpan(10, 15, 0));

            Assert.AreEqual(new TimeSpan(9, 30, 0), r1.GetInterSection(r2).Start);
            Assert.AreEqual(new TimeSpan(10, 10, 0), r1.GetInterSection(r2).End);

            //8
            //_____
            //   _____

            Range r5 = new Range(new TimeSpan(9, 30, 0), new TimeSpan(10, 00, 0));
            Range r6 = new Range(new TimeSpan(9, 45, 0), new TimeSpan(10, 00, 0));

            Assert.AreEqual(new TimeSpan(9, 45, 0), r5.GetInterSection(r6).Start);
            Assert.AreEqual(new TimeSpan(10, 0, 0), r5.GetInterSection(r6).End);

            //9
            //_____
            //     _____

            Range r3 = new Range(new TimeSpan(9, 15, 0), new TimeSpan(10, 00, 0));
            Range r4 = new Range(new TimeSpan(10, 0, 0), new TimeSpan(10, 15, 0));

            Assert.AreEqual(null, r3.GetInterSection(r4));

       

            //10
            //_______
            //          ______
            Range r9 = new Range(new TimeSpan(9, 0, 0), new TimeSpan(10, 0, 0));
            Range r10 = new Range(new TimeSpan(12, 0, 0), new TimeSpan(13, 0, 0));

            Assert.AreEqual(null, r9.GetInterSection(r10));


            //11
            //   _____
            // _________

            Range r23 = new Range(new TimeSpan(9, 30, 0), new TimeSpan(10, 00, 0));
            Range r24 = new Range(new TimeSpan(9, 0, 0), new TimeSpan(10, 30, 0));

            Assert.AreEqual(new TimeSpan(9, 30, 0), r23.GetInterSection(r24).Start);
            Assert.AreEqual(new TimeSpan(10, 0, 0), r23.GetInterSection(r24).End);




        }
    

        [TestCase]
        public void RangeTestFreeRange()
        {
            //1
            //               12_____13
            //         10____12 <- Wolny czas ma zwrocic
            //   9_____10

            Range r1 = new Range(new TimeSpan(12, 0, 0), new TimeSpan(13, 0, 0));
            Range r2 = new Range(new TimeSpan(9, 0, 0), new TimeSpan(10, 0, 0));

            Assert.AreEqual(new TimeSpan(10, 0, 0), r1.GenerateFreeRange(r2).Start);
            Assert.AreEqual(new TimeSpan(12, 0, 0), r1.GenerateFreeRange(r2).End);


            //2
            //        12_____13
            // 11_____12

            Range r3 = new Range(new TimeSpan(12, 0, 0), new TimeSpan(13, 0, 0));
            Range r4 = new Range(new TimeSpan(11, 0, 0), new TimeSpan(12, 0, 0));

            Assert.AreEqual(null, r3.GenerateFreeRange(r4));

            //4
            //      _____
            //      ___

            Range r5 = new Range(new TimeSpan(12, 30, 0), new TimeSpan(13, 30, 0));
            Range r6 = new Range(new TimeSpan(12, 30, 0), new TimeSpan(13, 0, 0));

            Assert.AreEqual(null, r5.GenerateFreeRange(r6));


            //5
            //_______
            //  ___
            Range r7 = new Range(new TimeSpan(9, 30, 0), new TimeSpan(10, 30, 0));
            Range r8 = new Range(new TimeSpan(9, 45, 0), new TimeSpan(10, 15, 0));

            Assert.AreEqual(null, r7.GenerateFreeRange(r8));

            //6
            //_______
            //       ___
            Range r9 = new Range(new TimeSpan(9, 30, 0), new TimeSpan(10, 30, 0));
            Range r10 = new Range(new TimeSpan(10, 30, 0), new TimeSpan(11, 30, 0));

            Assert.AreEqual(null, r7.GenerateFreeRange(r8));


            //7
            //9____13
            //          15_____17

            Range r11 = new Range(new TimeSpan(9, 0, 0), new TimeSpan(13, 0, 0));
            Range r12 = new Range(new TimeSpan(15, 0, 0), new TimeSpan(17, 0, 0));

            Assert.AreEqual(new TimeSpan(13, 0, 0), r11.GenerateFreeRange(r12).Start);
            Assert.AreEqual(new TimeSpan(15, 0, 0), r11.GenerateFreeRange(r12).End);
        }
    }
}
