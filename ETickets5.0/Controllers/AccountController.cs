using ETickets5._0.Data;
using ETickets5._0.Data.Static;
using ETickets5._0.Data.ViewModels;
using ETickets5._0.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ETickets5._0.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPasswordHasher<ApplicationUser> _passwordHasher;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _context;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            AppDbContext context, RoleManager<IdentityRole> roleManager, IPasswordHasher<ApplicationUser> passwordHasher)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _roleManager = roleManager;
            _passwordHasher = passwordHasher;


        }
        public async Task<IActionResult> Users()
        {
            var users = await _context.Users.ToListAsync();
            return View(users);

        }



        public IActionResult Login() => View(new LoginVM());

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVM);
            }
            var user = await _userManager.FindByEmailAsync(loginVM.EmailAddress);
            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Movies");
                    }
                }
                TempData["error"] = "wrong credentials, try again!";
                return View(loginVM);
            }
            TempData["error"] = "wrong credentials, try again!";
            return View(loginVM);


        }
        public IActionResult Register() => View(new RegisterVM());

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);

            var user = await _userManager.FindByEmailAsync(registerVM.EmailAddress);
            if (user != null)
            {
                TempData["Error"] = "This email address is already in use";
                return View(registerVM);
            }

            var newUser = new ApplicationUser()
            {
                FullName = registerVM.Fullname,
                Email = registerVM.EmailAddress,
                UserName = registerVM.EmailAddress
            };
            var newUserResponse = await _userManager.CreateAsync(newUser, registerVM.Password);

            if (newUserResponse.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, UserRole.User);
                return View("CompleteRegister");
            }
            else
            {
                TempData["Error"] = "there is a problem with password,please check that the password  contains an uppercase letter,  a lowercase letter, a special character that is not a letter or a number and one digit at least";
                return View(registerVM);
            }



        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Movies");

        }

        public async Task<IActionResult> EditUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);//find user
            if (user == null)
                return RedirectToAction("Error404", "Error");
            else
            {
                EditUserVM editUserVM = new EditUserVM
                {

                    id = user.Id,
                    Fullname = user.FullName,
                    EmailAddress = user.Email,

                };
                return View(editUserVM);
            }

        }

        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserVM editUserVM)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(editUserVM.id);
            if (user != null)
            {
                user.FullName = editUserVM.Fullname;
                user.Email = editUserVM.EmailAddress;
                user.UserName = editUserVM.EmailAddress;
                user.PasswordHash = _passwordHasher.HashPassword(user, editUserVM.Password);

                var emailnewcheck = await _userManager.FindByEmailAsync(editUserVM.EmailAddress);
                if (emailnewcheck != null)
                {
                    TempData["Error"] = "This email address is already in use";
                    return View(editUserVM);
                }
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Movies");
                }
                else
                {
                    TempData["Error"] = "there is a problem with password,please check that the password  contains an uppercase letter,  a lowercase letter, a special character that is not a letter or a number and one digit at least";
                    return View(editUserVM);
                }

            }
            else
            {
                return RedirectToAction("Users", "Account");
            }



        }

    }
}

