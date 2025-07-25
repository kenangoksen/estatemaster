namespace EstateMaster.Server.Models
{
    /// <summary>
    /// Müşteri aktiflik durumu değiştirme isteği.
    /// </summary>
    public class ToggleCustomerRequest
    {
        public string Id { get; set; }  // Müşteri UUID
    }
}