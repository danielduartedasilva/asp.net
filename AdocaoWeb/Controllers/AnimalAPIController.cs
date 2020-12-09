using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdocaoWeb.DAL;
using AdocaoWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdocaoWeb.Controllers
{

    [Route("api/Animal")]
    [ApiController]
    public class AnimalAPIController : ControllerBase
    {
        private readonly AnimalDAO _animalDAO;


        public AnimalAPIController(AnimalDAO animalDAO)
        {
            _animalDAO = animalDAO;
        }

        //GET: /api/Animal/Listar
        [HttpGet]//---------------------------------------------------------------------------------------------------------------se precisar chamar o Listar e não usar a requisição via GET não chega
        [Route("Listar")]
        public IActionResult Listar()
        {
            List<Animal> animais = _animalDAO.Listar();
            
            if (animais.Count > 0)
            {
                return Ok(animais);
            }
            return BadRequest(new { msg = "Lista de animais vazia!" });
        }

        //GET: /api/Animal/Buscar/1
        [HttpGet]//---------------------------------------------------------------------------------------------------------------se precisar chamar o Listar e não usar a requisição via GET não chega
        [Route("Buscar/{id}")]
        public IActionResult Buscar(int id)
        {
            Animal animal = _animalDAO.BuscarPorId(id);

            if (animal != null)
            {
                return Ok(animal);
            }
            return NotFound(new { msg = "Animal não disponível!" });
        }

        //POST: /api/Animal/Cadastrar
        [HttpPost]//---------------------------------------------------------------------------------------------------------------se precisar chamar o Listar e não usar a requisição via GET não chega
        [Route("Cadastrar")]
        public IActionResult Cadastrar(Animal animal)
        {
            if (ModelState.IsValid)
            {
                if (_animalDAO.Cadastrar(animal))
                {
                    return Created("", animal);
                }
                return Conflict(new { msg = "Esse animal já existe!" });
            }
            return BadRequest(ModelState);
        }
    }
}
