using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warmups
{
    public class Conditionals
    {
        public bool AreWeInTrouble(bool aSmile, bool bSmile)
        {
            if (aSmile == bSmile)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CanSleepIn(bool isWeekday, bool isVacation)
        {
            if (isWeekday == false || isVacation == true)
            {
                return true;
            }
            return false;

        }

        public int SumDouble(int a, int b)
        {
            if ( a == b)
            {
                return (a + b)*2;
            }
            return a + b;
        }

        public int Diff21(int n)
        {
            if (n > 21)
            {
                return Math.Abs((n - 21)*2);
            }
            return Math.Abs( n - 21);
        }

        public bool ParrotTrouble(bool isTalking, int hour)
        {
            if (isTalking == true)
            {
                if (hour < 7 || hour > 20)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


    }
}
