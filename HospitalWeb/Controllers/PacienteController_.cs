using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.DAL;
using HospitalWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalWeb.Controllers
{
    public class PacienteController_ : Controller
    {
        private readonly PacienteDAO _pacienteDAO;
        
        public PacienteController_(PacienteDAO pacienteDAO) => _pacienteDAO = pacienteDAO;
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Cadastrar()
        {
            return View();
        }
        public IActionResult Buscar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                _pacienteDAO.CadastrarPaciente(paciente);
            }
            return RedirectToAction("Index", "Paciente");
        }
    }
}
