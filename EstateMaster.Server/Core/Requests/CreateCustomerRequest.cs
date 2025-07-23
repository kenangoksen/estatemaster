namespace EstateMaster.Server.Models
{/// <summary>
 /// Müşteri oluşturma işlemi için gerekli alanları içerir.
 /// API üzerinden alınan veriler bu sınıf ile taşınır.
 /// </summary>
    public class CreateCustomerRequest
    {
        public string FirstName { get; set; }                // Müşteri adı
        public string LastName { get; set; }                 // Müşteri soyadı
        public string Email { get; set; }                    // E-posta adresi
        public string Phone { get; set; }                    // Telefon numarası
        public string CustomerType { get; set; }             // Müşteri tipi (örneğin "buyer" / "seller")
        public double BudgetMin { get; set; }                // Minimum bütçe
        public double BudgetMax { get; set; }                // Maksimum bütçe
        public string PreferredProvince { get; set; }        // Tercih edilen il
        public string PreferredDistrict { get; set; }        // Tercih edilen ilçe
        public string PreferredNeighborhood { get; set; }    // Tercih edilen mahalle
    }

}