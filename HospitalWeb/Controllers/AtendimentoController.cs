using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.DAL;
using Microsoft.AspNetCore.Mvc;

namespace HospitalWeb.Controllers
{
    public class AtendimentoController : Controller
    {
        private readonly PacienteDAO _pacienteDAO;
        private readonly AtendimentoDAO _atendimento;

        public AtendimentoController(AtendimentoDAO atendimento) => _atendimento = atendimento;
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Cadastrar()
        {
            return View();
        }
        public IActionResult Buscar(int id)
        {
            return View(_atendimento.BuscaPaciente(id));
        }
    }
}
