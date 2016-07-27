using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace displayPrime
{
    class Class1
    {
        public void FindPrime()
        {
            for (int i = 2; i < 101; i++)
            {
                int factorCount = 0;
                int n = Convert.ToInt32(Math.Sqrt(i));

                {
                    for (int j = 2; j < n; j++)
                    {
                        if (i%j == 0)
                        {
                            factorCount++;
                        }
                    }
                    if (factorCount == 0)
                    {
                        Console.WriteLine(i);
                    }


                }
            
        }

            //{
            //    public static bool IsPrime(int a)
            //    {
            //        for (int i = 2; i < a; i++)
            //        {
            //            if (a % i == 0)
            //            {
            //                return false;
            //            }
            //        }
            //        return true;
            //    }

            //    public static void ShowPrime(int a)
            //    {
            //        for (int j = 2; j < a; j++)
            //        {
            //            if (j.IsPrime())
            //            {
            //                Console.WriteLine(j);
            //            }
            //        }
            //    }
            //    public string

        }
    }
}

