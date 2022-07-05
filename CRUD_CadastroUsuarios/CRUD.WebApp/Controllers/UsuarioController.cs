using CRUD.Dominio;
using CRUD.Infra;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.WebApp.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        public IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet]
        [Route("ObterTodos")]
        public IActionResult ObterTodosOsUsuarios()
        {
            var todosOsUsuarios = _usuarioRepositorio.ObterTodos();
            if (todosOsUsuarios.Count() == 0)
            {
                return new OkObjectResult(new { message = "Nenhum Usuário Cadastrado" });
            }
            return Ok(todosOsUsuarios);
        }

        [HttpGet]
        [Route("ObterPorId")]
        public IActionResult ObterUsuarioPorId(int Id)
        {
            var usuarioObtido = _usuarioRepositorio.ObterPorId(Id);
            if(usuarioObtido == null)
            {
                return new OkObjectResult(new { message = "Usuário não cadastrado" });
            }
            return Ok(usuarioObtido);
        }

        [HttpDelete]
        [Route("DeletarUsuario")]
        public IActionResult DeletarUsuario(int Id)
        {
            var usuarioADeletar = _usuarioRepositorio.ObterPorId(Id);
            if(usuarioADeletar == null)
            {
                return new OkObjectResult(new { message = "Usuário não encontrado" });
            }
            _usuarioRepositorio.DeletarUsuario(Id);
            return new OkObjectResult(new { message = "Usuário deletado" });
        }

        [HttpPost]
        [Route("AdicionarUsuario")]
        public IActionResult AdicionarUsuario([FromBody]Usuario usuario)
        {
            _usuarioRepositorio.AdicionarUsuario(usuario);
            return new OkObjectResult(new {message = "Usuário adicionado"});
        }
    }
}
