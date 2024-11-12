namespace API.Helpers
{
    public class ErrorResponse
    {
        public ErrorResponse(int statusCode, string message, string? errorDescription)
        {
            StatusCode = statusCode;
            Message = message;
            ErrorDescription = errorDescription;
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string? ErrorDescription { get; set; } 

    }
}
