namespace EstateMaster.Server.Core.Models
{
    public class User : BaseEntity
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string phone { get; set; }
        public string state { get; set; }
        public string userType { get; set; }
    }
}
