using AdocaoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdocaoWeb.DAL
{
    
    public class AdocaoDAO
    {
        private readonly Context _context;
        public AdocaoDAO(Context context) => _context = context;

        private void Cadastrar (Adocao adocao)
        {
            _context.Adocoes.Add(adocao);
            _context.SaveChanges();
        }
    }
}
