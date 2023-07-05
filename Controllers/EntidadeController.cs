using Microsoft.AspNetCore.Mvc;

namespace study_dot_net.Controllers;

[ApiController]
[Route("[controller]")]
public class EntidadeController : ControllerBase
{
  private readonly ILogger<EntidadeController> _logger;

  public EntidadeController(ILogger<EntidadeController> logger)
  {
    _logger = logger;
  }

  [HttpGet]
  public string Get()
  {
    return "Olá Mundo!";
  }
}
