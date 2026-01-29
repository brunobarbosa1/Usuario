using Usuario.Models.Dto;
using Usuario.Models.Usuario;

namespace Usuario.Repository;

public interface IUsuarioRepository
{
    Task<UsuarioModel?> GetByIdAsync(int id);
    Task<List<UsuarioModel>> GetAllAsync();
    Task AddAsync(UsuarioModel usuario);
    Task<UsuarioModel> UpdateAsync(UsuarioModel request);
    Task DeleteAsync(UsuarioModel usuario);
}