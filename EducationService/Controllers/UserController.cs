using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EducationService.Models;
using EducationService.Service;

namespace EducationService.Controllers
{
	[Route("[controller]/[action]")]
	[ApiController]
	public class UserController : Controller
	{
		private readonly UserService _userService;

		public UserController(UserService userService)
		{
			_userService = userService;
		}

		[HttpPost]
		public async Task<IActionResult> Login(UserLogin userLogin)
		{

			try
			{
				var isLoggedIn = await _userService.LoginAsync(userLogin);

				if (!isLoggedIn)
				{
					return Unauthorized();
				}

				return Ok();
			}
			catch (Exception ex)
			{

				return BadRequest();
			}
		}



		[HttpPost]
		public async Task<IActionResult> Register(UserRegistration userRegistration)
		{
			try
			{
				var isRegistered = await _userService.RegisterAsync(userRegistration);

				if (!isRegistered)
				{
					return BadRequest();
				}

				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest();
			}
		}


	}
}
