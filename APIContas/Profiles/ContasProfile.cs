using APIContas.Data.Dtos.Categoria;
using APIContas.Data.Dtos.Conta;
using APIContas.Data.Dtos.Perfil;
using APIContas.Data.Dtos.Usuario;
using APIContas.Model;
using AutoMapper;

namespace APIContas.Profiles;

public class ContasProfile : Profile
{
    public ContasProfile()
    {
        CreateMap<CreateCategoriaDto, Categoria>().ReverseMap();
        CreateMap<ReadCategoriaDto, Categoria>().ReverseMap();
        CreateMap<UpdateCategoriaDto, Categoria>().ReverseMap();        

        CreateMap<CreateContaDto, Conta>().ReverseMap();
        CreateMap<ReadContaDto, Conta>().ReverseMap();
        CreateMap<UpdateContaDto, Conta>().ReverseMap();        

        CreateMap<CreatePerfilDto, Perfil>().ReverseMap();
        CreateMap<ReadPerfilDto, Perfil>().ReverseMap();
        CreateMap<UpdatePerfilDto, Perfil>().ReverseMap();        

        CreateMap<Conta, ReadContaBuscarTotalPorMesDto>()           
            .ForMember(x => x.Descricao, x => x.MapFrom(x => x.Descricao))
            .ForMember(x => x.Valor, x => x.MapFrom(x => x.Valor))
            .ReverseMap();

        CreateMap<CreateUsuarioDto, Usuario>().ReverseMap();        
        CreateMap<UpdateUsuarioDto, Usuario>().ReverseMap();

        CreateMap<Usuario, ReadUsuarioDto>()
            .ForMember(x => x.PerfilDescricao, x => x.MapFrom(x => x.Perfil.Descricao));
    }
}
