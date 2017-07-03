using System.Collections.Generic;
using Bill.Domain.Auth;

namespace Bill.IApplication
{
    public interface IUserService
    {
        User Login(string username, string password);
    }
}