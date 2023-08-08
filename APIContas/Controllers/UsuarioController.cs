using APIContas.Data.Dtos.Usuario;
using APIContas.Data.Interfaces;
using APIContas.Enum;
using APIContas.Model;
using APIContas.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIContas.Controllers;


[ApiController]
[Route("[controller]")]
public class UsuarioController : BaseController
{
    private readonly IUsuarioService _service;
    private readonly IMapper _mapper;

    public UsuarioController(IUsuarioService service, IMapper mapper) => (_service, _mapper) = (service, mapper);

    /// <summary>
    /// Retorna todos os usuários ativos 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> BuscarTodos()
    {
        try
        {
            return Ok(_mapper.Map<ICollection<ReadUsuarioDto>>(await _service.BuscarTodos()));
        }
        catch (Exception ex)
        {
            return Response(ex.Message);
        }
    }

    /// <summary>
    /// Busca usuário pelo id
    /// </summary>
    /// <param name="id">id do perfil</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [Authorize(Roles = "1")]
    public async Task<IActionResult> BuscarPorId(int id)
    {
        try
        {
            return Ok(_mapper.Map<ReadUsuarioDto>(await _service.BuscarPorId(id)));
        }
        catch (Exception ex)
        {
            return Response(ex.Message);
        }
    }

    /// <summary>
    /// Adiciona um usuário
    /// </summary>
    /// <param name="dto">Objeto com os campos necessários</param>
    /// <returns></returns>   
    [HttpPost]
    public async Task<ActionResult<CreateUsuarioDto>> Inserir([FromBody] CreateUsuarioDto dto)
    {
        if (!ModelState.IsValid) return Response(EMensagem.MODELSTATE_FALSE);

        try
        {
            var result = _mapper.Map<Usuario>(dto);

            await _service.Incluir(result);

            return Response(result);

        }
        catch (Exception ex)
        {
            return Response(ex.Message);
        }
    }

    [HttpPost]
    [Route("login")]
    public async Task<ActionResult<dynamic>> Authenticate([FromBody] LoginDto login)
    {
        try
        {
            var user = _service.BuscarPorNomeSenha(login.Nome, login.Senha);

            var token = TokenService.GenerateToken(user);

            return new
            {
                nome =  user.Nome,
                perfilId = user.PerfilId,               
                token = token
            };
        }
        catch (Exception ex)
        {
            return Response(ex.Message);
        }       
    }

    /// <summary>
    /// Altera um usuário
    /// </summary>
    /// <param name="dto">Objeto com os campos necessários</param>
    /// <returns></returns>
    [HttpPut]
    public async Task<ActionResult<UpdateUsuarioDto>> Alterar([FromBody] UpdateUsuarioDto dto)
    {
        if (!ModelState.IsValid) return Response(EMensagem.MODELSTATE_FALSE);

        try
        {
            var result = _mapper.Map<Usuario>(dto);

            await _service.Alterar(result);

            return Response(result);
        }
        catch (Exception ex)
        {
            return Response(ex.Message);
        }
    }

    /// <summary>
    /// Inativa um usuário 
    /// </summary>
    /// <param name="id">id do usuário para inativar</param>
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
    /// Ativa um usuário
    /// </summary>
    /// <param name="id">id do usuário para ativar</param>
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
    /// Exclui um usuário permanentemente
    /// </summary>
    /// <param name="id">id do usuário a ser excluído</param>
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
