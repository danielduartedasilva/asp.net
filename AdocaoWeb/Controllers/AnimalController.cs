using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdocaoWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdocaoWeb.Controllers
{
    public class AnimalController : Controller
    {
        private readonly Context _context;
        public AnimalController(Context context) => _context = context;    
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cadastrar() => View();
        
        [HttpPost]
        public IActionResult Cadastrar(string Especie, string Raca, string Sexo, string Cor, double Peso)
        {
            Animal animal = new Animal
            {
                Especie = Especie,
                Raca = Raca,
                Sexo = Sexo,
                Cor= Cor,
                Peso = Peso
            };
            _context.Animais.Add(animal);
            _context.SaveChanges();
            return RedirectToAction("Index", "Animal");
        }
    }


}
