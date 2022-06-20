namespace CRUD.Dominio
{
    public interface IUsuarioRepositorio : IDisposable
    {
        void AdicionarUsuario(Usuario usuario);
        void DeletarUsuario(int id);
        void AtualizarUsuario(Usuario usuario);
        Usuario ObterPorId(int id);
        List<Usuario> ObterTodos();
    }
}
