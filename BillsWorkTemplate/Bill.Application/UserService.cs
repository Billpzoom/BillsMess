using System;
using Bill.Domain.Auth;
using Bill.IApplication;
using Bill.IRepository;

namespace Bill.Application
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public User Login(string username, string password)
        {
            User user = null;
            try
            {
                _unitOfWork.Start();
                user = _userRepository.GetUserByLoginInfo(username, password);
                _unitOfWork.Commit();
            }
            catch (Exception e)
            {
                _unitOfWork.Rollback();
                Console.WriteLine(e.Message);
            }
            return user;
        }
    }
}