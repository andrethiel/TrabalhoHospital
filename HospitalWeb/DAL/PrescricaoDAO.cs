using HospitalWeb.Data;
using HospitalWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;

namespace HospitalWeb.DAL
{
    public class PrescricaoDAO
    {
        private readonly Context _context;
        public PrescricaoDAO(Context context) => _context = context;
        public List<Prescricao> ListarPrescricao() => _context.Prescricao.ToList();
        public List<Prescricao> BuscaPrescricaoAtendimento(int ID) => _context.Prescricao.Where(p => p.AtendimentoID == ID).ToList();
        public List<Prescricao> BuscaPrescricaoAtendimentoID(int ID) => _context.Prescricao.Where(p => p.ID == ID).ToList();

        public bool CadastroPrescricao(Prescricao prescricao)
        {
            _context.Prescricao.Add(prescricao);
            _context.SaveChanges();
            return false;
        }

        public List<Prescricao> BuscarPrescricao(int id) => _context.Prescricao.Where(p => p.ID == id).ToList();
       



    }
}
