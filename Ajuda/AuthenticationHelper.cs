using System.Text;

namespace Ajuda 
{
    public static class AuthenticationHelper
    {
        public static string ComputeHash(string input)
        {
            var sha1 = System.Security.Cryptography.SHA1.Create();

            byte[] bytes = Encoding.UTF8.GetBytes(input);
            var hash = sha1.ComputeHash(bytes);
            return System.Convert.ToBase64String(hash);
        }
    }
}