// HermesChat - Simple real-time chat application.
// Copyright (C) 2021  Jerrett D. Davis
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.

using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Domain.Models;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebUi.Areas.Identity.Pages.Account
{
    [PublicAPI]
    [AllowAnonymous]
    public class LoginWith2faModel : PageModel
    {
        private readonly ILogger<LoginWith2faModel> _logger;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public LoginWith2faModel(
            SignInManager<ApplicationUser> signInManager,
            ILogger<LoginWith2faModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;

            Input = new InputModel();
        }

        [BindProperty] public InputModel Input { get; set; }

        public bool RememberMe { get; set; }

        public string? ReturnUrl { get; set; }

        public async Task<IActionResult> OnGetAsync(
            bool rememberMe,
            string? returnUrl = null)
        {
            // Ensure the user has gone through the username & password screen first
            var user = await _signInManager
                .GetTwoFactorAuthenticationUserAsync();

            if (user == null)
                throw new InvalidOperationException(
                    "Unable to load two-factor authentication user.");

            ReturnUrl = returnUrl;
            RememberMe = rememberMe;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(
            bool rememberMe,
            string? returnUrl = null)
        {
            if (!ModelState.IsValid)
                return Page();

            returnUrl ??= Url.Content("~/");

            var user = await _signInManager
                .GetTwoFactorAuthenticationUserAsync();
            if (user == null)
                throw new InvalidOperationException("Unable to load two-factor authentication user.");

            var authenticatorCode = Input.TwoFactorCode
                .Replace(" ", string.Empty).Replace("-", string.Empty);

            var result = await _signInManager
                .TwoFactorAuthenticatorSignInAsync(
                    authenticatorCode,
                    rememberMe,
                    Input.RememberMachine);

            if (result.Succeeded)
            {
                _logger.LogInformation("User with ID '{UserId}' logged in with 2fa", user.Id);
                return LocalRedirect(returnUrl);
            }

            if (result.IsLockedOut)
            {
                _logger.LogWarning("User with ID '{UserId}' account locked out", user.Id);
                return RedirectToPage("./Lockout");
            }

            _logger.LogWarning("Invalid authenticator code entered for user with ID '{UserId}'", user.Id);
            ModelState.AddModelError(string.Empty, "Invalid authenticator code.");
            return Page();
        }

        public class InputModel
        {
            [Required]
            [StringLength(
                7,
                ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
                MinimumLength = 6)]
            [DataType(DataType.Text)]
            [Display(Name = "Authenticator code")]
            public string TwoFactorCode { get; set; } = null!;

            [Display(Name = "Remember this machine")]
            public bool RememberMachine { get; set; }
        }
    }
}