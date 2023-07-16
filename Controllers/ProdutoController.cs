using Microsoft.AspNetCore.Mvc;
using study_dot_net.IRepositories;
using study_dot_net.Models;

namespace study_dot_net.Controllers;

public class ProdutoController : PadraoController<Produto>
{
  private readonly IProdutoRepository _repository;

  public ProdutoController(ILogger<ProdutoController> logger, IProdutoRepository repository) : base(logger)
  {
    _repository = repository;
  }

  protected override IPadraoRepository<Produto> GetRepository()
  {
    return _repository;
  }
}
