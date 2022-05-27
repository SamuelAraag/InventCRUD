using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CRUD_CadastroUsuario
{
    public partial class FormNovoUsuario : Form
    {
        public Usuario UsuarioASerCadastrado { get; set; }
        
        public FormNovoUsuario(Usuario usuario)
        {
            InitializeComponent();
            caixaDataCriacao.Enabled = false;
            CaixaId.Enabled = false;

            if (usuario == null)
            {
                UsuarioASerCadastrado = new Usuario();
            }
            else
            {
                CaixaId.Text = usuario.Id.ToString();
                caixaNome.Text = usuario.Nome;
                caixaSenha.Text = usuario.Senha;
                caixaEmail.Text = usuario.Email;
                caixaDataNascimento.Text = usuario.DataNascimento.ToString();
                caixaDataCriacao.Text = usuario.DataCriacao;
                UsuarioASerCadastrado = usuario;
            }
        }

        public void AoClicarEmSalvar(object sender, EventArgs e)
        {
            try
            {
                ValidarCampos();

                UsuarioASerCadastrado.Email = caixaEmail.Text;
                UsuarioASerCadastrado.Senha = caixaSenha.Text;
                UsuarioASerCadastrado.Nome = caixaNome.Text;
                const string valorPadrao = "  /  /";
                if (caixaDataNascimento.Text != valorPadrao)
                {
                    UsuarioASerCadastrado.DataNascimento = DateTime.Parse(caixaDataNascimento.Text);
                }

                UsuarioASerCadastrado.DataCriacao = caixaDataCriacao.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); ;
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
    }
}
