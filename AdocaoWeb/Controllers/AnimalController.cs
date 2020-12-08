using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AdocaoWeb.DAL;
using AdocaoWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdocaoWeb.Controllers
{
    //[Authorize(Roles = "ADM")]//------------------------------------------------------------------------------------------------aqui diz quem tem acesso as regras, como funcionalidades
    [Authorize]
    public class AnimalController : Controller
    {
        private readonly AnimalDAO _animalDAO;
        private readonly CategoriaDAO _categoriaDAO;
        private readonly IWebHostEnvironment _hosting;
        public AnimalController(AnimalDAO animalDAO, IWebHostEnvironment hosting, CategoriaDAO categoriaDAO) {
            _animalDAO = animalDAO;
            _categoriaDAO = categoriaDAO;
            _hosting = hosting;
        }
        //[AllowAnonymous]
        public IActionResult Index()
        {//------------------------------------------------------------------------------------------------------------------------------configuração para abrir o index do animal
            ViewBag.Title = "Gerenciamento de Animais";
            return View(_animalDAO.Listar());
        }

        public IActionResult Cadastrar()
        {
            ViewBag.Categorias = new SelectList(_categoriaDAO.Listar(), "Id", "Nome");// ---------------------------------------------------------------------------------------------action que abre somente a página
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(Animal animal, IFormFile file)
        {
            if (ModelState.IsValid)
            {//-------------------------------------------------------------------------------------------------------------------------ModelState.IsValid az as validações aqui no controler
                if (file != null)
                {

                    string arquivo = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";//----------------------------------Guid permite gerar um identificador único global, com caracteres alpha númericos que não se repetem{Guid.NewGuid()} é utilizado para trocar o nome da imagem, FileNome garante que vai ser obtido a informação correta de qualquer sistema operacional
                    string caminho = Path.Combine(_hosting.WebRootPath, "images", arquivo);//-----------------------------combina pedaços para formar um caminho
                    file.CopyTo(new FileStream(caminho, FileMode.CreateNew));//----------------------------------------------cria um arquivo no pasta necessária
                    animal.Imagem = arquivo;//---------------------------------------------------------------------------salva o produto no banco e diz que está vinculado a esta imagem
                }
                else
                {
                    animal.Imagem = "sem-imagem.png";
                }
                animal.Categoria = _categoriaDAO.BuscarPorId(animal.CategoriaId);
                if (_animalDAO.Cadastrar(animal))
                {
                    return RedirectToAction("Index", "Animal");
                }
                ModelState.AddModelError("", "Já existe um animal dessa mesma espécie !!"); // ----------------------------------------------------------------serve para adição de mensagens de erro
                 
            }
            ViewBag.Categorias = new SelectList(_categoriaDAO.Listar(), "Id", "Nome");
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
