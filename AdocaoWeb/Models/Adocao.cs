using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdocaoWeb.Models
{
    [Table("Adocoes")]
    class Adocao : BaseModel // retirado o public
    {
        public Adocao()
        {
            Usuario = new Usuario();
            BichosAdocao = new List<BichoAdocao>();
        }
        public Usuario Usuario { get; set; }
        public List<BichoAdocao> BichosAdocao { get; set; }
    }
}
