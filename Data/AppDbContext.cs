using Microsoft.EntityFrameworkCore;
using Usuario.Models.Usuario;

namespace Usuario.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options){}
    
    public DbSet<UsuarioModel> Usuarios { get; set; }
}