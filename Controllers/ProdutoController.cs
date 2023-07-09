using Microsoft.AspNetCore.Mvc;
using study_dot_net.IRepositories;
using study_dot_net.Models;

namespace study_dot_net.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutoController : ControllerBase
{
  private readonly IProdutoRepository _repository;

  public ProdutoController(IProdutoRepository repository)
  {
    _repository = repository;
  }

  [HttpDelete]
  public async Task<IActionResult> Delete(int id)
  {
    Produto? produto = await _repository.Get(id);

    // Verificar se existe
    if (produto == null)
    {
      return NotFound();
    }

    _repository.Remove(produto);

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
  public async Task<IActionResult> Get(int id)
  {
    return Ok(await _repository.Get(id));
  }

  [HttpPost]
  public async Task<IActionResult> Post(Produto produto)
  {
    _repository.Add(produto);

    if (await _repository.SaveChangesAsync())
    {
      return Ok();
    }

    return BadRequest();
  }

  [HttpPut]
  public async Task<IActionResult> Put(int id, Produto produto)
  {
    // Verificar se existe
    if (!await _repository.Any(id))
    {
      return NotFound();
    }

    produto.Id = id;
    _repository.Update(produto);

    if (await _repository.SaveChangesAsync())
    {
      return Ok();
    }

    return BadRequest();
  }
}
