namespace study_dot_net.Services.DbLogger;

[ProviderAlias("Database")]
public class DbLoggerProvider : ILoggerProvider
{
  public const int LogOperationId = 1999;

  public ILogger CreateLogger(string categoryName)
  {
    return new DbLogger();
  }

  public void Dispose() { }
}
