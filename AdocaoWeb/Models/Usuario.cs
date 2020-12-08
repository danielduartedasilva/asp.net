using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdocaoWeb.Models
{
    public class Usuario : IdentityUser//------------------------------------------------------------------------------------------------classe que lidará como Identity e está sim manipulará o banco
    {
        public Usuario() => CriadoEm = DateTime.Now;
        public DateTime CriadoEm { get; set; }

        [Display(Name = "CEP")]
        public string Cep { get; set; }

        [Display(Name = "Rua")]
        public string Logradouro { get; set; }

        [Display(Name = "Cidade")]
        public string Localidade { get; set; }

        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [Display(Name = "Estado")]
        public string Uf { get; set; }
    }
}