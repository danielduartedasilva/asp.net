using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdocaoWeb.DAL;
using AdocaoWeb.Models;
using AdocaoWeb.Utils;
using Microsoft.AspNetCore.Mvc;

namespace AdocaoWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly AnimalDAO _animalDAO;
        private readonly CategoriaDAO _categoriaDAO;
        private readonly BichoAdocaoDAO _bichoAdocaoDAO;
        private readonly Sessao _sessao;

        public HomeController(AnimalDAO animalDAO, CategoriaDAO categoriaDAO, BichoAdocaoDAO bichoAdocaoDAO, Sessao sessao)
        {
            _animalDAO = animalDAO;
            _categoriaDAO = categoriaDAO;
            _bichoAdocaoDAO = bichoAdocaoDAO;
            _sessao = sessao;
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
        public IActionResult AdicionarACesta(int id)
        {
            Animal animal = _animalDAO.BuscarPorId(id);
            BichoAdocao bicho = new BichoAdocao
            {
                Animal = animal,
                Quantidade = 1,
                CestaId = _sessao.BuscarCestaId()
            };
            _bichoAdocaoDAO.Cadastrar(bicho);
            return RedirectToAction("CestaDeAdocao");
        }

        public IActionResult CestaDeAdocao()
        {
            return View(_bichoAdocaoDAO.ListarPorCestaId(_sessao.BuscarCestaId()));
        }
    }
}
