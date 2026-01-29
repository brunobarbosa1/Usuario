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
    
    
    public async Task<UsuarioModel?> GetByIdAsync(int id)
    {
        return await _context.Usuarios.FindAsync(id);
    }

    
    public async Task<List<UsuarioModel>> GetAllAsync()
    {
       return await _context.Usuarios.ToListAsync();
    }

    
    public async Task AddAsync(UsuarioModel usuario)
    {
        
        await _context.Usuarios.AddAsync(usuario);
        await _context.SaveChangesAsync();
    }

    
    public async Task<UsuarioModel> UpdateAsync(UsuarioModel usuario)
    {
        _context.Usuarios.Update(usuario);
        await _context.SaveChangesAsync();
        return usuario;
    }

    
    public async Task DeleteAsync(UsuarioModel usuario)
    {
        _context.Usuarios.Remove(usuario);
        await _context.SaveChangesAsync();
    }
}