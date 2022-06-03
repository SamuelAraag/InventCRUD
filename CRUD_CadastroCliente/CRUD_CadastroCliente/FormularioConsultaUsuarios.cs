using CRUD_CadastroCliente;
using System;
using System.Windows.Forms;

namespace CRUD_CadastroUsuario
{

    public partial class FormularioConsultaUsuarios : Form
    {
        public FormularioConsultaUsuarios()
        {
            InitializeComponent();
        }

        public void AoClicarEmNovo(object sender, EventArgs e)
        {
            try
            {
                var formNovoUsuario = new FormularioNovoUsuario(null);
                var resultado = formNovoUsuario.ShowDialog();
                var usuarioRepositorio = new UsuarioRepositorio();
                if (resultado == DialogResult.OK)
                {
                    usuarioRepositorio.AdicionarUsuario(formNovoUsuario.Usuario);
                    AtualizarLista();
                }
            }
            catch (Exception)
            {
                ExibirMensagem("Erro inesperado, tente novamente!");
            }

        }
        private void AoClicarEmAtualizar(object sender, EventArgs e)
        {
            try
            {
                var usuarioRepositorio = new UsuarioRepositorio();
                if(usuarioRepositorio.ObterTodos().Count == 0)
                {
                    ExibirMensagem("Nenhum usuário selecionado!");
                }
                else
                {
                    var indexSelecionado = listaUsuariosGrid.CurrentCell.RowIndex;
                    var usuarioSelecionado = listaUsuariosGrid.Rows[indexSelecionado].DataBoundItem as Usuario;
                    var formNovoUsuario = new FormularioNovoUsuario(usuarioSelecionado);

                    if (usuarioSelecionado != null)
                    {
                        formNovoUsuario.Text = "Atualizar Usuario";
                        var resultado = formNovoUsuario.ShowDialog(this);
                        usuarioRepositorio.AtualizarUsuario(formNovoUsuario.Usuario);
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
                var usuarioRepositorio = new UsuarioRepositorio();
                var listaDeUsuarios = ListaDeUsuarios.ObterInstancia();
                var usuario = new Usuario();

                if (listaUsuariosGrid.CurrentCell == null)
                {
                    ExibirMensagem("Nenhum usuário selecionado!");
                    throw new Exception("Nenhum usuário selecionado!");

                }
                else
                {
                    var indexSelecionado = listaUsuariosGrid.CurrentCell.RowIndex;
                    var usuarioSelecionado = listaUsuariosGrid.Rows[indexSelecionado].DataBoundItem as Usuario;

                    if (DesejaDeletarOUsuario())
                    {
                        usuarioRepositorio.DeletarUsuario(usuarioSelecionado.id);
                        AtualizarLista();
                    }
                }
            }
            catch (Exception ex)
            {
                ExibirMensagem($"Erro inesperado, tente novamente! \n {ex.Message}");
            }
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

        private void AoClicarEmOk(object sender, EventArgs e)
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

        public void AtualizarLista()
        {
            var listaDeUsuarios = ListaDeUsuarios.ObterInstancia();
            listaUsuariosGrid.DataSource = null;
            listaUsuariosGrid.DataSource = listaDeUsuarios;
            listaUsuariosGrid.Columns["Senha"].Visible = false;
        }

        private void ExibirMensagem(string mensagem)
        {
            MessageBox.Show(mensagem);
        }
    }
}
