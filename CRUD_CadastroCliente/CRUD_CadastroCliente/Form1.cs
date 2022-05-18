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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void botaoNovo_Click(object sender, EventArgs e)
        {
            FormNovoCliente formNovoCliente = new FormNovoCliente();
            formNovoCliente.ShowDialog();
        }

        private void botaoAtualizar_Click(object sender, EventArgs e)
        {
            FormAtualizarCliente formAtualizarCliente = new FormAtualizarCliente();
            formAtualizarCliente.ShowDialog();
        }

        private void botaoDeletar_Click(object sender, EventArgs e)
        {
            FormDeletarCliente formDeletarCliente = new FormDeletarCliente();
            formDeletarCliente.ShowDialog();
        }

        private void caixaLista_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
