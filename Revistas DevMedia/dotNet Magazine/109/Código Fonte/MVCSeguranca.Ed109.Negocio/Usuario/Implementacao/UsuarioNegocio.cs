using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MVCSeguranca.Ed109.Negocio.Usuario.Interface;
using MVCSeguranca.Ed109.DTO;
using MVCSeguranca.Ed109.NH.DAL.Interface;

namespace MVCSeguranca.Ed109.Negocio.Usuario.Implementacao
{
    public class UsuarioNegocio: IUsuarioNegocio
    {
        #region Atributos para Injeção de Dependências

        private IUsuarioDAO dao;

        #endregion

        #region Regras de Negócio

        public bool autenticaUsuario(string login, string senha)
        {
            throw new NotImplementedException();
        }

        public bool cadastraUsuario(UsuarioDTO dto)
        {
            throw new NotImplementedException();
        }

        public bool resetaSenha(string senhaAntiga, string senhaNova)
        {
            throw new NotImplementedException();
        }

        #endregion
        
    }
}
