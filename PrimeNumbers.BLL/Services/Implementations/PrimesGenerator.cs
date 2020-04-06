using PrimeNumbers.BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrimeNumbers.BLL.Services.Implementations
{
    public class PrimesGenerator : IPrimesGenerator
    {
        public static List<int> primesList = new List<int>();
        static bool[] isPrime = new bool[0];
        private bool _turnedOn = true;

        public bool TurnedOn { get { return _turnedOn; } set { _turnedOn = value; } }

        public async Task<(IList<int>, int, int, int)> GenerateUsingSieveOfAtkin(int limit, long elpsd, int x = 1, int y = 1, int lastPrime = 1)
        {
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
                if (!TurnedOn)
                {
                    break;
                }

                y = yInit;
                for (; y <= sqrt; y++)
                {
                    if (!TurnedOn)
                    {
                        break;
                    }
                    var n = 4 * x * x + y * y;
                    if (n <= limit && (n % 12 == 1 || n % 12 == 5))
                        isPrime[n] ^= true;

                    n = 3 * x * x + y * y;
                    if (n <= limit && n % 12 == 7)
                        isPrime[n] ^= true;

                    n = 3 * x * x - y * y;
                    if (x > y && n <= limit && n % 12 == 11)
                        isPrime[n] ^= true;
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
