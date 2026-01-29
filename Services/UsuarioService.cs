using Usuario.Models.Dto;
using Usuario.Models.Usuario;
using Usuario.Repository;

namespace Usuario.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _repository;
    
    public UsuarioService(IUsuarioRepository repository)
    {
        _repository = repository;
    }
    
    
    public async Task<List<UsuarioModel>> GetAll()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<UsuarioModel?> FindById(int idUsuario) {
        
       return await _repository.GetByIdAsync(idUsuario);
    }

    
    public async Task<UsuarioModel> Create(UsuarioRequestDto request) {
        
        var usuario = new UsuarioModel(
            request.Nome,
            request.Email,
            request.Senha);

        await _repository.AddAsync(usuario);
        return usuario;
    }

    
    public async Task<UsuarioModel> Update(UpdateUsuarioRequestDto request, int idUsuario)
    {
        var usuarioModel = await _repository.GetByIdAsync(idUsuario);
        
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
        
        await _repository.UpdateAsync(usuarioModel);
        return usuarioModel;
    }

    
    public async Task Delete(int idUsuario)
    {
        var usuario = await _repository.GetByIdAsync(idUsuario);
        await _repository.DeleteAsync(usuario);
    }
}