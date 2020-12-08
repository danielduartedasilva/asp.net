using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdocaoWeb.Models
{
    public class BichoAdocao : BaseModel
    {
        public BichoAdocao() => Animal = new Animal();
        public Animal Animal { get; set; }
        public int Quantidade { get; set; }
        public string CestaId { get; set; }
    }
}
