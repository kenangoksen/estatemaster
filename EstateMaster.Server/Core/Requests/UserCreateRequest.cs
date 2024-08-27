namespace EstateMaster.Server.Models
{
    public class AddUserRequest
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string phone { get; set; }
        public string state { get; set; }
        public string userType { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public DateTime loginDate { get; set; }
        public string session_id { get; set; }
    }
}