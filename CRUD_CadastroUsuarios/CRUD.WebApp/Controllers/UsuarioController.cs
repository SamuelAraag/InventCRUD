using CRUD.Dominio;
using FluentValidation;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
                return Ok(todosOsUsuarios);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult ObterUsuarioPorId([FromRoute] int id)
        {
            if (id == decimal.Zero)
            {
                return BadRequest("O id deve ser informado");
            }
             
            try
            { 
                var usuarioObtido = _usuarioRepositorio.ObterPorId(id);
                if(usuarioObtido is null)
                {
                    return NotFound($"Usuario não pode ser encontrado com o id: {id}");
                }

                return Ok(usuarioObtido);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeletarUsuario([FromRoute] int id)
        {
            if (id == decimal.Zero)
            {
                return BadRequest("O id deve ser informado");
            }
            try
            {
                var usuarioASerDeletado = _usuarioRepositorio.ObterPorId(id);
                if (usuarioASerDeletado is null)
                {
                    return NotFound($"Usuario não pode ser encontrado com o id: {id}");
                }
                _usuarioRepositorio.DeletarUsuario(usuarioASerDeletado.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AdicionarUsuario([FromBody] Usuario usuario)
        {
            if (usuario is null)
            {
                return BadRequest("O usuario deve ser informado");
            }

            try
            {
                usuario.DataCriacao = DateTime.Now;
                _validador.ValidateAndThrow(usuario);
                _usuarioRepositorio.AdicionarUsuario(usuario);

                return Created($"Usuario/{usuario.Id}", usuario);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult AtualizarUsuario([FromRoute] int id, [FromBody] Usuario usuario)
        {
            if (usuario is null)
            {
                return BadRequest("O usuario deve ser informado");
            }

            try
            { 
                var usuarioDoBanco = _usuarioRepositorio.ObterPorId(id);
                if (usuarioDoBanco is null)
                {
                    return NotFound($"Usuario não pode ser encontrado com o id: {id}");
                }
                usuario.DataCriacao = usuarioDoBanco.DataCriacao;
                usuario.Id = id;
                _validador.ValidateAndThrow(usuario);
                _usuarioRepositorio.AtualizarUsuario(usuario);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
