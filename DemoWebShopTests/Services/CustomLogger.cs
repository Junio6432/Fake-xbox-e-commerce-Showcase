using Microsoft.Extensions.Logging;

public interface ICustomLogger:ILogger
{
    void Log(string message);

}

public class CustomLogger<T> : ICustomLogger
{
    public IDisposable BeginScope<TState>(TState state)
    {
        throw new NotImplementedException();
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        throw new NotImplementedException();
    }

    public  void Log(string message)
    {
        //
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        //
    }
}
