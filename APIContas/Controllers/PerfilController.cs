using APIContas.Data.Dtos.Perfil;
using APIContas.Data.Interfaces;
using APIContas.Enum;
using APIContas.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APIContas.Controllers;

[ApiController]
[Route("[controller]")]
public class PerfilController : BaseController
{
    private readonly IPerfilService _service;
    private readonly IMapper _mapper;

    public PerfilController(IPerfilService service, IMapper mapper) => (_service, _mapper) = (service, mapper);

    /// <summary>
    /// Retorna todos os perfis ativos 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> BuscarTodos()
    {
        try
        {
            return Ok(_mapper.Map<ICollection<ReadPerfilDto>>(await _service.BuscarTodos()));
        }
        catch (Exception ex)
        {
            return Response(ex.Message);
        }
    }

    /// <summary>
    /// Busca perfil pelo id
    /// </summary>
    /// <param name="id">id do perfil</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarPorId(int id)
    {
        try
        {
            return Ok(_mapper.Map<ReadPerfilDto>(await _service.BuscarPorId(id)));
        }
        catch (Exception ex)
        {
            return Response(ex.Message);
        }
    }

    /// <summary>
    /// Adiciona um perfil
    /// </summary>
    /// <param name="dto">Objeto com os campos necessários</param>
    /// <returns></returns>   
    [HttpPost]
    public async Task<ActionResult<CreatePerfilDto>> Inserir([FromBody] CreatePerfilDto dto)
    {
        if (!ModelState.IsValid) return Response(EMensagem.MODELSTATE_FALSE);

        try
        {
            var result = _mapper.Map<Perfil>(dto);

            await _service.Incluir(result);

            return Response(result);

        }
        catch (Exception ex)
        {
            return Response(ex.Message);
        }
    }

    /// <summary>
    /// Altera um perfil
    /// </summary>
    /// <param name="dto">Objeto com os campos necessários</param>
    /// <returns></returns>
    [HttpPut]
    public async Task<ActionResult<UpdatePerfilDto>> Alterar([FromBody] UpdatePerfilDto dto)
    {
        if (!ModelState.IsValid) return Response(EMensagem.MODELSTATE_FALSE);

        try
        {
            var result = _mapper.Map<Perfil>(dto);

            await _service.Alterar(result);

            return Response(result);
        }
        catch (Exception ex)
        {
            return Response(ex.Message);
        }
    }

    /// <summary>
    /// Inativa um perfil 
    /// </summary>
    /// <param name="id">id do perfil para inativar</param>
    /// <returns></returns>
    [HttpPut("[Action]/{id}")]
    public async Task<ActionResult> Inativar(int id)
    {
        if (id == 0) return Response(EMensagem.ID_ZERADO);

        try
        {
            await _service.Inativar(await _service.BuscarPorId(id));

            return Response(EMensagem.INATIVADO_SUCESSO);
        }
        catch (Exception ex)
        {
            return Response(ex.Message);
        }
    }

    /// <summary>
    /// Ativa um perfil
    /// </summary>
    /// <param name="id">id do perfil para ativar</param>
    /// <returns></returns>
    [HttpPut("[Action]/{id}")]
    public async Task<ActionResult> Ativar(int id)
    {
        if (id == 0) return Response(EMensagem.ID_ZERADO);

        try
        {
            await _service.Ativar(await _service.BuscarPorId(id));

            return Response(EMensagem.ATIVADO_SUCESSO);
        }
        catch (Exception ex)
        {
            return Response(ex.Message);
        }
    }

    /// <summary>
    /// Exclui um perfil permanentemente
    /// </summary>
    /// <param name="id">id do perfil a ser excluído</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult> Excluir(int id)
    {
        if (id == 0) return Response(EMensagem.ID_ZERADO);

        try
        {
            await _service.Excluir(await _service.BuscarPorId(id));

            return Response(EMensagem.DELETADO_SUCESSO);
        }
        catch (Exception ex)
        {
            return Response(ex.Message);
        }
    }
}
