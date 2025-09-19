using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Projeto_ASP.NET_Core_ATEC.Models;
using Projeto_ASP.NET_Core_ATEC.Enums;

namespace Projeto_ASP.NET_Core_ATEC.Filters
{
    public class PaginaRestritaPorPerfil : ActionFilterAttribute
    {
        private readonly PerfilEnum[] _perfisPermitidos;

        public PaginaRestritaPorPerfil(params PerfilEnum[] perfisPermitidos)
        {
            _perfisPermitidos = perfisPermitidos;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string sessaoUsuario = context.HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
            }
            else
            {
                Usuario usuario = JsonConvert.DeserializeObject<Usuario>(sessaoUsuario);

                if (usuario == null || !_perfisPermitidos.Contains(usuario.Perfil))
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "AcessoNegado" }, { "action", "Index" } });
                }
            }

            base.OnActionExecuting(context);
        }
    }
}
