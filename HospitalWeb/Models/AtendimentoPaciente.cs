using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HospitalWeb.Models
{
    class AtendimentoPaciente
    {
        public string Tipo { get; set;}
        public string Sintomas { get; set; }
        public string Nome { get; set; }
        public int ID { get; set; }

        //[Column("id")]
        //public int AtendimentoID { get; set; }
    }
}
