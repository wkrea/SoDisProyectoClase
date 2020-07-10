using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Supermarket.API.Controllers;
using Supermarket.API.Dominio.Entidades;
using Supermarket.API.Dominio.Repositorios;
using Supermarket.API.Dominio.Persistencia;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTest.Controladores
{
    //https://medium.com/selectstarfromweb/xunit-tests-in-parallel-ad32788ce1bd
    //[Collection("Our Test Collection #1")]
    //public class TestClass1
    //{
    //    [Fact]
    //    public void Test1()
    //    {
    //        Thread.Sleep(3000);
    //    }
    //}
    //[Collection("Our Test Collection #1")]
    //public class TestClass2
    //{
    //    [Fact]
    //    public void Test2()
    //    {
    //        Thread.Sleep(5000);
    //    }
    //}

    [Collection("Customer Updates")]
    public class CategoriaTests : IClassFixture<WebApplicationFactory<Supermarket.API.Startup>>
    {
        private readonly HttpClient _httpClient;
        private readonly SupermarketApiContext _context;
        private readonly CategoriaRepo _repoCategoria;
        private readonly CategoriaController _ctrlCategoria;

        public CategoriaTests(WebApplicationFactory<Supermarket.API.Startup> factory)
        {
            _httpClient = factory.CreateClient();

            //_context = this.Get_SupermarketApiContext();
        }
        private SupermarketApiContext Get_SupermarketApiContext()
        {
            var dbOptions = new DbContextOptionsBuilder<SupermarketApiContext>()
                                .UseInMemoryDatabase(databaseName: "ToDoDb")
                                .Options;

            var context = new SupermarketApiContext(dbOptions);

            return context;
        }
        private CategoriaRepo getCategoriaRepo() => new CategoriaRepo(_context);
        private CategoriaController getControllerCategoria(CategoriaRepo _repoCategoria) => new CategoriaController(_repoCategoria);


        [Fact]
        public async Task GetCategoriaAsync()
        {
            // Arrange


            // Act
            //var response = await httpClient.GetAsync("http://localhost:5000/api/categoria");
            //var response = _httpClient.GetAsync("api/categoria").Result;
            //                            //.ConfigureAwait(false);
            var request = new HttpRequestMessage(HttpMethod.Get, $"api/categoria");
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                response = await _httpClient
                                    .SendAsync(request);
                //.ConfigureAwait(false);
                // https://blogs.encamina.com/piensa-en-software-desarrolla-en-colores/asincronia-en-c-bloqueos-contextos-y-tareas/
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Assert

            //response.EnsureSuccessStatusCode();
            var categorias = JsonConvert.DeserializeObject<IEnumerable<Categoria>>(await response.Content.ReadAsStringAsync());
            Assert.IsAssignableFrom<IEnumerable<Categoria>>(categorias);

            // using System.Text.Json;
            //var stringResponse = await response.Content.ReadAsStringAsync();
            //var terms = JsonSerializer.Deserialize<List<Categoria>>(stringResponse, 
            //                            new JsonSerializerOptions { 
            //                                PropertyNamingPolicy = JsonNamingPolicy.CamelCase 
            //                            });
            //Assert.Equal(3, terms.Count);
            //Assert.Contains(terms, t => t.Term == "Access Token");
            //Assert.Contains(terms, t => t.Term == "JWT");
            //Assert.Contains(terms, t => t.Term == "OpenID");
        }

        [Theory]
        [InlineData("X")]
        [InlineData(1)]
        [InlineData(40)]
        public async Task GetById_BadRequest_Test(object id)
        {
            //Arrange
            //_repoCategoria = new CategoriaRepo(context);
            //_ctrlCategoria = new CategoriaController(_repoCategoria);
            var request = new HttpRequestMessage(HttpMethod.Get, $"api/categoria/{id}");


            //Act
            //ActionResult<Categoria> responseApi = _ctrlCategoria.GetCategoriaById(id).Result;
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                response = await _httpClient
                                    .SendAsync(request);
                                    //.ConfigureAwait(false);
                // https://blogs.encamina.com/piensa-en-software-desarrolla-en-colores/asincronia-en-c-bloqueos-contextos-y-tareas/
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //Assert
            //response.EnsureSuccessStatusCode();
            switch (id)
            {
                case 40:
                    Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
                    break;

                case 1:
                    Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                    
                    var categoria = JsonConvert.DeserializeObject<Categoria>(await response.Content.ReadAsStringAsync());
                    Assert.IsType<Categoria>(categoria);
                    Assert.Equal(1, categoria.id);
                    break;

                default:
                    Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
                    //Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
                    break;
            }
        }




        [Theory]
        [InlineData(685349)]
        public void EliminarOk_Test(int id)
        {
            // Arrange

            // Assert
            //var ctrlCategoria = getControllerCategoria(getCategoriaRepo());
            //var result = _ctrlCategoria.Delete(id) as OkObjectResult;

            // Act

            //var result = userController.Delete(id) as OkObjectResult;
            //Assert.Equal(200, result.StatusCode);
            //Assert.IsType<UserDto.User>(result.Value);
        }

    }
}
