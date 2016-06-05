using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Warmups;
namespace Warmup.Tests
{
    [TestFixture]
     
    public class Class1
    {
        [TestCase("Bob", "Hello Bob!")]
        [TestCase("Alice","Hello Alice!")]
        [TestCase("X", "Hello X!")]
        public void TestSayHello(string name, string expected)
        {
            Strings obj = new Strings();
            string testValue = obj.SayHi(name);

            Assert.AreEqual(expected, testValue);
        }
    }
}
