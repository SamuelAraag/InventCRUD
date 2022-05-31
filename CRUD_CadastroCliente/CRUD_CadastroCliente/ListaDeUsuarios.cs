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
        //Crie uma instancia da lista privada
        private static List<Usuario> instancia;
        //crie uma instancia da lista publica e use o get para pegar a instancia e condicionar uma nova, caso seja nula
        public static List<Usuario> ObterInstancia()
        {
            if(instancia == null)
            {
                instancia = new List<Usuario>();
            }
            return instancia;
        }
    }
    //Usando Padrão Singleton (somente uma classe com construtor privado)
    //public class Usuario
    //{
    //    private Usuario() { }
    //    private static Usuario instancia;

    //    public int Id { get; set; }
    //    public string Nome { get; set; }
    //    public string Senha { get; set; }
    //    public string Email { get; set; }
    //    public DateTime? DataNascimento { get; set; }
    //    public string DataCriacao { get; set; }

    //    public static Usuario Instancia
    //    {
    //        get
    //        {
    //            if(instancia == null)
    //            {
    //                instancia = new Usuario();
    //            }
    //            return instancia;
    //        }
    //    }

    //}
}
