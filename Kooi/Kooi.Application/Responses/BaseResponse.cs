namespace Kooi.Application.Responses
{
    public class BaseResponse<T>
    {
        public BaseResponse()
        {
        }

        public BaseResponse(T data)
        {
            Data = data;
        }

        public T Data { get; set; }
    }
}
