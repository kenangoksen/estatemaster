namespace EstateMaster.Server.Models
{
    public class PropertiesResponse
    {
        public string id { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public string created_by { get; set; }
        public string property_type { get; set; } // Emlak türü
        public string user_id { get; set; } // Kullanıcı ID
        public string title { get; set; } // Mülk başlığı
        public string description { get; set; } // Açıklama
        public double price { get; set; } // Fiyat (₺)
        public string province { get; set; } // İl
        public string district { get; set; } // İlçe
        public string neighborhood { get; set; } // İlçe
        public double square_meters_net { get; set; } // Metrekare
        public string estate_status_type { get; set; }  // Emlak durumu - Kiralık-Satılık

    }
}