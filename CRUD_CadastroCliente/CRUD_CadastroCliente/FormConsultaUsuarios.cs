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

    public partial class FormConsultaUsuarios : Form
    {
        FormNovoUsuario usuario;
        public List<Usuario> ListaDeUsuariosSalvos { get; set; }
        public FormConsultaUsuarios()
        {
            InitializeComponent();
            ListaDeUsuariosSalvos = new List<Usuario>();
        }

        public void botaoNovo_Click(object sender, EventArgs e)
        {
            FormNovoUsuario formNovoUsuario = new FormNovoUsuario(null);
            DialogResult resultado = formNovoUsuario.ShowDialog(this);

            int ultimoIdInserido = 0;
            var idAtualASerInserido = 0;

            if (resultado == DialogResult.OK)
            {
                if (ListaDeUsuariosSalvos.Count == 0)
                {
                    ultimoIdInserido = 0;
                }
                else
                {
                    ultimoIdInserido = ListaDeUsuariosSalvos.Last().Id;
                }
                idAtualASerInserido = ultimoIdInserido + 1;

                formNovoUsuario.UsuarioASerCadastrado.Id = idAtualASerInserido;

                ListaDeUsuariosSalvos.Add(formNovoUsuario.UsuarioASerCadastrado);
                listaUsuarios.DataSource = null;
                listaUsuarios.DataSource = ListaDeUsuariosSalvos;
            }

        }
        public void botaoAtualizar_Click(object sender, EventArgs e)
        {
            
            try
            {
                //Selecionar usuario da lista usando index
                var indexSelecionado = listaUsuarios.CurrentCell.RowIndex;
                //transformar informações do usuario linha em objeto
                var usuarioSelecionado = listaUsuarios.Rows[indexSelecionado].DataBoundItem as Usuario;
                //Jogar essas informações na próxima tela, com todos os dados
                FormNovoUsuario formNovoUsuario = new FormNovoUsuario(usuarioSelecionado);
                formNovoUsuario.Text = "Atualizar Usuario";
                DialogResult resultado = formNovoUsuario.ShowDialog(this);
                listaUsuarios.DataSource = null;
                listaUsuarios.DataSource = ListaDeUsuariosSalvos;


            }
            catch (Exception ex)
            {
                //aqui vc vai abrir uma caixa de erro
                MessageBox.Show(ex.Message);
            }
        }

        private void botaoDeletar_Click(object sender, EventArgs e)
        {
            //Ao clicar, perguntar se quer excluir usuario selecionado na planilha
            try
            {
                var indexSelecionado = listaUsuarios.CurrentCell.RowIndex;
                var usuarioSelecionado = listaUsuarios.Rows[indexSelecionado].DataBoundItem as Usuario;
                

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void caixaLista_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void botaoCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Usuários cadastrados serão apagados ao sair, deseja realmente continuar? ", "Cuidado", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
            }
            else
            {
                this.Close();
            }
        }
        public void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
