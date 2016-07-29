using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Warmups
{
    public class Arrays
    {
        public bool FirstLast6(int[] numbers)
        {

            if (numbers[0] == 6 || numbers[numbers.Length - 1] == 6)
            {
                return true;
            }
            return false;
        }

        public bool SameFirstLast(int[] numbers)
        {
            if ((numbers.Length > 0) && (numbers[0] == numbers[numbers.Length - 1]))
            {
                return true;
            }
            return false;
        }

        public bool commonEnd(int[] a, int[] b)
        {
            if ((a[0] == b[0]) || (a[a.Length - 1] == b[b.Length - 1]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int Sum(int[] numbers)
        {
            return numbers.Sum();
        }

        public int[] RotateLeft(int[] numbers)
        {
            int first = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
              numbers[i - 1] = numbers[i];
            }

           numbers[numbers.Length - 1] = first;

            return numbers;
        }

        public int[] Reverse(int[] numbers)
        {
            int first = numbers[0];
            int last = numbers[numbers.Length - 1];

            numbers[0] = last;
            numbers[numbers.Length - 1] = first;

            return numbers;
        }

        public int[] HigherWins(int[] numbers)
        {
            int higher;

            if (numbers[0] > numbers[numbers.Length - 1])
            {
                higher = numbers[0];
            }
            else
            {
                higher = numbers[numbers.Length - 1];
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = higher;
            }

            return numbers;
        }

        public int[] GetMiddle(int[] a, int[] b)
        {
            int midA = a[1];
            int midB = b[1];

            int[] middle = new int[2];

            middle[0] = midA;
            middle[1] = midB;

            return middle;
        }

        public bool HasEven(int[] numbers)
        {
            foreach (var i in numbers)
            {
                if (i % 2 ==0)
                {
                    return true;
                }
            }
            return false;
        }

    }
}



