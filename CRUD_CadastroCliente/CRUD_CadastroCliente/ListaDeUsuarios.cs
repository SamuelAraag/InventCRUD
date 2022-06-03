﻿using CRUD_CadastroUsuario;
using System.Collections.Generic;
using System.Linq;

namespace CRUD_CadastroCliente
{
    public class ListaDeUsuarios
    {
        private static List<Usuario> instancia;
        public static List<Usuario> ObterInstancia()
        {
            if(instancia == null)
            {
                instancia = new List<Usuario>();
            }
            return instancia;
        }

        public static int ProximoId()
        {
            var atual = instancia.Any()  ? ObterInstancia().Max(x => x.Id) : (int)decimal.Zero;
            return ++atual;
        }
    }
}
