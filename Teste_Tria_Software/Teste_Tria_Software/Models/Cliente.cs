using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Teste_Tria_Software.Models
{
    public class Cliente
    {
        [Key]
        public long ClienteID { get; set; }

        [Required(ErrorMessage = "O campo CPF é obrigatório.")]
        [StringLength(11, ErrorMessage = "O campo CPF precisa ter 11 caracteres.", MinimumLength = 11)]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        [StringLength(200, ErrorMessage = "O campo nome precisa ter no máximo 200 caracteres.")]
        public string NOME { get; set; }

        [StringLength(150, ErrorMessage = "O campo e-mail precisa ter no máximo 150 caracteres.")]
        public string EMAIL { get; set; }

        [Required(ErrorMessage = "O campo data de criação é obrigatório.")]
        public DateTime DATA_CRIACAO { get; set; }

        //relacionamentos...
        public virtual ICollection<ClienteEmpresa> ClienteEmpresa { get; set; }

    }
}
