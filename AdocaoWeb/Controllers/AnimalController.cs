using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdocaoWeb.DAL;
using AdocaoWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdocaoWeb.Controllers
{
    public class AnimalController : Controller
    {
        private readonly AnimalDAO _animalDAO;
        public AnimalController(AnimalDAO animalDAO) => _animalDAO = animalDAO;    
        
        public IActionResult Index()
        {
            ViewBag.Title = "Gerenciamento de animais";
            return View(_animalDAO.Listar());
        }

        public IActionResult Cadastrar() => View();

        [HttpPost]
        public IActionResult Cadastrar(Animal animal)
        {
            if (ModelState.IsValid)
            {//-------------------------------------------------------------------------------------------------------------------------ModelState.IsValid az as validações aqui no controler
                if (_animalDAO.Cadastrar(animal))
                {
                    return RedirectToAction("Index", "Animal");
                }
                ModelState.AddModelError("", "Já existe um animal dessa mesma espécie !!"); // ----------------------------------------------------------------serve para adição de mensagens de erro
                 
            }
            return View(animal);
        }
        public IActionResult Alterar(int id)
        {
            return View(_animalDAO.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Alterar(Animal animal)
        {
            _animalDAO.Alterar(animal);
            return RedirectToAction("Index", "Animal");
        }
        public IActionResult Excluir(int id)
        {
            _animalDAO.Ecluir(id);
            //_context.SaveChanges();
            return RedirectToAction("Index", "Animal");
        }
    }


}
