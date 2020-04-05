using PrimeNumbers.BLL.Services.Interfaces;
using PrimeNumbers.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumbers.BLL.Services.Implementations
{
    public class CycleService : ICycleService
    {
        private IPrimesGenerator _primesGenerator;

        public CycleService(IPrimesGenerator primesGenerator)
        {
            _primesGenerator = primesGenerator;
        }

        public async Task<CycleInfo> StartCycle(int cycleTime, int breakTime, PrimeGenerationState state)
        {
            var elpsd = -DateTime.Now.Ticks;
            int x = 1, y = 1, limit = 10000;
            IList<int> listOfPrimes = new List<int>() { 1 };

            x = state.X;
            y = state.Y;
            limit = state.Limit;


            while (TimeSpan.FromTicks(elpsd + DateTime.Now.Ticks) < TimeSpan.FromSeconds(60))
            {
                (listOfPrimes, x, y, limit) = await _primesGenerator.GenerateUsingSieveOfAtkin(limit, elpsd, x, y, listOfPrimes.Last());
                if (x * x > limit && y * y > limit)
                {
                    x = 1;
                    y = 1;
                    limit *= 2;
                }
            }

            return new CycleInfo
            {
                CycleId = 1,
                Primes = listOfPrimes.ToList(),
                State = new PrimeGenerationState
                {
                    X = x,
                    Y = y,
                    Limit = limit
                }
            };
        }
    }
}
