namespace EstateMaster.Server.Models
{
  /// <summary>
  /// Müşteri oluşturma işleminin sonucunu temsil eder.
  /// SP'den dönen intID (UUID) ve oresult durumunu taşır.
  /// </summary>
  public class CustomerResponse
  {
    public string id { get; set; }
    public DateTime? created_at { get; set; }
    public DateTime? updated_at { get; set; }
    public string created_by { get; set; }
    public string customer_type { get; set; }
    public string assigned_user_id { get; set; }

    public string first_name { get; set; }
    public string last_name { get; set; }
    public string email { get; set; }
    public string phone { get; set; }
    public DateTime? birth_date { get; set; }
    public string gender { get; set; }

    public string budget_min { get; set; }
    public string budget_max { get; set; }

    public string preferred_province { get; set; }
    public string preferred_district { get; set; }
    public string preferred_neighborhood { get; set; }
    public string preferred_square_meters { get; set; }
    public string preferred_room_count { get; set; }

    public string amenities { get; set; }        // JSON veya virgülle ayrılmış liste olabilir
    public string facade { get; set; }
    public string source { get; set; }

    public DateTime? last_interaction { get; set; }
    public string notes { get; set; }
    public string updated_by { get; set; }
    public string company_id { get; set; }
    public string session_id { get; set; }
  }
}