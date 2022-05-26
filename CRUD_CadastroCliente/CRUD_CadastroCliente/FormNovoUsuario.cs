using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_CadastroUsuario
{
    public partial class FormNovoUsuario : Form
    {
        public Usuario UsuarioASerCadastrado { get; set; }
        
        public FormNovoUsuario(Usuario usuario)
        {
            //Salvando Usuario
            InitializeComponent();
            caixaDataCriacao.Enabled=false;
            CaixaId.Enabled = false;

            if (usuario == null)
            {
                UsuarioASerCadastrado = new Usuario();
            }
            else
            {
                //Atualizando Usuario - Criando construtor
                CaixaId.Text = usuario.Id.ToString();
                caixaNome.Text = usuario.Nome;
                caixaSenha.Text = usuario.Senha;
                caixaEmail.Text = usuario.Email;
                caixaDataNascimento.Text = usuario.DataNascimento;
                caixaDataCriacao.Text = usuario.DataCriacao;

                UsuarioASerCadastrado = usuario;
            }

        }

        public void btnSalvar_Click(object sender, EventArgs e)
        {
            string campoInvalido = "";
            UsuarioASerCadastrado.Nome = caixaNome.Text;
            if (caixaNome.Text == campoInvalido)
            {
                MessageBox.Show("Campo Nome, Obrigatório");
                return;
            }
            UsuarioASerCadastrado.Senha = caixaSenha.Text;
            if(caixaSenha.Text == campoInvalido)
            {
                MessageBox.Show("Campo Senha, Obrigatório");
                return ;
            }
            UsuarioASerCadastrado.Email = caixaEmail.Text;
            if(caixaEmail.Text == campoInvalido)
            {
                MessageBox.Show("Campo Email, Obrigatório");
                return;
            }
            UsuarioASerCadastrado.DataNascimento = caixaDataNascimento.Text;
            UsuarioASerCadastrado.DataCriacao = caixaDataCriacao.Text;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelarNovoUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if(MessageBox.Show("Deseja cancelar a conclusão do cadastro? ", "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void FormNovoUsuario_Load(object sender, EventArgs e)
        {
        }

        private void CaixaId_TextChanged(object sender, EventArgs e)
        {
        }
        
    }
}
