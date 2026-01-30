using Usuario.Models.Dto;
using Usuario.Models.Usuario;

namespace Usuario.Services;

public interface IUsuarioService
{
    Task<List<UsuarioModel>> Listar();
    Task<UsuarioModel> BuscarPorId(int idUsuario);
    Task<UsuarioModel> Criar(UsuarioRequestDto request);
    Task<UsuarioModel> Atualizar(UpdateUsuarioRequestDto request, int idUsuario);
    Task Deletar(int idUsuario);
}