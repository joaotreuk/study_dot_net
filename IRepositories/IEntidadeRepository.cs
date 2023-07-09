using study_dot_net.Models;

namespace study_dot_net.IRepositories;

public interface IEntidadeRepository : IPadraoRepository<Entidade>
{
  Task<Entidade[]> Get(string nome);
}
