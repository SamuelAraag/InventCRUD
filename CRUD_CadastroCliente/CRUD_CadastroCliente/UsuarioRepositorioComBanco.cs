using CRUD_CadastroUsuario;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;
using System.Data;
using System.Windows.Forms;

namespace CRUD_CadastroCliente
{
    public class UsuarioRepositorioComBanco
    {
        //Conexão com o banco de dados
        private string strCon = @"Persist Security Info=False;User ID=sa;Password=sap@123;Initial Catalog=Usuarios;Data Source=DESKTOP-7MCFTA2";
        SqlConnection sqlCon = null;
        private string strSql = string.Empty;

        FormularioNovoUsuario formNovoUsuario = new FormularioNovoUsuario(null);

        public void AdicionarUsuario()
        {
            //Criar conexão com bd e salvar novo Usuario
            //O que fazer no banco - Salvar campos na tabela
            strSql = "Insert into Usuario (Nome, Senha, Email, DataNascimento, DataCriacao)" +
            " values (@Nome, @Senha, @Email, @DataNascimento, @DataCriacao)";
            sqlCon = new SqlConnection(strCon);
            SqlCommand sqlCmd = new SqlCommand(strSql, sqlCon);


            //var listaDeUsuarios = ListaDeUsuarios.ObterInstancia();
            //var proximoId = ListaDeUsuarios.ProximoId();
            //usuario.Id = proximoId;
            //listaDeUsuarios.Add(usuario);
        }

        public DataTable ObterTodos()
        {
            //Metodo para testar a conexão com o banco de dados, carregando tabela no dataGrid
            var strSql = "SELECT * FROM Usuario";
            sqlCon = new SqlConnection(strCon);

            using (SqlConnection cn = new SqlConnection(strCon))
            {
            sqlCon.Open();
                using (SqlDataAdapter objAdp = new SqlDataAdapter(strSql, sqlCon))
                {
                    using (DataTable dtLista = new DataTable())
                    {
                        objAdp.Fill(dtLista);
                        return dtLista;
                    }
                }
            }
        }
    }
}
