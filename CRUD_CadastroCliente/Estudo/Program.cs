using System;

namespace Estudo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var consulta = new ConsultaDeUsuario();
            //acabei de clicar no botao editar, e peguei a linha selecionada que é o objeto Usuario
            consulta.UsuarioDaLinhaSelecionada = new Usuario
            {
                Name = "Gabriel"
            };

            var cadastro = new CadastroDeUsuario(consulta);
        }
    }
}
