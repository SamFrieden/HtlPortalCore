namespace HtlPortalCore.Models
{
    public class ResponseModel
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string RedirectUrl { get; set; }
        public bool IsError { get; set; }
    }
}
