using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Teste_Tria_Software.Models
{
    public class Empresa
    {
        [Key]
        public long EmpresaID { get; set; }

        [Required(ErrorMessage = "O campo CNPJ é obrigatório.")]
        [StringLength(14, ErrorMessage = "O campo CNPJ precisa ter 14 caracteres.", MinimumLength = 14)]
        [DisplayName("CNPJ")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "O campo razão social é obrigatório.")]
        [StringLength(150, ErrorMessage = "O campo razão social precisa ter no máximo 150 caracteres.")]
        [DisplayName("Razão Social")]
        public string RAZAO_SOCIAL { get; set; }

        //relacionamentos...
        public virtual ICollection<ClienteEmpresa> ClienteEmpresa { get; set; }

    }
}
