using System.ComponentModel.DataAnnotations;

namespace study_dot_net.Models;

public class Produto : Padrao
{
  [StringLength(100)]
  public required string Nome { get; set; }
}
