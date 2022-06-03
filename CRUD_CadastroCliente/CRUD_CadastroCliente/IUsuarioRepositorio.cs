using CRUD_CadastroUsuario;
using System.Collections.Generic;

namespace CRUD_CadastroCliente
{
    public interface IUsuarioRepositorio
    {
        void AdicionarUsuario(Usuario usuario);
        void DeletarUsuario(int id);
        void AtualizarUsuario(Usuario usuarioEditado);
        Usuario ObterPorId(int id);
        List<Usuario> ObterTodos();
    }
}
