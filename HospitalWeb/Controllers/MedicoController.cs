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

        public MedicoController(AtendimentoDAO atendimento) => _atendimentoDAO = atendimento;

        public IActionResult Index()
        {
            return View(_atendimentoDAO.Listar());
        }

        public IActionResult Fila()
        {
            
            return View();
        }




    }
}
