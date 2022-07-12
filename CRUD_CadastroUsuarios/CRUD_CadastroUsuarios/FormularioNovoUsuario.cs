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
            try
            { 
                const string dataVazia = "  /  /";
                if (caixaDataNascimento.Text == dataVazia && !DesejaSalvarSemData())
                {
                    return;
                }

                var usuarioDaTela = ObterUsuarioDaTela();
                _validador.ValidateAndThrow(usuarioDaTela);

                usuario = usuarioDaTela;
                DialogResult = DialogResult.OK; 
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Usuario ObterUsuarioDaTela( )
        {
            const string dataVazia = "  /  /";
            DateTime? data = null;
            if(caixaDataNascimento.Text != dataVazia)
            {
                data = DateTime.Parse(caixaDataNascimento.Text);
            } 
              
            return new Usuario
            {
                Nome = caixaNome.Text,
                Senha = caixaSenha.Text,
                Email = caixaEmail.Text,
                DataCriacao = DateTime.Parse(caixaDataCriacao.Text), 
                DataNascimento = data
            }; 
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
    }
}
