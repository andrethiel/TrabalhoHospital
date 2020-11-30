using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HospitalWeb.Models
{
    [Table("Atendimento")]
    public class Atendimento
    {
        public Atendimento() => CriadoEm = DateTime.Now;
        [Column("IdAtendimento")]
        public int ID { get; set; }
        public  string Tipo { get; set; }
        public string Chegada { get; set; }
        public string Sintomas { get; set; }
        public int PacienteID { get; set; }
        public DateTime CriadoEm { get; set; }

    }
}
