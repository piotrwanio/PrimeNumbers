using System;
using System.Xml.Serialization;

namespace PrimeNumbers.DTO
{
    public class BasicCycleInfo
    {
        public int CycleId { get; set; }

        [XmlIgnore]
        public TimeSpan CycleExecutionTime { get; set; }

        public ulong ComputedBiggestPrime { get; set; }

        [XmlIgnore]
        public TimeSpan PrimeComputeTime { get; set; }

        [XmlElement("CycleExecutionTime")]
        public string CycleExecutionTimeString
        {
            get => CycleExecutionTime.ToString(@"hh\:mm\:ss");
            set => CycleExecutionTime = TimeSpan.Parse(value);
        }

        [XmlElement("PrimeComputeTime")]
        public string PrimeComputeTimeString
        {
            get => PrimeComputeTime.ToString(@"hh\:mm\:ss");
            set => CycleExecutionTime = TimeSpan.Parse(value);
        }
    }
}
