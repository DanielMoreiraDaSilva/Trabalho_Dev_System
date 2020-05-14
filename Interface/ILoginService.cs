using Model;

namespace Interface
{
    public interface ILoginService
    {
        (User user, string token) Authenticate(Login login);
    }
}