using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Warmups;

namespace Warmups.Tests
{
    [TestFixture]
    public class ConditionalsTest
    {
        [TestCase(true, true, true)]
        [TestCase(false, false, true)]
        [TestCase(true, false, false)]
        public void TestAreWeInTrouble(bool aSmile, bool bSmile, bool expected)
        {
            Conditionals obj = new Conditionals();
            bool testValue = obj.AreWeInTrouble(aSmile, bSmile);

            Assert.AreEqual(testValue, expected);
        }

        [TestCase(false, false, true)]
        [TestCase(false, true, true)]
        [TestCase(true, false, false)]

        public void CanSleepIn(bool isWeekday, bool isVacation, bool expected)
        {
           Conditionals obj = new Conditionals();
            bool testValue = obj.CanSleepIn(isWeekday, isVacation);

            Assert.AreEqual(testValue, expected);
        }

        [TestCase(1,2,3)]
        [TestCase(3,2,5)]
        [TestCase(2,2,8)]

        public void SumDouble(int a, int b, int expected)
        {
            Conditionals obj = new Conditionals();
            int testValue = obj.SumDouble(a, b);

            Assert.AreEqual(testValue, expected);
        }

        [TestCase(23,4)]
        [TestCase(10,11)]
        [TestCase(21, 0)]

        public void Diff21(int n, int expected)
        {
            Conditionals obj = new Conditionals();
            int testValue = obj.Diff21(n);

            Assert.AreEqual(testValue, expected);

        }
        [TestCase(true, 6, true)]
        [TestCase(true, 7, false)]
        [TestCase(false, 6, false)]

        public void ParrotTrouble(bool isTalking, int hour, bool expecetd)
        {
            Conditionals obj = new Conditionals();
            bool testValue = obj.ParrotTrouble(isTalking, hour);

            Assert.AreEqual(testValue, expecetd);
        }


    }
}
