using PrimeNumbers.BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrimeNumbers.BLL.Services.Implementations
{
    public class PrimesGenerator : IPrimesGenerator
    {
        public static List<long> primesList = new List<long>();
        static bool[] isPrime = new bool[0];
        private bool _turnedOn = true;

        public bool TurnedOn { get { return _turnedOn; } set { _turnedOn = value; } }

        public async Task<(IList<long>, int, int, int)> GenerateUsingSieveOfAtkin(int limit, long elpsd, int x = 1,
            int y = 1, int lastPrime = 1)
        {
            if (isPrime.Length < limit || (x == 1 && y == 1))
            {
                isPrime = new bool[limit + 1];
                for (int i = 0; i < limit; i++)
                    isPrime[i] = false;
            }

            var sqrt = Math.Sqrt(limit);

            int yInit = y;
            int xInit = x;

            for (; x <= sqrt; x++)
            {
                if (x == xInit)
                {
                    y = yInit;
                }
                else
                {
                    y = 1;
                }

                for (; y <= sqrt; y++)
                {
                    var n = 4 * x * x + y * y;
                    if (n <= limit && (n % 12 == 1 || n % 12 == 5))
                        isPrime[n] ^= true;

                    n = 3 * x * x + y * y;
                    if (n <= limit && n % 12 == 7)
                        isPrime[n] ^= true;

                    n = 3 * x * x - y * y;
                    if (x > y && n <= limit && n % 12 == 11)
                        isPrime[n] ^= true;
                    if (!TurnedOn)
                    {
                        return (new List<long>(), x, y, limit);
                    }
                }

                if (!TurnedOn)
                {
                    return (new List<long>(), x, y, limit);
                }
            }

            isPrime[2] = isPrime[3] = isPrime[5] = true;

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
    }
}
