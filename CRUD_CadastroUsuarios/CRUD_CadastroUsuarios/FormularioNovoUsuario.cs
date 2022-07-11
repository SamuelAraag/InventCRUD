using CRUD.Dominio;
using FluentValidation;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CRUD_CadastroUsuarios
{
    public partial class FormularioNovoUsuario : Form
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IValidator<Usuario> _validador;

        public Usuario usuario { get; set; }

        public FormularioNovoUsuario(int idDoUsuario, IUsuarioRepositorio usuarioRepositorio, IValidator<Usuario> validadorUsuario)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _validador = validadorUsuario;
            InicializarComponentes();

            if (idDoUsuario == decimal.Zero)
            {
                usuario = new Usuario();
            }
            else
            {
                var usuarioSalvo = _usuarioRepositorio.ObterPorId(idDoUsuario);
                CaixaId.Text = usuarioSalvo.Id.ToString();
                caixaNome.Text = usuarioSalvo.Nome;
                caixaSenha.Enabled = false;
                try
                {
                    caixaSenha.Text = ServicoDeCriptografia.DescriptografarSenha(usuarioSalvo.Senha);
                }
                catch (Exception ex) 
                {
                    throw new Exception("Erro ao descriptografar senha!" , ex);
                }
                caixaEmail.Text = usuarioSalvo.Email;
                caixaDataNascimento.Text = usuarioSalvo.DataNascimento.ToString();
                caixaDataCriacao.Text = usuarioSalvo.DataCriacao.ToString();
                usuario = usuarioSalvo;
            }
        }

        private void AoClicarEmSalvar(object sender, EventArgs e)
        {
            const string dataVazia = "  /  /";
            try
            {
                usuario.Nome = caixaNome.Text;
                usuario.Senha = caixaSenha.Text;
                usuario.Email = caixaEmail.Text;
                usuario.DataCriacao = DateTime.Parse(caixaDataCriacao.Text);
                if (caixaDataNascimento.Text == dataVazia)
                {
                    if (DesejaSalvarSemData())
                    {
                        usuario.DataNascimento = null;
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    usuario.DataNascimento = DateTime.Parse(caixaDataNascimento.Text);
                }
                var _validador = new ValidarUsuario(_usuarioRepositorio);
                _validador.ValidateAndThrow(usuario);

                DialogResult = DialogResult.OK;
                
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AoClicarEmCancelar(object sender, EventArgs e)
        {
            try
            {
                if(DeveSairDaTela())
                {
                    Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro inesperado!", ex);
            }
        }

        private bool DesejaSalvarSemData()
        {
            return MessageBox.Show("Deseja salvar o usuário sem data de nascimento? ",
                "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes;
        }

        private bool DeveSairDaTela()
        {
            return MessageBox.Show("Deseja cancelar a conclusão do cadastro? ",
                "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes;
        }
        private void InicializarComponentes()
        {
            InitializeComponent();
            caixaDataCriacao.Enabled = false;
            CaixaId.Enabled = false;
        }

        //private void ValidarCampos()
        //{
        //    if (caixaNome.Text == String.Empty)
        //    {
        //        throw new Exception("Campo Nome, Obrigatório");
        //    }
        //    const int tamanhoMax = 50;
        //    if(caixaSenha.Text.Length > tamanhoMax)
        //    {
        //        throw new Exception("Senha muito grande! ");
        //    }
        //    if (caixaSenha.Text == String.Empty)
        //    {
        //        throw new Exception("Campo Senha, Obrigatório");
        //    }
        //    var email = caixaEmail.Text;
        //    var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        //    var match = regex.Match(email);
        //    if (!match.Success)
        //    {
        //        throw new Exception("Insira um email valido!");
        //    }
        //    var dataValida = DateTime.TryParseExact(caixaDataNascimento.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out var dt);
        //    const string dataVazia = "  /  /";
        //    if (caixaDataNascimento.Text != dataVazia && !dataValida)
        //    {
        //        throw new Exception("Insira uma data valida!");
        //    }
        //}
    }
}
