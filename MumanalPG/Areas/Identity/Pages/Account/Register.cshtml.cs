﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using MumanalPG.Models;
using MumanalPG.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MumanalPG.Areas.Identity.Pages.Account
{
    [Authorize(Roles = SD.SuperAdminEndUser)]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public RegisterModel(
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "La {0} debe tener al menos {2} y maximo {1} caracters.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "La Ccontraseña y la confirmación no corresponden.")]
            public string ConfirmPassword { get; set; }

            [Required]
            public string Name { get; set; }


            [Required]
            [Display(Name="Phone Number")]
            public string PhoneNumber { get; set; }


            [Display(Name="Super Admin")]
            public bool IsSuperAdmin { get; set; }

        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = Input.Email, Email = Input.Email, Name=Input.Name, PhoneNumber=Input.PhoneNumber };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    
                    if(Input.IsSuperAdmin)
                    {
                        await _userManager.AddToRoleAsync(user, SD.SuperAdminEndUser);
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, SD.AdminEndUser);
                    }


                    _logger.LogInformation("Se creó un nuevo Usuario y contraseña.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    
                     return RedirectToAction("Index", "AdminUsers", new { area = "Admin" });
                    
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
