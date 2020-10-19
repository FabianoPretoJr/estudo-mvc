using System;
using Microsoft.AspNetCore.Mvc; // Não esquece o Using

namespace ASPCORE.Controllers
{
    [Route("painel/admin")] // Personalizar Routes, pode se fazer no Startup.cs, mas no Controller é melhor e mais organizado
    public class AdminController : Controller // Sempre fazer Herança com o Controller, e o nome deve ter ser seguido de Controller sempre
    {     
        [HttpGet("principal/{num:int?}/{nome}")] // Pra não dar erro com as rotas automaticas do ASPNET Core, mapear suas ações com verbos HTTP (métodos principais => Get, Post, Put, Delete)
        // Pode se passar paramêtros/váriaveis pela URI, também dá pra fazer validações como em, :int, e também dá pra passar mais de um paramêtro
        // se adicionar um ? no fim desse paramêtro ele deixa de ser obrigatorio
        //[HttpGet("")] // Poder ter mais de uma mapeamento de rota
        public IActionResult Index(int num, string nome) // Açôes do Controller, a Index é a default caso não especifique na URI
        {
            return Content("O número é: " + num + "\nO nome é: " + nome); // Uma IActionResult sempre deve ter um return, pode ser uma View, Content, etc
            // Se o paramêtro for int e passar letras vai ser apresentado apenas 0
        }

        [HttpGet("son")]
        public IActionResult schoolOfNet() // Outra ação, para usar essa deve se passar seu /nome na URI
        {
            var nome = Request.Query["nome"]; // QueryString, outra forma de receber paramêtros em URI, estrutura => ?nome=fabiano
            return Content("Aprendendo ASP.NET Core na school of net! " + nome);
        }

        [HttpGet("view")]
        public IActionResult Visualizar() // O ASPNET Core assimila sozinho qual View eu quero trazer, devido o nome da Ação e o Controller que ela está, por isso é importante manter o padrão
        {
            ViewData["HelloWorld"] = false; // Passar dados para a View, existem outras formas, o false é a informação que ta indo dentro
            ViewData["nome"] = "Fabiano";

            return View("Nada"); // Retonar uma página HTML, se tiver mais de uma View posso passar o nome dela aqui
        }
    }
}