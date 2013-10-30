using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MVCSeguranca.Ed109.DTO;

namespace MVCSeguranca.Ed109.Negocio.Usuario.Interface
{
    public interface IUsuarioNegocio
    {

        Boolean autenticaUsuario(string login, string senha);
        Boolean cadastraUsuario(UsuarioDTO dto);
        Boolean resetaSenha(string senhaAntiga, string senhaNova);

    }
}
