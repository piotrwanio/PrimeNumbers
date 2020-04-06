using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrimeNumbers.BLL.Services.Interfaces
{
    public interface IPrimesGenerator
    {
        bool TurnedOn { get; set; }

        Task<(IList<int>, int, int, int)> GenerateUsingSieveOfAtkin(int limit, long elpsd, int x = 1, int y = 1, int lastPrime = 1);
    }
}