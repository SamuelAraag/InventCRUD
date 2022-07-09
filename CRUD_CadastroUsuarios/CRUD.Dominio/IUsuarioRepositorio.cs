﻿namespace CRUD.Dominio
{
    public interface IUsuarioRepositorio
    {
        void AdicionarUsuario(Usuario usuario);
        void DeletarUsuario(int id);
        void AtualizarUsuario(Usuario usuario);
        Usuario ObterPorId(int id);
        List<Usuario> ObterTodos();

        public Usuario ObterUsuarioPorEmail(string email);

        //public bool EmailExistente(string email);
    }
}
