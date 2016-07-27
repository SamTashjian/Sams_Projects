using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace Warmups.Tests
{
    [TestFixture]
  public  class LoopsTest
    {
        [TestCase("Hi", 2, "HiHi")]
        [TestCase("Hi", 3, "HiHiHi")]
        [TestCase("Hi", 1, "Hi")]

        public void StringTimes(string str, int n, string expected)
        {
            Loops obj = new Loops();
            string testValue = obj.StringTimes(str, n);

            Assert.AreEqual(testValue, expected);
        }

        [TestCase("Chocolate", 2, "ChoCho")]
        [TestCase("Chocolate", 3, "ChoChoCho")]
        [TestCase("Abc", 3, "AbcAbcAbc")]

        public void FrontTimes(string str, int n, string expected)
        {
            Loops obj = new Loops();
            string testValue = obj.FrontTimes(str, n);

            Assert.AreEqual(testValue, expected);
        }
    }
}
