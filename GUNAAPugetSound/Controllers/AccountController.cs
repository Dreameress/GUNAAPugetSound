using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GUNAAPugetSound.DTOs;
using GUNAAPugetSound.Models;
using GUNAAPugetSound.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GUNAAPugetSound.Controllers
{
    
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender,
            ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _logger = logger;
        }

        [TempData]
        public string ErrorMessage { get; set; }



        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            return Ok();
        }

        [HttpPost("[action]")]
        public void Login([FromBody]UserDto model)
        {
            //if (!ModelState.IsValid) return BadRequest("Invalid Logid. Please try again.");
            //// This doesn't count login failures towards account lockout
            //// To enable password failures to trigger account lockout, set lockoutOnFailure: true
            //var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false,
            //    false);
            //if (result.Succeeded)
            //{
            //    _logger.LogInformation("User logged in.");
            //    return Ok("Login Successful");
            //}
            //if (result.RequiresTwoFactor)
            //{
            //    return BadRequest("Requires 2 Factor Auth");
            //    //RedirectToAction(nameof(LoginWith2fa), new {returnUrl, model.RememberMe});
            //}
            //if (result.IsLockedOut)
            //{
            //    _logger.LogWarning("User account locked out.");
            //    return BadRequest("User account locked out.");
            //}

            //ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            //return BadRequest("Invalid login attempt.");

            // If we got this far, something failed, redisplay form
        }


    }
}