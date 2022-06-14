using System.Collections.Generic;

namespace CRUD.Dominio
{
    public interface IUsuarioRepositorio : IDisposable
    {
        void AdicionarUsuario(Usuario usuario);
        void DeletarUsuario(int id);
        void AtualizarUsuario(Usuario usuarioEditado);
        Usuario ObterPorId(int id);
        List<Usuario> ObterTodos();
    }
}
