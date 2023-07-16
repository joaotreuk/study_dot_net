namespace study_dot_net.Services.DbLogger;

public static class DbLoggerExtensions
{
  public static ILoggingBuilder AddDbLogger(this ILoggingBuilder builder)
  {
    builder.Services.AddSingleton<ILoggerProvider, DbLoggerProvider>();
    return builder;
  }
}
