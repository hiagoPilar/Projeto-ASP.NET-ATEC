using Microsoft.AspNetCore.Mvc;
using Projeto_ASP.NET_Core_ATEC.Filters;

namespace Projeto_ASP.NET_Core_ATEC.Controllers
{

    [PaginaParaUsuarioLogado]
    public class RestritoAdmin : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
