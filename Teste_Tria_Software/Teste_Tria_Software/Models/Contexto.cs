using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Teste_Tria_Software.Models
{
    public class Contexto : DbContext
    {

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<ClienteEmpresa> ClienteEmpresas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Password=UsuSenha1234;Persist Security Info=True;User ID=UsuarioElock;Initial Catalog=TesteTriaBD;Data Source=DESKTOP-7JG4BBK\\SQLEXPRESS");
        }
    }
}
