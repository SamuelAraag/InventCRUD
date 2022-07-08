using CRUD.Dominio;
using FluentValidation;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.WebApp.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        public IUsuarioRepositorio _usuarioRepositorio;
        private IValidator<Usuario> _validador;

        public UsuarioController(
            IUsuarioRepositorio usuarioRepositorio,
            IValidator<Usuario> validador)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _validador = validador;
        }

        [HttpGet]
        [Route("ObterTodosOsUsuarios")]
        public IActionResult ObterTodosOsUsuarios()
        {
            try
            {
                var todosOsUsuarios = _usuarioRepositorio.ObterTodos();
                if (todosOsUsuarios.Count() == decimal.Zero)
                {
                    return new OkObjectResult(new { message = "Nenhum Usuário Cadastrado" });
                }
                return Ok(todosOsUsuarios);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao buscar usuários! " + ex.Message);
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
            catch (Exception ex)
            {
                return BadRequest("Erro ao buscar usuário, verifique o Id! " + ex.Message);
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
            catch (Exception ex)
            {
                return BadRequest("Erro ao deletar, usuário não encontrado! " + ex.Message);
            }
        }

        [HttpPost]
        [Route("AdicionarUsuario")]
        public IActionResult AdicionarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                usuario.DataCriacao = DateTime.Now;
                _validador.ValidateAndThrow(usuario);
                _usuarioRepositorio.AdicionarUsuario(usuario);
                return new OkObjectResult(new { message = "Usuário adicionado" });
            }
            catch (Exception ex)
            {
                return BadRequest("Erro nas informações do Usuário! " + ex.Message);
            }
        }

        [HttpPut]
        [Route("AtualizarUsuario")]
        public IActionResult AtualizarUsuario(Usuario usuario)
        {
            try
            {
                var usuarioASerAtualizado = usuario;
                try
                {
                    usuarioASerAtualizado = _usuarioRepositorio.ObterPorId(usuario.Id);
                }
                catch (Exception)
                {
                    return BadRequest("Usuário não encontrado, verifique o Id! ");
                }

                usuarioASerAtualizado.Nome = usuario.Nome;
                usuarioASerAtualizado.Senha = usuario.Senha;
                usuarioASerAtualizado.Email = usuario.Email;
                usuarioASerAtualizado.DataNascimento = usuario.DataNascimento;
                _validador.ValidateAndThrow(usuarioASerAtualizado);
                _usuarioRepositorio.AtualizarUsuario(usuarioASerAtualizado);
                return new OkObjectResult(new {message = "Usuário atualizado"});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ex.InnerException.Message);
            }
        }
    }
}
