using Xunit;
//using FluentAssertions;
using System.Net.Http;

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Supermarket.API;
using Supermarket.API.Controllers;
using Supermarket.API.Dominio.Persistencia;
using Supermarket.API.Dominio.Entidades;
using Supermarket.API.Dominio.Repositorios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace xTest.Controladores
{
    [CollectionDefinition("EndpointTests", DisableParallelization = true)]
    public class CategoriaControllerTest
    {
        //private TestApiContext GetContext()
        //{
        //    var dbOptions = new DbContextOptionsBuilder<TestApiContext>()
        //                        .UseInMemoryDatabase(databaseName: "ToDoDb")
        //                        .Options;

        //    var context = new TestApiContext(dbOptions);

        //    return context;
        //}
        private SupermarketApiContext Get_SupermarketApiContext()
        {
            var dbOptions = new DbContextOptionsBuilder<SupermarketApiContext>()
                                .UseInMemoryDatabase(databaseName: "ToDoDb")
                                .Options;

            var context = new SupermarketApiContext(dbOptions);

            return context;
        }

        private CategoriaRepo _repoCategoria;
        private CategoriaController _ctrlCategoria;
        private readonly SupermarketApiContext context;
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public string IdentityBaseUrl { get; set; } = Config.BASE_URL;
        public string ApiBaseUrl { get; set; } = Config.BASE_URL;

        public CategoriaControllerTest()
        {
            // TestApiContext context = this.GetContext();
            // DBInicializar db = new DBInicializar(context);
            // db.Seed();
            context = this.Get_SupermarketApiContext();

            _server = new TestServer(
                            new WebHostBuilder()
                            .UseEnvironment("Development")
                            .UseStartup<Startup>());

            _client = _server.CreateClient();
        }

        [Fact]
        public void GetCategorias_OkResult()
        {
            //Arrange
            _repoCategoria = new CategoriaRepo(context);
            _ctrlCategoria = new CategoriaController(_repoCategoria);

            ////Act
            var response = _ctrlCategoria.GetAsync();

            ////Assert
            //// https://www.it-swarm.dev/es/c%23/asp.net-core-devuelve-json-con-codigo-de-estado/829623651/
            //// Assert.True(newToDoList.ListId != 0);
            ////Assert.True(result.GetType() != 0);
            Assert.IsAssignableFrom<OkObjectResult>(response);
            //Assert.Equal(200, response.StatusCode);
            Assert.IsType<OkResult>(response);
            //Assert.True((response.Value as string[]).Length != 0);
        }

        [Fact]
        public void GetCategoriasAsync_OkResult()
        {
            //Arrange
            _repoCategoria = new CategoriaRepo(context);

            //Act
            // sut.CreateToDoList(newToDoList);
            var result = _repoCategoria.GetCategoriasAsync().Result;
            //var response = _ctrlCategoria.GetCategorias();

            //Assert
            Assert.IsAssignableFrom<IEnumerable<Categoria>>(result);
        }

        [Theory]
        [InlineData(0)]
        //[InlineData(1)]
        //[InlineData(40)]
        public void GetById_BadRequest_Test(int id)
        {
            //Arrange
            _repoCategoria = new CategoriaRepo(context);
            _ctrlCategoria = new CategoriaController(_repoCategoria);

            //Act
            ActionResult<Categoria> responseApi = _ctrlCategoria.HallarCategoriaById(id).Result;

            //Assert
            switch (id)
            {
                case 0:
                    var responseBad = responseApi.Result as BadRequestResult;
                    Assert.Equal(400, responseBad.StatusCode);
                    break;

                case 1:
                    var responseOk = (OkObjectResult)responseApi.Result;
                    Assert.IsType<OkObjectResult>(responseOk);
                    //Assert.Equal(200, responseOk.StatusCode.Value);
                    //Assert.IsType<Categoria>(responseOk.Value);
                    //Assert.Equal(1, responseOk.Value.As<Categoria>().id);
                    break;

                default:
                    break;
            }
        }

        // [Fact]
        // public async void Get_OkResult()
        // {
        //     //Arrange
        //     var apiClient = new HttpClient();

        //     var apiResponse = await apiClient.GetAsync($"{ApiBaseUrl}/health");

        //     Assert.True(apiResponse.IsSuccessStatusCode);

        //     var stringResponse = await apiResponse.Content.ReadAsStringAsync();

        //     Assert.Equal("Healthy", stringResponse);
        // }



        /// <summary>
        /// http://www.mukeshkumar.net/articles/testing/crud-operations-unit-testing-in-aspnet-core-web-api-with-xunit
        /// </summary>
        // [Fact]
        // public void CreateToDoList_WithValidObject_NewListIdIsNotEqualsToZero()
        // {
        //     //Arrange
        //     var sut = CategoriaRepoUnderTest();

        //     //Act
        //     // sut.CreateToDoList(newToDoList);
        //     var list_data = sut.GetCategoriasAsync();

        //     //Assert
        //     // https://www.it-swarm.dev/es/c%23/asp.net-core-devuelve-json-con-codigo-de-estado/829623651/
        //     // Assert.True(newToDoList.ListId != 0);
        //     Assert.IsType<OkResult>(list_data);
        // }
    }
}