using HospitalWeb.DAL;
using HospitalWeb.Data;
using HospitalWeb.Models;
using HospitalWeb.Utils;
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
        public readonly SenhaMD5 _senhas;
        public UserController(Context context, UserManager<User> userManager,
            SignInManager<User> signInManager, SenhaMD5 senhas)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _senhas = senhas;
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
                //string senha = _senhas.GerarMD5(userView.Senha);
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

            if (result.Succeeded)
            {

                var usuario = _context.Usuarios.FirstOrDefault(p => p.Email == userView.Email);
                if (usuario.Setor == "Atendente")
                {
                    return RedirectToAction("Index", "Atendimento");
                }
                else
                {
                    return RedirectToAction("Index", "Medico");
                }

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
