using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdocaoWeb.Models
{
    public class Context : IdentityDbContext<Usuario> // ----------------------------------------------------------------------------------------IdentityDbContext para conseguir trabalhar com autenticações que já vem prontas
    {
        public Context(DbContextOptions options) : base(options) //------------------------------------------------------------------- para chamar o construtor da classe pai
        {}
        public DbSet<Animal> Animais { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<BichoAdocao> BichosAdocao { get; set; }
        public DbSet<UsuarioView> Usuarios { get; set; }
        public DbSet<Adocao> Adocoes { get; set; }
    }
}
