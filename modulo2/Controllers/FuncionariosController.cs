using System;
using Microsoft.AspNetCore.Mvc;
using modulo2.Models;
using modulo2.Database;

namespace modulo2.Controllers
{
    public class FuncionariosController : Controller
    {
        private readonly ApplicationDBContext database; // Atributo, pesquisar mais sobre esse readonly

        public FuncionariosController(ApplicationDBContext database)
        {
            this.database = database;
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Salvar(Funcionario funcionario)
        {
            database.Funcionarios.Add(funcionario); // Insert dos dados no banco de dados
            database.SaveChanges(); // Salva os dados no banco de dados
            return Content("Foram adicionados com sucesso ao banco de dados: " + funcionario.Nome + " " + funcionario.Salario + " " + funcionario.Cpf);
        }
    }
}