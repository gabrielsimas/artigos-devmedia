using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MVCSeguranca.Ed109.Generic.Implementacao;
using MVCSeguranca.Ed109.Entidade;
using MVCSeguranca.Ed109.DAL.DataSource;

namespace MVCSeguranca.Ed109.DAL.Persistencia
{
    public class UsuarioDAO : AbstractGenericDAO<Usuario,Conexao>
    {
        public UsuarioDAO(Conexao objeto): base(objeto)
        {
            
        }
    }
}
