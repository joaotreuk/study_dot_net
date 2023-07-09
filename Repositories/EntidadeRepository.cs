using Microsoft.EntityFrameworkCore;
using study_dot_net.IRepositories;
using study_dot_net.Models;

namespace study_dot_net.Repositories;

public class EntidadeRepository : PadraoRepository<Entidade>, IEntidadeRepository
{
  public EntidadeRepository(DbContexto contexto) : base(contexto) { }

  public async Task<Entidade[]> Get(string nome)
  {
    return await _contexto.Entidades
      .Where(e => e.Nome.Contains(nome))
      .ToArrayAsync();
  }
}
