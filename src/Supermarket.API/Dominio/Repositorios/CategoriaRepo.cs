using System.Linq.Expressions;
using System.Reflection.PortableExecutable;
using System.Diagnostics;
using System.Security.Cryptography;
using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Supermarket.API.Dominio.Modelos;
using Supermarket.API.Dominio.Persistencia;
namespace Supermarket.API.Dominio.Repositorios
{
   public class CategoriaRepo : ICategoriaRepo
   {
       private readonly SupermarketApiContext db;
          /// <summary>
         /// Constructor de la clase CategoriaRepo
         /// </summary>  
        /// <param name="apiContext">representa un objeto de la clase SupermarketApiContext para acceder a la base en memoria</param>
       public CategoriaRepo(SupermarketApiContext apiContext ){
            db=apiContext;
       }
          /// <summary>
         /// Permite crear una categoria
         /// </summary>  
        /// <param name="categoria">representa un objeto de la clase categoria</param>
       public async void crearCategoria(Categoria categoria){
            await db.categorias.AddAsync(categoria);
        }
          /// <summary>
         /// Permite modificar o editar una categoria
         /// </summary>  
         /// <param name="id">identificador de categoria</param>
        /// <param name="categoria">representa un objeto de la clase categoria</param>
       public void editarCategoria(int id, Categoria categoria)
        {
            db.Entry(categoria).State = EntityState.Modified;
            db.categorias.Update(categoria);
        }
         /// <summary>
         /// Permite eliminar una categoria
         /// </summary>  
        /// <param name="categoria">representa un objeto de la clase categoria</param>
        public void eliminarCategoria(Categoria categoria){
            db.categorias.Remove(categoria);
        }
         /// <summary>
         /// Permite guardar una Categoria
         /// </summary>  
        /// <param name="categoria">representa un objeto de la clase categoria</param>
        public async Task<Categoria> guardarCategoria(Categoria categoria){
             await db.SaveChangesAsync();
             return categoria; 
        } 
    //     ///<summary>
    //     ///Implementacion secuencial sincrona
    //     /// </summary> 
    //    public IEnumerable<Categoria> GetCategorias()
    //     {
    //         IEnumerable<Categoria> lista=db.categorias.ToList();
    //        return lista;
    //     }
        ///<summary>
        ///Implementacion secuencial asincrona metodo FindCategoriaById que encuentra una categoria
        /// </summary> 
        public async Task<Categoria> FindCategoriaById(int id)
        {
            Categoria resultado=await db.categorias.FindAsync(id);
            return resultado;
        } 
         ///<summary>
        ///Implementacion secuencial Asincrona
        /// </summary> 
        public async Task<IEnumerable<Categoria>> GetCategoriasAsync()
        {
              IEnumerable<Categoria> lista=await db.categorias.ToListAsync();
           return lista;
        }
    } 
}