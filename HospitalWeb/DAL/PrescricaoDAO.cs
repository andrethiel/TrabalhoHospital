using HospitalWeb.Data;
using HospitalWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalWeb.DAL
{
    class PrescricaoDAO
    {
        private static Context context;
        public static List<Prescricao> BuscaPrescricaoAtendimento(int ID) => context.Prescricao.Where(p => p.AtendimentoID == ID).ToList();

        public static bool CadastroPrescricao(Prescricao prescricao)
        {
            context.Prescricao.Add(prescricao);
            context.SaveChanges();
            return false;
        }

        public static Prescricao BuscarPrescricao(int id) => context.Prescricao.FirstOrDefault(p => p.ID == id);

        public static void Remover(int id)
        {
            context.Prescricao.Remove(context.Prescricao.Find(id));
            context.SaveChanges();
        }

        public static bool AlterarPrescricao(string alterada, int id)
        {
            var pres = context.Prescricao.Find(id);
            pres.TextoPrescricao = alterada;
            context.SaveChanges();
            return true;
        }
    }
}
