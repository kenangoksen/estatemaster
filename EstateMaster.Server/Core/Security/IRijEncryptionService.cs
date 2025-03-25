
namespace EstateMaster.Server.Security
{
    public interface IRijEncryptionService
    {
        string Decrypt(string encrypted);
        string Encrypt(string plainText);
    }
}