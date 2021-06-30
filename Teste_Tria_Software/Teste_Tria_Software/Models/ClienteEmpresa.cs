using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Teste_Tria_Software.Models
{
    public class ClienteEmpresa
    {
        [Key]
        public long ID { get; set; }

        public long ClienteID { get; set; }

        public long EmpresaID { get; set; }

        //relacionamentos...
        public virtual Cliente Cliente { get; set; }
        public virtual Empresa Empresa { get; set; }
    }
}
