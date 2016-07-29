using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRollerCollection
{
    class DiceRoller
    {
        static void Main(string[] args)
        {
            //Creating a new dictionary called diceSumDictionary with an interger type key,
            // and an interger type value
            Dictionary<int, int> diceSumDictionary = new Dictionary<int, int>();
            
            //Setting the keys to be the numbers 2-12 and giving all the keys a value
            //of 0 to start
            for (int i = 2; i < 13; i++)
            {
                diceSumDictionary.Add(i,0);
            }
            //Creating a random number generator 
            Random random = new Random();
            for (int i= 0; i <100; i++)
            {
            //Creating two variables that have a random number between 1-6, 
            //and then creating a variable that is the sum of the two random numbers  
            // 
                int randomNumberA = random.Next(1, 7);
                int randomNumberB = random.Next(1, 7);
                int diceSum = randomNumberA + randomNumberB;
            //retreiving the value for each key(2-12)
                diceSumDictionary[diceSum]++;
                
            }
            //Former Tribe slugger Albert Belle was a grouch; we don't want to see #8
            diceSumDictionary.Remove(8);

            for (int i = 2; i < 13; i++)
            {
                if (diceSumDictionary.ContainsKey(i))
                {
                    //this is retreiving the value for each key
                    Console.WriteLine($"{i} = {diceSumDictionary[i]}");
                }
            }
            
            Console.ReadLine();
            //How can we test this?  The sum of the keys(without 8) == 69, 
            //but the total values won't == 100
            //because we removed the key 8.
            // Any ideas?
        }
    }
}
