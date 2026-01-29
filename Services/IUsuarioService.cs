using Usuario.Models.Dto;
using Usuario.Models.Usuario;

namespace Usuario.Services;

public interface IUsuarioService
{
    Task<List<UsuarioModel>> GetAll();
    Task<UsuarioModel?> FindById(int idUsuario);
    Task<UsuarioModel> Create(UsuarioRequestDto request);
    Task<UsuarioModel> Update(UpdateUsuarioRequestDto request, int idUsuario);
    Task Delete(int idUsuario);
}