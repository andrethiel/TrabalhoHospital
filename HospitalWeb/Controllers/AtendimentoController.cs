using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalWeb.DAL;
using HospitalWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalWeb.Controllers
{
    public class AtendimentoController : Controller
    {
        private readonly PacienteDAO _pacienteDAO;
        private readonly AtendimentoDAO _atendimentoDAO;
        public static int PAcienteID;
        public AtendimentoController(AtendimentoDAO atendimento, PacienteDAO paciente)
        {
            _atendimentoDAO = atendimento;
            _pacienteDAO = paciente;
        }
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {

                return View();
            }
            return RedirectToAction("Index", "User");
        }

        public IActionResult Cadastrar(int id)
        {

            if (id == 0)
            {
                return RedirectToAction("Buscar", "Paciente");
            }
            var paciente = _pacienteDAO.BuscaPacienteID(id);
            PAcienteID = paciente.ID;
            ViewBag.Nome = paciente.Nome;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastrar(Atendimento atendimento)
        {
            atendimento.PacienteID = PAcienteID;
            atendimento.ID = 0;
            if (_atendimentoDAO.CadastrarAtendimento(atendimento))
            {
                return RedirectToAction("Index", "Atendimento");
            }
            return View();
        }

        public IActionResult Remover(int id)
        {
            var atendimento = _atendimentoDAO.BuscarPorId(id);
            if(atendimento.Atendido != "S")
            {
                _atendimentoDAO.RemoveAtendimento(id);
                return RedirectToAction(nameof(Buscar));
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Buscar()
        {
            return View(_atendimentoDAO.Listar());
        }
    }
}
