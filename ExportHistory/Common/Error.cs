
namespace ExportHistoryLib.Common
{
    public class Error : IError
    {
        private string _message;
        public string Message { get => _message; }

        public Error(string message) 
        {
            _message = message;
        }
    }
}
