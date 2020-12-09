using HospitalWeb.DAL;
using HospitalWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalWeb.Controllers.API
{
    [Route("api/")]
    [ApiController]
    public class AtendimentoController : ControllerBase
    {
        private readonly PrescricaoDAO _prescricao;
        private readonly AtendimentoDAO _atendimento;

        public AtendimentoController(PrescricaoDAO prescricao, AtendimentoDAO atendimento) {
            _prescricao = prescricao;
            _atendimento = atendimento;
        }

        [HttpGet]
        [Route("ListarAtendimentos")]
        public ActionResult Lista()
        {
            List<AtendimentoPaciente> atendimentos = _atendimento.Listar();
            if(atendimentos.Count > 0)
            {
                return Ok(atendimentos);
            }
            return BadRequest(new { msg = "Lista de atendimentos vazia!" });
        }
    }
}
