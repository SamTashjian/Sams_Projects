using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace Warmups.Tests
{
    [TestFixture]

    class LogicTests
    {
        [TestCase(30, false, false)]
        [TestCase(50, false, true)]
        [TestCase(70, true, true)]

        public void GreatParty(int cigars, bool isWeekend, bool expected)
        {
            Logic obj = new Logic();
            bool testValue = obj.GreatParty(cigars, isWeekend);

            Assert.AreEqual(expected, testValue);
        }

        [TestCase(5, 10, 2)]
        [TestCase(5, 2, 0)]
        [TestCase(5, 5, 1)]

        public void CanHazTable(int yourStyle, int dateStyle, int expected)
        {
            Logic obj = new Logic();
            int testValue = obj.CanHazTable(yourStyle, dateStyle);

            Assert.AreEqual(expected, testValue);

        }

        [TestCase(70, false, true)]
        [TestCase(95, false, false)]
        [TestCase(95, true, true)]

        public void PlayOutside(int temp, bool isSummer, bool expected)
        {
            Logic obj = new Logic();
            bool testValue = obj.PlayOutside(temp, isSummer);

            Assert.AreEqual(expected, testValue);
        }

        [TestCase(60, false, 0)]
        [TestCase(65, false, 1)]
        [TestCase(65, true, 0)]

        public void CaughtSpeeding(int speed, bool isBirthday, int expected)
        {
            Logic obj = new Logic();
            int testValue = obj.CaughtSpeeding(speed, isBirthday);

            Assert.AreEqual(expected, testValue);
        }

        [TestCase(3, 4, 7)]
        [TestCase(9, 4, 20)]
        [TestCase(10, 11, 21)]

        public void SkipSum(int a, int b, int expected)
        {
            Logic obj = new Logic();
            int testValue = obj.SkipSum(a, b);

            Assert.AreEqual(expected, testValue);
        }

        [TestCase(1, false, "7:00")]
        [TestCase(5, false, "7:00")]
        [TestCase(0, false, "10:00")]
        [TestCase(6, true, "off")]

        public void AlarmClock(int day, bool vacation, string expected)
        {
            Logic obj = new Logic();
            string testValue = obj.AlarmClock(day, vacation);

            Assert.AreEqual(expected, testValue);
        }
    }
}
