using API.Model;

namespace API.Repositry.IRepositry
{
    public interface Iuser
    {
        bool IsUniqueUser(string UserName);
        user Authenticte(string UserName, string Password);
        user Register(string UserName, string Password);
    }
}
