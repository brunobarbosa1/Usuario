using Microsoft.EntityFrameworkCore;
using Usuario.Data;
using Usuario.Models.Usuario;

namespace Usuario.Repository;

public class UsuarioRepository : IUsuarioRepository
{
    
    private readonly AppDbContext _context;
    
    
    public UsuarioRepository(AppDbContext dbContext)
    {
        _context = dbContext;
    }
    
    
    public async Task<UsuarioModel?> BuscarPorIdAsync(int id)
    {
        return await _context.Usuarios.FindAsync(id);
    }

    
    public async Task<List<UsuarioModel>> ListarAsync()
    {
       return await _context.Usuarios.ToListAsync();
    }

    
    public async Task AdicionarAsync(UsuarioModel usuario)
    {
        
        await _context.Usuarios.AddAsync(usuario);
        await _context.SaveChangesAsync();
    }

    
    public async Task<UsuarioModel> SalvarAsync(UsuarioModel usuario)
    {
        await _context.SaveChangesAsync();
        return usuario;
    }

    
    public async Task DeletarAsync(UsuarioModel usuario)
    {
        _context.Usuarios.Remove(usuario);
        await _context.SaveChangesAsync();
    }
}