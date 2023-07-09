using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace study_dot_net.Models;

public class Entidade
{
  [Column(TypeName = "date")]
  public DateTime? DataNascimento { get; set; }
  public int Id { get; set; }
  [StringLength(100)]
  public required string Nome { get; set; }
}
