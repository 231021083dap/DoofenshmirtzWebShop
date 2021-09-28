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
            int ID = 1;
            User user = new User
            {
                userID = ID,
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
            Assert.Equal(ID, result.ID);
            Assert.Equal(newUser.userEmail, result.email);
            Assert.Equal(newUser.userPassword, result.password);
            Assert.Equal(newUser.userName, result.username);
            Assert.Equal(newUser.userRole, result.Role);
        }

        [Fact]
        public async void getAll_shouldReturnEmptyListOfUserResponses_whenUserDoesNotExists()
        {
            List<User> users = new List<User>();

            _userRepository.Setup(u => u.getAll())
                .ReturnsAsync(users);

            var result = await _sut.getAll();

            Assert.NotNull(result);
            Assert.Empty(result);
            Assert.IsType<List<UserResponse>>(result);
        }

        [Fact]
        public async void getByID_shouldReturnUserResponse_whenUserExists()
        {
            int userID = 1;

            User user = new User
            {
                userID = userID,
                userEmail = "george@test.dk",
                userPassword = "georg",
                userName = "The G",
                userRole = Role.User
            };

            _userRepository.Setup(u => u.getByID(It.IsAny<int>()))
                .ReturnsAsync(user);

            var result = await _sut.getByID(userID);

            Assert.NotNull(result);
            Assert.IsType<UserResponse>(result);
            Assert.Equal(userID, result.ID);
            Assert.Equal(user.userEmail, result.email);
            Assert.Equal(user.userPassword, result.password);
            Assert.Equal(user.userName, result.username);
            Assert.Equal(user.userRole, result.Role);
        }

        [Fact]
        public async void getByID_shouldReturnNull_whenUserDoesNotExist()
        {
            int userID = 1;

            _userRepository.Setup(u => u.getByID(It.IsAny<int>()))
                .ReturnsAsync(() => null);

            var result = await _sut.getByID(userID);

            Assert.Null(result);
        }

        [Fact]
        public async void update_shouldReturnUpdatedUserResponse_whenUpdateIsSuccessful()
        {
            UpdateUser updateUser = new UpdateUser
            {
                userEmail = "tests@testa.dk",
                userPassword = "George",
                userName = "George",
                userRole = Role.User
            };

            int ID = 1;

            User user = new User
            {
                userID = ID,
                userEmail = "tests@testa.dk",
                userPassword = "George",
                userName = "George",
                userRole = Role.User
            };

            _userRepository.Setup(u => u.update(It.IsAny<int>(), It.IsAny<User>()))
                .ReturnsAsync(user);

            var result = await _sut.update(ID, updateUser);

            Assert.NotNull(result);
            Assert.IsType<UserResponse>(result);
            Assert.Equal(ID, result.ID);
            Assert.Equal(updateUser.userEmail, result.email);
            Assert.Equal(updateUser.userPassword, result.password);
            Assert.Equal(updateUser.userName, result.username);

        }

        [Fact]
        public async void update_shouldReturnNull_whenUserDoesNotExist()
        {
            UpdateUser updateUser = new UpdateUser
            {
                userEmail = "John@dieharder.dk",
                userPassword = "George",
                userName = "John",
                userRole = Role.User
            };

            int ID = 1;

            _userRepository.Setup(u => u.update(It.IsAny<int>(), It.IsAny<User>()))
                .ReturnsAsync(() => null);

            var result = await _sut.update(ID, updateUser);

            Assert.Null(result);
        }

        [Fact]
        public async void authenticate_shouldReturnTrue_whenAuthenticateIsSuccessful()
        {
            string email = "perry@platypus.com", password = "Grrrr";

            LoginRequest login = new LoginRequest
            {
                Email = email,
                Password = password
            };

            
        }

        [Fact]
        public async void delete_shouldReturnTrue_whenDeleteIsSuccessful()
        {
            int ID = 1;

            User user = new User
            {
                userID = ID,
                userEmail = "perry@platypus.com",
                userPassword = "Grrrr",
                userName = "Perry",
                userRole = Role.User
            };

            _userRepository.Setup(u => u.delete(It.IsAny<int>()))
                .ReturnsAsync(user);

            var result = await _sut.delete(ID);

            Assert.True(result);
        }
    }
}
