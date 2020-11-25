using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HospitalWeb.Models
{
    [Table("Prescricao")]
    public class Prescricao
    {
        public int ID { get; set; }
        public string TextoPrescricao { get; set; }
        public int AtendimentoID { get; set; }
    }
}
