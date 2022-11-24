using AutoMapper;
using ContratoTestWebApi.Models.DTOs;

namespace ContratoTestWebApi.Models.Profiles
{
    public class ContratoProfile : Profile
    {
        public ContratoProfile() 
        {
            CreateMap<Contrato, ContratoDto>();
            CreateMap<ContratoDto, Contrato>();
        }
    }
}
