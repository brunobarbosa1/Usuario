using Microsoft.AspNetCore.Mvc;
using Usuario.Models.Dto;
using Usuario.Models.Usuario;
using Usuario.Services;

namespace Usuario.Controllers;

[ApiController]
[Route("api/usuarios")]
public class UsuarioController : ControllerBase
{
    
    private readonly IUsuarioService _usuarioService;
    
    public  UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    
    [HttpGet]
    public async Task<ActionResult<List<UsuarioModel>>> Listar()
    {
        var usuarios = await _usuarioService.Listar();
        return Ok(usuarios);
    }

    
    [HttpGet("{id}")]
    public async Task<ActionResult<UsuarioModel>> BuscarPorId(int id)
    {
        var usuario = await _usuarioService.BuscarPorId(id);
        return Ok(usuario);
    }

    
    [HttpPost]
    public async Task<ActionResult<UsuarioModel>> Criar(UsuarioRequestDto request)
    {
        var usuario = await _usuarioService.Criar(request);
        return Created("api/usuarios", usuario);
    }


    [HttpPut("{id}")]
    public async Task<ActionResult<UsuarioModel>> Atualizar(int id, UpdateUsuarioRequestDto request)
    {
        var usuario = await _usuarioService.BuscarPorId(id);
        return Ok(usuario);
    }

    
    [HttpDelete("{id}")]
    public async Task<ActionResult> Deletar(int id)
    {
        
        await _usuarioService.Deletar(id);
        return NoContent();
    }
    
}