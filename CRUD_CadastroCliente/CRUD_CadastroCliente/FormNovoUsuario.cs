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
        public FormNovoUsuario()
        {
            InitializeComponent();
        }

        private void botaoSalvar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario.Nome = caixaNome.Text;
            usuario.CPF = caixaCPF.Text;
            usuario.Telefone = caixaTelefone.Text;
            usuario.Email = caixaEmail.Text;

            List<Usuario> usuarios = new List<Usuario>();

            usuarios.Add(usuario);

        }
    }
}
