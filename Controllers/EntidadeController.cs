using Microsoft.AspNetCore.Mvc;
using study_dot_net.IRepositories;
using study_dot_net.Models;

namespace study_dot_net.Controllers;

public class EntidadeController : PadraoController<Entidade>
{
  private readonly IEntidadeRepository _repository;

  public EntidadeController(ILogger<EntidadeController> logger, IEntidadeRepository repository) : base(logger)
  {
    _repository = repository;
  }

  [HttpGet("[action]")]
  public async Task<IActionResult> GetByName(string nome)
  {
    return Ok(await _repository.Get(nome));
  }

  protected override IPadraoRepository<Entidade> GetRepository()
  {
    return _repository;
  }
}
