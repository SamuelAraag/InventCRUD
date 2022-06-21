using CRUD.Dominio;
using LinqToDB;
using LinqToDB.DataProvider.SqlServer;
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
            var novoUsuario = new Usuario();
            try
            {
                using var db = SqlServerTools.CreateDataConnection(StringConexaoBanco());
                {
                    novoUsuario.Nome = usuario.Nome;
                    try
                    {
                        novoUsuario.Senha = ServicoDeCriptografia.CriptografarSenha(usuario.Senha);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Erro ao criptografar senha! " + ex);
                    }
                    novoUsuario.Email = usuario.Email;
                    if (usuario.DataNascimento == null)
                    {
                        novoUsuario.DataNascimento = null;
                    }
                    else
                    {
                        novoUsuario.DataNascimento = usuario.DataNascimento;
                    }
                    novoUsuario.DataCriacao = usuario.DataCriacao;

                    db.Insert(novoUsuario);
                }

                //using (var conn = AbrirConexaoComBanco())
                //{
                //    using (var cmd = conn.CreateCommand())
                //    {
                //        cmd.CommandText = "Insert into Usuario (Nome, Senha, Email, DataNascimento, DataCriacao)" +
                //        " values (@Nome, @Senha, @Email, @DataNascimento, @DataCriacao)";

                //        cmd.Parameters.AddWithValue("@Nome", usuario.Nome);
                //        try
                //        {
                //            cmd.Parameters.AddWithValue("@Senha", ServicoDeCriptografia.CriptografarSenha(usuario.Senha));
                //        }
                //        catch (Exception ex)
                //        {
                //            throw new Exception("Erro ao criptografar senha! " + ex);
                //        }
                //        cmd.Parameters.AddWithValue("@Email", usuario.Email);
                //        if (usuario.DataNascimento == null)
                //        {
                //            cmd.Parameters.AddWithValue("@DataNascimento", DBNull.Value);
                //        }
                //        else
                //        {
                //            cmd.Parameters.AddWithValue("@DataNascimento", usuario.DataNascimento.ToString());
                //        }
                //        cmd.Parameters.AddWithValue("@DataCriacao", usuario.DataCriacao);
                //        cmd.ExecuteNonQuery();
                //    }
                //}
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao adicionar novo usuário" + ex);
            }
        }

        public void AtualizarUsuario(Usuario usuario)
        {
            var usuarioAtualizado = new Usuario();
            try
            {
                if (usuario == null)
                {
                    throw new Exception("Usuario nulo!");
                }
                using var db = SqlServerTools.CreateDataConnection(StringConexaoBanco());
                {
                    usuarioAtualizado.Id = usuario.Id;
                    usuarioAtualizado.Nome = usuario.Nome;
                    try
                    {
                        usuarioAtualizado.Senha = ServicoDeCriptografia.CriptografarSenha(usuario.Senha);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Erro ao criptografar senha! " + ex);
                    }
                    usuarioAtualizado.Email = usuario.Email;
                    if(usuario.DataNascimento == null)
                    {
                        usuarioAtualizado.DataNascimento = null;
                    }
                    else
                    {
                        usuarioAtualizado.DataNascimento = usuario.DataNascimento;
                    }
                    usuarioAtualizado.DataCriacao = usuario.DataCriacao;
                    usuario = usuarioAtualizado;

                    db.Update(usuario);
                }








                //using (var conn = AbrirConexaoComBanco())
                //{
                //    using (var cmd = conn.CreateCommand())
                //    {
                //        cmd.CommandText = "Update Usuario set Nome=@Nome, Senha=@Senha, Email=@Email," +
                //        " DataNascimento=@DataNascimento, DataCriacao=@DataCriacao where Id=@Id";

                //        cmd.Parameters.AddWithValue("@Id", usuario.Id);
                //        cmd.Parameters.AddWithValue("@Nome", usuario.Nome);
                //        try
                //        {
                //            cmd.Parameters.AddWithValue("@Senha", ServicoDeCriptografia.CriptografarSenha(usuario.Senha));
                //        }
                //        catch (Exception ex)
                //        {
                //            throw new Exception("Erro ao criptografar senha! " + ex);
                //        }
                //        cmd.Parameters.AddWithValue("@Email", usuario.Email);
                //        if (usuario.DataNascimento == null)
                //        {
                //            cmd.Parameters.AddWithValue("@DataNascimento", DBNull.Value);
                //        }
                //        else
                //        {
                //            cmd.Parameters.AddWithValue("@DataNascimento", usuario.DataNascimento.ToString());
                //        }
                //        cmd.Parameters.AddWithValue("@DataCriacao", usuario.DataCriacao);
                //        cmd.ExecuteNonQuery();
                //    }
                //}
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao atualizar usuário" + ex);
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
                throw new Exception("Erro ao deletar usuário! " + ex);
            }
        }

        public List<Usuario> ObterTodos()
        {
            using var db = SqlServerTools.CreateDataConnection(StringConexaoBanco());

            var resultado =
                from usuarios in db.GetTable<Usuario>()
                select usuarios;

            return resultado.ToList();

            //Usando comandos banco de dados sqlConnection
            //SqlDataAdapter sqlDataAdapter = null;
            //DataTable bancoDataTable = new DataTable();
            //using (var conn = AbrirConexaoComBanco())
            //{
            //    using (var cmd = conn.CreateCommand())
            //    {
            //        cmd.CommandText = "select * from Usuario";
            //        sqlDataAdapter = new SqlDataAdapter(cmd.CommandText, conn);
            //        sqlDataAdapter.Fill(bancoDataTable);
            //    }
            //}
            //return Conversor.ConverterParaLista<Usuario>(bancoDataTable);
        }

        public Usuario ObterPorId(int id)
        {
            try
            {
                using var db = SqlServerTools.CreateDataConnection(StringConexaoBanco());
                var resultado =
                    from usuarios in db.GetTable<Usuario>()
                    select usuarios;

                var resultadoLista = resultado.ToList();

                var usuarioRetorno = resultadoLista.Find(u => u.Id == id);
                return usuarioRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter usuário pelo Id! " + ex);
            }
            
            //================================================================================
            //Usando comandos banco de dados sqlConnection
            //SqlDataAdapter sqlDataAdapter = null;
            //DataTable bancoDataTable = new DataTable();
            //try
            //{
            //    using (var conn = AbrirConexaoComBanco())
            //    {
            //        using (var cmd = conn.CreateCommand())
            //        {
            //            cmd.CommandText = "select * from Usuario";
            //            sqlDataAdapter = new SqlDataAdapter(cmd.CommandText, conn);
            //            sqlDataAdapter.Fill(bancoDataTable);
            //        }
            //    }
            //    var usuario = Conversor.ConverterParaLista<Usuario>(bancoDataTable).Find(u => u.Id == id);
            //    return usuario;
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception("Erro ao obter usuário pelo Id! " + ex);
            //}
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
