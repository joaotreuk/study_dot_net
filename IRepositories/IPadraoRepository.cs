namespace study_dot_net.IRepositories;

public interface IPadraoRepository<T>
{
  void Add(T entidade);
  Task<bool> Any(int id);
  Task<T[]> Get();
  Task<T?> Get(int id);
  void Remove(T entidade);
  Task<bool> SaveChangesAsync();
  void Update(T entidade);
}
