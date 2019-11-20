using AutoMapper;
using Project.Test.Application.Dto.Dto;
using Project.Test.Domain.Entity;

namespace Project.Test.CrossCutting.Ioc
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Carro, CarroDto>();
            CreateMap<CarroDto, Carro>();

            CreateMap<Manobra, ManobraDto>();
            CreateMap<ManobraDto, Manobra>();

            CreateMap<Manobrista, ManobristaDto>();
            CreateMap<ManobristaDto, Manobrista>();
        }
    }
}