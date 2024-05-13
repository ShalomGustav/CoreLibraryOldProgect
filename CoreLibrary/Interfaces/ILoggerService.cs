namespace CoreLibrary.Interfaces
{
    public interface ILoggerService
    {
        string GetLog();
        NLog.Logger Logger { get; }
    }
}
