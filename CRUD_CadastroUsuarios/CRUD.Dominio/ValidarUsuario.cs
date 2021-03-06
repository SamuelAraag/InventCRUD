using FluentValidation;
using System.Text.RegularExpressions;

namespace CRUD.Dominio
{
    public class ValidarUsuario : AbstractValidator<Usuario>
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public ValidarUsuario(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;

            const string dataMinimaValida = "1753-01-01T12:06:13.975Z";
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("Campo {PropertyName} obrigatorio!");

            RuleFor(x => x.Senha)
                .NotEmpty()
                .WithMessage("Campo {PropertyName} obrigatório!")
                .NotNull()
                .WithMessage("Campo {PropertyName} obrigatório!");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("campo {PropertyName} obrigatório!")
                .Must((usuario, email) => EmailEstaNoPadraoCorreto(email))
                .WithMessage("O campo {PropertyName} é inválido!")
                .Must((usuario, email) => EmailPodeSerCriado(usuario, email))
                .WithMessage("Este {PropertyName} já existe no nosso banco de dados!");

            RuleFor(x => x.DataNascimento)
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("Data invalida!")
                .GreaterThan(DateTime.Parse(dataMinimaValida))
                .WithMessage("Data invalida!");
        }

        private static bool EmailEstaNoPadraoCorreto(string email)
        {
            var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            var match = regex.Match(email);
            return match.Success; 
        }

        private bool EmailPodeSerCriado(Usuario usuario, string email)
        { 
            var ehCriacao           = usuario.Id == decimal.Zero;
            var emailDoBanco        = ehCriacao 
                ? null 
                : _usuarioRepositorio.ObterPorId(usuario.Id).Email;

            var emailAlterado       = email != emailDoBanco;
            var validarDuplicidade  = ehCriacao || emailAlterado;

            var resultado = validarDuplicidade && _usuarioRepositorio.ExisteEmailNoBanco(email);

            return !resultado; 
        }
    }
}
