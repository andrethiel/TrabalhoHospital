using HospitalWeb.Data;
using HospitalWeb.Models;
using Microsoft.AspNetCore.Mvc;
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
    }
}
