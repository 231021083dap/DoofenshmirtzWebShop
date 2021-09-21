using DoofenshmirtzsWebShop.Authorization;
using DoofenshmirtzsWebShop.Repositories;
using DoofenshmirtzsWebShop.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoofenshmirtzsWebShopUserTests
{
    public class UserServicesTests
    {
        //getAll()
        //GetByID(int userID)
        //Authenticate(LoginRequest login)
        //Register(RegisterUser newUser)
        //Update(int userID, UpdateUser updateUser)
        //Delete(int userID)

        private readonly UserServices _sut;
        private readonly Mock<IUserRepository> _userRepository = new();
        //private readonly Mock<IJwtUtils> = _jwtUtils = new();
        /*
        public UserServicesTests()
        {
            _sut = new UserServices(_userRepository.Object);
        }*/
    }
}
