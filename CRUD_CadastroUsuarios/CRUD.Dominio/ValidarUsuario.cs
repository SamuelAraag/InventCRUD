﻿namespace CRUD.Dominio
{
    public class ValidarUsuario
    {
        public void ValidarCampos(Usuario usuario)
        {
            const string nomeBase = "string";
            if ((usuario.Nome == String.Empty) && (usuario.Nome == nomeBase))
            {
                throw new Exception("Campo Nome, Obrigatório");
            }
            //const int tamanhoMax = 50;
            //if (caixaSenha.Text.Length > tamanhoMax)
            //{
            //    throw new Exception("Senha muito grande! ");
            //}
            //if (caixaSenha.Text == String.Empty)
            //{
            //    throw new Exception("Campo Senha, Obrigatório");
            //}
            //var email = caixaEmail.Text;
            //var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            //var match = regex.Match(email);
            //if (!match.Success)
            //{
            //    throw new Exception("Insira um email valido!");
            //}
            //var dataValida = DateTime.TryParseExact(caixaDataNascimento.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out var dt);
            //const string dataVazia = "  /  /";
            //if (caixaDataNascimento.Text != dataVazia && !dataValida)
            //{
            //    throw new Exception("Insira uma data valida!");
            //}
        
        }
    }
}
