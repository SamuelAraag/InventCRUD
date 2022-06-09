using CRUD_CadastroUsuario;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using System.Security.Cryptography;

namespace CRUD_CadastroCliente
{
    public class UsuarioRepositorioComBanco : IDisposable
    {
        private static SqlConnection conexaoSql;
        private static string sqlConexaoString;

        public UsuarioRepositorioComBanco() { }
        private static string StringConexaoBanco()
        {
            sqlConexaoString = ConfigurationManager.ConnectionStrings["conexaoSql"].ConnectionString;
            return sqlConexaoString;
        }
        private static SqlConnection AbrirConexaoBanco()
        {
            conexaoSql = new SqlConnection(ConfigurationManager.ConnectionStrings["conexaoSql"].ConnectionString);
            conexaoSql.Open();
            return conexaoSql;
        }

        public void AdicionarUsuario(Usuario usuario)
        {
            try
            {
                var cmd = AbrirConexaoBanco().CreateCommand();
                cmd.CommandText = "Insert into Usuario (Nome, Senha, Email, DataNascimento, DataCriacao)" +
                " values (@Nome, @Senha, @Email, @DataNascimento, @DataCriacao)";

                
                cmd.Parameters.AddWithValue("@Nome", usuario.Nome);
                string senhaCriptografada = CriptografarSenha(usuario.Senha);
                cmd.Parameters.AddWithValue("@Senha", senhaCriptografada);
                cmd.Parameters.AddWithValue("@Email", usuario.Email);
                if(usuario.DataNascimento == null)
                {
                    cmd.Parameters.AddWithValue("@DataNascimento", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@DataNascimento", usuario.DataNascimento.ToString());
                }
                cmd.Parameters.AddWithValue("@DataCriacao", usuario.DataCriacao);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexaoSql.Close();
            }
        }

        public void AtualizarUsuario(Usuario usuario)
        {
            try
            {
                var cmd = AbrirConexaoBanco().CreateCommand();
                cmd.CommandText = "Update Usuario set Nome=@Nome, Senha=@Senha, Email=@Email," +
                " DataNascimento=@DataNascimento, DataCriacao=@DataCriacao where Id=@Id";
                cmd.Parameters.AddWithValue("@Id", usuario.Id);
                cmd.Parameters.AddWithValue("@Nome", usuario.Nome);
                cmd.Parameters.AddWithValue("@Senha", usuario.Senha);
                cmd.Parameters.AddWithValue("@Email", usuario.Email);
                if (usuario.DataNascimento == null)
                {
                    cmd.Parameters.AddWithValue("@DataNascimento", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@DataNascimento", usuario.DataNascimento.ToString());
                }
                cmd.Parameters.AddWithValue("@DataCriacao", usuario.DataCriacao);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexaoSql.Close();
            }
        }

        public void DeletarUsuario(int Id)
        {
            try
            {
                var cmd = AbrirConexaoBanco().CreateCommand();
                cmd.CommandText = "delete from Usuario where Id=@Id";
                cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id.ToString();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexaoSql.Close();
            }
        }

        public DataTable ObterTodos()
        {
            SqlDataAdapter sqlDataAdapter = null;
            DataTable bancoDataTable = new DataTable();

            using(var conexaoBanco = AbrirConexaoBanco())
            {
                using(var cmd = conexaoBanco.CreateCommand())
                {
                    cmd.CommandText = "select * from Usuario";
                    sqlDataAdapter = new SqlDataAdapter(cmd.CommandText, conexaoBanco);
                    sqlDataAdapter.Fill(bancoDataTable);
                    return bancoDataTable;
                }
            }
        }

        public List<Usuario> ConverterDataTableParaUsuario()
        {
            var usuarioRepositorioBd = new UsuarioRepositorioComBanco();
            var converterParaLista = new Conversor();
            return converterParaLista.ConverterParaLista<Usuario>(usuarioRepositorioBd.ObterTodos());
        }

        //Criar metodo para criptografar senha
        public string CriptografarSenha(string senhaACriptografar)
        {
            CriptografarSenha criptografarSenha = new CriptografarSenha();
            var senhaCriptografada = criptografarSenha.SenhaDigitada(senhaACriptografar);

            return senhaCriptografada;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
