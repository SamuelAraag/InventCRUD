using CRUD.Dominio;
using LinqToDB;
using LinqToDB.DataProvider.SqlServer;
using System.Configuration;
using System.Data;

namespace CRUD.Infra
{
    public class UsuarioRepositorioComLinqToDb : IUsuarioRepositorio
    {
        private static string StringConexaoBanco()
        {
            return ConfigurationManager.ConnectionStrings["conexaoSql"].ConnectionString;
        }

        public void AdicionarUsuario(Usuario usuario)
        {
            try
            {
                using var db = SqlServerTools.CreateDataConnection(StringConexaoBanco());
                {
                    try
                    {
                        usuario.Senha = ServicoDeCriptografia.CriptografarSenha(usuario.Senha);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Erro ao criptografar senha! " + ex);
                    }
                    db.Insert(usuario);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao adicionar novo usuário" + ex);
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
                using var db = SqlServerTools.CreateDataConnection(StringConexaoBanco());
                {
                    try
                    {
                        usuario.Senha = ServicoDeCriptografia.CriptografarSenha(usuario.Senha);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Erro ao criptografar senha! " + ex);
                    }
                    db.Update(usuario);
                }
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
                using var db = SqlServerTools.CreateDataConnection(StringConexaoBanco());
                {
                    db.GetTable<Usuario>()
                        .Where(u => u.Id == Id)
                        .Delete();
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
            var listaDeUsuarios =
                from usuarios in db.GetTable<Usuario>()
                select usuarios;
            return listaDeUsuarios.ToList();
        }

        public Usuario ObterPorId(int Id)
        {
            try
            {
                using var db = SqlServerTools.CreateDataConnection(StringConexaoBanco());
                var usuarioEncontrado = db.GetTable<Usuario>()
                        .FirstOrDefault(u => u.Id == Id);
                if (usuarioEncontrado == null)
                {
                    throw new Exception("Não foi possível encontrar o Usuario com Id" + Id);
                }
                return usuarioEncontrado;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter usuário pelo Id! ", ex);
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
