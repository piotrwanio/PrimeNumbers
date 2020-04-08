using System.Collections.Generic;

namespace PrimeNumbers.BLL.Services.Interfaces
{
    public interface ISegmentedPrimesGenerator
    {
        IList<long> GeneratePrimes(long low, long high);
    }
}