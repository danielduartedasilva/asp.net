using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdocaoWeb.Models
{
    [Table("Animais")]
    public class Animal : BaseModel
    {
        public string Especie { get; set; }
        public string Raca { get; set; }
        public string Sexo { get; set; }
        public string Cor { get; set; }
        public double Peso { get; set; }
    }
}
