namespace EstateMaster.Server.Core.Helpers
{
    public class SuccessResponse<T>
    {
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "İşlem Başarılı";
        public T Data { get; set; }
    }
}