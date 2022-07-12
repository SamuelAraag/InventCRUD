﻿using CRUD.Dominio;

namespace CRUD.Infra
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        public void AdicionarUsuario(Usuario usuario)
        {
            var listaDeUsuarios = ListaDeUsuarios.ObterInstancia();
            var proximoId = ListaDeUsuarios.ProximoId();
            usuario.Id = proximoId;
            listaDeUsuarios.Add(usuario);
        }

        public void DeletarUsuario(int id)
        {
            var listaDeUsuarios = ListaDeUsuarios.ObterInstancia();
            var usuarioEncontrado = listaDeUsuarios.Find(u => u.Id == id) ?? throw new Exception("");
            listaDeUsuarios.Remove(usuarioEncontrado);
        }

        public void AtualizarUsuario(Usuario usuario)
        {
            var listaDeUsuarios = ListaDeUsuarios.ObterInstancia();
            var indice = listaDeUsuarios.FindIndex(usuario => usuario.Id == usuario.Id);
            listaDeUsuarios[indice] = usuario;
        }

        public Usuario ObterPorId(int id)
        {
            var listaDeUsuarios = ListaDeUsuarios.ObterInstancia();
            var usuarioBuscado = listaDeUsuarios.Find(u => u.Id == id);
            return usuarioBuscado;
        }

        public List<Usuario> ObterTodos()
        {
            var listaDeUsuarios = ListaDeUsuarios.ObterInstancia();
            return listaDeUsuarios;
        }

        public bool ExisteEmailNoBanco(string email)
        {
            bool resultado;
            var listaDeUsuarios = ListaDeUsuarios.ObterInstancia();
            resultado = listaDeUsuarios.Any(u => u.Email == email);
            return resultado;
        }

        public Usuario ObterUsuarioPorEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
