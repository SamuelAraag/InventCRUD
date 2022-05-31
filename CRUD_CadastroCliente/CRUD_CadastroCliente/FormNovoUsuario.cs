using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CRUD_CadastroUsuario
{
    public partial class FormNovoUsuario : Form
    {
        public Usuario Usuario { get; set; }
        
        public FormNovoUsuario(Usuario usuario)
        {
            InicializarComponentes();

            if (usuario == null)
            {
                Usuario = new Usuario();
            }
            else
            {
                CaixaId.Text = usuario.Id.ToString();
                caixaNome.Text = usuario.Nome;
                caixaSenha.Text = usuario.Senha;
                caixaEmail.Text = usuario.Email;
                caixaDataNascimento.Text = usuario.DataNascimento.ToString();
                caixaDataCriacao.Text = usuario.DataCriacao;
                Usuario = usuario;
            }
        }

        private void AoClicarEmSalvar(object sender, EventArgs e)
        {
            try
            {
                ValidarCampos();

                Usuario.Email = caixaEmail.Text;
                Usuario.Senha = caixaSenha.Text;
                Usuario.Nome = caixaNome.Text;

                //Validando datetime com exceção de data não existente
                const string valorPadrao = "  /  /";
                //Teste validação da data
                DateTime dt;
                if (!DateTime.TryParseExact(caixaDataNascimento.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
                {
                    MessageBox.Show("Campo Data, Inválido!");
                    caixaDataNascimento.Focus();
                    return;
                }
                else
                {
                    if (caixaDataNascimento.Text != valorPadrao)
                    {
                        Usuario.DataNascimento = DateTime.Parse(caixaDataNascimento.Text);
                    }
                }

                Usuario.DataCriacao = caixaDataCriacao.Text;
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
            var campoInvalido = "";
            if (caixaNome.Text == campoInvalido)
            {
                throw new Exception("Campo Nome, Obrigatório");
            }

            if (caixaSenha.Text == campoInvalido)
            {
                throw new Exception("Campo Senha, Obrigatório");
            }

            var email = caixaEmail.Text;
            var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            var match = regex.Match(email);
            if (!match.Success)
            {
                throw new Exception("Insira um email valido");
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
