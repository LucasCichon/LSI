namespace ExportHistoryLib.Common.Error
{
    public class Error : IError
    {
        private string _message;
        private ErrorType _type;
        public string Message { get => _message; }

        public ErrorType Type { get => _type; }

        public Error(string message)
        {
            _message = message;
        }
        public Error(string message, ErrorType type)
        {
            _message = message;
            _type = type;
        }
    }
}
