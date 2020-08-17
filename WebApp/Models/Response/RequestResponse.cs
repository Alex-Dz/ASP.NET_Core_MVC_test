namespace WebApp.Models.Response
{
    public class RequestResponse
    {
        public int Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public RequestResponse()
        {
            Success = 0;
            Message = null;
            Data = null;
        }

        public RequestResponse(int success, object data)
        {
            this.Success = success;
            this.Message = null;
            this.Data = data;
        }
        
        public RequestResponse(int success, string message, object data)
        {
            this.Success = success;
            this.Message = message;
            this.Data = data;
        }
    }
}