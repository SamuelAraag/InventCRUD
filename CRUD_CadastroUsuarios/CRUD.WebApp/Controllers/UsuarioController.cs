using CRUD.Dominio;
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
        [Route("ObterTodosOsUsuarios")]
        public IActionResult ObterTodosOsUsuarios()
        {
            try
            {
                var todosOsUsuarios = _usuarioRepositorio.ObterTodos();
                if (todosOsUsuarios.Count() == 0)
                {
                    return new OkObjectResult(new { message = "Nenhum Usuário Cadastrado" });
                }
                return Ok(todosOsUsuarios);
            }
            catch (Exception)
            {
                return new OkObjectResult(new { message = "Erro ao buscar usuários"});
            }
        }

        [HttpGet]
        [Route("ObterUsuarioPorId")]
        public IActionResult ObterUsuarioPorId(int Id)
        {
            try
            {
                var usuarioObtido = _usuarioRepositorio.ObterPorId(Id);
                return Ok(usuarioObtido);
            }
            catch (Exception)
            {
                return new OkObjectResult(new { message = "Erro ao buscar usuário, verifique o Id" });
            }
        }

        [HttpDelete]
        [Route("DeletarUsuario")]
        public IActionResult DeletarUsuario(int Id)
        {
            try
            {
                var usuarioASerDeletado = _usuarioRepositorio.ObterPorId(Id);
                _usuarioRepositorio.DeletarUsuario(usuarioASerDeletado.Id);
                return new OkObjectResult(new { message = "Usuário deletado" });
            }
            catch (Exception)
            {
                return new OkObjectResult(new { message = "Erro ao deletar, usuário não encontrado" });
            }
        }

        [HttpPost]
        [Route("AdicionarUsuario")]
        public IActionResult AdicionarUsuario(Usuario usuario)
        {
            try
            {
                var validacoes = new ValidarUsuario();
                validacoes.ValidarCampos(usuario.Nome);
                _usuarioRepositorio.AdicionarUsuario(usuario);
                return new OkObjectResult(new { message = "Usuário adicionado" });
            }
            catch (Exception)
            {
                return new OkObjectResult(new { message = "Erro ao adicionar usuário" });
            }
        }

        [HttpPut]
        [Route("AtualizarUsuario")]
        public IActionResult AtualizarUsuario(Usuario usuario)
        {
            try
            {
                var usuarioASerAtualizado = _usuarioRepositorio.ObterPorId(usuario.Id);
                usuarioASerAtualizado = usuario;
                _usuarioRepositorio.AtualizarUsuario(usuarioASerAtualizado);
                return new OkObjectResult(new {message = "Usuário atualizado"});
            }
            catch (Exception)
            {   
                return new OkObjectResult(new {message = "Usuário não encontrado, verifique o Id"});
            }
        }
    }
}
