using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.DAL;
using HospitalWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalWeb.Controllers
{
    public class PacienteController : Controller
    {
        private readonly PacienteDAO _pacienteDAO;

        public PacienteController(PacienteDAO pacienteDAO) => _pacienteDAO = pacienteDAO;
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

        [HttpGet]
        public IActionResult Buscar(string nome)
        {
            return View(_pacienteDAO.BuscaPacienteLista(nome));
        }

        public IActionResult Alterar(int id)
        {
            return View(_pacienteDAO.BuscaPacienteID(id));
        }

        [HttpPost]
        public IActionResult Cadastrar(Paciente paciente)
        {
            if (_pacienteDAO.CadastrarPaciente(paciente))
            {
                return RedirectToAction("Index", "Paciente");
            }

            ModelState.AddModelError("", "Paciente já cadastrado");
            return View();

        }
        [HttpPost]
        public IActionResult Alterar(Paciente paciente)
        {
            _pacienteDAO.AlteraraPaciente(paciente);
            return RedirectToAction("Buscar", "Paciente");
        }
    }
}
