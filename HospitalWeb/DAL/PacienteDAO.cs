using Hospital.Data;
using HospitalWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Hospital.DAL
{
    public class PacienteDAO
    {
        private readonly Context _context;

        public PacienteDAO(Context context) => _context = context;
        public Paciente BuscaPacienteID(int atendimento) => _context.Pacientes.FirstOrDefault(x => x.ID == atendimento);
        public Paciente BuscaPacienteNome(string nome) => _context.Pacientes.FirstOrDefault(x => x.Nome == nome);

        public List<Paciente> BuscaPacienteLista(string nome) => _context.Pacientes.Where(x => x.Nome.Contains(nome)).ToList();

        public bool CadastrarPaciente(Paciente paciente)
        {
            if(BuscaPacienteNome(paciente.Nome) == null)
            {
                _context.Pacientes.Add(paciente);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool AlteraraPaciente(Paciente paciente)
        {
            _context.Pacientes.Update(paciente);
            _context.SaveChanges();
            return true;
        }
    }
}
