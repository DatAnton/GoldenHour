namespace GoldenHour.Application.Core
{
    public class AppException
    {
        public AppException(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }

    }
}
