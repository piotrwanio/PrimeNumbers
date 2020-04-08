using PrimeNumbers.BLL.Services.Interfaces;
using PrimeNumbers.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace PrimeNumbers.BLL.Services.Implementations
{
    public class CycleService : ICycleService
    {
        private readonly IPrimesGenerator _primesGenerator;
        private readonly ISegmentedPrimesGenerator _segmentedPrimesGenerator;
        private readonly ILogger _logger;

        IList<long> listOfPrimes = new List<long>() { 1 };

        public CycleService(IPrimesGenerator primesGenerator, ILogger logger, ISegmentedPrimesGenerator segmentedPrimesGenerator)
        {
            _primesGenerator = primesGenerator;
            _logger = logger;
            _segmentedPrimesGenerator = segmentedPrimesGenerator;
        }

        public async Task<CycleInfo> StartCycle(int cycleTime, int breakTime, PrimeGenerationState state)
        {
            _logger.Information("Primes generating cycle started");

            _primesGenerator.TurnedOn = true;

            var elpsd = -DateTime.Now.Ticks;

            var x = state.X;
            var y = state.Y;
            var limit = state.Limit;


            while (_primesGenerator.TurnedOn)
            {
                IList<long> listOfPrimesTemp = new List<long>();

                //First stage of generating primes - with use of sieve of atkin
                if ((limit) < int.MaxValue/4)
                {
                    (listOfPrimesTemp, x, y, limit) =
                        await _primesGenerator.GenerateUsingSieveOfAtkin((int)limit, x, y);
                    if (x * x > limit && y * y > limit)
                    {
                        x = 1;
                        y = 1;
                        limit *= 2;
                    }
                }
                else
                {
                    //Second stage of generating primes - segregation sieve for large numbers
                    listOfPrimes.Concat(_segmentedPrimesGenerator.GeneratePrimes(listOfPrimes.Max(), limit));
                    limit += 100000000;
                }

                if (listOfPrimesTemp.Count != 0) listOfPrimes = listOfPrimesTemp;
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

            _logger.Information("Cycle stopped.");
        }
    }
}
