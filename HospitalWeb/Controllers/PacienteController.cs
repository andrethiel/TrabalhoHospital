using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalWeb.Controllers
{
    public class PacienteController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        //[HttpPost]
        //[Route("CriarUsuario")]
        //public IActionResult Cadastrar(Paciente paciente) 
        //{
        //    if (ModelState.IsValid)
        //    {
        //        paciente.Nome =
        //    }
        //}
    }
}
