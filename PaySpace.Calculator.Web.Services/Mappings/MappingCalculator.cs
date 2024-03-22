
using AutoMapper;
using PaySpace.Calculator.Data.Models;
using PaySpace.Calculator.Web.Services.Models;

namespace PaySpace.Calculator.Web.Services.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CalculatorHistory, CalculatorHistoryDto>()
            .ForMember(dest => dest.Calculator, opt => opt.MapFrom(src => src.Calculator.ToString()));

        CreateMap<PostalCode, PostalCodeDto>()
            .ForMember(dest => dest.Calculator, o => o.MapFrom(src => src.Calculator.ToString()));

    }
}
