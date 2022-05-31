using CRUD_CadastroUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_CadastroCliente
{
    public class ListaDeUsuarios
    {
        private static List<Usuario> instancia;
        public static List<Usuario> ObterInstancia()
        {
            if(instancia == null)
            {
                instancia = new List<Usuario>();
            }
            return instancia;
        }

        public static int IdASerInserido()
        {
            var listaDeUsuarios = ListaDeUsuarios.ObterInstancia();
            var ultimoIdInserido = 0;
            var idAtualASerInserido = 0;

            if (listaDeUsuarios.Count == 0)
            {
                ultimoIdInserido = 0;
            }
            else
            {
                ultimoIdInserido = listaDeUsuarios.Last().Id;
            }
            idAtualASerInserido = ultimoIdInserido + 1;

            return idAtualASerInserido;
        }

        //public static int ProximoId()
        //{
        //    var atual = (instancia ?? new List<Usuario>()).Max(x => x.Id);
        //    return atual++ ;
        //}

    }
}

//criar id auto-incrementavel
//public void AutoIncrementavel()
//{
//    var formNovoUsuario = new FormNovoUsuario(null);
//    var listaDeUsuarios = ListaDeUsuarios.ObterInstancia();
//    var ultimoIdInserido = 0;
//    var idAtualASerInserido = 0;

//    if (listaDeUsuarios.Count == 0)
//    {
//        ultimoIdInserido = 0;
//    }
//    else
//    {
//        ultimoIdInserido = listaDeUsuarios.Last().Id;
//    }
//    idAtualASerInserido = ultimoIdInserido + 1;
//    formNovoUsuario.Usuario.Id = idAtualASerInserido;
//}
