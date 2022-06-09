using CRUD_CadastroCliente;
using System;
using System.Windows.Forms;

namespace CRUD_CadastroUsuario
{

    public partial class FormularioConsultaUsuarios : Form
    {
        UsuarioRepositorio usuarioRepositorioComLista = new UsuarioRepositorio();
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
                var formularioNovoUsuario = new FormularioNovoUsuario(null);
                var resultado = formularioNovoUsuario.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    usuarioRepositorioBd.AdicionarUsuario(formularioNovoUsuario.Usuario);
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
                if (usuarioRepositorioBd.ConverterDataTableParaUsuario().Count == 0)
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
                        if(resultado == DialogResult.OK)
                        {
                            usuarioRepositorioBd.AtualizarUsuario(usuarioSelecionado);
                            MessageBox.Show("Usuario atualizado!");
                        }
                        
                    }
                }
            }
            catch (Exception)
            {
                ExibirMensagem("Erro inesperado, tente novamente!");
            }
            AtualizarLista();
        }

        private void AoClicarEmDeletar(object sender, EventArgs e)
        {
            try
            {
                if (listaUsuariosGrid.CurrentCell == null)
                {
                    ExibirMensagem("Nenhum usuário selecionado!");
                }
                else
                {
                    var indexSelecionado = listaUsuariosGrid.CurrentCell.RowIndex;
                    var usuarioSelecionado = listaUsuariosGrid.Rows[indexSelecionado].DataBoundItem as Usuario;

                    if (DesejaDeletarOUsuario())
                    {
                        usuarioRepositorioBd.DeletarUsuario(usuarioSelecionado.Id);
                        MessageBox.Show("Usuario deletado!");
                    }
                }
            }
            catch (Exception ex)
            {
                ExibirMensagem($"Erro inesperado, tente novamente! \n {ex.Message}");
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
            listaUsuariosGrid.DataSource = usuarioRepositorioBd.ConverterDataTableParaUsuario();
            listaUsuariosGrid.Columns["Senha"].Visible = false;
        }

        private void ExibirMensagem(string mensagem)
        {
            MessageBox.Show(mensagem);
        }
    }
}
