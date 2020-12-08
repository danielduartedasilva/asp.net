using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdocaoWeb.Models
{
    [Table("Animais")]
    public class Animal : BaseModel
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [MinLength(3, ErrorMessage = "Mínimo 3 caracteres!")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres!")]
        public string Especie { get; set; }


        public string Raca { get; set; }


        public string Sexo { get; set; }


        public string Cor { get; set; }


        public double Peso { get; set; }

        public string Imagem { get; set; }

        [ForeignKey("CategoriaId")]//-----------------------------------------------------------------------------------ForeignKey serve para especificar que dentro desse campo iremos utilizar uma chave estrangeira
        public Categoria Categoria { get; set; }

        public int CategoriaId { get; set; }//-------------------------------------------------------------------------para facilitar e otimizar na hora da busca
    }
}
