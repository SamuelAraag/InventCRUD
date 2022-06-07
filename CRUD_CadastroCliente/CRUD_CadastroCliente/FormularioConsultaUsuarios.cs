using CRUD_CadastroCliente;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace CRUD_CadastroUsuario
{

    public partial class FormularioConsultaUsuarios : Form
    {
        //Instancia do repositorio com lista singleton
        UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();
        //Instanciar o repositorio com o banco de dados
        UsuarioRepositorioComBanco usuarioRepositorioBd = new UsuarioRepositorioComBanco();

        public FormularioConsultaUsuarios()
        {
            InitializeComponent();
            AtualizarLista();
        }

        public void AoClicarEmNovo(object sender, EventArgs e)
        {
            try
            {
                var formNovoUsuario = new FormularioNovoUsuario(null);
                var resultado = formNovoUsuario.ShowDialog();
                var usuarioRepositorio = new UsuarioRepositorioComBanco();
                if (resultado == DialogResult.OK)
                {
                    usuarioRepositorioBd.AdicionarUsuario(formNovoUsuario.Usuario);
                    listaUsuariosGrid.DataSource = usuarioRepositorioBd.ObterTodos();
                }
            }
            catch (Exception)
            {
                ExibirMensagem("Erro inesperado, tente novamente!");
            }
            AtualizarLista();
        }

        private void AoClicarEmAtualizar(object sender, EventArgs e)
        {
            try
            {
                var usuarioRepositorio = new UsuarioRepositorio();
                if (usuarioRepositorio.ObterTodos().Count == 0)
                {
                    ExibirMensagem("Nenhum usuário selecionado!");
                }
                else
                {
                    var indexSelecionado = listaUsuariosGrid.CurrentCell.RowIndex;
                    var usuarioSelecionado = listaUsuariosGrid.Rows[indexSelecionado].DataBoundItem as Usuario;
                    var usuario = usuarioRepositorio.ObterPorId(usuarioSelecionado.Id).ShallowCopy() as Usuario;
                    var formNovoUsuario = new FormularioNovoUsuario(usuario);

                    if (usuarioSelecionado != null)
                    {
                        formNovoUsuario.Text = "Atualizar Usuario";
                        var resultado = formNovoUsuario.ShowDialog(this);
                        usuarioRepositorio.AtualizarUsuario(usuario);
                        AtualizarLista();
                    }
                }
            }
            catch (Exception)
            {
                ExibirMensagem("Erro inesperado, tente novamente!");
            }
        }

        private void AoClicarEmDeletar(object sender, EventArgs e)
        {
            try
            {
                if (listaUsuariosGrid.CurrentCell == null)
                {
                    ExibirMensagem("Nenhum usuário selecionado!");
                    throw new Exception("Nenhum usuário selecionado!");
                }
                else
                {
                    var indexSelecionado = listaUsuariosGrid.CurrentCell.RowIndex;
                    var usuarioSelecionado = listaUsuariosGrid.Rows[indexSelecionado].DataBoundItem as Usuario;

                    ////var formNovoUsuario = new FormularioNovoUsuario(usuario);

                    if (DesejaDeletarOUsuario())
                    {
                        usuarioRepositorioBd.DeletarUsuario(usuarioSelecionado.Id);
                        MessageBox.Show("Usuario deletado!");
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
            //Carregar com banco de dados
            listaUsuariosGrid.DataSource = usuarioRepositorioBd.ObterTodos();
            //=======================================================
            ////Atualizar grid com banco em lista
            //var listaDeUsuarios = ListaDeUsuarios.ObterInstancia();
            //listaUsuariosGrid.DataSource = null;
            //listaUsuariosGrid.DataSource = listaDeUsuarios;
            listaUsuariosGrid.Columns["Senha"].Visible = false;
            listaUsuariosGrid.Columns["DataNascimento"].DefaultCellStyle.Format = "dd/MM/yyyy";
            listaUsuariosGrid.Columns["DataCriacao"].DefaultCellStyle.Format = "d";
            

        }

        private void ExibirMensagem(string mensagem)
        {
            MessageBox.Show(mensagem);
        }

        private void listaUsuariosGrid_ColumnDefaultCellStyleChanged(object sender, DataGridViewColumnEventArgs e)
        { 
        }
    }
}
