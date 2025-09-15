using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Projeto_ASP.NET_Core_ATEC.Models;

namespace Projeto_ASP.NET_Core_ATEC.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string sessaoUsuario = HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario)) return View();

            Usuario usuario = JsonConvert.DeserializeObject<Usuario>(sessaoUsuario);
            
            return View(usuario);
        }
    }
}
