using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace study_dot_net.Repositories;

public class PadraoRepository<T> where T : class
{
  protected readonly DbContexto _contexto;

  public PadraoRepository(DbContexto contexto)
  {
    _contexto = contexto;
  }

  public void Add(T entidade)
  {
    _contexto.Add(entidade ?? throw new ArgumentNullException(nameof(entidade), "A entidade não pode ser nula."));
  }

  public async Task<bool> Any(int id)
  {
    return await _contexto.Set<T>()
      .Where("Id == @0", id)
      .AnyAsync();
  }

  public async Task<T[]> Get()
  {
    return await _contexto.Set<T>().ToArrayAsync();
  }

  public async Task<T?> Get(int id)
  {
    return await _contexto.Set<T>()
      .Where("Id == @0", id)
      .FirstOrDefaultAsync();
  }

  public void Remove(T entidade)
  {
    _contexto.Remove(entidade ?? throw new ArgumentNullException(nameof(entidade), "A entidade não pode ser nula."));
  }

  public async Task<bool> SaveChangesAsync()
  {
    return (await _contexto.SaveChangesAsync()) > 0;
  }

  public void Update(T entidade)
  {
    _contexto.Update(entidade ?? throw new ArgumentNullException(nameof(entidade), "A entidade não pode ser nula."));
  }
}
