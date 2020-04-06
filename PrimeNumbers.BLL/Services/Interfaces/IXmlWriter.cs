using PrimeNumbers.DTO;
using System.Collections.Generic;

namespace PrimeNumbers.BLL.Services.Interfaces
{
    public interface IXmlWriter
    {
        void Serialize(IList<BasicCycleInfo> cycleInfo);
    }
}