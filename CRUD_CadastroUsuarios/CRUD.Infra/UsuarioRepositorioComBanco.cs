using CRUD.Dominio;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CRUD.Infra
{
    public class UsuarioRepositorioComBanco : IUsuarioRepositorio
    {
        private static SqlConnection conexaoSql;

        private static string StringConexaoBanco()
        {
            return ConfigurationManager.ConnectionStrings["conexaoSql"].ConnectionString;
        }

        private static SqlConnection AbrirConexaoComBanco()
        {
            conexaoSql = new SqlConnection(StringConexaoBanco());
            conexaoSql.Open();
            return conexaoSql;
        }

        public void AdicionarUsuario(Usuario usuario)
        {
            using (var conn = AbrirConexaoComBanco())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "Insert into Usuario (Nome, Senha, Email, DataNascimento, DataCriacao)" +
                    " values (@Nome, @Senha, @Email, @DataNascimento, @DataCriacao)";

                    cmd.Parameters.AddWithValue("@Nome", usuario.Nome);
                    cmd.Parameters.AddWithValue("@Senha", ServicoDeCriptografia.CriptografarSenha(usuario.Senha));
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
            }
        }

        public void AtualizarUsuario(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new Exception("Usuario nulo");
            }
            using (var conn = AbrirConexaoComBanco())
            {
                using (var cmd = conn.CreateCommand())
                {
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
            }
        }

        public void DeletarUsuario(int Id)
        {
            using (var conn = AbrirConexaoComBanco())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "delete from Usuario where Id=@Id";
                    cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = Id.ToString();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Usuario> ObterTodos()
        {
            SqlDataAdapter sqlDataAdapter = null;
            DataTable bancoDataTable = new DataTable();
            using (var conn = AbrirConexaoComBanco())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select * from Usuario";
                    sqlDataAdapter = new SqlDataAdapter(cmd.CommandText, conn);
                    sqlDataAdapter.Fill(bancoDataTable);
                }
            }
            return Conversor.ConverterParaLista<Usuario>(bancoDataTable);
        }

        public Usuario ObterPorId(int id)
        {
            SqlDataAdapter sqlDataAdapter = null;
            DataTable bancoDataTable = new DataTable();
            using (var conn = AbrirConexaoComBanco())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select * from Usuario";
                    sqlDataAdapter = new SqlDataAdapter(cmd.CommandText, conn);
                    sqlDataAdapter.Fill(bancoDataTable);
                }
            }
            var usuario = Conversor.ConverterParaLista<Usuario>(bancoDataTable).Find(u => u.Id == id);
            return usuario;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
