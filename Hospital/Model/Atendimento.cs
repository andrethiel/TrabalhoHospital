using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hospital.Model
{
    [Table("Atendimento")]
    class Atendimento
    {
        public Atendimento() => CriadoEm = DateTime.Now;
        public int ID { get; set; }
        [Column("id_paciente")]
        public int? PacienteID { get; set; }
        public  string Tipo { get; set; }
        public string Chegada { get; set; }
        public string Sintomas { get; set; }

        public DateTime CriadoEm { get; set; }

    }
}
