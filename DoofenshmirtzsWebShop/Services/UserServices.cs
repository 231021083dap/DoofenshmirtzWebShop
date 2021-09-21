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
        Task<UserResponse> Register(RegisterUser newUser);
        Task<UserResponse> Update(int userID, UpdateUser updateUser);
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
                Role = u.userRole,
            }).ToList();
        }

        public async Task<UserResponse> getByID(int userID)
        {
            User user = await _userRepository.getByID(userID);
            return userResponse(user);
        }

        public async Task<LoginResponse> Authenticate(LoginRequest login)
        {
            User user = await _userRepository.getByEmail(login.Email);
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

        public async Task<UserResponse> Register(RegisterUser newUser)
        {
            User user = new User
            {
                userEmail = newUser.Email,
                userName = newUser.Username,
                userPassword = newUser.Password,
                userRole = Helpers.Role.User // Force all users created through register to Role.User
            };

            user = await _userRepository.register(user);

            return userResponse(user);
        }

        public async Task<UserResponse> Update(int userID, UpdateUser updateUser)
        {
            User user = new User
            {
                userEmail = updateUser.userEmail,
                userName = updateUser.userName,
                userPassword = updateUser.userPassword,
                userRole = updateUser.userRole
            };

            user = await _userRepository.update(userID, user);

            return userResponse(user);
        }

        private UserResponse userResponse(User user)
        {
            return user == null ? null : new UserResponse
            {
                ID = user.userID,
                email = user.userEmail,
                password = user.userPassword,
                username = user.userName,
                Role = user.userRole
            };
        }

    }
}
