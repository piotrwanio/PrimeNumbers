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
            _primesGenerator.TurnedOn = true;

            var elpsd = -DateTime.Now.Ticks;
            int x = 1, y = 1, limit = 10000;
            IList<int> listOfPrimes = new List<int>() { 1 };

            x = state.X;
            y = state.Y;
            limit = state.Limit;


            while (_primesGenerator.TurnedOn)
            {
                IList<int> listOfPrimesTemp = new List<int>();
                (listOfPrimesTemp, x, y, limit) = await _primesGenerator.GenerateUsingSieveOfAtkin(limit, elpsd, x, y, listOfPrimes.Last());
                if (listOfPrimesTemp.Count != 0) listOfPrimes = listOfPrimesTemp;

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

        public void StopCycle()
        {
            _primesGenerator.TurnedOn = false;
        }
    }
}
