using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Warmups
{
  public class Logic
    {
        public bool GreatParty(int cigars, bool isWeekend)
        {
            if (cigars > 39 && cigars < 61)
            {
                return true;
            }
            else if (isWeekend == true && cigars > 39)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

      public int CanHazTable(int yourStyle, int dateStyle)
      {
          if (yourStyle > 7 || dateStyle > 7)
          {
              return 2;
          }
          else if (yourStyle < 3 || dateStyle < 3)
          {
              return 0;
          }
          else
          {
              return 1;
          }
          
      }

      public bool PlayOutside(int temp, bool isSummer)
      {
          if ((isSummer == true) && (temp > 59 && temp < 101))
          {
              return true;
          }

          else if ((isSummer == false) && (temp > 59 && temp < 91))
          {
              return true;
          }
          else
          {
              return false;
          }
      }

      public int CaughtSpeeding(int speed, bool isBirthday)
      {
          if (isBirthday == true)
          {
              speed -= 5;
          }

          if (speed > 60 && speed < 81)
            {
              return 1;
          }
          else if (speed >= 81)
            {
              return 2;
          }
          else
          {
              return 0;
          }

      }

      public int SkipSum(int a, int b)
      {
          int sum = a + b;

          if (sum > 9 && sum < 21)
          {
              return 20;
          }
          else
          {
              return sum;
          }
      }

      public string AlarmClock(int day, bool vacation)
      {
          string result = "";
          string seven = "7:00";
          string ten = "10:00";
          string off = "off";

          if ((day == 0 || day == 6) && (vacation == true))
          {
              result = off;
          }
          else if ((day == 0 || day == 6) && (vacation == false))
          {
              result = ten;
          }
          else if ((day > 0 && day < 6) && (vacation == true))
          {
              result = ten;
          }
          else
          {
              result = seven;
          }
          return result;


      }

    }
}
