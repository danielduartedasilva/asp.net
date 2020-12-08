using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdocaoWeb.Models
{
    [Table("Usuarios")]
    public class UsuarioView : BaseModel//----------------------------------------------------------------------------------------------classe específica para lidar com as views
    {
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Senha { get; set; }

        [Display(Name = "Confirmação da senha")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [NotMapped]//---------------------------------------------------------------------------------------------------------quando não queremos que grave no banco
        [Compare("Senha", ErrorMessage = "Campos não coincidem")]
        public string ConfirmacaoSenha { get; set; }

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
