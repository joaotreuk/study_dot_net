using System.ComponentModel.DataAnnotations;

namespace study_dot_net.Models;

public class Produto
{
  public int Id { get; set; }
  [StringLength(100)]
  public required string Nome { get; set; }
}
