using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdocaoWeb.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options) //------------------------------------------------------------------- para chamar o construtor da classe pai
        {}
        public DbSet<Animal> Animais { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }
}
