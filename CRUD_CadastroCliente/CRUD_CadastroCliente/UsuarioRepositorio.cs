using CRUD_CadastroUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_CadastroCliente
{
    public class UsuarioRepositorio
    {
        public void AdicionarUsuario(Usuario usuario)
        {
            var listaDeUsuarios = ListaDeUsuarios.ObterInstancia();
            listaDeUsuarios.Add(usuario);
        }

        public List<Usuario> ObterTodos()
        {
            var listaDeUsuarios = ListaDeUsuarios.ObterInstancia();
            return listaDeUsuarios;
        }
        public void DeletarUsuario(Usuario usuario)
        {
            var listaDeUsuarios = ListaDeUsuarios.ObterInstancia();
            listaDeUsuarios.Remove(usuario);
        }

        public Usuario ObterPorId(int id)
        {
            var listaDeUsuarios = ListaDeUsuarios.ObterInstancia();
            var usuarioBase = new Usuario();

            listaDeUsuarios.ForEach(usuario => 

            {
                if (usuario.Id == id)
                {
                    usuarioBase = usuario;
                }
            });
            return usuarioBase;
        }

        //Criar funcao atualizar usuario
    }
}
