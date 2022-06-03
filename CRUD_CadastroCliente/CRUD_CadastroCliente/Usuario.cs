using System;

namespace CRUD_CadastroUsuario
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string DataCriacao { get; set; }

        public object ShallowCopy()
        {
            return this.MemberwiseClone();
        }
    }
}
