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
                Role = DoofenshmirtzsWebShop.Helpers.Role.Admin
            });

            users.Add(new UserResponse
            {
                ID = 2, 
                email = "perry@platypus.com",
                password = "GrRrRr",
                username = "Agent P", 
                Role = DoofenshmirtzsWebShop.Helpers.Role.User
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
        public async void getByID_shouldReturnStatusCode404_whenUserDoesNotExist()
        {
            int userID = 1;
            

    
            _userService
                .Setup(s => s.getByID(It.IsAny<int>()))
                .ReturnsAsync(() => null);

            var result = await _sut.getByID(userID);

            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(404, statusCodeResult.StatusCode);
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
                userEmail = "perry@platypus.com",
                userName = "Perry",
                userPassword = "Platypus"
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
