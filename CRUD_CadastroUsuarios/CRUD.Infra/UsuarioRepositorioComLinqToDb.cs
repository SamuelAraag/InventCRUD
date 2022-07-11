using CRUD.Dominio;
using LinqToDB;
using LinqToDB.DataProvider.SqlServer;
using System.Data;

namespace CRUD.Infra
{
    public class UsuarioRepositorioComLinqToDb : IUsuarioRepositorio
    {
        public static string StringConexaoBanco()
        {
            string stringConexao = "Persist Security Info=False;User ID=sa;Password=sap@123;Initial Catalog=Usuarios;Data Source=INVENT085";
            return stringConexao;
        }

        public void AdicionarUsuario(Usuario usuario)
        {
            try
            {
                using var db = SqlServerTools.CreateDataConnection(StringConexaoBanco());
                {
                    usuario.Senha = CriptografarSenhaDoUsuario(usuario.Senha);
                    db.Insert(usuario);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao adicionar novo usuário" , ex);
            }
        }

        public void AtualizarUsuario(Usuario usuario)
        {
            try
            {
                if (usuario == null)
                {
                    throw new Exception("Usuario não encontrado!");
                }
                using var db = SqlServerTools.CreateDataConnection(StringConexaoBanco());
                {
                    usuario.Senha = CriptografarSenhaDoUsuario(usuario.Senha);
                    db.Update(usuario);
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Erro ao atualizar Usuário! " , ex);
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
                throw new Exception("Erro ao deletar usuário! " , ex);
            }
        }

        public List<Usuario> ObterTodos()
        {
            try
            {
                using var db = SqlServerTools.CreateDataConnection(StringConexaoBanco());
                var listaDeUsuarios =
                    from usuarios in db.GetTable<Usuario>()
                    select usuarios;
                return listaDeUsuarios.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar lista de Usuários! " , ex);
            }
        }

        public Usuario ObterPorId(int id)
        {
            try
            {
                using var db = SqlServerTools.CreateDataConnection(StringConexaoBanco());
                var usuarioEncontrado = db
                    .GetTable<Usuario>()
                    .FirstOrDefault(u => u.Id == id) ?? throw new Exception ("Não foi possível encontrar o Usuario com Id" + id);

                return usuarioEncontrado;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter usuário pelo Id! " + id , ex);
            }
        }
        
        private string CriptografarSenhaDoUsuario(string senhaACriptografar)
        {
            try
            {
                var senhaCriptografada = ServicoDeCriptografia.CriptografarSenha(senhaACriptografar);
                return senhaCriptografada;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criptografar a senha do Usuário " , ex);
            }
        }

        public bool ExisteEmailNoBanco(string email)
        {
            using var db = SqlServerTools.CreateDataConnection(StringConexaoBanco());
            var existeOemailNoBanco = db
                .GetTable<Usuario>()
                .Any(u => u.Email == email);
            
            return existeOemailNoBanco;
        }
    }
}
