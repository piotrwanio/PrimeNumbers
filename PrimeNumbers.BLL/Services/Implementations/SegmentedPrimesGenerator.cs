using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PrimeNumbers.BLL.Services.Interfaces;

namespace PrimeNumbers.BLL.Services.Implementations
{
    public class SegmentedPrimesGenerator
    {
        private readonly IPrimesGenerator _sievePrimesGenerator;

        public SegmentedPrimesGenerator(IPrimesGenerator sievePrimesGenerator)
        {
            _sievePrimesGenerator = sievePrimesGenerator;
        }

        public IList<long> GeneratePrimes(long low, long high)
        {
            // Comput all primes smaller or equal to 
            // square root of high using sieve  of atkin
            var limit = Math.Floor(Math.Sqrt(high)) + 1;

            IList<long> primes;

            (primes, _, _, _) = _sievePrimesGenerator.GenerateUsingSieveOfAtkin((int)limit, 0,1,1).Result;
            if (primes.Count == 0)
                return primes;

            // Count of elements in given range 
            long n = high - low + 1;

            // Declaring boolean only for [low, high] 
            bool[] mark =  Enumerable.Repeat(false, (int)n).ToArray();

            // Use the found primes by atkin sieve to find 
            // primes in given range 
            for (int i = 0; i < primes.Count; i++)
            {
                // Find the minimum number in [low..high] that is 
                // a multiple of primes[i] (divisible by primes[i]) 
                long loLim = (long)(Math.Floor((double)(low / primes[i])) * primes[i]);
                if (loLim < low)
                    loLim += primes[i];
                if (loLim == primes[i])
                    loLim += primes[i];
                /*  Mark multiples of primes[i] in [low..high]: 
                    We are marking j - low for j, i.e. each number 
                    in range [low, high] is mapped to [0, high - low] 
                    so if range is [50, 100]  marking 50 corresponds 
                    to marking 0, marking 51 corresponds to 1 and 
                    so on. In this way we need to allocate space only 
                    for range  */
                for (long j = loLim; j <= high; j += primes[i])
                    mark[j - low] = true;
            }

            primes.Clear();
            // Numbers which are not marked in range, are prime 
            for (long i = low; i <= high; i++)
                if (!mark[i - low])
                    primes.Add(i);

            return primes;
        }
    }
}
