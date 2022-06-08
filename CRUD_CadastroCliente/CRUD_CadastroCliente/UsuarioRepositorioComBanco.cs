using CRUD_CadastroUsuario;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;

namespace CRUD_CadastroCliente
{
    public class UsuarioRepositorioComBanco
    {
        private string strCon = @"Persist Security Info=False;User ID=sa;Password=sap@123;Initial Catalog=Usuarios;Data Source=DESKTOP-7MCFTA2";
        SqlConnection sqlCon = null;
        private string strSql = string.Empty;

        public void AdicionarUsuario(Usuario usuario)
        {
            try
            {
                strSql = "Insert into Usuario (Nome, Senha, Email, DataNascimento, DataCriacao)" +
                " values (@Nome, @Senha, @Email, @DataNascimento, @DataCriacao)";
                sqlCon = new SqlConnection(strCon);
                SqlCommand cmd = new SqlCommand(strSql, sqlCon);

                cmd.Parameters.Add("@Nome", SqlDbType.VarChar).Value = usuario.Nome;
                cmd.Parameters.Add("@Senha", SqlDbType.VarChar).Value = usuario.Senha;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = usuario.Email;
                cmd.Parameters.Add("@DataNascimento", SqlDbType.DateTime).Value = usuario.DataNascimento.ToString();
                cmd.Parameters.Add("@DataCriacao", SqlDbType.DateTime).Value = usuario.DataCriacao.ToString();

                sqlCon.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }

        public void AtualizarUsuario(Usuario usuario)
        {
            strSql = "update Usuario set Nome=@Nome, Senha=@Senha, Email=@Email, DataNascimento=@DataNascimento, DataCriacao=@DataCriacao where Id=@Id";
            sqlCon = new SqlConnection(@strCon);
            SqlCommand cmd = new SqlCommand(strSql, sqlCon);

            cmd.Parameters.Add("Id", SqlDbType.Int).Value = usuario.Id;
            cmd.Parameters.Add("Nome", SqlDbType.VarChar).Value = usuario.Nome;
            cmd.Parameters.Add("Senha", SqlDbType.VarChar).Value = usuario.Senha;
            cmd.Parameters.Add("Email", SqlDbType.VarChar).Value = usuario.Email;
            cmd.Parameters.Add("DataNascimento", SqlDbType.DateTime).Value = usuario.DataNascimento;
            cmd.Parameters.Add("DataCriacao", SqlDbType.DateTime).Value = usuario.DataCriacao;

            try
            {
                sqlCon.Open();
                cmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }

        public void DeletarUsuario(int Id)
        {
            var usuario = new Usuario();
            try
            {
                strSql = "delete from Usuario where Id=@Id";
                sqlCon = new SqlConnection(strCon);
                SqlCommand cmd = new SqlCommand(strSql, sqlCon);
                cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id.ToString();
                try
                {
                    sqlCon.Open();
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    sqlCon.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public List<Usuario> ObterTodos()
        {
            var strSql = "SELECT * FROM Usuario";
            sqlCon = new SqlConnection(strCon);

            var usuariosDoBanco = new List<Usuario>();

            using (SqlConnection cn = new SqlConnection(strCon))
            {
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand(strSql, sqlCon);
                var leitor = cmd.ExecuteReader();

                while (leitor.Read())
                {
                    var linha = ObterUsuarioPor(leitor);
                    usuariosDoBanco.Add(linha);
                }
            }
            return usuariosDoBanco;
        }

        private Usuario ObterUsuarioPor(SqlDataReader linha)
        {
            return new Usuario
            {
                Id = (int)linha["Id"],
                DataCriacao = (DateTime)linha["DataCriacao"],
                DataNascimento = (DateTime?)linha["DataNascimento"],
                Email = (string)linha["Email"],
                Senha = (string)linha["Senha"],
                Nome = (string)linha["Nome"]
            };
        }

        //public Usuario ObterPorId(int id)
        //{
        //    SqlDataAdapter da = null;
        //    DataTable dt = new DataTable();
        //    var usuario = new Usuario();

        //    sqlCon = new SqlConnection(strCon);
        //    try
        //    {
        //        using (var cmd = new SqlCommand(strSql, sqlCon))
        //        {
        //            cmd.CommandText = "SELECT * FROM UsuarioI where UsuarioId=" + id;
        //            da = new SqlDataAdapter(cmd.CommandText, strSql);
        //            da.Fill(dt);

        //            usuario.Id = Convert.ToInt32(dt.Rows[0]["ID"]);
        //            usuario.Nome = dt.Rows[0]["Nome"].ToString();
        //            usuario.Senha = dt.Rows[0]["Senha"].ToString();
        //            usuario.Email = dt.Rows[0]["Email"].ToString();
        //            usuario.DataNascimento = Convert.ToDateTime(dt.Rows[0]["DataNascimento"]);
        //            usuario.DataCriacao = Convert.ToString(dt.Rows[0]["DataCriacao"]);

        //            sqlCon.Open();
        //            return usuario;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
