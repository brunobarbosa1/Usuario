using Usuario.Exceptions;
using Usuario.Models.Dto;
using Usuario.Models.Usuario;
using Usuario.Repository;

namespace Usuario.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;
    
    public UsuarioService(IUsuarioRepository repository)
    {
        _usuarioRepository = repository;
    }
    
    
    public async Task<List<UsuarioModel>> Listar()
    {
        return await _usuarioRepository.ListarAsync();
    }

    public async Task<UsuarioModel> BuscarPorId(int idUsuario)
    {
        var usuario = await _usuarioRepository.BuscarPorIdAsync(idUsuario);
        if (usuario == null)
        {
            throw new UserNotFoundException("Usuário não encontrado");
        }
        return usuario;
    }

    
    public async Task<UsuarioModel> Criar(UsuarioRequestDto request) {
        
        var newUsuario = new UsuarioModel(
            request.Nome,
            request.Email,
            request.Senha);

        await _usuarioRepository.AdicionarAsync(newUsuario);
        return newUsuario;
    }

    
    public async Task<UsuarioModel> Atualizar(UpdateUsuarioRequestDto request, int idUsuario)
    {
        var usuarioModel = await _usuarioRepository.BuscarPorIdAsync(idUsuario);

        if (usuarioModel == null)
        {
            throw new UserNotFoundException("Usuário não encontrado para atualizar");
        }

        if (!string.IsNullOrWhiteSpace(request.Nome))
        {
            usuarioModel.Nome = request.Nome;
        }
        if (!string.IsNullOrWhiteSpace(request.Email))
        {
            usuarioModel.Email = request.Email;
        }
        if (!string.IsNullOrWhiteSpace(request.Senha))
        {
            usuarioModel.Senha = request.Senha;
        }
        
        await _usuarioRepository.SalvarAsync(usuarioModel);
        return usuarioModel;
    }

    
    public async Task Deletar(int idUsuario)
    {
        var usuario = await _usuarioRepository.BuscarPorIdAsync(idUsuario);

        if (usuario == null)
        { 
            throw new UserNotFoundException("Usuário não encontrado!");
        }

        await _usuarioRepository.DeletarAsync(usuario);
    }
}