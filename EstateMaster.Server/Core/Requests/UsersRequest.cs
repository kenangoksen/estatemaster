using System.ComponentModel.DataAnnotations;

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
        public string description { get; set; }
        public string email { get; set; }


    }

    public class CreateUserRequest
    {
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
        public string description { get; set; }
        public string email { get; set; }
    }

    public class AdminCreateUserRequest
    {
        [Required]
        public string name { get; set; }

        [Required]
        public string surname { get; set; }

        [Phone]
        public string phone { get; set; }

        [Required]
        public string state { get; set; } // Adminin kullanıcıya atayacağı durum

        [Required]
        public string userType { get; set; } // Adminin kullanıcıya atayacağı tip (örn: 'USER', 'ADMIN', 'MANAGER')

        [Required]
        [MinLength(4, ErrorMessage = "Kullanıcı adı en az 4 karakter olmalıdır.")]
        public string username { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
        public string password { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }

        public string description { get; set; }

        // targetCompanyId kaldırıldı, çünkü admin kendi şirketine ekleyecek.
    }

    public class UpdateUserRequest
    {
        [Required]
        public string id { get; set; } // Güncellenecek kullanıcının ID'si

        [Required]
        public string name { get; set; }

        [Required]
        public string surname { get; set; }

        [Phone]
        public string phone { get; set; }

        [Required]
        public string state { get; set; }

        [Required]
        public string userType { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }

        public string description { get; set; }
    }

    public class UsersRequestID
    {
        public string id { get; set; }
    }

    public class DeleteUserRequest
    {
        public string id { get; set; }
    }

    public class SuccessResponse
    {
        public string Message { get; set; }
        public string UserId { get; set; }
    }

    // Hata yanıtı modeli
    public class ErrorResponse
    {
        public string Message { get; set; }
        public string Code { get; set; } // Hata kodu eklenebilir (isteğe bağlı)
    }
}