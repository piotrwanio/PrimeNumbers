using System;
using System.Collections.Generic;

namespace PrimeNumbers.DTO
{
    public class CycleInfo
    {
        public int CycleId { get; set; }
        public TimeSpan CycleExecutionTime { get; set; }
        public ulong ComputedBiggestPrime { get; set; }
        public TimeSpan PrimeComputeTime { get; set; }
        public List<long> Primes { get; set; }
        public PrimeGenerationState State{ get; set; }
    }
}
