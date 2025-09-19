using Newtonsoft.Json;
using Projeto_ASP.NET_Core_ATEC.Models;

namespace Projeto_ASP.NET_Core_ATEC.Helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContext;

        public Sessao(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public Usuario BuscarSessaoDoUsuario()
        {
            //busca a string da sessao que estiver logada e joga para dentro da sessaoUsuario o valor
            //que foi serializado ao criar a sessao do usuario
            string sessaoUsuario = _httpContext.HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario)) return null;

            //aqui faz o processo inverso, onde temos que deserializar, transformar de json para um objeto
            return JsonConvert.DeserializeObject<Usuario>(sessaoUsuario);
        }

        public void CriarSessaoDoUsuario(Usuario usuario)
        {
            
            //converte o objeto Usuario Model para uma string no padrao json 
            string valor = JsonConvert.SerializeObject(usuario);

            //a sessao recebe uma chave e um valor, sendo que esse valor que quero guardar dentro da sessao
            //é um valor string, só que queremos guardar os dados da Usuario Model, que é um objeto, enão temos
            //que converter esse objeto para uma string no padrao json
            _httpContext.HttpContext.Session.SetString("sessaoUsuarioLogado", valor);
        }

        public void RemoverSessaoUsuario()
        {
            _httpContext.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }
    }
}
