using CRUD_CadastroUsuario;
using System.Collections.Generic;
using System.Linq;

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
            var usuario = new Usuario();
            var usuarioBase = 0;
            usuarioBase = listaDeUsuarios.FindIndex(u => u.Id == id);
            var idRemocao = id;

            listaDeUsuarios.Remove(usuario);
        }


        //Criar funcao atualizar usuario
        public void AtualizarUsuario(Usuario usuarioEditado)
        {
            //usar indicie que foi encontrado pelo ID para fazer atualização
            var listaDeUsuarios = ListaDeUsuarios.ObterInstancia();
            //Encontrar pelo id
            var idUsuario = usuarioEditado.Id;    
        }

        public Usuario ObterPorId(Usuario usuario)
        {
            //Usar metodo da list para encontrar o id diretamente
            var listaDeUsuarios = ListaDeUsuarios.ObterInstancia();
            var usuarioBase = 0;
            usuarioBase = listaDeUsuarios.FindIndex(u => u.Id == id);
            var idUsuario = id; 

            return usuario;
        }
        public List<Usuario> ObterTodos()
        {
            var listaDeUsuarios = ListaDeUsuarios.ObterInstancia();
            return listaDeUsuarios;
        }
    }
}
