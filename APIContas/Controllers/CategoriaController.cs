using APIContas.Data.Dtos.Categoria;
using APIContas.Data.Interfaces;
using APIContas.Enum;
using APIContas.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APIContas.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriaController : BaseController
{
    private readonly ICategoriaService _service;
    private readonly IMapper _mapper;

    public CategoriaController(ICategoriaService service, IMapper mapper) => (_service,_mapper) = (service,mapper);


    /// <summary>
    /// Retorna todas as categorias ativas
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> BuscarTodos()
    {
        try
        {
            return Ok(_mapper.Map<ICollection<ReadCategoriaDto>>(await _service.BuscarTodos()));
        }
        catch (Exception ex)
        {
            return Response(ex.Message);
        }
       
    }

    /// <summary>
    /// Busca categoria pelo id
    /// </summary>
    /// <param name="id">id da conta</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarPorId(int id)
    {
        try
        {
            return Ok(_mapper.Map<ReadCategoriaDto>(await _service.BuscarPorId(id)));
        }
        catch (Exception ex)
        {
            return Response(ex.Message);
        }
    }

    /// <summary>
    /// Adiciona uma categoria
    /// </summary>
    /// <param name="dto">Objeto com os campos necessários</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<CreateCategoriaDto>> Inserir([FromBody] CreateCategoriaDto dto)
    {
        if (!ModelState.IsValid) return Response(EMensagem.MODELSTATE_FALSE);

        try
        {
            var result = _mapper.Map<Categoria>(dto);           

            await _service.Incluir(result);

            return Response(result);
        }
        catch (Exception ex)
        {
            return Response(ex.Message);
        }
    }

    /// <summary>
    /// Altera uma categoria
    /// </summary>
    /// <param name="dto">Objeto com os campos necessários</param>
    /// <returns></returns>
    [HttpPut]
    public async Task<ActionResult<UpdateCategoriaDto>> Alterar([FromBody]UpdateCategoriaDto dto)
    {
        if (!ModelState.IsValid) return Response(EMensagem.MODELSTATE_FALSE);

        try
        {
            var result = _mapper.Map<Categoria>(dto);

            await _service.Alterar(result);

            return Response(result);
        }
        catch (Exception ex)
        {
            return Response(ex.Message);
        }
    }

    /// <summary>
    /// Inativa uma categoria
    /// </summary>
    /// <param name="id">id da categoria para inativar</param>
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
    /// Ativa uma categoria
    /// </summary>
    /// <param name="id">id da categoria para ativar</param>
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
    /// Exclui uma categoria permanentemente
    /// </summary>
    /// <param name="id">id da categoria a ser excluída</param>
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
