using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MVCSeguranca.Ed109.DAL.Persistencia;
using MVCSeguranca.Ed109.Generic.Implementacao;
using MVCSeguranca.Ed109.DAL.DataSource;
using MVCSeguranca.Ed109.Entidade;

namespace MVCSeguranca.Ed109.DAL.Persistencia
{
    public class ComprasDAO : AbstractGenericDAO<Compras,Conexao>
    {
        public ComprasDAO(Conexao objeto):base(objeto)
        {

        }
    }
}
