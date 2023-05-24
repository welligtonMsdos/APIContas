using APIContas.Data.Dtos;
using APIContas.Data.Interfaces;
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
}
