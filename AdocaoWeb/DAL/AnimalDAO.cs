using AdocaoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdocaoWeb.DAL
{
    public class AnimalDAO
    {
        private readonly Context _context;
        public AnimalDAO(Context context) => _context = context;

        public List<Animal> Listar() => _context.Animais.ToList();
        public Animal BuscarPorId(int id) => _context.Animais.Find(id);
        public Animal BuscarPorEspecie(string especie) => _context.Animais.FirstOrDefault(x => x.Especie == especie);
        public bool Cadastrar(Animal animal)
        {
            if (BuscarPorEspecie(animal.Especie) == null)
            {
                _context.Animais.Add(animal);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public void Ecluir(int id)
        {
            _context.Animais.Remove(BuscarPorId(id));
            _context.SaveChanges();
        }

        public void Alterar(Animal animal)
        {
            _context.Animais.Update(animal);
            _context.SaveChanges();
        }
    }
}
