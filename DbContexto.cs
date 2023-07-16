using Microsoft.EntityFrameworkCore;
using study_dot_net.Models;

namespace study_dot_net
{
  public class DbContexto : DbContext
  {
    public DbSet<Entidade> Entidades { get; set; }
    public DbSet<Log> Logs { get; set; }
    public DbSet<Produto> Produtos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer("Server=(local);Database=study_dot_net;Trusted_Connection=True;TrustServerCertificate=true;");
    }
  }
}
