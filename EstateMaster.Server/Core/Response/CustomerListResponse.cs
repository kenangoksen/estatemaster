namespace EstateMaster.Server.Models
{/// <summary>
 /// Müşteri listesi için gereken dönüş modelidir.
 /// Sadece aktif müşterileri döndürür.
 /// </summary>
    public class CustomerListResponse
    {
        public string Id { get; set; }                 // UUID
        public string FirstName { get; set; }          // Ad
        public string LastName { get; set; }           // Soyad
        public string Email { get; set; }              // E-posta
        public string Phone { get; set; }              // Telefon
        public string CustomerType { get; set; }       // Tür (buyer/seller)
        public DateTime CreatedAt { get; set; }        // Oluşturulma tarihi
    }
}