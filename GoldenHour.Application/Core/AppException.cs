namespace GoldenHour.Application.Core
{
    public class AppException
    {
        public AppException(string message)
        {
            Message = message;
        }
        public string Message { get; set; }

    }
}
