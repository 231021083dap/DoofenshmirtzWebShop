using DoofenshmirtzsWebShop.Database;
using DoofenshmirtzsWebShop.Database.Entities;
using DoofenshmirtzsWebShop.Helpers;
using DoofenshmirtzsWebShop.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DoofenshmirtzsWebShopUserTests
{
    public class UserRepositoryTests
    {
        private readonly UserRepository _sut;
        private readonly DoofenshmirtzWebShopContext _context;
        private readonly DbContextOptions<DoofenshmirtzWebShopContext> _options;

        public UserRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<DoofenshmirtzWebShopContext>()
                .UseInMemoryDatabase(databaseName: "DoofenshmirtzWebShopUser")
                .Options;

            _context = new DoofenshmirtzWebShopContext(_options);

            _sut = new UserRepository(_context);
        }

        [Fact]
        public async Task getAll_shouldReturnListOfUsers_whenUsersExists()
        {
            await _context.Database.EnsureDeletedAsync();
            _context.User.Add(new User
            {
                userID = 1,
                userName = "Perry",
                userEmail = "perry@platypus.com",
                userPassword = "Grrrr", // 4 + r
                userRole = Role.Admin
            });

            _context.User.Add(new User
            {
                userID = 2,
                userName = "Doof",
                userEmail = "doof@evil.com",
                userPassword = "EvilInc",
                userRole = Role.User
            });

            await _context.SaveChangesAsync();

            var result = await _sut.getAll();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.IsType<List<User>>(result);
        }

        [Fact]
        public async Task getAll_shouldReturnEmptyListOfUsers_whenNoUsersExists()
        {
            await _context.Database.EnsureDeletedAsync();

            await _context.SaveChangesAsync();

            var result = await _sut.getAll();

            Assert.NotNull(result);
            Assert.Empty(result);
            Assert.IsType<List<User>>(result);
        }

        [Fact]
        public async Task register_shouldAddIDToUser_whenSavingToDatabase()
        {
            await _context.Database.EnsureDeletedAsync();
            int expectedID = 1;
            User user = new User
            {
                userName = "Perry",
                userEmail = "perry@platypus.com",
                userPassword = "Grrrr", // 4 + r
                userRole = Role.Admin
            };

            var result = await _sut.register(user);

            Assert.NotNull(result);
            Assert.IsType<User>(result);
            Assert.Equal(expectedID, result.userID);

        }

        [Fact]
        public async Task getByID_shouldReturnUser_ifUserExists()
        {
            await _context.Database.EnsureDeletedAsync();
            int userID = 1;
            _context.User.Add(new User
            {
                userID = userID,
                userName = "Perry",
                userEmail = "perry@platypus.com",
                userPassword = "Grrrr", // 4 + r
                userRole = Role.Admin
            });

            await _context.SaveChangesAsync();

            var result = await _sut.getByID(userID);

            Assert.NotNull(result);
            Assert.IsType<User>(result);
            Assert.Equal(userID, result.userID);
        }

        [Fact]
        public async Task getByID_shouldReturnNull_ifUserDoesNotExist()
        {
            await _context.Database.EnsureDeletedAsync();
            int userID = 1;

            var result = await _sut.getByID(userID);

            Assert.Null(result);
        }

        [Fact]
        public async Task register_shouldFailToAddUser_whenAddingUserWithExistingID()
        {
            await _context.Database.EnsureDeletedAsync();

            User user = new User
            {
                userID = 1,
                userEmail = "perry@platypus.com",
                userPassword = "Grrrr",
                userName = "Perry",
                userRole = Role.User
            };

            _context.User.Add(user);
            await _context.SaveChangesAsync();

            Func<Task> action = async () => await _sut.register(user);


            var ex = await Assert.ThrowsAsync<ArgumentException>(action);

            Assert.Contains("An item with the same key has already been added", ex.Message);
        }

        [Fact]
        public async Task update_shouldChangeValueOnUser_whenUserExists()
        {
            await _context.Database.EnsureDeletedAsync();

            int userID = 1;
            User user = new User
            {
                userID = userID,
                userName = "Perry",
                userEmail = "perry@platypus.com",
                userPassword = "Platypus"
            };
            _context.User.Add(user);
            await _context.SaveChangesAsync();

            User updateUser = new User
            {
                userID = userID,
                userEmail = "doof@evil.com",
                userName = "Doofenia",
                userPassword = "EvilInc"
            };

            var result = await _sut.update(userID, updateUser);

            Assert.NotNull(result);
            Assert.IsType<User>(result);
            Assert.Equal(userID, result.userID);
            Assert.Equal(updateUser.userEmail, result.userEmail);
            Assert.Equal(updateUser.userName, result.userName);
            Assert.Equal(updateUser.userPassword, result.userPassword);
        }

        [Fact]
        public async Task update_shouldReturnNull_whenUserDoesNotExist()
        {
            await _context.Database.EnsureDeletedAsync();

            int userID = 1;

            User updateUser = new User
            {
                userID = userID, 
                userEmail = "perry@platypus.com",
                userName = "Perry",
                userPassword = "Grrrr"
            };

            var result = await _sut.update(userID, updateUser);

            Assert.Null(result);
        }

        [Fact]
        public async Task delete_shouldReturnDeletedUser_whenUserIsDeleted()
        {
            await _context.Database.EnsureDeletedAsync();

            int userID = 1;
            User user = new User
            {
                userID = userID,
                userEmail = "perry@platypus.com",
                userName = "Perry",
                userPassword = "Grrrr",
                userRole = Role.User
            };

            _context.User.Add(user);
            await _context.SaveChangesAsync();

            var result = await _sut.delete(userID);
            var users = await _sut.getAll();

            Assert.NotNull(result);
            Assert.IsType<User>(result);
            Assert.Equal(userID, result.userID);
            Assert.Empty(users);
        }

        [Fact]
        public async Task delete_shouldReturnNull_whenUserDoesNotExist()
        {
            await _context.Database.EnsureDeletedAsync();
            int userID = 1;

            var result = await _sut.delete(userID);

            Assert.Null(result);
        }
    }
}
