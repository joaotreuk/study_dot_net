using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using study_dot_net.Models;

namespace study_dot_net.Services.DbLogger;

public class DbLogger : ILogger
{
  public IDisposable? BeginScope<TState>(TState state) where TState : notnull
  {
    return null;
  }

  public bool IsEnabled(LogLevel logLevel)
  {
    return logLevel == LogLevel.Information;
  }

  public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
  {
    // Logar apenas operações aqui
    if (!IsEnabled(logLevel) || eventId.Id != DbLoggerProvider.LogOperationId)
    {
      return;
    }

    JObject valores = new();

    if (!string.IsNullOrWhiteSpace(eventId.Name))
    {
      valores["EventName"] = eventId.Name;
    }

    if (!string.IsNullOrWhiteSpace(formatter(state, exception)))
    {
      valores["Message"] = formatter(state, exception);
    }

    using DbContexto contexto = new();

    // Adicionar o log ao banco de dados
    contexto.Logs.Add(new Log
    {
      Created = DateTime.Now,
      Values = JsonConvert.SerializeObject(valores)
    });

    contexto.SaveChanges();
  }
}
