using Bill.Domain.Auth;

namespace Bill.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByLoginInfo(string username, string password);
    }
}