using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalWeb.Models
{
    [Table("Paciente")]
    public class Paciente
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        //public string SobreNome { get; set; }
        //public string Celular { get; set; }
    }
}
