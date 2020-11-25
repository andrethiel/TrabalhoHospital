using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.DAL;
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
    }
}
