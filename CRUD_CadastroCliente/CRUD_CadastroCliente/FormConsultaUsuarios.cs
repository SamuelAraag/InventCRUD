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


            if (resultado == DialogResult.OK)
            {
                int ultimoIdInserido = 0;
                var idAtualASerInserido = 0;
                //Iniciar o ID com 1

                //se nao existir usuario inserido na lista ainda, iniciar a variavel do ultimoIdInserido
                // como 1.

                if (ListaDeUsuariosSalvos.Count == 0)
                {
                    ultimoIdInserido = 0;
                }
                else
                {
                    // criar uma variavel e armazenar o valor do ultimo ID inserido.
                    ultimoIdInserido = ListaDeUsuariosSalvos.Last().Id;

                }
                idAtualASerInserido = ultimoIdInserido + 1;

                //criar uma variavel do ID atual(que eu vou criar) que será inserido, que será alterado
                // no UsuarioASerCadastrado.

                //agora modificar o ID da variavel UsuarioASerCadastrado com o novo ID criado.
                formNovoUsuario.UsuarioASerCadastrado.Id = idAtualASerInserido;

                ListaDeUsuariosSalvos.Add(formNovoUsuario.UsuarioASerCadastrado);
                listaUsuarios.DataSource = null;
                listaUsuarios.DataSource = ListaDeUsuariosSalvos;
            }
        
        }

        private void botaoAtualizar_Click(object sender, EventArgs e)
        {
            //carregar usuarios na lista
            //listaUsuarios.Items.Add();

            FormNovoUsuario formNovoUsuario = new FormNovoUsuario(null);
            formNovoUsuario.ShowDialog();
        }

        private void botaoDeletar_Click(object sender, EventArgs e)
        {
            //Ao clicar, perguntar se quer excluir usuario selecionado na planilha
        }

        private void caixaLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            //carregar usuarios padrão
            //listaUsuarios.DataSource = Usuario;
        }

        private void botaoCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
