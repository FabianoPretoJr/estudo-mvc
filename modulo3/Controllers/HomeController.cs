using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using modulo3.Models;
using modulo3.Database;
using Microsoft.EntityFrameworkCore;

namespace modulo3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDBContext database;

        public HomeController(ApplicationDBContext database)
        {
            this.database = database;
        }

        // private readonly ILogger<HomeController> _logger;

        // public HomeController(ILogger<HomeController> logger)
        // {
        //     _logger = logger;
        // }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Teste() // Ação para teste, cria no automatico dados de categoria
        {
            // Categoria c1 = new Categoria();
            // c1.Nome = "Victor";
            // Categoria c2 = new Categoria();
            // c2.Nome = "Victor";
            // Categoria c3 = new Categoria();
            // c3.Nome = "Erik";
            // Categoria c4 = new Categoria();
            // c4.Nome = "Wesley";

            // List<Categoria> catList = new List<Categoria>();
            // catList.Add(c1);
            // catList.Add(c2);
            // catList.Add(c3);
            // catList.Add(c4);

            // database.AddRange(catList);

            // database.SaveChanges();

            // COMENTAR PRA NÃO CRIAR DE NOVO QUANDO RODAR ESSA ROTA

            // ---------------------------------------------------------------------------------------------------------------------------------------------------------------

            var listaDeCategorias = database.Categorias.Where(cat => cat.Nome.Equals("Victor")).ToList(); // Convertendo os dados do banco em lista, mais passando o parametro de busca no banco com Where, Equals é o modo correto de comparar Strings

            Console.WriteLine("\n\n======== CATEGORIAS ========\n");

            listaDeCategorias.ForEach(categoria => {
                Console.WriteLine(categoria.ToString()); // Apresenta os dados retornados da busca no banco que foram salvos em lista, o ForEach percorre essa lista e apresenta em console nesse caso
            });

            Console.WriteLine("\n============================\n\n");

            return Content("Dados salvos");
        }

        public IActionResult Relacionamento()
        {
            // Produto p1 = new Produto();
            // p1.Nome = "Doritos";
            // p1.Categoria = database.Categorias.First(c => c.Id == 1);

            // Produto p2 = new Produto();
            // p2.Nome = "Frango";
            // p2.Categoria = database.Categorias.First(c => c.Id == 1);

            // Produto p3 = new Produto();
            // p3.Nome = "Bolo";
            // p3.Categoria = database.Categorias.First(c => c.Id == 2);

            // database.Add(p1);
            // database.Add(p2);
            // database.Add(p3);

            // database.SaveChanges();

            // ---------------------------------------------------------------------------------------------------------------------------------------------------------------

            // CONSULTA 1 PARA 1

            // var listaDeProdutos = database.Produtos.Include(p => p.Categoria).ToList(); // Necesario usar Include para referencia qual a categoria, lembrar de fazer o importe do using Microsoft.EntityFramweworkCore;

            // listaDeProdutos.ForEach(produto => {
            //     Console.WriteLine(produto.ToString());
            // });

            // ---------------------------------------------------------------------------------------------------------------------------------------------------------------

            // CONSULTA N PARA 1

            // var listaDeProdutosDeUmaCategoria = database.Produtos.Include(p => p.Categoria).Where(p => p.Categoria.Id == 1).ToList(); // Exemplo com Include
            var listaDeProdutosDeUmaCategoria = database.Produtos.Where(p => p.Categoria.Id == 1).ToList(); // Para funcionar a Query sem o Include, usando o Lazi Loading é necessário tornar o atributo na entidade Virtual

            listaDeProdutosDeUmaCategoria.ForEach(produto => {
                Console.WriteLine(produto.ToString());
            });

            return Content("Relacionamento");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
