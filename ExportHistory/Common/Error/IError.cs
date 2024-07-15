namespace ExportHistoryLib.Common.Error
{
    public interface IError
    {
        ErrorType Type { get; }
        string Message { get; }
    }
}
