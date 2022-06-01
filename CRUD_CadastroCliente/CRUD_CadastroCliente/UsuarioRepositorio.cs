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

            //puxar id e mandar ele junto com o objeto
            var proximoId = ListaDeUsuarios.ProximoId();
            usuario.Id = proximoId;


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
        public void AtualizarUsuario(Usuario usuarioEditado)
        {
            var listaDeUsuarios = ListaDeUsuarios.ObterInstancia();
            //Preciso fazer o metodo adicionar com as informações do Usuario
            //Não pode salvar um novo usuario com as informaçoes antigas, muito menos salvar com o mesmo id
            //Você vai conseguir fazer isso usando o index da lista
            //retorna um id
            listaDeUsuarios.ForEach(usuario =>
            {
                if (usuario.Id == usuarioEditado.Id)
                {
                    usuario = usuarioEditado;
                }
            });
        }
    }
}
