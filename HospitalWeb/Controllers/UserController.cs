using HospitalWeb.Data;
using HospitalWeb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalWeb.Controllers
{
    public class UserController : Controller
    {
        private readonly Context _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public UserController(Context context, UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastro(UserView userView)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    UserName = userView.Email,
                    Email = userView.Email
                };

                IdentityResult resultado = await _userManager.CreateAsync(user, userView.Senha);
                if (resultado.Succeeded)
                {
                    _context.Add(userView);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                AdicionarErros(resultado);
            }
            return View(userView);
        }
        public void AdicionarErros(IdentityResult resultado)
        {
            foreach (IdentityError erro in resultado.Errors)
            {
                ModelState.AddModelError("", erro.Description);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserView userView)
        {
            var result = await _signInManager.PasswordSignInAsync(userView.Email, userView.Senha, false, false);

            var nome = User.Identity.Name;
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Atendimento");
            }
            ModelState.AddModelError("", "Login ou senha inválidos!");
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
