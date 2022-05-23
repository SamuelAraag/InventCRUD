using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_CadastroCliente
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
            CaixaId.Text = "*";
            

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

        public void botaoSalvar_Click(object sender, EventArgs e)
        {
            UsuarioASerCadastrado.Nome = caixaNome.Text;
            UsuarioASerCadastrado.Senha = caixaSenha.Text;
            UsuarioASerCadastrado.Email = caixaEmail.Text;
            UsuarioASerCadastrado.DataNascimento = caixaDataNascimento.Text;
            UsuarioASerCadastrado.DataCriacao = caixaDataCriacao.Text;

            DialogResult = DialogResult.OK;

            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void FormNovoUsuario_Load(object sender, EventArgs e)
        {
        }

        private void CaixaId_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
