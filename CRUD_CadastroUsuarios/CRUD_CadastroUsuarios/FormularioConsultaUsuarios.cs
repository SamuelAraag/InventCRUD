using CRUD.Dominio;
using CRUD.Infra;

namespace CRUD_CadastroUsuarios
{
    public partial class FormularioConsultaUsuarios : Form
    {
        //UsuarioRepositorio usuarioRepositorioComLista = new UsuarioRepositorio();
        UsuarioRepositorioComBanco usuarioRepositorioBd = new UsuarioRepositorioComBanco();
        private IUsuarioRepositorio _usuarioRepositorio;

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
                var formularioNovoUsuario = new FormularioNovoUsuario(null);
                var resultado = formularioNovoUsuario.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    usuarioRepositorioBd.AdicionarUsuario(formularioNovoUsuario.Usuario);
                    listaUsuariosGrid.DataSource = usuarioRepositorioBd.ObterTodos();
                    MessageBox.Show("Usuário adicionado com sucesso!");
                }
                AtualizarLista();
            }
            catch (Exception ex)
            {
                ExibirMensagem(ex.Message);
            }
        }

        private void AoClicarEmAtualizar(object sender, EventArgs e)
        {
            try
            {
                var indexSelecionado = listaUsuariosGrid.CurrentCell.RowIndex;
                if (listaUsuariosGrid.CurrentCell.RowIndex == -1)
                {
                    throw new Exception("Nenhum usuário selecionado!");
                }
                else
                {
                    indexSelecionado = listaUsuariosGrid.CurrentCell.RowIndex;
                    var usuarioSelecionado = (listaUsuariosGrid.Rows[indexSelecionado].DataBoundItem as Usuario) 
                        ?? throw new Exception("");

                    var formNovoUsuario = new FormularioNovoUsuario(usuarioSelecionado.Id, _usuarioRepositorio);
                    
                    formNovoUsuario.Text = "Atualizar Usuario";
                    var resultado = formNovoUsuario.ShowDialog(this);
                    if(resultado == DialogResult.OK)
                    {
                        usuarioRepositorioBd.AtualizarUsuario(usuarioSelecionado);
                        MessageBox.Show("Usuario atualizado com sucesso!");
                    }
                }
            }
            catch (Exception ex)
            {
                ExibirMensagem(ex.Message);
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
                listaUsuariosGrid.DataSource = usuarioRepositorioBd.ObterTodos();
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
