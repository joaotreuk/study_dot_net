namespace study_dot_net.Services.DbLogger;

[ProviderAlias("Database")]
public class DbLoggerProvider : ILoggerProvider
{
  public const int LogOperationId = 1999;

  private readonly IServiceScopeFactory _serviceProvider;

  public DbLoggerProvider(IServiceScopeFactory serviceProvider)
  {
    _serviceProvider = serviceProvider;
  }

  public ILogger CreateLogger(string categoryName)
  {
    return new DbLogger(_serviceProvider);
  }

  public void Dispose() { }
}
