using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MumanalPG.Data;
using MumanalPG.Models;

namespace MumanalPG.Areas.Identity.Pages.Account.Manage
{
    public class ChangePasswordModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<ChangePasswordModel> _logger;
        protected ApplicationDbContext DB;

        public ChangePasswordModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<ChangePasswordModel> logger, ApplicationDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            DB = db;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "El campo {0} es requerido.")]
            [DataType(DataType.Password)]
            [Display(Name = "Contraseña Actual")]
            public string OldPassword { get; set; }

            [Required(ErrorMessage = "El campo {0} es requerido.")]
            [StringLength(100, ErrorMessage = "El campo {0} debe tener almenos {2} y máximo {1} caracteres.", MinimumLength = 6)]
            [DataType(DataType.Password, ErrorMessage = "Las contraseñas deben tener al menos un carácter no alfanumérico, Las contraseñas deben tener al menos una mayúscula ('A' - 'Z').")]
            [Display(Name = "Nueva Contraseña")]
            public string NewPassword { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirmar Nueva Contraseña")]
            [Compare("NewPassword", ErrorMessage = "La Nueva contraseña y este campo no coinciden.")]
            public string ConfirmPassword { get; set; }

            public string ReturnUrl { get; set; }
        }

        public async Task<IActionResult> OnGetAsync(string returnUrl = null)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Usuario no encontrado ID: '{_userManager.GetUserId(User)}'.");
            }

            var hasPassword = await _userManager.HasPasswordAsync(user);
            if (!hasPassword)
            {
                return RedirectToPage("./SetPassword");
            }

            ViewData["ReturnUrl"] = returnUrl;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Usuario no encontrado ID: '{_userManager.GetUserId(User)}'.");
            }

            var changePasswordResult = await _userManager.ChangePasswordAsync(user, Input.OldPassword, Input.NewPassword);
            if (!changePasswordResult.Succeeded)
            {
                foreach (var error in changePasswordResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return Page();
            }

            // var user = await _signInManager.UserManager.FindByNameAsync(Input.Email);

            ApplicationUser currentUser = DB.ApplicationUser
                .FirstOrDefault(u => u.Id == user.Id);

            Console.WriteLine("======================================");
            Console.WriteLine(currentUser.ToString());
            currentUser.LastChangedPassword = DateTime.Now;
               
            Console.WriteLine(currentUser.LastChangedPassword);
            Console.WriteLine("======================================");

            await _signInManager.RefreshSignInAsync(user);
            DB.Update(currentUser);
            await DB.SaveChangesAsync();
            _logger.LogInformation("El usuario cambió su contraseña exitosamente.");
            StatusMessage = "Tu contraseña ha sido cambiada.";

            if (Input.ReturnUrl != null)
            {
                return LocalRedirect(Input.ReturnUrl);
            }
            else
            {
                return LocalRedirect("/");
            }
        }
    }
}
