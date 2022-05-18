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
    public partial class FormNovoCliente : Form
    {
        public FormNovoCliente()
        {
            InitializeComponent();
        }

        private void botaoSalvar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.Nome = caixaNome.Text;
            cliente.CPF = Convert.ToInt32(caixaCPF.Text);
            cliente.Telefone = Convert.ToInt32(caixaTelefone.Text);
            cliente.Email = caixaEmail.Text;

        }
    }
}
