using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HospitalWeb.Models
{
    public class AtendimentoPaciente
    {
        AtendimentoPaciente() => CriadoEm = DateTime.Now;
        public int ID { get; set; }
        public string Tipo { get; set;}
        public string Sintomas { get; set; }
        public int PacienteID { get; set; }
        public string Nome { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}
