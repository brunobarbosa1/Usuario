using Usuario.Models.Usuario;

namespace Usuario.Repository;

public interface IUsuarioRepository
{
    Task<UsuarioModel> BuscarPorIdAsync(int id);
    Task<List<UsuarioModel>> ListarAsync();
    Task AdicionarAsync(UsuarioModel usuario);
    Task<UsuarioModel> SalvarAsync(UsuarioModel request);
    Task DeletarAsync(UsuarioModel usuario);
}