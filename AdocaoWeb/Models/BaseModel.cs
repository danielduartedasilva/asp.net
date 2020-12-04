using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdocaoWeb.Models
{
    public class BaseModel
    {
        public BaseModel() => CriadoEm = DateTime.Now;//--------------------------------------------------------------------------------Contrutor
        
        [Key]
        public int Id { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}
