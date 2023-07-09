using study_dot_net.IRepositories;
using study_dot_net.Models;

namespace study_dot_net.Repositories;

public class ProdutoRepository : PadraoRepository<Produto>, IProdutoRepository
{
  public ProdutoRepository(DbContexto contexto) : base(contexto) { }
}
