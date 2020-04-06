using PrimeNumbers.DTO;
using System.Threading.Tasks;

namespace PrimeNumbers.BLL.Services.Interfaces
{
    public interface ICycleService
    {
        Task<CycleInfo> StartCycle(int cycleTime, int breakTime, PrimeGenerationState state);
        void StopCycle();
    }
}