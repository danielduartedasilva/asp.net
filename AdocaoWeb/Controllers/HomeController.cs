using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdocaoWeb.DAL;
using AdocaoWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdocaoWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly AnimalDAO _animalDAO;
        private readonly CategoriaDAO _categoriaDAO;
        
       
        public HomeController(AnimalDAO animalDAO, CategoriaDAO categoriaDAO)
        {
            _animalDAO = animalDAO;
            _categoriaDAO = categoriaDAO;
            
        }
        public IActionResult Index(int id)
        {
            ViewBag.Categorias = _categoriaDAO.Listar();
            List<Animal> animais = id == 0 ? _animalDAO.Listar() : _animalDAO.ListarPorCategoria(id);//-------------- nos if ternário os : funcionam como um else, tanto o if quanto o else tem que ser do mesmo tipo
            //o if abaixo foi substituido pelo pelo if ternário acima
            //if (id == 0)
            //{
            //    return View(_animalDAO.Listar());
            //}
            return View(animais);
        }
        public IActionResult Reservar()
        {
            return View();
        }
    }
}
