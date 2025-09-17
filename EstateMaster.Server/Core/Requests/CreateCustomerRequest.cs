namespace EstateMaster.Server.Models
{/// <summary>
 /// Müşteri oluşturma işlemi için gerekli alanları içerir.
 /// API üzerinden alınan veriler bu sınıf ile taşınır.
 /// </summary>
    public class CreateCustomerRequest
    {
        public string session_id { get; set; }
        public string company_id { get; set; }
        public string CustomerType { get; set; }
        public string AssignedUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Gender { get; set; }
        public double? BudgetMin { get; set; }
        public double? BudgetMax { get; set; }
        public string PreferredProvince { get; set; }
        public string PreferredDistrict { get; set; }
        public string PreferredNeighborhood { get; set; }
        public double? PreferredSquareMeters { get; set; }
        public string PreferredRoomCount { get; set; }
        public string Amenities { get; set; }
        public string Facade { get; set; }
        public string Source { get; set; }
        public DateTime? LastInteraction { get; set; }
        public string Notes { get; set; }
        public string created_by { get; set; }
    }

}