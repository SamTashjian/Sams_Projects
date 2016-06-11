using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warmups.Tests
{
    [TestFixture]
    public class StringsTests
    {
        [TestCase("Bob", "Hello Bob!")]
        [TestCase("Alice", "Hello Alice!")]
        [TestCase("X", "Hello X!")]
        public void TestSayHello(string name, string expected)
        {
            Strings obj = new Strings();
            string testValue = obj.SayHi(name);

            Assert.AreEqual(expected, testValue);
        }

        [TestCase("Hi", "Bye", "HiByeByeHi")]
        public void TestAbba(string a, string b, string expected)
        {
            Strings obj = new Strings();
            string testValue = obj.Abba(a, b);

            Assert.AreEqual(expected, testValue);
        }

        [TestCase("i", "Yay", "<i>Yay</i>")]
        [TestCase("i", "Hello", "<i>Hello</i>")]
        [TestCase("cite", "Yay", "<cite>Yay</cite>")]
        public void MakeTags(string tag, string content, string expected)
        {
            Strings obj = new Strings();
            string testValue = obj.MakeTags(tag, content);

            Assert.AreEqual(expected, testValue);
        }

        [TestCase("<<>>","Yay","<<Yay>>")]
        [TestCase("<<>>", "WooHoo", "<<WooHoo>>")]
        [TestCase("[[]]", "word", "[[word]]")]

        public void InsertWord(string container, string word, string expected)
        {
            Strings obj = new Strings();
            string testValue = obj.InsertWord(container, word);

            Assert.AreEqual(expected, testValue);
        }

        [TestCase("Hello","lololo")]
        [TestCase("ab", "ababab")]
        [TestCase("Hi", "HiHiHi")]

        public void MultipleEndings(string str, string expected)
        {
            Strings obj = new Strings();
            string testValue = obj.MultipleEndings(str);

            Assert.AreEqual(expected, testValue);
        }
        [TestCase("WooHoo", "Woo" )]
        [TestCase("HelloThere", "Hello")]
        [TestCase("abcdef", "abc")]

        public void FirstHalf(string str, string expected)
        {
            Strings obj = new Strings();
            string testValue = obj.FirstHalf(str);

            Assert.AreEqual(expected, testValue);
        }

    }
}



