namespace EstateMaster.Server.Core.Helpers
{
    public class ErrorResponse
    {
        public bool IsSuccess { get; set; } = false;
        public string Message { get; set; } = "Bir hata oluştu.";
        public string Code { get; set; } // Özel hata kodu (örn: AUTH-01)
    }
}