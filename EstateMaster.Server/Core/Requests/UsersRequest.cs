namespace EstateMaster.Server.Models
{
    public class UsersRequest
    {
        public string id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string created_by { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string phone { get; set; }
        public string state { get; set; }
        public string userType { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public DateTime login_date { get; set; }
      
    }
}