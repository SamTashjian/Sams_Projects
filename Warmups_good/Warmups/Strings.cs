using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Warmups
{
    public class Strings
    {
        public string SayHi(string name)
        {
            return $"Hello {name}!";
        }

        public string Abba(string a, string b)
        {
            return $"{a}{b}{b}{a}";

        }

        public string MakeTags(string tag, string content)
        {
            return $"<{tag}>{content}</{tag}>";
        }

        public string InsertWord(string container, string word)
        {
            string FirstH = container.Substring(0, container.Length/2);
            string SecondH = container.Substring(container.Length/2);

            return $"{FirstH}{word}{SecondH}";
        }

        public string MultipleEndings(string str)
        {
            string Last2 = str.Substring(str.Length - 2);

            return $"{Last2}{Last2}{Last2}";
        }

        public string FirstHalf(string str)
        {
            string FirstH = str.Substring(0, str.Length / 2);

            return FirstH;
        }

        public string Reverse(string word)
        {
            char[] wordArray = word.ToCharArray();
            string reverse = "";
            for (int i = wordArray.Length - 1; i > -1; i--)
            {
                reverse += wordArray[i];
            }

            return reverse;
        }

    }

}
