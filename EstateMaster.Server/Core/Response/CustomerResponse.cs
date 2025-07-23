namespace EstateMaster.Server.Models
{
  /// <summary>
/// Müşteri oluşturma işleminin sonucunu temsil eder.
/// SP'den dönen intID (UUID) ve oresult durumunu taşır.
/// </summary>
public class CustomerResponse
{
    public string Id { get; set; }            // Oluşturulan müşteri UUID
    public string Result { get; set; }        // SP dönüş sonucu (örneğin "CREATED", "EMAIL_EXISTS")
    public DateTime CreatedAt { get; set; }   // Oluşturulma zamanı
}
}