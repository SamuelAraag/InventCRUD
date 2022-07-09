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
        public IActionResult ObterTodosOsUsuarios()
        {
            try
            {
                var todosOsUsuarios = _usuarioRepositorio.ObterTodos();
                if (todosOsUsuarios.Count() == decimal.Zero)
                {
                    return Ok("Nenhum Usuário Cadastrado");
                }
                return Ok(todosOsUsuarios);
            }
            catch (Exception ex)
            {
                return NotFound("Erro ao buscar usuários! " + ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult ObterUsuarioPorId([FromRoute] int id)
        {
            try
            {
                try
                {
                    var usuarioObtido = _usuarioRepositorio.ObterPorId(id);
                    return Ok(usuarioObtido);
                }
                catch (Exception ex)
                {
                    return BadRequest("Erro ao buscar usuário, verifique o Id! " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                return NotFound("Erro ao buscar usuário, verifique o Id! " + ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeletarUsuario([FromRoute] int id)
        {
            try
            {
                _usuarioRepositorio.DeletarUsuario(id);
                return Ok("Usuário deletado");
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao deletar, usuário não encontrado! " + ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AdicionarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                usuario.DataCriacao = DateTime.Now;
                _validador.ValidateAndThrow(usuario);
                _usuarioRepositorio.AdicionarUsuario(usuario);

                return Ok("Usuário adicionado");
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message} {ex.InnerException?.Message ?? String.Empty}");
            }
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult AtualizarUsuario([FromRoute] int id, [FromBody] Usuario usuario)
        {
            try
            {
                var usuarioASerAtualizado = usuario;
                
                usuarioASerAtualizado = _usuarioRepositorio.ObterPorId(id);
                usuarioASerAtualizado.Nome = usuario.Nome;
                usuarioASerAtualizado.Senha = usuario.Senha;
                usuarioASerAtualizado.DataNascimento = usuario.DataNascimento;

                if (usuario.Email != usuarioASerAtualizado.Email)
                {
                    usuarioASerAtualizado.Email = usuario.Email;
                    _validador.ValidateAndThrow(usuarioASerAtualizado);
                }
                else
                {
                    var _validador2 = new validarUsuario(_usuarioRepositorio);
                    usuarioASerAtualizado.Email = usuario.Email;
                    _validador2.ValidarUsuarioMetodoAtualizar(usuarioASerAtualizado);
                }

                _usuarioRepositorio.AtualizarUsuario(usuarioASerAtualizado);
                return Ok("Usuário atualizado");
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message} {ex.InnerException?.Message ?? String.Empty}");
            }
        }
    }
}
