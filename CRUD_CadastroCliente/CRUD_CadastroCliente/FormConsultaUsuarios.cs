using CRUD_CadastroCliente;
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

    public partial class FormConsultaUsuarios : Form
    {
        public FormConsultaUsuarios()
        {
            InitializeComponent();
        }
        public void btnNovo_Click(object sender, EventArgs e)
        {
            var formNovoUsuario = new FormNovoUsuario(null);
            var resultado = formNovoUsuario.ShowDialog(this);
            var listaDeUsuarios = ListaDeUsuarios.ObterInstancia();

            var ultimoIdInserido = 0;
            var idAtualASerInserido = 0;

            if (resultado == DialogResult.OK)
            {
                if (listaDeUsuarios.Count == 0)
                {
                    ultimoIdInserido = 0;
                }
                else
                {
                    ultimoIdInserido = listaDeUsuarios.Last().Id;
                }
                idAtualASerInserido = ultimoIdInserido + 1;

                formNovoUsuario.UsuarioASerCadastrado.Id = idAtualASerInserido;

                listaDeUsuarios.Add(formNovoUsuario.UsuarioASerCadastrado);
                protegerSenha_atualizarLista();
            }

        }
        public void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if(listaUsuarios.Rows.Count == 0)
                {
                    MessageBox.Show("Nenhum usuário selecionado!");
                }
                else
                {
                    var indexSelecionado = listaUsuarios.CurrentCell.RowIndex;
                    //transformar informações do usuario linha em objeto
                    var usuarioSelecionado = listaUsuarios.Rows[indexSelecionado].DataBoundItem as Usuario;
                    //Jogar essas informações na próxima tela, com todos os dados
                    FormNovoUsuario formNovoUsuario = new FormNovoUsuario(usuarioSelecionado);
                    if (usuarioSelecionado != null)
                    {
                        formNovoUsuario.Text = "Atualizar Usuario";
                        DialogResult resultado = formNovoUsuario.ShowDialog(this);

                        protegerSenha_atualizarLista();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erro inesperado, tente novamente!");
            }
        }
        private void btnDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                var listaDeUsuarios = ListaDeUsuarios.ObterInstancia();
                //Tentar deletar o usuario
                if (listaUsuarios.CurrentCell == null)
                {
                    MessageBox.Show("Nenhum usuário selecionado!");
                }
                else
                {
                    var indexSelecionado = listaUsuarios.CurrentCell.RowIndex;
                    var usuarioSelecionado = listaUsuarios.Rows[indexSelecionado].DataBoundItem as Usuario;
                    if (MessageBox.Show("Deseja realmente deletar o usuário? ", "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {
                    }
                    else
                    {
                        listaDeUsuarios.Remove(usuarioSelecionado);
                        protegerSenha_atualizarLista();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erro inesperado, tente novamente!");
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Usuários cadastrados serão apagados ao sair, deseja realmente continuar? ", "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    Close();
                }
            }
            catch
            {
                MessageBox.Show("Erro inesperado, tente novamente!");
            }
        } 

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Usuários cadastrados serão apagados ao sair, deseja realmente continuar?", "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                }
                else
                {
                    this.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erro inesperado, tente novamente!");
            }
            
        }
        public void protegerSenha_atualizarLista()
        {
            var listaDeUsuarios = ListaDeUsuarios.ObterInstancia();
            listaUsuarios.DataSource = null;
            listaUsuarios.DataSource = listaDeUsuarios;
            this.listaUsuarios.Columns["Senha"].Visible = false;
        }

        private void caixaLista_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        public void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
