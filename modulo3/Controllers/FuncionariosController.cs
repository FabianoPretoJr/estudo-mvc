using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using modulo3.Models;
using modulo3.Database;

namespace modulo3.Controllers
{
    public class FuncionariosController : Controller
    {
        private readonly ApplicationDBContext database; // Atributo, pesquisar mais sobre esse readonly

        public FuncionariosController(ApplicationDBContext database)
        {
            this.database = database;
        }

        public IActionResult Index()
        {
            var funcionarios = database.Funcionarios.ToList();
            return View(funcionarios);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        public IActionResult Editar(int id) // No caso de id não precisa fazer mapeamento manual da rota com HttpGet
        {
            Funcionario funcionario = database.Funcionarios.First(registro => registro.Id == id); // Fazer uma Query no banco e vai retorna a primeira que encontrar com esse paramêtro id
            return View("Cadastrar", funcionario); // Chamando a View e passando o funcionario encontrado na Query
        }

        public IActionResult Deletar(int id)
        {
            Funcionario funcionario = database.Funcionarios.First(registro => registro.Id == id);
            database.Funcionarios.Remove(funcionario);
            database.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Salvar(Funcionario funcionario)
        {
            if (funcionario.Id == 0)
            {
                // Salvar novo funcionario
                database.Funcionarios.Add(funcionario); // Insert dos dados no banco de dados
            }
            else
            {
                // Atualizar um funcionario
                Funcionario funcionarioDoBanco = database.Funcionarios.First(registro => registro.Id == funcionario.Id); // Verifica se quem vc quer atualizar realmente existe no banco, talvez seria interessante usar um Try Catch pra tratar erros

                funcionarioDoBanco.Nome = funcionario.Nome;
                funcionarioDoBanco.Salario = funcionario.Salario;
                funcionarioDoBanco.Cpf = funcionario.Cpf; // Apenas isso é suficiente para atualizar os dados no banco, não precisa de métodos Update() e etc
            }
            
            database.SaveChanges(); // Salva os dados no banco de dados
            return RedirectToAction("Index");
        }
    }
}