using DoofenshmirtzsWebShop.Database;
using DoofenshmirtzsWebShop.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoofenshmirtzsWebShop.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> getAll();
        Task<User> create(User user);
        Task<User> getByEmail(string Email);
        Task<User> getByID(int userId);
        Task<User> update(int userId, User user);
        Task<User> delete(int userId);
    }

    public class UserRepository : IUserRepository
    {
        private readonly DoofenshmirtzWebShopContext _context;

        public UserRepository(DoofenshmirtzWebShopContext context)
        {
            _context = context;
        }

        public async Task<List<User>> getAll()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<User> create(User user)
        {
            if (_context.User.Any(u => u.userEmail == user.userEmail))
            {
                throw new Exception("Email " + user.userEmail + "is not available");
            }

            if (_context.User.Any(u => u.userName == user.userName))
            {
                throw new Exception("Username " + user.userName + "is not available");
            }

            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> getByEmail(string Email)
        {
            return await _context.User.FirstOrDefaultAsync(u => u.userEmail == Email);
        }

        public async Task<User> getByID(int userID)
        {
            return await _context.User.FirstOrDefaultAsync(u => u.userID == userID);
        }

        public async Task<User> update(int userID, User user)
        {
            User updateUser = await _context.User.FirstOrDefaultAsync(u => u.userID == userID);

            if (updateUser != null)
            {
                if (_context.User.Any(u => u.userID != userID && u.userEmail == user.userEmail))
                {
                    throw new Exception("Email" + user.userEmail + "is not available");
                }

                if (_context.User.Any(u => u.userID != userID && u.userName == user.userName))
                {
                    throw new Exception("Username" + user.userName + "is not available");
                }

                updateUser.userEmail = user.userEmail;
                updateUser.userName = user.userName;

                if (user.userPassword != null)
                {
                    updateUser.userPassword = user.userPassword;
                }
            }
            return updateUser;
        }

        public async Task<User> delete(int userID)
        {
            User user = await _context.User.FirstOrDefaultAsync(u => u.userID == userID);

            if (user != null)
            {
                _context.User.Remove(user);
                await _context.SaveChangesAsync();
            }
            return user;
        }
    }
}
