using CRUD_CadastroUsuario;
using System.Collections.Generic;

namespace CRUD_CadastroCliente
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        public void AdicionarUsuario(Usuario usuario)
        {
            var listaDeUsuarios = ListaDeUsuarios.ObterInstancia();
            var proximoId = ListaDeUsuarios.ProximoId();
            usuario.Id = proximoId;
            listaDeUsuarios.Add(usuario);
        }

        public void DeletarUsuario(int id)
        {
            var listaDeUsuarios = ListaDeUsuarios.ObterInstancia();
            var usuarioEncontrado = listaDeUsuarios.Find(u => u.Id == id);
            listaDeUsuarios.Remove(usuarioEncontrado);
        }

        public void AtualizarUsuario(Usuario usuarioEditado)
        {
            var listaDeUsuarios = ListaDeUsuarios.ObterInstancia();
            var indice = listaDeUsuarios.FindIndex(usuario => usuario.Id == usuarioEditado.Id);
            listaDeUsuarios[indice] = usuarioEditado;
        }

        public Usuario ObterPorId(int id)
        {
            var listaDeUsuarios = ListaDeUsuarios.ObterInstancia();
            var usuarioBuscado = listaDeUsuarios.Find(u => u.Id == id);
            return usuarioBuscado;
        }

        public List<Usuario> ObterTodos()
        {
            var listaDeUsuarios = ListaDeUsuarios.ObterInstancia();
            return listaDeUsuarios;
        }
    }
}
