using DoofenshmirtzsWebShop.Authorization;
using DoofenshmirtzsWebShop.Database.Entities;
using DoofenshmirtzsWebShop.DTOs.Requests;
using DoofenshmirtzsWebShop.DTOs.Responses;
using DoofenshmirtzsWebShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoofenshmirtzsWebShop.Services
{
    public interface IUserService
    {
        Task<List<UserResponse>> getAll();
        Task<UserResponse> getByID(int userID);
        Task<LoginResponse> Authenticate(LoginRequest login);
        Task<UserResponse> register(NewUser newUser);
        Task<UserResponse> update(int userID, UpdateUser updateUser);
        Task<bool> delete(int userID);
    }
    public class UserServices : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtUtils _jwtUtils;

        public UserServices(IUserRepository userRepository, IJwtUtils jwtUtils)
        {
            _userRepository = userRepository;
            _jwtUtils = jwtUtils;
        }

        public async Task<List<UserResponse>> getAll()
        {
            List<User> users = await _userRepository.getAll();

            return users == null ? null : users.Select(u => new UserResponse
            {
                ID = u.userID,
                email = u.userEmail,
                password = u.userPassword,
                username = u.userName,
                role = u.userRole,
            }).ToList();
        }

        public async Task<UserResponse> getByID(int userID)
        {
            User user = await _userRepository.getByID(userID);
            return userResponse(user);
        }

        public async Task<LoginResponse> Authenticate(LoginRequest login)
        {
            User user = await _userRepository.getByUsername(login.Username);
            if (user == null)
            {
                return null;
            }

            if (user.userPassword== login.Password)
            {
                LoginResponse response = new LoginResponse
                {
                    Id = user.userID,
                    Email = user.userEmail,
                    Username = user.userName,
                    Role = user.userRole,
                    Token = _jwtUtils.GenerateJwtToken(user)
                };
                return response;
            }
            return null;
        }

        public async Task<UserResponse> register(NewUser newUser)
        {
            User user = new User
            {
                userEmail = newUser.email,
                userPassword = newUser.password,
                userName = newUser.username,
                userRole = Helpers.Role.User // Force all users created through register to Role.User
            };

            user = await _userRepository.register(user);

            return userResponse(user);
        }

        public async Task<UserResponse> update(int userID, UpdateUser updateUser)
        {
            User user = new User
            {
                userEmail = updateUser.email,
                userName = updateUser.username,
                //userPassword = updateUser.password,
                userRole = updateUser.role
            };

            user = await _userRepository.update(userID, user);

            return user == null ? null : new UserResponse
            {
                ID = user.userID,
                email = user.userEmail,
                username = user.userName,
                //password = user.userPassword,
                role = user.userRole
            };
        }

        public async Task<bool> delete(int userID)
        {
            var result = await _userRepository.delete(userID);
            return true;
        }

        private UserResponse userResponse(User user)
        {
            return user == null ? null : new UserResponse
            {
                ID = user.userID,
                email = user.userEmail,
                password = user.userPassword,
                username = user.userName,
                role = user.userRole
            };
        }

    }
}
