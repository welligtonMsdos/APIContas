using APIContas.Data.Dtos.Conta;
using APIContas.Data.Interfaces;
using APIContas.Enum;
using APIContas.Model;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace APIContas.Controllers;

[ApiController]
[Route("[controller]")]
public class ContaController : BaseController
{
    private readonly IContaService _service;
    private readonly IMapper _mapper;

    public ContaController(IContaService service, IMapper mapper) => (_service, _mapper) = (service, mapper);

    /// <summary>
    /// Retorna todas as contas ativas
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> BuscarTodos()
    {
        try
        {
            return Ok(_mapper.Map<ICollection<ReadContaDto>>(await _service.BuscarTodos()));
        }
        catch (Exception ex)
        {
            return Response(ex.Message);
        }
    }

    /// <summary>
    /// Busca conta pelo id
    /// </summary>
    /// <param name="id">id da conta</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarPorId(int id)
    {
        try
        {
            return Ok(_mapper.Map<ReadContaDto>(await _service.BuscarPorId(id)));
        }
        catch (Exception ex)
        {
            return Response(ex.Message);
        }
    }

    /// <summary>
    /// Busca total do mês 
    /// </summary>
    /// <param name="numeroMes">número do mês</param>
    /// <returns></returns>
    [HttpGet("[Action]/{numeroMes}")]
    public IActionResult BuscarTotalPorMes(int numeroMes)
    {
        try
        {
            return Ok(_mapper.Map<ICollection<ReadContaBuscarTotalPorMesDto>>(_service.BuscarTotalPorMes(numeroMes)));
        }
        catch (Exception ex)
        {
            return Response(ex.Message);
        }
    }

    /// <summary>
    /// Adiciona uma conta
    /// </summary>
    /// <param name="dto">Objeto com os campos necessários</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<CreateContaDto>> Inserir([FromBody] CreateContaDto dto)
    {
        if (!ModelState.IsValid) return Response(EMensagem.MODELSTATE_FALSE);

        try
        {
            var result = _mapper.Map<Conta>(dto);

            await _service.Incluir(result);

            return Response(result);

        }
        catch (Exception ex)
        {
            return Response(ex.Message);
        }
    }

    /// <summary>
    /// Altera uma conta
    /// </summary>
    /// <param name="dto">Objeto com os campos necessários</param>
    /// <returns></returns>
    [HttpPut]
    public async Task<ActionResult<UpdateContaDto>> Alterar([FromBody] UpdateContaDto dto)
    {
        if (!ModelState.IsValid) return Response(EMensagem.MODELSTATE_FALSE);

        try
        {
            var result = _mapper.Map<Conta>(dto);

            await _service.Alterar(result);

            return Response(result);
        }
        catch (Exception ex)
        {
            return Response(ex.Message);
        }
    }

    /// <summary>
    /// Inativa uma conta
    /// </summary>
    /// <param name="id">id da conta para inativar</param>
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
    /// Ativa uma conta
    /// </summary>
    /// <param name="id">id da conta para ativar</param>
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
    /// Exclui uma conta permanentemente
    /// </summary>
    /// <param name="id">id da conta a ser excluída</param>
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
