﻿using CRUD.Dominio;
using FluentValidation;

namespace CRUD_CadastroUsuarios
{
    public partial class FormularioConsultaUsuarios : Form
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private IValidator<Usuario> validadorUsuario;

        public FormularioConsultaUsuarios(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
            InitializeComponent();
            AtualizarLista();
        }

        public void AoClicarEmNovo(object sender, EventArgs e)
        {
            try
            { 
                var usuarioNovo = (int)decimal.Zero;
                var formularioNovoUsuario = new FormularioNovoUsuario(usuarioNovo, _usuarioRepositorio, validadorUsuario);
                var resultado = formularioNovoUsuario.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    _usuarioRepositorio.AdicionarUsuario(formularioNovoUsuario.usuario);
                    listaUsuariosGrid.DataSource = _usuarioRepositorio.ObterTodos();
                    MessageBox.Show("Usuário adicionado com sucesso!");
                }
                AtualizarLista();
            }
            catch (Exception ex)
            {
                var mensagem = $"{ex.Message}{ex.InnerException?.Message}";
                ExibirMensagem(mensagem);
            }
        }

        private void AoClicarEmAtualizar(object sender, EventArgs e)
        {
            try
            {
                if (listaUsuariosGrid.CurrentCell == null)
                {
                    throw new Exception("Nenhum usuário selecionado!");
                }
                var indexSelecionado = listaUsuariosGrid.CurrentCell.RowIndex;
                indexSelecionado = listaUsuariosGrid.CurrentCell.RowIndex;
                var usuarioSelecionado = (listaUsuariosGrid.Rows[indexSelecionado].DataBoundItem as Usuario)
                    ?? throw new Exception("Nenhum usuário selecionado");

                var formNovoUsuario = new FormularioNovoUsuario(usuarioSelecionado.Id, _usuarioRepositorio, validadorUsuario);

                formNovoUsuario.Text = "Atualizar Usuário";
                var resultado = formNovoUsuario.ShowDialog(this);
                if (resultado == DialogResult.OK)
                {
                    _usuarioRepositorio.AtualizarUsuario(formNovoUsuario.usuario);
                    MessageBox.Show("Usuário atualizado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                var mensagem = $"{ex.Message}{ex.InnerException?.Message}";
                ExibirMensagem(mensagem);
            }
            AtualizarLista();
        }

        private void AoClicarEmDeletar(object sender, EventArgs e)
        {
            try
            {
                if (listaUsuariosGrid.CurrentCell == null)
                {
                    ExibirMensagem("Nenhum Usuário selecionado!");
                }
                var indexSelecionado = listaUsuariosGrid.CurrentCell.RowIndex;
                var usuarioSelecionado = listaUsuariosGrid.Rows[indexSelecionado].DataBoundItem as Usuario;
                if (DesejaDeletarOUsuario())
                {
                     _usuarioRepositorio.DeletarUsuario(usuarioSelecionado.Id);
                     MessageBox.Show("Usuário deletado!");
                }
            }
            catch (Exception ex)
            {
                ExibirMensagem(ex.Message);
            }
            AtualizarLista();
        }
        private static bool DesejaDeletarOUsuario()
        {
            return MessageBox.Show("Deseja realmente deletar o usuário? ", 
                "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes;
        }

        private void AoClicarEmCancelar(object sender, EventArgs e)
        {
            try
            {
                if (DeveSairDoCadastroDeUsuario())
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                ExibirMensagem(ex.Message);
            }
        }

        private void AoClicarEmOk(object sender, EventArgs e)
        {
            try
            {
                if (DeveSairDoCadastroDeUsuario())
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                ExibirMensagem(ex.Message);
            }
        }

        private static bool DeveSairDoCadastroDeUsuario()
        {
            var resultadoDialogResult = MessageBox.Show("Usuários cadastrados serão apagados ao sair, " +
                "deseja realmente continuar?",
                "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            return resultadoDialogResult == DialogResult.Yes;
        }

        public void AtualizarLista()
        {
            try
            {
                listaUsuariosGrid.DataSource = _usuarioRepositorio.ObterTodos();
                listaUsuariosGrid.Columns["Senha"].Visible = false;
                listaUsuariosGrid.Columns["Id"].Width = 25;
                listaUsuariosGrid.Columns["Nome"].Width = 150;
                listaUsuariosGrid.Columns["Email"].Width = 200;
                listaUsuariosGrid.Columns["DataNascimento"].Width = 130;
                listaUsuariosGrid.Columns["DataNascimento"].HeaderText = "Data de Nascimento";
                listaUsuariosGrid.Columns["DataCriacao"].Width = 140;
                listaUsuariosGrid.Columns["DataCriacao"].HeaderText = "Data de Criacao";
            }
            catch (Exception ex)
            {
                ExibirMensagem(ex.Message);
            }
        }

        private void ExibirMensagem(string mensagem)
        {
            MessageBox.Show(mensagem);
        }
    }
}
