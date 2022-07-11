using CRUD.Dominio;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CRUD.Infra
{
    public class UsuarioRepositorioComBanco : IUsuarioRepositorio
    {
        private static SqlConnection conexaoSql;

        private static string BancoConexao()
        {
            return ConfigurationManager.ConnectionStrings["conexaoSql"].ConnectionString;
        }
        private static SqlConnection AbrirConexaoComBanco()
        {
            conexaoSql = new SqlConnection(BancoConexao());
            conexaoSql.Open();
            return conexaoSql;
        }

        public void AdicionarUsuario(Usuario usuario)
        {
            try
            {
                using (var conn = AbrirConexaoComBanco())
                {
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Insert into Usuario (Nome, Senha, Email, DataNascimento, DataCriacao)" +
                        " values (@Nome, @Senha, @Email, @DataNascimento, @DataCriacao)";

                        cmd.Parameters.AddWithValue("@Nome", usuario.Nome);
                        try
                        {
                            cmd.Parameters.AddWithValue("@Senha", ServicoDeCriptografia.CriptografarSenha(usuario.Senha));
                        }
                        catch (Exception)
                        {
                            throw new Exception("Erro ao criptografar senha! ");
                        }
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
            catch (Exception ex)
            {
                throw new Exception("Erro ao adicionar novo Usuários! " , ex);
            }
        }

        public void AtualizarUsuario(Usuario usuario)
        {
            try
            {
                if (usuario == null)
                {
                    throw new Exception("Usuario nulo!");
                }
                using (var conn = AbrirConexaoComBanco())
                {
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "Update Usuario set Nome=@Nome, Senha=@Senha, Email=@Email," +
                        " DataNascimento=@DataNascimento, DataCriacao=@DataCriacao where Id=@Id";

                        cmd.Parameters.AddWithValue("@Id", usuario.Id);
                        cmd.Parameters.AddWithValue("@Nome", usuario.Nome);
                        try
                        {
                            cmd.Parameters.AddWithValue("@Senha", ServicoDeCriptografia.CriptografarSenha(usuario.Senha));
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Erro ao criptografar senha! " + ex);
                        }
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
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar Usuário! " , ex);
            }
        }

        public void DeletarUsuario(int Id)
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception("Erro ao deletar Usuário! " , ex);
            }
        }

        public List<Usuario> ObterTodos()
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar lista de Usuários! " , ex);
            }
        }

        public Usuario ObterPorId(int id)
        {
            SqlDataAdapter sqlDataAdapter = null;
            DataTable bancoDataTable = new DataTable();
            try
            {
                using (var conn = AbrirConexaoComBanco())
                {
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "select * from Usuario";
                        sqlDataAdapter = new SqlDataAdapter(cmd.CommandText, conn);
                        sqlDataAdapter.Fill(bancoDataTable);
                    }
                }
                var usuarioARetornar = Conversor.ConverterParaLista<Usuario>(bancoDataTable).Find(u => u.Id == id);
                if (usuarioARetornar == null)
                {
                    throw new Exception("Usuário Id não encontrado");
                }
                return usuarioARetornar;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter usuário pelo Id! " , ex);
            }
        }


        public bool ExisteEmailNoBanco(string email)
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
            var emailExiste = Conversor.ConverterParaLista<Usuario>(bancoDataTable).Exists(u => u.Email == email);
            return emailExiste;
        }
    }
}
