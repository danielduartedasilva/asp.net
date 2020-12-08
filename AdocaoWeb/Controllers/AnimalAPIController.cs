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

    }
}
