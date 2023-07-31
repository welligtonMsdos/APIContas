using APIContas.Data.Dtos;
using APIContas.Model;
using AutoMapper;

namespace APIContas.Profiles;

public class ContasProfile : Profile
{
    public ContasProfile()
    {
        CreateMap<ReadCategoriaDto, Categoria>().ReverseMap();
        CreateMap<UpdateCategoriaDto, Categoria>().ReverseMap();
        CreateMap<CreateCategoriaDto, Categoria>().ReverseMap();        

        CreateMap<ReadContaDto, Conta>().ReverseMap();
        CreateMap<UpdateContaDto, Conta>().ReverseMap();
        CreateMap<CreateContaDto, Conta>().ReverseMap();

        CreateMap<ReadPerfilDto, Perfil>().ReverseMap();
        CreateMap<UpdatePerfilDto, Perfil>().ReverseMap();
        CreateMap<CreatePerfilDto, Perfil>().ReverseMap();

        CreateMap<Conta, ContaBuscarTotalPorMesDto>()           
            .ForMember(x => x.NomeMes, x => x.MapFrom(x => x.Descricao))
            .ForMember(x => x.Valor, x => x.MapFrom(x => x.Valor))
            .ReverseMap();
    }
}
