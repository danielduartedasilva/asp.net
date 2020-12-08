using AdocaoWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdocaoWeb.DAL
{
    public class BichoAdocaoDAO
    {
        private readonly Context _context;
        public BichoAdocaoDAO(Context context) => _context = context;
        
        public void Cadastrar(BichoAdocao bicho)
        {
            _context.BichosAdocao.Add(bicho);
            _context.SaveChanges();
        }
        public List<BichoAdocao> ListarPorCestaId(string id) => _context.BichosAdocao.Include(x => x.Animal.Categoria).Where(x => x.CestaId == id).ToList();
        //public Categoria BuscarPorId(int id) => _context.Categorias.Find(id);
    }
}
