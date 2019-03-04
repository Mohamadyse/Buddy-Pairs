using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    public class Kata
    {

        public static string Buddy(long start, long limit)
        {

            for (long i = start; i <= limit; i++)
            {

                long sumOfdiviors = Sumera(FindDivisiors(i));
                long potenialBudy = sumOfdiviors - 1;
                if (!(potenialBudy > i))
                {
                    continue;
                }
                List<long> divisorsOfPotenialBudy = FindDivisiors(potenialBudy);
                long sumOfdiviorsofPotential = Sumera(divisorsOfPotenialBudy);
                if ((potenialBudy + 1 == sumOfdiviors) && (i + 1 == sumOfdiviorsofPotential))
                    return $"({i} {potenialBudy})";
            }


            return "Nothing";
        }

        private static long Sumera(List<long> divisors)
        {
            long sum = 0;
            divisors.ForEach(a => sum += a);
            return sum;
        }
        private static List<long> FindDivisiors(long i)
        {
            var divisors = new List<long>();
            for (long j = 1; j < i; j++)
            {
                if (i % j == 0) divisors.Add(j);
            }
            return divisors;
        }

        /*
         public static List<long> FindPrimes(int number)
         {
             var primes = new List<long>();

             for (int div = 2; div <= number; div++)
             {
                 while (number % div == 0)
                 {
                     primes.Add(div);
                     number = number / div;
                 }
             }
             return primes;
         }
        */

        public static List<long> FindPrimes(int n)
        {
            var primes = new List<long>();
            while (n % 2 == 0)
            {
              

                n /= 2;
                primes.Add(n);
            }

            // n must be odd at this point. So we can 
            // skip one element (Note i = i +2) 
            for (int i = 3; i <= Math.Sqrt(n); i += 2)
            {
                // While i divides n, print i and divide n 
                while (n % i == 0)
                {
                 
                    n /= i;
                    primes.Add(n);

                }
            }
            return primes;
 
        }

       

    



    public static List<long> PowerSet(List<long> setOfPrimes)
        {
           
                int n = setOfPrimes.Count;
                // Power set contains 2^N subsets.
                int powerSetCount = 1 << n;
                var ans = new List<long>();

                for (int setMask = 0; setMask < powerSetCount-1; setMask++)
                {
            
                var multiplication = 1L;
                    for (int i = 0; i < n; i++)
                    {
                        // Checking whether i'th element of input collection should go to the current subset.
                        if ((setMask & (1 << i)) > 0)
                        {
                        multiplication *= setOfPrimes[i];
                        }
                }
                if (!(ans.Contains(multiplication)))
                    ans.Add(multiplication);
            }

            return ans;
            
        }



    }
}