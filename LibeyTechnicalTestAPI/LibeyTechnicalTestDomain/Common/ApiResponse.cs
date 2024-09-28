namespace LibeyTechnicalTestDomain.Common
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; }

        public ApiResponse(T data, string message = "", bool status = true)
        {
            this.Data = data;
            this.Message = message;
            this.Status = status;
        }
    }
}
