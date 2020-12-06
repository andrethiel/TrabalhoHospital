using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HospitalWeb.DAL;
using HospitalWeb.Data;

namespace HospitalWeb.Controllers
{
    public class MedicoController : Controller
    {
        private readonly AtendimentoDAO _atendimentoDAO;
        private readonly PacienteDAO _paciente;

        public MedicoController(AtendimentoDAO atendimento, PacienteDAO paciente) 
        {
            _atendimentoDAO = atendimento;
            _paciente = paciente;
        } 

        public IActionResult Index()
        {
            return View(_atendimentoDAO.ListarAtendimentos());
        }

        public IActionResult Cadastrar(int id)
        {
            var IdPaciente = _atendimentoDAO.BuscarPorId(id);
            var nome = _paciente.BuscaPacienteID(IdPaciente.PacienteID);
            ViewBag.atendimento = _atendimentoDAO.BuscarPorId(id);
            ViewBag.Nome = nome.Nome;
            return View();
        }

        //[HttpPost]
        //public IActionResult Cadastrar()
        //{
            
        //}
    }
}
