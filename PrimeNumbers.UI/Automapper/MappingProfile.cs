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
                .ForMember(dest => dest.ComputedBiggestPrime, opt => opt.MapFrom(src => src.Primes.Count != 0 ? src.Primes.Max() : 0));
        }
    }
}
