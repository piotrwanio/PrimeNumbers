using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrimeNumbers.BLL.Services.Interfaces
{
    public interface IPrimesGenerator
    {
        bool TurnedOn { get; set; }

        Task<(IList<long>, int, int, int)> GenerateUsingSieveOfAtkin(int limit, int x = 1, int y = 1);
    }
}