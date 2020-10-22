using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using modulo4.Models;
using Microsoft.AspNetCore.Authorization; // Importa esse using pra fazer validação de autorização pra usuário logado e não logado
using Microsoft.AspNetCore.Identity; // Poder pegar os dados de um usuário logado

namespace modulo4.Controllers
{
    //[Authorize] // Colocando esse mapeamento o ASP.NET só deixa acessar quem tiver logado
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager; // Com isso pode ter acesso a informação de qualquer usuário logado
        }


        public async Task<IActionResult> Index() // Necessário fazer uma adaptação devido o método que busca os dados do usuário serem Async
        {
            var user = await _userManager.GetUserAsync(User); // Busca o usuário atualmente logado

            // return Content(User.FindFirst("FullName").Value); // Pegando informações da Claim referente ao usuário logado
            // return Content(user.Email); // Acessar dados próprio do User
            return View();
        }

        // Aqui só está bloqueando a rota Privacy
        // [Authorize] // Sem política
        [Authorize(Policy = "TemNome")] // Com política, criada em Startup.cs
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
