using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MumanalPG.Data;
using MumanalPG.Models;
using MumanalPG.Utility;

namespace MumanalPG.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        protected ApplicationDbContext DB;

        public LoginModel(SignInManager<IdentityUser> signInManager, ILogger<LoginModel> logger, ApplicationDbContext db)
        {
            _signInManager = signInManager;
            _logger = logger;
            DB = db;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Nombre de Usuario o Email es requerido")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Contraseña es requerida")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl = returnUrl ?? Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            ViewData["ReturnUrl"] = returnUrl;
            if (Input.Email.IndexOf('@') > -1)
            {
                //Validate email format
                string emailRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                    @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                    @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                Regex re = new Regex(emailRegex);
                if (!re.IsMatch(Input.Email))
                {
                    ModelState.AddModelError("Email", "Email Inválido");
                }
            }
            else
            {
                //validate Username format
                string emailRegex = @"^[a-zA-Z0-9.]*$";
                Regex re = new Regex(emailRegex);
                if (!re.IsMatch(Input.Email))
                {
                    ModelState.AddModelError("Email", "Nombre de Usuario Inválido");
                }
            }

            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation("Usuario conectado.");
                    
                    var user = await _signInManager.UserManager.FindByNameAsync(Input.Email);

                    ApplicationUser currentUser = DB.ApplicationUser
                    .FirstOrDefault(u => u.Id == user.Id);
                    if (currentUser?.LastChangedPassword == null)
                    {
                        return RedirectToPage("./Manage/ChangePassword", new { ReturnUrl = returnUrl });
                    }
                    else
                    {
                        return LocalRedirect(returnUrl);   
                    }
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("Cuenta de Usuario bloqueada.");
                    return RedirectToPage("./Lockout");
                }
                
                else
                {
                    ModelState.AddModelError(string.Empty, "Nombre de Usuario o contraseña inválidos.");
                    return Page();
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
