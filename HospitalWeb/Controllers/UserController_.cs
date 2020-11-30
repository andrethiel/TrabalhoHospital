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
    public class UserController_ : Controller
    {
        private readonly Context _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public UserController_(Context context, UserManager<User> userManager,
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
        public async Task<IActionResult> Cadastrar([Bind("Nome,Email,Senha,Id,CriadoEm,Setor")] UserView userView)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    UserName = userView.Nome,
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
    }
}
