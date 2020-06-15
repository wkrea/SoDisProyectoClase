using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Dominio.repositorios;
using Supermarket.API.Dominio.Modelos;

namespace Supermarket.API.Controllers
{
    [ApiController]
    // ruta por la cual se puede acceder al al api
    [Route("api/[controller]")]

    /// <summary>
    /// request api/catagorias ( Get, Put, Delete)
    /// nos permite optener datos de las clases 
    /// </summary>
    public class CategoriaController : ControllerBase
    {
        /// <summary>
        /// maneja la informacion de la base 
        /// </summary>
        private readonly ICategoriaRepo context;
        
        public CategoriaController(ICategoriaRepo CategoriaContexto)
        {
            context = CategoriaContexto;
        }

         // GET api/values
         /// <summary>
         /// permite otener respuestas tipo jason de listas de categorias 
         /// </summary>
         /// <returns> listas de las categorias </returns>
        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            return context.GetCategorias().ToList();
        }
        
        // GET api/values/
        /// <summary>
        /// nos permiter optener informacion de una categoria especifica
        /// </summary>
        /// <param name="id"> parametro de la cataegoria</param>
        /// <returns> categoria consultada</returns>
        [HttpGet("{id}")]
        public ActionResult<string> FindCategoriaById(int id)
        {
            return "categoria";
        }
    }
} 