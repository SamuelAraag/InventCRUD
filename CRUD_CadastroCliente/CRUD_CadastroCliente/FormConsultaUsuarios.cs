﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_CadastroUsuario
{

    public partial class FormConsultaUsuarios : Form
    {
        public List<Usuario> ListaDeUsuariosSalvos { get; set; }
        public FormConsultaUsuarios()
        {
            InitializeComponent();
            ListaDeUsuariosSalvos = new List<Usuario>();
        }
        public void AoClicarEmNovo(object sender, EventArgs e)
        {
            var formNovoUsuario = new FormNovoUsuario(null);
            var resultado = formNovoUsuario.ShowDialog(this);

            var ultimoIdInserido = 0;
            var idAtualASerInserido = 0;

            if (resultado == DialogResult.OK)
            {
                if (ListaDeUsuariosSalvos.Count == 0)
                {
                    ultimoIdInserido = 0;
                }
                else
                {
                    ultimoIdInserido = ListaDeUsuariosSalvos
                        .Last()
                        .Id;
                }
                idAtualASerInserido = ultimoIdInserido + 1;

                formNovoUsuario.UsuarioASerCadastrado.Id = idAtualASerInserido;

                ListaDeUsuariosSalvos.Add(formNovoUsuario.UsuarioASerCadastrado);
                AtualizarLista();
            }
        }
        public void AoClicarEmAtualizar(object sender, EventArgs e)
        {
            try
            {
                if(listaUsuarios.Rows.Count == 0)
                {
                    ExibirMensagem("Nenhum usuário selecionado!");
                }
                else
                {
                    var indexSelecionado = listaUsuarios.CurrentCell.RowIndex;
                    var usuarioSelecionado = listaUsuarios.Rows[indexSelecionado].DataBoundItem as Usuario;
                    var formNovoUsuario = new FormNovoUsuario(usuarioSelecionado);
                    if (usuarioSelecionado != null)
                    {
                        formNovoUsuario.Text = "Atualizar Usuario";
                        var resultado = formNovoUsuario.ShowDialog(this);
                        AtualizarLista();
                    }
                }
            }
            catch (Exception)
            {
                ExibirMensagem("Erro inesperado, tente novamente!");
            }
        }
        private void aoClicarEmDeletar(object sender, EventArgs e)
        {
            try
            {
                if (listaUsuarios.CurrentCell == null)
                {
                    ExibirMensagem("Nenhum usuário selecionado!");
                    throw new Exception("Nenhum usuário selecionado!");

                }
                else
                {
                    var indexSelecionado = listaUsuarios.CurrentCell.RowIndex;
                    var usuarioSelecionado = listaUsuarios.Rows[indexSelecionado].DataBoundItem as Usuario;
                    if (DezejaDeletarOUsuario())
                    {
                        ListaDeUsuariosSalvos.Remove(usuarioSelecionado);
                        AtualizarLista();
                    }
                }
            }
            catch (Exception ex)
            {
                ExibirMensagem($"Erro inesperado, tente novamente! \n {ex.Message}");
            }
        }

        private static bool DezejaDeletarOUsuario()
        {
            return MessageBox.Show("Deseja realmente deletar o usuário? ", 
                "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes;
        }

        private void AoClicarEmCancelar(object sender, EventArgs e)
        {
            try
            {
                if (DeveSairDoSistema())
                {
                    this.Close();
                }
            }
            catch (Exception)
            {
                ExibirMensagem("Erro inesperado, tente novamente!");
            }
        }

        private static bool DeveSairDoSistema()
        {
            return MessageBox.Show("Usuários cadastrados serão apagados ao sair, deseja realmente continuar?",
                "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Usuários cadastrados serão apagados ao sair, deseja realmente continuar?", "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch (Exception)
            {
                ExibirMensagem("Erro inesperado, tente novamente!");
            }
        }

        public void AtualizarLista()
        {
            listaUsuarios.DataSource = null;
            listaUsuarios.DataSource = ListaDeUsuariosSalvos;
            listaUsuarios.Columns["Senha"].Visible = false;
        }

        private void ExibirMensagem(string mensagem)
        {
            MessageBox.Show(mensagem);
        }
    }
}
