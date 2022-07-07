using FluentValidation;
using System.Text.RegularExpressions;

namespace CRUD.Dominio
{
    public class ValidarUsuario : AbstractValidator<Usuario>
    {
        public ValidarUsuario()
        {
            //valor mínimo do datetime para sql server
            var dataMinimaValida = DateTime.Parse("1753-07-07T12:06:13.975Z");

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
                .WithMessage("O campo {PropertyName} é inválido!");

            RuleFor(x => x.DataNascimento)
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("Data invalida!")
                .GreaterThan(dataMinimaValida)
                .WithMessage("Data invalida!");
            
            
            //Validar data de criação

        }

        private static bool EmailEstaNoPadraoCorreto(string email)
        { 
            var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            var match = regex.Match(email);
            return match.Success; 
        }
    }
}
