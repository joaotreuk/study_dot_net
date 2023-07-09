using Microsoft.AspNetCore.Mvc;
using study_dot_net.IRepositories;
using study_dot_net.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace study_dot_net.Controllers;

[ApiController]
[Route("[controller]")]
public class EntidadeController : ControllerBase
{
  private readonly ILogger<EntidadeController> _logger;
  private readonly IEntidadeRepository _repository;

  public EntidadeController(ILogger<EntidadeController> logger, IEntidadeRepository repository)
  {
    _logger = logger;
    _repository = repository;
  }

  [HttpDelete]
  public async Task<IActionResult> Delete(int id)
  {
    Entidade? entidade = await _repository.Get(id);

    // Verificar se existe
    if (entidade == null)
    {
      return NotFound();
    }

    _repository.Remove(entidade);

    if (await _repository.SaveChangesAsync())
    {
      return Ok();
    }

    return BadRequest();
  }

  [HttpGet]
  public async Task<IActionResult> Get()
  {
    return Ok(await _repository.Get());
  }

  [HttpGet("{id}")]
  [SwaggerOperation(Description = "Vai obter uma entidade pelo Id e retornar seu objeto", Summary = "Obter a entidade pelo Id")]
  public async Task<IActionResult> Get(int id)
  {
    return Ok(await _repository.Get(id));
  }

  [HttpGet("[action]")]
  public async Task<IActionResult> GetByName(string nome)
  {
    return Ok(await _repository.Get(nome));
  }

  [HttpPost]
  public async Task<IActionResult> Post(Entidade entidade)
  {
    _repository.Add(entidade);

    if (await _repository.SaveChangesAsync())
    {
      return Ok();
    }

    return BadRequest();
  }

  [HttpPut]
  public async Task<IActionResult> Put(int id, Entidade entidade)
  {
    // Verificar se existe
    if (!await _repository.Any(id))
    {
      return NotFound();
    }

    entidade.Id = id;
    _repository.Update(entidade);

    if (await _repository.SaveChangesAsync())
    {
      return Ok();
    }

    return BadRequest();
  }
}
