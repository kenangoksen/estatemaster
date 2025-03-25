// using EstateMaster;
// using EstateMaster.Server.Core.Models;
// using Microsoft.AspNetCore.Http.HttpResults;

// public interface IUserService
// {
//     User Authenticate(string username, string password);
//     IEnumerable<User> GetAll();
// }

// public class UserService : IUserService
// {
//     private readonly EMDBContext _context;

//     public UserService(EMDBContext context)
//     {
//         _context = context;
//     }

//     public User Authenticate(string username, string password)
//     {
//         var user = _context.Users.SingleOrDefault( x=> x.username == username && x.password == password);

//         if(user == null)
//         {
//             return null;
//         }    
//         user.loginDate = DateTime.Now;
//         _context.SaveChanges();

//         return user;
//     }

//     public IEnumerable<User> GetAll()
//     {
//         return _context.Users;
//     }
// }