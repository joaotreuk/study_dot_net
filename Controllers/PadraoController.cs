using Microsoft.AspNetCore.Mvc;
using study_dot_net.IRepositories;
using study_dot_net.Models;
using study_dot_net.Services.DbLogger;
using Swashbuckle.AspNetCore.Annotations;

namespace study_dot_net.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public abstract class PadraoController<T> : ControllerBase where T : Padrao
  {
    private readonly ILogger _logger;

    private IPadraoRepository<T> Repository => GetRepository();

    protected abstract IPadraoRepository<T> GetRepository();

    public PadraoController(ILogger logger)
    {
      _logger = logger;
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
      T? produto = await Repository.Get(id);

      // Verificar se existe
      if (produto == null)
      {
        return NotFound();
      }

      Repository.Remove(produto);

      if (await Repository.SaveChangesAsync())
      {
        // Log
        EventId eventoId = new(DbLoggerProvider.LogOperationId, $"{typeof(T)} Delete");
        _logger.LogInformation(eventoId, $"{id} was deleted.");

        return Ok();
      }

      return BadRequest();
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
      return Ok(await Repository.Get());
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Description = "Vai obter uma entidade pelo Id e retornar seu objeto", Summary = "Obter a entidade pelo Id")]
    public async Task<IActionResult> Get(int id)
    {
      return Ok(await Repository.Get(id));
    }

    [HttpPost]
    public async Task<IActionResult> Post(T entidade)
    {
      Repository.Add(entidade);

      if (await Repository.SaveChangesAsync())
      {
        // Log
        EventId eventoId = new(DbLoggerProvider.LogOperationId, $"{typeof(T)} Insert");
        _logger.LogInformation(eventoId, $"{entidade.Id} was inserted.");

        return Ok();
      }

      return BadRequest();
    }

    [HttpPut]
    public async Task<IActionResult> Put(int id, T entidade)
    {
      // Verificar se existe
      if (!await Repository.Any(id))
      {
        return NotFound();
      }

      entidade.Id = id;
      Repository.Update(entidade);

      if (await Repository.SaveChangesAsync())
      {
        return Ok();
      }

      return BadRequest();
    }
  }
}
