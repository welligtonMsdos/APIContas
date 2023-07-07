using APIContas.Data.Dtos;
using APIContas.Data.Interfaces;
using APIContas.Enum;
using APIContas.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APIContas.Controllers;

[ApiController]
[Route("[controller]")]
public class ContaController : BaseController
{
    private readonly IContaService _service;
    private readonly IMapper _mapper;

    public ContaController(IContaService service, IMapper mapper) => (_service, _mapper) = (service, mapper);

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
