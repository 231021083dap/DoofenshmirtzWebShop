using DoofenshmirtzsWebShop.Helpers;
using DoofenshmirtzsWebShop.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoofenshmirtzsWebShop.Authorization
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;

        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;
        }

        public async Task Invoke(HttpContext context, IUserService userService, IJwtUtils jwtUtils)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userID = jwtUtils.ValidateJwtToken(token);
            if (userID != null)
            {
                // Attach user to context on succesful Jwt validation
                context.Items["User"] = await userService.getByID(userID.Value);
            }
            await _next(context);
        }
    }
}
