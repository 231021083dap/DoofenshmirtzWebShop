using DoofenshmirtzsWebShop.Authorization;
using DoofenshmirtzsWebShop.Database.Entities;
using DoofenshmirtzsWebShop.DTOs.Requests;
using DoofenshmirtzsWebShop.DTOs.Responses;
using DoofenshmirtzsWebShop.Helpers;
using DoofenshmirtzsWebShop.Repositories;
using DoofenshmirtzsWebShop.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

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
        private readonly JwtUtils _jwt;
        private readonly Mock<IUserRepository> _userRepository = new();
        private readonly Mock<IJwtUtils> _jwtUtils = new();

        public UserServicesTests()
        {
            _sut = new UserServices(_userRepository.Object, _jwtUtils.Object);
        }

        [Fact]
        public async void getAll_shouldReturnListOfUserResponses_whenUserExists()
        {
            List<User> users = new();

            users.Add(new User
            {
                userID = 1,
                userEmail = "test@tests.dk",
                userPassword = "Grrrr",
                userName = "Testa"
            });

            users.Add(new User
            {
                userID = 2,
                userEmail = "testa@test.dk",
                userPassword = "Grrrr",
                userName = "Tests"
            });

            _userRepository.Setup(u => u.getAll())
                .ReturnsAsync(users);

            var result = await _sut.getAll();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.IsType<List<UserResponse>>(result);
        }

        [Fact]
        public async void register_shouldReturnUserResponse_whenRegisterIsSuccessful()
        {
            NewUser newUser = new NewUser
            {
                userEmail = "platypus@perry.com",
                userPassword = "Grrrr",
                userName = "Agent P",
                userRole = Role.User
            };
            int userID = 1;
            User user = new User
            {
                userID = userID,
                userEmail = "platypus@perry.com",
                userPassword = "Grrrr",
                userName = "Agent P",
                userRole = Role.User
            };

            _userRepository.Setup(u => u.register(It.IsAny<User>()))
                .ReturnsAsync(user);

            var result = await _sut.register(newUser);

            Assert.NotNull(result);
            Assert.IsType<UserResponse>(result);
            Assert.Equal(userID, result.ID);
            Assert.Equal(newUser.userEmail, result.email);
            Assert.Equal(newUser.userPassword, result.password);
            Assert.Equal(newUser.userName, result.name);
        }
    }
}
