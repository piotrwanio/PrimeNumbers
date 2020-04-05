using PrimeNumbers.BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrimeNumbers.BLL.Services.Implementations
{
    //TODO: change to async
    public class PrimesGenerator : IPrimesGenerator
    {
        public static List<int> primesList = new List<int>();
        static bool[] isPrime = new bool[0];

        public async Task<(IList<int>, int, int, int)> GenerateUsingSieveOfAtkin(int limit, long elpsd, int x = 1, int y = 1, int lastPrime = 1)
        {
            //limit = 7919;

            //// 2 and 3 are known to be prime 
            //if (limit > 2)
            //    Console.Write(2 + " ");

            //if (limit > 3)
            //    Console.Write(3 + " ");

            //// Initialise the sieve array with 
            //// false values 
            //if (sieve.Length < limit)
            //{
            //    bool[] sieveTemp = sieve;
            //    sieve = new bool[limit];
            //    sieveTemp.CopyTo(sieve, 0);
            //}
            //for (int i = lastPrime; i < limit; i++)
            //    sieve[i] = false;

            ///* Mark siev[n] is true if one of the 
            //following is true: 
            //a) n = (4*x*x)+(y*y) has odd number  
            //   of solutions, i.e., there exist  
            //   odd number of distinct pairs  
            //   (x, y) that satisfy the equation  
            //   and    n % 12 = 1 or n % 12 = 5. 
            //b) n = (3*x*x)+(y*y) has odd number  
            //   of solutions and n % 12 = 7 
            //c) n = (3*x*x)-(y*y) has odd number  
            //   of solutions, x > y and n % 12 = 11 */
            //for (; x * x < limit; x++)
            //{
            //    if (TimeSpan.FromTicks(elpsd + DateTime.Now.Ticks) > TimeSpan.FromSeconds(400))
            //    {
            //        break;
            //    }
            //    for (; y * y < limit; y++)
            //    {
            //        if (TimeSpan.FromTicks(elpsd + DateTime.Now.Ticks) > TimeSpan.FromSeconds(400))
            //        {
            //            break;
            //        }
            //        // Main part of Sieve of Atkin 
            //        int n = (4 * x * x) + (y * y);
            //        if (n <= limit && (n % 12 == 1 || n % 12 == 5))

            //            sieve[n] ^= true;

            //        n = (3 * x * x) + (y * y);
            //        if (n <= limit && n % 12 == 7)
            //            sieve[n] ^= true;

            //        n = (3 * x * x) - (y * y);
            //        if (x > y && n <= limit && n % 12 == 11)
            //            sieve[n] ^= true;
            //    }

            //}

            //// Mark all multiples of squares as 
            //// non-prime 
            //for (r = 5; r * r < limit; r++)
            //{
            //    if (sieve[r])
            //    {
            //        for (int i = r * r; i < limit;
            //             i += r * r)
            //            sieve[i] = false;
            //    }
            //}

            //// Print primes using sieve[] 
            //for (int a = lastPrime; a < limit; a++)
            //    if (sieve[a])
            //        primesList.Add(a);


            if (isPrime.Length < limit)
            {
                bool[] sieveTemp = isPrime;
                isPrime = new bool[limit + 1];
                sieveTemp.CopyTo(isPrime, 0);
            }
            var sqrt = Math.Sqrt(limit);

            int yInit = y;

            for (; x <= sqrt; x++)
            {
                if (TimeSpan.FromTicks(elpsd + DateTime.Now.Ticks) > TimeSpan.FromSeconds(60))
                {
                    break;
                }

                y = yInit;
                for (; y <= sqrt; y++)
                {
                    if (TimeSpan.FromTicks(elpsd + DateTime.Now.Ticks) > TimeSpan.FromSeconds(60))
                    {
                        break;
                    }
                    var n = 4 * x * x + y * y;
                    if (n <= limit && (n % 12 == 1 || n % 12 == 5))
                        isPrime[n] = true;

                    n = 3 * x * x + y * y;
                    if (n <= limit && n % 12 == 7)
                        isPrime[n] = true;

                    n = 3 * x * x - y * y;
                    if (x > y && n <= limit && n % 12 == 11)
                        isPrime[n] = true;
                }
            }
            for (int n = 5; n <= sqrt; n++)
                if (isPrime[n])
                {
                    int nSquared = n * n;
                    for (int k = nSquared; k <= limit; k += nSquared)
                        isPrime[k] = false;
                }
            primesList.Clear();
            primesList.Add(2);
            primesList.Add(3);
            for (int n = 5; n <= limit; n++)
                if (isPrime[n])
                    primesList.Add(n);

            return (primesList, x, y, limit);
        }

        //public IList<int> Generate()
        //{

        //} 
    }
}
