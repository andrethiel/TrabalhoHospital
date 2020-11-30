using HospitalWeb.Data;
using HospitalWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalWeb.DAL
{
    public class AtendimentoDAO_
    {
        private readonly Context _context;

        AtendimentoDAO_(Context context) => _context = context;

        //public bool CadastrarAtendimento(Atendimento atendimento)
        //{
        //    try
        //    {
        //        _context.Atendimentos.Add(atendimento);
        //        _context.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}
        //public List<AtendimentoPaciente> BuscaAtendimento() /*=> context.Atendimentos.ToList();*/
        //{
        //    //var join = context.AtendimentoPacientes.FromSqlRaw("select a.tipo,a.Sintomas,a.id_paciente p.* from atendimento a, pacientes p where a.id_paciente = p.ID");
        //    var join = _context.AtendimentoPacientes.FromSqlRaw("select a.tipo,a.Sintomas,a.Id, p.Nome from atendimento a, pacientes p where a.id_paciente = p.ID");

        //    return join.ToList();
        //}

        //public AtendimentoPaciente BuscaPaciente(int id) => _context.AtendimentoPacientes.FirstOrDefault(x => x.PacienteID == id);
    }
}
