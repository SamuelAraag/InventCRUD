using System;
using CRUD_CadastroUsuario;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_CadastroCliente
{
    public interface IUsuarioRepositorio
    {
        void AdicionarUsuario(Usuario usuario);
        void DeletarUsuario(int id);
        void AtualizarUsuario(Usuario usuario);
        int ObterPorId(int id);
        List<Usuario> ObterTodos();


    }
}
