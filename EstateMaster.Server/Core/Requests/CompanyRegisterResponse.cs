namespace EstateMaster.Server.Models
{
    /// <summary>
    /// Şirket kayıt işlemi için gerekli alanları içerir.
    /// API üzerinden alınan veriler bu sınıf ile taşınır.
    /// </summary>
    public class CompanyRegisterRequest
{
    public string CompanyName { get; set; }
    public string CompanyEmail { get; set; }
    public string UserName { get; set; }
    public string UserSurname { get; set; }
    public string UserUsername { get; set; }
    public string UserPassword { get; set; }
    public string UserEmail { get; set; }
}

}