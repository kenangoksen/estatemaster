namespace EstateMaster.Server.Models
{
  /// <summary>
  /// Aktiflik durumu değişimi sonrası dönüş bilgisi.
  /// </summary>
  public class ToggleCustomerResponse
  {
    public string Result { get; set; }   // Örn: TOGGLED, NOT_FOUND
  }
}