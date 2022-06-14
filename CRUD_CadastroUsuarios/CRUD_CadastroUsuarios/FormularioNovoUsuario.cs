using CRUD.Dominio;
using System.Text.RegularExpressions;

namespace CRUD_CadastroUsuarios
{
    public partial class FormularioNovoUsuario : Form
    {
        private IUsuarioRepositorio _repositorioDeUsuario;

        public Usuario Usuario { get; set; }

        public FormularioNovoUsuario(int idDoUsuario, IUsuarioRepositorio repositorioDeUsuario)
        {
            _repositorioDeUsuario = repositorioDeUsuario;

            InicializarComponentes();

            if (Usuario == null)
            {
                Usuario = new Usuario();
            }
            else
            {
                var usuarioSalvo = _repositorioDeUsuario.ObterPorId(idDoUsuario) 
                    ?? throw new Exception("");

                CaixaId.Text = usuarioSalvo.Id.ToString();
                caixaNome.Text = usuarioSalvo.Nome;
                caixaSenha.Enabled = false;
                caixaSenha.Text = ServicoDeCriptografia.DescriptografarSenha(usuarioSalvo.Senha);
                caixaEmail.Text = usuarioSalvo.Email;
                caixaDataNascimento.Text = usuarioSalvo.DataNascimento.ToString();
                caixaDataCriacao.Text = usuarioSalvo.DataCriacao.ToString();
                Usuario = usuarioSalvo;
            }
        }

        private void AoClicarEmSalvar(object sender, EventArgs e)
        {
            const string dataVazia = "  /  /";
            try
            {
                ValidarCampos();
                Usuario.Nome = caixaNome.Text;
                Usuario.Email = caixaEmail.Text;
                Usuario.Senha = caixaSenha.Text;
                Usuario.DataCriacao = DateTime.Parse(caixaDataCriacao.Text);
                if(caixaDataNascimento.Text == dataVazia)
                {
                    if (DesejaSalvarSemData())
                    {
                        Usuario.DataNascimento = null;
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    Usuario.DataNascimento = DateTime.Parse(caixaDataNascimento.Text);
                }
                DialogResult = DialogResult.OK;
                
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ValidarCampos()
        {
            if (caixaNome.Text == String.Empty)
            {
                throw new Exception("Campo Nome, Obrigatório");
            }
            if (caixaSenha.Text == String.Empty)
            {
                throw new Exception("Campo Senha, Obrigatório");
            }
            var email = caixaEmail.Text;
            var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            var match = regex.Match(email);
            if (!match.Success)
            {
                throw new Exception("Insira um email valido!");
            }
            var dataValida = DateTime.TryParseExact(caixaDataNascimento.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out var dt);
            const string dataVazia = "  /  /";
            if (caixaDataNascimento.Text != dataVazia && !dataValida)
            {
                throw new Exception("Insira uma data valida!");
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
                MessageBox.Show(ex.Message);
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
    }
}
