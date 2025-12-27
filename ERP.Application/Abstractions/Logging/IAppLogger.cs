namespace ERP.Application.Abstractions.Logging;

public interface IAppLogger<T>
{
    void Debug(string message, params object[] args);
    void Info(string message, params object[] args);
    void Warn(string message, params object[] args);
    void Error(Exception ex, string message, params object[] args);
}