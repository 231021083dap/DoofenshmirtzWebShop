using DoofenshmirtzsWebShop.Controllers;
using DoofenshmirtzsWebShop.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
