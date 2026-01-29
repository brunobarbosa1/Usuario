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
    public async Task<ActionResult<List<UsuarioModel>>> GetAll()
    {
        var usuarios = await _usuarioService.GetAll();
        return Ok(usuarios);
    }

    
    [HttpGet("{id}")]
    public async Task<ActionResult<UsuarioModel>> FindById(int id)
    {
        var usuario = await _usuarioService.FindById(id);
        if (usuario == null) {
            return NotFound("Usuário não encontrado!");
        }
        return Ok(usuario);
    }

    
    [HttpPost]
    public async Task<ActionResult<UsuarioModel>> Create(UsuarioRequestDto request)
    {
        var usuario = await _usuarioService.Create(request);
        return Created("api/usuarios", usuario);
    }


    [HttpPut("{id}")]
    public async Task<ActionResult<UsuarioModel>> Update(int id, UpdateUsuarioRequestDto request)
    {
        var usuario = await _usuarioService.FindById(id);
        
        if (usuario == null)
        {
            return NotFound("Usuário não encontrado!");
        }
        var usuarioUpdate = await _usuarioService.Update(request, id);
        return Ok(usuarioUpdate);
    }

    
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var usuario = await _usuarioService.FindById(id);
        if (usuario == null)
        {
            return NotFound("Usuário não encontrado!");
        }
        await _usuarioService.Delete(id);
        return NoContent();
    }
    
}