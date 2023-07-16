namespace study_dot_net.Models
{
  public class Log : Padrao
  {
    public required string Values { get; set; }
    public DateTime Created { get; set; }
  }
}
