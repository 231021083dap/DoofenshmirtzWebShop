using DoofenshmirtzsWebShop.Controllers;
using DoofenshmirtzsWebShop.Database.Entities;
using DoofenshmirtzsWebShop.DTOs.Requests;
using DoofenshmirtzsWebShop.DTOs.Responses;
using DoofenshmirtzsWebShop.Repositories;
using DoofenshmirtzsWebShop.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DoofenshmirtzsWebShopUserTests
{
    public class UserControllerTests
    {
        private readonly UserController _sut;
        private readonly Mock<IUserService> _userService = new();

        public UserControllerTests()
        {
            _sut = new UserController(_userService.Object);
            _sut.ControllerContext.HttpContext = new DefaultHttpContext() { };
        }

        [Fact]
        public async void getAll_shouldReturnStatusCode200_whenDataExists()
        {
            List<UserResponse> users = new();

            users.Add(new UserResponse
            {
                ID = 1, 
                email = "doofen@evil.com",
                password = "DamnYouPerry",
                username = "Doof",
                role = DoofenshmirtzsWebShop.Helpers.Role.Admin
            });

            users.Add(new UserResponse
            {
                ID = 2, 
                email = "perry@platypus.com",
                password = "GrRrRr",
                username = "Agent P", 
                role = DoofenshmirtzsWebShop.Helpers.Role.User
            });

            _userService.Setup(s => s.getAll())
                .ReturnsAsync(users);

            var result = await _sut.getAll();

            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void getAll_shouldReturnStatusCode204_whenNoDataExists()
        {
            List<UserResponse> users = new();

            _userService.Setup(s => s.getAll())
                .ReturnsAsync(users);

            var result = await _sut.getAll();

            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(204, statusCodeResult.StatusCode);
        }

        
        [Fact]
        public async void getByID_shouldReturnUnauthorized_whenUserIsNotLoggedIn()
        {
            _sut.ControllerContext.HttpContext.Items["User"] = null;

            var result = await _sut.getByID(1);

            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(401, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void getByID_shouldReturnUser_whenUserIsLoggedOnAsUser()
        {
            _sut.ControllerContext.HttpContext.Items["User"] = new UserResponse
            {
                ID = 2,
                role = DoofenshmirtzsWebShop.Helpers.Role.User
            };

            UserResponse user = new UserResponse
            {
                ID = 2,
                email = "test@test.dk",
                username = "Test"
            };

            _userService.Setup(u => u.getByID(It.IsAny<int>()))
                .ReturnsAsync(user);

            var result = await _sut.getByID(2);

            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void getAll_shouldReturnStatusCode500_whenNullIsReturnedFromService()
        {
            List<UserResponse> users = new();

            _userService.Setup(s => s.getAll())
                .ReturnsAsync(() => null);

            var result = await _sut.getAll();

            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void getAll_shouldReturnStatusCode500_whenExceptionIsRaised()
        {
            List<UserResponse> users = new();

            _userService.Setup(s => s.getAll())
                .ReturnsAsync(() => throw new System.Exception("This is an exception"));

            var result = await _sut.getAll();

            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void create_shouldReturnStatusCode200_whenCreateIsSuccessful()
        {
            int userID = 1;

            NewUser newUser = new NewUser
            {
                email = "perry@platypus.com",
                username = "Perry",
                password = "Platypus"
            };
            User user = new User
            {
                userID = userID,
                userEmail = "perry@platypus.com",
                userName = "Perry",
                userPassword = "Platypus"
            };

            //_userService.Setup(s => s.Register(It.IsAny<RegisterUser>())).ReturnsAsync(user);

            var result = await _sut.register(newUser);

            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
            
        }
        
    }
}
