using PrimeNumbers.DTO;

namespace PrimeNumbers.BLL.Services.Interfaces
{
    public interface IXmlWriter
    {
        void Serialize(CycleInfo cycleInfo);
    }
}