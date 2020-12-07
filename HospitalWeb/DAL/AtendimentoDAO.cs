using HospitalWeb.Data;
using HospitalWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalWeb.DAL
{
    public class AtendimentoDAO
    {
        private readonly Context _context;

        public AtendimentoDAO(Context context) => _context = context;
        public List<Atendimento> Listar() => _context.Atendimentos.ToList();
        public Atendimento BuscarPorId(int id) => _context.Atendimentos.Find(id);

        public List<AtendimentoPaciente> ListarAtendimentos() => _context.AtendimentoPacientes.FromSqlRaw("select p.Nome, a.* from Paciente p, Atendimento a where p.ID = a.PacienteID and Atendido = 'N'").ToList();

        public bool CadastrarAtendimento(Atendimento atendimento)
        {
            try
            {
                _context.Atendimentos.Add(atendimento);
                _context.SaveChanges();
                return true;
            }

            
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Atualizar(Atendimento atendimento)
        {
            _context.Atendimentos.Update(atendimento);
            _context.SaveChanges();
        }

        public void AtualizaAtendimento(int id)
        {
            var atendimento = BuscarPorId(id);
            atendimento.Atendido = "S";
            _context.SaveChanges();
        }
    }
}
