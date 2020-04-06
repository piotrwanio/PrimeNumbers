using PrimeNumbers.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumbers.DTO
{
    public class BasicCycleInfo
    {
        public int CycleId { get; set; }
        public TimeSpan CycleExecutionTime { get; set; }
        public ulong ComputedBiggestPrime { get; set; }
        public TimeSpan PrimeComputeTime { get; set; }
        public PrimeGenerationState State { get; set; }
    }
}
