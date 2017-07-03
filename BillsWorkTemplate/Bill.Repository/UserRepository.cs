using Bill.Domain.Auth;
using Bill.IRepository;

namespace Bill.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public User GetUserByLoginInfo(string username, string password)
        {
            return Session.QueryOver<User>().Where(u => u.UserName == username && u.Password == password)
                .SingleOrDefault();
        }
    }
}