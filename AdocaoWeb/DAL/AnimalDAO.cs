using AdocaoWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdocaoWeb.DAL
{
    public class AnimalDAO
    {
        private readonly Context _context;//-------------------------------------------------------------------------------------------------------------------------OBJETO glogal de contexto, readonly significa que o _contexto só pode receber alguma coisa no momento em que ele é declarado ou dentro do construtor
        public AnimalDAO(Context context) => _context = context;

        public List<Animal> Listar() => _context.Animais.Include(x => x.Categoria).ToList();//--------------------------------------------------------------------------------------------------Método que lista TODOS os animais, o include é porque precisamos dos dados da outra tabela
        public Animal BuscarPorId(int id) => _context.Animais.Find(id);//----------------------------------------------------------------------------------------------------Construtor, que passo o que chega como parâmetro para o nosso contexto glogal
        public Animal BuscarPorEspecie(string especie) => _context.Animais.FirstOrDefault(x => x.Especie == especie);//-------------------------------------------------------------------------------------------------- pega o primeiro que encontrar, se não entrantrar devolve nulo, x vai na tabela na linha do especie e compara

        public List<Animal> ListarPorCategoria(int id) => 
            _context.Animais.Where(x => x.CategoriaId == id).ToList();//--------------------------------------------------------------------------------------------o x é uma expressão lambda, para unir dados de tabelas do banco
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
