using AutoMapper;
using PrimeNumbers.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumbers.UI.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CycleInfo, BasicCycleInfo>()
                .ForMember(dest => dest.ComputedBiggestPrime, opt =>
                        opt.MapFrom(src => src.Primes.Count != 0 ? src.Primes.Max() : 0))
                .ForMember(dest => dest.PrimeComputeTime, opt =>
                    opt.MapFrom(src => src.PrimeComputeTime.ToString(@"hh\:mm\:ss")))
                .ForMember(dest => dest.CycleExecutionTime, opt =>
                    opt.MapFrom(src => src.CycleExecutionTime.ToString(@"hh\:mm\:ss")));
        }
    }
}
