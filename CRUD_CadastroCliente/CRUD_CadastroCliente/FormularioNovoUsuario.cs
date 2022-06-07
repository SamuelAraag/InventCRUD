using CRUD_CadastroCliente;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CRUD_CadastroUsuario
{
    public partial class FormularioNovoUsuario : Form
    {
        public Usuario Usuario { get; set; }
        private string strCon = @"Persist Security Info=False;User ID=sa;Password=sap@123;Initial Catalog=Usuarios;Data Source=DESKTOP-7MCFTA2";
        SqlConnection sqlCon = null;
        private string strSql = string.Empty;


        public FormularioNovoUsuario(Usuario usuario)
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


            ////Salvando com o banco de dados
            //sqlCmd.Parameters.Add("Nome", SqlDbType.VarChar).Value = caixaNome.Text;
            //sqlCmd.Parameters.Add("Senha", SqlDbType.VarChar).Value = caixaSenha.Text;
            //sqlCmd.Parameters.Add("Email", SqlDbType.VarChar).Value = caixaEmail.Text;
            //sqlCmd.Parameters.Add("DataNascimento", SqlDbType.VarChar).Value = caixaDataNascimento.Text;
            //sqlCmd.Parameters.Add("DataCriacao", SqlDbType.VarChar).Value = caixaDataCriacao.Text;

            try
            {
                //ValidarCampos();
                Usuario.Nome = caixaNome.Text;
                Usuario.Email = caixaEmail.Text;
                Usuario.Senha = caixaSenha.Text;
                Usuario.DataCriacao = caixaDataCriacao.Text;
                Usuario.DataNascimento = DateTime.Parse(caixaDataNascimento.Text);

                //Teste com banco


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
                throw new Exception("Insira um email valido!");
            }
            const string valorPadrao = "  /  /";
            DateTime dt;
            if (caixaDataNascimento.Text == valorPadrao)
            {
                Usuario.DataNascimento = null;
            }
            else
            {
                if ((!DateTime.TryParseExact(caixaDataNascimento.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dt)))
                {
                    throw new Exception("Insira uma data valida!");
                }
                Usuario.DataNascimento = DateTime.Parse(caixaDataNascimento.Text);
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
