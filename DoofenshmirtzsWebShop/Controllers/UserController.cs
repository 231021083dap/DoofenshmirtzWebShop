﻿using DoofenshmirtzsWebShop.Authorization;
using DoofenshmirtzsWebShop.DTOs.Requests;
using DoofenshmirtzsWebShop.DTOs.Responses;
using DoofenshmirtzsWebShop.Helpers;
using DoofenshmirtzsWebShop.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoofenshmirtzsWebShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("Authorization")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Authenticate(LoginRequest login)
        {
            try
            {
                LoginResponse response = await _userService.Authenticate(login);
                if (response == null)
                {
                    return Unauthorized();
                }
                return Ok(Response);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> register([FromBody] NewUser newUser)
        {
            try
            {
                UserResponse user = await _userService.register(newUser);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [Authorize(Role.Admin)] // Only admins are allowed to enter this endpoint
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> getAll()
        {
            try
            {
                List<UserResponse> users = await _userService.getAll();
                if (users == null)
                {
                    return Problem("Got no data - not even an empty list - unexpected");
                }
                if (users.Count == 0)
                {
                    return NoContent();
                }
                return Ok(users);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }


        [Authorize(Role.User, Role.Admin)]
        [HttpGet("{user.ID}")]
        public async Task<IActionResult> getByID([FromRoute] int userID)
        {
            try
            {
                // Only admins can access other user records
                var currentUser = (UserResponse)HttpContext.Items["User"];

                if (userID != currentUser.ID && currentUser.Role != Role.Admin)
                {
                    return Unauthorized(new { message = "Unauthorized" });
                }

                UserResponse user = await _userService.getByID(userID);

                if (user == null)
                {
                    return NoContent();
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

        }
    }
 }
