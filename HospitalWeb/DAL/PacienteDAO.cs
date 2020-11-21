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
    class PacienteDAO
    {
        private readonly Context context;

        public Paciente BuscaPacienteID(int atendimento) => context.Pacientes.FirstOrDefault(x => x.ID == atendimento);
        public Paciente BuscaPacienteNome(string nome) => context.Pacientes.FirstOrDefault(x => x.Nome == nome);

        public List<Paciente> BuscaPacienteLista(string nome) => context.Pacientes.Where(x => x.Nome.Contains(nome)).ToList();

        public bool CadastrarPaciente(Paciente paciente)
        {
            if(BuscaPacienteNome(paciente.Nome) == null)
            {
                context.Pacientes.Add(paciente);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool AlteraraPaciente(Paciente paciente)
        {
            context.Pacientes.Update(paciente);
            context.SaveChanges();
            return true;
        }
    }
}
