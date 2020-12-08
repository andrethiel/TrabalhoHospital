using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Display(Name = "CEP")]
        public string Cep { get; set; }

        [Display(Name = "Estado")]
        public string Uf { get; set; }

        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [Display(Name = "Tipo")]
        public string TipoLogradouro { get; set; }

        [Display(Name = "Endereço")]
        public string Logradouro { get; set; }
        //public string SobreNome { get; set; }
        //public string Celular { get; set; }
    }
}
