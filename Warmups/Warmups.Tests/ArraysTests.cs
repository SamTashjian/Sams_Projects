using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warmups;
using NUnit.Framework;

namespace Warmups.Tests
{
    [TestFixture]

    class ArraysTests
    {
        [TestCase(new[] {1, 2, 6}, true)]
        [TestCase(new[] {6, 1, 2, 3}, true)]
        [TestCase(new[] {13, 6, 1, 2, 3}, false)]

        public void FirstLast6(int[] numbers, bool expected)
        {
            Arrays obj = new Arrays();
          var testValue =  obj.FirstLast6(numbers);

            Assert.AreEqual(expected, testValue);
            
        }

        [TestCase(new[] {1, 2, 3}, false)]
        [TestCase(new[] {1, 2, 3, 1}, true)]
        [TestCase(new[] {1, 2, 1}, true)]

        public void SameFirstLast(int[] numbers, bool expected)
       {
            Arrays obj = new Arrays();
            var testValue = obj.SameFirstLast(numbers);

            Assert.AreEqual(expected, testValue);
        }

        [TestCase(new[] {1,2,3}, new[] {7,3 }, true)]
        [TestCase(new[] {1,2,3}, new[] {7,3,2}, false)]
        [TestCase(new[] {1,2,3}, new[] {1,3}, true)]

        public void commonEnd(int[] a, int[] b, bool expected)
        {
            Arrays obj = new Arrays();
            var testValue = obj.commonEnd(a, b);

            Assert.AreEqual(expected, testValue);
        }

        [TestCase(new[] {1, 2, 3}, 6)]
        [TestCase(new[] {5, 11, 2}, 18)]
        [TestCase(new[] {7, 0, 0}, 7)]

        public void Sum(int[] numbers, int expected)
        {
            Arrays obj = new Arrays();
            var testValue = obj.Sum(numbers);

            Assert.AreEqual(expected, testValue);
        }

        
        [TestCase(new[] {5, 11, 9}, new[] {11, 9, 5})]
        [TestCase(new[] {7, 0, 0}, new[] {0, 0, 7})]
        [TestCase(new[] { 1, 2, 3 }, new[] { 2, 3, 1 })]

        public void RotateLeft(int[] numbers, int[] expected)
        {
            Arrays obj = new Arrays();
            var testValue = obj.RotateLeft(numbers);

            Assert.AreEqual(expected, testValue);
        }

        [TestCase(new[] {3, 2, 1}, new[] {1, 2, 3})]
        [TestCase(new[] {6, 5, 4}, new[] {4, 5, 6})]
        [TestCase(new[] {7, 8, 9}, new[] {9, 8, 7})]

        public void Reverse(int[] numbers, int[] expected)
        {
            Arrays obj = new Arrays();
            var testValue = obj.Reverse(numbers);

            Assert.AreEqual(expected, testValue);
        }

        [TestCase(new[] {1, 2, 3}, new[] {3, 3, 3})]
        [TestCase(new[] {11, 5, 9}, new[] {11, 11, 11})]
        [TestCase(new[] {2, 11, 3}, new[] {3, 3, 3})]

        public void HigherWins(int[] numbers, int[] expected)
        {
            Arrays obj = new Arrays();
            var testValue = obj.HigherWins(numbers);

            Assert.AreEqual(expected, testValue);
        }

        [TestCase(new[] {1, 2, 3}, new[] {4, 5, 6}, new[] {2, 5})]
        [TestCase(new[] {7, 7, 7}, new[] {3, 8, 0}, new[] {7, 8})]
        [TestCase(new[] {5, 2, 9}, new[] {1, 4, 5}, new[] {2, 4})]

        public void GetMiddle(int[] a, int[] b, int[] expected)
        {
            Arrays obj = new Arrays();
            var testValue = obj.GetMiddle(a, b);

            Assert.AreEqual(expected, testValue);
        }

        [TestCase(new[] {2, 5}, true)]
        [TestCase(new[] {4, 3}, true)]
        [TestCase(new[] {7, 5}, false)]
        [TestCase(new[] {1, 3, 5, 9}, false)]

        public void HasEven(int[] numbers, bool expected)
        {
            Arrays obj = new Arrays();
            var testValue = obj.HasEven(numbers);

            Assert.AreEqual(expected, testValue);
        }
    }
}
