using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HospitalWeb.DAL;
using HospitalWeb.Data;
using HospitalWeb.Models;

namespace HospitalWeb.Controllers
{
    public class MedicoController : Controller
    {
        private readonly AtendimentoDAO _atendimentoDAO;
        private readonly PacienteDAO _paciente;
        private readonly PrescricaoDAO _prescricao;
        public static int ATendimentoID;

        public MedicoController(AtendimentoDAO atendimento, PacienteDAO paciente, PrescricaoDAO prescricao) 
        {
            _atendimentoDAO = atendimento;
            _paciente = paciente;
            _prescricao = prescricao;

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
            ATendimentoID = id;
            ViewBag.Nome = nome.Nome;

            return View();
        }
        [HttpPost]
        public IActionResult CriarPrescricao(Prescricao prescricao)
        {
           prescricao.AtendimentoID = ATendimentoID;
            prescricao.ID = 0;
           if (_prescricao.CadastroPrescricao(prescricao))
            {
                return RedirectToAction("index", "Medico");
                
            }
            return View();

        }
        public IActionResult Listar()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Listar(String ID)
        {
            int a  = Convert.ToInt32(ID);
            return View(_prescricao.BuscarPrescricao(a));
        }

    }
}
